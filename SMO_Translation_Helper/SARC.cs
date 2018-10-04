using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SMO_Translation_Helper
{
	class SARC
	{
		public Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();

		public ByteOrder byteOrder = ByteOrder.LittleEndian;
		public int padding = -1;

		struct SFATNode
		{
			public int nameHash;
			public int nameTableOffset;
			public int fileDataOffset;
			public int endFileDataOffset;
			public bool hasString;
		}

		public SARC()
		{

		}

		public void Read(byte[] file)
		{
			FileInput f = new FileInput(file);
			f.byteOrder = byteOrder;
			f.Seek(8); // SARC+Endianness

			int archiveSize = f.ReadInt();
			int startOffset = f.ReadInt();
			padding = startOffset;
			f.Skip(10); // SFAT
			int nodeCount = f.ReadShort();
			int hashMultiplier = f.ReadInt();

			List<SFATNode> sfatNodes = new List<SFATNode>();
			for (int i = 0; i < nodeCount; i++)
			{
				SFATNode temp;
				temp.nameHash = f.ReadInt();
				temp.nameTableOffset = f.ReadInt() - 0x1000000;
				if (temp.nameTableOffset == -0x1000000)
					temp.hasString = false;
				else
					temp.hasString = true;
				temp.fileDataOffset = f.ReadInt();
				temp.endFileDataOffset = f.ReadInt();
				sfatNodes.Add(temp);
			}

			f.Skip(8);

			int nameTableStart = f.Position();
			foreach (SFATNode sfat in sfatNodes)
			{
				string tempName;
				if (sfat.hasString)
				{
					f.Seek(sfat.nameTableOffset * 4 + nameTableStart);
					tempName = f.ReadString();
				}
				else
					tempName = "0x" + sfat.nameHash.ToString("X8");
				f.Seek(sfat.fileDataOffset + startOffset);
				byte[] tempFile = f.Read(sfat.endFileDataOffset - sfat.fileDataOffset);
				files.Add(tempName, tempFile);
			}
		}

		uint GetHash(char[] name, int length, uint multiplier)
		{
			uint result = 0;
			for (int i = 0; i < length; i++)
			{
				result = name[i] + result * multiplier;
			}
			return result;
		}

		int GetSizeInChunks(int length, int chunkSize)
		{
			int i = length;
			while (i % 4 != 0)
				i++;
			return i;
		}

		private int sfatStartOffset;

		private byte[] RebuildSFATArchive()
		{
			FileOutput f = new FileOutput();
			f.byteOrder = byteOrder;

			f.WriteString("SFAT");
			f.WriteShort(0xC);
			f.WriteShort(files.Count);
			f.WriteInt(0x65);

			int stringPos = 0;
			int dataPos = 0;
			bool isString = true;
			foreach (string filename in files.Keys)
			{
				if (filename.Contains("0x"))
				{
					isString = false;
					f.WriteInt((int)Convert.ToInt32(filename, 16));
					f.WriteInt(0);
				}
				else
				{
					f.WriteInt((int)GetHash(filename.ToArray(), filename.Length, 0x65));
					f.WriteInt(stringPos + 0x1000000);
					stringPos += GetSizeInChunks(filename.Length + 1, 4) / 4;
				}
				f.WriteInt(dataPos);
				f.WriteInt(dataPos + files[filename].Length);
				dataPos += files[filename].Length % padding == 0 ? files[filename].Length : files[filename].Length + (padding - files[filename].Length % padding);
			}

			f.WriteHex("53464E5400080000");
			if (isString)
			{
				foreach (string filename in files.Keys)
				{
					f.WriteString(filename);
					f.WriteByte(0);
					while (f.Position() % 4 != 0)
						f.WriteByte(0);
				}
			}
			if (padding == -1 || padding < f.Position())
				while ((f.Position() + 0x14) % 0x100 != 0)
					f.WriteByte(0);
			else
				f.WriteBytes(new byte[padding - (f.Position() + 0x14)]);

			sfatStartOffset = f.Position();
			int cur = 0;
			foreach (string filename in files.Keys)
			{
				f.WriteIntAt(f.Position() - sfatStartOffset, 0x14 + (cur * 0x10));
				f.WriteBytes(files[filename]);
				f.WriteIntAt(f.Position() - sfatStartOffset, 0x18 + (cur * 0x10));
				while ((f.Position() + 0x14) % padding != 0)
					f.WriteByte(0);

				cur++;
			}

			return f.GetBytes();
		}

		public byte[] Rebuild()
		{
			FileOutput f = new FileOutput();
			f.byteOrder = byteOrder;

			f.WriteString("SARC");
			f.WriteShort(0x14);
			f.byteOrder = byteOrder;
			f.WriteShort(65279);

			byte[] sfat = RebuildSFATArchive();

			f.WriteInt(sfat.Length + 0x14);
			f.WriteInt(sfatStartOffset + 0x14);
			f.WriteInt(0x1000000);
			f.WriteBytes(sfat);

			return f.GetBytes();
		}
	}
}

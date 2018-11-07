using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO_Translation_Helper
{
	public class YAZ0
	{
		public static byte[] Decompress(byte[] data)
		{
			FileInput f = new FileInput(data);

			f.byteOrder = ByteOrder.BigEndian;
			f.Seek(4);
			int uncompressedSize = f.ReadInt();
			byte[] flags = f.Read(8);

			byte[] src = f.Read(data.Length - 0x10);
			byte[] dst = new byte[uncompressedSize];

			int srcPlace = 0, dstPlace = 0; // Current read/write positions

			uint validBitCount = 0; // Number of valid bits left in "code" byte
			byte currCodeByte = 0;
			while (dstPlace < uncompressedSize)
			{
				// Read new "code" byte if the current one is used up
				if (validBitCount == 0)
				{
					currCodeByte = src[srcPlace];
					++srcPlace;
					validBitCount = 8;
				}

				if ((currCodeByte & 0x80) != 0)
				{
					// Straight copy
					dst[dstPlace] = src[srcPlace];
					dstPlace++;
					srcPlace++;
				}
				else
				{
					// RLE part
					byte byte1 = src[srcPlace];
					byte byte2 = src[srcPlace + 1];
					srcPlace += 2;

					uint dist = (uint)(((byte1 & 0xF) << 8) | byte2);
					uint copySource = (uint)(dstPlace - (dist + 1));

					uint numBytes = (uint)(byte1 >> 4);
					if (numBytes == 0)
					{
						numBytes = (uint)(src[srcPlace] + 0x12);
						srcPlace++;
					}
					else
						numBytes += 2;

					// Copy run
					for (int i = 0; i < numBytes; ++i)
					{
						dst[dstPlace] = dst[copySource];
						copySource++;
						dstPlace++;
					}
				}

				// Use next bit from "code" byte
				currCodeByte <<= 1;
				validBitCount -= 1;
			}

			return dst;
		}

		public static byte[] Compress(byte[] data)
		{
			FileOutput f = new FileOutput();
			f.byteOrder = ByteOrder.LittleEndian;
			f.WriteString("Yaz0");
			byte w1 = (byte)(data.Length & 0xFF);
			byte w2 = (byte)((data.Length >> 8) & 0xFF);
			byte w3 = (byte)((data.Length >> 16) & 0xFF);
			byte w4 = (byte)(data.Length >> 24);
			f.WriteInt((w1 << 24) | (w2 << 16) | (w3 << 8) | w4);
			f.WriteHex("0000000000000000");
			int pos = 0, posInChunk = 0;
			while (pos < data.Length)
			{
				posInChunk = 0;
				f.WriteByte(0xFF);
				while (pos + posInChunk < data.Length && posInChunk < 8)
				{
					f.WriteByte(data[pos + posInChunk]);
					posInChunk++;
				}
				pos += posInChunk;
			}

			return f.GetBytes();
		}
	}
}

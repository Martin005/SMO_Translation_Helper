using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO_Translation_Helper
{
	public class FileOutput
	{
		List<byte> data = new List<byte>();

		public ByteOrder byteOrder;

		public byte[] GetBytes()
		{
			return data.ToArray();
		}

		public void WriteString(string s)
		{
			char[] c = s.ToCharArray();
			for (int i = 0; i < c.Length; i++)
				data.Add((byte)c[i]);
		}

		private static char[] HexToCharArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
							 .Where(x => x % 2 == 0)
							 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
							 .Select(x => Convert.ToChar(x))
							 .ToArray();
		}

		public void WriteHex(string s)
		{
			char[] c = HexToCharArray(s);
			for (int i = 0; i < c.Length; i++)
				data.Add((byte)c[i]);
		}

		public void WriteInt(int i)
		{
			if (byteOrder == ByteOrder.LittleEndian)
			{
				data.Add((byte)((i) & 0xFF));
				data.Add((byte)((i >> 8) & 0xFF));
				data.Add((byte)((i >> 16) & 0xFF));
				data.Add((byte)((i >> 24) & 0xFF));
			}
			else
			{
				data.Add((byte)((i >> 24) & 0xFF));
				data.Add((byte)((i >> 16) & 0xFF));
				data.Add((byte)((i >> 8) & 0xFF));
				data.Add((byte)((i) & 0xFF));
			}
		}
		
		public void WriteIntAt(int i, int p)
		{
			if (byteOrder == ByteOrder.LittleEndian)
			{
				data[p++] = (byte)((i) & 0xFF);
				data[p++] = (byte)((i >> 8) & 0xFF);
				data[p++] = (byte)((i >> 16) & 0xFF);
				data[p++] = (byte)((i >> 24) & 0xFF);
			}
			else
			{
				data[p++] = (byte)((i >> 24) & 0xFF);
				data[p++] = (byte)((i >> 16) & 0xFF);
				data[p++] = (byte)((i >> 8) & 0xFF);
				data[p++] = (byte)((i) & 0xFF);
			}
		}
		
		public void WriteShort(int i)
		{
			if (byteOrder == ByteOrder.LittleEndian)
			{
				data.Add((byte)((i) & 0xFF));
				data.Add((byte)((i >> 8) & 0xFF));
			}
			else
			{
				data.Add((byte)((i >> 8) & 0xFF));
				data.Add((byte)((i) & 0xFF));
			}
		}

		public void WriteByte(int i)
		{
			data.Add((byte)((i) & 0xFF));
		}

		public void WriteBytes(byte[] bytes)
		{
			foreach (byte b in bytes)
				WriteByte(b);
		}

		public int Position()
		{
			return data.Count;
		}

	}
}

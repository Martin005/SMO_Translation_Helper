using System;
using System.IO;
using System.Collections.Generic;

namespace SMO_Translation_Helper
{
	public class FileInput
	{
		private byte[] b;
		private int p = 0;
		public ByteOrder byteOrder;

		public FileInput(byte[] b)
		{
			this.b = b;
		}

		public byte[] Read(int length)
		{
			if (length + p > b.Length)
				throw new IndexOutOfRangeException();

			var data = new byte[length];
			for (int i = 0; i < length; i++, p++)
			{
				data[i] = b[p];
			}
			return data;
		}

		public int ReadInt()
		{
			if (byteOrder == ByteOrder.LittleEndian)
			{
				return (b[p++] & 0xFF) | ((b[p++] & 0xFF) << 8) | ((b[p++] & 0xFF) << 16) | ((b[p++] & 0xFF) << 24);
			}
			else
				return ((b[p++] & 0xFF) << 24) | ((b[p++] & 0xFF) << 16) | ((b[p++] & 0xFF) << 8) | (b[p++] & 0xFF);
		}

		public int ReadShort()
		{
			if (byteOrder == ByteOrder.LittleEndian)
			{
				return (b[p++] & 0xFF) | ((b[p++] & 0xFF) << 8);
			}
			else
				return ((b[p++] & 0xFF) << 8) | (b[p++] & 0xFF);
		}

		public void Skip(int i)
		{
			p += i;
		}

		public void Seek(int i)
		{
			p = i;
		}

		public int Position()
		{
			return p;
		}

		public string ReadString()
		{
			string s = "";
			while (b[p] != 0x00)
			{
				s += (char)b[p];
				p++;
			}
			return s;
		}

		public string ReadString(int p, int size)
		{
			if (size == -1)
			{
				string str = "";
				while (p < b.Length)
				{
					if ((b[p] & 0xFF) != 0x00)
						str += (char)(b[p] & 0xFF);
					else
						break;
					p++;
				}
				return str;
			}

			string str2 = "";
			for (int i = p; i < p + size; i++)
			{
				if ((b[i] & 0xFF) != 0x00)
					str2 += (char)(b[i] & 0xFF);
			}
			return str2;
		}
	}
}


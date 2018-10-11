using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SMO_Translation_Helper
{
	public enum ByteOrder
	{
		LittleEndian = 0,
		BigEndian = 1
	}

	class BinaryReaderX : BinaryReader
	{
		public ByteOrder ByteOrder { get; set; }

		public BinaryReaderX(Stream input, ByteOrder byteOrder = ByteOrder.LittleEndian)
			: base(input)
		{
			ByteOrder = byteOrder;
		}

		public override ushort ReadUInt16()
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				return base.ReadUInt16();
			else
				return BitConverter.ToUInt16(base.ReadBytes(2).Reverse().ToArray(), 0);
		}

		public override uint ReadUInt32()
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				return base.ReadUInt32();
			else
				return BitConverter.ToUInt32(base.ReadBytes(4).Reverse().ToArray(), 0);
		}

		public string ReadString(int length)
		{
			return Encoding.ASCII.GetString(ReadBytes(length)).TrimEnd('\0');
		}

		public string PeekString(int length = 4)
		{
			List<byte> bytes = new List<byte>();
			long startOffset = BaseStream.Position;

			for (int i = 0; i < length; i++)
				bytes.Add(ReadByte());

			BaseStream.Seek(startOffset, SeekOrigin.Begin);

			return Encoding.ASCII.GetString(bytes.ToArray());
		}
	}

	class BinaryWriterX : BinaryWriter
	{
		public ByteOrder ByteOrder { get; set; }

		public BinaryWriterX(Stream input, ByteOrder byteOrder = ByteOrder.LittleEndian)
			: base(input)
		{
			ByteOrder = byteOrder;
		}

		public override void Write(ushort value)
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				base.Write(value);
			else
				base.Write(BitConverter.GetBytes(value).Reverse().ToArray());
		}

		public override void Write(uint value)
		{
			if (ByteOrder == ByteOrder.LittleEndian)
				base.Write(value);
			else
				base.Write(BitConverter.GetBytes(value).Reverse().ToArray());
		}

		public void WriteASCII(string value)
		{
			base.Write(Encoding.ASCII.GetBytes(value));
		}
	}
}
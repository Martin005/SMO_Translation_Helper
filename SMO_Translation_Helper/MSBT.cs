using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace SMO_Translation_Helper
{
	public enum EncodingByte : byte
	{
		UTF8 = 0x00,
		Unicode = 0x01
	}

	public class Header
	{
		public string Identifier; // MsgStdBn
		public byte[] ByteOrderMark;
		public UInt16 Unknown1; // Always 0x0000
		public EncodingByte EncodingByte;
		public byte Unknown2; // Always 0x03
		public UInt16 NumberOfSections;
		public UInt16 Unknown3; // Always 0x0000
		public UInt32 FileSize;
		public byte[] Unknown4; // Always 0x0000 0000 0000 0000 0000

		public UInt32 FileSizeOffset;
	}

	public class Section
	{
		public string Identifier;
		public UInt32 SectionSize; // Begins after Unknown1
		public byte[] Padding1; // Always 0x0000 0000
	}

	public interface IEntry
	{
		string ToString();
		string ToString(Encoding encoding);
		byte[] Value { get; set; }
		UInt32 Index { get; set; }
	}

	public class LBL1 : Section
	{
		public UInt32 NumberOfGroups;

		public List<Group> Groups;
		public List<IEntry> Labels;
	}

	public class Group
	{
		public UInt32 NumberOfLabels;
		public UInt32 Offset;
	}

	public class Label : IEntry
	{
		private UInt32 _index;

		public UInt32 Length;
		public string Name;
		public UInt32 Checksum;
		public IEntry String;

		public byte[] Value
		{
			get
			{
				return String.Value;
			}
			set
			{
				String.Value = value;
			}
		}

		public UInt32 Index
		{
			get
			{
				return _index;
			}
			set
			{
				_index = value;
			}
		}

		public override string ToString()
		{
			return (Length > 0 ? Name : (_index + 1).ToString());
		}

		public string ToString(Encoding encoding)
		{
			return (Length > 0 ? Name : (_index + 1).ToString());
		}
	}

	public class TXT2 : Section
	{
		public UInt32 NumberOfStrings;

		public List<IEntry> Strings;
		public List<IEntry> OriginalStrings;
	}

	public class String : IEntry
	{
		private byte[] _text;
		private UInt32 _index;

		public byte[] Value
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
			}
		}

		public UInt32 Index
		{
			get
			{
				return _index;
			}
			set
			{
				_index = value;
			}
		}

		public override string ToString()
		{
			return (_index + 1).ToString();
		}

		public string ToString(Encoding encoding)
		{
			return encoding.GetString(_text);
		}
	}

	public class InvalidMSBTException : Exception
	{
		public InvalidMSBTException(string message) : base(message) { }
	}

	public class MSBT
	{
		public Header Header = new Header();
		public LBL1 LBL1 = new LBL1();
		public TXT2 TXT2 = new TXT2();
		public Encoding FileEncoding = Encoding.Unicode;
		public List<string> SectionOrder = new List<string>();
		public bool HasLabels = false;

		private byte paddingChar = 0xAB;

		public static UInt32 LabelMaxLength = 64;
		public static string LabelFilter = @"^[a-zA-Z0-9_]+$";

		public MSBT(string filename)
		{
			FileInfo file = new FileInfo(filename);
			if (file.Exists && filename.Length > 0)
			{
				FileStream fs = File.Open(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
				BinaryReaderX br = new BinaryReaderX(fs);

				// Initialize Members
				LBL1.Groups = new List<Group>();
				LBL1.Labels = new List<IEntry>();
				TXT2.Strings = new List<IEntry>();
				TXT2.OriginalStrings = new List<IEntry>();

				// Header
				Header.Identifier = br.ReadString(8);
				if (Header.Identifier != "MsgStdBn")
					throw new InvalidMSBTException("The file provided is not a valid MSBT file.");

				// Byte Order
				Header.ByteOrderMark = br.ReadBytes(2);
				br.ByteOrder = Header.ByteOrderMark[0] > Header.ByteOrderMark[1] ? ByteOrder.LittleEndian : ByteOrder.BigEndian;

				Header.Unknown1 = br.ReadUInt16();

				// Encoding
				Header.EncodingByte = (EncodingByte)br.ReadByte();
				FileEncoding = (Header.EncodingByte == EncodingByte.UTF8 ? Encoding.UTF8 : Encoding.Unicode);

				Header.Unknown2 = br.ReadByte();
				Header.NumberOfSections = br.ReadUInt16();
				Header.Unknown3 = br.ReadUInt16();
				Header.FileSizeOffset = (UInt32)br.BaseStream.Position; // Record offset for future use
				Header.FileSize = br.ReadUInt32();
				Header.Unknown4 = br.ReadBytes(10);

				if (Header.FileSize != br.BaseStream.Length)
					throw new InvalidMSBTException("The file provided is not a valid MSBT file.");

				SectionOrder.Clear();
				for (int i = 0; i < Header.NumberOfSections; i++)
				{
					switch (br.PeekString())
					{
						case "LBL1":
							ReadLBL1(br);
							SectionOrder.Add("LBL1");
							break;
						case "TXT2":
							ReadTXT2(br);
							SectionOrder.Add("TXT2");
							break;
					}
				}

				br.Close();
			}
		}

		public MSBT(byte[] rawBytes)
		{
			if (rawBytes.Length > 0)
			{
				Stream stream = new MemoryStream(rawBytes);
				BinaryReaderX br = new BinaryReaderX(stream);

				// Initialize Members
				LBL1.Groups = new List<Group>();
				LBL1.Labels = new List<IEntry>();
				TXT2.Strings = new List<IEntry>();
				TXT2.OriginalStrings = new List<IEntry>();

				// Header
				Header.Identifier = br.ReadString(8);
				if (Header.Identifier != "MsgStdBn")
					throw new InvalidMSBTException("The file provided is not a valid MSBT file.");

				// Byte Order
				Header.ByteOrderMark = br.ReadBytes(2);
				br.ByteOrder = Header.ByteOrderMark[0] > Header.ByteOrderMark[1] ? ByteOrder.LittleEndian : ByteOrder.BigEndian;

				Header.Unknown1 = br.ReadUInt16();

				// Encoding
				Header.EncodingByte = (EncodingByte)br.ReadByte();
				FileEncoding = (Header.EncodingByte == EncodingByte.UTF8 ? Encoding.UTF8 : Encoding.Unicode);

				Header.Unknown2 = br.ReadByte();
				Header.NumberOfSections = br.ReadUInt16();
				Header.Unknown3 = br.ReadUInt16();
				Header.FileSizeOffset = (UInt32)br.BaseStream.Position; // Record offset for future use
				Header.FileSize = br.ReadUInt32();
				Header.Unknown4 = br.ReadBytes(10);

				if (Header.FileSize != br.BaseStream.Length)
					throw new InvalidMSBTException("The file provided is not a valid MSBT file.");

				SectionOrder.Clear();
				for (int i = 0; i < Header.NumberOfSections; i++)
				{
					switch (br.PeekString())
					{
						case "LBL1":
							ReadLBL1(br);
							SectionOrder.Add("LBL1");
							break;
						case "TXT2":
							ReadTXT2(br);
							SectionOrder.Add("TXT2");
							break;
					}
				}

				br.Close();
			}
		}

		public uint LabelChecksum(string label)
		{
			return label.Aggregate(0u, (hash, c) => hash * 0x492 + c) % LBL1.NumberOfGroups;
		}

		private void ReadLBL1(BinaryReaderX br)
		{
			LBL1.Identifier = br.ReadString(4);
			LBL1.SectionSize = br.ReadUInt32();
			LBL1.Padding1 = br.ReadBytes(8);
			long startOfLabels = br.BaseStream.Position;
			LBL1.NumberOfGroups = br.ReadUInt32();

			for (int i = 0; i < LBL1.NumberOfGroups; i++)
			{
				Group grp = new Group();
				grp.NumberOfLabels = br.ReadUInt32();
				grp.Offset = br.ReadUInt32();
				LBL1.Groups.Add(grp);
			}

			foreach (Group grp in LBL1.Groups)
			{
				br.BaseStream.Seek(startOfLabels + grp.Offset, SeekOrigin.Begin);

				for (int i = 0; i < grp.NumberOfLabels; i++)
				{
					Label lbl = new Label();
					lbl.Length = Convert.ToUInt32(br.ReadByte());
					lbl.Name = br.ReadString((int)lbl.Length);
					lbl.Index = br.ReadUInt32();
					lbl.Checksum = (uint)LBL1.Groups.IndexOf(grp);
					LBL1.Labels.Add(lbl);
				}
			}

			// Old rename correction
			foreach (Label lbl in LBL1.Labels)
			{
				uint previousChecksum = lbl.Checksum;
				lbl.Checksum = LabelChecksum(lbl.Name);

				if (previousChecksum != lbl.Checksum)
				{
					LBL1.Groups[(int)previousChecksum].NumberOfLabels -= 1;
					LBL1.Groups[(int)lbl.Checksum].NumberOfLabels += 1;
				}
			}

			if (LBL1.Labels.Count > 0)
				HasLabels = true;

			PaddingSeek(br);
		}

		private void ReadTXT2(BinaryReaderX br)
		{
			TXT2.Identifier = br.ReadString(4);
			TXT2.SectionSize = br.ReadUInt32();
			TXT2.Padding1 = br.ReadBytes(8);
			long startOfStrings = br.BaseStream.Position;
			TXT2.NumberOfStrings = br.ReadUInt32();

			List<UInt32> offsets = new List<UInt32>();
			for (int i = 0; i < TXT2.NumberOfStrings; i++)
				offsets.Add(br.ReadUInt32());
			for (int i = 0; i < TXT2.NumberOfStrings; i++)
			{
				String str = new String();
				UInt32 nextOffset = (i + 1 < offsets.Count) ? ((UInt32)startOfStrings + offsets[i + 1]) : ((UInt32)startOfStrings + TXT2.SectionSize);

				br.BaseStream.Seek(startOfStrings + offsets[i], SeekOrigin.Begin);

				List<byte> result = new List<byte>();
				while (br.BaseStream.Position < nextOffset && br.BaseStream.Position < Header.FileSize)
				{
					if (Header.EncodingByte == EncodingByte.UTF8)
						result.Add(br.ReadByte());
					else
					{
						byte[] unichar = br.ReadBytes(2);

						if (br.ByteOrder == ByteOrder.BigEndian)
							Array.Reverse(unichar);

						result.AddRange(unichar);
					}
				}
				str.Value = result.ToArray();
				str.Index = (uint)i;

				TXT2.OriginalStrings.Add(str);

				// Duplicate entries for editing
				String estr = new String();
				estr.Value = str.Value;
				estr.Index = str.Index;
				TXT2.Strings.Add(estr);
			}

			// Tie in LBL1 labels
			foreach (Label lbl in LBL1.Labels)
				lbl.String = TXT2.Strings[(int)lbl.Index];

			PaddingSeek(br);
		}

		private void PaddingSeek(BinaryReaderX br)
		{
			long remainder = br.BaseStream.Position % 16;
			if (remainder > 0)
			{
				paddingChar = br.ReadByte();
				br.BaseStream.Seek(-1, SeekOrigin.Current);
				br.BaseStream.Seek(16 - remainder, SeekOrigin.Current);
			}
		}
		
		public bool SaveFile(string fullPath)
		{
			bool result = false;

			try
			{
				FileStream fs = File.Create(fullPath);
				BinaryWriterX bw = new BinaryWriterX(fs);

				// Byte Order
				bw.ByteOrder = Header.ByteOrderMark[0] > Header.ByteOrderMark[1] ? ByteOrder.LittleEndian : ByteOrder.BigEndian;

				// Header
				bw.WriteASCII(Header.Identifier);
				bw.Write(Header.ByteOrderMark);
				bw.Write(Header.Unknown1);
				bw.Write((byte)Header.EncodingByte);
				bw.Write(Header.Unknown2);
				bw.Write(Header.NumberOfSections);
				bw.Write(Header.Unknown3);
				bw.Write(Header.FileSize);
				bw.Write(Header.Unknown4);

				foreach (string section in SectionOrder)
				{
					if (section == "LBL1")
						WriteLBL1(bw);
					else if (section == "TXT2")
						WriteTXT2(bw);
				}

				// Update FileSize
				long fileSize = bw.BaseStream.Position;
				bw.BaseStream.Seek(Header.FileSizeOffset, SeekOrigin.Begin);
				bw.Write((UInt32)fileSize);

				bw.Close();
			}
			catch (Exception)
			{ }

			return result;
		}

		public byte[] ExportFileBytes()
		{
			MemoryStream stream = new MemoryStream();
			try
			{
				BinaryWriterX bw = new BinaryWriterX(stream);

				// Byte Order
				bw.ByteOrder = Header.ByteOrderMark[0] > Header.ByteOrderMark[1] ? ByteOrder.LittleEndian : ByteOrder.BigEndian;

				// Header
				bw.WriteASCII(Header.Identifier);
				bw.Write(Header.ByteOrderMark);
				bw.Write(Header.Unknown1);
				bw.Write((byte)Header.EncodingByte);
				bw.Write(Header.Unknown2);
				bw.Write(Header.NumberOfSections);
				bw.Write(Header.Unknown3);
				bw.Write(Header.FileSize);
				bw.Write(Header.Unknown4);

				foreach (string section in SectionOrder)
				{
					if (section == "LBL1")
						WriteLBL1(bw);
					else if (section == "TXT2")
						WriteTXT2(bw);
				}

				// Update FileSize
				long fileSize = bw.BaseStream.Position;
				bw.BaseStream.Seek(Header.FileSizeOffset, SeekOrigin.Begin);
				bw.Write((UInt32)fileSize);

				bw.Close();
			}
			catch (Exception)
			{ }

			return stream.ToArray();
		}

		private bool WriteLBL1(BinaryWriterX bw)
		{
			bool result = false;

			try
			{
				// Calculate Section Size
				UInt32 newSize = sizeof(UInt32);

				foreach (Group grp in LBL1.Groups)
					newSize += (UInt32)(sizeof(UInt32) + sizeof(UInt32));

				foreach (Label lbl in LBL1.Labels)
					newSize += (UInt32)(sizeof(byte) + lbl.Name.Length + sizeof(UInt32));

				// Calculate Group Offsets
				UInt32 offsetsLength = LBL1.NumberOfGroups * sizeof(UInt32) * 2 + sizeof(UInt32);
				UInt32 runningTotal = 0;
				for (int i = 0; i < LBL1.Groups.Count; i++)
				{
					LBL1.Groups[i].Offset = offsetsLength + runningTotal;
					foreach (Label lbl in LBL1.Labels)
						if (lbl.Checksum == i)
							runningTotal += (UInt32)(sizeof(byte) + lbl.Name.Length + sizeof(UInt32));
				}

				bw.WriteASCII(LBL1.Identifier);
				bw.Write(newSize);
				bw.Write(LBL1.Padding1);
				bw.Write(LBL1.NumberOfGroups);

				foreach (Group grp in LBL1.Groups)
				{
					bw.Write(grp.NumberOfLabels);
					bw.Write(grp.Offset);
				}

				foreach (Group grp in LBL1.Groups)
				{
					foreach (Label lbl in LBL1.Labels)
					{
						if (lbl.Checksum == LBL1.Groups.IndexOf(grp))
						{
							bw.Write(Convert.ToByte(lbl.Length));
							bw.WriteASCII(lbl.Name);
							bw.Write(lbl.Index);
						}
					}
				}

				PaddingWrite(bw);

				result = true;
			}
			catch (Exception)
			{
				result = false;
			}

			return result;
		}

		private bool WriteTXT2(BinaryWriterX bw)
		{
			bool result = false;

			try
			{
				// Calculate Section Size
				UInt32 newSize = (UInt32)(TXT2.NumberOfStrings * sizeof(UInt32) + sizeof(UInt32));

				for (int i = 0; i < TXT2.NumberOfStrings; i++)
					newSize += (UInt32)((String)TXT2.Strings[i]).Value.Length;

				bw.WriteASCII(TXT2.Identifier);
				bw.Write(newSize);
				bw.Write(TXT2.Padding1);
				long startOfStrings = bw.BaseStream.Position;
				bw.Write(TXT2.NumberOfStrings);

				List<UInt32> offsets = new List<UInt32>();
				UInt32 offsetsLength = TXT2.NumberOfStrings * sizeof(UInt32) + sizeof(UInt32);
				UInt32 runningTotal = 0;
				for (int i = 0; i < TXT2.NumberOfStrings; i++)
				{
					offsets.Add(offsetsLength + runningTotal);
					runningTotal += (UInt32)((String)TXT2.Strings[i]).Value.Length;
				}
				for (int i = 0; i < TXT2.NumberOfStrings; i++)
					bw.Write(offsets[i]);
				for (int i = 0; i < TXT2.NumberOfStrings; i++)
				{
					for (int j = 0; j < TXT2.Strings.Count; j++)
						TXT2.OriginalStrings[i] = TXT2.Strings[i];

					if (Header.EncodingByte == EncodingByte.UTF8)
						bw.Write(((String)TXT2.Strings[i]).Value);
					else
					{
						if (Header.ByteOrderMark[0] == 0xFF)
							bw.Write(((String)TXT2.Strings[i]).Value);
						else
							for (int j = 0; j < ((String)TXT2.Strings[i]).Value.Length; j += 2)
							{
								bw.Write(((String)TXT2.Strings[i]).Value[j + 1]);
								bw.Write(((String)TXT2.Strings[i]).Value[j]);
							}
					}
				}

				PaddingWrite(bw);

				result = true;
			}
			catch (Exception)
			{
				result = false;
			}

			return result;
		}

		private void PaddingWrite(BinaryWriterX bw)
		{
			long remainder = bw.BaseStream.Position % 16;
			if (remainder > 0)
				for (int i = 0; i < 16 - remainder; i++)
					bw.Write(paddingChar);
		}

		public string ExportXLIFF(string filePath, bool overwrite = true)
		{
			string result = "Successfully exported to XLIFF.";

			string fileName = Path.GetFileNameWithoutExtension(filePath);

			try
			{
				if (!File.Exists(filePath) || (File.Exists(filePath) && overwrite))
				{
					if (HasLabels)
					{
						XmlDocument xmlDocument = new XmlDocument();

						XmlWriterSettings xmlSettings = new XmlWriterSettings
						{
							Encoding = FileEncoding,
							Indent = true,
							IndentChars = "\t",
							CheckCharacters = false,
							OmitXmlDeclaration = true
						};

						string xliffNameSpace = "urn:oasis:names:tc:xliff:document:2.0";
						XmlElement xliff = xmlDocument.CreateElement("xliff", xliffNameSpace);
						xliff.SetAttribute("xmlns", xliffNameSpace);
						xliff.SetAttribute("version", "2.0");
						xliff.SetAttribute("srcLang", "en-US");
						xmlDocument.AppendChild(xliff);

						XmlElement xliffFile = xmlDocument.CreateElement("file", xliffNameSpace);
						xliffFile.SetAttribute("id", fileName);
						xliff.AppendChild(xliffFile);
						
						foreach (Label lbl in LBL1.Labels)
						{
							XmlElement xliffUnit = xmlDocument.CreateElement("unit", xliffNameSpace);
							xliffUnit.SetAttribute("id", lbl.Name);
							xliffFile.AppendChild(xliffUnit);

							XmlElement xliffSegment = xmlDocument.CreateElement("segment", xliffNameSpace);
							xliffUnit.AppendChild(xliffSegment);

							XmlElement xliffSource = xmlDocument.CreateElement("source", xliffNameSpace);

							xliffSource.InnerText = QA.CleanBeforeExport(lbl.String.Value);
							xliffSegment.AppendChild(xliffSource);
						}
						
						StreamWriter stream = new StreamWriter(filePath, false, FileEncoding);
						xmlDocument.Save(XmlWriter.Create(stream, xmlSettings));
						stream.Close();
					}
					else
					{
						result = "XLIFF export does not currently support files without an LBL1 section.";
					}
				}
				else
				{
					result = fileName + " already exists and overwrite was set to false.";
				}
			}
			catch (Exception ex)
			{
				result = "Unknown Error - " + ex.Message;
			}

			return result;
		}

		public string ImportXLIFF(string filename, bool addNew = false)
		{
			string result = "Successfully imported from XMSBT.";

			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(filename);

				XmlNamespaceManager ns = new XmlNamespaceManager(xmlDocument.NameTable);
				ns.AddNamespace("ns", "urn:oasis:names:tc:xliff:document:2.0");

				XmlNode xmlRoot = xmlDocument.SelectSingleNode("//ns:file", ns);

				Dictionary<string, Label> labels = new Dictionary<string, Label>();
				foreach (Label lbl in LBL1.Labels)
					labels.Add(lbl.Name, lbl);

				foreach (XmlNode unit in xmlRoot.SelectNodes("ns:unit", ns))
				{
					string label = unit.Attributes["id"].Value;

					string targetText;
					if (unit.SelectSingleNode("//ns:target", ns) == null)
					{
						targetText = unit.SelectSingleNode("//ns:source", ns).InnerText;
					}
					else
					{
						targetText = unit.SelectSingleNode("//ns:target", ns).InnerText;
					}

					byte[] str = QA.CleanBeforeImport(targetText);

					if (labels.ContainsKey(label))
						labels[label].String.Value = str;
				}
			}
			catch (Exception ex)
			{
				result = "Unknown Error - " + ex.Message;
			}

			return result;
		}
	}
}
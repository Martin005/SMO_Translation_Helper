using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace SMO_Translation_Helper
{
	public partial class MainForm : MetroForm
	{
		public int globalPadding = -1;

		public MainForm()
		{
			InitializeComponent();
		}

		private string extractingSZSFilename = null;
		private DirectoryInfo extractingDirectory = null;

		private string packingSZSFilename = null;
		private DirectoryInfo packingDirectory = null;

		private List<MsbtFile> msbtFiles = new List<MsbtFile>();

		private void SanitizeFolderPath(MetroTextBox textBox, ref DirectoryInfo directory)
		{
			directory = null;

			if (textBox.Text.Substring(textBox.Text.Length - 1) == @"\")
			{
				directory = new DirectoryInfo(textBox.Text);
			}
			else
			{
				textBox.Text += @"\";
				directory = new DirectoryInfo(textBox.Text);
			}
		}

		private void JumpToTheEndOfTextBox(MetroTextBox textBox)
		{
			textBox.Focus();
			textBox.Select(textBox.Text.Length, 0);
		}

		private void OpenFile(string file)
		{
			msbtFiles.Clear();
			if (Path.GetExtension(file).Equals(".szs"))
			{
				byte[] szs = YAZ0.Decompress(File.ReadAllBytes(file));
				if (new FileInput(szs).ReadString(0, 4).Equals("SARC"))
				{
					SARC sarc = new SARC();
					sarc.Read(szs);
					globalPadding = sarc.padding;
					foreach (string name in sarc.files.Keys)
					{
						msbtFiles.Add(new MsbtFile() { Name = name, Content = sarc.files[name] });
					}
				}
			}
		}

		private void SelectExtractingSZSButton_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckFileExists = true;
				ofd.Title = "Select SZS file to extract";
				ofd.Filter = "SZS compressed file|*.szs";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					extractingSZSFilename = ofd.FileName;
					extractingSZSTextBox.Text = extractingSZSFilename;
					JumpToTheEndOfTextBox(extractingSZSTextBox);
					extractingPanel.Focus();
				}
			}
		}

		private void SelectExtractingFolderButton_Click(object sender, EventArgs e)
		{
			using (var folderSelectDialog = new CommonOpenFileDialog())
			{
				folderSelectDialog.RestoreDirectory = false;
				folderSelectDialog.IsFolderPicker = true;
				folderSelectDialog.Title = "Select folder for extracting MSBT and XLIFF files";

				if (folderSelectDialog.ShowDialog() == CommonFileDialogResult.Ok)
				{
					extractingDirectory = new DirectoryInfo(folderSelectDialog.FileName);
					extractingFolderTextBox.Text = extractingDirectory.FullName;
					SanitizeFolderPath(extractingFolderTextBox, ref extractingDirectory);
					JumpToTheEndOfTextBox(extractingFolderTextBox);
					extractingPanel.Focus();
				}
			}
		}

		private void ExtractSZSButton_Click(object sender, EventArgs e)
		{
			string result = "Successfully extracted MSBTs and XLIFFs from SZS file.";

			SanitizeFolderPath(extractingFolderTextBox, ref extractingDirectory);
			OpenFile(extractingSZSFilename);

			try
			{
				foreach (MsbtFile file in msbtFiles)
				{
					if (!string.IsNullOrWhiteSpace(Path.GetDirectoryName(file.Name)))
						Directory.CreateDirectory(Path.GetDirectoryName(file.Name));

					MSBT msbt = new MSBT(file.Content);

					if (!extractingDirectory.Exists)
					{
						Directory.CreateDirectory(extractingDirectory.FullName);
					}

					string msbtFilename = Path.GetFileNameWithoutExtension(file.Name);
					msbt.SaveFile(Path.Combine(extractingDirectory.FullName, Path.GetFileName(file.Name)));
					msbt.ExportXLIFF(Path.Combine(extractingDirectory.FullName, msbtFilename + ".xliff"));
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}

			MessageBox.Show(result, "Extracting MSBTs and XLIFFs", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void SelectPackingFolderButton_Click(object sender, EventArgs e)
		{
			using (var folderSelectDialog = new CommonOpenFileDialog())
			{
				folderSelectDialog.RestoreDirectory = false;
				folderSelectDialog.IsFolderPicker = true;
				folderSelectDialog.Title = "Select folder with MSBT and XLIFF files";

				if (folderSelectDialog.ShowDialog() == CommonFileDialogResult.Ok)
				{
					packingDirectory = new DirectoryInfo(folderSelectDialog.FileName);
					packingFolderTextBox.Text = packingDirectory.FullName;
					SanitizeFolderPath(packingFolderTextBox, ref packingDirectory);
					JumpToTheEndOfTextBox(packingFolderTextBox);
					packingPanel.Focus();
				}
			}
		}

		private void SelectPackingSZSButton_Click(object sender, EventArgs e)
		{
			using (var sfd = new SaveFileDialog())
			{
				sfd.Title = "Select SZS file to pack";
				sfd.Filter = "SZS compressed file| *.szs";

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					packingSZSFilename = sfd.FileName;
					packingSZSTextBox.Text = packingSZSFilename;
					JumpToTheEndOfTextBox(packingSZSTextBox);
					packingPanel.Focus();
				}
			}
		}

		private void PackXLIFFSButton_Click(object sender, EventArgs e)
		{
			string result = "Successfully packed XLIFFs into SZS file.";

			SanitizeFolderPath(packingFolderTextBox, ref packingDirectory);

			try
			{
				FileInfo[] msbtFiles = packingDirectory.GetFiles("*.msbt");
				FileInfo[] xliffFiles = packingDirectory.GetFiles("*.xliff");

				Dictionary<string, FileInfo> matches = new Dictionary<string, FileInfo>();
				Dictionary<string, FileInfo> nonMatches = new Dictionary<string, FileInfo>();

				foreach (FileInfo msbtFile in msbtFiles)
				{
					string msbtName = Path.GetFileNameWithoutExtension(msbtFile.FullName);

					foreach (FileInfo xliffFile in xliffFiles)
					{
						string xliffName = Path.GetFileNameWithoutExtension(xliffFile.FullName);

						if (msbtName == xliffName)
						{
							matches.Add(msbtName, msbtFile);
							break;
						}
						else
						{
							if (!matches.ContainsKey(xliffName) && !nonMatches.ContainsKey(msbtName))
							{
								nonMatches.Add(msbtName, msbtFile);
							}
						}

					}
				}
				
				SARC sarc = new SARC
				{
					padding = globalPadding,
					byteOrder = ByteOrder.LittleEndian
				};

				foreach (string file in matches.Keys)
				{
					try
					{
						MSBT msbt = new MSBT(matches[file].FullName);
						string filePath = Path.Combine(Path.GetDirectoryName(matches[file].FullName), Path.GetFileNameWithoutExtension(matches[file].FullName) + ".xliff");
						msbt.ImportXLIFF(filePath);
						sarc.files.Add(Path.GetFileName(matches[file].FullName), msbt.ExportFileBytes());

					}
					catch (Exception ex)
					{
						result = ex.Message;
					}
				}

				foreach (string file in nonMatches.Keys)
				{
					try
					{
						MSBT msbt = new MSBT(nonMatches[file].FullName);
						sarc.files.Add(Path.GetFileName(nonMatches[file].FullName), msbt.ExportFileBytes());

					}
					catch (Exception ex)
					{
						result = ex.Message;
					}
				}

				File.WriteAllBytes(packingSZSFilename, YAZ0.Compress(sarc.Rebuild()));
				
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}

			MessageBox.Show(result, "Packing XLIFFs", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}

	public class MsbtFile
	{
		public string Name { get; set; }
		public byte[] Content { get; set; }
	}

}

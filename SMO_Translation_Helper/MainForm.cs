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

namespace SMO_Translation_Helper
{
	public partial class MainForm : MetroForm
	{
		public int globalPadding = -1;

		public MainForm()
		{
			InitializeComponent();
		}

		private string filename = null;
		private List<MsbtFile> msbtFiles = new List<MsbtFile>();

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

		private void SelectSZSButton_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckFileExists = true;
				ofd.Filter = "SZS compressed file|*.szs";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					filename = ofd.FileName;
					extractingTextBox.Text = filename;
					extractingTextBox.Focus();
					extractingTextBox.Select(extractingTextBox.Text.Length, 0);
					extractingPanel.Focus();
				}
			}
		}

		private void ExtractSZSButton_Click(object sender, EventArgs e)
		{
			OpenFile(filename);

			foreach (MsbtFile file in msbtFiles)
			{
				if (!string.IsNullOrWhiteSpace(Path.GetDirectoryName(file.Name)))
					Directory.CreateDirectory(Path.GetDirectoryName(file.Name));
				MSBT msbt = new MSBT(file.Content);

				DirectoryInfo directory = new DirectoryInfo(string.Format(@"{0}\{1}\{2}\", Path.GetDirectoryName(filename), "exported", Path.GetFileNameWithoutExtension(filename)));

				if (!directory.Exists)
				{
					Directory.CreateDirectory(directory.FullName);
				}

				string msbtFilename = Path.GetFileNameWithoutExtension(file.Name);
				msbt.SaveFile(directory + Path.GetFileName(file.Name));
				msbt.ExportXLIFF(directory, msbtFilename);
			}

			var w = new Form() { Size = new Size(0, 0) };
			Task.Delay(TimeSpan.FromSeconds(2))
				.ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

			MessageBox.Show(w, "Processing done!");
		}

		private void PackXLIFFSButton_Click(object sender, EventArgs e)
		{
			string result = "";

			using (var folderSelectDialog = new CommonOpenFileDialog())
			{
				folderSelectDialog.RestoreDirectory = false;
				folderSelectDialog.IsFolderPicker = true;
				folderSelectDialog.Title = "Select folder with MSBT and XLIFF files";

				if (folderSelectDialog.ShowDialog() == CommonFileDialogResult.Ok)
				{
					try
					{
						DirectoryInfo directory = new DirectoryInfo(folderSelectDialog.FileName);

						FileInfo[] msbtFiles = directory.GetFiles("*.msbt");
						FileInfo[] xliffFiles = directory.GetFiles("*.xliff");

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

						using (var sfd = new SaveFileDialog())
						{
							sfd.Filter = "SZS compressed file| *.szs";

							if (sfd.ShowDialog() == DialogResult.OK)
							{
								try
								{
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
											string filePath = string.Format("{0}\\{1}.{2}", Path.GetDirectoryName(matches[file].FullName), Path.GetFileNameWithoutExtension(matches[file].FullName), "xliff");
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

									File.WriteAllBytes(sfd.FileName, YAZ0.Compress(sarc.Rebuild()));
								}
								catch (Exception ex)
								{
									result = ex.Message;
								}
							}
							else
								result = "You have not selected a file to save";
						}
					}
					catch (Exception ex)
					{
						result = ex.Message;
					}
					
					if (result.Length == 0)
						result = "Successfully packed XLIFFs into szs file.";

					MessageBox.Show(result, "Packing XLIFFs", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}

	public class MsbtFile
	{
		public string Name { get; set; }
		public byte[] Content { get; set; }
	}

}

namespace SMO_Translation_Helper
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.packingPanel = new MetroFramework.Controls.MetroPanel();
            this.selectPackingSZSButton = new MetroFramework.Controls.MetroButton();
            this.packingLabel = new MetroFramework.Controls.MetroLabel();
            this.packingSZSTextBox = new MetroFramework.Controls.MetroTextBox();
            this.packingFolderTextBox = new MetroFramework.Controls.MetroTextBox();
            this.packXLIFFSButton = new MetroFramework.Controls.MetroButton();
            this.selectPackingFolderButton = new MetroFramework.Controls.MetroButton();
            this.extractingPanel = new MetroFramework.Controls.MetroPanel();
            this.selectExtractingFolderButton = new MetroFramework.Controls.MetroButton();
            this.extractingFolderTextBox = new MetroFramework.Controls.MetroTextBox();
            this.extractingSZSTextBox = new MetroFramework.Controls.MetroTextBox();
            this.extractingLabel = new MetroFramework.Controls.MetroLabel();
            this.extractSZSButton = new MetroFramework.Controls.MetroButton();
            this.selectExtractingSZSButton = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.packingPanel.SuspendLayout();
            this.extractingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Location = new System.Drawing.Point(20, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(452, 551);
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.metroPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(444, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Extract/Pack";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroPanel1);
            this.metroPanel2.Controls.Add(this.packingPanel);
            this.metroPanel2.Controls.Add(this.extractingPanel);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(3, 3);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(438, 503);
            this.metroPanel2.TabIndex = 4;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 245);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(438, 13);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // packingPanel
            // 
            this.packingPanel.Controls.Add(this.selectPackingSZSButton);
            this.packingPanel.Controls.Add(this.packingLabel);
            this.packingPanel.Controls.Add(this.packingSZSTextBox);
            this.packingPanel.Controls.Add(this.packingFolderTextBox);
            this.packingPanel.Controls.Add(this.packXLIFFSButton);
            this.packingPanel.Controls.Add(this.selectPackingFolderButton);
            this.packingPanel.HorizontalScrollbarBarColor = true;
            this.packingPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.packingPanel.HorizontalScrollbarSize = 10;
            this.packingPanel.Location = new System.Drawing.Point(3, 264);
            this.packingPanel.Name = "packingPanel";
            this.packingPanel.Size = new System.Drawing.Size(432, 236);
            this.packingPanel.TabIndex = 4;
            this.packingPanel.VerticalScrollbarBarColor = true;
            this.packingPanel.VerticalScrollbarHighlightOnWheel = false;
            this.packingPanel.VerticalScrollbarSize = 10;
            // 
            // selectPackingSZSButton
            // 
            this.selectPackingSZSButton.Location = new System.Drawing.Point(324, 105);
            this.selectPackingSZSButton.Name = "selectPackingSZSButton";
            this.selectPackingSZSButton.Size = new System.Drawing.Size(105, 23);
            this.selectPackingSZSButton.TabIndex = 5;
            this.selectPackingSZSButton.Text = "Select SZS file";
            this.selectPackingSZSButton.UseSelectable = true;
            this.selectPackingSZSButton.Click += new System.EventHandler(this.SelectPackingSZSButton_Click);
            // 
            // packingLabel
            // 
            this.packingLabel.AutoSize = true;
            this.packingLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.packingLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.packingLabel.Location = new System.Drawing.Point(0, 3);
            this.packingLabel.Name = "packingLabel";
            this.packingLabel.Size = new System.Drawing.Size(72, 25);
            this.packingLabel.TabIndex = 3;
            this.packingLabel.Text = "Packing";
            // 
            // packingSZSTextBox
            // 
            // 
            // 
            // 
            this.packingSZSTextBox.CustomButton.Image = null;
            this.packingSZSTextBox.CustomButton.Location = new System.Drawing.Point(293, 1);
            this.packingSZSTextBox.CustomButton.Name = "";
            this.packingSZSTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.packingSZSTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.packingSZSTextBox.CustomButton.TabIndex = 1;
            this.packingSZSTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.packingSZSTextBox.CustomButton.UseSelectable = true;
            this.packingSZSTextBox.CustomButton.Visible = false;
            this.packingSZSTextBox.Lines = new string[0];
            this.packingSZSTextBox.Location = new System.Drawing.Point(3, 105);
            this.packingSZSTextBox.MaxLength = 32767;
            this.packingSZSTextBox.Name = "packingSZSTextBox";
            this.packingSZSTextBox.PasswordChar = '\0';
            this.packingSZSTextBox.PromptText = "Select SZS file to pack...";
            this.packingSZSTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.packingSZSTextBox.SelectedText = "";
            this.packingSZSTextBox.SelectionLength = 0;
            this.packingSZSTextBox.SelectionStart = 0;
            this.packingSZSTextBox.ShortcutsEnabled = true;
            this.packingSZSTextBox.Size = new System.Drawing.Size(315, 23);
            this.packingSZSTextBox.TabIndex = 4;
            this.packingSZSTextBox.UseSelectable = true;
            this.packingSZSTextBox.WaterMark = "Select SZS file to pack...";
            this.packingSZSTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.packingSZSTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // packingFolderTextBox
            // 
            // 
            // 
            // 
            this.packingFolderTextBox.CustomButton.Image = null;
            this.packingFolderTextBox.CustomButton.Location = new System.Drawing.Point(293, 1);
            this.packingFolderTextBox.CustomButton.Name = "";
            this.packingFolderTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.packingFolderTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.packingFolderTextBox.CustomButton.TabIndex = 1;
            this.packingFolderTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.packingFolderTextBox.CustomButton.UseSelectable = true;
            this.packingFolderTextBox.CustomButton.Visible = false;
            this.packingFolderTextBox.Lines = new string[0];
            this.packingFolderTextBox.Location = new System.Drawing.Point(3, 54);
            this.packingFolderTextBox.MaxLength = 32767;
            this.packingFolderTextBox.Name = "packingFolderTextBox";
            this.packingFolderTextBox.PasswordChar = '\0';
            this.packingFolderTextBox.PromptText = "Select folder with extracted MSBT and XLIFF files...";
            this.packingFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.packingFolderTextBox.SelectedText = "";
            this.packingFolderTextBox.SelectionLength = 0;
            this.packingFolderTextBox.SelectionStart = 0;
            this.packingFolderTextBox.ShortcutsEnabled = true;
            this.packingFolderTextBox.Size = new System.Drawing.Size(315, 23);
            this.packingFolderTextBox.TabIndex = 2;
            this.packingFolderTextBox.UseSelectable = true;
            this.packingFolderTextBox.WaterMark = "Select folder with extracted MSBT and XLIFF files...";
            this.packingFolderTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.packingFolderTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // packXLIFFSButton
            // 
            this.packXLIFFSButton.Location = new System.Drawing.Point(161, 160);
            this.packXLIFFSButton.Name = "packXLIFFSButton";
            this.packXLIFFSButton.Size = new System.Drawing.Size(116, 45);
            this.packXLIFFSButton.TabIndex = 2;
            this.packXLIFFSButton.Text = "Pack XLIFFs to SZS";
            this.packXLIFFSButton.UseSelectable = true;
            this.packXLIFFSButton.Click += new System.EventHandler(this.PackXLIFFSButton_Click);
            // 
            // selectPackingFolderButton
            // 
            this.selectPackingFolderButton.Location = new System.Drawing.Point(324, 54);
            this.selectPackingFolderButton.Name = "selectPackingFolderButton";
            this.selectPackingFolderButton.Size = new System.Drawing.Size(105, 23);
            this.selectPackingFolderButton.TabIndex = 0;
            this.selectPackingFolderButton.Text = "Select folder";
            this.selectPackingFolderButton.UseSelectable = true;
            this.selectPackingFolderButton.Click += new System.EventHandler(this.SelectPackingFolderButton_Click);
            // 
            // extractingPanel
            // 
            this.extractingPanel.Controls.Add(this.selectExtractingFolderButton);
            this.extractingPanel.Controls.Add(this.extractingFolderTextBox);
            this.extractingPanel.Controls.Add(this.extractingSZSTextBox);
            this.extractingPanel.Controls.Add(this.extractingLabel);
            this.extractingPanel.Controls.Add(this.extractSZSButton);
            this.extractingPanel.Controls.Add(this.selectExtractingSZSButton);
            this.extractingPanel.HorizontalScrollbarBarColor = true;
            this.extractingPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.extractingPanel.HorizontalScrollbarSize = 10;
            this.extractingPanel.Location = new System.Drawing.Point(3, 3);
            this.extractingPanel.Name = "extractingPanel";
            this.extractingPanel.Size = new System.Drawing.Size(432, 236);
            this.extractingPanel.TabIndex = 3;
            this.extractingPanel.VerticalScrollbarBarColor = true;
            this.extractingPanel.VerticalScrollbarHighlightOnWheel = false;
            this.extractingPanel.VerticalScrollbarSize = 10;
            // 
            // selectExtractingFolderButton
            // 
            this.selectExtractingFolderButton.Location = new System.Drawing.Point(324, 105);
            this.selectExtractingFolderButton.Name = "selectExtractingFolderButton";
            this.selectExtractingFolderButton.Size = new System.Drawing.Size(105, 23);
            this.selectExtractingFolderButton.TabIndex = 5;
            this.selectExtractingFolderButton.Text = "Select folder";
            this.selectExtractingFolderButton.UseSelectable = true;
            this.selectExtractingFolderButton.Click += new System.EventHandler(this.SelectExtractingFolderButton_Click);
            // 
            // extractingFolderTextBox
            // 
            // 
            // 
            // 
            this.extractingFolderTextBox.CustomButton.Image = null;
            this.extractingFolderTextBox.CustomButton.Location = new System.Drawing.Point(293, 1);
            this.extractingFolderTextBox.CustomButton.Name = "";
            this.extractingFolderTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.extractingFolderTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.extractingFolderTextBox.CustomButton.TabIndex = 1;
            this.extractingFolderTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.extractingFolderTextBox.CustomButton.UseSelectable = true;
            this.extractingFolderTextBox.CustomButton.Visible = false;
            this.extractingFolderTextBox.Lines = new string[0];
            this.extractingFolderTextBox.Location = new System.Drawing.Point(3, 105);
            this.extractingFolderTextBox.MaxLength = 32767;
            this.extractingFolderTextBox.Name = "extractingFolderTextBox";
            this.extractingFolderTextBox.PasswordChar = '\0';
            this.extractingFolderTextBox.PromptText = "Select folder for extracted MSBT and XLIFF files...";
            this.extractingFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.extractingFolderTextBox.SelectedText = "";
            this.extractingFolderTextBox.SelectionLength = 0;
            this.extractingFolderTextBox.SelectionStart = 0;
            this.extractingFolderTextBox.ShortcutsEnabled = true;
            this.extractingFolderTextBox.Size = new System.Drawing.Size(315, 23);
            this.extractingFolderTextBox.TabIndex = 4;
            this.extractingFolderTextBox.UseSelectable = true;
            this.extractingFolderTextBox.WaterMark = "Select folder for extracted MSBT and XLIFF files...";
            this.extractingFolderTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.extractingFolderTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // extractingSZSTextBox
            // 
            // 
            // 
            // 
            this.extractingSZSTextBox.CustomButton.Image = null;
            this.extractingSZSTextBox.CustomButton.Location = new System.Drawing.Point(293, 1);
            this.extractingSZSTextBox.CustomButton.Name = "";
            this.extractingSZSTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.extractingSZSTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.extractingSZSTextBox.CustomButton.TabIndex = 1;
            this.extractingSZSTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.extractingSZSTextBox.CustomButton.UseSelectable = true;
            this.extractingSZSTextBox.CustomButton.Visible = false;
            this.extractingSZSTextBox.Lines = new string[0];
            this.extractingSZSTextBox.Location = new System.Drawing.Point(3, 54);
            this.extractingSZSTextBox.MaxLength = 32767;
            this.extractingSZSTextBox.Name = "extractingSZSTextBox";
            this.extractingSZSTextBox.PasswordChar = '\0';
            this.extractingSZSTextBox.PromptText = "Select SZS file to extract...";
            this.extractingSZSTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.extractingSZSTextBox.SelectedText = "";
            this.extractingSZSTextBox.SelectionLength = 0;
            this.extractingSZSTextBox.SelectionStart = 0;
            this.extractingSZSTextBox.ShortcutsEnabled = true;
            this.extractingSZSTextBox.Size = new System.Drawing.Size(315, 23);
            this.extractingSZSTextBox.TabIndex = 2;
            this.extractingSZSTextBox.UseSelectable = true;
            this.extractingSZSTextBox.WaterMark = "Select SZS file to extract...";
            this.extractingSZSTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.extractingSZSTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // extractingLabel
            // 
            this.extractingLabel.AutoSize = true;
            this.extractingLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.extractingLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.extractingLabel.Location = new System.Drawing.Point(0, 3);
            this.extractingLabel.Name = "extractingLabel";
            this.extractingLabel.Size = new System.Drawing.Size(89, 25);
            this.extractingLabel.TabIndex = 3;
            this.extractingLabel.Text = "Extracting";
            // 
            // extractSZSButton
            // 
            this.extractSZSButton.Location = new System.Drawing.Point(119, 160);
            this.extractSZSButton.Name = "extractSZSButton";
            this.extractSZSButton.Size = new System.Drawing.Size(200, 45);
            this.extractSZSButton.TabIndex = 1;
            this.extractSZSButton.Text = "Extract MSBTs and XLIFFs from SZS ";
            this.extractSZSButton.UseSelectable = true;
            this.extractSZSButton.Click += new System.EventHandler(this.ExtractSZSButton_Click);
            // 
            // selectExtractingSZSButton
            // 
            this.selectExtractingSZSButton.Location = new System.Drawing.Point(324, 54);
            this.selectExtractingSZSButton.Name = "selectExtractingSZSButton";
            this.selectExtractingSZSButton.Size = new System.Drawing.Size(105, 23);
            this.selectExtractingSZSButton.TabIndex = 0;
            this.selectExtractingSZSButton.Text = "Select SZS file";
            this.selectExtractingSZSButton.UseSelectable = true;
            this.selectExtractingSZSButton.Click += new System.EventHandler(this.SelectExtractingSZSButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 649);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "SMO Translation Helper";
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.packingPanel.ResumeLayout(false);
            this.packingPanel.PerformLayout();
            this.extractingPanel.ResumeLayout(false);
            this.extractingPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private MetroFramework.Controls.MetroTabControl metroTabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private MetroFramework.Controls.MetroButton selectExtractingSZSButton;
		private MetroFramework.Controls.MetroButton extractSZSButton;
		private MetroFramework.Controls.MetroPanel extractingPanel;
		private MetroFramework.Controls.MetroPanel metroPanel2;
		private MetroFramework.Controls.MetroButton packXLIFFSButton;
		private MetroFramework.Controls.MetroTextBox extractingSZSTextBox;
		private MetroFramework.Controls.MetroLabel extractingLabel;
		private MetroFramework.Controls.MetroPanel packingPanel;
		private MetroFramework.Controls.MetroLabel packingLabel;
		private MetroFramework.Controls.MetroPanel metroPanel1;
		private MetroFramework.Controls.MetroButton selectExtractingFolderButton;
		private MetroFramework.Controls.MetroTextBox extractingFolderTextBox;
		private MetroFramework.Controls.MetroButton selectPackingSZSButton;
		private MetroFramework.Controls.MetroTextBox packingSZSTextBox;
		private MetroFramework.Controls.MetroTextBox packingFolderTextBox;
		private MetroFramework.Controls.MetroButton selectPackingFolderButton;
	}
}


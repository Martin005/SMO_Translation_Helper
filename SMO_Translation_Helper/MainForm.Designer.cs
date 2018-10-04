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
			this.packingLabel = new MetroFramework.Controls.MetroLabel();
			this.packXLIFFSButton = new MetroFramework.Controls.MetroButton();
			this.extractingPanel = new MetroFramework.Controls.MetroPanel();
			this.extractingTextBox = new MetroFramework.Controls.MetroTextBox();
			this.extractingLabel = new MetroFramework.Controls.MetroLabel();
			this.extractSZSButton = new MetroFramework.Controls.MetroButton();
			this.selectSZSButton = new MetroFramework.Controls.MetroButton();
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
			this.metroTabControl1.Size = new System.Drawing.Size(452, 458);
			this.metroTabControl1.TabIndex = 4;
			this.metroTabControl1.UseSelectable = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.metroPanel2);
			this.tabPage1.Location = new System.Drawing.Point(4, 38);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(444, 416);
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
			this.metroPanel2.Size = new System.Drawing.Size(438, 410);
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
			this.metroPanel1.Location = new System.Drawing.Point(0, 209);
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
			this.packingPanel.Controls.Add(this.packingLabel);
			this.packingPanel.Controls.Add(this.packXLIFFSButton);
			this.packingPanel.HorizontalScrollbarBarColor = true;
			this.packingPanel.HorizontalScrollbarHighlightOnWheel = false;
			this.packingPanel.HorizontalScrollbarSize = 10;
			this.packingPanel.Location = new System.Drawing.Point(3, 228);
			this.packingPanel.Name = "packingPanel";
			this.packingPanel.Size = new System.Drawing.Size(432, 181);
			this.packingPanel.TabIndex = 4;
			this.packingPanel.VerticalScrollbarBarColor = true;
			this.packingPanel.VerticalScrollbarHighlightOnWheel = false;
			this.packingPanel.VerticalScrollbarSize = 10;
			// 
			// packingLabel
			// 
			this.packingLabel.AutoSize = true;
			this.packingLabel.Location = new System.Drawing.Point(3, 3);
			this.packingLabel.Name = "packingLabel";
			this.packingLabel.Size = new System.Drawing.Size(53, 19);
			this.packingLabel.TabIndex = 3;
			this.packingLabel.Text = "Packing";
			// 
			// packXLIFFSButton
			// 
			this.packXLIFFSButton.Location = new System.Drawing.Point(161, 98);
			this.packXLIFFSButton.Name = "packXLIFFSButton";
			this.packXLIFFSButton.Size = new System.Drawing.Size(116, 45);
			this.packXLIFFSButton.TabIndex = 2;
			this.packXLIFFSButton.Text = "Pack XLIFFs to SZS";
			this.packXLIFFSButton.UseSelectable = true;
			this.packXLIFFSButton.Click += new System.EventHandler(this.PackXLIFFSButton_Click);
			// 
			// extractingPanel
			// 
			this.extractingPanel.Controls.Add(this.extractingTextBox);
			this.extractingPanel.Controls.Add(this.extractingLabel);
			this.extractingPanel.Controls.Add(this.extractSZSButton);
			this.extractingPanel.Controls.Add(this.selectSZSButton);
			this.extractingPanel.HorizontalScrollbarBarColor = true;
			this.extractingPanel.HorizontalScrollbarHighlightOnWheel = false;
			this.extractingPanel.HorizontalScrollbarSize = 10;
			this.extractingPanel.Location = new System.Drawing.Point(3, 3);
			this.extractingPanel.Name = "extractingPanel";
			this.extractingPanel.Size = new System.Drawing.Size(432, 200);
			this.extractingPanel.TabIndex = 3;
			this.extractingPanel.VerticalScrollbarBarColor = true;
			this.extractingPanel.VerticalScrollbarHighlightOnWheel = false;
			this.extractingPanel.VerticalScrollbarSize = 10;
			// 
			// extractingTextBox
			// 
			this.extractingTextBox.CustomButton.Image = null;
			this.extractingTextBox.CustomButton.Location = new System.Drawing.Point(285, 1);
			this.extractingTextBox.CustomButton.Name = "";
			this.extractingTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.extractingTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.extractingTextBox.CustomButton.TabIndex = 1;
			this.extractingTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.extractingTextBox.CustomButton.UseSelectable = true;
			this.extractingTextBox.CustomButton.Visible = false;
			this.extractingTextBox.Lines = new string[0];
			this.extractingTextBox.Location = new System.Drawing.Point(11, 54);
			this.extractingTextBox.MaxLength = 32767;
			this.extractingTextBox.Name = "extractingTextBox";
			this.extractingTextBox.PasswordChar = '\0';
			this.extractingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.extractingTextBox.SelectedText = "";
			this.extractingTextBox.SelectionLength = 0;
			this.extractingTextBox.SelectionStart = 0;
			this.extractingTextBox.ShortcutsEnabled = true;
			this.extractingTextBox.Size = new System.Drawing.Size(307, 23);
			this.extractingTextBox.TabIndex = 2;
			this.extractingTextBox.UseSelectable = true;
			this.extractingTextBox.WaterMark = "Select SZS file...";
			this.extractingTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.extractingTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// extractingLabel
			// 
			this.extractingLabel.AutoSize = true;
			this.extractingLabel.Location = new System.Drawing.Point(3, 3);
			this.extractingLabel.Name = "extractingLabel";
			this.extractingLabel.Size = new System.Drawing.Size(66, 19);
			this.extractingLabel.TabIndex = 3;
			this.extractingLabel.Text = "Extracting";
			// 
			// extractSZSButton
			// 
			this.extractSZSButton.Location = new System.Drawing.Point(118, 126);
			this.extractSZSButton.Name = "extractSZSButton";
			this.extractSZSButton.Size = new System.Drawing.Size(200, 45);
			this.extractSZSButton.TabIndex = 1;
			this.extractSZSButton.Text = "Extract MSBTs and XLLIFs from SZS ";
			this.extractSZSButton.UseSelectable = true;
			this.extractSZSButton.Click += new System.EventHandler(this.ExtractSZSButton_Click);
			// 
			// selectSZSButton
			// 
			this.selectSZSButton.Location = new System.Drawing.Point(324, 54);
			this.selectSZSButton.Name = "selectSZSButton";
			this.selectSZSButton.Size = new System.Drawing.Size(105, 23);
			this.selectSZSButton.TabIndex = 0;
			this.selectSZSButton.Text = "Select SZS file";
			this.selectSZSButton.UseSelectable = true;
			this.selectSZSButton.Click += new System.EventHandler(this.SelectSZSButton_Click);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(495, 544);
			this.Controls.Add(this.metroTabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
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
		private MetroFramework.Controls.MetroButton selectSZSButton;
		private MetroFramework.Controls.MetroButton extractSZSButton;
		private MetroFramework.Controls.MetroPanel extractingPanel;
		private MetroFramework.Controls.MetroPanel metroPanel2;
		private MetroFramework.Controls.MetroButton packXLIFFSButton;
		private MetroFramework.Controls.MetroTextBox extractingTextBox;
		private MetroFramework.Controls.MetroLabel extractingLabel;
		private MetroFramework.Controls.MetroPanel packingPanel;
		private MetroFramework.Controls.MetroLabel packingLabel;
		private MetroFramework.Controls.MetroPanel metroPanel1;
	}
}


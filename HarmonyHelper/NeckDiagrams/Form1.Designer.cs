
namespace NeckDiagrams
{
	partial class Form1
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
            this.bottomMenuPanel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this._pnlNav = new System.Windows.Forms.Panel();
            this._rbManufaktura = new System.Windows.Forms.RadioButton();
            this._bnFeatureVoiceLeading = new System.Windows.Forms.RadioButton();
            this._bnFeatureLeadSheets = new System.Windows.Forms.RadioButton();
            this._bnFeatureArpeggiator = new System.Windows.Forms.RadioButton();
            this._bnFeatureReHarmonize = new System.Windows.Forms.RadioButton();
            this._bnFeatureHarmonicAnalysis = new System.Windows.Forms.RadioButton();
            this._bnFeatureArpeggios = new System.Windows.Forms.RadioButton();
            this._bnFeatureScales = new System.Windows.Forms.RadioButton();
            this._pnlMain = new System.Windows.Forms.Panel();
            this.bottomMenuPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this._pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomMenuPanel
            // 
            this.bottomMenuPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bottomMenuPanel.Controls.Add(this.menuStrip);
            this.bottomMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomMenuPanel.Location = new System.Drawing.Point(200, 750);
            this.bottomMenuPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bottomMenuPanel.Name = "bottomMenuPanel";
            this.bottomMenuPanel.Size = new System.Drawing.Size(1400, 115);
            this.bottomMenuPanel.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1400, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "File";
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.toolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.toolStripMenuItem.Text = "Print";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printDocument1_QueryPageSettings);
            // 
            // _pnlNav
            // 
            this._pnlNav.BackColor = System.Drawing.SystemColors.ControlLight;
            this._pnlNav.Controls.Add(this._rbManufaktura);
            this._pnlNav.Controls.Add(this._bnFeatureVoiceLeading);
            this._pnlNav.Controls.Add(this._bnFeatureScales);
            this._pnlNav.Controls.Add(this._bnFeatureReHarmonize);
            this._pnlNav.Controls.Add(this._bnFeatureLeadSheets);
            this._pnlNav.Controls.Add(this._bnFeatureHarmonicAnalysis);
            this._pnlNav.Controls.Add(this._bnFeatureArpeggiator);
            this._pnlNav.Controls.Add(this._bnFeatureArpeggios);
            this._pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this._pnlNav.Location = new System.Drawing.Point(0, 0);
            this._pnlNav.Name = "_pnlNav";
            this._pnlNav.Size = new System.Drawing.Size(200, 865);
            this._pnlNav.TabIndex = 2;
            // 
            // _rbManufaktura
            // 
            this._rbManufaktura.Appearance = System.Windows.Forms.Appearance.Button;
            this._rbManufaktura.AutoSize = true;
            this._rbManufaktura.Dock = System.Windows.Forms.DockStyle.Top;
            this._rbManufaktura.Location = new System.Drawing.Point(0, 245);
            this._rbManufaktura.Name = "_rbManufaktura";
            this._rbManufaktura.Size = new System.Drawing.Size(200, 35);
            this._rbManufaktura.TabIndex = 7;
            this._rbManufaktura.Text = "Manufaktura";
            this._rbManufaktura.UseVisualStyleBackColor = true;
            this._rbManufaktura.CheckedChanged += new System.EventHandler(this._rbManufaktura_CheckedChanged);
            // 
            // _bnFeatureVoiceLeading
            // 
            this._bnFeatureVoiceLeading.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureVoiceLeading.AutoSize = true;
            this._bnFeatureVoiceLeading.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureVoiceLeading.Location = new System.Drawing.Point(0, 210);
            this._bnFeatureVoiceLeading.Name = "_bnFeatureVoiceLeading";
            this._bnFeatureVoiceLeading.Size = new System.Drawing.Size(200, 35);
            this._bnFeatureVoiceLeading.TabIndex = 6;
            this._bnFeatureVoiceLeading.Text = "Voice Leading";
            this._bnFeatureVoiceLeading.UseVisualStyleBackColor = true;
            this._bnFeatureVoiceLeading.CheckedChanged += new System.EventHandler(this._bnFeatureVoiceLeading_CheckedChanged);
            // 
            // _bnFeatureLeadSheets
            // 
            this._bnFeatureLeadSheets.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureLeadSheets.AutoSize = true;
            this._bnFeatureLeadSheets.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureLeadSheets.Location = new System.Drawing.Point(0, 105);
            this._bnFeatureLeadSheets.Name = "_bnFeatureLeadSheets";
            this._bnFeatureLeadSheets.Size = new System.Drawing.Size(200, 35);
            this._bnFeatureLeadSheets.TabIndex = 5;
            this._bnFeatureLeadSheets.Text = "Lead Sheets";
            this._bnFeatureLeadSheets.UseVisualStyleBackColor = true;
            this._bnFeatureLeadSheets.CheckedChanged += new System.EventHandler(this._bnFeatureLeadSheets_CheckedChanged);
            // 
            // _bnFeatureArpeggiator
            // 
            this._bnFeatureArpeggiator.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureArpeggiator.AutoSize = true;
            this._bnFeatureArpeggiator.Checked = true;
            this._bnFeatureArpeggiator.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureArpeggiator.Location = new System.Drawing.Point(0, 35);
            this._bnFeatureArpeggiator.Name = "_bnFeatureArpeggiator";
            this._bnFeatureArpeggiator.Size = new System.Drawing.Size(200, 35);
            this._bnFeatureArpeggiator.TabIndex = 4;
            this._bnFeatureArpeggiator.TabStop = true;
            this._bnFeatureArpeggiator.Text = "Arpeggiator";
            this._bnFeatureArpeggiator.UseVisualStyleBackColor = true;
            this._bnFeatureArpeggiator.CheckedChanged += new System.EventHandler(this._bnFeatureArpeggiator_CheckedChanged);
            // 
            // _bnFeatureReHarmonize
            // 
            this._bnFeatureReHarmonize.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureReHarmonize.AutoSize = true;
            this._bnFeatureReHarmonize.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureReHarmonize.Location = new System.Drawing.Point(0, 140);
            this._bnFeatureReHarmonize.Name = "_bnFeatureReHarmonize";
            this._bnFeatureReHarmonize.Size = new System.Drawing.Size(200, 35);
            this._bnFeatureReHarmonize.TabIndex = 3;
            this._bnFeatureReHarmonize.Text = "Re-Harmonize";
            this._bnFeatureReHarmonize.UseVisualStyleBackColor = true;
            this._bnFeatureReHarmonize.CheckedChanged += new System.EventHandler(this._bnFeatureReHarmonize_CheckedChanged);
            // 
            // _bnFeatureHarmonicAnalysis
            // 
            this._bnFeatureHarmonicAnalysis.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureHarmonicAnalysis.AutoSize = true;
            this._bnFeatureHarmonicAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureHarmonicAnalysis.Location = new System.Drawing.Point(0, 70);
            this._bnFeatureHarmonicAnalysis.Name = "_bnFeatureHarmonicAnalysis";
            this._bnFeatureHarmonicAnalysis.Size = new System.Drawing.Size(200, 35);
            this._bnFeatureHarmonicAnalysis.TabIndex = 2;
            this._bnFeatureHarmonicAnalysis.Text = "Harmonic Analysis";
            this._bnFeatureHarmonicAnalysis.UseVisualStyleBackColor = true;
            this._bnFeatureHarmonicAnalysis.CheckedChanged += new System.EventHandler(this._bnFeatureHarmonicAnalysis_CheckedChanged);
            // 
            // _bnFeatureArpeggios
            // 
            this._bnFeatureArpeggios.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureArpeggios.AutoSize = true;
            this._bnFeatureArpeggios.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureArpeggios.Location = new System.Drawing.Point(0, 0);
            this._bnFeatureArpeggios.Name = "_bnFeatureArpeggios";
            this._bnFeatureArpeggios.Size = new System.Drawing.Size(200, 35);
            this._bnFeatureArpeggios.TabIndex = 1;
            this._bnFeatureArpeggios.Text = "Argeggios";
            this._bnFeatureArpeggios.UseVisualStyleBackColor = true;
            this._bnFeatureArpeggios.CheckedChanged += new System.EventHandler(this._bnFeatureArpeggios_CheckedChanged);
            // 
            // _bnFeatureScales
            // 
            this._bnFeatureScales.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureScales.AutoSize = true;
            this._bnFeatureScales.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureScales.Location = new System.Drawing.Point(0, 175);
            this._bnFeatureScales.Name = "_bnFeatureScales";
            this._bnFeatureScales.Size = new System.Drawing.Size(200, 35);
            this._bnFeatureScales.TabIndex = 0;
            this._bnFeatureScales.Text = "Scales";
            this._bnFeatureScales.UseVisualStyleBackColor = true;
            this._bnFeatureScales.CheckedChanged += new System.EventHandler(this._bnFeatureScales_CheckedChanged);
            // 
            // _pnlMain
            // 
            this._pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMain.Location = new System.Drawing.Point(200, 0);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(1400, 750);
            this._pnlMain.TabIndex = 3;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this._pnlMain);
            this.Controls.Add(this.bottomMenuPanel);
            this.Controls.Add(this._pnlNav);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Harmony Helper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.bottomMenuPanel.ResumeLayout(false);
            this.bottomMenuPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this._pnlNav.ResumeLayout(false);
            this._pnlNav.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel bottomMenuPanel;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
		private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Panel _pnlNav;
        private System.Windows.Forms.RadioButton _bnFeatureVoiceLeading;
        private System.Windows.Forms.RadioButton _bnFeatureLeadSheets;
        private System.Windows.Forms.RadioButton _bnFeatureArpeggiator;
        private System.Windows.Forms.RadioButton _bnFeatureReHarmonize;
        private System.Windows.Forms.RadioButton _bnFeatureHarmonicAnalysis;
        private System.Windows.Forms.RadioButton _bnFeatureArpeggios;
        private System.Windows.Forms.RadioButton _bnFeatureScales;
        private System.Windows.Forms.Panel _pnlMain;
        private System.Windows.Forms.RadioButton _rbManufaktura;
    }
}


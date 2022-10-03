
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.modelsControl = new NeckDiagrams.ModelsControl();
            this.keyPanel = new System.Windows.Forms.Panel();
            this._bnAddItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._cbKey = new System.Windows.Forms.ComboBox();
            this.neckPanel = new System.Windows.Forms.Panel();
            this._neckCtl = new NeckDiagrams.NeckControl();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.neckTabPage = new System.Windows.Forms.TabPage();
            this.arpeggiatorTabPage = new System.Windows.Forms.TabPage();
            this.analyzerTabPage = new System.Windows.Forms.TabPage();
            this.harmonicAnalysisControl1 = new NeckDiagrams.Controls.HarmonicAnalysisControl();
            this._pnlNav = new System.Windows.Forms.Panel();
            this._bnFeatureScales = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this._bnScales = new System.Windows.Forms.RadioButton();
            this.bottomMenuPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.keyPanel.SuspendLayout();
            this.neckPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.neckTabPage.SuspendLayout();
            this.analyzerTabPage.SuspendLayout();
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
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
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
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.Control;
            this.topPanel.Controls.Add(this.modelsControl);
            this.topPanel.Controls.Add(this.keyPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(40, 39);
            this.topPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.topPanel.MinimumSize = new System.Drawing.Size(1600, 192);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1600, 192);
            this.topPanel.TabIndex = 2;
            // 
            // modelsControl
            // 
            this.modelsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelsControl.Location = new System.Drawing.Point(400, 0);
            this.modelsControl.Margin = new System.Windows.Forms.Padding(8);
            this.modelsControl.Name = "modelsControl";
            this.modelsControl.Size = new System.Drawing.Size(1200, 192);
            this.modelsControl.TabIndex = 2;
            // 
            // keyPanel
            // 
            this.keyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.keyPanel.Controls.Add(this._bnAddItem);
            this.keyPanel.Controls.Add(this.label1);
            this.keyPanel.Controls.Add(this._cbKey);
            this.keyPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.keyPanel.Location = new System.Drawing.Point(0, 0);
            this.keyPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.keyPanel.Name = "keyPanel";
            this.keyPanel.Size = new System.Drawing.Size(400, 192);
            this.keyPanel.TabIndex = 1;
            // 
            // _bnAddItem
            // 
            this._bnAddItem.Location = new System.Drawing.Point(212, 100);
            this._bnAddItem.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._bnAddItem.Name = "_bnAddItem";
            this._bnAddItem.Size = new System.Drawing.Size(149, 44);
            this._bnAddItem.TabIndex = 6;
            this._bnAddItem.Text = "+";
            this._bnAddItem.UseVisualStyleBackColor = true;
            this._bnAddItem.Click += new System.EventHandler(this._bnAddItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _cbKey
            // 
            this._cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbKey.FormattingEnabled = true;
            this._cbKey.Location = new System.Drawing.Point(120, 49);
            this._cbKey.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._cbKey.Name = "_cbKey";
            this._cbKey.Size = new System.Drawing.Size(239, 33);
            this._cbKey.TabIndex = 4;
            // 
            // neckPanel
            // 
            this.neckPanel.BackColor = System.Drawing.SystemColors.Control;
            this.neckPanel.Controls.Add(this.topPanel);
            this.neckPanel.Controls.Add(this._neckCtl);
            this.neckPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neckPanel.Location = new System.Drawing.Point(4, 5);
            this.neckPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.neckPanel.Name = "neckPanel";
            this.neckPanel.Padding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.neckPanel.Size = new System.Drawing.Size(1384, 702);
            this.neckPanel.TabIndex = 3;
            // 
            // _neckCtl
            // 
            this._neckCtl.BackColor = System.Drawing.SystemColors.Control;
            this._neckCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._neckCtl.Location = new System.Drawing.Point(40, 39);
            this._neckCtl.Margin = new System.Windows.Forms.Padding(8);
            this._neckCtl.Name = "_neckCtl";
            this._neckCtl.Size = new System.Drawing.Size(1304, 624);
            this._neckCtl.TabIndex = 0;
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.neckTabPage);
            this.tabControl.Controls.Add(this.arpeggiatorTabPage);
            this.tabControl.Controls.Add(this.analyzerTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(200, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(1400, 750);
            this.tabControl.TabIndex = 1;
            // 
            // neckTabPage
            // 
            this.neckTabPage.Controls.Add(this.neckPanel);
            this.neckTabPage.Location = new System.Drawing.Point(4, 34);
            this.neckTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.neckTabPage.Name = "neckTabPage";
            this.neckTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.neckTabPage.Size = new System.Drawing.Size(1392, 712);
            this.neckTabPage.TabIndex = 0;
            this.neckTabPage.Text = "Neck";
            this.neckTabPage.UseVisualStyleBackColor = true;
            // 
            // arpeggiatorTabPage
            // 
            this.arpeggiatorTabPage.Location = new System.Drawing.Point(4, 34);
            this.arpeggiatorTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.arpeggiatorTabPage.Name = "arpeggiatorTabPage";
            this.arpeggiatorTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.arpeggiatorTabPage.Size = new System.Drawing.Size(1592, 712);
            this.arpeggiatorTabPage.TabIndex = 1;
            this.arpeggiatorTabPage.Text = "Arpeggiator";
            this.arpeggiatorTabPage.UseVisualStyleBackColor = true;
            // 
            // analyzerTabPage
            // 
            this.analyzerTabPage.Controls.Add(this.harmonicAnalysisControl1);
            this.analyzerTabPage.Location = new System.Drawing.Point(4, 34);
            this.analyzerTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.analyzerTabPage.Name = "analyzerTabPage";
            this.analyzerTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.analyzerTabPage.Size = new System.Drawing.Size(1592, 712);
            this.analyzerTabPage.TabIndex = 2;
            this.analyzerTabPage.Text = "Analyzer";
            this.analyzerTabPage.UseVisualStyleBackColor = true;
            // 
            // harmonicAnalysisControl1
            // 
            this.harmonicAnalysisControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.harmonicAnalysisControl1.Location = new System.Drawing.Point(4, 5);
            this.harmonicAnalysisControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.harmonicAnalysisControl1.Name = "harmonicAnalysisControl1";
            this.harmonicAnalysisControl1.Size = new System.Drawing.Size(1584, 702);
            this.harmonicAnalysisControl1.TabIndex = 1;
            // 
            // _pnlNav
            // 
            this._pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._pnlNav.Controls.Add(this._bnScales);
            this._pnlNav.Controls.Add(this.radioButton6);
            this._pnlNav.Controls.Add(this.radioButton5);
            this._pnlNav.Controls.Add(this.radioButton4);
            this._pnlNav.Controls.Add(this.radioButton3);
            this._pnlNav.Controls.Add(this.radioButton2);
            this._pnlNav.Controls.Add(this._bnFeatureScales);
            this._pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this._pnlNav.Location = new System.Drawing.Point(0, 0);
            this._pnlNav.Name = "_pnlNav";
            this._pnlNav.Size = new System.Drawing.Size(200, 865);
            this._pnlNav.TabIndex = 2;
            // 
            // _bnFeatureScales
            // 
            this._bnFeatureScales.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureScales.AutoSize = true;
            this._bnFeatureScales.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureScales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._bnFeatureScales.Location = new System.Drawing.Point(0, 0);
            this._bnFeatureScales.Name = "_bnFeatureScales";
            this._bnFeatureScales.Size = new System.Drawing.Size(200, 37);
            this._bnFeatureScales.TabIndex = 0;
            this._bnFeatureScales.TabStop = true;
            this._bnFeatureScales.Text = "Scales";
            this._bnFeatureScales.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(0, 37);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(200, 37);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Argeggios";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(0, 74);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(200, 37);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Harmonic Analysis";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton4.Location = new System.Drawing.Point(0, 111);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(200, 37);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Re-Harmonize";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton5.AutoSize = true;
            this.radioButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton5.Location = new System.Drawing.Point(0, 148);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(200, 37);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton6.AutoSize = true;
            this.radioButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton6.Location = new System.Drawing.Point(0, 185);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(200, 37);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // _bnScales
            // 
            this._bnScales.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnScales.AutoSize = true;
            this._bnScales.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnScales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._bnScales.Location = new System.Drawing.Point(0, 222);
            this._bnScales.Name = "_bnScales";
            this._bnScales.Size = new System.Drawing.Size(200, 37);
            this._bnScales.TabIndex = 6;
            this._bnScales.TabStop = true;
            this._bnScales.Text = "radioButton7";
            this._bnScales.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bottomMenuPanel);
            this.Controls.Add(this._pnlNav);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.bottomMenuPanel.ResumeLayout(false);
            this.bottomMenuPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.keyPanel.ResumeLayout(false);
            this.keyPanel.PerformLayout();
            this.neckPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.neckTabPage.ResumeLayout(false);
            this.analyzerTabPage.ResumeLayout(false);
            this._pnlNav.ResumeLayout(false);
            this._pnlNav.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel bottomMenuPanel;
		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Panel neckPanel;
		private NeckControl _neckCtl;
		private ModelsControl modelsControl;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage neckTabPage;
		private System.Windows.Forms.TabPage arpeggiatorTabPage;
        private System.Windows.Forms.TabPage analyzerTabPage;
        private System.Windows.Forms.Panel keyPanel;
        private System.Windows.Forms.Button _bnAddItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cbKey;
        private Controls.HarmonicAnalysisControl harmonicAnalysisControl1;
        private System.Windows.Forms.Panel _pnlNav;
        private System.Windows.Forms.RadioButton _bnScales;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton _bnFeatureScales;
    }
}


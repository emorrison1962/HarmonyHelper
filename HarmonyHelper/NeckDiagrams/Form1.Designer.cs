
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
            this.bottomMenuPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.keyPanel.SuspendLayout();
            this.neckPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.neckTabPage.SuspendLayout();
            this.analyzerTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomMenuPanel
            // 
            this.bottomMenuPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bottomMenuPanel.Controls.Add(this.menuStrip);
            this.bottomMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomMenuPanel.Location = new System.Drawing.Point(0, 480);
            this.bottomMenuPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bottomMenuPanel.Name = "bottomMenuPanel";
            this.bottomMenuPanel.Size = new System.Drawing.Size(1067, 74);
            this.bottomMenuPanel.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "File";
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.toolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.toolStripMenuItem.Text = "Print";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.Control;
            this.topPanel.Controls.Add(this.modelsControl);
            this.topPanel.Controls.Add(this.keyPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(27, 25);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topPanel.MinimumSize = new System.Drawing.Size(1067, 123);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1067, 123);
            this.topPanel.TabIndex = 2;
            // 
            // modelsControl
            // 
            this.modelsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelsControl.Location = new System.Drawing.Point(267, 0);
            this.modelsControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.modelsControl.Name = "modelsControl";
            this.modelsControl.Size = new System.Drawing.Size(800, 123);
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
            this.keyPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.keyPanel.Name = "keyPanel";
            this.keyPanel.Size = new System.Drawing.Size(267, 123);
            this.keyPanel.TabIndex = 1;
            // 
            // _bnAddItem
            // 
            this._bnAddItem.Location = new System.Drawing.Point(141, 64);
            this._bnAddItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._bnAddItem.Name = "_bnAddItem";
            this._bnAddItem.Size = new System.Drawing.Size(100, 28);
            this._bnAddItem.TabIndex = 6;
            this._bnAddItem.Text = "+";
            this._bnAddItem.UseVisualStyleBackColor = true;
            this._bnAddItem.Click += new System.EventHandler(this._bnAddItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _cbKey
            // 
            this._cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbKey.FormattingEnabled = true;
            this._cbKey.Location = new System.Drawing.Point(80, 31);
            this._cbKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._cbKey.Name = "_cbKey";
            this._cbKey.Size = new System.Drawing.Size(160, 24);
            this._cbKey.TabIndex = 4;
            // 
            // neckPanel
            // 
            this.neckPanel.BackColor = System.Drawing.SystemColors.Control;
            this.neckPanel.Controls.Add(this.topPanel);
            this.neckPanel.Controls.Add(this._neckCtl);
            this.neckPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neckPanel.Location = new System.Drawing.Point(3, 3);
            this.neckPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.neckPanel.Name = "neckPanel";
            this.neckPanel.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.neckPanel.Size = new System.Drawing.Size(1053, 445);
            this.neckPanel.TabIndex = 3;
            // 
            // _neckCtl
            // 
            this._neckCtl.BackColor = System.Drawing.SystemColors.Control;
            this._neckCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._neckCtl.Location = new System.Drawing.Point(27, 25);
            this._neckCtl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this._neckCtl.Name = "_neckCtl";
            this._neckCtl.Size = new System.Drawing.Size(999, 395);
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
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 2;
            this.tabControl.Size = new System.Drawing.Size(1067, 480);
            this.tabControl.TabIndex = 1;
            // 
            // neckTabPage
            // 
            this.neckTabPage.Controls.Add(this.neckPanel);
            this.neckTabPage.Location = new System.Drawing.Point(4, 25);
            this.neckTabPage.Name = "neckTabPage";
            this.neckTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.neckTabPage.Size = new System.Drawing.Size(1059, 451);
            this.neckTabPage.TabIndex = 0;
            this.neckTabPage.Text = "Neck";
            this.neckTabPage.UseVisualStyleBackColor = true;
            // 
            // arpeggiatorTabPage
            // 
            this.arpeggiatorTabPage.Location = new System.Drawing.Point(4, 25);
            this.arpeggiatorTabPage.Name = "arpeggiatorTabPage";
            this.arpeggiatorTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.arpeggiatorTabPage.Size = new System.Drawing.Size(1059, 451);
            this.arpeggiatorTabPage.TabIndex = 1;
            this.arpeggiatorTabPage.Text = "Arpeggiator";
            this.arpeggiatorTabPage.UseVisualStyleBackColor = true;
            // 
            // analyzerTabPage
            // 
            this.analyzerTabPage.Controls.Add(this.harmonicAnalysisControl1);
            this.analyzerTabPage.Location = new System.Drawing.Point(4, 25);
            this.analyzerTabPage.Name = "analyzerTabPage";
            this.analyzerTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.analyzerTabPage.Size = new System.Drawing.Size(1059, 451);
            this.analyzerTabPage.TabIndex = 2;
            this.analyzerTabPage.Text = "Analyzer";
            this.analyzerTabPage.UseVisualStyleBackColor = true;
            // 
            // harmonicAnalysisControl1
            // 
            this.harmonicAnalysisControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.harmonicAnalysisControl1.Location = new System.Drawing.Point(3, 3);
            this.harmonicAnalysisControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.harmonicAnalysisControl1.Name = "harmonicAnalysisControl1";
            this.harmonicAnalysisControl1.Size = new System.Drawing.Size(1053, 445);
            this.harmonicAnalysisControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bottomMenuPanel);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}


namespace NeckDiagrams.Controls
{
    partial class ScratchPadControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.bottomMenuPanel = new System.Windows.Forms.Panel();
            this._pnlMain = new System.Windows.Forms.Panel();
            this.navPanelControl1 = new NeckDiagrams.Controls.NavPanelControl();
            this.menuStrip.SuspendLayout();
            this.bottomMenuPanel.SuspendLayout();
            this._pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.toolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.toolStripMenuItem.Text = "Print";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1947, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "File";
            // 
            // bottomMenuPanel
            // 
            this.bottomMenuPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bottomMenuPanel.Controls.Add(this.menuStrip);
            this.bottomMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomMenuPanel.Location = new System.Drawing.Point(0, 836);
            this.bottomMenuPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bottomMenuPanel.Name = "bottomMenuPanel";
            this.bottomMenuPanel.Size = new System.Drawing.Size(1947, 115);
            this.bottomMenuPanel.TabIndex = 4;
            // 
            // _pnlMain
            // 
            this._pnlMain.Controls.Add(this.navPanelControl1);
            this._pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMain.Location = new System.Drawing.Point(0, 0);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(1947, 951);
            this._pnlMain.TabIndex = 6;
            // 
            // navPanelControl1
            // 
            this.navPanelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.navPanelControl1.Name = "navPanelControl1";
            this.navPanelControl1.Size = new System.Drawing.Size(187, 951);
            this.navPanelControl1.TabIndex = 0;
            // 
            // ScratchPadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomMenuPanel);
            this.Controls.Add(this._pnlMain);
            this.Name = "ScratchPadControl";
            this.Size = new System.Drawing.Size(1947, 951);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.bottomMenuPanel.ResumeLayout(false);
            this.bottomMenuPanel.PerformLayout();
            this._pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Panel bottomMenuPanel;
        private System.Windows.Forms.Panel _pnlMain;
        private NavPanelControl navPanelControl1;
    }
}

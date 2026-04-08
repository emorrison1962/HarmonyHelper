
using NeckDiagrams.Controls;

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
            this._pnlMain = new System.Windows.Forms.Panel();
            this._pnlFeatureView = new System.Windows.Forms.Panel();
            this._ctlNav = new NavPanelControl();
            this.bottomMenuPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this._pnlMain.SuspendLayout();
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
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripMenuItem });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1400, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "File";
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            this.toolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.toolStripMenuItem.Text = "Print";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // _pnlMain
            // 
            this._pnlMain.Controls.Add(this._pnlFeatureView);
            this._pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMain.Location = new System.Drawing.Point(200, 0);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(1400, 750);
            this._pnlMain.TabIndex = 3;
            // 
            // _pnlFeatureView
            // 
            this._pnlFeatureView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlFeatureView.Location = new System.Drawing.Point(0, 0);
            this._pnlFeatureView.Name = "_pnlFeatureView";
            this._pnlFeatureView.Size = new System.Drawing.Size(1400, 750);
            this._pnlFeatureView.TabIndex = 0;
            // 
            // _ctlNav
            // 
            this._ctlNav.BackColor = System.Drawing.SystemColors.ControlLight;
            this._ctlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this._ctlNav.Location = new System.Drawing.Point(0, 0);
            this._ctlNav.Name = "_ctlNav";
            this._ctlNav.Size = new System.Drawing.Size(200, 865);
            this._ctlNav.TabIndex = 2;
            this._ctlNav.Load += this._ctlNav_Load;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this._pnlMain);
            this.Controls.Add(this.bottomMenuPanel);
            this.Controls.Add(this._ctlNav);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Harmony Helper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bottomMenuPanel.ResumeLayout(false);
            this.bottomMenuPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this._pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomMenuPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Panel _pnlMain;
        private NavPanelControl _ctlNav;
        private System.Windows.Forms.Panel _pnlFeatureView;
    }
}


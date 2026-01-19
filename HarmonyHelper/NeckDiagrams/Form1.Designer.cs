
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
            bottomMenuPanel = new System.Windows.Forms.Panel();
            menuStrip = new System.Windows.Forms.MenuStrip();
            toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            printDialog = new System.Windows.Forms.PrintDialog();
            printDocument = new System.Drawing.Printing.PrintDocument();
            _pnlMain = new System.Windows.Forms.Panel();
            _pnlFeatureView = new System.Windows.Forms.Panel();
            _ctlNav = new NavPanelControl();
            bottomMenuPanel.SuspendLayout();
            menuStrip.SuspendLayout();
            _pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // bottomMenuPanel
            // 
            bottomMenuPanel.BackColor = System.Drawing.SystemColors.Control;
            bottomMenuPanel.Controls.Add(menuStrip);
            bottomMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomMenuPanel.Location = new System.Drawing.Point(200, 750);
            bottomMenuPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            bottomMenuPanel.Name = "bottomMenuPanel";
            bottomMenuPanel.Size = new System.Drawing.Size(1400, 115);
            bottomMenuPanel.TabIndex = 1;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            menuStrip.Size = new System.Drawing.Size(1400, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "File";
            // 
            // toolStripMenuItem
            // 
            toolStripMenuItem.Name = "toolStripMenuItem";
            toolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            toolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            toolStripMenuItem.Text = "Print";
            // 
            // printDialog
            // 
            printDialog.UseEXDialog = true;
            // 
            // _pnlMain
            // 
            _pnlMain.Controls.Add(_pnlFeatureView);
            _pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            _pnlMain.Location = new System.Drawing.Point(200, 0);
            _pnlMain.Name = "_pnlMain";
            _pnlMain.Size = new System.Drawing.Size(1400, 750);
            _pnlMain.TabIndex = 3;
            // 
            // _pnlFeatureView
            // 
            _pnlFeatureView.BackColor = System.Drawing.Color.Turquoise;
            _pnlFeatureView.Dock = System.Windows.Forms.DockStyle.Fill;
            _pnlFeatureView.Location = new System.Drawing.Point(0, 0);
            _pnlFeatureView.Name = "_pnlFeatureView";
            _pnlFeatureView.Size = new System.Drawing.Size(1400, 750);
            _pnlFeatureView.TabIndex = 0;
            // 
            // _ctlNav
            // 
            _ctlNav.BackColor = System.Drawing.SystemColors.ControlLight;
            _ctlNav.Dock = System.Windows.Forms.DockStyle.Left;
            _ctlNav.Location = new System.Drawing.Point(0, 0);
            _ctlNav.Name = "_ctlNav";
            _ctlNav.Size = new System.Drawing.Size(200, 865);
            _ctlNav.TabIndex = 2;
            _ctlNav.Load += _ctlNav_Load;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1600, 865);
            Controls.Add(_pnlMain);
            Controls.Add(bottomMenuPanel);
            Controls.Add(_ctlNav);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Harmony Helper";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            bottomMenuPanel.ResumeLayout(false);
            bottomMenuPanel.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            _pnlMain.ResumeLayout(false);
            ResumeLayout(false);

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


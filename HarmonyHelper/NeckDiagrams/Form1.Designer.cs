
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
            _pnlNav = new System.Windows.Forms.Panel();
            _bnModalInterchange = new System.Windows.Forms.RadioButton();
            _rbScore = new System.Windows.Forms.RadioButton();
            _rbManufaktura = new System.Windows.Forms.RadioButton();
            _bnFeatureVoiceLeading = new System.Windows.Forms.RadioButton();
            _bnFeatureScales = new System.Windows.Forms.RadioButton();
            _bnFeatureReHarmonize = new System.Windows.Forms.RadioButton();
            _bnFeatureLeadSheets = new System.Windows.Forms.RadioButton();
            _bnFeatureHarmonicAnalysis = new System.Windows.Forms.RadioButton();
            _bnFeatureArpeggiator = new System.Windows.Forms.RadioButton();
            _bnFeatureArpeggios = new System.Windows.Forms.RadioButton();
            _pnlMain = new System.Windows.Forms.Panel();
            bottomMenuPanel.SuspendLayout();
            menuStrip.SuspendLayout();
            _pnlNav.SuspendLayout();
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
            toolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            toolStripMenuItem.Text = "Print";
            // 
            // printDialog
            // 
            printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            printDocument.BeginPrint += printDocument1_BeginPrint;
            printDocument.EndPrint += printDocument1_EndPrint;
            printDocument.PrintPage += printDocument1_PrintPage;
            printDocument.QueryPageSettings += printDocument1_QueryPageSettings;
            // 
            // _pnlNav
            // 
            _pnlNav.BackColor = System.Drawing.SystemColors.ControlLight;
            _pnlNav.Controls.Add(_bnModalInterchange);
            _pnlNav.Controls.Add(_rbScore);
            _pnlNav.Controls.Add(_rbManufaktura);
            _pnlNav.Controls.Add(_bnFeatureVoiceLeading);
            _pnlNav.Controls.Add(_bnFeatureScales);
            _pnlNav.Controls.Add(_bnFeatureReHarmonize);
            _pnlNav.Controls.Add(_bnFeatureLeadSheets);
            _pnlNav.Controls.Add(_bnFeatureHarmonicAnalysis);
            _pnlNav.Controls.Add(_bnFeatureArpeggiator);
            _pnlNav.Controls.Add(_bnFeatureArpeggios);
            _pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            _pnlNav.Location = new System.Drawing.Point(0, 0);
            _pnlNav.Name = "_pnlNav";
            _pnlNav.Size = new System.Drawing.Size(200, 865);
            _pnlNav.TabIndex = 2;
            // 
            // _bnModalInterchange
            // 
            _bnModalInterchange.Appearance = System.Windows.Forms.Appearance.Button;
            _bnModalInterchange.AutoSize = true;
            _bnModalInterchange.Dock = System.Windows.Forms.DockStyle.Top;
            _bnModalInterchange.Location = new System.Drawing.Point(0, 270);
            _bnModalInterchange.Name = "_bnModalInterchange";
            _bnModalInterchange.Size = new System.Drawing.Size(200, 30);
            _bnModalInterchange.TabIndex = 9;
            _bnModalInterchange.Text = "Modal Interchange";
            _bnModalInterchange.UseVisualStyleBackColor = true;
            _bnModalInterchange.CheckedChanged += _bnModalInterchange_CheckedChanged;
            // 
            // _rbScore
            // 
            _rbScore.Appearance = System.Windows.Forms.Appearance.Button;
            _rbScore.AutoSize = true;
            _rbScore.Dock = System.Windows.Forms.DockStyle.Top;
            _rbScore.Location = new System.Drawing.Point(0, 240);
            _rbScore.Name = "_rbScore";
            _rbScore.Size = new System.Drawing.Size(200, 30);
            _rbScore.TabIndex = 8;
            _rbScore.TabStop = true;
            _rbScore.Text = "Score";
            _rbScore.UseVisualStyleBackColor = true;
            _rbScore.CheckedChanged += _rbScore_CheckedChanged;
            // 
            // _rbManufaktura
            // 
            _rbManufaktura.Appearance = System.Windows.Forms.Appearance.Button;
            _rbManufaktura.AutoSize = true;
            _rbManufaktura.Dock = System.Windows.Forms.DockStyle.Top;
            _rbManufaktura.Location = new System.Drawing.Point(0, 210);
            _rbManufaktura.Name = "_rbManufaktura";
            _rbManufaktura.Size = new System.Drawing.Size(200, 30);
            _rbManufaktura.TabIndex = 7;
            _rbManufaktura.Text = "Manufaktura";
            _rbManufaktura.UseVisualStyleBackColor = true;
            _rbManufaktura.CheckedChanged += _rbManufaktura_CheckedChanged;
            // 
            // _bnFeatureVoiceLeading
            // 
            _bnFeatureVoiceLeading.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureVoiceLeading.AutoSize = true;
            _bnFeatureVoiceLeading.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureVoiceLeading.Location = new System.Drawing.Point(0, 180);
            _bnFeatureVoiceLeading.Name = "_bnFeatureVoiceLeading";
            _bnFeatureVoiceLeading.Size = new System.Drawing.Size(200, 30);
            _bnFeatureVoiceLeading.TabIndex = 6;
            _bnFeatureVoiceLeading.Text = "Voice Leading";
            _bnFeatureVoiceLeading.UseVisualStyleBackColor = true;
            _bnFeatureVoiceLeading.CheckedChanged += _bnFeatureVoiceLeading_CheckedChanged;
            // 
            // _bnFeatureScales
            // 
            _bnFeatureScales.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureScales.AutoSize = true;
            _bnFeatureScales.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureScales.Location = new System.Drawing.Point(0, 150);
            _bnFeatureScales.Name = "_bnFeatureScales";
            _bnFeatureScales.Size = new System.Drawing.Size(200, 30);
            _bnFeatureScales.TabIndex = 0;
            _bnFeatureScales.Text = "Scales";
            _bnFeatureScales.UseVisualStyleBackColor = true;
            _bnFeatureScales.CheckedChanged += _bnFeatureScales_CheckedChanged;
            // 
            // _bnFeatureReHarmonize
            // 
            _bnFeatureReHarmonize.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureReHarmonize.AutoSize = true;
            _bnFeatureReHarmonize.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureReHarmonize.Location = new System.Drawing.Point(0, 120);
            _bnFeatureReHarmonize.Name = "_bnFeatureReHarmonize";
            _bnFeatureReHarmonize.Size = new System.Drawing.Size(200, 30);
            _bnFeatureReHarmonize.TabIndex = 3;
            _bnFeatureReHarmonize.Text = "Re-Harmonize";
            _bnFeatureReHarmonize.UseVisualStyleBackColor = true;
            _bnFeatureReHarmonize.CheckedChanged += _bnFeatureReHarmonize_CheckedChanged;
            // 
            // _bnFeatureLeadSheets
            // 
            _bnFeatureLeadSheets.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureLeadSheets.AutoSize = true;
            _bnFeatureLeadSheets.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureLeadSheets.Location = new System.Drawing.Point(0, 90);
            _bnFeatureLeadSheets.Name = "_bnFeatureLeadSheets";
            _bnFeatureLeadSheets.Size = new System.Drawing.Size(200, 30);
            _bnFeatureLeadSheets.TabIndex = 5;
            _bnFeatureLeadSheets.Text = "Lead Sheets";
            _bnFeatureLeadSheets.UseVisualStyleBackColor = true;
            _bnFeatureLeadSheets.CheckedChanged += _bnFeatureLeadSheets_CheckedChanged;
            // 
            // _bnFeatureHarmonicAnalysis
            // 
            _bnFeatureHarmonicAnalysis.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureHarmonicAnalysis.AutoSize = true;
            _bnFeatureHarmonicAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureHarmonicAnalysis.Location = new System.Drawing.Point(0, 60);
            _bnFeatureHarmonicAnalysis.Name = "_bnFeatureHarmonicAnalysis";
            _bnFeatureHarmonicAnalysis.Size = new System.Drawing.Size(200, 30);
            _bnFeatureHarmonicAnalysis.TabIndex = 2;
            _bnFeatureHarmonicAnalysis.Text = "Harmonic Analysis";
            _bnFeatureHarmonicAnalysis.UseVisualStyleBackColor = true;
            _bnFeatureHarmonicAnalysis.CheckedChanged += _bnFeatureHarmonicAnalysis_CheckedChanged;
            // 
            // _bnFeatureArpeggiator
            // 
            _bnFeatureArpeggiator.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureArpeggiator.AutoSize = true;
            _bnFeatureArpeggiator.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureArpeggiator.Location = new System.Drawing.Point(0, 30);
            _bnFeatureArpeggiator.Name = "_bnFeatureArpeggiator";
            _bnFeatureArpeggiator.Size = new System.Drawing.Size(200, 30);
            _bnFeatureArpeggiator.TabIndex = 4;
            _bnFeatureArpeggiator.Text = "Arpeggiator";
            _bnFeatureArpeggiator.UseVisualStyleBackColor = true;
            _bnFeatureArpeggiator.CheckedChanged += _bnFeatureArpeggiator_CheckedChanged;
            // 
            // _bnFeatureArpeggios
            // 
            _bnFeatureArpeggios.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureArpeggios.AutoSize = true;
            _bnFeatureArpeggios.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureArpeggios.Location = new System.Drawing.Point(0, 0);
            _bnFeatureArpeggios.Name = "_bnFeatureArpeggios";
            _bnFeatureArpeggios.Size = new System.Drawing.Size(200, 30);
            _bnFeatureArpeggios.TabIndex = 1;
            _bnFeatureArpeggios.Text = "Argeggios";
            _bnFeatureArpeggios.UseVisualStyleBackColor = true;
            _bnFeatureArpeggios.CheckedChanged += _bnFeatureArpeggios_CheckedChanged;
            // 
            // _pnlMain
            // 
            _pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            _pnlMain.Location = new System.Drawing.Point(200, 0);
            _pnlMain.Name = "_pnlMain";
            _pnlMain.Size = new System.Drawing.Size(1400, 750);
            _pnlMain.TabIndex = 3;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1600, 865);
            Controls.Add(_pnlMain);
            Controls.Add(bottomMenuPanel);
            Controls.Add(_pnlNav);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Harmony Helper";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            KeyUp += Form1_KeyUp;
            PreviewKeyDown += Form1_PreviewKeyDown;
            bottomMenuPanel.ResumeLayout(false);
            bottomMenuPanel.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            _pnlNav.ResumeLayout(false);
            _pnlNav.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton _rbScore;
        private System.Windows.Forms.RadioButton _bnModalInterchange;
    }
}


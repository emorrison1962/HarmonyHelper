using NeckDiagrams.Controls.Buttons;
using NeckDiagrams.Controls.ComboBoxes;

namespace NeckDiagrams.Controls
{
    partial class NavPanelControl
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
            this._pnlNav = new System.Windows.Forms.Panel();
            this.bnOptions = new System.Windows.Forms.Button();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this._bnSandbox = new FeatureTypeButton();
            this._bnSquareOfStitch = new FeatureTypeButton();
            this._bnFeatureChordShape = new FeatureTypeButton();
            this._bnModalInterchange = new FeatureTypeButton();
            this._bnFeatureVoiceLeading = new FeatureTypeButton();
            this._bnFeatureScales = new FeatureTypeButton();
            this._bnFeatureReHarmonize = new FeatureTypeButton();
            this._bnFeatureLeadSheets = new FeatureTypeButton();
            this._bnFeatureHarmonicAnalysis = new FeatureTypeButton();
            this._bnFeatureArpeggios = new FeatureTypeButton();
            this._pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlNav
            // 
            this._pnlNav.BackColor = System.Drawing.SystemColors.ControlLight;
            this._pnlNav.Controls.Add(this.bnOptions);
            this._pnlNav.Controls.Add(this.pnlSpacer);
            this._pnlNav.Controls.Add(this._bnSandbox);
            this._pnlNav.Controls.Add(this._bnSquareOfStitch);
            this._pnlNav.Controls.Add(this._bnFeatureChordShape);
            this._pnlNav.Controls.Add(this._bnModalInterchange);
            this._pnlNav.Controls.Add(this._bnFeatureVoiceLeading);
            this._pnlNav.Controls.Add(this._bnFeatureScales);
            this._pnlNav.Controls.Add(this._bnFeatureReHarmonize);
            this._pnlNav.Controls.Add(this._bnFeatureLeadSheets);
            this._pnlNav.Controls.Add(this._bnFeatureHarmonicAnalysis);
            this._pnlNav.Controls.Add(this._bnFeatureArpeggios);
            this._pnlNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlNav.Location = new System.Drawing.Point(0, 0);
            this._pnlNav.Name = "_pnlNav";
            this._pnlNav.Size = new System.Drawing.Size(468, 1039);
            this._pnlNav.TabIndex = 3;
            // 
            // bnOptions
            // 
            this.bnOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.bnOptions.Location = new System.Drawing.Point(0, 400);
            this.bnOptions.Name = "bnOptions";
            this.bnOptions.Size = new System.Drawing.Size(468, 30);
            this.bnOptions.TabIndex = 13;
            this.bnOptions.Text = "Options...";
            this.bnOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnOptions.UseVisualStyleBackColor = true;
            this.bnOptions.Click += this.bnOptions_Click;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpacer.Location = new System.Drawing.Point(0, 300);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(468, 100);
            this.pnlSpacer.TabIndex = 12;
            // 
            // _bnSandbox
            // 
            this._bnSandbox.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnSandbox.AutoSize = true;
            this._bnSandbox.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnSandbox.FeatureType = FeatureType.SandBox;
            this._bnSandbox.Location = new System.Drawing.Point(0, 270);
            this._bnSandbox.Name = "_bnSandbox";
            this._bnSandbox.Size = new System.Drawing.Size(468, 30);
            this._bnSandbox.TabIndex = 14;
            this._bnSandbox.TabStop = true;
            this._bnSandbox.Tag = "";
            this._bnSandbox.Text = "SandBox";
            this._bnSandbox.UseVisualStyleBackColor = true;
            // 
            // _bnSquareOfStitch
            // 
            this._bnSquareOfStitch.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnSquareOfStitch.AutoSize = true;
            this._bnSquareOfStitch.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnSquareOfStitch.FeatureType = FeatureType.SquareOfStitch;
            this._bnSquareOfStitch.Location = new System.Drawing.Point(0, 240);
            this._bnSquareOfStitch.Name = "_bnSquareOfStitch";
            this._bnSquareOfStitch.Size = new System.Drawing.Size(468, 30);
            this._bnSquareOfStitch.TabIndex = 10;
            this._bnSquareOfStitch.TabStop = true;
            this._bnSquareOfStitch.Tag = "";
            this._bnSquareOfStitch.Text = "Square Of Stitch";
            this._bnSquareOfStitch.UseVisualStyleBackColor = true;
            // 
            // _bnFeatureChordShape
            // 
            this._bnFeatureChordShape.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureChordShape.AutoSize = true;
            this._bnFeatureChordShape.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureChordShape.FeatureType = FeatureType.ChordFingering;
            this._bnFeatureChordShape.Location = new System.Drawing.Point(0, 210);
            this._bnFeatureChordShape.Name = "_bnFeatureChordShape";
            this._bnFeatureChordShape.Size = new System.Drawing.Size(468, 30);
            this._bnFeatureChordShape.TabIndex = 11;
            this._bnFeatureChordShape.TabStop = true;
            this._bnFeatureChordShape.Tag = "";
            this._bnFeatureChordShape.Text = "Chord Shapes";
            this._bnFeatureChordShape.UseVisualStyleBackColor = true;
            // 
            // _bnModalInterchange
            // 
            this._bnModalInterchange.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnModalInterchange.AutoSize = true;
            this._bnModalInterchange.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnModalInterchange.FeatureType = FeatureType.ModalInterchange;
            this._bnModalInterchange.Location = new System.Drawing.Point(0, 180);
            this._bnModalInterchange.Name = "_bnModalInterchange";
            this._bnModalInterchange.Size = new System.Drawing.Size(468, 30);
            this._bnModalInterchange.TabIndex = 9;
            this._bnModalInterchange.Text = "Modal Interchange";
            this._bnModalInterchange.UseVisualStyleBackColor = true;
            // 
            // _bnFeatureVoiceLeading
            // 
            this._bnFeatureVoiceLeading.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureVoiceLeading.AutoSize = true;
            this._bnFeatureVoiceLeading.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureVoiceLeading.FeatureType = FeatureType.VoiceLeading;
            this._bnFeatureVoiceLeading.Location = new System.Drawing.Point(0, 150);
            this._bnFeatureVoiceLeading.Name = "_bnFeatureVoiceLeading";
            this._bnFeatureVoiceLeading.Size = new System.Drawing.Size(468, 30);
            this._bnFeatureVoiceLeading.TabIndex = 6;
            this._bnFeatureVoiceLeading.Text = "Voice Leading";
            this._bnFeatureVoiceLeading.UseVisualStyleBackColor = true;
            // 
            // _bnFeatureScales
            // 
            this._bnFeatureScales.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureScales.AutoSize = true;
            this._bnFeatureScales.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureScales.FeatureType = FeatureType.Scales;
            this._bnFeatureScales.Location = new System.Drawing.Point(0, 120);
            this._bnFeatureScales.Name = "_bnFeatureScales";
            this._bnFeatureScales.Size = new System.Drawing.Size(468, 30);
            this._bnFeatureScales.TabIndex = 0;
            this._bnFeatureScales.Text = "Scales";
            this._bnFeatureScales.UseVisualStyleBackColor = true;
            // 
            // _bnFeatureReHarmonize
            // 
            this._bnFeatureReHarmonize.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureReHarmonize.AutoSize = true;
            this._bnFeatureReHarmonize.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureReHarmonize.FeatureType = FeatureType.ReHarmonize;
            this._bnFeatureReHarmonize.Location = new System.Drawing.Point(0, 90);
            this._bnFeatureReHarmonize.Name = "_bnFeatureReHarmonize";
            this._bnFeatureReHarmonize.Size = new System.Drawing.Size(468, 30);
            this._bnFeatureReHarmonize.TabIndex = 3;
            this._bnFeatureReHarmonize.Text = "Re-Harmonize";
            this._bnFeatureReHarmonize.UseVisualStyleBackColor = true;
            // 
            // _bnFeatureLeadSheets
            // 
            this._bnFeatureLeadSheets.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureLeadSheets.AutoSize = true;
            this._bnFeatureLeadSheets.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureLeadSheets.FeatureType = FeatureType.LeadSheets;
            this._bnFeatureLeadSheets.Location = new System.Drawing.Point(0, 60);
            this._bnFeatureLeadSheets.Name = "_bnFeatureLeadSheets";
            this._bnFeatureLeadSheets.Size = new System.Drawing.Size(468, 30);
            this._bnFeatureLeadSheets.TabIndex = 5;
            this._bnFeatureLeadSheets.Text = "Lead Sheets";
            this._bnFeatureLeadSheets.UseVisualStyleBackColor = true;
            // 
            // _bnFeatureHarmonicAnalysis
            // 
            this._bnFeatureHarmonicAnalysis.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureHarmonicAnalysis.AutoSize = true;
            this._bnFeatureHarmonicAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureHarmonicAnalysis.FeatureType = FeatureType.HarmonicAnalysis;
            this._bnFeatureHarmonicAnalysis.Location = new System.Drawing.Point(0, 30);
            this._bnFeatureHarmonicAnalysis.Name = "_bnFeatureHarmonicAnalysis";
            this._bnFeatureHarmonicAnalysis.Size = new System.Drawing.Size(468, 30);
            this._bnFeatureHarmonicAnalysis.TabIndex = 2;
            this._bnFeatureHarmonicAnalysis.Text = "Harmonic Analysis";
            this._bnFeatureHarmonicAnalysis.UseVisualStyleBackColor = true;
            // 
            // _bnFeatureArpeggios
            // 
            this._bnFeatureArpeggios.Appearance = System.Windows.Forms.Appearance.Button;
            this._bnFeatureArpeggios.AutoSize = true;
            this._bnFeatureArpeggios.Dock = System.Windows.Forms.DockStyle.Top;
            this._bnFeatureArpeggios.FeatureType = FeatureType.Arpeggios;
            this._bnFeatureArpeggios.Location = new System.Drawing.Point(0, 0);
            this._bnFeatureArpeggios.Name = "_bnFeatureArpeggios";
            this._bnFeatureArpeggios.Size = new System.Drawing.Size(468, 30);
            this._bnFeatureArpeggios.TabIndex = 1;
            this._bnFeatureArpeggios.Text = "Argeggios";
            this._bnFeatureArpeggios.UseVisualStyleBackColor = true;
            // 
            // NavPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pnlNav);
            this.Name = "NavPanelControl";
            this.Size = new System.Drawing.Size(468, 1039);
            this._pnlNav.ResumeLayout(false);
            this._pnlNav.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlNav;
        private FeatureTypeButton _bnModalInterchange;
        private FeatureTypeButton _bnFeatureVoiceLeading;
        private FeatureTypeButton _bnFeatureScales;
        private FeatureTypeButton _bnFeatureReHarmonize;
        private FeatureTypeButton _bnFeatureLeadSheets;
        private FeatureTypeButton _bnFeatureHarmonicAnalysis;
        private FeatureTypeButton _bnFeatureArpeggios;
        private FeatureTypeButton _bnFeatureChordShape;
        private System.Windows.Forms.Button bnOptions;
        private System.Windows.Forms.Panel pnlSpacer;
        private FeatureTypeButton _bnSquareOfStitch;
        private FeatureTypeButton _bnSandbox;
    }
}

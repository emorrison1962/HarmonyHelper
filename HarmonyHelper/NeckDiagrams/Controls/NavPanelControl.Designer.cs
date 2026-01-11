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
            _pnlNav = new System.Windows.Forms.Panel();
            _bnFeatureChordShape = new FeatureTypeButton(FeatureType.ChordFingering);
            _bnModalInterchange = new FeatureTypeButton(FeatureType.ModalInterchange);
            _rbManufaktura = new FeatureTypeButton(FeatureType.Manufaktura);
            _bnFeatureVoiceLeading = new FeatureTypeButton(FeatureType.VoiceLeading);
            _bnFeatureScales = new FeatureTypeButton(FeatureType.Scales);
            _bnFeatureReHarmonize = new FeatureTypeButton(FeatureType.ReHarmonize);
            _bnFeatureLeadSheets = new FeatureTypeButton(FeatureType.LeadSheets);
            _bnFeatureHarmonicAnalysis = new FeatureTypeButton(FeatureType.HarmonicAnalysis);
            _bnFeatureArpeggiator = new FeatureTypeButton(FeatureType.Arpeggiator);
            _bnFeatureArpeggios = new FeatureTypeButton(FeatureType.Arpeggios);
            _pnlNav.SuspendLayout();
            SuspendLayout();
            // 
            // _pnlNav
            // 
            _pnlNav.BackColor = System.Drawing.SystemColors.ControlLight;
            _pnlNav.Controls.Add(_bnFeatureChordShape);
            _pnlNav.Controls.Add(_bnModalInterchange);
            _pnlNav.Controls.Add(_rbManufaktura);
            _pnlNav.Controls.Add(_bnFeatureVoiceLeading);
            _pnlNav.Controls.Add(_bnFeatureScales);
            _pnlNav.Controls.Add(_bnFeatureReHarmonize);
            _pnlNav.Controls.Add(_bnFeatureLeadSheets);
            _pnlNav.Controls.Add(_bnFeatureHarmonicAnalysis);
            _pnlNav.Controls.Add(_bnFeatureArpeggiator);
            _pnlNav.Controls.Add(_bnFeatureArpeggios);
            _pnlNav.Dock = System.Windows.Forms.DockStyle.Fill;
            _pnlNav.Location = new System.Drawing.Point(0, 0);
            _pnlNav.Name = "_pnlNav";
            _pnlNav.Size = new System.Drawing.Size(468, 1039);
            _pnlNav.TabIndex = 3;
            // 
            // _bnFeatureChordShape
            // 
            _bnFeatureChordShape.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureChordShape.AutoSize = true;
            _bnFeatureChordShape.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureChordShape.Location = new System.Drawing.Point(0, 300);
            _bnFeatureChordShape.Name = "_bnFeatureChordShape";
            _bnFeatureChordShape.Size = new System.Drawing.Size(468, 30);
            _bnFeatureChordShape.TabIndex = 10;
            _bnFeatureChordShape.Tag = "";
            _bnFeatureChordShape.Text = "Chord Shapes";
            _bnFeatureChordShape.UseVisualStyleBackColor = true;
            _bnFeatureChordShape.CheckedChanged += _CheckedChanged;
            // 
            // _bnModalInterchange
            // 
            _bnModalInterchange.Appearance = System.Windows.Forms.Appearance.Button;
            _bnModalInterchange.AutoSize = true;
            _bnModalInterchange.Dock = System.Windows.Forms.DockStyle.Top;
            _bnModalInterchange.Location = new System.Drawing.Point(0, 270);
            _bnModalInterchange.Name = "_bnModalInterchange";
            _bnModalInterchange.Size = new System.Drawing.Size(468, 30);
            _bnModalInterchange.TabIndex = 9;
            _bnModalInterchange.Text = "Modal Interchange";
            _bnModalInterchange.UseVisualStyleBackColor = true;
            _bnModalInterchange.CheckedChanged += _CheckedChanged;
            // 
            // _rbManufaktura
            // 
            _rbManufaktura.Appearance = System.Windows.Forms.Appearance.Button;
            _rbManufaktura.AutoSize = true;
            _rbManufaktura.Dock = System.Windows.Forms.DockStyle.Top;
            _rbManufaktura.Location = new System.Drawing.Point(0, 210);
            _rbManufaktura.Name = "_rbManufaktura";
            _rbManufaktura.Size = new System.Drawing.Size(468, 30);
            _rbManufaktura.TabIndex = 7;
            _rbManufaktura.Text = "Manufaktura";
            _rbManufaktura.UseVisualStyleBackColor = true;
            _rbManufaktura.CheckedChanged += _CheckedChanged;
            // 
            // _bnFeatureVoiceLeading
            // 
            _bnFeatureVoiceLeading.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureVoiceLeading.AutoSize = true;
            _bnFeatureVoiceLeading.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureVoiceLeading.Location = new System.Drawing.Point(0, 180);
            _bnFeatureVoiceLeading.Name = "_bnFeatureVoiceLeading";
            _bnFeatureVoiceLeading.Size = new System.Drawing.Size(468, 30);
            _bnFeatureVoiceLeading.TabIndex = 6;
            _bnFeatureVoiceLeading.Text = "Voice Leading";
            _bnFeatureVoiceLeading.UseVisualStyleBackColor = true;
            _bnFeatureVoiceLeading.CheckedChanged += _CheckedChanged;
            // 
            // _bnFeatureScales
            // 
            _bnFeatureScales.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureScales.AutoSize = true;
            _bnFeatureScales.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureScales.Location = new System.Drawing.Point(0, 150);
            _bnFeatureScales.Name = "_bnFeatureScales";
            _bnFeatureScales.Size = new System.Drawing.Size(468, 30);
            _bnFeatureScales.TabIndex = 0;
            _bnFeatureScales.Text = "Scales";
            _bnFeatureScales.UseVisualStyleBackColor = true;
            _bnFeatureScales.CheckedChanged += _CheckedChanged;
            // 
            // _bnFeatureReHarmonize
            // 
            _bnFeatureReHarmonize.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureReHarmonize.AutoSize = true;
            _bnFeatureReHarmonize.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureReHarmonize.Location = new System.Drawing.Point(0, 120);
            _bnFeatureReHarmonize.Name = "_bnFeatureReHarmonize";
            _bnFeatureReHarmonize.Size = new System.Drawing.Size(468, 30);
            _bnFeatureReHarmonize.TabIndex = 3;
            _bnFeatureReHarmonize.Text = "Re-Harmonize";
            _bnFeatureReHarmonize.UseVisualStyleBackColor = true;
            _bnFeatureReHarmonize.CheckedChanged += _CheckedChanged;
            // 
            // _bnFeatureLeadSheets
            // 
            _bnFeatureLeadSheets.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureLeadSheets.AutoSize = true;
            _bnFeatureLeadSheets.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureLeadSheets.Location = new System.Drawing.Point(0, 90);
            _bnFeatureLeadSheets.Name = "_bnFeatureLeadSheets";
            _bnFeatureLeadSheets.Size = new System.Drawing.Size(468, 30);
            _bnFeatureLeadSheets.TabIndex = 5;
            _bnFeatureLeadSheets.Text = "Lead Sheets";
            _bnFeatureLeadSheets.UseVisualStyleBackColor = true;
            _bnFeatureLeadSheets.CheckedChanged += _CheckedChanged;
            // 
            // _bnFeatureHarmonicAnalysis
            // 
            _bnFeatureHarmonicAnalysis.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureHarmonicAnalysis.AutoSize = true;
            _bnFeatureHarmonicAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureHarmonicAnalysis.Location = new System.Drawing.Point(0, 60);
            _bnFeatureHarmonicAnalysis.Name = "_bnFeatureHarmonicAnalysis";
            _bnFeatureHarmonicAnalysis.Size = new System.Drawing.Size(468, 30);
            _bnFeatureHarmonicAnalysis.TabIndex = 2;
            _bnFeatureHarmonicAnalysis.Text = "Harmonic Analysis";
            _bnFeatureHarmonicAnalysis.UseVisualStyleBackColor = true;
            _bnFeatureHarmonicAnalysis.CheckedChanged += _CheckedChanged;
            // 
            // _bnFeatureArpeggiator
            // 
            _bnFeatureArpeggiator.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureArpeggiator.AutoSize = true;
            _bnFeatureArpeggiator.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureArpeggiator.Location = new System.Drawing.Point(0, 30);
            _bnFeatureArpeggiator.Name = "_bnFeatureArpeggiator";
            _bnFeatureArpeggiator.Size = new System.Drawing.Size(468, 30);
            _bnFeatureArpeggiator.TabIndex = 4;
            _bnFeatureArpeggiator.Text = "Arpeggiator";
            _bnFeatureArpeggiator.UseVisualStyleBackColor = true;
            _bnFeatureArpeggiator.CheckedChanged += _CheckedChanged;
            // 
            // _bnFeatureArpeggios
            // 
            _bnFeatureArpeggios.Appearance = System.Windows.Forms.Appearance.Button;
            _bnFeatureArpeggios.AutoSize = true;
            _bnFeatureArpeggios.Dock = System.Windows.Forms.DockStyle.Top;
            _bnFeatureArpeggios.Location = new System.Drawing.Point(0, 0);
            _bnFeatureArpeggios.Name = "_bnFeatureArpeggios";
            _bnFeatureArpeggios.Size = new System.Drawing.Size(468, 30);
            _bnFeatureArpeggios.TabIndex = 1;
            _bnFeatureArpeggios.Text = "Argeggios";
            _bnFeatureArpeggios.UseVisualStyleBackColor = true;
            _bnFeatureArpeggios.CheckedChanged += _CheckedChanged;
            // 
            // NavPanelControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_pnlNav);
            Name = "NavPanelControl";
            Size = new System.Drawing.Size(468, 1039);
            _pnlNav.ResumeLayout(false);
            _pnlNav.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlNav;
        private FeatureTypeButton _bnModalInterchange;
        private FeatureTypeButton _rbManufaktura;
        private FeatureTypeButton _bnFeatureVoiceLeading;
        private FeatureTypeButton _bnFeatureScales;
        private FeatureTypeButton _bnFeatureReHarmonize;
        private FeatureTypeButton _bnFeatureLeadSheets;
        private FeatureTypeButton _bnFeatureHarmonicAnalysis;
        private FeatureTypeButton _bnFeatureArpeggiator;
        private FeatureTypeButton _bnFeatureArpeggios;
        private FeatureTypeButton _bnFeatureChordShape;

        
    }
}

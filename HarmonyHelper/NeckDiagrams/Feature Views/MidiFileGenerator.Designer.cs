namespace NeckDiagrams.Feature_Views
{
    partial class MidiFileGenerator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._bnSave = new System.Windows.Forms.Button();
            this._tbChords = new System.Windows.Forms.TextBox();
            this._pnlParsed = new System.Windows.Forms.Panel();
            this._chordNamesControl = new NeckDiagrams.Controls.ChordNamesControl();
            this.panel1.SuspendLayout();
            this._pnlParsed.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._bnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 100);
            this.panel1.TabIndex = 0;
            // 
            // _bnSave
            // 
            this._bnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._bnSave.Location = new System.Drawing.Point(1224, 42);
            this._bnSave.Name = "_bnSave";
            this._bnSave.Size = new System.Drawing.Size(75, 23);
            this._bnSave.TabIndex = 0;
            this._bnSave.Text = "Save";
            this._bnSave.UseVisualStyleBackColor = true;
            this._bnSave.Click += this._bnSave_Click;
            // 
            // _tbChords
            // 
            this._tbChords.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbChords.Location = new System.Drawing.Point(0, 0);
            this._tbChords.Multiline = true;
            this._tbChords.Name = "_tbChords";
            this._tbChords.Size = new System.Drawing.Size(1302, 120);
            this._tbChords.TabIndex = 1;
            this._tbChords.KeyPress += this._tbChords_KeyPress;
            // 
            // _pnlParsed
            // 
            this._pnlParsed.Controls.Add(this._chordNamesControl);
            this._pnlParsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlParsed.Location = new System.Drawing.Point(0, 120);
            this._pnlParsed.Name = "_pnlParsed";
            this._pnlParsed.Size = new System.Drawing.Size(1302, 364);
            this._pnlParsed.TabIndex = 2;
            // 
            // _chordNamesControl
            // 
            this._chordNamesControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._chordNamesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chordNamesControl.Location = new System.Drawing.Point(0, 0);
            this._chordNamesControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chordNamesControl.Name = "_chordNamesControl";
            this._chordNamesControl.Size = new System.Drawing.Size(1302, 364);
            this._chordNamesControl.TabIndex = 5;
            // 
            // MidiFileGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._pnlParsed);
            this.Controls.Add(this._tbChords);
            this.Controls.Add(this.panel1);
            this.Name = "MidiFileGenerator";
            this.Size = new System.Drawing.Size(1302, 584);
            this.KeyPress += this.MidiFileGenerator_KeyPress;
            this.panel1.ResumeLayout(false);
            this._pnlParsed.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _bnSave;
        private System.Windows.Forms.TextBox _tbChords;
        private System.Windows.Forms.Panel _pnlParsed;
        private Controls.ChordNamesControl _chordNamesControl;
    }
}

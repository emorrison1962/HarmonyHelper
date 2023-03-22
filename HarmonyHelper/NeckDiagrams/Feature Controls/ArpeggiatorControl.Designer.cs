namespace NeckDiagrams.Controls
{
    partial class ArpeggiatorControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this._cbUntilPatternRepeats = new System.Windows.Forms.CheckBox();
            this.groupDirection = new System.Windows.Forms.GroupBox();
            this._cbTemporaryReversal = new System.Windows.Forms.CheckBox();
            this._rbDescending = new System.Windows.Forms.RadioButton();
            this._rbAscending = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._numericNotesPerChord = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._numericNotesPerMeasure = new System.Windows.Forms.NumericUpDown();
            this._comboNeckPosition = new System.Windows.Forms.ComboBox();
            this._comboNoteRange = new System.Windows.Forms.ComboBox();
            this._bnChords = new System.Windows.Forms.Button();
            this.pnlSettings.SuspendLayout();
            this.groupDirection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericNotesPerChord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericNotesPerMeasure)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arpeggiator";
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this._cbUntilPatternRepeats);
            this.pnlSettings.Controls.Add(this.groupDirection);
            this.pnlSettings.Controls.Add(this.label4);
            this.pnlSettings.Controls.Add(this.label3);
            this.pnlSettings.Controls.Add(this._numericNotesPerChord);
            this.pnlSettings.Controls.Add(this.label2);
            this.pnlSettings.Controls.Add(this._numericNotesPerMeasure);
            this.pnlSettings.Controls.Add(this._comboNeckPosition);
            this.pnlSettings.Controls.Add(this._comboNoteRange);
            this.pnlSettings.Controls.Add(this._bnChords);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1454, 686);
            this.pnlSettings.TabIndex = 2;
            // 
            // _cbUntilPatternRepeats
            // 
            this._cbUntilPatternRepeats.AutoSize = true;
            this._cbUntilPatternRepeats.Location = new System.Drawing.Point(8, 218);
            this._cbUntilPatternRepeats.Name = "_cbUntilPatternRepeats";
            this._cbUntilPatternRepeats.Size = new System.Drawing.Size(290, 29);
            this._cbUntilPatternRepeats.TabIndex = 9;
            this._cbUntilPatternRepeats.Text = "Arpeggiate until pattern repeats";
            this._cbUntilPatternRepeats.UseVisualStyleBackColor = true;
            // 
            // groupDirection
            // 
            this.groupDirection.Controls.Add(this._cbTemporaryReversal);
            this.groupDirection.Controls.Add(this._rbDescending);
            this.groupDirection.Controls.Add(this._rbAscending);
            this.groupDirection.Location = new System.Drawing.Point(8, 270);
            this.groupDirection.Name = "groupDirection";
            this.groupDirection.Size = new System.Drawing.Size(369, 150);
            this.groupDirection.TabIndex = 8;
            this.groupDirection.TabStop = false;
            this.groupDirection.Text = "Direction";
            // 
            // _cbTemporaryReversal
            // 
            this._cbTemporaryReversal.AutoSize = true;
            this._cbTemporaryReversal.Location = new System.Drawing.Point(6, 104);
            this._cbTemporaryReversal.Name = "_cbTemporaryReversal";
            this._cbTemporaryReversal.Size = new System.Drawing.Size(363, 29);
            this._cbTemporaryReversal.TabIndex = 3;
            this._cbTemporaryReversal.Text = "Allow Temporay Reversal For Closer Note";
            this._cbTemporaryReversal.UseVisualStyleBackColor = true;
            // 
            // _rbDescending
            // 
            this._rbDescending.AutoSize = true;
            this._rbDescending.Location = new System.Drawing.Point(6, 69);
            this._rbDescending.Name = "_rbDescending";
            this._rbDescending.Size = new System.Drawing.Size(130, 29);
            this._rbDescending.TabIndex = 0;
            this._rbDescending.TabStop = true;
            this._rbDescending.Text = "Descending";
            this._rbDescending.UseVisualStyleBackColor = true;
            // 
            // _rbAscending
            // 
            this._rbAscending.AutoSize = true;
            this._rbAscending.Location = new System.Drawing.Point(6, 36);
            this._rbAscending.Name = "_rbAscending";
            this._rbAscending.Size = new System.Drawing.Size(120, 29);
            this._rbAscending.TabIndex = 0;
            this._rbAscending.TabStop = true;
            this._rbAscending.Text = "Ascending";
            this._rbAscending.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "notes per chord.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Play ";
            // 
            // _numericNotesPerChord
            // 
            this._numericNotesPerChord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._numericNotesPerChord.Location = new System.Drawing.Point(181, 165);
            this._numericNotesPerChord.Name = "_numericNotesPerChord";
            this._numericNotesPerChord.Size = new System.Drawing.Size(60, 27);
            this._numericNotesPerChord.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Notes per measure";
            // 
            // _numericNotesPerMeasure
            // 
            this._numericNotesPerMeasure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._numericNotesPerMeasure.Location = new System.Drawing.Point(181, 128);
            this._numericNotesPerMeasure.Name = "_numericNotesPerMeasure";
            this._numericNotesPerMeasure.Size = new System.Drawing.Size(60, 27);
            this._numericNotesPerMeasure.TabIndex = 3;
            // 
            // _comboNeckPosition
            // 
            this._comboNeckPosition.FormattingEnabled = true;
            this._comboNeckPosition.Location = new System.Drawing.Point(177, 69);
            this._comboNeckPosition.Name = "_comboNeckPosition";
            this._comboNeckPosition.Size = new System.Drawing.Size(235, 33);
            this._comboNeckPosition.TabIndex = 2;
            // 
            // _comboNoteRange
            // 
            this._comboNoteRange.FormattingEnabled = true;
            this._comboNoteRange.Items.AddRange(new object[] {
            "Select Note Range",
            "Guitar",
            "Bass (4 String)",
            "Bass (5 String)",
            "Other..."});
            this._comboNoteRange.Location = new System.Drawing.Point(177, 26);
            this._comboNoteRange.Name = "_comboNoteRange";
            this._comboNoteRange.Size = new System.Drawing.Size(235, 33);
            this._comboNoteRange.TabIndex = 1;
            // 
            // _bnChords
            // 
            this._bnChords.Location = new System.Drawing.Point(30, 21);
            this._bnChords.Name = "_bnChords";
            this._bnChords.Size = new System.Drawing.Size(112, 34);
            this._bnChords.TabIndex = 0;
            this._bnChords.Text = "Chords...";
            this._bnChords.UseVisualStyleBackColor = true;
            this._bnChords.Click += new System.EventHandler(this._bnChords_Click);
            // 
            // ArpeggiatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.label1);
            this.Name = "ArpeggiatorControl";
            this.Size = new System.Drawing.Size(1454, 686);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.groupDirection.ResumeLayout(false);
            this.groupDirection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericNotesPerChord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericNotesPerMeasure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button _bnChords;
        private System.Windows.Forms.ComboBox _comboNeckPosition;
        private System.Windows.Forms.ComboBox _comboNoteRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _numericNotesPerChord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _numericNotesPerMeasure;
        private System.Windows.Forms.GroupBox groupDirection;
        private System.Windows.Forms.RadioButton _rbDescending;
        private System.Windows.Forms.RadioButton _rbAscending;
        private System.Windows.Forms.CheckBox _cbTemporaryReversal;
        private System.Windows.Forms.CheckBox _cbUntilPatternRepeats;
    }
}

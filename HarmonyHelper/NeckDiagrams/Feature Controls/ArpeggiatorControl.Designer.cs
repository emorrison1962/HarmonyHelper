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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._cbUntilPatternRepeats = new System.Windows.Forms.CheckBox();
            this._bnChords = new System.Windows.Forms.Button();
            this._comboNeckPosition = new System.Windows.Forms.ComboBox();
            this._comboNoteRange = new System.Windows.Forms.ComboBox();
            this.groupDirection = new System.Windows.Forms.GroupBox();
            this._cbTemporaryReversal = new System.Windows.Forms.CheckBox();
            this._rbDescending = new System.Windows.Forms.RadioButton();
            this._rbAscending = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this._numericNotesPerMeasure = new System.Windows.Forms.NumericUpDown();
            this._errorProviderDirection = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this._rtbResults = new System.Windows.Forms.RichTextBox();
            this.pnlSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupDirection.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericNotesPerMeasure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProviderDirection)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arpeggiator";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSettings.Controls.Add(this.tableLayoutPanel1);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.pnlSettings.Size = new System.Drawing.Size(658, 686);
            this.pnlSettings.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._cbUntilPatternRepeats, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this._bnChords, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._comboNeckPosition, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._comboNoteRange, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupDirection, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 674);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // _cbUntilPatternRepeats
            // 
            this._cbUntilPatternRepeats.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this._cbUntilPatternRepeats, 2);
            this._cbUntilPatternRepeats.Location = new System.Drawing.Point(2, 116);
            this._cbUntilPatternRepeats.Margin = new System.Windows.Forms.Padding(2);
            this._cbUntilPatternRepeats.Name = "_cbUntilPatternRepeats";
            this._cbUntilPatternRepeats.Size = new System.Drawing.Size(290, 29);
            this._cbUntilPatternRepeats.TabIndex = 9;
            this._cbUntilPatternRepeats.Text = "Arpeggiate until pattern repeats";
            this._cbUntilPatternRepeats.UseVisualStyleBackColor = true;
            this._cbUntilPatternRepeats.CheckedChanged += new System.EventHandler(this._cbUntilPatternRepeats_CheckedChanged);
            // 
            // _bnChords
            // 
            this._bnChords.Location = new System.Drawing.Point(2, 2);
            this._bnChords.Margin = new System.Windows.Forms.Padding(2);
            this._bnChords.Name = "_bnChords";
            this._bnChords.Size = new System.Drawing.Size(112, 34);
            this._bnChords.TabIndex = 0;
            this._bnChords.Text = "Chords...";
            this._bnChords.UseVisualStyleBackColor = true;
            this._bnChords.Click += new System.EventHandler(this._bnChords_Click);
            // 
            // _comboNeckPosition
            // 
            this._comboNeckPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboNeckPosition.FormattingEnabled = true;
            this._comboNeckPosition.Location = new System.Drawing.Point(2, 79);
            this._comboNeckPosition.Margin = new System.Windows.Forms.Padding(2);
            this._comboNeckPosition.Name = "_comboNeckPosition";
            this._comboNeckPosition.Size = new System.Drawing.Size(235, 33);
            this._comboNeckPosition.TabIndex = 2;
            this._comboNeckPosition.SelectedIndexChanged += new System.EventHandler(this._comboNeckPosition_SelectedIndexChanged);
            // 
            // _comboNoteRange
            // 
            this._comboNoteRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboNoteRange.FormattingEnabled = true;
            this._comboNoteRange.Items.AddRange(new object[] {
            "Select Note Range",
            "Guitar",
            "Bass (4 String)",
            "Bass (5 String)",
            "Other..."});
            this._comboNoteRange.Location = new System.Drawing.Point(2, 40);
            this._comboNoteRange.Margin = new System.Windows.Forms.Padding(2);
            this._comboNoteRange.Name = "_comboNoteRange";
            this._comboNoteRange.Size = new System.Drawing.Size(235, 33);
            this._comboNoteRange.TabIndex = 1;
            this._comboNoteRange.SelectedIndexChanged += new System.EventHandler(this._comboNoteRange_SelectedIndexChanged);
            // 
            // groupDirection
            // 
            this.groupDirection.AutoSize = true;
            this.groupDirection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupDirection, 2);
            this.groupDirection.Controls.Add(this._cbTemporaryReversal);
            this.groupDirection.Controls.Add(this._rbDescending);
            this.groupDirection.Controls.Add(this._rbAscending);
            this.groupDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupDirection.Location = new System.Drawing.Point(2, 149);
            this.groupDirection.Margin = new System.Windows.Forms.Padding(2);
            this.groupDirection.Name = "groupDirection";
            this.groupDirection.Padding = new System.Windows.Forms.Padding(2);
            this.groupDirection.Size = new System.Drawing.Size(372, 159);
            this.groupDirection.TabIndex = 8;
            this.groupDirection.TabStop = false;
            this.groupDirection.Text = "Direction";
            // 
            // _cbTemporaryReversal
            // 
            this._cbTemporaryReversal.AutoSize = true;
            this._cbTemporaryReversal.Location = new System.Drawing.Point(5, 102);
            this._cbTemporaryReversal.Margin = new System.Windows.Forms.Padding(2);
            this._cbTemporaryReversal.Name = "_cbTemporaryReversal";
            this._cbTemporaryReversal.Size = new System.Drawing.Size(363, 29);
            this._cbTemporaryReversal.TabIndex = 3;
            this._cbTemporaryReversal.Text = "Allow Temporay Reversal For Closer Note";
            this._cbTemporaryReversal.UseVisualStyleBackColor = true;
            this._cbTemporaryReversal.CheckedChanged += new System.EventHandler(this._cbTemporaryReversal_CheckedChanged);
            // 
            // _rbDescending
            // 
            this._rbDescending.AutoSize = true;
            this._rbDescending.Location = new System.Drawing.Point(5, 68);
            this._rbDescending.Margin = new System.Windows.Forms.Padding(2);
            this._rbDescending.Name = "_rbDescending";
            this._rbDescending.Size = new System.Drawing.Size(130, 29);
            this._rbDescending.TabIndex = 0;
            this._rbDescending.TabStop = true;
            this._rbDescending.Text = "Descending";
            this._rbDescending.UseVisualStyleBackColor = true;
            this._rbDescending.CheckedChanged += new System.EventHandler(this._rbDescending_CheckedChanged);
            // 
            // _rbAscending
            // 
            this._rbAscending.AutoSize = true;
            this._rbAscending.Location = new System.Drawing.Point(5, 35);
            this._rbAscending.Margin = new System.Windows.Forms.Padding(2);
            this._rbAscending.Name = "_rbAscending";
            this._rbAscending.Size = new System.Drawing.Size(120, 29);
            this._rbAscending.TabIndex = 0;
            this._rbAscending.TabStop = true;
            this._rbAscending.Text = "Ascending";
            this._rbAscending.UseVisualStyleBackColor = true;
            this._rbAscending.CheckedChanged += new System.EventHandler(this._rbAscending_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._numericNotesPerMeasure);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(327, 42);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 31);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Notes per measure";
            // 
            // _numericNotesPerMeasure
            // 
            this._numericNotesPerMeasure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._numericNotesPerMeasure.Location = new System.Drawing.Point(168, 2);
            this._numericNotesPerMeasure.Margin = new System.Windows.Forms.Padding(2);
            this._numericNotesPerMeasure.Name = "_numericNotesPerMeasure";
            this._numericNotesPerMeasure.Size = new System.Drawing.Size(60, 27);
            this._numericNotesPerMeasure.TabIndex = 3;
            this._numericNotesPerMeasure.ValueChanged += new System.EventHandler(this._numericNotesPerMeasure_ValueChanged);
            // 
            // _errorProviderDirection
            // 
            this._errorProviderDirection.ContainerControl = this;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this._rtbResults);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(658, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(796, 686);
            this.pnlMain.TabIndex = 3;
            // 
            // rtbResults
            // 
            this._rtbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbResults.Location = new System.Drawing.Point(0, 0);
            this._rtbResults.Name = "rtbResults";
            this._rtbResults.Size = new System.Drawing.Size(796, 686);
            this._rtbResults.TabIndex = 0;
            this._rtbResults.Text = "";
            // 
            // ArpeggiatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ArpeggiatorControl";
            this.Size = new System.Drawing.Size(1454, 686);
            this.pnlSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupDirection.ResumeLayout(false);
            this.groupDirection.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericNotesPerMeasure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProviderDirection)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox _cbUntilPatternRepeats;
        private System.Windows.Forms.Button _bnChords;
        private System.Windows.Forms.ComboBox _comboNeckPosition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _numericNotesPerMeasure;
        private System.Windows.Forms.ComboBox _comboNoteRange;
        private System.Windows.Forms.GroupBox groupDirection;
        private System.Windows.Forms.CheckBox _cbTemporaryReversal;
        private System.Windows.Forms.RadioButton _rbDescending;
        private System.Windows.Forms.RadioButton _rbAscending;
        private System.Windows.Forms.ErrorProvider _errorProviderDirection;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RichTextBox _rtbResults;
    }
}

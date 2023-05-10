﻿using System.Drawing;

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
            this._noteViewer = new Manufaktura.Controls.WinForms.NoteViewer();
            this._rtbResults = new System.Windows.Forms.RichTextBox();
            this._keyboardControl = new KeyboardControl();
            this.pnlSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupDirection.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._numericNotesPerMeasure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this._errorProviderDirection).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(24, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(90, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arpeggiator";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = SystemColors.Control;
            this.pnlSettings.Controls.Add(this.tableLayoutPanel1);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSettings.Location = new Point(0, 0);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.pnlSettings.Size = new Size(526, 465);
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
            this.tableLayoutPanel1.Location = new Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new Size(516, 455);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // _cbUntilPatternRepeats
            // 
            this._cbUntilPatternRepeats.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this._cbUntilPatternRepeats, 2);
            this._cbUntilPatternRepeats.Location = new Point(2, 98);
            this._cbUntilPatternRepeats.Margin = new System.Windows.Forms.Padding(2);
            this._cbUntilPatternRepeats.Name = "_cbUntilPatternRepeats";
            this._cbUntilPatternRepeats.Size = new Size(244, 24);
            this._cbUntilPatternRepeats.TabIndex = 9;
            this._cbUntilPatternRepeats.Text = "Arpeggiate until pattern repeats";
            this._cbUntilPatternRepeats.UseVisualStyleBackColor = true;
            this._cbUntilPatternRepeats.CheckedChanged += this._cbUntilPatternRepeats_CheckedChanged;
            // 
            // _bnChords
            // 
            this._bnChords.Location = new Point(2, 2);
            this._bnChords.Margin = new System.Windows.Forms.Padding(2);
            this._bnChords.Name = "_bnChords";
            this._bnChords.Size = new Size(90, 27);
            this._bnChords.TabIndex = 0;
            this._bnChords.Text = "Chords...";
            this._bnChords.UseVisualStyleBackColor = true;
            this._bnChords.Click += this._bnChords_Click;
            // 
            // _comboNeckPosition
            // 
            this._comboNeckPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboNeckPosition.FormattingEnabled = true;
            this._comboNeckPosition.Location = new Point(2, 66);
            this._comboNeckPosition.Margin = new System.Windows.Forms.Padding(2);
            this._comboNeckPosition.Name = "_comboNeckPosition";
            this._comboNeckPosition.Size = new Size(189, 28);
            this._comboNeckPosition.TabIndex = 2;
            this._comboNeckPosition.SelectedIndexChanged += this._comboNeckPosition_SelectedIndexChanged;
            // 
            // _comboNoteRange
            // 
            this._comboNoteRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboNoteRange.FormattingEnabled = true;
            this._comboNoteRange.Items.AddRange(new object[] { "Select Note Range", "Guitar", "Bass (4 String)", "Bass (5 String)", "Other..." });
            this._comboNoteRange.Location = new Point(2, 33);
            this._comboNoteRange.Margin = new System.Windows.Forms.Padding(2);
            this._comboNoteRange.Name = "_comboNoteRange";
            this._comboNoteRange.Size = new Size(189, 28);
            this._comboNoteRange.TabIndex = 1;
            this._comboNoteRange.SelectedIndexChanged += this._comboNoteRange_SelectedIndexChanged;
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
            this.groupDirection.Location = new Point(2, 126);
            this.groupDirection.Margin = new System.Windows.Forms.Padding(2);
            this.groupDirection.Name = "groupDirection";
            this.groupDirection.Padding = new System.Windows.Forms.Padding(2);
            this.groupDirection.Size = new Size(313, 130);
            this.groupDirection.TabIndex = 8;
            this.groupDirection.TabStop = false;
            this.groupDirection.Text = "Direction";
            // 
            // _cbTemporaryReversal
            // 
            this._cbTemporaryReversal.AutoSize = true;
            this._cbTemporaryReversal.Location = new Point(4, 82);
            this._cbTemporaryReversal.Margin = new System.Windows.Forms.Padding(2);
            this._cbTemporaryReversal.Name = "_cbTemporaryReversal";
            this._cbTemporaryReversal.Size = new Size(305, 24);
            this._cbTemporaryReversal.TabIndex = 3;
            this._cbTemporaryReversal.Text = "Allow Temporay Reversal For Closer Note";
            this._cbTemporaryReversal.UseVisualStyleBackColor = true;
            this._cbTemporaryReversal.CheckedChanged += this._cbTemporaryReversal_CheckedChanged;
            // 
            // _rbDescending
            // 
            this._rbDescending.AutoSize = true;
            this._rbDescending.Location = new Point(4, 54);
            this._rbDescending.Margin = new System.Windows.Forms.Padding(2);
            this._rbDescending.Name = "_rbDescending";
            this._rbDescending.Size = new Size(108, 24);
            this._rbDescending.TabIndex = 0;
            this._rbDescending.TabStop = true;
            this._rbDescending.Text = "Descending";
            this._rbDescending.UseVisualStyleBackColor = true;
            this._rbDescending.CheckedChanged += this._rbDescending_CheckedChanged;
            // 
            // _rbAscending
            // 
            this._rbAscending.AutoSize = true;
            this._rbAscending.Location = new Point(4, 28);
            this._rbAscending.Margin = new System.Windows.Forms.Padding(2);
            this._rbAscending.Name = "_rbAscending";
            this._rbAscending.Size = new Size(99, 24);
            this._rbAscending.TabIndex = 0;
            this._rbAscending.TabStop = true;
            this._rbAscending.Text = "Ascending";
            this._rbAscending.UseVisualStyleBackColor = true;
            this._rbAscending.CheckedChanged += this._rbAscending_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._numericNotesPerMeasure);
            this.flowLayoutPanel1.Location = new Point(261, 34);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(190, 27);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(134, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Notes per measure";
            // 
            // _numericNotesPerMeasure
            // 
            this._numericNotesPerMeasure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._numericNotesPerMeasure.Location = new Point(140, 2);
            this._numericNotesPerMeasure.Margin = new System.Windows.Forms.Padding(2);
            this._numericNotesPerMeasure.Name = "_numericNotesPerMeasure";
            this._numericNotesPerMeasure.Size = new Size(48, 23);
            this._numericNotesPerMeasure.TabIndex = 3;
            this._numericNotesPerMeasure.Value = new decimal(new int[] { 4, 0, 0, 0 });
            this._numericNotesPerMeasure.ValueChanged += this._numericNotesPerMeasure_ValueChanged;
            // 
            // _errorProviderDirection
            // 
            this._errorProviderDirection.ContainerControl = this;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this._noteViewer);
            this.pnlMain.Controls.Add(this._rtbResults);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new Point(526, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(637, 465);
            this.pnlMain.TabIndex = 3;
            // 
            // _noteViewer
            // 
            this._noteViewer.DataSource = null;
            this._noteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._noteViewer.Location = new Point(0, 0);
            this._noteViewer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._noteViewer.Name = "_noteViewer";
            this._noteViewer.RenderingMode = Manufaktura.Controls.Rendering.ScoreRenderingModes.AllPages;
            this._noteViewer.Size = new Size(637, 305);
            this._noteViewer.TabIndex = 1;
            this._noteViewer.Text = "_noteViewer";
            // 
            // _rtbResults
            // 
            this._rtbResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._rtbResults.Location = new Point(0, 305);
            this._rtbResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._rtbResults.Name = "_rtbResults";
            this._rtbResults.Size = new Size(637, 160);
            this._rtbResults.TabIndex = 0;
            this._rtbResults.Text = "";
            // 
            // keyboardControl1
            // 
            this._keyboardControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._keyboardControl.Location = new Point(0, 465);
            this._keyboardControl.Name = "keyboardControl1";
            this._keyboardControl.Size = new Size(1163, 84);
            this._keyboardControl.TabIndex = 2;
            // 
            // ArpeggiatorControl
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._keyboardControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ArpeggiatorControl";
            this.Size = new Size(1163, 549);
            this.pnlSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupDirection.ResumeLayout(false);
            this.groupDirection.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._numericNotesPerMeasure).EndInit();
            ((System.ComponentModel.ISupportInitialize)this._errorProviderDirection).EndInit();
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
        private Manufaktura.Controls.WinForms.NoteViewer _noteViewer;
        private KeyboardControl _keyboardControl;
    }
}

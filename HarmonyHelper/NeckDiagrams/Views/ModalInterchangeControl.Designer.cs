namespace NeckDiagrams.Controls
{
    partial class ModalInterchangeControl
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
            _chordNamesControl = new ChordNamesControl();
            mainSplitter = new System.Windows.Forms.SplitContainer();
            analysisSplitter = new System.Windows.Forms.SplitContainer();
            lvAnalysis = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            tbDetails = new System.Windows.Forms.TextBox();
            bnChords = new System.Windows.Forms.Button();
            pnlTop = new System.Windows.Forms.Panel();
            keySignatureSelectorControl1 = new KeySignatureSelectorControl();
            ((System.ComponentModel.ISupportInitialize)mainSplitter).BeginInit();
            mainSplitter.Panel1.SuspendLayout();
            mainSplitter.Panel2.SuspendLayout();
            mainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)analysisSplitter).BeginInit();
            analysisSplitter.Panel1.SuspendLayout();
            analysisSplitter.Panel2.SuspendLayout();
            analysisSplitter.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // _chordNamesControl
            // 
            _chordNamesControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _chordNamesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _chordNamesControl.Location = new System.Drawing.Point(0, 0);
            _chordNamesControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            _chordNamesControl.Name = "_chordNamesControl";
            _chordNamesControl.Size = new System.Drawing.Size(1246, 345);
            _chordNamesControl.TabIndex = 4;
            // 
            // mainSplitter
            // 
            mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            mainSplitter.Location = new System.Drawing.Point(0, 40);
            mainSplitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            mainSplitter.Name = "mainSplitter";
            mainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitter.Panel1
            // 
            mainSplitter.Panel1.Controls.Add(_chordNamesControl);
            // 
            // mainSplitter.Panel2
            // 
            mainSplitter.Panel2.Controls.Add(analysisSplitter);
            mainSplitter.Size = new System.Drawing.Size(1246, 642);
            mainSplitter.SplitterDistance = 345;
            mainSplitter.TabIndex = 5;
            // 
            // analysisSplitter
            // 
            analysisSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            analysisSplitter.Location = new System.Drawing.Point(0, 0);
            analysisSplitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            analysisSplitter.Name = "analysisSplitter";
            // 
            // analysisSplitter.Panel1
            // 
            analysisSplitter.Panel1.Controls.Add(lvAnalysis);
            // 
            // analysisSplitter.Panel2
            // 
            analysisSplitter.Panel2.Controls.Add(tbDetails);
            analysisSplitter.Size = new System.Drawing.Size(1246, 293);
            analysisSplitter.SplitterDistance = 525;
            analysisSplitter.TabIndex = 0;
            // 
            // lvAnalysis
            // 
            lvAnalysis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            lvAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            lvAnalysis.FullRowSelect = true;
            lvAnalysis.GridLines = true;
            lvAnalysis.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lvAnalysis.Location = new System.Drawing.Point(0, 0);
            lvAnalysis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lvAnalysis.Name = "lvAnalysis";
            lvAnalysis.ShowItemToolTips = true;
            lvAnalysis.Size = new System.Drawing.Size(525, 293);
            lvAnalysis.TabIndex = 0;
            lvAnalysis.UseCompatibleStateImageBehavior = false;
            lvAnalysis.View = System.Windows.Forms.View.Details;
            lvAnalysis.SelectedIndexChanged += lvAnalysis_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 491;
            // 
            // tbDetails
            // 
            tbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            tbDetails.Location = new System.Drawing.Point(0, 0);
            tbDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbDetails.Multiline = true;
            tbDetails.Name = "tbDetails";
            tbDetails.Size = new System.Drawing.Size(717, 293);
            tbDetails.TabIndex = 0;
            // 
            // bnChords
            // 
            bnChords.AutoSize = true;
            bnChords.Dock = System.Windows.Forms.DockStyle.Left;
            bnChords.Location = new System.Drawing.Point(3, 2);
            bnChords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            bnChords.Name = "bnChords";
            bnChords.Size = new System.Drawing.Size(82, 36);
            bnChords.TabIndex = 0;
            bnChords.Text = "Chords...";
            bnChords.UseVisualStyleBackColor = true;
            bnChords.Click += bnChords_Click;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(keySignatureSelectorControl1);
            pnlTop.Controls.Add(bnChords);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pnlTop.Size = new System.Drawing.Size(1246, 40);
            pnlTop.TabIndex = 6;
            // 
            // keySignatureSelectorControl1
            // 
            keySignatureSelectorControl1.Location = new System.Drawing.Point(254, 7);
            keySignatureSelectorControl1.Name = "keySignatureSelectorControl1";
            keySignatureSelectorControl1.Size = new System.Drawing.Size(470, 35);
            keySignatureSelectorControl1.TabIndex = 1;
            // 
            // ModalInterchangeControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(mainSplitter);
            Controls.Add(pnlTop);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ModalInterchangeControl";
            Size = new System.Drawing.Size(1246, 682);
            mainSplitter.Panel1.ResumeLayout(false);
            mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitter).EndInit();
            mainSplitter.ResumeLayout(false);
            analysisSplitter.Panel1.ResumeLayout(false);
            analysisSplitter.Panel2.ResumeLayout(false);
            analysisSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)analysisSplitter).EndInit();
            analysisSplitter.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ChordNamesControl _chordNamesControl;
        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.SplitContainer analysisSplitter;
        private System.Windows.Forms.ListView lvAnalysis;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Button bnChords;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private KeySignatureSelectorControl keySignatureSelectorControl1;
    }
}

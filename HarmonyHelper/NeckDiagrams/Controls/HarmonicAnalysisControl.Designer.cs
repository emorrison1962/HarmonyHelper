namespace NeckDiagrams.Controls
{
    partial class HarmonicAnalysisControl
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
            this.chordsTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.bnChords = new System.Windows.Forms.Button();
            this.analysisSplitter = new System.Windows.Forms.SplitContainer();
            this.lvAnalysis = new System.Windows.Forms.ListView();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chordsTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analysisSplitter)).BeginInit();
            this.analysisSplitter.Panel1.SuspendLayout();
            this.analysisSplitter.Panel2.SuspendLayout();
            this.analysisSplitter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chordsTablePanel
            // 
            this.chordsTablePanel.ColumnCount = 8;
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.chordsTablePanel.Controls.Add(this.label3, 0, 0);
            this.chordsTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chordsTablePanel.Location = new System.Drawing.Point(0, 0);
            this.chordsTablePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chordsTablePanel.Name = "chordsTablePanel";
            this.chordsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 368F));
            this.chordsTablePanel.Size = new System.Drawing.Size(1402, 368);
            this.chordsTablePanel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MediumTurquoise;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 368);
            this.label3.TabIndex = 1;
            this.label3.Text = "Parsed:";
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 0);
            this.mainSplitter.Name = "mainSplitter";
            this.mainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.chordsTablePanel);
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.analysisSplitter);
            this.mainSplitter.Size = new System.Drawing.Size(1402, 682);
            this.mainSplitter.SplitterDistance = 368;
            this.mainSplitter.TabIndex = 5;
            // 
            // bnChords
            // 
            this.bnChords.AutoSize = true;
            this.bnChords.Dock = System.Windows.Forms.DockStyle.Left;
            this.bnChords.Location = new System.Drawing.Point(3, 3);
            this.bnChords.Name = "bnChords";
            this.bnChords.Size = new System.Drawing.Size(82, 34);
            this.bnChords.TabIndex = 0;
            this.bnChords.Text = "Chords...";
            this.bnChords.UseVisualStyleBackColor = true;
            this.bnChords.Click += new System.EventHandler(this.bnChords_Click);
            // 
            // analysisSplitter
            // 
            this.analysisSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analysisSplitter.Location = new System.Drawing.Point(0, 0);
            this.analysisSplitter.Name = "analysisSplitter";
            // 
            // analysisSplitter.Panel1
            // 
            this.analysisSplitter.Panel1.Controls.Add(this.lvAnalysis);
            // 
            // analysisSplitter.Panel2
            // 
            this.analysisSplitter.Panel2.Controls.Add(this.tbDetails);
            this.analysisSplitter.Size = new System.Drawing.Size(1402, 310);
            this.analysisSplitter.SplitterDistance = 592;
            this.analysisSplitter.TabIndex = 0;
            // 
            // lvAnalysis
            // 
            this.lvAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAnalysis.FullRowSelect = true;
            this.lvAnalysis.GridLines = true;
            this.lvAnalysis.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAnalysis.HideSelection = false;
            this.lvAnalysis.Location = new System.Drawing.Point(0, 0);
            this.lvAnalysis.Name = "lvAnalysis";
            this.lvAnalysis.Size = new System.Drawing.Size(592, 310);
            this.lvAnalysis.TabIndex = 0;
            this.lvAnalysis.UseCompatibleStateImageBehavior = false;
            // 
            // tbDetails
            // 
            this.tbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetails.Location = new System.Drawing.Point(0, 0);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Size = new System.Drawing.Size(806, 310);
            this.tbDetails.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bnChords);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1402, 40);
            this.panel1.TabIndex = 6;
            // 
            // HarmonicAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainSplitter);
            this.Name = "HarmonicAnalysisControl";
            this.Size = new System.Drawing.Size(1402, 682);
            this.chordsTablePanel.ResumeLayout(false);
            this.chordsTablePanel.PerformLayout();
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.analysisSplitter.Panel1.ResumeLayout(false);
            this.analysisSplitter.Panel2.ResumeLayout(false);
            this.analysisSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analysisSplitter)).EndInit();
            this.analysisSplitter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel chordsTablePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.SplitContainer analysisSplitter;
        private System.Windows.Forms.ListView lvAnalysis;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Button bnChords;
        private System.Windows.Forms.Panel panel1;
    }
}

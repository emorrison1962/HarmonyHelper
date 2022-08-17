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
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.analysisSplitter = new System.Windows.Forms.SplitContainer();
            this.lvAnalysis = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.bnChords = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analysisSplitter)).BeginInit();
            this.analysisSplitter.Panel1.SuspendLayout();
            this.analysisSplitter.Panel2.SuspendLayout();
            this.analysisSplitter.SuspendLayout();
            this.pnlTop.SuspendLayout();
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
            this.chordsTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chordsTablePanel.Location = new System.Drawing.Point(0, 0);
            this.chordsTablePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chordsTablePanel.Name = "chordsTablePanel";
            this.chordsTablePanel.Size = new System.Drawing.Size(1402, 345);
            this.chordsTablePanel.TabIndex = 4;
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 40);
            this.mainSplitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.mainSplitter.Size = new System.Drawing.Size(1402, 642);
            this.mainSplitter.SplitterDistance = 345;
            this.mainSplitter.TabIndex = 5;
            // 
            // analysisSplitter
            // 
            this.analysisSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analysisSplitter.Location = new System.Drawing.Point(0, 0);
            this.analysisSplitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.analysisSplitter.Name = "analysisSplitter";
            // 
            // analysisSplitter.Panel1
            // 
            this.analysisSplitter.Panel1.Controls.Add(this.lvAnalysis);
            // 
            // analysisSplitter.Panel2
            // 
            this.analysisSplitter.Panel2.Controls.Add(this.tbDetails);
            this.analysisSplitter.Size = new System.Drawing.Size(1402, 293);
            this.analysisSplitter.SplitterDistance = 591;
            this.analysisSplitter.TabIndex = 0;
            // 
            // lvAnalysis
            // 
            this.lvAnalysis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAnalysis.FullRowSelect = true;
            this.lvAnalysis.GridLines = true;
            this.lvAnalysis.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAnalysis.HideSelection = false;
            this.lvAnalysis.Location = new System.Drawing.Point(0, 0);
            this.lvAnalysis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvAnalysis.Name = "lvAnalysis";
            this.lvAnalysis.Size = new System.Drawing.Size(591, 293);
            this.lvAnalysis.TabIndex = 0;
            this.lvAnalysis.UseCompatibleStateImageBehavior = false;
            this.lvAnalysis.View = System.Windows.Forms.View.Details;
            this.lvAnalysis.SelectedIndexChanged += new System.EventHandler(this.lvAnalysis_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 491;
            // 
            // tbDetails
            // 
            this.tbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetails.Location = new System.Drawing.Point(0, 0);
            this.tbDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Size = new System.Drawing.Size(807, 293);
            this.tbDetails.TabIndex = 0;
            // 
            // bnChords
            // 
            this.bnChords.AutoSize = true;
            this.bnChords.Dock = System.Windows.Forms.DockStyle.Left;
            this.bnChords.Location = new System.Drawing.Point(3, 2);
            this.bnChords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnChords.Name = "bnChords";
            this.bnChords.Size = new System.Drawing.Size(92, 36);
            this.bnChords.TabIndex = 0;
            this.bnChords.Text = "Chords...";
            this.bnChords.UseVisualStyleBackColor = true;
            this.bnChords.Click += new System.EventHandler(this.bnChords_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.bnChords);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTop.Size = new System.Drawing.Size(1402, 40);
            this.pnlTop.TabIndex = 6;
            // 
            // HarmonicAnalysisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainSplitter);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HarmonicAnalysisControl";
            this.Size = new System.Drawing.Size(1402, 682);
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.analysisSplitter.Panel1.ResumeLayout(false);
            this.analysisSplitter.Panel2.ResumeLayout(false);
            this.analysisSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.analysisSplitter)).EndInit();
            this.analysisSplitter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel chordsTablePanel;
        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.SplitContainer analysisSplitter;
        private System.Windows.Forms.ListView lvAnalysis;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Button bnChords;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

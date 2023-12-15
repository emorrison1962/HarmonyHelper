namespace NeckDiagrams.Controls
{
    partial class ModalInterchangeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModalInterchangeView));
            mainSplitter = new System.Windows.Forms.SplitContainer();
            analysisSplitter = new System.Windows.Forms.SplitContainer();
            tbDetails = new System.Windows.Forms.TextBox();
            pnlTop = new System.Windows.Forms.Panel();
            _keySignatureCombo = new KeySignatureCombo();
            _rootFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelMajor = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelMelodicMinor = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelHarmonicMinor = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)mainSplitter).BeginInit();
            mainSplitter.Panel1.SuspendLayout();
            mainSplitter.Panel2.SuspendLayout();
            mainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)analysisSplitter).BeginInit();
            analysisSplitter.Panel2.SuspendLayout();
            analysisSplitter.SuspendLayout();
            pnlTop.SuspendLayout();
            _rootFlowLayoutPanel.SuspendLayout();
            SuspendLayout();
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
            mainSplitter.Panel1.Controls.Add(_rootFlowLayoutPanel);
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
            // analysisSplitter.Panel2
            // 
            analysisSplitter.Panel2.Controls.Add(tbDetails);
            analysisSplitter.Size = new System.Drawing.Size(1246, 293);
            analysisSplitter.SplitterDistance = 525;
            analysisSplitter.TabIndex = 0;
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
            // pnlTop
            // 
            pnlTop.Controls.Add(_keySignatureCombo);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pnlTop.Size = new System.Drawing.Size(1246, 40);
            pnlTop.TabIndex = 6;
            // 
            // _keySignatureCombo
            // 
            _keySignatureCombo.Location = new System.Drawing.Point(254, 7);
            _keySignatureCombo.Name = "_keySignatureCombo";
            _keySignatureCombo.Size = new System.Drawing.Size(470, 28);
            _keySignatureCombo.TabIndex = 1;
            // 
            // _rootFlowLayoutPanel
            // 
            _rootFlowLayoutPanel.Controls.Add(flowLayoutPanelMajor);
            _rootFlowLayoutPanel.Controls.Add(flowLayoutPanelMelodicMinor);
            _rootFlowLayoutPanel.Controls.Add(flowLayoutPanelHarmonicMinor);
            _rootFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _rootFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            _rootFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            _rootFlowLayoutPanel.Name = "_rootFlowLayoutPanel";
            _rootFlowLayoutPanel.Size = new System.Drawing.Size(1246, 345);
            _rootFlowLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanelMajor.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanelMajor.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanelMajor.Name = "flowLayoutPanel1";
            flowLayoutPanelMajor.Size = new System.Drawing.Size(0, 125);
            flowLayoutPanelMajor.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanelMelodicMinor.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanelMelodicMinor.Location = new System.Drawing.Point(3, 134);
            flowLayoutPanelMelodicMinor.Name = "flowLayoutPanel2";
            flowLayoutPanelMelodicMinor.Size = new System.Drawing.Size(0, 125);
            flowLayoutPanelMelodicMinor.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanelHarmonicMinor.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanelHarmonicMinor.Location = new System.Drawing.Point(9, 3);
            flowLayoutPanelHarmonicMinor.Name = "flowLayoutPanel3";
            flowLayoutPanelHarmonicMinor.Size = new System.Drawing.Size(0, 125);
            flowLayoutPanelHarmonicMinor.TabIndex = 2;
            // 
            // ModalInterchangeView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(mainSplitter);
            Controls.Add(pnlTop);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ModalInterchangeView";
            Size = new System.Drawing.Size(1246, 682);
            mainSplitter.Panel1.ResumeLayout(false);
            mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitter).EndInit();
            mainSplitter.ResumeLayout(false);
            analysisSplitter.Panel2.ResumeLayout(false);
            analysisSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)analysisSplitter).EndInit();
            analysisSplitter.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            _rootFlowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.SplitContainer analysisSplitter;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Panel pnlTop;
        private KeySignatureCombo _keySignatureCombo;
        private System.Windows.Forms.FlowLayoutPanel _rootFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMajor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMelodicMinor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHarmonicMinor;
    }
}

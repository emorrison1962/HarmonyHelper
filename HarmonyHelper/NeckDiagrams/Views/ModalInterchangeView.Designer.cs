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
            _rootPanel = new System.Windows.Forms.TableLayoutPanel();
            _panelMajor = new System.Windows.Forms.TableLayoutPanel();
            _panelMelodicMinor = new System.Windows.Forms.TableLayoutPanel();
            _panelHarmonicMinor = new System.Windows.Forms.TableLayoutPanel();
            analysisSplitter = new System.Windows.Forms.SplitContainer();
            tbDetails = new System.Windows.Forms.TextBox();
            pnlTop = new System.Windows.Forms.Panel();
            _keySignatureCombo = new KeySignatureCombo();
            ((System.ComponentModel.ISupportInitialize)mainSplitter).BeginInit();
            mainSplitter.Panel1.SuspendLayout();
            mainSplitter.Panel2.SuspendLayout();
            mainSplitter.SuspendLayout();
            _rootPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)analysisSplitter).BeginInit();
            analysisSplitter.Panel2.SuspendLayout();
            analysisSplitter.SuspendLayout();
            pnlTop.SuspendLayout();
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
            mainSplitter.Panel1.Controls.Add(_rootPanel);
            // 
            // mainSplitter.Panel2
            // 
            mainSplitter.Panel2.Controls.Add(analysisSplitter);
            mainSplitter.Size = new System.Drawing.Size(1246, 642);
            mainSplitter.SplitterDistance = 345;
            mainSplitter.TabIndex = 5;
            // 
            // _rootPanel
            // 
            _rootPanel.AutoSize = true;
            _rootPanel.ColumnCount = 1;
            _rootPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _rootPanel.Controls.Add(_panelMajor);
            _rootPanel.Controls.Add(_panelMelodicMinor);
            _rootPanel.Controls.Add(_panelHarmonicMinor);
            _rootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _rootPanel.Location = new System.Drawing.Point(0, 0);
            _rootPanel.Name = "_rootPanel";
            _rootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _rootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _rootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _rootPanel.Size = new System.Drawing.Size(1246, 345);
            _rootPanel.TabIndex = 0;
            // 
            // _panelMajor
            // 
            _panelMajor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _panelMajor.Dock = System.Windows.Forms.DockStyle.Top;
            _panelMajor.Location = new System.Drawing.Point(3, 3);
            _panelMajor.Name = "_panelMajor";
            _panelMajor.Size = new System.Drawing.Size(1240, 14);
            _panelMajor.TabIndex = 0;
            // 
            // _panelMelodicMinor
            // 
            _panelMelodicMinor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _panelMelodicMinor.Dock = System.Windows.Forms.DockStyle.Top;
            _panelMelodicMinor.Location = new System.Drawing.Point(3, 23);
            _panelMelodicMinor.Name = "_panelMelodicMinor";
            _panelMelodicMinor.Size = new System.Drawing.Size(1240, 14);
            _panelMelodicMinor.TabIndex = 1;
            // 
            // _panelHarmonicMinor
            // 
            _panelHarmonicMinor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _panelHarmonicMinor.Dock = System.Windows.Forms.DockStyle.Top;
            _panelHarmonicMinor.Location = new System.Drawing.Point(3, 43);
            _panelHarmonicMinor.Name = "_panelHarmonicMinor";
            _panelHarmonicMinor.Size = new System.Drawing.Size(1240, 125);
            _panelHarmonicMinor.TabIndex = 2;
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
            mainSplitter.Panel1.PerformLayout();
            mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitter).EndInit();
            mainSplitter.ResumeLayout(false);
            _rootPanel.ResumeLayout(false);
            analysisSplitter.Panel2.ResumeLayout(false);
            analysisSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)analysisSplitter).EndInit();
            analysisSplitter.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.SplitContainer analysisSplitter;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Panel pnlTop;
        private KeySignatureCombo _keySignatureCombo;
        private System.Windows.Forms.TableLayoutPanel _rootPanel;
        private System.Windows.Forms.TableLayoutPanel _panelMajor;
        private System.Windows.Forms.TableLayoutPanel _panelMelodicMinor;
        private System.Windows.Forms.TableLayoutPanel _panelHarmonicMinor;
    }
}

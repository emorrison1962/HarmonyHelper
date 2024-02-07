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
            _rootPanel = new System.Windows.Forms.FlowLayoutPanel();
            _panelMajor = new System.Windows.Forms.TableLayoutPanel();
            _panelMelodicMinor = new System.Windows.Forms.TableLayoutPanel();
            _panelHarmonicMinor = new System.Windows.Forms.TableLayoutPanel();
            pnlTop = new System.Windows.Forms.Panel();
            _keySignatureCombo = new KeySignatureCombo();
            _rootPanel.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // _rootPanel
            // 
            _rootPanel.AutoSize = true;
            _rootPanel.Controls.Add(_panelMajor);
            _rootPanel.Controls.Add(_panelMelodicMinor);
            _rootPanel.Controls.Add(_panelHarmonicMinor);
            _rootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _rootPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            _rootPanel.Location = new System.Drawing.Point(0, 40);
            _rootPanel.Name = "_rootPanel";
            _rootPanel.Padding = new System.Windows.Forms.Padding(10);
            _rootPanel.Size = new System.Drawing.Size(1246, 642);
            _rootPanel.TabIndex = 0;
            // 
            // _panelMajor
            // 
            _panelMajor.AutoSize = true;
            _panelMajor.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            _panelMajor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _panelMajor.Dock = System.Windows.Forms.DockStyle.Top;
            _panelMajor.Location = new System.Drawing.Point(13, 13);
            _panelMajor.Name = "_panelMajor";
            _panelMajor.Size = new System.Drawing.Size(22, 1);
            _panelMajor.TabIndex = 0;
            // 
            // _panelMelodicMinor
            // 
            _panelMelodicMinor.AutoSize = true;
            _panelMelodicMinor.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            _panelMelodicMinor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _panelMelodicMinor.Dock = System.Windows.Forms.DockStyle.Top;
            _panelMelodicMinor.Location = new System.Drawing.Point(13, 20);
            _panelMelodicMinor.Name = "_panelMelodicMinor";
            _panelMelodicMinor.Size = new System.Drawing.Size(22, 1);
            _panelMelodicMinor.TabIndex = 1;
            // 
            // _panelHarmonicMinor
            // 
            _panelHarmonicMinor.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            _panelHarmonicMinor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _panelHarmonicMinor.Dock = System.Windows.Forms.DockStyle.Top;
            _panelHarmonicMinor.Location = new System.Drawing.Point(13, 27);
            _panelHarmonicMinor.Name = "_panelHarmonicMinor";
            _panelHarmonicMinor.Size = new System.Drawing.Size(22, 217);
            _panelHarmonicMinor.TabIndex = 2;
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
            Controls.Add(_rootPanel);
            Controls.Add(pnlTop);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ModalInterchangeView";
            Size = new System.Drawing.Size(1246, 682);
            _rootPanel.ResumeLayout(false);
            _rootPanel.PerformLayout();
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private KeySignatureCombo _keySignatureCombo;
        //private System.Windows.Forms.TableLayoutPanel _rootPanel;
        private System.Windows.Forms.FlowLayoutPanel _rootPanel;
        private System.Windows.Forms.TableLayoutPanel _panelMajor;
        private System.Windows.Forms.TableLayoutPanel _panelMelodicMinor;
        private System.Windows.Forms.TableLayoutPanel _panelHarmonicMinor;
    }
}

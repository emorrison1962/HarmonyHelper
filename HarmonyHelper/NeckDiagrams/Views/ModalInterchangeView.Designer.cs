using NeckDiagrams.Controls;
using NeckDiagrams.Controls.ComboBoxes;

namespace NeckDiagrams.Views
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
            this._rootPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._gridMajor = new NeckDiagrams.Controls.ModalInterchangeGridControl();
            this._gridMelodicMinor = new NeckDiagrams.Controls.ModalInterchangeGridControl();
            this._gridHarmonicMinor = new NeckDiagrams.Controls.ModalInterchangeGridControl();
            this.pnlTop = new System.Windows.Forms.Panel();
            this._keySignatureCombo = new NeckDiagrams.Controls.ComboBoxes.KeySignatureCombo();
            this._rootPanel.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rootPanel
            // 
            this._rootPanel.AutoSize = true;
            this._rootPanel.Controls.Add(this._gridMajor);
            this._rootPanel.Controls.Add(this._gridMelodicMinor);
            this._rootPanel.Controls.Add(this._gridHarmonicMinor);
            this._rootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rootPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._rootPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._rootPanel.Location = new System.Drawing.Point(0, 64);
            this._rootPanel.Margin = new System.Windows.Forms.Padding(5);
            this._rootPanel.Name = "_rootPanel";
            this._rootPanel.Padding = new System.Windows.Forms.Padding(16);
            this._rootPanel.Size = new System.Drawing.Size(2025, 1027);
            this._rootPanel.TabIndex = 0;
            // 
            // _gridMajor
            // 
            this._gridMajor.Location = new System.Drawing.Point(19, 19);
            this._gridMajor.Name = "_gridMajor";
            this._gridMajor.Size = new System.Drawing.Size(2184, 273);
            this._gridMajor.TabIndex = 0;
            // 
            // _gridMelodicMinor
            // 
            this._gridMelodicMinor.Location = new System.Drawing.Point(19, 298);
            this._gridMelodicMinor.Name = "_gridMelodicMinor";
            this._gridMelodicMinor.Size = new System.Drawing.Size(2184, 273);
            this._gridMelodicMinor.TabIndex = 1;
            // 
            // _gridHarmonicMinor
            // 
            this._gridHarmonicMinor.Location = new System.Drawing.Point(19, 577);
            this._gridHarmonicMinor.Name = "_gridHarmonicMinor";
            this._gridHarmonicMinor.Size = new System.Drawing.Size(2184, 273);
            this._gridHarmonicMinor.TabIndex = 2;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this._keySignatureCombo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.pnlTop.Size = new System.Drawing.Size(2025, 64);
            this.pnlTop.TabIndex = 6;
            // 
            // _keySignatureCombo
            // 
            this._keySignatureCombo.Location = new System.Drawing.Point(413, 11);
            this._keySignatureCombo.Margin = new System.Windows.Forms.Padding(5);
            this._keySignatureCombo.Name = "_keySignatureCombo";
            this._keySignatureCombo.Size = new System.Drawing.Size(761, 40);
            this._keySignatureCombo.TabIndex = 1;
            // 
            // ModalInterchangeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._rootPanel);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "ModalInterchangeView";
            this.Size = new System.Drawing.Size(2025, 1091);
            this._rootPanel.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private KeySignatureCombo _keySignatureCombo;
        //private System.Windows.Forms.TableLayoutPanel _rootPanel;
        private System.Windows.Forms.FlowLayoutPanel _rootPanel;
        private ModalInterchangeGridControl _gridMajor;
        private ModalInterchangeGridControl _gridMelodicMinor;
        private ModalInterchangeGridControl _gridHarmonicMinor;
    }
}

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
            _gridMajor = new ModalInterchangeGridControl();
            _gridMelodicMinor = new ModalInterchangeGridControl();
            _gridHarmonicMinor = new ModalInterchangeGridControl();
            pnlTop = new System.Windows.Forms.Panel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            _keySignatureCombo = new KeySignatureCombo();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            pnlTop.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // _gridMajor
            // 
            _gridMajor.Dock = System.Windows.Forms.DockStyle.Fill;
            _gridMajor.Location = new System.Drawing.Point(507, 1);
            _gridMajor.Margin = new System.Windows.Forms.Padding(1);
            _gridMajor.Name = "_gridMajor";
            _gridMajor.Size = new System.Drawing.Size(1011, 399);
            _gridMajor.TabIndex = 0;
            // 
            // _gridMelodicMinor
            // 
            _gridMelodicMinor.Dock = System.Windows.Forms.DockStyle.Fill;
            _gridMelodicMinor.Location = new System.Drawing.Point(507, 402);
            _gridMelodicMinor.Margin = new System.Windows.Forms.Padding(1);
            _gridMelodicMinor.Name = "_gridMelodicMinor";
            _gridMelodicMinor.Size = new System.Drawing.Size(1011, 399);
            _gridMelodicMinor.TabIndex = 1;
            // 
            // _gridHarmonicMinor
            // 
            _gridHarmonicMinor.Dock = System.Windows.Forms.DockStyle.Fill;
            _gridHarmonicMinor.Location = new System.Drawing.Point(507, 803);
            _gridHarmonicMinor.Margin = new System.Windows.Forms.Padding(1);
            _gridHarmonicMinor.Name = "_gridHarmonicMinor";
            _gridHarmonicMinor.Size = new System.Drawing.Size(1011, 401);
            _gridHarmonicMinor.TabIndex = 2;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(tableLayoutPanel2);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pnlTop.Size = new System.Drawing.Size(2027, 40);
            pnlTop.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(_keySignatureCombo, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(2021, 36);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // _keySignatureCombo
            // 
            _keySignatureCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            _keySignatureCombo.Location = new System.Drawing.Point(891, 3);
            _keySignatureCombo.Name = "_keySignatureCombo";
            _keySignatureCombo.Size = new System.Drawing.Size(239, 28);
            _keySignatureCombo.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(_gridHarmonicMinor, 1, 2);
            tableLayoutPanel1.Controls.Add(_gridMelodicMinor, 1, 1);
            tableLayoutPanel1.Controls.Add(_gridMajor, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new System.Drawing.Size(2027, 1205);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // ModalInterchangeView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlTop);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ModalInterchangeView";
            Size = new System.Drawing.Size(2027, 1245);
            pnlTop.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private KeySignatureCombo _keySignatureCombo;
        private ModalInterchangeGridControl _gridMajor;
        private ModalInterchangeGridControl _gridMelodicMinor;
        private ModalInterchangeGridControl _gridHarmonicMinor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

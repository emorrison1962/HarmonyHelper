namespace NeckDiagrams.Views
{
    partial class ChordShapeView
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
            components = new System.ComponentModel.Container();
            _ctlNeck = new NeckControl();
            pnlTop = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            _ctlChordFormulaSelector = new ChordFormulaSelectorControl();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            pnlTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // _ctlNeck
            // 
            _ctlNeck.Location = new System.Drawing.Point(273, 5);
            _ctlNeck.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            _ctlNeck.Name = "_ctlNeck";
            _ctlNeck.Size = new System.Drawing.Size(1368, 310);
            _ctlNeck.TabIndex = 0;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(tableLayoutPanel1);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1915, 87);
            pnlTop.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(_ctlChordFormulaSelector, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1915, 87);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // _ctlChordFormulaSelector
            // 
            _ctlChordFormulaSelector.Location = new System.Drawing.Point(810, 5);
            _ctlChordFormulaSelector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            _ctlChordFormulaSelector.Name = "_ctlChordFormulaSelector";
            _ctlChordFormulaSelector.NoteName = null;
            _ctlChordFormulaSelector.SelectedItem = null;
            _ctlChordFormulaSelector.Size = new System.Drawing.Size(295, 77);
            _ctlChordFormulaSelector.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(_ctlNeck, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 87);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(1915, 1082);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // ChordShapeView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel2);
            Controls.Add(pnlTop);
            Name = "ChordShapeView";
            Size = new System.Drawing.Size(1915, 1169);
            pnlTop.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private NeckControl _ctlNeck;
        private System.Windows.Forms.Panel pnlTop;
        private ChordFormulaSelectorControl _ctlChordFormulaSelector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}


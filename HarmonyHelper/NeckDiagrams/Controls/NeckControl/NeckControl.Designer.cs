
namespace NeckDiagrams
{
	partial class NeckControl
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
            printDocument = new System.Drawing.Printing.PrintDocument();
            pnlNeck = new System.Windows.Forms.Panel();
            pnlTop = new System.Windows.Forms.Panel();
            pnlKey = new System.Windows.Forms.Panel();
            _bnAddItem = new System.Windows.Forms.Button();
            lblKey = new System.Windows.Forms.Label();
            _cbKey = new System.Windows.Forms.ComboBox();
            chordShapeVMBindingSource = new System.Windows.Forms.BindingSource(components);
            pnlNeck.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chordShapeVMBindingSource).BeginInit();
            SuspendLayout();
            // 
            // printDocument
            // 
            printDocument.BeginPrint += printDocument_BeginPrint;
            printDocument.EndPrint += printDocument_EndPrint;
            printDocument.PrintPage += printDocument_PrintPage;
            printDocument.QueryPageSettings += printDocument_QueryPageSettings;
            // 
            // pnlNeck
            // 
            pnlNeck.BackColor = System.Drawing.SystemColors.Control;
            pnlNeck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnlNeck.Controls.Add(pnlTop);
            pnlNeck.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlNeck.Location = new System.Drawing.Point(0, 0);
            pnlNeck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlNeck.Name = "pnlNeck";
            pnlNeck.Padding = new System.Windows.Forms.Padding(32, 31, 32, 31);
            pnlNeck.Size = new System.Drawing.Size(1368, 334);
            pnlNeck.TabIndex = 4;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = System.Drawing.SystemColors.Control;
            pnlTop.Controls.Add(pnlKey);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(32, 31);
            pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlTop.MinimumSize = new System.Drawing.Size(1280, 154);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1300, 154);
            pnlTop.TabIndex = 2;
            // 
            // pnlKey
            // 
            pnlKey.BackColor = System.Drawing.SystemColors.Control;
            pnlKey.Controls.Add(_bnAddItem);
            pnlKey.Controls.Add(lblKey);
            pnlKey.Controls.Add(_cbKey);
            pnlKey.Dock = System.Windows.Forms.DockStyle.Left;
            pnlKey.Location = new System.Drawing.Point(0, 0);
            pnlKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlKey.Name = "pnlKey";
            pnlKey.Size = new System.Drawing.Size(320, 154);
            pnlKey.TabIndex = 1;
            // 
            // _bnAddItem
            // 
            _bnAddItem.Location = new System.Drawing.Point(170, 80);
            _bnAddItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            _bnAddItem.Name = "_bnAddItem";
            _bnAddItem.Size = new System.Drawing.Size(119, 35);
            _bnAddItem.TabIndex = 6;
            _bnAddItem.Text = "+";
            _bnAddItem.UseVisualStyleBackColor = true;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new System.Drawing.Point(30, 42);
            lblKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblKey.Name = "lblKey";
            lblKey.Size = new System.Drawing.Size(36, 20);
            lblKey.TabIndex = 5;
            lblKey.Text = "Key:";
            lblKey.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _cbKey
            // 
            _cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _cbKey.FormattingEnabled = true;
            _cbKey.Location = new System.Drawing.Point(96, 39);
            _cbKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            _cbKey.Name = "_cbKey";
            _cbKey.Size = new System.Drawing.Size(192, 28);
            _cbKey.TabIndex = 4;
            // 
            // chordShapeVMBindingSource
            // 
            chordShapeVMBindingSource.DataSource = typeof(Domain.ChordShapeVM);
            // 
            // NeckControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pnlNeck);
            DataBindings.Add(new System.Windows.Forms.Binding("DataContext", chordShapeVMBindingSource, "", true));
            Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            Name = "NeckControl";
            Size = new System.Drawing.Size(1368, 334);
            MouseMove += NeckControl_MouseMove;
            pnlNeck.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlKey.ResumeLayout(false);
            pnlKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chordShapeVMBindingSource).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Panel pnlNeck;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlKey;
        private System.Windows.Forms.Button _bnAddItem;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.ComboBox _cbKey;
        private System.Windows.Forms.BindingSource chordShapeVMBindingSource;
    }
}

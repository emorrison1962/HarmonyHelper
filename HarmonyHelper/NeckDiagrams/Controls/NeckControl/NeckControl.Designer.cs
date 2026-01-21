
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
            chordShapeVMBindingSource = new System.Windows.Forms.BindingSource(components);
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
            pnlNeck.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlNeck.Location = new System.Drawing.Point(0, 0);
            pnlNeck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlNeck.Name = "pnlNeck";
            pnlNeck.Padding = new System.Windows.Forms.Padding(32, 31, 32, 31);
            pnlNeck.Size = new System.Drawing.Size(1368, 334);
            pnlNeck.TabIndex = 4;
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
            Paint += NeckControl_Paint;
            MouseMove += NeckControl_MouseMove;
            ((System.ComponentModel.ISupportInitialize)chordShapeVMBindingSource).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Panel pnlNeck;
        private System.Windows.Forms.BindingSource chordShapeVMBindingSource;
    }
}

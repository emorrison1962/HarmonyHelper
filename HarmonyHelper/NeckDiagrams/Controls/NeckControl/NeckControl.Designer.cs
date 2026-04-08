
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
            this.components = new System.ComponentModel.Container();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.pnlNeck = new System.Windows.Forms.Panel();
            this.chordShapeVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)this.chordShapeVMBindingSource).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += this.printDocument_BeginPrint;
            this.printDocument.EndPrint += this.printDocument_EndPrint;
            this.printDocument.PrintPage += this.printDocument_PrintPage;
            this.printDocument.QueryPageSettings += this.printDocument_QueryPageSettings;
            // 
            // pnlNeck
            // 
            this.pnlNeck.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNeck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNeck.Location = new System.Drawing.Point(0, 0);
            this.pnlNeck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlNeck.Name = "pnlNeck";
            this.pnlNeck.Padding = new System.Windows.Forms.Padding(32, 31, 32, 31);
            this.pnlNeck.Size = new System.Drawing.Size(1368, 334);
            this.pnlNeck.TabIndex = 4;
            // 
            // chordShapeVMBindingSource
            // 
            this.chordShapeVMBindingSource.DataSource = typeof(Domain.ChordShapeVM);
            // 
            // NeckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNeck);
            this.DataBindings.Add(new System.Windows.Forms.Binding("DataContext", this.chordShapeVMBindingSource, "", true));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "NeckControl";
            this.Size = new System.Drawing.Size(1368, 334);
            this.Paint += this.NeckControl_Paint;
            this.MouseMove += this.NeckControl_MouseMove;
            ((System.ComponentModel.ISupportInitialize)this.chordShapeVMBindingSource).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Panel pnlNeck;
        private System.Windows.Forms.BindingSource chordShapeVMBindingSource;
    }
}

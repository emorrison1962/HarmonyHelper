namespace NeckDiagrams.Feature_Controls
{
    partial class ManufakturaSandboxControl
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
            this._noteViewer = new Manufaktura.Controls.WinForms.NoteViewer();
            this.SuspendLayout();
            // 
            // _noteViewer
            // 
            this._noteViewer.DataSource = null;
            this._noteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._noteViewer.Location = new System.Drawing.Point(0, 0);
            this._noteViewer.Name = "_noteViewer";
            this._noteViewer.RenderingMode = Manufaktura.Controls.Rendering.ScoreRenderingModes.AllPages;
            this._noteViewer.Size = new System.Drawing.Size(1172, 596);
            this._noteViewer.TabIndex = 0;
            this._noteViewer.Text = "noteViewer1";
            // 
            // ManufakturaSandboxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._noteViewer);
            this.Name = "ManufakturaSandboxControl";
            this.Size = new System.Drawing.Size(1172, 596);
            this.ResumeLayout(false);

        }

        #endregion

        private Manufaktura.Controls.WinForms.NoteViewer _noteViewer;
    }
}

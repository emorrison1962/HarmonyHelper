namespace NeckDiagrams.Controls
{
    partial class TonnetzControl
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
            this.SuspendLayout();
            // 
            // TonnetzControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TonnetzControl";
            this.Size = new System.Drawing.Size(1050, 492);
            this.Load += this.TonnetzControl_Load;
            this.SizeChanged += this.TonnetzControl_SizeChanged;
            this.Paint += this.TonnetzControl_Paint;
            this.MouseClick += this.TonnetzPanel_MouseClick;
            this.ResumeLayout(false);
        }

        #endregion
    }
}

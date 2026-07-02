namespace NeckDiagrams.Views
{
    partial class TonnetzView
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
            this.tonnetzControl1 = new NeckDiagrams.Controls.TonnetzControl();
            this.SuspendLayout();
            // 
            // tonnetzControl1
            // 
            this.tonnetzControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tonnetzControl1.Location = new System.Drawing.Point(0, 0);
            this.tonnetzControl1.Name = "tonnetzControl1";
            this.tonnetzControl1.Size = new System.Drawing.Size(1645, 667);
            this.tonnetzControl1.TabIndex = 0;
            // 
            // SandBoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tonnetzControl1);
            this.Name = "TonnetzView";
            this.Size = new System.Drawing.Size(1645, 667);
            this.ResumeLayout(false);
        }

        #endregion

        private Controls.TonnetzControl tonnetzControl1;
    }
}

namespace HarmonyHelperControls.WinForms
{
    partial class Score
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
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Score";
            this.Size = new System.Drawing.Size(1000, 400);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Score_Paint);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Score_Layout);
            this.Resize += new System.EventHandler(this.Score_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

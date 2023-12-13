namespace NeckDiagrams.Controls
{
    partial class ReHarmonizerControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._bnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ReHarmonizer";
            // 
            // _bnOpen
            // 
            this._bnOpen.Location = new System.Drawing.Point(200, 225);
            this._bnOpen.Name = "_bnOpen";
            this._bnOpen.Size = new System.Drawing.Size(112, 34);
            this._bnOpen.TabIndex = 2;
            this._bnOpen.Text = "Open...";
            this._bnOpen.UseVisualStyleBackColor = true;
            this._bnOpen.Click += new System.EventHandler(this._bnOpen_Click);
            // 
            // ReHarmonizerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._bnOpen);
            this.Controls.Add(this.label1);
            this.Name = "ReHarmonizerControl";
            this.Size = new System.Drawing.Size(1000, 614);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _bnOpen;
    }
}

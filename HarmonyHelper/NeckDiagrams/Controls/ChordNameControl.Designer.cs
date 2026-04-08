namespace NeckDiagrams.Controls
{
    partial class ChordNameControl
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
            this.lblChordName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChordName
            // 
            this.lblChordName.AutoSize = true;
            this.lblChordName.BackColor = System.Drawing.SystemColors.Control;
            this.lblChordName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChordName.Location = new System.Drawing.Point(0, 0);
            this.lblChordName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblChordName.Name = "lblChordName";
            this.lblChordName.Size = new System.Drawing.Size(113, 24);
            this.lblChordName.TabIndex = 0;
            this.lblChordName.Text = "ChordName";
            this.lblChordName.UseMnemonic = false;
            this.lblChordName.Click += this._MouseClick;
            this.lblChordName.MouseDown += this.lblChordName_MouseDown;
            // 
            // ChordNameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblChordName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "ChordNameControl";
            this.Size = new System.Drawing.Size(254, 46);
            this.Click += this._MouseClick;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChordName;
    }
}

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
            this.lblChordName = new Label();
            this.SuspendLayout();
            // 
            // lblChordName
            // 
            this.lblChordName.AutoSize = true;
            this.lblChordName.BackColor = SystemColors.Control;
            this.lblChordName.Dock = DockStyle.Fill;
            this.lblChordName.Location = new Point(0, 0);
            this.lblChordName.Margin = new Padding(5, 0, 5, 0);
            this.lblChordName.Name = "lblChordName";
            this.lblChordName.Size = new Size(144, 29);
            this.lblChordName.TabIndex = 0;
            this.lblChordName.Text = "ChordName";
            this.lblChordName.UseMnemonic = false;
            // 
            // ChordNameControl
            // 
            this.AutoScaleDimensions = new SizeF(14F, 29F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblChordName);
            this.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this.Margin = new Padding(5, 6, 5, 6);
            this.Name = "ChordNameControl";
            this.Size = new Size(254, 46);
            this.Paint += this.ChordNameControl_Paint;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblChordName;
    }
}

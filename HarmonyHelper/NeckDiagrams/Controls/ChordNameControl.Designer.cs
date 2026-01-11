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
            lblChordName = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lblChordName
            // 
            lblChordName.AutoSize = true;
            lblChordName.BackColor = System.Drawing.SystemColors.Control;
            lblChordName.Dock = System.Windows.Forms.DockStyle.Fill;
            lblChordName.Location = new System.Drawing.Point(0, 0);
            lblChordName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            lblChordName.Name = "lblChordName";
            lblChordName.Size = new System.Drawing.Size(113, 24);
            lblChordName.TabIndex = 0;
            lblChordName.Text = "ChordName";
            lblChordName.UseMnemonic = false;
            // 
            // ChordNameControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(lblChordName);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "ChordNameControl";
            Size = new System.Drawing.Size(254, 46);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChordName;
    }
}

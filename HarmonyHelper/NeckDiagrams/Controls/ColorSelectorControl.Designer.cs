namespace NeckDiagrams.Controls
{
    partial class ColorSelectorControl
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
            bnColor = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            lblChordTone = new System.Windows.Forms.Label();
            dlgColor = new System.Windows.Forms.ColorDialog();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // bnColor
            // 
            bnColor.Dock = System.Windows.Forms.DockStyle.Right;
            bnColor.Location = new System.Drawing.Point(447, 0);
            bnColor.Name = "bnColor";
            bnColor.Size = new System.Drawing.Size(87, 30);
            bnColor.TabIndex = 1;
            bnColor.Text = "Color...";
            bnColor.UseVisualStyleBackColor = true;
            bnColor.Click += bnColor_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblChordTone);
            panel1.Controls.Add(bnColor);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(534, 30);
            panel1.TabIndex = 2;
            // 
            // lblChordTone
            // 
            lblChordTone.CausesValidation = false;
            lblChordTone.Dock = System.Windows.Forms.DockStyle.Fill;
            lblChordTone.Location = new System.Drawing.Point(0, 0);
            lblChordTone.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            lblChordTone.Name = "lblChordTone";
            lblChordTone.Size = new System.Drawing.Size(447, 30);
            lblChordTone.TabIndex = 2;
            lblChordTone.Text = "label1";
            lblChordTone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlgColor
            // 
            dlgColor.AllowFullOpen = false;
            dlgColor.AnyColor = true;
            // 
            // ColorSelectorControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ColorSelectorControl";
            Size = new System.Drawing.Size(534, 30);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button bnColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.Label lblChordTone;
    }
}

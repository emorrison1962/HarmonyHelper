namespace NeckDiagrams.Controls
{
    partial class ChordsControl
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
            this.chordsPanel = new System.Windows.Forms.Panel();
            this.chordsEditPanel = new System.Windows.Forms.Panel();
            this._tbChords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chordsTablePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chordsPanel.SuspendLayout();
            this.chordsEditPanel.SuspendLayout();
            this.chordsTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chordsPanel
            // 
            this.chordsPanel.Controls.Add(this.chordsEditPanel);
            this.chordsPanel.Controls.Add(this.chordsTablePanel);
            this.chordsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chordsPanel.Location = new System.Drawing.Point(0, 0);
            this.chordsPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chordsPanel.Name = "chordsPanel";
            this.chordsPanel.Size = new System.Drawing.Size(1043, 28);
            this.chordsPanel.TabIndex = 5;
            // 
            // chordsEditPanel
            // 
            this.chordsEditPanel.Controls.Add(this._tbChords);
            this.chordsEditPanel.Controls.Add(this.label2);
            this.chordsEditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chordsEditPanel.Location = new System.Drawing.Point(0, 0);
            this.chordsEditPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chordsEditPanel.Name = "chordsEditPanel";
            this.chordsEditPanel.Size = new System.Drawing.Size(1043, 28);
            this.chordsEditPanel.TabIndex = 2;
            // 
            // _tbChords
            // 
            this._tbChords.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbChords.Location = new System.Drawing.Point(62, 0);
            this._tbChords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._tbChords.Name = "_tbChords";
            this._tbChords.Size = new System.Drawing.Size(981, 27);
            this._tbChords.TabIndex = 0;
            this._tbChords.Click += this._tbChords_Click;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chords: ";
            // 
            // chordsTablePanel
            // 
            this.chordsTablePanel.Controls.Add(this.label3);
            this.chordsTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chordsTablePanel.Location = new System.Drawing.Point(0, 0);
            this.chordsTablePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chordsTablePanel.Name = "chordsTablePanel";
            this.chordsTablePanel.Size = new System.Drawing.Size(1043, 28);
            this.chordsTablePanel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chords: ";
            // 
            // ChordsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chordsPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChordsControl";
            this.Size = new System.Drawing.Size(1043, 28);
            this.chordsPanel.ResumeLayout(false);
            this.chordsEditPanel.ResumeLayout(false);
            this.chordsEditPanel.PerformLayout();
            this.chordsTablePanel.ResumeLayout(false);
            this.chordsTablePanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel chordsPanel;
        private System.Windows.Forms.Panel chordsEditPanel;
        private System.Windows.Forms.TextBox _tbChords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel chordsTablePanel;
        private System.Windows.Forms.Label label3;
    }
}

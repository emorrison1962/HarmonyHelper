namespace NeckDiagrams
{
    partial class ChordParserDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.chordsEditPanel = new System.Windows.Forms.Panel();
            this._tbChords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chordsDisplayPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.bnOk = new System.Windows.Forms.Button();
            this.bnParse = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.chordsEditPanel.SuspendLayout();
            this.chordsDisplayPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.chordsEditPanel);
            this.mainPanel.Controls.Add(this.chordsDisplayPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 6;
            // 
            // chordsEditPanel
            // 
            this.chordsEditPanel.Controls.Add(this._tbChords);
            this.chordsEditPanel.Controls.Add(this.label2);
            this.chordsEditPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chordsEditPanel.Location = new System.Drawing.Point(0, 0);
            this.chordsEditPanel.Name = "chordsEditPanel";
            this.chordsEditPanel.Size = new System.Drawing.Size(800, 200);
            this.chordsEditPanel.TabIndex = 2;
            // 
            // _tbChords
            // 
            this._tbChords.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbChords.Location = new System.Drawing.Point(56, 0);
            this._tbChords.Multiline = true;
            this._tbChords.Name = "_tbChords";
            this._tbChords.Size = new System.Drawing.Size(744, 200);
            this._tbChords.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chords: ";
            // 
            // chordsDisplayPanel
            // 
            this.chordsDisplayPanel.Controls.Add(this.label3);
            this.chordsDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chordsDisplayPanel.Location = new System.Drawing.Point(0, 0);
            this.chordsDisplayPanel.Name = "chordsDisplayPanel";
            this.chordsDisplayPanel.Size = new System.Drawing.Size(800, 450);
            this.chordsDisplayPanel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chords: ";
            // 
            // bnOk
            // 
            this.bnOk.Location = new System.Drawing.Point(713, 415);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(75, 23);
            this.bnOk.TabIndex = 7;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnParse
            // 
            this.bnParse.Location = new System.Drawing.Point(632, 415);
            this.bnParse.Name = "bnParse";
            this.bnParse.Size = new System.Drawing.Size(75, 23);
            this.bnParse.TabIndex = 8;
            this.bnParse.Text = "Parse";
            this.bnParse.UseVisualStyleBackColor = true;
            // 
            // ChordParserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bnParse);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.mainPanel);
            this.Name = "ChordParserDialog";
            this.Text = "ChordParserDialog";
            this.mainPanel.ResumeLayout(false);
            this.chordsEditPanel.ResumeLayout(false);
            this.chordsEditPanel.PerformLayout();
            this.chordsDisplayPanel.ResumeLayout(false);
            this.chordsDisplayPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel chordsEditPanel;
        private System.Windows.Forms.TextBox _tbChords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel chordsDisplayPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnParse;
    }
}
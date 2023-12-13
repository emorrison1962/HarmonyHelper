namespace NeckDiagrams.Feature_Controls
{
    partial class ScoreControl_Scratchpad
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
            this._ctlScore = new HarmonyHelperControls.WinForms.Score();
            this._rtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _ctlScore
            // 
            this._ctlScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctlScore.Location = new System.Drawing.Point(32, 32);
            this._ctlScore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._ctlScore.Name = "_ctlScore";
            this._ctlScore.Size = new System.Drawing.Size(1015, 526);
            this._ctlScore.TabIndex = 0;
            // 
            // _rtb
            // 
            this._rtb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._rtb.Font = new System.Drawing.Font("Polihymnia", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._rtb.Location = new System.Drawing.Point(32, 500);
            this._rtb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._rtb.Name = "_rtb";
            this._rtb.Size = new System.Drawing.Size(1015, 58);
            this._rtb.TabIndex = 1;
            this._rtb.Text = "";
            // 
            // ScoreControl_Scratchpad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this._rtb);
            this.Controls.Add(this._ctlScore);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ScoreControl_Scratchpad";
            this.Padding = new System.Windows.Forms.Padding(32, 32, 32, 0);
            this.Size = new System.Drawing.Size(1079, 558);
            this.ResumeLayout(false);
        }

        #endregion

        private HarmonyHelperControls.WinForms.Score _ctlScore;
        private System.Windows.Forms.RichTextBox _rtb;
    }
}

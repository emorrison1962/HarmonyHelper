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
            this.SuspendLayout();
            // 
            // score1
            // 
            this._ctlScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctlScore.Location = new System.Drawing.Point(0, 0);
            this._ctlScore.Name = "score1";
            this._ctlScore.Size = new System.Drawing.Size(1000, 400);
            this._ctlScore.TabIndex = 0;
            // 
            // ScoreControl_Scratchpad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ctlScore);
            this.Name = "ScoreControl_Scratchpad";
            this.Size = new System.Drawing.Size(1000, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private HarmonyHelperControls.WinForms.Score _ctlScore;
    }
}

namespace NeckDiagrams.Controls
{
    partial class HarmonicAnalysisTab
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

        //this = new System.Windows.Forms.TabPage();


        #region Component Designer generated code
            // 
            // harmonicAnalysisControl1
            // 


        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.harmonicAnalysisControl1 = new NeckDiagrams.Controls.HarmonicAnalysisControl();
            this.SuspendLayout();
            // 
            // harmonicAnalysisControl1
            // 
            this.harmonicAnalysisControl1.AutoSize = true;
            this.harmonicAnalysisControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.harmonicAnalysisControl1.Location = new System.Drawing.Point(3, 3);
            this.harmonicAnalysisControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.harmonicAnalysisControl1.Name = "harmonicAnalysisControl1";
            this.harmonicAnalysisControl1.Size = new System.Drawing.Size(987, 492);
            this.harmonicAnalysisControl1.TabIndex = 1;
            // 
            // HarmonicAnalysisTab
            // 
            this.Controls.Add(this.harmonicAnalysisControl1);
            this.Location = new System.Drawing.Point(4, 25);
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(993, 498);
            this.TabIndex = 2;
            this.Text = "Analyzer";
            this.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);
            this.PerformLayout();
            this.harmonicAnalysisControl1.ResumeLayout(false);


        }

        #endregion

        private Controls.HarmonicAnalysisControl harmonicAnalysisControl1;


    }
}

namespace CharMapEx
{
    partial class CharMapExForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._cbFonts = new System.Windows.Forms.ComboBox();
            this._pnlMain = new System.Windows.Forms.Panel();
            this._runesControl = new NeckDiagrams.Controls.RunesControl();
            this._pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cbFonts
            // 
            this._cbFonts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._cbFonts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cbFonts.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbFonts.FormattingEnabled = true;
            this._cbFonts.Location = new System.Drawing.Point(0, 0);
            this._cbFonts.Margin = new System.Windows.Forms.Padding(4);
            this._cbFonts.Name = "_cbFonts";
            this._cbFonts.Size = new System.Drawing.Size(1000, 33);
            this._cbFonts.TabIndex = 0;
            this._cbFonts.SelectedIndexChanged += new System.EventHandler(this._cbFonts_SelectedIndexChanged);
            // 
            // _pnlMain
            // 
            this._pnlMain.AutoScroll = true;
            this._pnlMain.Controls.Add(this._runesControl);
            this._pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMain.Location = new System.Drawing.Point(0, 33);
            this._pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(1000, 529);
            this._pnlMain.TabIndex = 1;
            // 
            // runesControl1
            // 
            this._runesControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._runesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._runesControl.FontProvider = null;
            this._runesControl.Location = new System.Drawing.Point(0, 0);
            this._runesControl.Margin = new System.Windows.Forms.Padding(4);
            this._runesControl.Name = "runesControl1";
            this._runesControl.SelectedFont = null;
            this._runesControl.Size = new System.Drawing.Size(1000, 529);
            this._runesControl.TabIndex = 0;
            // 
            // CharMapExForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this._pnlMain);
            this.Controls.Add(this._cbFonts);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CharMapExForm";
            this.Text = "Form1";
            this._pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox _cbFonts;
        private Panel _pnlMain;
        private NeckDiagrams.Controls.RunesControl _grid;
        private NeckDiagrams.Controls.RunesControl _runesControl;
    }
}
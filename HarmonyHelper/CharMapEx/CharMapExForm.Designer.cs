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
            this._cbFonts = new ComboBox();
            this._pnlMain = new Panel();
            this._grid = new NeckDiagrams.Controls.ChordNamesControl();
            this._pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cbFonts
            // 
            this._cbFonts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this._cbFonts.AutoCompleteSource = AutoCompleteSource.ListItems;
            this._cbFonts.Dock = DockStyle.Top;
            this._cbFonts.FormattingEnabled = true;
            this._cbFonts.Location = new Point(0, 0);
            this._cbFonts.Name = "_cbFonts";
            this._cbFonts.Size = new Size(800, 28);
            this._cbFonts.TabIndex = 0;
            this._cbFonts.SelectedIndexChanged += this._cbFonts_SelectedIndexChanged;
            // 
            // _pnlMain
            // 
            this._pnlMain.AutoScroll = true;
            this._pnlMain.Controls.Add(this._grid);
            this._pnlMain.Dock = DockStyle.Fill;
            this._pnlMain.Location = new Point(0, 28);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new Size(800, 422);
            this._pnlMain.TabIndex = 1;
            // 
            // _grid
            // 
            this._grid.BorderStyle = BorderStyle.FixedSingle;
            this._grid.Dock = DockStyle.Fill;
            this._grid.Location = new Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.Size = new Size(800, 422);
            this._grid.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this._pnlMain);
            this.Controls.Add(this._cbFonts);
            this.Name = "Form1";
            this.Text = "Form1";
            this._pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private ComboBox _cbFonts;
        private Panel _pnlMain;
        private NeckDiagrams.Controls.ChordNamesControl _grid;
    }
}
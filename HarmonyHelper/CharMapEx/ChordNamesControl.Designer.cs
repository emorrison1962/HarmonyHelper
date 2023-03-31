namespace NeckDiagrams.Controls
{
    partial class ChordNamesControl
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
            this._chordNamesTablePanel = new TableLayoutPanel();
            this.SuspendLayout();
            // 
            // _chordNamesTablePanel
            // 
            this._chordNamesTablePanel.ColumnCount = 16;
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.ColumnStyles.Add(new ColumnStyle());
            this._chordNamesTablePanel.Dock = DockStyle.Fill;
            this._chordNamesTablePanel.Location = new Point(0, 0);
            this._chordNamesTablePanel.Margin = new Padding(3, 4, 3, 4);
            this._chordNamesTablePanel.Name = "_chordNamesTablePanel";
            this._chordNamesTablePanel.Size = new Size(659, 465);
            this._chordNamesTablePanel.TabIndex = 5;
            // 
            // ChordNamesControl
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this._chordNamesTablePanel);
            this.Name = "ChordNamesControl";
            this.Size = new Size(659, 465);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _chordNamesTablePanel;
    }
}

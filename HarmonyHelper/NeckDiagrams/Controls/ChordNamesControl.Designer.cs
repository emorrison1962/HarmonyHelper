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
            this._chordNamesTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // _chordNamesTablePanel
            // 
            this._chordNamesTablePanel.ColumnCount = 8;
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._chordNamesTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chordNamesTablePanel.Location = new System.Drawing.Point(0, 0);
            this._chordNamesTablePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chordNamesTablePanel.Name = "_chordNamesTablePanel";
            this._chordNamesTablePanel.Size = new System.Drawing.Size(743, 467);
            this._chordNamesTablePanel.TabIndex = 5;
            // 
            // ChordNamesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._chordNamesTablePanel);
            this.Name = "ChordNamesControl";
            this.Size = new System.Drawing.Size(743, 467);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordNamesControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChordNamesControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordNamesControl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _chordNamesTablePanel;
    }
}

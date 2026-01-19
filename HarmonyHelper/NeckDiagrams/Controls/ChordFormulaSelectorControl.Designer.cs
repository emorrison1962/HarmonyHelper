
namespace NeckDiagrams
{
    partial class ChordFormulaSelectorControl
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
            arpPanel = new System.Windows.Forms.Panel();
            _cbChordType = new System.Windows.Forms.ComboBox();
            _chordNoteNameCombo = new NoteNameComboBox();
            label3 = new System.Windows.Forms.Label();
            arpPanel.SuspendLayout();
            SuspendLayout();
            // 
            // arpPanel
            // 
            arpPanel.Controls.Add(_cbChordType);
            arpPanel.Controls.Add(_chordNoteNameCombo);
            arpPanel.Controls.Add(label3);
            arpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            arpPanel.Location = new System.Drawing.Point(0, 0);
            arpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            arpPanel.Name = "arpPanel";
            arpPanel.Size = new System.Drawing.Size(376, 32);
            arpPanel.TabIndex = 22;
            // 
            // _cbChordType
            // 
            _cbChordType.Dock = System.Windows.Forms.DockStyle.Fill;
            _cbChordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _cbChordType.DropDownWidth = 300;
            _cbChordType.FormattingEnabled = true;
            _cbChordType.Location = new System.Drawing.Point(139, 0);
            _cbChordType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            _cbChordType.MaxDropDownItems = 100;
            _cbChordType.Name = "_cbChordType";
            _cbChordType.Size = new System.Drawing.Size(237, 28);
            _cbChordType.TabIndex = 18;
            _cbChordType.SelectedValueChanged += _cbChordType_SelectedValueChanged;
            // 
            // _chordNoteNameCombo
            // 
            _chordNoteNameCombo.Dock = System.Windows.Forms.DockStyle.Left;
            _chordNoteNameCombo.Location = new System.Drawing.Point(87, 0);
            _chordNoteNameCombo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            _chordNoteNameCombo.Name = "_chordNoteNameCombo";
            _chordNoteNameCombo.Size = new System.Drawing.Size(52, 32);
            _chordNoteNameCombo.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Left;
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label3.Size = new System.Drawing.Size(87, 25);
            label3.TabIndex = 12;
            label3.Text = "Chord Type:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChordTypeSelectorControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(arpPanel);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "ChordTypeSelectorControl";
            Size = new System.Drawing.Size(376, 32);
            arpPanel.ResumeLayout(false);
            arpPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel arpPanel;
        private System.Windows.Forms.ComboBox _cbChordType;
        private NoteNameComboBox _chordNoteNameCombo;
        private System.Windows.Forms.Label label3;
    }
}

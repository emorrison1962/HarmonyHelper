namespace NeckDiagrams.Views
{
    partial class ChordShapeControl
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
            ctlNeck = new NeckControl();
            pnlTop = new System.Windows.Forms.Panel();
            ctlChordTypeSelectorControl = new ChordTypeSelectorControl();
            comboNoteNameComboBox = new NoteNameComboBox();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // ctlNeck
            // 
            ctlNeck.Location = new System.Drawing.Point(275, 139);
            ctlNeck.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            ctlNeck.Name = "ctlNeck";
            ctlNeck.Size = new System.Drawing.Size(1368, 597);
            ctlNeck.TabIndex = 0;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(ctlChordTypeSelectorControl);
            pnlTop.Controls.Add(comboNoteNameComboBox);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1915, 87);
            pnlTop.TabIndex = 1;
            // 
            // ctlChordTypeSelectorControl
            // 
            ctlChordTypeSelectorControl.Location = new System.Drawing.Point(545, 36);
            ctlChordTypeSelectorControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ctlChordTypeSelectorControl.Name = "ctlChordTypeSelectorControl";
            ctlChordTypeSelectorControl.NoteName = null;
            ctlChordTypeSelectorControl.SelectedItem = null;
            ctlChordTypeSelectorControl.Size = new System.Drawing.Size(376, 32);
            ctlChordTypeSelectorControl.TabIndex = 1;
            // 
            // comboNoteNameComboBox
            // 
            comboNoteNameComboBox.Location = new System.Drawing.Point(282, 31);
            comboNoteNameComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            comboNoteNameComboBox.Name = "comboNoteNameComboBox";
            comboNoteNameComboBox.Size = new System.Drawing.Size(200, 32);
            comboNoteNameComboBox.TabIndex = 0;
            // 
            // ChordShapeControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pnlTop);
            Controls.Add(ctlNeck);
            Name = "ChordShapeControl";
            Size = new System.Drawing.Size(1915, 1169);
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private NeckControl ctlNeck;
        private System.Windows.Forms.Panel pnlTop;
        private NoteNameComboBox comboNoteNameComboBox;
        private ChordTypeSelectorControl ctlChordTypeSelectorControl;
    }
}

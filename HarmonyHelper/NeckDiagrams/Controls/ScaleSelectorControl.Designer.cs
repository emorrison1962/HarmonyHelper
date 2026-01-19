
namespace NeckDiagrams
{
    partial class ScaleSelectorControl
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
            scalePanel = new System.Windows.Forms.Panel();
            _cbScaleType = new System.Windows.Forms.ComboBox();
            _scaleNoteNameCombo = new NoteNameComboBox();
            label2 = new System.Windows.Forms.Label();
            scalePanel.SuspendLayout();
            SuspendLayout();
            // 
            // scalePanel
            // 
            scalePanel.Controls.Add(_cbScaleType);
            scalePanel.Controls.Add(_scaleNoteNameCombo);
            scalePanel.Controls.Add(label2);
            scalePanel.Dock = System.Windows.Forms.DockStyle.Top;
            scalePanel.Location = new System.Drawing.Point(0, 0);
            scalePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            scalePanel.Name = "scalePanel";
            scalePanel.Size = new System.Drawing.Size(376, 32);
            scalePanel.TabIndex = 21;
            // 
            // _cbScaleType
            // 
            _cbScaleType.Dock = System.Windows.Forms.DockStyle.Fill;
            _cbScaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _cbScaleType.DropDownWidth = 300;
            _cbScaleType.FormattingEnabled = true;
            _cbScaleType.Location = new System.Drawing.Point(134, 0);
            _cbScaleType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            _cbScaleType.MaxDropDownItems = 100;
            _cbScaleType.Name = "_cbScaleType";
            _cbScaleType.Size = new System.Drawing.Size(242, 28);
            _cbScaleType.TabIndex = 19;
            _cbScaleType.SelectedValueChanged += _cbScaleType_SelectedValueChanged;
            // 
            // _scaleNoteNameCombo
            // 
            _scaleNoteNameCombo.Dock = System.Windows.Forms.DockStyle.Left;
            _scaleNoteNameCombo.Location = new System.Drawing.Point(82, 0);
            _scaleNoteNameCombo.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            _scaleNoteNameCombo.Name = "_scaleNoteNameCombo";
            _scaleNoteNameCombo.SelectedNoteName = null;
            _scaleNoteNameCombo.Size = new System.Drawing.Size(52, 32);
            _scaleNoteNameCombo.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Left;
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            label2.Size = new System.Drawing.Size(82, 25);
            label2.TabIndex = 13;
            label2.Text = "Scale Type:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ScaleSelectorControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(scalePanel);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "ScaleSelectorControl";
            Size = new System.Drawing.Size(376, 32);
            scalePanel.ResumeLayout(false);
            scalePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel scalePanel;
        private System.Windows.Forms.ComboBox _cbScaleType;
        private NoteNameComboBox _scaleNoteNameCombo;
        private System.Windows.Forms.Label label2;
    }
}

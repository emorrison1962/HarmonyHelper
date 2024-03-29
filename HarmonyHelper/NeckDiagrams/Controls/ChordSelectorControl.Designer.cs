﻿
namespace NeckDiagrams
{
	partial class ChordSelectorControl
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
            this.arpPanel = new System.Windows.Forms.Panel();
            this._cbChordType = new System.Windows.Forms.ComboBox();
            this._chordNoteNameCombo = new NeckDiagrams.NoteNameComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.arpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // arpPanel
            // 
            this.arpPanel.Controls.Add(this._cbChordType);
            this.arpPanel.Controls.Add(this._chordNoteNameCombo);
            this.arpPanel.Controls.Add(this.label3);
            this.arpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.arpPanel.Location = new System.Drawing.Point(0, 0);
            this.arpPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.arpPanel.Name = "arpPanel";
            this.arpPanel.Size = new System.Drawing.Size(376, 26);
            this.arpPanel.TabIndex = 22;
            // 
            // _cbChordType
            // 
            this._cbChordType.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbChordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbChordType.DropDownWidth = 300;
            this._cbChordType.FormattingEnabled = true;
            this._cbChordType.Location = new System.Drawing.Point(133, 0);
            this._cbChordType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._cbChordType.MaxDropDownItems = 100;
            this._cbChordType.Name = "_cbChordType";
            this._cbChordType.Size = new System.Drawing.Size(243, 24);
            this._cbChordType.TabIndex = 18;
            this._cbChordType.SelectedValueChanged += new System.EventHandler(this._cbChordType_SelectedValueChanged);
            // 
            // _chordNoteNameCombo
            // 
            this._chordNoteNameCombo.Dock = System.Windows.Forms.DockStyle.Left;
            this._chordNoteNameCombo.Location = new System.Drawing.Point(81, 0);
            this._chordNoteNameCombo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this._chordNoteNameCombo.Name = "_chordNoteNameCombo";
            this._chordNoteNameCombo.SelectedNoteName = null;
            this._chordNoteNameCombo.Size = new System.Drawing.Size(52, 26);
            this._chordNoteNameCombo.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Chord Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChordSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.arpPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChordSelectorControl";
            this.Size = new System.Drawing.Size(376, 26);
            this.arpPanel.ResumeLayout(false);
            this.arpPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel arpPanel;
		private System.Windows.Forms.ComboBox _cbChordType;
		private NoteNameComboBox _chordNoteNameCombo;
		private System.Windows.Forms.Label label3;
	}
}

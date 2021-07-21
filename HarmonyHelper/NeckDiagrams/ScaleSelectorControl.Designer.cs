
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
			this.scalePanel = new System.Windows.Forms.Panel();
			this._cbScaleType = new System.Windows.Forms.ComboBox();
			this._scaleNoteNameCombo = new NeckDiagrams.NoteNameComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.scalePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// scalePanel
			// 
			this.scalePanel.Controls.Add(this._cbScaleType);
			this.scalePanel.Controls.Add(this._scaleNoteNameCombo);
			this.scalePanel.Controls.Add(this.label2);
			this.scalePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.scalePanel.Location = new System.Drawing.Point(0, 0);
			this.scalePanel.Name = "scalePanel";
			this.scalePanel.Size = new System.Drawing.Size(282, 21);
			this.scalePanel.TabIndex = 21;
			// 
			// _cbScaleType
			// 
			this._cbScaleType.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cbScaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cbScaleType.DropDownWidth = 300;
			this._cbScaleType.FormattingEnabled = true;
			this._cbScaleType.Location = new System.Drawing.Point(103, 0);
			this._cbScaleType.MaxDropDownItems = 100;
			this._cbScaleType.Name = "_cbScaleType";
			this._cbScaleType.Size = new System.Drawing.Size(179, 21);
			this._cbScaleType.TabIndex = 19;
			this._cbScaleType.SelectedValueChanged += new System.EventHandler(this._cbScaleType_SelectedValueChanged);
			// 
			// _scaleNoteNameCombo
			// 
			this._scaleNoteNameCombo.Dock = System.Windows.Forms.DockStyle.Left;
			this._scaleNoteNameCombo.Location = new System.Drawing.Point(64, 0);
			this._scaleNoteNameCombo.Name = "_scaleNoteNameCombo";
			this._scaleNoteNameCombo.Size = new System.Drawing.Size(39, 21);
			this._scaleNoteNameCombo.TabIndex = 18;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Scale Type:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ScaleSelectorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.scalePanel);
			this.Name = "ScaleSelectorControl";
			this.Size = new System.Drawing.Size(282, 21);
			this.scalePanel.ResumeLayout(false);
			this.scalePanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel scalePanel;
		private System.Windows.Forms.ComboBox _cbScaleType;
		private NoteNameComboBox _scaleNoteNameCombo;
		private System.Windows.Forms.Label label2;
	}
}

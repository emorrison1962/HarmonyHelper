
namespace NeckDiagrams
{
	partial class ModelItemControl
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.colorPanel = new System.Windows.Forms.Panel();
			this._cbVisible = new System.Windows.Forms.CheckBox();
			this.scaleSelectorControl = new NeckDiagrams.ScaleSelectorControl();
			this.chordSelectorControl = new NeckDiagrams.ChordTypeSelectorControl();
			this._panelRadioButtons = new System.Windows.Forms.Panel();
			this._rbArpeggio = new System.Windows.Forms.RadioButton();
			this._rbScale = new System.Windows.Forms.RadioButton();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this._colorSwatch = new System.Windows.Forms.Panel();
			this._bnColor = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox.SuspendLayout();
			this.colorPanel.SuspendLayout();
			this._panelRadioButtons.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.colorPanel);
			this.groupBox.Controls.Add(this.scaleSelectorControl);
			this.groupBox.Controls.Add(this.chordSelectorControl);
			this.groupBox.Controls.Add(this._panelRadioButtons);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Margin = new System.Windows.Forms.Padding(10);
			this.groupBox.Name = "groupBox";
			this.groupBox.Padding = new System.Windows.Forms.Padding(7, 3, 3, 3);
			this.groupBox.Size = new System.Drawing.Size(241, 110);
			this.groupBox.TabIndex = 18;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "groupBox1";
			// 
			// colorPanel
			// 
			this.colorPanel.Controls.Add(this.panel1);
			this.colorPanel.Controls.Add(this._cbVisible);
			this.colorPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorPanel.Location = new System.Drawing.Point(7, 81);
			this.colorPanel.Name = "colorPanel";
			this.colorPanel.Size = new System.Drawing.Size(231, 21);
			this.colorPanel.TabIndex = 27;
			// 
			// _cbVisible
			// 
			this._cbVisible.AutoSize = true;
			this._cbVisible.Checked = true;
			this._cbVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			this._cbVisible.Dock = System.Windows.Forms.DockStyle.Left;
			this._cbVisible.Location = new System.Drawing.Point(0, 0);
			this._cbVisible.Name = "_cbVisible";
			this._cbVisible.Size = new System.Drawing.Size(56, 21);
			this._cbVisible.TabIndex = 25;
			this._cbVisible.Text = "Visible";
			this._cbVisible.UseVisualStyleBackColor = true;
			// 
			// scaleSelectorControl
			// 
			this.scaleSelectorControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.scaleSelectorControl.Location = new System.Drawing.Point(7, 60);
			this.scaleSelectorControl.Name = "scaleSelectorControl";
			this.scaleSelectorControl.Size = new System.Drawing.Size(231, 21);
			this.scaleSelectorControl.TabIndex = 26;
			// 
			// chordSelectorControl
			// 
			this.chordSelectorControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.chordSelectorControl.Location = new System.Drawing.Point(7, 39);
			this.chordSelectorControl.Name = "chordSelectorControl";
			this.chordSelectorControl.Size = new System.Drawing.Size(231, 21);
			this.chordSelectorControl.TabIndex = 34;
			// 
			// _panelRadioButtons
			// 
			this._panelRadioButtons.Controls.Add(this._rbArpeggio);
			this._panelRadioButtons.Controls.Add(this._rbScale);
			this._panelRadioButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this._panelRadioButtons.Location = new System.Drawing.Point(7, 16);
			this._panelRadioButtons.Name = "_panelRadioButtons";
			this._panelRadioButtons.Size = new System.Drawing.Size(231, 23);
			this._panelRadioButtons.TabIndex = 23;
			// 
			// _rbArpeggio
			// 
			this._rbArpeggio.AutoSize = true;
			this._rbArpeggio.Dock = System.Windows.Forms.DockStyle.Fill;
			this._rbArpeggio.Location = new System.Drawing.Point(52, 0);
			this._rbArpeggio.Name = "_rbArpeggio";
			this._rbArpeggio.Size = new System.Drawing.Size(179, 23);
			this._rbArpeggio.TabIndex = 20;
			this._rbArpeggio.Text = "Arpeggio";
			this._rbArpeggio.UseVisualStyleBackColor = true;
			this._rbArpeggio.CheckedChanged += new System.EventHandler(this._rbArpeggio_CheckedChanged);
			// 
			// _rbScale
			// 
			this._rbScale.AutoSize = true;
			this._rbScale.Dock = System.Windows.Forms.DockStyle.Left;
			this._rbScale.Location = new System.Drawing.Point(0, 0);
			this._rbScale.Name = "_rbScale";
			this._rbScale.Size = new System.Drawing.Size(52, 23);
			this._rbScale.TabIndex = 18;
			this._rbScale.Text = "Scale";
			this._rbScale.UseVisualStyleBackColor = true;
			this._rbScale.CheckedChanged += new System.EventHandler(this._rbScale_CheckedChanged);
			// 
			// colorDialog
			// 
			this.colorDialog.AnyColor = true;
			// 
			// _colorSwatch
			// 
			this._colorSwatch.Dock = System.Windows.Forms.DockStyle.Right;
			this._colorSwatch.Location = new System.Drawing.Point(75, 0);
			this._colorSwatch.MinimumSize = new System.Drawing.Size(21, 21);
			this._colorSwatch.Name = "_colorSwatch";
			this._colorSwatch.Size = new System.Drawing.Size(21, 21);
			this._colorSwatch.TabIndex = 31;
			// 
			// _bnColor
			// 
			this._bnColor.Dock = System.Windows.Forms.DockStyle.Right;
			this._bnColor.Location = new System.Drawing.Point(0, 0);
			this._bnColor.MinimumSize = new System.Drawing.Size(75, 21);
			this._bnColor.Name = "_bnColor";
			this._bnColor.Size = new System.Drawing.Size(75, 21);
			this._bnColor.TabIndex = 32;
			this._bnColor.Text = "Color";
			this._bnColor.UseVisualStyleBackColor = true;
			this._bnColor.Click += new System.EventHandler(this._bnColor_Click);
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this._bnColor);
			this.panel1.Controls.Add(this._colorSwatch);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(135, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(96, 21);
			this.panel1.TabIndex = 33;
			// 
			// ModelItemControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox);
			this.Name = "ModelItemControl";
			this.Size = new System.Drawing.Size(241, 110);
			this.groupBox.ResumeLayout(false);
			this.colorPanel.ResumeLayout(false);
			this.colorPanel.PerformLayout();
			this._panelRadioButtons.ResumeLayout(false);
			this._panelRadioButtons.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.RadioButton _rbArpeggio;
		private System.Windows.Forms.RadioButton _rbScale;
		private System.Windows.Forms.Panel _panelRadioButtons;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Panel colorPanel;
		private System.Windows.Forms.CheckBox _cbVisible;
		private ScaleSelectorControl scaleSelectorControl;
		private ChordTypeSelectorControl chordSelectorControl;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button _bnColor;
		private System.Windows.Forms.Panel _colorSwatch;
	}
}

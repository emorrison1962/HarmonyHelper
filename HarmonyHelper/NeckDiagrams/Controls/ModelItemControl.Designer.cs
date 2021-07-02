
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
			this._cbVisible = new System.Windows.Forms.CheckBox();
			this.scalePanel = new System.Windows.Forms.Panel();
			this._cbScaleType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.arpPanel = new System.Windows.Forms.Panel();
			this._cbChordType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this._panelRadioButtons = new System.Windows.Forms.Panel();
			this._rbArpeggio = new System.Windows.Forms.RadioButton();
			this._rbScale = new System.Windows.Forms.RadioButton();
			this._cbRoot = new System.Windows.Forms.ComboBox();
			this.groupBox.SuspendLayout();
			this.scalePanel.SuspendLayout();
			this.arpPanel.SuspendLayout();
			this._panelRadioButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this._cbVisible);
			this.groupBox.Controls.Add(this.scalePanel);
			this.groupBox.Controls.Add(this.arpPanel);
			this.groupBox.Controls.Add(this._panelRadioButtons);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Margin = new System.Windows.Forms.Padding(10);
			this.groupBox.Name = "groupBox";
			this.groupBox.Padding = new System.Windows.Forms.Padding(7, 3, 3, 3);
			this.groupBox.Size = new System.Drawing.Size(212, 110);
			this.groupBox.TabIndex = 18;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "groupBox1";
			// 
			// _cbVisible
			// 
			this._cbVisible.AutoSize = true;
			this._cbVisible.Checked = true;
			this._cbVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			this._cbVisible.Dock = System.Windows.Forms.DockStyle.Top;
			this._cbVisible.Location = new System.Drawing.Point(7, 87);
			this._cbVisible.Name = "_cbVisible";
			this._cbVisible.Size = new System.Drawing.Size(202, 17);
			this._cbVisible.TabIndex = 24;
			this._cbVisible.Text = "Visible";
			this._cbVisible.UseVisualStyleBackColor = true;
			// 
			// scalePanel
			// 
			this.scalePanel.Controls.Add(this._cbScaleType);
			this.scalePanel.Controls.Add(this.label2);
			this.scalePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.scalePanel.Location = new System.Drawing.Point(7, 66);
			this.scalePanel.Name = "scalePanel";
			this.scalePanel.Size = new System.Drawing.Size(202, 21);
			this.scalePanel.TabIndex = 20;
			// 
			// _cbScaleType
			// 
			this._cbScaleType.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cbScaleType.DropDownWidth = 300;
			this._cbScaleType.FormattingEnabled = true;
			this._cbScaleType.Location = new System.Drawing.Point(64, 0);
			this._cbScaleType.MaxDropDownItems = 100;
			this._cbScaleType.Name = "_cbScaleType";
			this._cbScaleType.Size = new System.Drawing.Size(138, 21);
			this._cbScaleType.TabIndex = 12;
			this._cbScaleType.SelectedValueChanged += new System.EventHandler(this._cbScaleType_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Scale Type:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arpPanel
			// 
			this.arpPanel.Controls.Add(this._cbRoot);
			this.arpPanel.Controls.Add(this._cbChordType);
			this.arpPanel.Controls.Add(this.label3);
			this.arpPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.arpPanel.Location = new System.Drawing.Point(7, 45);
			this.arpPanel.Name = "arpPanel";
			this.arpPanel.Size = new System.Drawing.Size(202, 21);
			this.arpPanel.TabIndex = 21;
			// 
			// _cbChordType
			// 
			this._cbChordType.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cbChordType.DropDownWidth = 300;
			this._cbChordType.FormattingEnabled = true;
			this._cbChordType.Location = new System.Drawing.Point(65, 0);
			this._cbChordType.MaxDropDownItems = 100;
			this._cbChordType.Name = "_cbChordType";
			this._cbChordType.Size = new System.Drawing.Size(137, 21);
			this._cbChordType.TabIndex = 14;
			this._cbChordType.SelectedValueChanged += new System.EventHandler(this._cbChordType_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Chord Type:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _panelRadioButtons
			// 
			this._panelRadioButtons.Controls.Add(this._rbArpeggio);
			this._panelRadioButtons.Controls.Add(this._rbScale);
			this._panelRadioButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this._panelRadioButtons.Location = new System.Drawing.Point(7, 16);
			this._panelRadioButtons.Name = "_panelRadioButtons";
			this._panelRadioButtons.Size = new System.Drawing.Size(202, 29);
			this._panelRadioButtons.TabIndex = 23;
			// 
			// _rbArpeggio
			// 
			this._rbArpeggio.AutoSize = true;
			this._rbArpeggio.Dock = System.Windows.Forms.DockStyle.Fill;
			this._rbArpeggio.Location = new System.Drawing.Point(52, 0);
			this._rbArpeggio.Name = "_rbArpeggio";
			this._rbArpeggio.Size = new System.Drawing.Size(150, 29);
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
			this._rbScale.Size = new System.Drawing.Size(52, 29);
			this._rbScale.TabIndex = 18;
			this._rbScale.Text = "Scale";
			this._rbScale.UseVisualStyleBackColor = true;
			this._rbScale.CheckedChanged += new System.EventHandler(this._rbScale_CheckedChanged);
			// 
			// _cbRoot
			// 
			this._cbRoot.Dock = System.Windows.Forms.DockStyle.Left;
			this._cbRoot.DropDownWidth = 300;
			this._cbRoot.FormattingEnabled = true;
			this._cbRoot.Location = new System.Drawing.Point(65, 0);
			this._cbRoot.MaxDropDownItems = 100;
			this._cbRoot.Name = "_cbRoot";
			this._cbRoot.Size = new System.Drawing.Size(44, 21);
			this._cbRoot.TabIndex = 15;
			// 
			// ModelItemControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox);
			this.Name = "ModelItemControl";
			this.Size = new System.Drawing.Size(212, 110);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			this.scalePanel.ResumeLayout(false);
			this.scalePanel.PerformLayout();
			this.arpPanel.ResumeLayout(false);
			this.arpPanel.PerformLayout();
			this._panelRadioButtons.ResumeLayout(false);
			this._panelRadioButtons.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox;

		private System.Windows.Forms.ComboBox _cbScaleType;
		private System.Windows.Forms.ComboBox _cbChordType;
		private System.Windows.Forms.RadioButton _rbArpeggio;
		private System.Windows.Forms.RadioButton _rbScale;
		private System.Windows.Forms.Panel scalePanel;
		private System.Windows.Forms.Panel arpPanel;

		private System.Windows.Forms.CheckBox _cbVisible;
		private System.Windows.Forms.Panel _panelRadioButtons;
		private System.Windows.Forms.ComboBox _cbRoot;
	}
}

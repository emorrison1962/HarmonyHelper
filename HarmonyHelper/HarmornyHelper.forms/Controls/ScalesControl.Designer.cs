namespace HarmornyHelper.forms
{
	partial class ScalesControl
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
			this._inputPanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._comboScaleTypes = new System.Windows.Forms.ComboBox();
			this._comboKeys = new System.Windows.Forms.ComboBox();
			this._outputPanel = new System.Windows.Forms.Panel();
			this._textBox = new System.Windows.Forms.TextBox();
			this._inputPanel.SuspendLayout();
			this._outputPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _inputPanel
			// 
			this._inputPanel.Controls.Add(this.label2);
			this._inputPanel.Controls.Add(this.label1);
			this._inputPanel.Controls.Add(this._comboScaleTypes);
			this._inputPanel.Controls.Add(this._comboKeys);
			this._inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._inputPanel.Location = new System.Drawing.Point(0, 0);
			this._inputPanel.Name = "_inputPanel";
			this._inputPanel.Size = new System.Drawing.Size(1045, 100);
			this._inputPanel.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Scale Type:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Key:";
			// 
			// _comboScaleTypes
			// 
			this._comboScaleTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._comboScaleTypes.FormattingEnabled = true;
			this._comboScaleTypes.Location = new System.Drawing.Point(220, 43);
			this._comboScaleTypes.Name = "_comboScaleTypes";
			this._comboScaleTypes.Size = new System.Drawing.Size(176, 21);
			this._comboScaleTypes.TabIndex = 0;
			this._comboScaleTypes.SelectionChangeCommitted += new System.EventHandler(this._comboScaleTypes_SelectionChangeCommitted);
			// 
			// _comboKeys
			// 
			this._comboKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._comboKeys.FormattingEnabled = true;
			this._comboKeys.Location = new System.Drawing.Point(47, 43);
			this._comboKeys.Name = "_comboKeys";
			this._comboKeys.Size = new System.Drawing.Size(64, 21);
			this._comboKeys.TabIndex = 0;
			this._comboKeys.SelectionChangeCommitted += new System.EventHandler(this._comboKeys_SelectionChangeCommitted);
			// 
			// _outputPanel
			// 
			this._outputPanel.Controls.Add(this._textBox);
			this._outputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._outputPanel.Location = new System.Drawing.Point(0, 100);
			this._outputPanel.Name = "_outputPanel";
			this._outputPanel.Size = new System.Drawing.Size(1045, 639);
			this._outputPanel.TabIndex = 2;
			// 
			// _textBox
			// 
			this._textBox.Dock = System.Windows.Forms.DockStyle.Right;
			this._textBox.Location = new System.Drawing.Point(725, 0);
			this._textBox.Multiline = true;
			this._textBox.Name = "_textBox";
			this._textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._textBox.Size = new System.Drawing.Size(320, 639);
			this._textBox.TabIndex = 0;
			// 
			// ScalesControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._outputPanel);
			this.Controls.Add(this._inputPanel);
			this.Name = "ScalesControl";
			this.Size = new System.Drawing.Size(1045, 739);
			this._inputPanel.ResumeLayout(false);
			this._inputPanel.PerformLayout();
			this._outputPanel.ResumeLayout(false);
			this._outputPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel _inputPanel;
		private System.Windows.Forms.Panel _outputPanel;
		private System.Windows.Forms.TextBox _textBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _comboKeys;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _comboScaleTypes;
	}
}

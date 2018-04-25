namespace HarmornyHelper.forms
{
	partial class ArpeggiosControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArpeggiosControl));
			this._outputPanel = new System.Windows.Forms.Panel();
			this._tbDiags = new System.Windows.Forms.TextBox();
			this._inputPanel = new System.Windows.Forms.Panel();
			this._comboKey = new HarmornyHelper.forms.Controls.KeySignatureComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this._comboClef = new System.Windows.Forms.ComboBox();
			this._bnParse = new System.Windows.Forms.Button();
			this._tbChords = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this._outputPanel.SuspendLayout();
			this._inputPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _outputPanel
			// 
			this._outputPanel.Controls.Add(this._tbDiags);
			this._outputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._outputPanel.Location = new System.Drawing.Point(0, 123);
			this._outputPanel.Margin = new System.Windows.Forms.Padding(4);
			this._outputPanel.Name = "_outputPanel";
			this._outputPanel.Size = new System.Drawing.Size(1281, 371);
			this._outputPanel.TabIndex = 4;
			// 
			// _tbDiags
			// 
			this._tbDiags.Dock = System.Windows.Forms.DockStyle.Right;
			this._tbDiags.Location = new System.Drawing.Point(856, 0);
			this._tbDiags.Margin = new System.Windows.Forms.Padding(4);
			this._tbDiags.Multiline = true;
			this._tbDiags.Name = "_tbDiags";
			this._tbDiags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._tbDiags.Size = new System.Drawing.Size(425, 371);
			this._tbDiags.TabIndex = 2;
			// 
			// _inputPanel
			// 
			this._inputPanel.Controls.Add(this.label2);
			this._inputPanel.Controls.Add(this._comboKey);
			this._inputPanel.Controls.Add(this.label1);
			this._inputPanel.Controls.Add(this._comboClef);
			this._inputPanel.Controls.Add(this._bnParse);
			this._inputPanel.Controls.Add(this._tbChords);
			this._inputPanel.Controls.Add(this.label3);
			this._inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._inputPanel.Location = new System.Drawing.Point(0, 0);
			this._inputPanel.Margin = new System.Windows.Forms.Padding(4);
			this._inputPanel.Name = "_inputPanel";
			this._inputPanel.Size = new System.Drawing.Size(1281, 123);
			this._inputPanel.TabIndex = 5;
			// 
			// _comboKey
			// 
			this._comboKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._comboKey.FormattingEnabled = true;
			this._comboKey.Items.AddRange(new object[] {
            ((object)(resources.GetObject("_comboKey.Items"))),
            ((object)(resources.GetObject("_comboKey.Items1"))),
            ((object)(resources.GetObject("_comboKey.Items2"))),
            ((object)(resources.GetObject("_comboKey.Items3"))),
            ((object)(resources.GetObject("_comboKey.Items4"))),
            ((object)(resources.GetObject("_comboKey.Items5"))),
            ((object)(resources.GetObject("_comboKey.Items6"))),
            ((object)(resources.GetObject("_comboKey.Items7"))),
            ((object)(resources.GetObject("_comboKey.Items8"))),
            ((object)(resources.GetObject("_comboKey.Items9"))),
            ((object)(resources.GetObject("_comboKey.Items10"))),
            ((object)(resources.GetObject("_comboKey.Items11"))),
            ((object)(resources.GetObject("_comboKey.Items12"))),
            ((object)(resources.GetObject("_comboKey.Items13"))),
            ((object)(resources.GetObject("_comboKey.Items14")))});
			this._comboKey.Keys = ((System.Collections.Generic.List<Eric.Morrison.Harmony.KeySignature>)(resources.GetObject("_comboKey.Keys")));
			this._comboKey.Location = new System.Drawing.Point(72, 34);
			this._comboKey.Name = "_comboKey";
			this._comboKey.Size = new System.Drawing.Size(121, 24);
			this._comboKey.TabIndex = 7;
			this._comboKey.SelectionChangeCommitted += new System.EventHandler(this._comboKey_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "Clef:";
			// 
			// _comboClef
			// 
			this._comboClef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._comboClef.FormattingEnabled = true;
			this._comboClef.Items.AddRange(new object[] {
            "Treble",
            "Bass"});
			this._comboClef.Location = new System.Drawing.Point(72, 64);
			this._comboClef.Name = "_comboClef";
			this._comboClef.Size = new System.Drawing.Size(121, 24);
			this._comboClef.TabIndex = 5;
			this._comboClef.SelectionChangeCommitted += new System.EventHandler(this._comboClef_SelectionChangeCommitted);
			// 
			// _bnParse
			// 
			this._bnParse.Location = new System.Drawing.Point(1177, 87);
			this._bnParse.Margin = new System.Windows.Forms.Padding(4);
			this._bnParse.Name = "_bnParse";
			this._bnParse.Size = new System.Drawing.Size(100, 28);
			this._bnParse.TabIndex = 4;
			this._bnParse.Text = "Parse";
			this._bnParse.UseVisualStyleBackColor = true;
			this._bnParse.Click += new System.EventHandler(this._bnParse_Click);
			// 
			// _tbChords
			// 
			this._tbChords.Location = new System.Drawing.Point(72, 5);
			this._tbChords.Margin = new System.Windows.Forms.Padding(4);
			this._tbChords.Name = "_tbChords";
			this._tbChords.Size = new System.Drawing.Size(989, 22);
			this._tbChords.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 10);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Chords:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Key:";
			// 
			// ArpeggiosControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._outputPanel);
			this.Controls.Add(this._inputPanel);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ArpeggiosControl";
			this.Size = new System.Drawing.Size(1281, 494);
			this._outputPanel.ResumeLayout(false);
			this._outputPanel.PerformLayout();
			this._inputPanel.ResumeLayout(false);
			this._inputPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel _outputPanel;
		private System.Windows.Forms.TextBox _tbDiags;
		private System.Windows.Forms.Panel _inputPanel;
		private System.Windows.Forms.TextBox _tbChords;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button _bnParse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _comboClef;
		private Controls.KeySignatureComboBox _comboKey;
		private System.Windows.Forms.Label label2;
	}
}

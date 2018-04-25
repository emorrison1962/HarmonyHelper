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
			this._outputPanel = new System.Windows.Forms.Panel();
			this._tbDiags = new System.Windows.Forms.TextBox();
			this._inputPanel = new System.Windows.Forms.Panel();
			this._bnParse = new System.Windows.Forms.Button();
			this._tbChords = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this._outputPanel.SuspendLayout();
			this._inputPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _outputPanel
			// 
			this._outputPanel.Controls.Add(this._tbDiags);
			this._outputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._outputPanel.Location = new System.Drawing.Point(0, 100);
			this._outputPanel.Name = "_outputPanel";
			this._outputPanel.Size = new System.Drawing.Size(940, 309);
			this._outputPanel.TabIndex = 4;
			// 
			// _tbDiags
			// 
			this._tbDiags.Dock = System.Windows.Forms.DockStyle.Right;
			this._tbDiags.Location = new System.Drawing.Point(620, 0);
			this._tbDiags.Multiline = true;
			this._tbDiags.Name = "_tbDiags";
			this._tbDiags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._tbDiags.Size = new System.Drawing.Size(320, 309);
			this._tbDiags.TabIndex = 2;
			// 
			// _inputPanel
			// 
			this._inputPanel.Controls.Add(this._bnParse);
			this._inputPanel.Controls.Add(this._tbChords);
			this._inputPanel.Controls.Add(this.label3);
			this._inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._inputPanel.Location = new System.Drawing.Point(0, 0);
			this._inputPanel.Name = "_inputPanel";
			this._inputPanel.Size = new System.Drawing.Size(940, 100);
			this._inputPanel.TabIndex = 5;
			// 
			// _bnParse
			// 
			this._bnParse.Location = new System.Drawing.Point(7, 25);
			this._bnParse.Name = "_bnParse";
			this._bnParse.Size = new System.Drawing.Size(75, 23);
			this._bnParse.TabIndex = 4;
			this._bnParse.Text = "Parse";
			this._bnParse.UseVisualStyleBackColor = true;
			this._bnParse.Click += new System.EventHandler(this._bnParse_Click);
			// 
			// _tbChords
			// 
			this._tbChords.Location = new System.Drawing.Point(54, 4);
			this._tbChords.Name = "_tbChords";
			this._tbChords.Size = new System.Drawing.Size(743, 20);
			this._tbChords.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Chords:";
			// 
			// ArpeggiosControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._outputPanel);
			this.Controls.Add(this._inputPanel);
			this.Name = "ArpeggiosControl";
			this.Size = new System.Drawing.Size(940, 409);
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
	}
}

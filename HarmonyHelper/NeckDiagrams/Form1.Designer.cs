
namespace NeckDiagrams
{
	partial class Form1
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._cbScaleType = new System.Windows.Forms.ComboBox();
			this._cbKey = new System.Windows.Forms.ComboBox();
			this._pnlNeck = new System.Windows.Forms.Panel();
			this._neckCtl = new NeckDiagrams.NeckControl();
			this.label3 = new System.Windows.Forms.Label();
			this._cbChordType = new System.Windows.Forms.ComboBox();
			this._radioScale = new System.Windows.Forms.RadioButton();
			this._radioArpeggio = new System.Windows.Forms.RadioButton();
			this.panel3.SuspendLayout();
			this._pnlNeck.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 390);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 60);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.Controls.Add(this._radioArpeggio);
			this.panel3.Controls.Add(this._radioScale);
			this.panel3.Controls.Add(this._cbChordType);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this._cbScaleType);
			this.panel3.Controls.Add(this._cbKey);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(800, 100);
			this.panel3.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Scale Type:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Key:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _cbScaleType
			// 
			this._cbScaleType.FormattingEnabled = true;
			this._cbScaleType.Location = new System.Drawing.Point(91, 39);
			this._cbScaleType.Name = "_cbScaleType";
			this._cbScaleType.Size = new System.Drawing.Size(121, 21);
			this._cbScaleType.TabIndex = 1;
			this._cbScaleType.SelectedValueChanged += new System.EventHandler(this._cbScaleType_SelectedValueChanged);
			// 
			// _cbKey
			// 
			this._cbKey.FormattingEnabled = true;
			this._cbKey.Location = new System.Drawing.Point(91, 12);
			this._cbKey.Name = "_cbKey";
			this._cbKey.Size = new System.Drawing.Size(121, 21);
			this._cbKey.TabIndex = 0;
			this._cbKey.SelectedValueChanged += new System.EventHandler(this._cbKey_SelectedValueChanged);
			// 
			// _pnlNeck
			// 
			this._pnlNeck.BackColor = System.Drawing.SystemColors.Control;
			this._pnlNeck.Controls.Add(this._neckCtl);
			this._pnlNeck.Dock = System.Windows.Forms.DockStyle.Fill;
			this._pnlNeck.Location = new System.Drawing.Point(0, 100);
			this._pnlNeck.Name = "_pnlNeck";
			this._pnlNeck.Padding = new System.Windows.Forms.Padding(20);
			this._pnlNeck.Size = new System.Drawing.Size(800, 290);
			this._pnlNeck.TabIndex = 3;
			// 
			// _neckCtl
			// 
			this._neckCtl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._neckCtl.Location = new System.Drawing.Point(20, 20);
			this._neckCtl.Name = "_neckCtl";
			this._neckCtl.Size = new System.Drawing.Size(760, 250);
			this._neckCtl.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(236, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Chord Type:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _cbChordType
			// 
			this._cbChordType.FormattingEnabled = true;
			this._cbChordType.Location = new System.Drawing.Point(307, 39);
			this._cbChordType.Name = "_cbChordType";
			this._cbChordType.Size = new System.Drawing.Size(121, 21);
			this._cbChordType.TabIndex = 5;
			this._cbChordType.SelectedValueChanged += new System.EventHandler(this._cbChordType_SelectedValueChanged);
			// 
			// _radioScale
			// 
			this._radioScale.AutoSize = true;
			this._radioScale.Location = new System.Drawing.Point(239, 15);
			this._radioScale.Name = "_radioScale";
			this._radioScale.Size = new System.Drawing.Size(52, 17);
			this._radioScale.TabIndex = 6;
			this._radioScale.TabStop = true;
			this._radioScale.Text = "Scale";
			this._radioScale.UseVisualStyleBackColor = true;
			this._radioScale.CheckedChanged += new System.EventHandler(this._radioScale_CheckedChanged);
			// 
			// _radioArpeggio
			// 
			this._radioArpeggio.AutoSize = true;
			this._radioArpeggio.Location = new System.Drawing.Point(330, 15);
			this._radioArpeggio.Name = "_radioArpeggio";
			this._radioArpeggio.Size = new System.Drawing.Size(67, 17);
			this._radioArpeggio.TabIndex = 7;
			this._radioArpeggio.TabStop = true;
			this._radioArpeggio.Text = "Arpeggio";
			this._radioArpeggio.UseVisualStyleBackColor = true;
			this._radioArpeggio.CheckedChanged += new System.EventHandler(this._radioArpeggio_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this._pnlNeck);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this._pnlNeck.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel _pnlNeck;
		private NeckControl _neckCtl;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _cbScaleType;
		private System.Windows.Forms.ComboBox _cbKey;
		private System.Windows.Forms.ComboBox _cbChordType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton _radioArpeggio;
		private System.Windows.Forms.RadioButton _radioScale;
	}
}



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
			this._pnlNeck = new System.Windows.Forms.Panel();
			this._neckCtl = new NeckDiagrams.NeckControl();
			this._pnlNeck.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Salmon;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 390);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 60);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.MediumAquamarine;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(800, 100);
			this.panel3.TabIndex = 2;
			// 
			// _pnlNeck
			// 
			this._pnlNeck.BackColor = System.Drawing.SystemColors.Control;
			this._pnlNeck.Controls.Add(this._neckCtl);
			this._pnlNeck.Dock = System.Windows.Forms.DockStyle.Fill;
			this._pnlNeck.Location = new System.Drawing.Point(0, 100);
			this._pnlNeck.Name = "_pnlNeck";
			this._pnlNeck.Size = new System.Drawing.Size(800, 290);
			this._pnlNeck.TabIndex = 3;
			// 
			// _neckCtl
			// 
			this._neckCtl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._neckCtl.Location = new System.Drawing.Point(0, 0);
			this._neckCtl.Name = "_neckCtl";
			this._neckCtl.Size = new System.Drawing.Size(800, 290);
			this._neckCtl.TabIndex = 0;
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
			this._pnlNeck.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel _pnlNeck;
		private NeckControl _neckCtl;
	}
}


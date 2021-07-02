
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
			this.modelItemsControl = new NeckDiagrams.ModelCollectionControl();
			this.keyPanel = new System.Windows.Forms.Panel();
			this._bnAddItem = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._cbKey = new System.Windows.Forms.ComboBox();
			this._pnlNeck = new System.Windows.Forms.Panel();
			this._neckCtl = new NeckDiagrams.NeckControl();
			this.panel3.SuspendLayout();
			this.keyPanel.SuspendLayout();
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
			this.panel3.Controls.Add(this.modelItemsControl);
			this.panel3.Controls.Add(this.keyPanel);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(800, 100);
			this.panel3.TabIndex = 2;
			// 
			// modelItemsControl
			// 
			this.modelItemsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelItemsControl.Location = new System.Drawing.Point(200, 0);
			this.modelItemsControl.Name = "modelItemsControl";
			this.modelItemsControl.Size = new System.Drawing.Size(600, 100);
			this.modelItemsControl.TabIndex = 2;
			// 
			// keyPanel
			// 
			this.keyPanel.BackColor = System.Drawing.SystemColors.Control;
			this.keyPanel.Controls.Add(this._bnAddItem);
			this.keyPanel.Controls.Add(this.label1);
			this.keyPanel.Controls.Add(this._cbKey);
			this.keyPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.keyPanel.Location = new System.Drawing.Point(0, 0);
			this.keyPanel.Name = "keyPanel";
			this.keyPanel.Size = new System.Drawing.Size(200, 100);
			this.keyPanel.TabIndex = 1;
			// 
			// _bnAddItem
			// 
			this._bnAddItem.Location = new System.Drawing.Point(106, 52);
			this._bnAddItem.Name = "_bnAddItem";
			this._bnAddItem.Size = new System.Drawing.Size(75, 23);
			this._bnAddItem.TabIndex = 6;
			this._bnAddItem.Text = "+";
			this._bnAddItem.UseVisualStyleBackColor = true;
			this._bnAddItem.Click += new System.EventHandler(this._bnAddItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Key:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _cbKey
			// 
			this._cbKey.FormattingEnabled = true;
			this._cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cbKey.Location = new System.Drawing.Point(60, 25);
			this._cbKey.Name = "_cbKey";
			this._cbKey.Size = new System.Drawing.Size(121, 21);
			this._cbKey.TabIndex = 4;
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this._pnlNeck);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel3.ResumeLayout(false);
			this.keyPanel.ResumeLayout(false);
			this.keyPanel.PerformLayout();
			this._pnlNeck.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel _pnlNeck;
		private NeckControl _neckCtl;
		private System.Windows.Forms.Panel keyPanel;
		private System.Windows.Forms.Button _bnAddItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _cbKey;
		private ModelCollectionControl modelItemsControl;
	}
}


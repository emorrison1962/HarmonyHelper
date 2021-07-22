
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
			this.topPanel = new System.Windows.Forms.Panel();
			this.keyPanel = new System.Windows.Forms.Panel();
			this._bnAddItem = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._cbKey = new System.Windows.Forms.ComboBox();
			this._pnlNeck = new System.Windows.Forms.Panel();
			this._neckCtl = new NeckDiagrams.NeckControl();
			this.modelItemsControl = new NeckDiagrams.ModelCollectionControl();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.panel2.SuspendLayout();
			this.topPanel.SuspendLayout();
			this.keyPanel.SuspendLayout();
			this._pnlNeck.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Controls.Add(this.menuStrip);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 390);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 60);
			this.panel2.TabIndex = 1;
			// 
			// topPanel
			// 
			this.topPanel.BackColor = System.Drawing.SystemColors.Control;
			this.topPanel.Controls.Add(this.modelItemsControl);
			this.topPanel.Controls.Add(this.keyPanel);
			this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPanel.Location = new System.Drawing.Point(0, 0);
			this.topPanel.MinimumSize = new System.Drawing.Size(800, 100);
			this.topPanel.Name = "topPanel";
			this.topPanel.Size = new System.Drawing.Size(800, 100);
			this.topPanel.TabIndex = 2;
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
			this._cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cbKey.FormattingEnabled = true;
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
			this._neckCtl.BackColor = System.Drawing.SystemColors.Control;
			this._neckCtl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._neckCtl.Location = new System.Drawing.Point(20, 20);
			this._neckCtl.Name = "_neckCtl";
			this._neckCtl.Size = new System.Drawing.Size(760, 250);
			this._neckCtl.TabIndex = 0;
			// 
			// modelItemsControl
			// 
			this.modelItemsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelItemsControl.Location = new System.Drawing.Point(200, 0);
			this.modelItemsControl.Name = "modelItemsControl";
			this.modelItemsControl.Size = new System.Drawing.Size(600, 100);
			this.modelItemsControl.TabIndex = 2;
			// 
			// printDialog1
			// 
			this.printDialog1.UseEXDialog = true;
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(800, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "File";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
			this.toolStripMenuItem1.Text = "Print";
			// 
			// printDocument1
			// 
			this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
			this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			this.printDocument1.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printDocument1_QueryPageSettings);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this._pnlNeck);
			this.Controls.Add(this.topPanel);
			this.Controls.Add(this.panel2);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.topPanel.ResumeLayout(false);
			this.keyPanel.ResumeLayout(false);
			this.keyPanel.PerformLayout();
			this._pnlNeck.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Panel _pnlNeck;
		private NeckControl _neckCtl;
		private System.Windows.Forms.Panel keyPanel;
		private System.Windows.Forms.Button _bnAddItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _cbKey;
		private ModelCollectionControl modelItemsControl;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Drawing.Printing.PrintDocument printDocument1;
	}
}


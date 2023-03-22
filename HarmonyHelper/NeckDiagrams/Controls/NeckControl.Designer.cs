
namespace NeckDiagrams
{
	partial class NeckControl
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
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.pnlNeck = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this._ctlModels = new NeckDiagrams.ModelsControl();
            this.pnlKey = new System.Windows.Forms.Panel();
            this._bnAddItem = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this._cbKey = new System.Windows.Forms.ComboBox();
            this.pnlNeck.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            this.printDocument.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printDocument_QueryPageSettings);
            // 
            // pnlNeck
            // 
            this.pnlNeck.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNeck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNeck.Controls.Add(this.pnlTop);
            this.pnlNeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNeck.Location = new System.Drawing.Point(0, 0);
            this.pnlNeck.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pnlNeck.Name = "pnlNeck";
            this.pnlNeck.Padding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.pnlNeck.Size = new System.Drawing.Size(1710, 746);
            this.pnlNeck.TabIndex = 4;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTop.Controls.Add(this._ctlModels);
            this.pnlTop.Controls.Add(this.pnlKey);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(40, 39);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pnlTop.MinimumSize = new System.Drawing.Size(1600, 192);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1626, 192);
            this.pnlTop.TabIndex = 2;
            // 
            // _ctlModels
            // 
            this._ctlModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctlModels.Location = new System.Drawing.Point(400, 0);
            this._ctlModels.Margin = new System.Windows.Forms.Padding(8);
            this._ctlModels.Name = "_ctlModels";
            this._ctlModels.Size = new System.Drawing.Size(1226, 192);
            this._ctlModels.TabIndex = 2;
            // 
            // pnlKey
            // 
            this.pnlKey.BackColor = System.Drawing.SystemColors.Control;
            this.pnlKey.Controls.Add(this._bnAddItem);
            this.pnlKey.Controls.Add(this.lblKey);
            this.pnlKey.Controls.Add(this._cbKey);
            this.pnlKey.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKey.Location = new System.Drawing.Point(0, 0);
            this.pnlKey.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pnlKey.Name = "pnlKey";
            this.pnlKey.Size = new System.Drawing.Size(400, 192);
            this.pnlKey.TabIndex = 1;
            // 
            // _bnAddItem
            // 
            this._bnAddItem.Location = new System.Drawing.Point(212, 100);
            this._bnAddItem.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._bnAddItem.Name = "_bnAddItem";
            this._bnAddItem.Size = new System.Drawing.Size(149, 44);
            this._bnAddItem.TabIndex = 6;
            this._bnAddItem.Text = "+";
            this._bnAddItem.UseVisualStyleBackColor = true;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(37, 52);
            this.lblKey.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(44, 25);
            this.lblKey.TabIndex = 5;
            this.lblKey.Text = "Key:";
            this.lblKey.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _cbKey
            // 
            this._cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbKey.FormattingEnabled = true;
            this._cbKey.Location = new System.Drawing.Point(120, 49);
            this._cbKey.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._cbKey.Name = "_cbKey";
            this._cbKey.Size = new System.Drawing.Size(239, 33);
            this._cbKey.TabIndex = 4;
            // 
            // NeckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNeck);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "NeckControl";
            this.Size = new System.Drawing.Size(1710, 746);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NeckControl_MouseMove);
            this.pnlNeck.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlKey.ResumeLayout(false);
            this.pnlKey.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Panel pnlNeck;
        private System.Windows.Forms.Panel pnlTop;
        private NeckControl _neckCtl;
        private ModelsControl _ctlModels;
        private System.Windows.Forms.Panel pnlKey;
        private System.Windows.Forms.Button _bnAddItem;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.ComboBox _cbKey;

    }
}

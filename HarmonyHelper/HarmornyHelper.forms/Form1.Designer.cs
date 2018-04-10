namespace HarmornyHelper.forms
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.NavPanel = new System.Windows.Forms.Panel();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this._bnAnalysis = new System.Windows.Forms.RadioButton();
			this._bnArpeggios = new System.Windows.Forms.RadioButton();
			this._bnChords = new System.Windows.Forms.RadioButton();
			this._bnScales = new System.Windows.Forms.RadioButton();
			this._bnIntervals = new System.Windows.Forms.RadioButton();
			this._contentPanel = new System.Windows.Forms.Panel();
			this.footerPanel = new System.Windows.Forms.Panel();
			this.headerPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.NavPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.NavPanel);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this._contentPanel);
			this.splitContainer1.Panel2.Controls.Add(this.footerPanel);
			this.splitContainer1.Panel2.Controls.Add(this.headerPanel);
			this.splitContainer1.Size = new System.Drawing.Size(1090, 500);
			this.splitContainer1.SplitterDistance = 200;
			this.splitContainer1.TabIndex = 0;
			// 
			// NavPanel
			// 
			this.NavPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.NavPanel.Controls.Add(this.radioButton1);
			this.NavPanel.Controls.Add(this._bnAnalysis);
			this.NavPanel.Controls.Add(this._bnArpeggios);
			this.NavPanel.Controls.Add(this._bnChords);
			this.NavPanel.Controls.Add(this._bnScales);
			this.NavPanel.Controls.Add(this._bnIntervals);
			this.NavPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NavPanel.Location = new System.Drawing.Point(0, 0);
			this.NavPanel.Name = "NavPanel";
			this.NavPanel.Size = new System.Drawing.Size(200, 500);
			this.NavPanel.TabIndex = 5;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(83, 241);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(85, 17);
			this.radioButton1.TabIndex = 14;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "radioButton1";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// _bnAnalysis
			// 
			this._bnAnalysis.Appearance = System.Windows.Forms.Appearance.Button;
			this._bnAnalysis.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._bnAnalysis.Dock = System.Windows.Forms.DockStyle.Top;
			this._bnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._bnAnalysis.Location = new System.Drawing.Point(0, 92);
			this._bnAnalysis.Name = "_bnAnalysis";
			this._bnAnalysis.Size = new System.Drawing.Size(200, 23);
			this._bnAnalysis.TabIndex = 13;
			this._bnAnalysis.Text = "Analysis";
			this._bnAnalysis.UseVisualStyleBackColor = true;
			this._bnAnalysis.CheckedChanged += new System.EventHandler(this._bnAnalysis_CheckedChanged);
			// 
			// _bnArpeggios
			// 
			this._bnArpeggios.Appearance = System.Windows.Forms.Appearance.Button;
			this._bnArpeggios.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._bnArpeggios.Dock = System.Windows.Forms.DockStyle.Top;
			this._bnArpeggios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._bnArpeggios.Location = new System.Drawing.Point(0, 69);
			this._bnArpeggios.Name = "_bnArpeggios";
			this._bnArpeggios.Size = new System.Drawing.Size(200, 23);
			this._bnArpeggios.TabIndex = 12;
			this._bnArpeggios.Text = "Arpeggios";
			this._bnArpeggios.UseVisualStyleBackColor = true;
			this._bnArpeggios.CheckedChanged += new System.EventHandler(this._bnArpeggios_CheckedChanged);
			// 
			// _bnChords
			// 
			this._bnChords.Appearance = System.Windows.Forms.Appearance.Button;
			this._bnChords.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._bnChords.Dock = System.Windows.Forms.DockStyle.Top;
			this._bnChords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._bnChords.Location = new System.Drawing.Point(0, 46);
			this._bnChords.Name = "_bnChords";
			this._bnChords.Size = new System.Drawing.Size(200, 23);
			this._bnChords.TabIndex = 11;
			this._bnChords.Text = "Chords";
			this._bnChords.UseVisualStyleBackColor = true;
			this._bnChords.CheckedChanged += new System.EventHandler(this._bnChords_CheckedChanged);
			// 
			// _bnScales
			// 
			this._bnScales.Appearance = System.Windows.Forms.Appearance.Button;
			this._bnScales.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._bnScales.Dock = System.Windows.Forms.DockStyle.Top;
			this._bnScales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._bnScales.Location = new System.Drawing.Point(0, 23);
			this._bnScales.Name = "_bnScales";
			this._bnScales.Size = new System.Drawing.Size(200, 23);
			this._bnScales.TabIndex = 8;
			this._bnScales.Text = "Scales";
			this._bnScales.UseVisualStyleBackColor = true;
			this._bnScales.CheckedChanged += new System.EventHandler(this._bnScales_CheckedChanged);
			// 
			// _bnIntervals
			// 
			this._bnIntervals.Appearance = System.Windows.Forms.Appearance.Button;
			this._bnIntervals.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this._bnIntervals.Dock = System.Windows.Forms.DockStyle.Top;
			this._bnIntervals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._bnIntervals.Location = new System.Drawing.Point(0, 0);
			this._bnIntervals.Name = "_bnIntervals";
			this._bnIntervals.Size = new System.Drawing.Size(200, 23);
			this._bnIntervals.TabIndex = 5;
			this._bnIntervals.Text = "Intervals";
			this._bnIntervals.UseVisualStyleBackColor = false;
			this._bnIntervals.CheckedChanged += new System.EventHandler(this._bnIntervals_CheckedChanged);
			// 
			// _contentPanel
			// 
			this._contentPanel.BackColor = System.Drawing.Color.AntiqueWhite;
			this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._contentPanel.Location = new System.Drawing.Point(0, 59);
			this._contentPanel.Name = "_contentPanel";
			this._contentPanel.Size = new System.Drawing.Size(886, 380);
			this._contentPanel.TabIndex = 8;
			// 
			// footerPanel
			// 
			this.footerPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.footerPanel.Location = new System.Drawing.Point(0, 439);
			this.footerPanel.Name = "footerPanel";
			this.footerPanel.Size = new System.Drawing.Size(886, 61);
			this.footerPanel.TabIndex = 7;
			// 
			// headerPanel
			// 
			this.headerPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(886, 59);
			this.headerPanel.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1090, 500);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Harmony Helper";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.NavPanel.ResumeLayout(false);
			this.NavPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel NavPanel;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton _bnAnalysis;
		private System.Windows.Forms.RadioButton _bnArpeggios;
		private System.Windows.Forms.RadioButton _bnChords;
		private System.Windows.Forms.RadioButton _bnScales;
		private System.Windows.Forms.RadioButton _bnIntervals;
		private System.Windows.Forms.Panel _contentPanel;
		private System.Windows.Forms.Panel footerPanel;
		private System.Windows.Forms.Panel headerPanel;
	}
}


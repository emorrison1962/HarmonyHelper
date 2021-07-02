
namespace NeckDiagrams
{
	partial class NewHarmonyItemDialog
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
			this.bnPanel = new System.Windows.Forms.Panel();
			this._bnCancel = new System.Windows.Forms.Button();
			this._bnOk = new System.Windows.Forms.Button();
			this.modelItemControl = new NeckDiagrams.ModelItemControl();
			this.bnPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// bnPanel
			// 
			this.bnPanel.Controls.Add(this._bnCancel);
			this.bnPanel.Controls.Add(this._bnOk);
			this.bnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bnPanel.Location = new System.Drawing.Point(0, 188);
			this.bnPanel.Name = "bnPanel";
			this.bnPanel.Size = new System.Drawing.Size(256, 32);
			this.bnPanel.TabIndex = 2;
			// 
			// _bnCancel
			// 
			this._bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._bnCancel.Location = new System.Drawing.Point(97, 6);
			this._bnCancel.Name = "_bnCancel";
			this._bnCancel.Size = new System.Drawing.Size(75, 23);
			this._bnCancel.TabIndex = 3;
			this._bnCancel.Text = "Cancel";
			this._bnCancel.UseVisualStyleBackColor = true;
			this._bnCancel.Click += new System.EventHandler(this._bnCancel_Click);
			// 
			// _bnOk
			// 
			this._bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._bnOk.Location = new System.Drawing.Point(178, 6);
			this._bnOk.Name = "_bnOk";
			this._bnOk.Size = new System.Drawing.Size(75, 23);
			this._bnOk.TabIndex = 2;
			this._bnOk.Text = "OK";
			this._bnOk.UseVisualStyleBackColor = true;
			this._bnOk.Click += new System.EventHandler(this._bnOk_Click);
			// 
			// modelItemControl
			// 
			this.modelItemControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modelItemControl.Location = new System.Drawing.Point(0, 0);
			this.modelItemControl.Name = "modelItemControl";
			this.modelItemControl.Size = new System.Drawing.Size(256, 188);
			this.modelItemControl.TabIndex = 3;
			// 
			// NewHarmonyItemDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(256, 220);
			this.ControlBox = false;
			this.Controls.Add(this.modelItemControl);
			this.Controls.Add(this.bnPanel);
			this.Name = "NewHarmonyItemDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create HarmonyModelItem";
			this.bnPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel bnPanel;
		private System.Windows.Forms.Button _bnCancel;
		private System.Windows.Forms.Button _bnOk;
		private ModelItemControl modelItemControl;
	}
}

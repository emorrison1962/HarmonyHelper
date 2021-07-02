
namespace NeckDiagrams
{
	partial class ModelItemsControl
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
			this.itemsPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// itemsPanel
			// 
			this.itemsPanel.BackColor = System.Drawing.Color.LightSalmon;
			this.itemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsPanel.Location = new System.Drawing.Point(0, 0);
			this.itemsPanel.Name = "itemsPanel";
			this.itemsPanel.Size = new System.Drawing.Size(390, 93);
			this.itemsPanel.TabIndex = 2;
			// 
			// ModelItemsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.itemsPanel);
			this.Name = "ModelItemsControl";
			this.Size = new System.Drawing.Size(390, 93);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel itemsPanel;
	}
}

﻿
namespace NeckDiagrams
{
	partial class StringPositionControl
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
            this.components = new System.ComponentModel.Container();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // StringPositionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StringPositionControl";
            this.Size = new System.Drawing.Size(53, 49);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StringPositionControl_Paint);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.StringPositionControl_Layout);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip _toolTip;
	}
}

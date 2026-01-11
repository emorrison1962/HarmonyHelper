
namespace NeckDiagrams
{
	partial class NoteNameComboBox
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
			this._cbNoteName = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// _cbNoteName
			// 
			this._cbNoteName.Dock = System.Windows.Forms.DockStyle.Top;
			this._cbNoteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cbNoteName.DropDownWidth = 300;
			this._cbNoteName.FormattingEnabled = true;
			this._cbNoteName.Location = new System.Drawing.Point(0, 0);
			this._cbNoteName.MaxDropDownItems = 100;
			this._cbNoteName.Name = "_cbNoteName";
			this._cbNoteName.Size = new System.Drawing.Size(150, 21);
			this._cbNoteName.TabIndex = 16;
			this._cbNoteName.SelectedValueChanged += new System.EventHandler(this._cbNoteName_SelectedValueChanged);
			// 
			// NoteNameComboBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._cbNoteName);
			this.Name = "NoteNameComboBox";
			this.Size = new System.Drawing.Size(150, 21);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox _cbNoteName;
	}
}

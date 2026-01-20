
namespace NeckDiagrams
{
	partial class NoteComboBox
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
            _cbNoteName = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // _cbNoteName
            // 
            _cbNoteName.Dock = System.Windows.Forms.DockStyle.Top;
            _cbNoteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _cbNoteName.DropDownWidth = 300;
            _cbNoteName.FormattingEnabled = true;
            _cbNoteName.Location = new System.Drawing.Point(0, 0);
            _cbNoteName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            _cbNoteName.MaxDropDownItems = 100;
            _cbNoteName.Name = "_cbNoteName";
            _cbNoteName.Size = new System.Drawing.Size(200, 28);
            _cbNoteName.TabIndex = 16;
            _cbNoteName.SelectedValueChanged += _cbNoteName_SelectedValueChanged;
            // 
            // NoteNameComboBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_cbNoteName);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MinimumSize = new System.Drawing.Size(0, 32);
            Name = "NoteNameComboBox";
            Size = new System.Drawing.Size(200, 32);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbNoteName;
	}
}

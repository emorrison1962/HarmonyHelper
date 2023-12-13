namespace NeckDiagrams.Controls
{
    partial class KeySignatureSelectorControl
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
            components = new System.ComponentModel.Container();
            _combo = new System.Windows.Forms.ComboBox();
            keySignatureBindingSource = new System.Windows.Forms.BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)keySignatureBindingSource).BeginInit();
            SuspendLayout();
            // 
            // _combo
            // 
            _combo.Dock = System.Windows.Forms.DockStyle.Fill;
            _combo.FormattingEnabled = true;
            _combo.Location = new System.Drawing.Point(0, 0);
            _combo.Name = "_combo";
            _combo.Size = new System.Drawing.Size(376, 28);
            _combo.TabIndex = 0;
            // 
            // keySignatureBindingSource
            // 
            keySignatureBindingSource.DataSource = typeof(Eric.Morrison.Harmony.KeySignature);
            // 
            // KeySignatureSelectorControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(_combo);
            Name = "KeySignatureSelectorControl";
            Size = new System.Drawing.Size(376, 28);
            ((System.ComponentModel.ISupportInitialize)keySignatureBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox _combo;
        private System.Windows.Forms.BindingSource keySignatureBindingSource;
    }
}

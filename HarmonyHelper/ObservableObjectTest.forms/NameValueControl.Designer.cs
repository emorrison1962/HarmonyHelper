namespace ObservableObjectTest.forms
{
    partial class NameValueControl
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
            _tbValue = new TextBox();
            _tbName = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // _tbValue
            // 
            _tbValue.Dock = DockStyle.Fill;
            _tbValue.Location = new Point(221, 3);
            _tbValue.Name = "_tbValue";
            _tbValue.Size = new Size(212, 27);
            _tbValue.TabIndex = 0;
            // 
            // _tbName
            // 
            _tbName.Dock = DockStyle.Fill;
            _tbName.Location = new Point(3, 3);
            _tbName.Name = "_tbName";
            _tbName.Size = new Size(212, 27);
            _tbName.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(_tbName, 0, 0);
            tableLayoutPanel1.Controls.Add(_tbValue, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(436, 39);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // NameValueControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "NameValueControl";
            Size = new Size(436, 39);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox _tbValue;
        private TextBox _tbName;
        private TableLayoutPanel tableLayoutPanel1;
    }
}

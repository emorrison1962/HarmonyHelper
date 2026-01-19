namespace ObservableObjectTest.forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            nameValueControl6 = new NameValueControl();
            nameValueControl5 = new NameValueControl();
            nameValueControl4 = new NameValueControl();
            nameValueControl3 = new NameValueControl();
            nameValueControl2 = new NameValueControl();
            nameValueControl1 = new NameValueControl();
            bnOK = new Button();
            bnCancel = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(nameValueControl6);
            panel1.Controls.Add(nameValueControl5);
            panel1.Controls.Add(nameValueControl4);
            panel1.Controls.Add(nameValueControl3);
            panel1.Controls.Add(nameValueControl2);
            panel1.Controls.Add(nameValueControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 532);
            panel1.TabIndex = 0;
            // 
            // nameValueControl6
            // 
            nameValueControl6.Dock = DockStyle.Top;
            nameValueControl6.Location = new Point(0, 195);
            nameValueControl6.Name = "nameValueControl6";
            nameValueControl6.Size = new Size(356, 39);
            nameValueControl6.TabIndex = 5;
            // 
            // nameValueControl5
            // 
            nameValueControl5.Dock = DockStyle.Top;
            nameValueControl5.Location = new Point(0, 156);
            nameValueControl5.Name = "nameValueControl5";
            nameValueControl5.Size = new Size(356, 39);
            nameValueControl5.TabIndex = 4;
            // 
            // nameValueControl4
            // 
            nameValueControl4.Dock = DockStyle.Top;
            nameValueControl4.Location = new Point(0, 117);
            nameValueControl4.Name = "nameValueControl4";
            nameValueControl4.Size = new Size(356, 39);
            nameValueControl4.TabIndex = 3;
            // 
            // nameValueControl3
            // 
            nameValueControl3.Dock = DockStyle.Top;
            nameValueControl3.Location = new Point(0, 78);
            nameValueControl3.Name = "nameValueControl3";
            nameValueControl3.Size = new Size(356, 39);
            nameValueControl3.TabIndex = 2;
            // 
            // nameValueControl2
            // 
            nameValueControl2.Dock = DockStyle.Top;
            nameValueControl2.Location = new Point(0, 39);
            nameValueControl2.Name = "nameValueControl2";
            nameValueControl2.Size = new Size(356, 39);
            nameValueControl2.TabIndex = 1;
            // 
            // nameValueControl1
            // 
            nameValueControl1.Dock = DockStyle.Top;
            nameValueControl1.Location = new Point(0, 0);
            nameValueControl1.Name = "nameValueControl1";
            nameValueControl1.Size = new Size(356, 39);
            nameValueControl1.TabIndex = 0;
            // 
            // bnOK
            // 
            bnOK.DialogResult = DialogResult.OK;
            bnOK.Location = new Point(1083, 490);
            bnOK.Name = "bnOK";
            bnOK.Size = new Size(75, 30);
            bnOK.TabIndex = 1;
            bnOK.Text = "OK";
            bnOK.UseVisualStyleBackColor = true;
            bnOK.Click += bnOK_Click;
            // 
            // bnCancel
            // 
            bnCancel.DialogResult = DialogResult.Cancel;
            bnCancel.Location = new Point(1002, 490);
            bnCancel.Name = "bnCancel";
            bnCancel.Size = new Size(75, 30);
            bnCancel.TabIndex = 1;
            bnCancel.Text = "Cancel";
            bnCancel.UseVisualStyleBackColor = true;
            bnCancel.Click += bnCancel_Click;
            // 
            // Form1
            // 
            AcceptButton = bnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = bnCancel;
            ClientSize = new Size(1170, 532);
            Controls.Add(bnCancel);
            Controls.Add(bnOK);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bnOK;
        private Button bnCancel;
        private NameValueControl nameValueControl3;
        private NameValueControl nameValueControl2;
        private NameValueControl nameValueControl1;
        private NameValueControl nameValueControl6;
        private NameValueControl nameValueControl5;
        private NameValueControl nameValueControl4;
    }
}

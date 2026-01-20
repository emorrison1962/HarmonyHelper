namespace NeckDiagrams.Controls
{
    partial class OptionsDialog
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
            Domain.GuitarStringCollection guitarStringCollection2 = new Domain.GuitarStringCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            tabControl = new System.Windows.Forms.TabControl();
            tabGuitarStrings = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            ctlGuitarStrings = new GuitarStringsControl();
            tabColors = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            ctlSeventh = new ColorSelectorControl();
            ctlSixth = new ColorSelectorControl();
            ctlFifth = new ColorSelectorControl();
            ctlFourth = new ColorSelectorControl();
            ctlThird = new ColorSelectorControl();
            ctlSecond = new ColorSelectorControl();
            ctlRoot = new ColorSelectorControl();
            panel1 = new System.Windows.Forms.Panel();
            bnCancel = new System.Windows.Forms.Button();
            bnOK = new System.Windows.Forms.Button();
            ctlNinth = new ColorSelectorControl();
            ctlEleventh = new ColorSelectorControl();
            ctlThirteenth = new ColorSelectorControl();
            tabControl.SuspendLayout();
            tabGuitarStrings.SuspendLayout();
            panel3.SuspendLayout();
            tabColors.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabGuitarStrings);
            tabControl.Controls.Add(tabColors);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(800, 450);
            tabControl.TabIndex = 0;
            // 
            // tabGuitarStrings
            // 
            tabGuitarStrings.Controls.Add(panel3);
            tabGuitarStrings.Location = new System.Drawing.Point(4, 29);
            tabGuitarStrings.Name = "tabGuitarStrings";
            tabGuitarStrings.Padding = new System.Windows.Forms.Padding(3);
            tabGuitarStrings.Size = new System.Drawing.Size(792, 417);
            tabGuitarStrings.TabIndex = 0;
            tabGuitarStrings.Text = "tabPage1";
            tabGuitarStrings.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(ctlGuitarStrings);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(786, 411);
            panel3.TabIndex = 0;
            // 
            // ctlGuitarStrings
            // 
            ctlGuitarStrings.Dock = System.Windows.Forms.DockStyle.Top;
            ctlGuitarStrings.GuitarStringCollection = guitarStringCollection2;
            ctlGuitarStrings.Location = new System.Drawing.Point(0, 0);
            ctlGuitarStrings.Name = "ctlGuitarStrings";
            ctlGuitarStrings.Size = new System.Drawing.Size(786, 268);
            ctlGuitarStrings.TabIndex = 0;
            // 
            // tabColors
            // 
            tabColors.Controls.Add(panel2);
            tabColors.Location = new System.Drawing.Point(4, 29);
            tabColors.Name = "tabColors";
            tabColors.Padding = new System.Windows.Forms.Padding(3);
            tabColors.Size = new System.Drawing.Size(792, 417);
            tabColors.TabIndex = 1;
            tabColors.Text = "Colors";
            tabColors.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(ctlThirteenth);
            panel2.Controls.Add(ctlEleventh);
            panel2.Controls.Add(ctlNinth);
            panel2.Controls.Add(ctlSeventh);
            panel2.Controls.Add(ctlSixth);
            panel2.Controls.Add(ctlFifth);
            panel2.Controls.Add(ctlFourth);
            panel2.Controls.Add(ctlThird);
            panel2.Controls.Add(ctlSecond);
            panel2.Controls.Add(ctlRoot);
            panel2.Dock = System.Windows.Forms.DockStyle.Left;
            panel2.Location = new System.Drawing.Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(284, 411);
            panel2.TabIndex = 0;
            // 
            // ctlSeventh
            // 
            ctlSeventh.ColorContext = null;
            ctlSeventh.Dock = System.Windows.Forms.DockStyle.Top;
            ctlSeventh.Label = "label1";
            ctlSeventh.Location = new System.Drawing.Point(0, 180);
            ctlSeventh.Name = "ctlSeventh";
            ctlSeventh.Size = new System.Drawing.Size(284, 30);
            ctlSeventh.TabIndex = 6;
            // 
            // ctlSixth
            // 
            ctlSixth.ColorContext = null;
            ctlSixth.Dock = System.Windows.Forms.DockStyle.Top;
            ctlSixth.Label = "label1";
            ctlSixth.Location = new System.Drawing.Point(0, 150);
            ctlSixth.Name = "ctlSixth";
            ctlSixth.Size = new System.Drawing.Size(284, 30);
            ctlSixth.TabIndex = 5;
            // 
            // ctlFifth
            // 
            ctlFifth.ColorContext = null;
            ctlFifth.Dock = System.Windows.Forms.DockStyle.Top;
            ctlFifth.Label = "label1";
            ctlFifth.Location = new System.Drawing.Point(0, 120);
            ctlFifth.Name = "ctlFifth";
            ctlFifth.Size = new System.Drawing.Size(284, 30);
            ctlFifth.TabIndex = 4;
            // 
            // ctlFourth
            // 
            ctlFourth.ColorContext = null;
            ctlFourth.Dock = System.Windows.Forms.DockStyle.Top;
            ctlFourth.Label = "label1";
            ctlFourth.Location = new System.Drawing.Point(0, 90);
            ctlFourth.Name = "ctlFourth";
            ctlFourth.Size = new System.Drawing.Size(284, 30);
            ctlFourth.TabIndex = 3;
            // 
            // ctlThird
            // 
            ctlThird.ColorContext = null;
            ctlThird.Dock = System.Windows.Forms.DockStyle.Top;
            ctlThird.Label = "label1";
            ctlThird.Location = new System.Drawing.Point(0, 60);
            ctlThird.Name = "ctlThird";
            ctlThird.Size = new System.Drawing.Size(284, 30);
            ctlThird.TabIndex = 2;
            // 
            // ctlSecond
            // 
            ctlSecond.ColorContext = null;
            ctlSecond.Dock = System.Windows.Forms.DockStyle.Top;
            ctlSecond.Label = "label1";
            ctlSecond.Location = new System.Drawing.Point(0, 30);
            ctlSecond.Name = "ctlSecond";
            ctlSecond.Size = new System.Drawing.Size(284, 30);
            ctlSecond.TabIndex = 1;
            // 
            // ctlRoot
            // 
            ctlRoot.ColorContext = null;
            ctlRoot.Dock = System.Windows.Forms.DockStyle.Top;
            ctlRoot.Label = "label1";
            ctlRoot.Location = new System.Drawing.Point(0, 0);
            ctlRoot.Name = "ctlRoot";
            ctlRoot.Size = new System.Drawing.Size(284, 30);
            ctlRoot.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(bnCancel);
            panel1.Controls.Add(bnOK);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 420);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(800, 30);
            panel1.TabIndex = 1;
            // 
            // bnCancel
            // 
            bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            bnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            bnCancel.Location = new System.Drawing.Point(650, 0);
            bnCancel.Name = "bnCancel";
            bnCancel.Size = new System.Drawing.Size(75, 30);
            bnCancel.TabIndex = 1;
            bnCancel.Text = "Cancel";
            bnCancel.UseVisualStyleBackColor = true;
            bnCancel.Click += bnCancel_Click;
            // 
            // bnOK
            // 
            bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            bnOK.Dock = System.Windows.Forms.DockStyle.Right;
            bnOK.Location = new System.Drawing.Point(725, 0);
            bnOK.Name = "bnOK";
            bnOK.Size = new System.Drawing.Size(75, 30);
            bnOK.TabIndex = 0;
            bnOK.Text = "OK";
            bnOK.UseVisualStyleBackColor = true;
            bnOK.Click += bnOK_Click;
            // 
            // ctlNinth
            // 
            ctlNinth.ColorContext = null;
            ctlNinth.Dock = System.Windows.Forms.DockStyle.Top;
            ctlNinth.Label = "label1";
            ctlNinth.Location = new System.Drawing.Point(0, 210);
            ctlNinth.Name = "ctlNinth";
            ctlNinth.Size = new System.Drawing.Size(284, 30);
            ctlNinth.TabIndex = 7;
            // 
            // ctlEleventh
            // 
            ctlEleventh.ColorContext = null;
            ctlEleventh.Dock = System.Windows.Forms.DockStyle.Top;
            ctlEleventh.Label = "label1";
            ctlEleventh.Location = new System.Drawing.Point(0, 240);
            ctlEleventh.Name = "ctlEleventh";
            ctlEleventh.Size = new System.Drawing.Size(284, 30);
            ctlEleventh.TabIndex = 8;
            // 
            // ctlThirteenth
            // 
            ctlThirteenth.ColorContext = null;
            ctlThirteenth.Dock = System.Windows.Forms.DockStyle.Top;
            ctlThirteenth.Label = "label1";
            ctlThirteenth.Location = new System.Drawing.Point(0, 270);
            ctlThirteenth.Name = "ctlThirteenth";
            ctlThirteenth.Size = new System.Drawing.Size(284, 30);
            ctlThirteenth.TabIndex = 9;
            // 
            // OptionsDialog
            // 
            AcceptButton = bnOK;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = bnCancel;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(tabControl);
            Name = "OptionsDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "OptionsDialog";
            tabControl.ResumeLayout(false);
            tabGuitarStrings.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabColors.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGuitarStrings;
        private System.Windows.Forms.TabPage tabColors;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Panel panel2;
        private ColorSelectorControl ctlRoot;
        private ColorSelectorControl ctlSecond;
        private ColorSelectorControl ctlThird;
        private ColorSelectorControl ctlFourth;
        private ColorSelectorControl ctlFifth;
        private ColorSelectorControl ctlSixth;
        private ColorSelectorControl ctlSeventh;
        private System.Windows.Forms.Panel panel3;
        private GuitarStringsControl ctlGuitarStrings;
        private ColorSelectorControl ctlThirteenth;
        private ColorSelectorControl ctlEleventh;
        private ColorSelectorControl ctlNinth;
    }
}
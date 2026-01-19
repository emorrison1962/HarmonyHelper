namespace NeckDiagrams.Controls
{
    partial class GuitarNeckSettingsDialog
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
            ctlGuitarStrings = new GuitarStringsControl();
            bnOK = new System.Windows.Forms.Button();
            bnCancel = new System.Windows.Forms.Button();
            bnSave = new System.Windows.Forms.Button();
            pnlButtons = new System.Windows.Forms.Panel();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // ctlGuitarStrings
            // 
            ctlGuitarStrings.Dock = System.Windows.Forms.DockStyle.Top;
            ctlGuitarStrings.GuitarStringCollection = null;
            ctlGuitarStrings.Location = new System.Drawing.Point(0, 0);
            ctlGuitarStrings.Name = "ctlGuitarStrings";
            ctlGuitarStrings.Size = new System.Drawing.Size(800, 268);
            ctlGuitarStrings.TabIndex = 0;
            // 
            // bnOK
            // 
            bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            bnOK.Location = new System.Drawing.Point(713, 2);
            bnOK.Name = "bnOK";
            bnOK.Size = new System.Drawing.Size(75, 25);
            bnOK.TabIndex = 1;
            bnOK.Text = "OK";
            bnOK.UseVisualStyleBackColor = true;
            bnOK.Click += bnOK_Click;
            // 
            // bnCancel
            // 
            bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            bnCancel.Location = new System.Drawing.Point(632, 2);
            bnCancel.Name = "bnCancel";
            bnCancel.Size = new System.Drawing.Size(75, 25);
            bnCancel.TabIndex = 1;
            bnCancel.Text = "Cancel";
            bnCancel.UseVisualStyleBackColor = true;
            bnCancel.Click += bnCancel_Click;
            // 
            // bnSave
            // 
            bnSave.DialogResult = System.Windows.Forms.DialogResult.Yes;
            bnSave.Location = new System.Drawing.Point(551, 2);
            bnSave.Name = "bnSave";
            bnSave.Size = new System.Drawing.Size(75, 25);
            bnSave.TabIndex = 1;
            bnSave.Text = "Save";
            bnSave.UseVisualStyleBackColor = true;
            bnSave.Click += bnSave_Click;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(bnOK);
            pnlButtons.Controls.Add(bnSave);
            pnlButtons.Controls.Add(bnCancel);
            pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlButtons.Location = new System.Drawing.Point(0, 420);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(800, 30);
            pnlButtons.TabIndex = 2;
            // 
            // GuitarNeckSettingsDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(pnlButtons);
            Controls.Add(ctlGuitarStrings);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GuitarNeckSettingsDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "GuitarNeckSettingsDialog";
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GuitarStringsControl ctlGuitarStrings;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.Panel pnlButtons;
    }
}
﻿using NeckDiagrams.Controls;

namespace NeckDiagrams
{
    partial class ChordParserDialog
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this._chordNamesControl = new ChordNamesControl();
            this.chordsEditPanel = new System.Windows.Forms.Panel();
            this._tbChords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bnOk = new System.Windows.Forms.Button();
            this.bnParse = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.chordsEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this._chordNamesControl);
            this.mainPanel.Controls.Add(this.chordsEditPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(900, 562);
            this.mainPanel.TabIndex = 6;
            // 
            // chordsTablePanel
            // 
            this._chordNamesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chordNamesControl.Location = new System.Drawing.Point(0, 250);
            this._chordNamesControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._chordNamesControl.Name = "chordsTablePanel";
            this._chordNamesControl.Size = new System.Drawing.Size(900, 312);
            this._chordNamesControl.TabIndex = 3;
            // 
            // chordsEditPanel
            // 
            this.chordsEditPanel.Controls.Add(this._tbChords);
            this.chordsEditPanel.Controls.Add(this.label2);
            this.chordsEditPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chordsEditPanel.Location = new System.Drawing.Point(0, 0);
            this.chordsEditPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chordsEditPanel.Name = "chordsEditPanel";
            this.chordsEditPanel.Size = new System.Drawing.Size(900, 250);
            this.chordsEditPanel.TabIndex = 2;
            // 
            // _tbChords
            // 
            this._tbChords.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbChords.Location = new System.Drawing.Point(68, 0);
            this._tbChords.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._tbChords.Multiline = true;
            this._tbChords.Name = "_tbChords";
            this._tbChords.Size = new System.Drawing.Size(832, 250);
            this._tbChords.TabIndex = 0;
            this._tbChords.Text = "cmaj7 bm7b5 e7 am7 d7 gm7 c7 f7 fm7 bb7 ebm7 ab7 dm7 g7 cmaj7 a7 dm7 g7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chords: ";
            // 
            // bnOk
            // 
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Location = new System.Drawing.Point(802, 519);
            this.bnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(84, 29);
            this.bnOk.TabIndex = 7;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnParse
            // 
            this.bnParse.Location = new System.Drawing.Point(711, 519);
            this.bnParse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bnParse.Name = "bnParse";
            this.bnParse.Size = new System.Drawing.Size(84, 29);
            this.bnParse.TabIndex = 8;
            this.bnParse.Text = "Parse";
            this.bnParse.UseVisualStyleBackColor = true;
            this.bnParse.Click += new System.EventHandler(this.bnParse_Click);
            // 
            // ChordParserDialog
            // 
            this.AcceptButton = this.bnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.bnParse);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChordParserDialog";
            this.Text = "ChordParserDialog";
            this.mainPanel.ResumeLayout(false);
            this.chordsEditPanel.ResumeLayout(false);
            this.chordsEditPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel chordsEditPanel;
        private System.Windows.Forms.TextBox _tbChords;
        private System.Windows.Forms.Label label2;
        private ChordNamesControl _chordNamesControl;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnParse;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NeckDiagrams.Domain;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NeckDiagrams.Controls
{
    public partial class ColorSelectorControl : UserControl
    {
        ColorContext _ColorContext { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ColorContext ColorContext
        {
            get { return this._ColorContext; }
            set
            {
                this._ColorContext = value;
                this.Label = this._ColorContext.Label;
                this.SetColor(this._ColorContext.Color);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Label { get { return this.lblChordTone.Text; } set { this.lblChordTone.Text = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Color { get { return ColorContext.Color; } set { ColorContext.Color = value; } }

        public ColorSelectorControl()
        {
            InitializeComponent();
            this.Init();
        }

        void Init()
        {
        }

        private void bnColor_Click(object sender, EventArgs e)
        {
            // Define an array of custom colors (BGR format required for this property)
            int[] customColorsBGR = new int[]
            {
                ToInt(Color.Red),
                ToInt(Color.HotPink),
                ToInt(Color.Orange),
                ToInt(Color.Yellow),
                ToInt(Color.Violet),
                ToInt(Color.LimeGreen),
                ToInt(Color.CornflowerBlue),
            };

            dlgColor.CustomColors = customColorsBGR;

            var dr = dlgColor.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.SetColor(dlgColor.Color);
            }
        }

        void SetColor(Color color)
        {
            this.Color = color;
            this.lblChordTone.BackColor = Color;

            var brightness = this.Color.GetBrightness();
            if (brightness <= .5)
                lblChordTone.ForeColor = Color.White;
        }

        int ToInt(Color color)
        {
            return (color.B << 8) | (color.G << 8) | (color.R);
        }
    }//class
}//ns

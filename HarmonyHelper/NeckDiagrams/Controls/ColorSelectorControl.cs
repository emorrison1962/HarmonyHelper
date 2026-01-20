using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                if (value != null)
                {
                    this._ColorContext = value;
                    this.Label = this._ColorContext.Label;
                    this.SetColor(this._ColorContext.Color);
                }
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
            this.VisibleChanged += ColorSelectorControl_VisibleChanged;
        }

        private void ColorSelectorControl_VisibleChanged(object sender, EventArgs e)
        {
            new object();
        }

        void Init()
        {
        }

        protected override void InitLayout()
        {
            base.InitLayout();
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

            var grayscale = this.ToGrayscaleLuminosity(this.Color);
            if (grayscale.R <= 127)
            {
                lblChordTone.ForeColor = Color.White;
            }
            else
            {
                lblChordTone.ForeColor = Color.Black;
            }
        }

        public Color ToGrayscaleLuminosity(Color originalColor)
        {
            int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
            return Color.FromArgb(originalColor.A, grayScale, grayScale, grayScale);
        }

        int ToInt(Color color)
        {
            return (color.B << 8) | (color.G << 8) | (color.R);
        }
    }//class
}//ns

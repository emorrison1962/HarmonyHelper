using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NeckDiagrams.Controls
{
    public partial class RuneControl : UserControl
    {
        Color NORMAL_COLOR = System.Drawing.SystemColors.Control;
        Color SELECTED_COLOR = Color.CornflowerBlue;

        //public ChordFormula Chord { get { return VM.ChordFormula; } }
        //public ChordFormulaVM VM { get; set; }

        public Rune Rune { get; set; }
        string _SelectedFont;
        public string SelectedFont
        {
            get { return this._SelectedFont; }
            set
            {
                this._SelectedFont = value;
                this.Refresh();
                this.Update();
            }
        }

        public bool _IsSelected = false;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                this.OnSelected();
            }
        }

        public RuneControl(IFontProvider fp, Rune rune)
        {
            InitializeComponent();
            this.Rune = rune;
        }
        public void SetFontProvider(IFontProvider provider)
        {
            if (provider is not null)
            {
                provider.FontChanged += Fp_FontChanged;
            }
        }

        private void Fp_FontChanged(object? sender, string e)
        {
            this.SelectedFont = e;
            this.Invalidate(this.Region);

            var parent = this.Parent as System.Windows.Forms.TableLayoutPanel;
            

            Debug.WriteLine($"row={parent.GetRow(this)}, col={parent.GetColumn(this)}");

            //this.Update();
        }



        //public RuneControl(ChordFormulaVM vm, HarmonicAnalysisControl parent)
        //    : this(vm)
        //{
        //    if (null != parent)
        //        this.SubscribeToEvents(parent);
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void RuneControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.IsSelected = !this.IsSelected;
        }

        private void lblRune_Click(object sender, EventArgs e)
        {
            this.IsSelected = !this.IsSelected;
        }

        private void OnSelected()
        {
            if (this.IsSelected)
            {
                this.BackColor = SELECTED_COLOR;
            }
            else
            {
                this.BackColor = NORMAL_COLOR;
            }
        }

        private void lblRune_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void RuneControl_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void RuneControl_Paint(object sender, PaintEventArgs e)
        {
            using (var font = new Font(this.SelectedFont, (float)20.0))
            {
                var brush = Brushes.Black;
                var pt = e.ClipRectangle.Location;
                Debug.WriteLine($"{this.Location}, {this.Size}");

                e.Graphics.DrawString(this.Rune.ToString(), 
                    font, brush, pt);
                new object();
            }
        }

        private void DrawText(object sender, PaintEventArgs e)
        {
            //var font = new Font("Bravura", 40)
            //var font = new Font("Petaluma", 50f, GraphicsUnit.Pixel)
            using (var font = new Font("Bravura", 40))
            {
                var brush = Brushes.Black;
                var pt = e.ClipRectangle.Location;

                var str = "\u0069";
                for (int i = 0xE010, ndx = 0; i < 0xE0FF; ++i, ++ndx)
                {//"U+F52C"
                    var r1 = new Rune(i);
                    str += r1.ToString();
                }

                e.Graphics.DrawString(str, font, brush, pt);
                new object();
            }
        }



    }//class
}//ns

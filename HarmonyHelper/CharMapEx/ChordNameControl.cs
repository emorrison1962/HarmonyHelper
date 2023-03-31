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
    public partial class ChordNameControl : UserControl
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
                this.Invalidate();
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

        public ChordNameControl(Rune rune)
        {
            InitializeComponent();
            this.Rune = rune;
        }

        //public ChordNameControl(ChordFormulaVM vm, HarmonicAnalysisControl parent)
        //    : this(vm)
        //{
        //    if (null != parent)
        //        this.SubscribeToEvents(parent);
        //}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.lblChordName.Text = Rune.ToString();
        }

        private void ChordNameControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.IsSelected = !this.IsSelected;
        }

        private void lblChordName_Click(object sender, EventArgs e)
        {
            this.IsSelected = !this.IsSelected;
        }

        private void OnSelected()
        {
            if (this.IsSelected)
            {
                this.BackColor = SELECTED_COLOR;
                this.lblChordName.BackColor = SELECTED_COLOR;
            }
            else
            {
                this.BackColor = NORMAL_COLOR;
                this.lblChordName.BackColor = NORMAL_COLOR;
            }
        }

        private void lblChordName_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void ChordNameControl_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void ChordNameControl_Paint(object sender, PaintEventArgs e)
        {
            using (var font = new Font(this.SelectedFont, (float)20.0))
            {
                Debug.WriteLine(this.Rune.ToString());
                e.Graphics.DrawString(this.Rune.ToString(),
                    font,
                    Brushes.Black,
                    e.ClipRectangle);
            }
        }
    }//class
}//ns

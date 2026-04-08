using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony.Chords;

using NeckDiagrams.Views;

namespace NeckDiagrams.Controls
{
    public partial class ChordNameControl : UserControl
    {
        Color SELECTED_COLOR = Color.CornflowerBlue;
        Color DE_SELECTED_COLOR = System.Drawing.SystemColors.Control;


        #region Properties

        public override string Text { get => lblChordName.Text; set => lblChordName.Text = value; }

        public event EventHandler<ChordNameControl> Selected;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ChordFormulaVM ChordFormula { get; set; }

        public bool _IsSelected = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    this.OnSelected();
                }
            }
        }

        #endregion

        #region Construction
        public ChordNameControl(ChordFormulaVM vm)
        {
            InitializeComponent();
            this.ChordFormula = vm;

#warning This is a bit hacky, but it gives us a nice color scheme for the chord names.  We can always change this later if we want to.
            switch (vm.ChordFormula.Root.NameAscii.ToLower()[0])
            { 
                case 'a':
                    SELECTED_COLOR = Color.FromArgb(244, 67, 54);
                    break;
                case 'b':
                    SELECTED_COLOR = Color.FromArgb(156, 39, 176);
                    break;
                case 'c':
                    SELECTED_COLOR = Color.FromArgb(63, 81, 181);
                    break;
                case 'd':
                    SELECTED_COLOR = Color.FromArgb(3, 169, 244);
                    break;
                case 'e':
                    SELECTED_COLOR = Color.FromArgb(0, 150, 136);
                    break;
                case 'f':
                    SELECTED_COLOR = Color.FromArgb(139, 195, 74);
                    break;
                case 'g':
                    SELECTED_COLOR = Color.FromArgb(255, 235, 59);
                    break;
            }
        }

        public ChordNameControl(ChordFormulaVM vm, HarmonicAnalysisControl parent)
            : this(vm)
        {
            if (null != parent)
                this.SubscribeToEvents(parent);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.lblChordName.Text = ChordFormula.ChordFormula.NameAscii;
        }

        #endregion

        void SubscribeToEvents(HarmonicAnalysisControl parent)
        {
            parent.AnalysisResultChanged += Parent_AnalysisResultChanged;
        }

        private void Parent_AnalysisResultChanged(object sender, HarmonicAnalysisControl.AnalysisResultEventArgs e)
        {
            if (e.Result.Chords
                .Contains(this.ChordFormula.ChordFormula, new ChordFormulaInstanceEqualityComparer()))
            {
                this.IsSelected = true;
            }
            else
            {
                this.IsSelected = false;
            }
            this.Refresh();
        }

        private class ChordFormulaInstanceEqualityComparer : IEqualityComparer<ChordFormula>
        {
            bool IEqualityComparer<ChordFormula>.Equals(ChordFormula x, ChordFormula y)
            {
                return Object.ReferenceEquals(x, y);
            }

            int IEqualityComparer<ChordFormula>.GetHashCode(ChordFormula obj)
            {
                return Guid.NewGuid().GetHashCode();
            }
        }

        private void _MouseClick(object sender, EventArgs e)
        {
            this.IsSelected = !this.IsSelected;
        }

        private void OnSelected()
        {
            SetColor();
            if (null != this.Selected)
                this.Selected(this, this);
        }


        void SetColor()
        {
            if (this.IsSelected)
            {
                base.BackColor = SELECTED_COLOR;
                this.lblChordName.BackColor = SELECTED_COLOR;
            }
            else
            {
                base.BackColor = DE_SELECTED_COLOR;
                this.lblChordName.BackColor = DE_SELECTED_COLOR;
            }
            Invalidate();
        }

        void SetBackColor(Color color)
        {
            base.BackColor = color;
            this.lblChordName.BackColor = color;
        }

        private void lblChordName_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
    }//class
}//ns

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

namespace NeckDiagrams.Controls
{
    public partial class ChordNameControl : UserControl
    {
        Color NORMAL_COLOR = System.Drawing.SystemColors.Control;
        Color SELECTED_COLOR = Color.CornflowerBlue;

        public ChordFormula Chord { get { return VM.ChordFormula; } }
        public ChordFormulaVM VM { get; set; }

        public bool _IsSelected = false;
        public bool IsSelected 
        {
            get 
            {
                return _IsSelected;
            }
            private set 
            {
                _IsSelected = value;
                this.OnSelected();
            } 
        }

        public ChordNameControl(ChordFormulaVM vm)
        {
            InitializeComponent();
            this.VM = vm;
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
            this.lblChordName.Text = Chord.Name; 
        }

        void SubscribeToEvents(HarmonicAnalysisControl parent)
        {
            parent.AnalysisResultChanged += Parent_AnalysisResultChanged;
        }

        private void Parent_AnalysisResultChanged(object sender, HarmonicAnalysisControl.AnalysisResultEventArgs e)
        {
            if (e.Result.Chords.Contains(this.Chord, new ChordFormulaInstanceEqualityComparer()))
            {
                this.lblChordName.BackColor = SELECTED_COLOR;
            }
            else
            {
                this.lblChordName.BackColor = NORMAL_COLOR;
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

        private void ChordNameControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnSelected();
        }

        private void lblChordName_Click(object sender, EventArgs e)
        {
            this.OnSelected();
        }

        private void OnSelected()
        {
            this._IsSelected = !this._IsSelected;
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
    }//class
}//ns

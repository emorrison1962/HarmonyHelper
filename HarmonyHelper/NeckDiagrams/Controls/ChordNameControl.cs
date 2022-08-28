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
        public ChordFormula Chord { get; set; }
        public ChordNameControl(ChordFormula chord)
        {
            InitializeComponent();
            this.Chord = chord;
        }

        public ChordNameControl(ChordFormula chord, HarmonicAnalysisControl parent)
            : this(chord)
        {
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
                this.lblChordName.BackColor = Color.CornflowerBlue;
            }
            else
            {
                this.lblChordName.BackColor = SystemColors.Control;
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
    }//class
}//ns

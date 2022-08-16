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
        public Chord Chord { get; set; }
        public ChordNameControl(Chord cf)
        {
            InitializeComponent();
            this.Chord = cf;
        }

        public ChordNameControl(Chord cf, HarmonicAnalysisControl parent)
        {
            InitializeComponent();
            this.SubscribeToEvents(parent);
            this.Chord = cf; 
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
            if (e.Result.Chords.Contains(this.Chord, new ChordInstanceEqualityComparer()))
            {
                this.lblChordName.BackColor = Color.CornflowerBlue;
            }
            else
            {
                this.lblChordName.BackColor = SystemColors.Control;
            }
            this.Refresh();
        }

        private class ChordInstanceEqualityComparer : IEqualityComparer<Chord>
        {
            bool IEqualityComparer<Chord>.Equals(Chord x, Chord y)
            {
                return Object.ReferenceEquals(x, y);
            }

            int IEqualityComparer<Chord>.GetHashCode(Chord obj)
            {
                return Guid.NewGuid().GetHashCode();
            }
        }
    }//class
}//ns

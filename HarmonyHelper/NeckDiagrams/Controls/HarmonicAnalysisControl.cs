using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeckDiagrams.Controls
{
    public partial class HarmonicAnalysisControl : UserControl
    {
        public HarmonicAnalysisControl()
        {
            InitializeComponent();
        }

        public List<Chord> Chords { get; private set; } = new List<Chord>();

        private void bnChords_Click(object sender, EventArgs e)
        {
            var dlg = new ChordParserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            { 
                this.Chords = dlg.Chords;
                this.Populate();
            }
        }

        private void Populate()
        {
            foreach (var chord in this.Chords)
            {
                var ctl = new ChordNameControl(chord.Formula);
                this.chordsTablePanel.Controls.Add(
                    ctl);
                ctl.Show();
            }
        }
    }
}

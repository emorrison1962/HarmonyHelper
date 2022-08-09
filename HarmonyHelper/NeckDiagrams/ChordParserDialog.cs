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

using Eric.Morrison.Harmony.Chords;

using NeckDiagrams.Controls;

namespace NeckDiagrams
{
    public partial class ChordParserDialog : Form
    {
        public ChordParserDialog()
        {
            InitializeComponent();
        }

        private void bnParse_Click(object sender, EventArgs e)
        {
            if (ChordParser.TryParse(this._tbChords.Text, out var chords, out var messageResult))
            {
                this.Populate(chords);
            }
            else
            {
                Debug.WriteLine(messageResult);
            }
        }

        private void Populate(List<Chord> chords)
        {
            foreach (var chord in chords)
            {
                var ctl = new ChordNameControl(chord.Formula);
                this.chordsDisplayPanel.Controls.Add(
                    ctl);
                ctl.Show();
            }
        }
    }
}

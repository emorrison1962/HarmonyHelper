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
        public List<Chord> Chords { get; set; }
        public ChordParserDialog()
        {
            InitializeComponent();
            this.bnOk.Enabled = false;  
        }

        private void bnParse_Click(object sender, EventArgs e)
        {
            if (ChordParser.TryParse(this._tbChords.Text, out var chords, out var messageResult))
            {
                this.Chords = chords;   
                this.Populate();
                this.bnOk.Enabled = true;
            }
            else
            {
                Debug.WriteLine(messageResult);
            }
        }

        private void Populate()
        {
            foreach (var chord in this.Chords)
            {
                var ctl = new ChordNameControl(chord.Formula);
                this.chordsDisplayPanel.Controls.Add(
                    ctl);
                ctl.Show();
            }
        }
    }
}

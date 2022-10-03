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
        public List<ChordFormulaVM> ChordFormulaVMs { get; set; }
        public ChordParserDialog()
        {
            InitializeComponent();
            this.bnOk.Enabled = false;  
        }

        private void bnParse_Click(object sender, EventArgs e)
        {
            if (ChordFormulaParser.TryParse(this._tbChords.Text, out var key, out var formulas, out var messageResult))
            {
                var vms = formulas.Select(x => 
                new ChordFormulaVM(x, Guid.NewGuid()));
                this.ChordFormulaVMs = vms.ToList();   
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
            foreach (var vm in this.ChordFormulaVMs)
            {
                this._chordNamesControl.Add(vm);
            }
        }
    }
}

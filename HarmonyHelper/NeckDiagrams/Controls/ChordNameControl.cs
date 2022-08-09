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
        public ChordFormula ChordFormula { get; set; }
        public ChordNameControl(ChordFormula cf)
        {
            InitializeComponent();
            this.ChordFormula = cf; 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.lblChordName.Text = ChordFormula.Name; 
        }
    }
}

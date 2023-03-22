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
    public partial class ArpeggiatorControl : UserControl
    {
        public ArpeggiatorControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        List<ChordFormulaVM> ChordFormulaVMs { get; set; } 
        private void _bnChords_Click(object sender, EventArgs e)
        {
            var dlg = new ChordParserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                this.ChordFormulaVMs = dlg.ChordFormulaVMs;
            }
        }
    }//class
}//ns

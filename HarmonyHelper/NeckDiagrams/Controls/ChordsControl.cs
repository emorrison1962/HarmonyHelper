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
    public partial class ChordsControl : UserControl
    {
        public ChordsControl()
        {
            InitializeComponent();
        }

        private void _tbChords_Click(object sender, EventArgs e)
        {
            var dlg = new ChordParserDialog();  
            dlg.ShowDialog();
        }
    }
}

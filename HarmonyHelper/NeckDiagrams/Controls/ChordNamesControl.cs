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

namespace NeckDiagrams.Controls
{
    public partial class ChordNamesControl : UserControl
    {
        public List<ChordFormulaVM> ChordFormulaVMs { get; private set; } = new List<ChordFormulaVM>();
        public bool MouseIsDragging { get; private set; }
        public Point DragBeginPoint { get; private set; }

        public ChordNamesControl()
        {
            InitializeComponent();
            this.Load += ChordNamesControl_Load;
        }

        private void ChordNamesControl_Load(object sender, EventArgs e)
        {
            this._chordNamesTablePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordNamesControl_MouseDown);
            this._chordNamesTablePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChordNamesControl_MouseMove);
            this._chordNamesTablePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordNamesControl_MouseUp);
            this.MouseDragContext = new MouseDragContext();
        }

        public void Add(ChordFormulaVM vm, HarmonicAnalysisControl parent = null)
        {
            var ctl = new ChordNameControl(
                vm, parent);
            this._chordNamesTablePanel.Controls.Add(ctl);
        }

        public void AddRange(IEnumerable<ChordFormulaVM> vms, HarmonicAnalysisControl parent = null)
        {
            var vmList = vms.ToList();
            vmList.ForEach(x => this.Add(x, parent));
        }

    }//class
}//ns

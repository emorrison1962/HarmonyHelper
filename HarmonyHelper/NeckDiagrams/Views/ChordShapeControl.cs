using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using NeckDiagrams.Controls;



namespace NeckDiagrams.Views
{
    public partial class ChordShapeControl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ChordFormula ChordFormula { get; set; }

        public ChordShapeControl()
        {
            InitializeComponent();
            this.Init();
        }

        void Init()
        {
            this.ctlChordTypeSelectorControl.ChordFolmulaChanged += CtlChordTypeSelectorControl_ChordFolmulaChanged;
        }

        private void CtlChordTypeSelectorControl_ChordFolmulaChanged(object sender, ChordFormulaContext e)
        {
            this.ChordFormula = e.Value;
            this.ctlNeck.SetChord(this.ChordFormula);
        }

        void foo()
        {
            var dlg = new GuitarNeckSettingsDialog();
            var dr = dlg.ShowDialog();
        }

    }//class
}//ns

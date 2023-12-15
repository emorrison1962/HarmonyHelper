using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

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
    public partial class ModalInterchangeView : UserControl
    {
        public KeySignature KeySignature { get; private set; }

        public ModalInterchangeView()
        {
            InitializeComponent();
            this._keySignatureCombo.KeySignatureChanged += _keySignatureCombo_KeySignatureChanged;
        }

        private void _keySignatureCombo_KeySignatureChanged(object sender, KeySignature e)
        {
            this.KeySignature = e;
            this.CreateGrids();
        }

        FlowLayoutPanel GetParentPanel(ModalInterchangeGrid grid)
        {
            FlowLayoutPanel result = null;
            if (grid.IsMajor)
            {
                result = this.flowLayoutPanelMajor;
            }
            else if (grid.IsMelodicMinor)
            {
                result = this.flowLayoutPanelMelodicMinor;
            }
            else if (grid.IsHarmonicMinor)
            {
                result = this.flowLayoutPanelHarmonicMinor;
            }
            Debug.Assert(result != null);
            return result;

        }

        private void CreateGrids()
        {
            var rule = new BorrowedChordHarmonicAnalysisRule();
            var grids = rule.CreateGrids(this.KeySignature);
            foreach (var grid in grids)
            {
                var parent = this.GetParentPanel(grid);

                foreach (var row in grid.Rows)
                {
                    foreach (var chord in row.Chords)
                    {
                        var vm = new ChordFormulaVM(chord, Guid.NewGuid());
                        var ctl = new ChordNameControl(vm);
                        parent.Controls.Add(ctl);
                    }
                    var chords = row.Chords.Select(x => x.Name).ToList();
                    var s = $"{row.ModeName} | {chords[0]} | {chords[1]} | {chords[2]} | {chords[3]} | {chords[4]} | {chords[5]} | {chords[6]} | ";


                    Debug.WriteLine(s);
                    new object();
                }
                new object();
            }
        }

        private void Populate()
        {
            //this._chordNamesControl.AddRange(this.ChordFormulaVMs, this);
        }





    }//class
}//ns

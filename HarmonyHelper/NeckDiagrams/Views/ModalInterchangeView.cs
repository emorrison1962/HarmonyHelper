using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

using Manufaktura.Music.Model;

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

        TableLayoutPanel GetParentPanel(ModalInterchangeGrid grid)
        {
            TableLayoutPanel result = null;
            if (grid.IsMajor)
            {
                result = this._panelMajor;
            }
            else if (grid.IsMelodicMinor)
            {
                result = this._panelMelodicMinor;
            }
            else if (grid.IsHarmonicMinor)
            {
                result = this._panelHarmonicMinor;
            }
            Debug.Assert(result != null);
            return result;

        }

        Control CreateCellControl(string text)
        {
            var result = new TextBox();
            result.Text = text;
            result.ReadOnly = true;
            result.BorderStyle = BorderStyle.None;
            return result;
        }

        private void CreateGrids()
        {
            var rule = new BorrowedChordHarmonicAnalysisRule();
            var grids = rule.CreateGrids(this.KeySignature);
            foreach (var grid in grids)
            {
                var parent = this.GetParentPanel(grid);
                var rowCount = grid.Rows.Count;
                for (int ndxRow = 0; ndxRow < rowCount; ++ndxRow)
                {
                    var row = grid.Rows[ndxRow];
                    var chordCount = row.Chords.Count;
                    for (int ndxColumn = 0; ndxColumn < chordCount; ++ndxColumn)
                    {
                        if (ndxColumn == 0)
                        {
                            var col1 = CreateCellControl(row.ModeName);
                            col1.Width = parent.Parent.Width / 8;
                            parent.Controls.Add(col1, 0, ndxRow);
                        }

                        var chord = row.Chords[ndxColumn];
                        var vm = new ChordFormulaVM(chord, Guid.NewGuid());
                        var ctl = new ChordNameControl(vm);
                        var cx = parent.ClientSize.Width / 8;
                        //ctl.Width = cx;
                        //parent.Controls.Add(ctl, ndxColumn + 1, ndxRow);
                        //ctl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                        
                        ctl.Dock = DockStyle.Fill;
                        parent.Controls.Add(CreateCellControl(chord.Name), ndxColumn + 1, ndxRow);
                    }

                    //var rc = parent.DisplayRectangle;
                    //rc = parent.DisplayRectangle;
                    for (int i = 0; i < parent.ColumnStyles.Count; ++i)
                    {
                        var col = parent.ColumnStyles[i];
                        var cx = parent.ClientSize.Width / 8;
                        col.Width = cx;
                        col.Width = 200;
                    }


                    var chords = row.Chords.Select(x => x.Name).ToList();
                    var s = $"{row.ModeName} | {chords[0]} | {chords[1]} | {chords[2]} | {chords[3]} | {chords[4]} | {chords[5]} | {chords[6]} | ";


                    Debug.WriteLine(s);
                    new object();
                }
                new object();
                //parent.Refresh();
                //parent.PerformLayout();
            }

            this.Refresh();
        }

        private void Populate()
        {
            //this._chordNamesControl.AddRange(this.ChordFormulaVMs, this);
        }





    }//class
}//ns

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;

using Manufaktura.Music.Model;

using NeckDiagrams.Controls;

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

namespace NeckDiagrams.Views
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
            Task.Run(() => this.CreateGrids());
        }

        ModalInterchangeGridControl GetGridControl(ModalInterchangeGrid grid)
        {
            ModalInterchangeGridControl result = null;
            if (grid.IsMajor)
            {
                result = this._gridMajor;
            }
            else if (grid.IsMelodicMinor)
            {
                result = this._gridMelodicMinor;
            }
            else if (grid.IsHarmonicMinor)
            {
                result = this._gridHarmonicMinor;
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

        async Task CreateGrids()
        {
            if (this.InvokeRequired)
            {
                await Task.Run(() => this.Invoke(this.CreateGrids));
            }

            var rule = new BorrowedChordHarmonicAnalysisRule();
            var grids = await Task.Run(() => rule.CreateGrids(this.KeySignature));
            foreach (var grid in grids)
            {
                var miGrid = this.GetGridControl(grid);
                var rowCount = grid.Rows.Count;
                for (int ndxRow = 0; ndxRow < rowCount; ++ndxRow)
                {
                    var row = grid.Rows[ndxRow];
                    var chordCount = row.Chords.Count;
                    for (int ndxColumn = 0; ndxColumn < chordCount; ++ndxColumn)
                    {
                        if (ndxColumn == 0)
                        {
                            this.Invoke(() =>
                            {
                                miGrid.GetControl(0, ndxRow).Text = row.ModeName;
                            });
                        }

                        var chord = row.Chords[ndxColumn];
                        this.Invoke(() =>
                        {
                            miGrid.GetControl((ndxColumn + 1), ndxRow).Text = chord.Name;
                        });
                    }

                    var chords = row.Chords.Select(x => x.Name).ToList();
                    var s = $"{row.ModeName} | {chords[0]} | {chords[1]} | {chords[2]} | {chords[3]} | {chords[4]} | {chords[5]} | {chords[6]} | ";


                    Debug.WriteLine(s);
                    new object();
                }
                new object();
                //miGrid.Refresh();
                //miGrid.PerformLayout();
            }

            this.Invoke(() =>
            {
                this.Refresh();
            });
        }

        private void Populate()
        {
            //this._chordNamesControl.AddRange(this.ChordFormulaVMs, this);
        }





    }//class
}//ns

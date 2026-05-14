using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;
using Eric.Morrison.Harmony.Rhythm;

using HarmonyHelper.MusicXml.Domain;

using HarmonyHelper_DryWetMidi;

namespace NeckDiagrams.Feature_Views
{
    public partial class MidiFileGenerator : UserControl
    {
        public MidiFileGenerator()
        {
            InitializeComponent();
        }

        private void MidiFileGenerator_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void ParseChords()
        {
            var strChords = this._tbChords.Text;
            var chords = ChordFormulaParser.Parse(strChords);
            this.PopulateChordNamesControl(chords);
        }

        void PopulateChordNamesControl(List<ChordFormula> chords)
        {
            var chordVMs = new List<ChordFormulaVM>();
            chords.ForEach(x => chordVMs.Add(new ChordFormulaVM(x)));
            this._chordNamesControl.Clear();
            this._chordNamesControl.AddRange(chordVMs);
        }

        private void _bnSave_Click(object sender, EventArgs e)
        {
            var strChords = this._tbChords.Text;

            var model = this.CreateModel(strChords);
            var midi = new MidiFileConverter();

            var filename = @"c:\temp\_temp.mid";
            midi.Create(model, filename);

            //Open File Explorer, for convenience.
            Process.Start("explorer.exe", $"/select,\"{filename}\"");

            new object();
        }

        public MusicXmlModel CreateModel(string chords)
        {
            List<string> sections = chords.Split(new char[] { ' ' }).ToList();
            return this.CreateModel(sections);
        }

        public MusicXmlModel CreateModel(List<string> sections)
        {
            var rhythm = new RhythmicContext(new TimeSignature(4, 4));
            var model = MusicXmlModelFactory.Create(sections,
                DurationEnum.Duration_Quarter, rhythm);
            return model;
        }

        private void _tbChords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter
                || e.KeyChar == (char)Keys.Tab)
            {
                this.ParseChords();
            }
        }
    }//class
}//ns

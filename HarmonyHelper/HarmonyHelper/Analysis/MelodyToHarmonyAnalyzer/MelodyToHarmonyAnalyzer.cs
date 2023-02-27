using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.Analysis
{
    public class MelodyToHarmonyAnalyzer
    {
        public KeySignature KeySignature { get; private set; }
        public List<ChordFormula> xFormulaCatalog { get; private set; }

        public List<List<ChordFormula>> Analyze(List<List<NoteName>> bars)
        {
            this.Init(bars);
            var result = new List<List<ChordFormula>>();
            foreach (var bar in bars)
            { 
                var list = Analyze(bar);
                result.Add(list);
            }
            return result;
        }

        void Init(List<List<NoteName>> notes)
        {
            this.KeySignature = this.DetermineKey(notes);
        }

        KeySignature DetermineKey(List<List<NoteName>> bars)
        {
            var notes = (from bar in bars
                         from nn in bar
                         select nn).ToList();


            if (KeySignature.TryDetermineKey(notes, out var matched, out var probable))
            {
                this.KeySignature = matched;
            }
            else 
            {
                this.KeySignature = probable;
            }
            return this.KeySignature;
        }

        List<ChordFormula> Analyze(List<NoteName> notes)
        {
            var result = new List<ChordFormula>();
            foreach (var formula in ChordFormula.Catalog)
            {
                var successCount = 0;
                foreach (var note in notes)
                {
                    if (formula.Contains(note))
                    {// This consideration is going to need to be fuzzy, based on the importance of the note.
                        ++successCount;
                    }
                }
                if (notes.Count == successCount)
                {
                    result.Add(formula);
                }
            }
            return result;
        }

    }
}

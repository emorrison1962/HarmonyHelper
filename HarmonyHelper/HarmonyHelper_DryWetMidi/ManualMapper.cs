using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDI = Melanchall.DryWetMidi.Interaction;
using MDT = Melanchall.DryWetMidi.MusicTheory;
using HHC = Eric.Morrison.Harmony.Chords;
using HH = Eric.Morrison.Harmony;
using Melanchall.DryWetMidi.Common;
using Eric.Morrison.Harmony;
using static Eric.Morrison.Harmony.NoteName;
using System.Diagnostics;

namespace HarmonyHelper_DryWetMidi
{
    static public partial class MappingExtensions
    {
        public static MDI.Chord ToDWMChord(this HHC.ChordFormula src)
        {
            var result = new MDI.Chord();
            var dstNotes = src.NoteNames.ToDWMNotes();
            result.Notes.Add(dstNotes);
            return result;
        }

        static public List<MDI.Note> ToDWMNotes(this List<HH.NoteName> src)
        {
            var result = new List<MDI.Note>();
            foreach (var nn in src)
            {
                result.Add(nn.ToDWMNote());
            }
            return result;
        }

        static public MDI.Note ToDWMNote(this HH.NoteName src, int octave = 4)
        {
            MDT.NoteName dstNn;
            switch ((RawNoteValuesEnum)src.RawValue)
            {
                case RawNoteValuesEnum.C:
                    dstNn = MDT.NoteName.C; break;
                case RawNoteValuesEnum.Db:
                    dstNn = MDT.NoteName.CSharp; break;
                case RawNoteValuesEnum.D:
                    dstNn = MDT.NoteName.D; break;
                case RawNoteValuesEnum.Eb:
                    dstNn = MDT.NoteName.DSharp; break;
                case RawNoteValuesEnum.E:
                    dstNn = MDT.NoteName.E; break;
                case RawNoteValuesEnum.F:
                    dstNn = MDT.NoteName.F; break;
                case RawNoteValuesEnum.Gb:
                    dstNn = MDT.NoteName.FSharp; break;
                case RawNoteValuesEnum.G:
                    dstNn = MDT.NoteName.G; break;
                case RawNoteValuesEnum.Ab:
                    dstNn = MDT.NoteName.GSharp; break;
                case RawNoteValuesEnum.A:
                    dstNn = MDT.NoteName.A; break;
                case RawNoteValuesEnum.Bb:
                    dstNn = MDT.NoteName.ASharp; break;
                case RawNoteValuesEnum.B:
                    dstNn = MDT.NoteName.B; break;
                default: { throw new ArgumentOutOfRangeException(); }
            };

            var result = new MDI.Note(dstNn, octave);
            return result;
        }

        static public MDI.Note ToDWMNote(this HH.Note src)
        {
            var result = ToDWMNote(src.NoteName, (int)src.Octave);
            return result;
        }

    }//class
}//ns

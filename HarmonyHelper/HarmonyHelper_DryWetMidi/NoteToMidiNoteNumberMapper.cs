using System;
using System.Collections.Generic;
using System.Text;

using Eric.Morrison.Harmony;

using Melanchall.DryWetMidi.Common;

using static Eric.Morrison.Harmony.NoteName;

namespace HarmonyHelper_DryWetMidi
{
    internal static class NoteToMidiNoteNumberMapper
    {
        static public SevenBitNumber ToMidiNoteNumber(this Note note)
        {
            var nnId = 0;
            switch (note.NoteName.ExplicitValue)
            {
                case ExplicitNoteValuesEnum.BSharp:
                case ExplicitNoteValuesEnum.C:
                case ExplicitNoteValuesEnum.Dbb:
                    { nnId = 0; break; }

                case ExplicitNoteValuesEnum.BSharpSharp:
                case ExplicitNoteValuesEnum.CSharp:
                case ExplicitNoteValuesEnum.Db:
                    { nnId = 1; break; }

                case ExplicitNoteValuesEnum.CSharpSharp:
                case ExplicitNoteValuesEnum.D:
                case ExplicitNoteValuesEnum.Ebb:
                    { nnId = 2; break; }

                case ExplicitNoteValuesEnum.DSharp:
                case ExplicitNoteValuesEnum.Eb:
                case ExplicitNoteValuesEnum.Fbb:
                    { nnId = 3; break; }

                case ExplicitNoteValuesEnum.DSharpSharp:
                case ExplicitNoteValuesEnum.E:
                case ExplicitNoteValuesEnum.Fb:
                    { nnId = 4; break; }

                case ExplicitNoteValuesEnum.ESharp:
                case ExplicitNoteValuesEnum.F:
                case ExplicitNoteValuesEnum.Gbb:
                    { nnId = 5; break; }

                case ExplicitNoteValuesEnum.ESharpSharp:
                case ExplicitNoteValuesEnum.FSharp:
                case ExplicitNoteValuesEnum.Gb:
                    { nnId = 6; break; }

                case ExplicitNoteValuesEnum.FSharpSharp:
                case ExplicitNoteValuesEnum.G:
                case ExplicitNoteValuesEnum.Abb:
                    { nnId = 7; break; }

                case ExplicitNoteValuesEnum.GSharp:
                case ExplicitNoteValuesEnum.Ab:
                    { nnId = 8; break; }

                case ExplicitNoteValuesEnum.GSharpSharp:
                case ExplicitNoteValuesEnum.A:
                case ExplicitNoteValuesEnum.Bbb:
                    { nnId = 9; break; }

                case ExplicitNoteValuesEnum.ASharp:
                case ExplicitNoteValuesEnum.Bb:
                case ExplicitNoteValuesEnum.Cbb:
                    { nnId = 10; break; }

                case ExplicitNoteValuesEnum.ASharpSharp:
                case ExplicitNoteValuesEnum.B:
                case ExplicitNoteValuesEnum.Cb:
                    { nnId = 11; break; }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            var factor = 0;
            switch (note.Octave)
            {
                case OctaveEnum.Octave0: { factor = 0; break; }
                case OctaveEnum.Octave1: { factor = 1; break; }
                case OctaveEnum.Octave2: { factor = 2; break; }
                case OctaveEnum.Octave3: { factor = 3; break; }
                case OctaveEnum.Octave4: { factor = 4; break; }
                case OctaveEnum.Octave5: { factor = 5; break; }
                case OctaveEnum.Octave6: { factor = 6; break; }
            }

            var result = (12 * factor) + nnId;
            return (SevenBitNumber)result;
        }
    }//class
}//ns

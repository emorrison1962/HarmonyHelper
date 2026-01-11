using System;
using System.Collections.Generic;
using System.Text;

using Eric.Morrison.Harmony;

namespace NeckDiagrams.Domain
{
    internal class GuitarTuningModel
    {

        void Init()
        {
            var string1 = new NoteRange(
                new Note(NoteName.E, OctaveEnum.Octave3),
                new Note(NoteName.E, OctaveEnum.Octave4));

            var string2 = new NoteRange(
                new Note(NoteName.B, OctaveEnum.Octave3),
                new Note(NoteName.B, OctaveEnum.Octave4));

            var string3 = new NoteRange(
                new Note(NoteName.G, OctaveEnum.Octave2),
                new Note(NoteName.G, OctaveEnum.Octave3));

            var string4 = new NoteRange(
                new Note(NoteName.D, OctaveEnum.Octave2),
                new Note(NoteName.D, OctaveEnum.Octave3));

            var string5 = new NoteRange(
                new Note(NoteName.A, OctaveEnum.Octave1),
                new Note(NoteName.A, OctaveEnum.Octave2));

            var string6 = new NoteRange(
                new Note(NoteName.E, OctaveEnum.Octave1),
                new Note(NoteName.E, OctaveEnum.Octave2));
        }
    }
}

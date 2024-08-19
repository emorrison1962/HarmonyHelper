using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;

namespace HarmonyHelper.Chords.NegativeHarmony
{
    /// <summary>
    /// C Ionian transforms into G Phrygian.
    /// C Dorian trasforms into G Dorian.
    /// C Phrygian trasforms into G Ionian.
    /// C Lydian transforms into G Locrian.
    /// C Mixolydian trasforms into G Aelian.
    /// C Aeolian trasforms into G Mixolydian.
    /// C Locrian transforms into G Lydian.
    /// https://rcalsaverini.github.io/blog/modes-transform-negative-harmony/
    /// </summary>
    public class NegativeHarmonyMirror
    {

        public NoteName GetMirror(KeySignature ks, NoteName nn)
        {
            var cof = new CircleOfFifths(ks.NoteName);
            var interval = ks.NoteName - nn;
            var ndx = cof.Notes.IndexOf(nn);

            var mirrorNdx = 1; //[0] = [1]
            if (ndx == 1)
                mirrorNdx = 0; //[1] = [0]
            else if (ndx > 1)
                mirrorNdx = (cof.Notes.Count + 1) - (ndx);

            mirrorNdx %= (cof.Notes.Count + 1);

            var result = cof.Notes[mirrorNdx];
            //Debug.WriteLine($"{nn.NameAscii}: {result.NameAscii}, {ndx}: {mirrorNdx}");
            //new object();

            return result;
        }

    }//class

    /// <summary>
    /// Clockwise:
    /// C, G, D, A, E, B, Gb/F#, Db, Ab, Eb, Bb, F
    /// </summary>
    public class CircleOfFifths
    {
        public List<NoteName> Notes { get; set; } = new List<NoteName>();
        public CircleOfFifths(NoteName nn)
        {
            Notes.Add(nn);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);
            Notes.Add(nn += Interval.Perfect5th);

        }
    }
}//ns

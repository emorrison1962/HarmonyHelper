using System;
using System.Collections.Generic;
using System.Text;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony
{
    /// <summary>
    /// Clockwise:
    /// C, G, D, A, E, B, Gb/F#, Db, Ab, Eb, Bb, F
    /// </summary>
    public class CircleOf 
    {
        Interval Interval { get; set; }

        public List<NoteName> Notes { get; set; } = new List<NoteName>();
        public List<KeySignature> Keys { get; set; } = new List<KeySignature>();
        public CircleOf(Interval interval, NoteName nn, bool isMajor)
        {
            ArgumentNullException.ThrowIfNull(interval);
            this.Interval = interval;
            Notes.Add(nn);
            #region Notes
            for (int i = 1; i < 12; ++i)
            {
                try
                {
#warning FIXME: This is a hack to get the correct enharmonic equivalent.  The problem is that the NoteName.ResolveNoteName() method doesn't know how to resolve a note name when the interval is a perfect fourth, and the note name is a natural.  For example, when nn is C, and the interval is a perfect fourth, the method will try to resolve C - perfect fourth, which is F, but it will also try to resolve C + perfect fourth, which is G.  The method will return F, because it's the first one it finds, but it should return G, because it's the correct enharmonic equivalent.  This hack is to force the method to resolve C + perfect fourth, which will return G. 
                    var before = nn;
                    var after = before - this.Interval;
                    var resolved = NoteName.ResolveNoteName(nn, interval, after.RawValue, false);
                    nn = after;
                }
                catch (Exception)
                {
                    throw;
                }                
                if (!nn.IsNatural)
                {
                    var enharmonic = NoteName.GetEnharmonicEquivalents(nn)
                        .OrderBy(ee => ee.AccidentalCount)
                        .First();
                    Notes.Add(enharmonic);
                }
                else
                    Notes.Add(nn);
            }

            #endregion

            #region Keys
            foreach (var note in Notes)
            {
                var key = KeySignature.Catalog.First(x => x.NoteName.NameAscii == note.NameAscii
                    && x.IsMajor == isMajor);
                Keys.Add(key);
            }
        }
        #endregion

    }//class

}

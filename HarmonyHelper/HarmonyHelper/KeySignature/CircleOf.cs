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
                nn -= this.Interval;
                //nn += this.Interval;
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
                var key = KeySignature.Catalog.First(x => x.NoteName == note 
                    && x.IsMajor == isMajor);
                Keys.Add(key);
            }
        }
        #endregion

    }//class

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public abstract class ScaleBase
    {
        public KeySignature Key { get; protected set; }
        public List<NoteName> Notes { get; protected set; } = new List<NoteName>();
        NoteName CurrentNote { get; set; }
        int MaxIndex
        {
            get
            {
                return this.Notes.Count - 1;
            }
        }

        public NoteName Next(DirectionEnum direction = DirectionEnum.Ascending)
        {
            NoteName result = null;
            var currentNdx = this.Notes.IndexOf(this.CurrentNote);

            if (DirectionEnum.Ascending == direction)
            {
                var nextNdx = 0;
                if (currentNdx < this.MaxIndex)
                {
                    nextNdx = currentNdx + 1;
                }
                result = this.Notes[nextNdx];
            }
            else
            {
                var nextNdx = this.MaxIndex;
                if (currentNdx > 0)
                {
                    nextNdx = currentNdx - 1;
                }
                result = this.Notes[nextNdx];
            }

            return result;
        }

        protected ScaleBase(KeySignature key)
        {
            this.Key = key;
        }
        protected ScaleBase(KeySignature key, IEnumerable<NoteName> notes)
        {
            this.Key = key;
            this.Notes = new List<NoteName>(notes);
        }
    }

    public class Scale : ScaleBase
    {
        public Scale(KeySignature key, IEnumerable<NoteName> notes) : base (key, notes)
        {
        }
    }

    public class HarmonicMinor : ScaleBase
    {
        public HarmonicMinor(KeySignature key, IEnumerable<NoteName> notes) : base(key, notes)
        {
        }
    }

    public class MelodicMinor : ScaleBase
    {
        public MelodicMinor(KeySignature key, IEnumerable<NoteName> notes) : base(key, notes)
        {
        }
    }

    public class Pentatonic : ScaleBase
    {
        public Pentatonic(KeySignature key, IEnumerable<NoteName> notes) : base(key, notes)
        {
        }
    }

    public class WholeTone : ScaleBase
    {
        public WholeTone(KeySignature key, IEnumerable<NoteName> notes) : base(key, notes)
        {
        }
    }

    public class Diminished : ScaleBase
    {
        public Diminished(KeySignature key, IEnumerable<NoteName> notes) : base(key, notes)
        {
        }
    }

    public class Chromatic : ScaleBase
    {
        public Chromatic(KeySignature key, IEnumerable<NoteName> notes) : base(key, notes)
        {
        }
    }


#if false
    References:
http://www2.siba.fi/muste1/index.php?id=71&la=en
#endif 

}//ns

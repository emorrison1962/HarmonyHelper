using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public abstract class ScaleBase : HarmonyEntityBase
    {
        public List<Note> Notes { get; protected set; } = new List<Note>();
        Note CurrentNote { get; set; }
        int MaxIndex
        {
            get
            {
                return this.Notes.Count - 1;
            }
        }

        public Note Next(DirectionEnum direction = DirectionEnum.Ascending)
        {
            Note result = null;
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

        protected ScaleBase(KeySignature key) : base(key)
        {
            this.Key = key;
        }
        protected ScaleBase(KeySignature key, IEnumerable<Note> notes) : this(key)
        {
            this.Key = key;
            this.Notes = new List<Note>(notes);
        }

        protected ScaleBase(KeySignature key, IEnumerable<IntervalsEnum> intervals, NoteRange noteRange) : this(key)
        {
            if (null == key)
                throw new ArgumentNullException();
            if (null == intervals)
                throw new ArgumentNullException();
            if (null == noteRange)
                throw new ArgumentNullException();

            this.Key = key;
        }

    }

    public class Scale : ScaleBase
    {
        public Scale(KeySignature key, IEnumerable<Note> notes) : base (key)
        {
        }
    }

    public class HarmonicMinor : ScaleBase
    {
        public HarmonicMinor(KeySignature key, IEnumerable<Note> notes) : base(key)
        {
        }
    }

    public class MelodicMinor : ScaleBase
    {
        public MelodicMinor(KeySignature key, IEnumerable<NoteName> notes, NoteRange noteRange) : base(key)
        {
        }
    }

    public class Pentatonic : ScaleBase
    {
        public Pentatonic(KeySignature key, IEnumerable<NoteName> notes, NoteRange noteRange) : base(key)
        {
        }
    }

    public class WholeTone : ScaleBase
    {
        public WholeTone(KeySignature key, IEnumerable<NoteName> notes, NoteRange noteRange) : base(key)
        {
        }
    }

    public class Diminished : ScaleBase
    {
        public Diminished(KeySignature key, IEnumerable<NoteName> notes, NoteRange noteRange) : base(key)
        {
        }
    }

    public class Chromatic : ScaleBase
    {
        public Chromatic(KeySignature key, IEnumerable<NoteName> notes, NoteRange noteRange) : base(key)
        {
        }
    }


#if false
    References:
http://www2.siba.fi/muste1/index.php?id=71&la=en
#endif 

}//ns

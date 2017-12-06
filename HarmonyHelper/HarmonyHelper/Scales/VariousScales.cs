using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
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

}

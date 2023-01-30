using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class ParsingContext
    {
        #region Properties
        public MusicXmlScoreMetadata Metadata { get; set; }
        public MusicXmlMeasure CurrentMeasure { get; set; }
        RhythmicContext _Rhythm { get; set; } = new RhythmicContext();
        public RhythmicContext Rhythm
        {
            get 
            { 
                return this._Rhythm; 
            }
            set
            {
                this._Rhythm = value;
            }
        }


        int _CurrentOffset = 0;
#warning FIXME: Refactor this to a backing store prop after setters are working properly.
        public int CurrentOffset
        {
            get
            {
                return _CurrentOffset;
            }
            set
            {
                _CurrentOffset = value;
                //Debug.Assert(_CurrentOffset <= 481);
                //Debug.Assert(_CurrentOffset >= 0);
                //Debug.WriteLine($"set_CurrentOffset: {this._CurrentMeasure}: {this._CurrentOffset}");
            }
        }
        public List<MusicXmlPart> Parts { get; set; } = new List<MusicXmlPart>();

        //public ConcurrentDictionary<TiedNoteContext, TiedNoteContext> TiedNotes { get; set; } = new ConcurrentDictionary<TiedNoteContext, TiedNoteContext>();

        public ChordTimeContext ChordTimeContext { get; set; } = new ChordTimeContext();

        #endregion
    }//class

}//cs

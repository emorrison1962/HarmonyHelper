using Eric.Morrison.Harmony.Rhythm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class RhythmicContext
    {
        #region Properties
        public TimeSignature TimeSignature { get; private set; }
        //public int PulsesPerMeasure { get; protected set; }
        public int PulsesPerQuarterNote { get; private set; }
        public int PulsesPerMeasure { get; private set; }
        public int Tempo { get; private set; }

        //{
        //    get
        //    {
        //        return this.TimeSignature.BeatCount * this.PulsesPerQuarterNote;
        //    }
        //}

        #endregion

        #region Construction
        public RhythmicContext()
        {

        }

        public RhythmicContext(TimeSignature ts, int ppm)
        {
            this.TimeSignature = ts;
            this.PulsesPerMeasure = ppm;
        }

        public RhythmicContext(TimeSignature ts)
            : this(ts, 100)
        {
        }

        #endregion

        #region Fluency
        public RhythmicContext SetTimeSignature(TimeSignature ts)
        {
            this.TimeSignature = ts;
            return this;
        }

        public RhythmicContext SetPulsesPerMeasure(int ppm)
        {
            this.PulsesPerMeasure = ppm;
#warning FIXME: We're assuming this.TimeSignature.BeatUnit is Quarter note.
            this.PulsesPerQuarterNote = this.PulsesPerMeasure / this.TimeSignature.BeatCount;
            return this;
        }

        public RhythmicContext SetPulsesPerQuarterNote(int ppqn)
        {
            this.PulsesPerQuarterNote = ppqn;
#warning FIXME: We're assuming this.TimeSignature.BeatUnit is Quarter note.
            this.PulsesPerMeasure = this.TimeSignature.BeatCount * this.PulsesPerQuarterNote;
            return this;
        }

        public RhythmicContext SetTempo(int tempo)
        {
            this.Tempo = tempo;
            return this;
        }

        #endregion

    }//class

}//ns

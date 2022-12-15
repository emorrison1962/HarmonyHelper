using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;

namespace Eric.Morrison.Harmony.Analysis.ReHarmonizer
{
    public class ReHarmonizer
    {
        ReHarmonizerContext Context { get; set; }
        public void ReHarmonize(MusicXmlParsingResult input) 
        {
            this.Context = new ReHarmonizerContext(input);
            var chords = this.Context.GetChords();
            new object();
        }
    }//class

    public class ReHarmonizerContext
    {
        MusicXmlParsingResult MusicXmlParsingResult { get; set; }
        public ReHarmonizerContext(MusicXmlParsingResult input)
        {
            this.MusicXmlParsingResult = input;
        }

        public List<TimedEvent<ChordFormula>> GetChords() 
        {
            var result = (from p in this.MusicXmlParsingResult.Parts
                       from m in p.Measures
                       from c in m.Chords
                       select c).ToList();
            return result;
        }
    }//
}//ns



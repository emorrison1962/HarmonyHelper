using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeckDiagrams
{
    public enum FeatureType
    {
        None,
        ModalInterchange,
        [Obsolete("", true)]
        Score,
        Manufaktura,
        VoiceLeading,
        Scales,
        ReHarmonize,
        LeadSheets,
        HarmonicAnalysis,
        Arpeggiator,
        Arpeggios,
        ChordFingering,
        SquareOfStitch
    }
}

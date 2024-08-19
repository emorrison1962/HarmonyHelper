using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;

namespace HarmonyHelper.Melody
{
    enum MelodicAlterationEnum
    {// https://musictheory.pugetsound.edu/mt21c/MelodicAlteration.html
        Inversion,
        IntervallicChange,
        Augmentation, //Augmentation usually refers to an exact doubling of the duration of every rhythmic value in a motive or phrase.
        Diminution,   //Diminution is the opposite of augmentation and usually refers to the exact halving of the duration of every rhythmic value in a motive or phrase. 
        RhythmicChange,
        Ornamentation,
        Extension,
        Retrograde,

    };

    public class IntervalContext
    {
        public NoteName NoteNameFirst { get; set; }
        public NoteName NoteNameSecond { get; set; }
        public Interval Interval { get; set; }
        public IntervalContext(NoteName nnFirst, NoteName nnSecond)
        {
            this.NoteNameFirst = nnFirst;
            this.NoteNameSecond = nnSecond;
            var tmpInterval = nnFirst - nnSecond;
            this.Interval = Interval.Min(tmpInterval, tmpInterval.GetInversion());
        }

        public override string ToString()
        {
            return $"{base.ToString()}: NoteNameFirst={NoteNameFirst}, NoteNameSecond={NoteNameSecond}, Interval={Interval}";
        }
    }//class

    public enum MelodicMotionEnum
    {
        None = 0,
                               //Approached by   Left by
        PassingTone,           //step            step in same direction
        NeighborTone,          //step            step in opposite direction
        Appoggiatura,          //leap            step
        EscapeTone,            //step            leap in opposite direction
        DoubleNeighbor,        //see text        see text
        Anticipation,          //step            same note
        PedalPoint,            //same note       same note
        Suspension,            //same note       step down
        Retardation,           //same note       step up
    };
    public class MelodicMotion
    {
#if false
Non-Chord Tone          Approached by   Left by
Passing Tone            step            step in same direction
Neighbor Tone           step            step in opposite direction
Appoggiatura            leap            step
Escape Tone             step            leap in opposite direction
Double Neighbor         see text        see text
Anticipation            step            same note
Pedal Point             same note       same note
Suspension              same note       step down
Retardation             same note       step up

#endif    

        public MelodicMotionEnum MelodicMotionType { get; set; }
        public static MelodicMotion GetRandom()
        { 
            var result = new MelodicMotion();
            var motionType = (MelodicMotionEnum)new Random()
                .Next((int)MelodicMotionEnum.PassingTone,
                    (int)MelodicMotionEnum.Retardation);
            result.MelodicMotionType = motionType;
            return result;
        }
    }//class

    public class PassingTone : MelodicMotion
    {
    }//class

    public class Motiv
    {
        List<Fragment> Fragments { get; set; }
    }//class

    /// <summary>
    /// While the motive is usually defined as the smallest identifiable melodic idea in a composition, “compound” motives can be broken into fragments (sometimes called “germs”).
    /// Note: Fragments may overlap.
    /// </summary>
    public class Fragment
    {
    }
}//ns

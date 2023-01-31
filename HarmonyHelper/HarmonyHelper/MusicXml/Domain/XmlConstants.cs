#region MusicXml reference
#if false

https://www.w3.org/2021/06/musicxml40/musicxml-reference/elements/

#endif
#endregion


using Eric.Morrison.Harmony.Chords;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Xml.Linq;
using System;

namespace Eric.Morrison.Harmony.MusicXml
{
    static public class XmlConstants
    {
        public const string actual_notes = "actual-notes";
        public const string accidental = "accidental";
        public const string attributes = "attributes";
        public const string alter = "alter";
        public const string attack = "attack";
        public const string backup = "backup";
        
        public const string barline = "barline";
        public const string barline_location = "location";
        public const string barline_location_left = "left";
        public const string barline_location_right = "right";
        public const string bar_style = "bar-style";

        public const string bar_style_dashed = "dashed";
        public const string bar_style_dotted = "dotted";
        public const string bar_style_heavy = "heavy";
        public const string bar_style_heavy_heavy = "heavy-heavy";
        public const string bar_style_heavy_light = "heavy-light";
        public const string bar_style_light_heavy = "light-heavy";
        public const string bar_style_light_light = "light-light";
        public const string bar_style_regular = "regular";
        public const string bar_style_short = "short";
        public const string bar_style_tick = "tick";

        public const string repeat = "repeat";
        public const string repeat_backward = "backward";
        public const string repeat_forward = "forward";
        public const string repeat_after_jump = "after-jump";
        public const string repeat_times = "times";


        public const string beam = "beam";
        public const string beat_type = "beat-type";
        public const string beats = "beats";
        public const string chord = "chord";
        public const string chord_start = "chord_start";
        public const string clef = "clef";
        public const string coda = "coda";
        public const string creator = "creator";
        public const string degree = "degree";
        public const string degree_value = "degree-value";
        public const string degree_alter = "degree-alter";
        public const string degree_type = "degree-type";
        public const string divisions = "divisions";
        public const string dot = "dot";
        public const string duration = "duration";

        public const string ending = "ending";
        public const string ending_number = "number";
        
        public const string fifths = "fifths";
        public const string forward = "forward";
        public const string harmony = "harmony";
        public const string id = "id";
        public const string identification = "identification";
        public const string key = "key";
        public const string kind = "kind";
        public const string line = "line";
        public const string measure = "measure";
        public const string movement_title = "movement-title";
        public const string movement_number = "movement-number";
        public const string normal_notes = "normal-notes";
        public const string normal_type = "normal-type";
        public const string notations = "notations";
        public const string note = "note";
        public const string number = "number";
        public const string octave = "octave";
        public const string offset = "offset";
        public const string part = "part";
        public const string part_list = "part-list";
        public const string part_name = "part-name";
        public const string pitch = "pitch";
        public const string release = "release";
        public const string rest = "rest";
        public const string root = "root";
        public const string root_alter = "root-alter";
        public const string root_step = "root-step";
        public const string score_part = "score-part";
        public const string score_timewise = "score-timewise";
        public const string score_partwise = "score-partwise";
        public const string segno = "segno";
        public const string sign = "sign";
        public const string sound = "sound";
        public const string staff = "staff";
        public const string start = "start";
        public const string staves = "staves";
        public const string step = "step";
        public const string stop = "stop";
        public const string tempo = "tempo";
        public const string text = "text";
        const string tie = "tie";
        public const string tied = "tied";
        public const string time = "time";
        public const string time_modification = "time-modification";
        public const string type = "type";
        public const string unpitched = "unpitched";
        public const string voice = "voice";
        public const string work = "work";
        public const string work_title = "work-title";
        public const string work_number = "work-number";

    }//class

    static public class MusicXml_HarmonyKind_Constants
    {
        public const string augmented = "augmented"; //Triad: major third, augmented fifth.
        public const string augmented_seventh = "augmented-seventh"; //Seventh: augmented triad, minor seventh.
        public const string diminished = "diminished"; //Triad: minor third, diminished fifth.
        public const string diminished_seventh = "diminished-seventh"; //Seventh: diminished triad, diminished seventh.
        public const string dominant = "dominant"; //Seventh: major triad, minor seventh.
        public const string dominant_11th = "dominant-11th";    //11th: dominant-ninth, perfect 11th.
        public const string dominant_13th = "dominant-13th";    //13th: dominant-11th, major 13th.
        public const string dominant_ninth = "dominant-ninth"; //Ninth: dominant, major ninth.
        public const string French = "French";  //Functional French sixth.
        public const string German = "German"; //Functional German sixth.
        public const string half_diminished = "half-diminished"; //Seventh: diminished triad, minor seventh.
        public const string Italian = "Italian"; //Functional Italian sixth.
        public const string major = "major"; //Triad: major third, perfect fifth.
        public const string major_11th = "major-11th";  //11th: major-ninth, perfect 11th.
        public const string major_13th = "major-13th";  //13th: major-11th, major 13th.
        public const string major_minor = "major-minor"; //Seventh: minor triad, major seventh.
        public const string major_ninth = "major-ninth"; //Ninth: major-seventh, major ninth.
        public const string major_seventh = "major-seventh"; //Seventh: major triad, major seventh.
        public const string major_sixth = "major-sixth"; //Sixth: major triad, added sixth.
        public const string minor = "minor"; //Triad: minor third, perfect fifth.
        public const string minor_11th = "minor-11th";  //11th: minor-ninth, perfect 11th.
        public const string minor_13th = "minor-13th";  //13th: minor-11th, major 13th.
        public const string minor_ninth = "minor-ninth"; //Ninth: minor-seventh, major ninth.
        public const string minor_seventh = "minor-seventh"; //Seventh: minor triad, minor seventh.
        public const string minor_sixth = "minor-sixth"; //Sixth: minor triad, added sixth.
        public const string Neapolitan = "Neapolitan"; //Functional Neapolitan sixth.
        public const string none = "none"; //Used to explicitly encode the absence of chords or functional harmony. In this case, the<root> <numeral>, or<function> element has no meaning.When using the <root> or<numeral> element, the <root-step> or<numeral-step> text attribute should be set to the empty string to keep the root or numeral from being displayed.
        public const string other = "other";   //Used when the harmony is entirely composed of add elements.
        public const string pedal = "pedal"; //Pedal-point bass
        public const string power = "power"; //Perfect fifth.
        public const string suspended_fourth = "suspended-fourth"; //Suspended: perfect fourth, perfect fifth.
        public const string suspended_second = "suspended-second"; //Suspended: major second, perfect fifth.
        public const string Tristan = "Tristan"; //Augmented fourth, augmented sixth, augmented ninth.

    }
}//ns

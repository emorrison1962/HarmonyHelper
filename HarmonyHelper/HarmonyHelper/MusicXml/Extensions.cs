using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class ChordAlteration
    {
        public const string ADD = "add";//add	If the degree element is in addition to the kind of the current chord.
        public const string ALTER = "alter";//alter	If the degree element is an alteration to the kind of the current chord.
        public const string REMOVE = "subtract";//subtract	If the degree element is a subtraction from the kind of the current chord.
        public int Degree { get; set; }
        public int Alteration { get; set; }
        public string Type { get; set; }

        public ChordAlteration(string type, int degree, int alteration=0 )
        {
            this.Degree = degree;
            this.Alteration = alteration;
            this.Type = type;
            if (this.Type != ADD
                && this.Type != ALTER
                && this.Type != REMOVE)
                throw new ArgumentOutOfRangeException("type");
        }

        public XElement ToXElement()
        {
#if false
<degree-value>5</degree-value>
<degree-alter>-1</degree-alter>
<degree-type>alter</degree-type>
#endif

            var result = new XElement(XmlConstants.degree);
            result.Add(new XElement(XmlConstants.degree_value, this.Degree));
            result.Add(new XElement(XmlConstants.degree_alter, this.Alteration));
            result.Add(new XElement(XmlConstants.degree_type, this.Type));
            return result;
        }
    }
    public static class Extensions
    {
        static public List<XElement> ToXElements(this ChordIntervalsEnum ct)
        {
            var result = new List<XElement>();

#if false
<degree>
<degree-value>5</degree-value>
<degree-alter>-1</degree-alter>
<degree-type>alter</degree-type>

</degree>
#endif
            switch (ct.Name())
            {
                case "aug":
                    {
                        var kind = new XElement(XmlConstants.kind, 
                            MusicXml_HarmonyKind_Constants.augmented);
                        result.Add(kind);
                        break;
                    }
                case "dim":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.diminished);
                        result.Add(kind);
                        break;

                    }
                case "m7b5":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.half_diminished);
                        result.Add(kind);
                        break;

                    }
                case "dim7":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.diminished_seventh);
                        result.Add(kind);
                        break;

                    }
                case "Sus2":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.suspended_second);
                        result.Add(kind);
                        break;

                    }
                case "7Sus2":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ADD, 2)
                            .ToXElement());
                        break;

                    }
                case "Sus4":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.suspended_fourth);
                        result.Add(kind);
                        break;

                    }
                case "7Sus4":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.suspended_fourth);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ADD, 7)
                            .ToXElement());
                        break;

                    }
                case "Sus2Sus4":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.suspended_second);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ADD, 4)
                            .ToXElement());
                        break;

                    }
                case "m":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor);
                        result.Add(kind);
                        break;

                    }
                case "m7":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor_seventh);
                        result.Add(kind);
                        break;

                    }
                case "mM7":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor_seventh);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 7, 1)
                            .ToXElement());
                        break;

                    }
                case "mMaj7aug5":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 7, 1)
                            .ToXElement());
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 5, 1)
                            .ToXElement());
                        break;

                    }
                case "m6":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor_sixth);
                        result.Add(kind);
                        break;

                    }
                case "m9":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor_ninth);
                        result.Add(kind);
                        break;

                    }
                case "m11":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor_11th);
                        result.Add(kind);
                        break;

                    }
                case "m13":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor_13th);
                        result.Add(kind);
                        break;

                    }
                case "mAdd9":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.minor);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ADD, 9)
                            .ToXElement());
                        break;

                    }
                case "Maj":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major);
                        result.Add(kind);
                        break;

                    }
                case "6":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major_sixth);
                        result.Add(kind);
                        break;

                    }
                case "Maj7":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major_seventh);
                        result.Add(kind);
                        break;

                    }
                case "Maj9":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major_ninth);
                        result.Add(kind);
                        break;

                    }
                case "Maj11":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major_11th);
                        result.Add(kind);
                        break;

                    }
                case "Maj13":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major_13th);
                        result.Add(kind);
                        break;

                    }
                case "Add9":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ADD, 9)
                            .ToXElement());
                        break;

                    }
                case "MajMu":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ADD, 2)
                            .ToXElement());

                        break;

                    }
                case "Maj7b5":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major_seventh);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 5, -1)
                            .ToXElement());
                        break;

                    }
                case "Maj7aug5":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.major_seventh);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 5, 1)
                            .ToXElement());
                        break;

                    }
                case "7":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant);
                        result.Add(kind);
                        break;

                    }
                case "9":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant_ninth);
                        result.Add(kind);
                        break;

                    }
                case "11":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant_11th);
                        result.Add(kind);
                        break;

                    }
                case "13":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant_13th);
                        result.Add(kind);
                        break;

                    }
                case "7b5":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 5, -1)
                            .ToXElement());
                        break;

                    }
                case "7b9":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant_ninth);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 9, -1)
                            .ToXElement());
                        break;

                    }
                case "7#9":
                    {
                        var kind = new XElement(XmlConstants.kind,
                            MusicXml_HarmonyKind_Constants.dominant);
                        result.Add(kind);
                        result.Add(new ChordAlteration(ChordAlteration.ALTER, 9, 1)
                            .ToXElement());
                        break;

                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
            return result;
        }

        static public DurationEnum ToDurationEnum(this string name)
        {
            var result = DurationEnum.Unknown;
            switch (name) 
            {
                case DurationStrings.NoteType_1024th:
                    result = DurationEnum.Duration_1024th;
                    break;
                case DurationStrings.NoteType_512th:
                    result = DurationEnum.Duration_512th;
                    break;
                case DurationStrings.NoteType_256th:
                    result = DurationEnum.Duration_256th;
                    break;
                case DurationStrings.NoteType_128th:
                    result = DurationEnum.Duration_128th;
                    break;
                case DurationStrings.NoteType_64th:
                    result = DurationEnum.Duration_64th;
                    break;
                case DurationStrings.NoteType_32nd:
                    result = DurationEnum.Duration_32nd;
                    break;
                case DurationStrings.NoteType_16th:
                    result = DurationEnum.Duration_16th;
                    break;
                case DurationStrings.NoteType_eighth:
                    result = DurationEnum.Duration_Eighth;
                    break;
                case DurationStrings.NoteType_quarter:
                    result = DurationEnum.Duration_Quarter;
                    break;
                case DurationStrings.NoteType_half:
                    result = DurationEnum.Duration_Half;
                    break;
                case DurationStrings.NoteType_whole:
                    result = DurationEnum.Duration_Whole;
                    break;
                case DurationStrings.NoteType_breve:
                    result = DurationEnum.Duration_Breve;
                    break;
                case DurationStrings.NoteType_long:
                    result = DurationEnum.Duration_Long;
                    break;
                case DurationStrings.NoteType_maxima:
                    result = DurationEnum.Duration_Maxima;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
            return result;
        }

    }//class
}//ns

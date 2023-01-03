using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.MusicXml
{
    public static class Extensions
    {
        static public string GetMusicXmlName(this ChordType ct)
        {
            var result = string.Empty;
            switch (ct.Name)
            {
                case "aug":
                    {
                        result = MusicXml_HarmonyKind_Constants.augmented;
                        break;
                    }
                case "dim":
                    {
                        result = MusicXml_HarmonyKind_Constants.diminished;
                        break;
                    }
                case "m7b5":
                    {
                        result = MusicXml_HarmonyKind_Constants.half_diminished;
                        break;
                    }
                case "dim7":
                    {
                        result = MusicXml_HarmonyKind_Constants.diminished_seventh;
                        break;
                    }
                case "Sus2":
                    {
                        result = MusicXml_HarmonyKind_Constants.suspended_second;
                        break;
                    }
                case "7Sus2":
                    {
                        result = MusicXml_HarmonyKind_Constants.suspended_second;
                        break;
                    }
                case "Sus4":
                    {
                        result = MusicXml_HarmonyKind_Constants.suspended_fourth;
                        break;
                    }
                case "7Sus4":
                    {
                        result = MusicXml_HarmonyKind_Constants.suspended_fourth;
                        break;
                    }
                case "Sus2Sus4":
                    {
                        result = MusicXml_HarmonyKind_Constants.suspended_second;
                        break;
                    }
                case "m":
                    {
                        result = MusicXml_HarmonyKind_Constants.minor;
                        break;
                    }
                case "m7":
                    {
                        result = MusicXml_HarmonyKind_Constants.minor_seventh;
                        break;
                    }
                case "mM7":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_minor;
                        break;
                    }
                case "mMaj7aug5":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_minor;
                        break;
                    }
                case "m6":
                    {
                        result = MusicXml_HarmonyKind_Constants.minor_sixth;
                        break;
                    }
                case "m9":
                    {
                        result = MusicXml_HarmonyKind_Constants.minor_ninth;
                        break;
                    }
                case "m11":
                    {
                        result = MusicXml_HarmonyKind_Constants.minor_11th;
                        break;
                    }
                case "m13":
                    {
                        result = MusicXml_HarmonyKind_Constants.minor_13th;
                        break;
                    }
                case "mAdd9":
                    {
                        result = MusicXml_HarmonyKind_Constants.minor_ninth;
                        break;
                    }
                case "Maj":
                    {
                        result = MusicXml_HarmonyKind_Constants.major;
                        break;
                    }
                case "6":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_sixth;
                        break;
                    }
                case "Maj7":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_seventh;
                        break;
                    }
                case "Maj9":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_ninth;
                        break;
                    }
                case "Maj11":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_11th;
                        break;
                    }
                case "Maj13":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_13th;
                        break;
                    }
                case "Add9":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_ninth;
                        break;
                    }
                case "MajMu":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_ninth;
                        break;
                    }
                case "Maj7b5":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_seventh;
                        break;
                    }
                case "Maj7aug5":
                    {
                        result = MusicXml_HarmonyKind_Constants.major_seventh;
                        break;
                    }
                case "7":
                    {
                        result = MusicXml_HarmonyKind_Constants.dominant;
                        break;
                    }
                case "9":
                    {
                        result = MusicXml_HarmonyKind_Constants.dominant_ninth;
                        break;
                    }
                case "11":
                    {
                        result = MusicXml_HarmonyKind_Constants.dominant_11th;
                        break;
                    }
                case "13":
                    {
                        result = MusicXml_HarmonyKind_Constants.dominant_13th;
                        break;
                    }
                case "7b5":
                    {
                        result = MusicXml_HarmonyKind_Constants.diminished_seventh;
                        break;
                    }
                case "7b9":
                    {
                        result = MusicXml_HarmonyKind_Constants.diminished_seventh;
                        break;
                    }
                case "7sharp9":
                    {
                        result = MusicXml_HarmonyKind_Constants.dominant;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
            return result;
        }

        static public string GetMusicXmlName(this NoteLengthDivisorEnum nlde)
        {
            var result = string.Empty;
            switch (nlde)
            {
                case NoteLengthDivisorEnum.Whole:
                    {
                        result = "Whole";
                        break;
                    }
                case NoteLengthDivisorEnum.Half:
                    {
                        result = "Half";
                        break;
                    }
                case NoteLengthDivisorEnum.Quarter:
                    {
                        result = "Quarter";
                        break;
                    }
                case NoteLengthDivisorEnum.Eighth:
                    {
                        result = "Eighth";
                        break;
                    }
                case NoteLengthDivisorEnum.Sixteenth:
                    {
                        result = "16th";
                        break;
                    }
                case 
                    NoteLengthDivisorEnum._32nd:
                    {
                        result = "32nd";
                        break;
                    }
                case 
                    NoteLengthDivisorEnum._64th:
                    {
                        result = "64th";
                        break;
                    }
                case 
                    NoteLengthDivisorEnum._128th:
                    {
                        result = "128th";
                        break;
                    }
                case 
                    NoteLengthDivisorEnum._256th:
                    {
                        result = "256th";
                        break;
                    }
                case 
                    NoteLengthDivisorEnum._512th:
                    {
                        result = "512th";
                        break;
                    }
                case 
                    NoteLengthDivisorEnum._1024th:
                    {
                        result = "1024th";
                        break;
                    }
                case 
                    NoteLengthDivisorEnum.Breve:
                    {
                        result = "Breve";
                        break;
                    }
                default: 
                    { 
                        throw new NotImplementedException();    
                    }
                }
            return result = result.ToLower();
        }
    }//class
}//ns

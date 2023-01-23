using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using Eric.Morrison.Harmony.Notes;
using Eric.Morrison.Harmony.Rhythm;

namespace Eric.Morrison.Harmony.MusicXml
{
    public partial class MusicXmlImporter : MusicXmlBase
    {
        private TimedEvent<Note> ParsePitched(XElement xnote)
        {
            TimedEvent<Note> result = null;

            Note hhNote = null;
            var durationEnum = DurationEnum.None;
            int start = 0;
            int duration = 0;



#if true //Ignore tied notes, for now.
            if (xnote.Elements(XmlConstants.tie).Any())
            {
                var tieType = this.ParseTie(xnote);
                //Debug.WriteLine($"**** tie count = {xnote.Elements(XmlConstants.tie).Count()}");
                if (tieType == TieTypeEnum.Start || tieType == TieTypeEnum.Stop)
                {// There can be a start AND a stop.
                    new object();
                    //var tiedNote = new TiedNoteContext(
                    //        this, xnote, tieType,
                    //        this.ParsingContext.CurrentMeasure, this.ParsingContext.CurrentOffset);
                    //this.ParsingContext.TiedNotes.TryAdd(tiedNote, tiedNote);

                    //tiedNote.TryResolve();
                }
                //short circuit processing for tied notes.
                //return result;
                //if (TieTypeEnum.Stop == note.GetTieType())
                //{
                //    new object();
                //}
                return result;
            }
#endif
            if (xnote.Elements(XmlConstants.pitch).Any())
            {
                hhNote = this.Parse_HarmonyHelper_Note(xnote);
            }

            MusicXmlTimeModification timeModification = null;
            if (!xnote.Elements(XmlConstants.type).Any())
            {
                throw new XmlException($"<{XmlConstants.note}> does not contain required element: <{XmlConstants.type}>");
                new object();
            }
            if (xnote.Elements(XmlConstants.type).Any())
            {
                //duration = this.ParseDuration(xnote);
                duration = ParseDuration(xnote, out durationEnum, out timeModification);

                start = this.ParsingContext.CurrentOffset;
                var end = this.ParsingContext.CurrentOffset + duration;

                if (this.IsFirstNoteOfChord(xnote))
                {
                    this.ParsingContext.ChordTimeContext.Start = start;
                    this.ParsingContext.ChordTimeContext.End = end;
                    this.ParsingContext.ChordTimeContext.FirstNote = result;
                }
                else if (this.IsLastNoteOfChord(xnote))
                {
                    start = this.ParsingContext.ChordTimeContext.Start;
                    end = this.ParsingContext.ChordTimeContext.End;
                    this.ParsingContext.ChordTimeContext.Clear();
                    this.ParsingContext.CurrentOffset += duration;
                    new object();
                }
                else if (this.IsNoteOfChord(xnote))
                {
                    start = this.ParsingContext.ChordTimeContext.Start;
                    end = this.ParsingContext.ChordTimeContext.End;
                }
                else //we're not in a chord.
                {
                    this.ParsingContext.CurrentOffset += duration;
                }
            }

            bool hasChord = false;
            if (xnote.Elements(XmlConstants.chord).Any())
            {
                hasChord = true;
            }


            result = TimedEventFactory.Instance.CreateTimedEvent(hhNote,
                this.ParsingContext.Rhythm,
                this.ParsingContext.CurrentMeasure.MeasureNumber,
                start,
                duration,
                durationEnum,
                timeModification,
                xnote);
            result.Serialization.HasChord = hasChord;

            if (xnote.Attributes(XmlConstants.attack).Any())
                result.Serialization.Attack = xnote.Attribute(XmlConstants.attack).Value;
            if (xnote.Attributes(XmlConstants.release).Any())
                result.Serialization.Release = xnote.Attribute(XmlConstants.release).Value;

            if (xnote.Elements(XmlConstants.voice).Any())
                result.Serialization.Voice = xnote.Element(XmlConstants.voice).Value;
            
            if (xnote.Elements(XmlConstants.staff).Any())
                result.Serialization.Staff = xnote.Element(XmlConstants.staff).Value;

            return result;
        }

        TieTypeEnum ParseTie(XElement note)
        {
#if false
<note attack="18">
  <duration>60</duration>
  <tie type="start" />
</note>
#endif
            var result = TieTypeEnum.Unknown;
            var ties = note.Descendants(XmlConstants.tie).ToList();
            if (ties.Count == 1)
            {
                var attrVal = ties[0].Attribute(XmlConstants.type).Value;
                if (XmlConstants.start == attrVal)
                    result = TieTypeEnum.Start;
                else
                    result = TieTypeEnum.Stop;
            }
            else
            {
                result = TieTypeEnum.StartStop;
            }
            return result;
        }

        public Note Parse_HarmonyHelper_Note(XElement note)
        {
#if false
  <pitch>
    <step>B</step>
    <alter>-1</alter>
    <octave>1</octave>
  </pitch>
#endif
            Note result = null;
            var pitch = note.Elements(XmlConstants.pitch).First();

            var strNoteName = pitch.Elements(XmlConstants.step).First().Value;
            var modifier = pitch.Elements(XmlConstants.alter).FirstOrDefault()?.Value;
            if (modifier != null)
            {
                if (modifier == "-1")
                    strNoteName += "b";
                else
                    strNoteName += "#";
            }
            var octave = (OctaveEnum)Int32.Parse(
                pitch.Elements(XmlConstants.octave)
                .First()
                .Value);

            if (NoteNameParser.TryParse(strNoteName, out var notes, out var msg))
            {
                var nn = notes.First();
                result = new Note(nn, octave);
            }
            else
            {
                throw new ArgumentException(msg);
            }
            return result;
        }

        bool IsFirstNoteOfChord(XElement note)
        {
            var elements = note.ElementsAfterSelf(XmlConstants.note).ToList();
            var result = (note.ElementsAfterSelf()
                .FirstOrDefault()
                ?.Elements(XmlConstants.chord)
                ?.Any()).GetValueOrDefault();
            if (result)
            {
                new object();
            }
            return result;
        }

        bool IsNoteOfChord(XElement note)
        {
            var result = false;
            if (null != note)
            {
                result = note.Elements(XmlConstants.chord).Any();
                if (result)
                {
                    new object();
                }
            }
            return result;
        }

        bool IsLastNoteOfChord(XElement note)
        {
            var beforeElements = note.ElementsBeforeSelf(XmlConstants.note)
                .ToList();
            var afterElements = note.ElementsBeforeSelf(XmlConstants.note)
                .ToList();
            var before = note.ElementsBeforeSelf(XmlConstants.note)
                .FirstOrDefault();
            var after = note.ElementsAfterSelf(XmlConstants.note)
                .FirstOrDefault();

            var result = false;
            if (IsNoteOfChord(note))
            {
                new object();
                if (!IsNoteOfChord(after))
                {
                    result = true;
                }
            }

            if (result)
            {
                new object();
            }

            return result;
        }

    }//class
}//ns

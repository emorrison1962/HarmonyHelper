
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Notes;
using Eric.Morrison.Harmony.Rhythm;

#region MusicXml reference
#if false

https://www.w3.org/2021/06/musicxml40/musicxml-reference/elements/

#endif
#endregion


namespace Eric.Morrison.Harmony.MusicXml
{
    public partial class MusicXmlExportr_Export : MusicXmlBase
    {
        #region Constants

        #endregion

        #region Properties
        XDocument Document { get; set; }
        ParsingContext ParsingContext { get; set; } = new ParsingContext();

        #endregion

        #region Construction
        public MusicXmlExportr_Export()
        {
        }

        #endregion
        
        public bool Export(MusicXmlParsingResult model)
        {
            var xml = this.LoadEmbeddedResource("ExportTemplate_MusicXml.xml");

            this.Document = XDocument.Parse(xml);
            var result = this.ExportImpl(model);
            return result;
        }

        bool ExportImpl(MusicXmlParsingResult model)
        {
            foreach (var part in model.Parts) 
            {
                foreach (var measure in part.Measures)
                {
                    var events = measure.GetMergedEvents();
                    foreach (var @event in events)
                    {
                        var ob = (dynamic)@event;
                        var cft = this.ToXElement(ob);
                    }
                }
            }

            //var metadata = this.ExportScoreMetadata(model);
            //this.ParsingContext.Metadata = metadata;
            var score = this.Document.Elements(XmlConstants.score_partwise).First();

            return false;
        }


        string LoadEmbeddedResource(string partialName)
        {
            var result = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
            var resource = assembly.GetManifestResourceNames()
                .Where(x => x.Contains(partialName)).FirstOrDefault();
            using (var sr = new StreamReader(assembly
                .GetManifestResourceStream(resource)))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }





        public XElement ToPitch(Note note)
        {
#if false
  <pitch>
    <step>B</step>
    <alter>-1</alter>
    <octave>1</octave>
  </pitch>
#endif
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            XElement result = new XElement(XmlConstants.pitch);
            XElement step = new XElement(XmlConstants.step, note.NoteName.Name[0]);
            result.Add(step);

            XElement alter = null;
            if (note.NoteName.IsSharped)
                alter = new XElement(XmlConstants.alter, 1);
            else if (note.NoteName.IsFlatted)
                alter = new XElement(XmlConstants.alter, -1);
            result.Add(alter);

            var octave = new XElement(XmlConstants.octave, (int)note.Octave);
            result.Add(octave);

            return result;
        }

        public XElement ToXElement(TimedEvent<ChordFormula> te)
        {
#if false
      <harmony>
         <root>
         <root-step>C</root-step>
         </root>
         <kind text="m7">minor-seventh</kind>
      <offset>240</offset>
      </harmony>
#endif
            var harmony = new XElement(XmlConstants.harmony);
            var root = ToRoot(te);
            harmony.Add(root);

            var kind = new XElement(XmlConstants.kind, te.Event.ChordType.Name);
            harmony.Add(kind);

            //throw new NotImplementedException("How do I get the offset?");
            var offset = new XElement(XmlConstants.offset);
            harmony.Add(offset);

            return harmony;
        }

        public XElement ToRoot(TimedEvent<ChordFormula> te)
        {
#if false
  <root>
    <root-step>B</root-step>
    <root-alter>-1</root-alter>
  </root>
#endif

            var root = new XElement(XmlConstants.root);

            var root_step = new XElement(XmlConstants.root_step, te.Event.Root.Name[0]);
            root.Add(root_step);

            if (!te.Event.Root.IsNatural)
            {
                if (te.Event.Root.IsSharped)
                {
                    var root_alter = new XElement(XmlConstants.root_alter, 1);
                    root.Add(root_alter);
                }
                else
                {
                    var root_alter = new XElement(XmlConstants.root_alter, -1);
                    root.Add(root_alter);
                }
            }
            return root;
        }

        public XElement ToXElement<T>(T te)
            where T: TimedEvent<ChordFormula>
        {
#if false
      <harmony>
         <root>
         <root-step>C</root-step>
         </root>
         <kind text="m7">minor-seventh</kind>
      <offset>240</offset>
      </harmony>
#endif
            var harmony = new XElement(XmlConstants.harmony);
            var root = this.ToRoot((dynamic)te);
            harmony.Add(root);

            var kind = new XElement(XmlConstants.kind, te.Event.ChordType.Name);
            harmony.Add(kind);

            //throw new NotImplementedException("How do I get the offset?");
            var offset = new XElement(XmlConstants.offset);
            harmony.Add(offset);

            return harmony;
        }


        /// <summary>
        /// </summary>
        /// <param name="te"></param>
        /// <returns>
        ///      <note release="55">
        ///        <pitch>
        ///          <step>B</step>
        ///          <alter>-1</alter>
        ///          <octave>1</octave>
        ///        </pitch>
        ///         <duration>60</duration>
        ///         <voice>2</voice>
        ///         <type>eighth</type>
        ///         <beam number="1">begin</beam>
        ///      </note>
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public XElement ToXElement(TimedEvent<Note> te)
        {
            var nn = te.Event.NoteName;
            var note = te.Event;
            var time = te.TimeContext;

            var xnote = new XElement(XmlConstants.note);
            {
                var xpitch = new XElement(XmlConstants.pitch);
                {
                    var xstep = new XElement(XmlConstants.step);
                    xpitch.Add(xstep, nn.Name[0]);
                    
                    if (!nn.IsNatural)
                    {
                        XElement xalter = null;
                        if (nn.IsSharped)
                            xalter = new XElement(XmlConstants.alter, 1);
                        else if (nn.IsFlatted)
                            xalter = new XElement(XmlConstants.alter, -1);
                        xpitch.Add(xalter);
                    }

                    var xoctave = new XElement(XmlConstants.octave, (int)note.Octave);
                    xpitch.Add(xoctave);
                }
                xnote.Add(xpitch);
                {
                    this.GetDuration(time, out var xduration, out var xtype);
                    xnote.Add(xduration);
                    xnote.Add(xtype);
                }
            }
            new object();
            return xnote;
        }
        public XElement ToXElement(TimedEvent<Rest> te)
        {
#if false
      <note>
        <rest/>
         <duration>120</duration>
         <voice>1</voice>
         <type>quarter</type>
         <staff>1</staff>
      </note>

#endif
            var rest = te.Event;
            var time = te.TimeContext;

            var xnote = new XElement(XmlConstants.note);
            var xrest = new XElement(XmlConstants.rest);
            xnote.Add(xrest);

            this.GetDuration(time, out var duration, out var noteType);
            xrest.Add(duration);
            xrest.Add(noteType);

#warning May need to save voice and staff on import.

            return xrest;
        }

        void GetDuration(TimeContext time, out XElement duration, out XElement noteType)
        {
            duration = new XElement(XmlConstants.duration, time.Duration);
            noteType = new XElement(XmlConstants.type,
                time.GetNoteType().ToLower());
        }

    }//class
}//ns

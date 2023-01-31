using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class TimedEvent<T> : IHasTimeContext, IEquatable<TimedEvent<T>>, IComparable<TimedEvent<T>>
        where T : class, IMusicalEvent<T>, IComparable<T>, new()
    {
        #region Properties
        //public int AbsoluteStart { get { return this.TimeContext.AbsoluteStart; } }
        //public int AbsoluteEnd { get { return this.TimeContext.AbsoluteEnd; } }
        public int RelativeStart { get { return this.TimeContext.RelativeStart; } }
        public int RelativeEnd { get { return this.TimeContext.RelativeEnd; } }
        //public int Duration { get { return this.TimeContext.Duration; } }
        public int SortOrder { get { return this.Event.SortOrder; } }
        public T Event { get; set; }
        public TimeContext TimeContext { get; set; }
        public XmlSerializationProperties Serialization { get; set; } = new XmlSerializationProperties();
        public MusicXmlTimeModification TimeModification { get; set; }
        public bool HasTimeModification { get { return null == this.TimeModification; } }

        #endregion

        #region Construction
        public TimedEvent(TimedEvent<T> src)
        {
            var dst = src.Event.Copy();
            this.Event = dst;
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEvent(T @event, TimeContext ctx)
        {
            this.Event = @event;
            this.TimeContext = ctx;
        }

        #endregion

        #region Serialization

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

        public XElement ToXElement<TE>(TimedEvent<ChordFormula> te)
            where TE: TimedEvent<ChordFormula>
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
            var root = this.ToRoot(te);
            harmony.Add(root);

            var elems = te.Event.ChordType.ToXElements();
            harmony.Add(elems);

            //var kind = new XElement(XmlConstants.kind, te.Event.ChordType.GetMusicXmlName());
            //kind.Add(new XAttribute(XmlConstants.text,
            //    $"{te.Event.Root.Name[0]}{te.Event.ChordType.Name}"));
            //harmony.Add(kind);

#warning throw new NotImplementedException("How do I get the offset?");
            //var offset = new XElement(XmlConstants.offset);
            //harmony.Add(offset);

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
        public XElement ToXElement<TE>(TimedEvent<Note> te)
            where TE: TimedEvent<Note> 
        {
            var nn = te.Event.NoteName;
            var note = te.Event;
            var time = te.TimeContext;

            var xnote = new XElement(XmlConstants.note);
            {
                if (null != te.Serialization.Attack)
                    xnote.Add(new XAttribute(XmlConstants.attack, te.Serialization.Attack));
                if (null != te.Serialization.Release)
                    xnote.Add(new XAttribute(XmlConstants.release, te.Serialization.Release));

                var xpitch = new XElement(XmlConstants.pitch);
                {
                    var xstep = new XElement(XmlConstants.step, nn.Name[0]);
                    xpitch.Add(xstep);

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
                if (te.Serialization.HasChord)
                {
                    xnote.Add(new XElement(XmlConstants.chord));
                }
                xnote.Add(xpitch);
                {
                    this.ToXElements(time, out var xnoteTypeName, out var xduration, out var xdot);
                    xnote.Add(xduration);
                    xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
                    xnote.Add(xnoteTypeName);
                    xnote.Add(xdot);

                    if (!string.IsNullOrEmpty(te.Serialization.Staff))
                        xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));
                }

                if (te.TimeContext.TieType != TieTypeEnum.None)
                {
#if false
        <notations>
          <tied type="start"/>
        </notations>
#endif
                    var xnotations = new XElement(XmlConstants.notations);
                    xnote.Add(xnotations);
                    if (te.TimeContext.TieType == TieTypeEnum.Start)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.start);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (te.TimeContext.TieType == TieTypeEnum.Stop)
                    {
                        var xtype = new XAttribute(XmlConstants.type, XmlConstants.stop);
                        var xtied = new XElement(XmlConstants.tied, xtype);
                        xnotations.Add(xtied);
                    }
                    if (te.TimeContext.TieType == TieTypeEnum.StartStop)
                    {
                        var xtypeStart = new XAttribute(XmlConstants.type, XmlConstants.start);
                        var xtiedStart = new XElement(XmlConstants.tied, xtypeStart);
                        xnotations.Add(xtiedStart);
                        var xtypeStop = new XAttribute(XmlConstants.type, XmlConstants.stop);
                        var xtiedStop = new XElement(XmlConstants.tied, xtypeStart);
                        xnotations.Add(xtiedStop);
                    }
                }
            }
            new object();
            return xnote;
        }
        public XElement ToXElement<TE>(TimedEvent<Rest> te)
            where TE: TimedEvent<Rest> 
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

            this.ToXElements(time, out var xnoteTypeName, out var xduration, out var xdot);
            xnote.Add(xduration);
            xnote.Add(new XElement(XmlConstants.voice, te.Serialization.Voice));
            xnote.Add(xnoteTypeName);
            xnote.Add(xdot);

            if (!string.IsNullOrEmpty(te.Serialization.Staff))
                xnote.Add(new XElement(XmlConstants.staff, te.Serialization.Staff));

            return xnote;
        }

        public XElement ToXElement<TE>(TimedEvent<Forward> te)
            where TE: TimedEvent<Forward>
        {
            var rest = te.Event;
            var time = te.TimeContext;

            var xforward = new XElement(XmlConstants.forward);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xforward.Add(xduration);
            return xforward;
        }

        public XElement ToXElement<TE>(TimedEvent<Backup> te)
            where TE: TimedEvent<Backup>
        {
            var rest = te.Event;
            var time = te.TimeContext;

            var xbackup = new XElement(XmlConstants.backup);
            var xduration = new XElement(XmlConstants.duration, time.Duration);
            xbackup.Add(xduration);
            return xbackup;
        }


        void ToXElements(TimeContext time, out XElement xnoteTypeName, out XElement xduration, out XElement xdot)
        {
            time.TryGetName(time.DurationEnum, out var name, out var isDotted);
            xnoteTypeName = null; xduration = null; xdot = null;
#if true
            xnoteTypeName = new XElement(XmlConstants.type, name);

            xduration = new XElement(XmlConstants.duration, time.Duration);
            xdot = null;
            if (isDotted)
            {
                xdot = new XElement(XmlConstants.dot);
            }
#endif
        }

        #endregion

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        #region IEquatable
        public bool Equals(TimedEvent<T> other)
        {
            var result = false;
            if (this.Event.Equals(other.Event)
                && this.TimeContext.Equals(other.TimeContext))
                result = true;
            return result;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TimedEvent<T>)
                result = this.Equals(obj as TimedEvent<T>);
            return result;
        }
        public int CompareTo(TimedEvent<T> other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEvent<T> a, TimedEvent<T> b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.Event.CompareTo(b.Event);

            if (0 == result)
            {
                result = a.TimeContext.CompareTo(b.TimeContext);
            }
            return result;
        }
        public override int GetHashCode()
        {
            var result = this.Event.GetHashCode()
                ^ this.TimeContext.ToString().GetHashCode();
            //Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}: {this.ToString()}={result}");

            return result;
        }
        public static bool operator ==(TimedEvent<T> a, TimedEvent<T> b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEvent<T> a, TimedEvent<T> b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion
    }//class

    public class XmlSerializationProperties
    {
        public string Voice { get; set; }
        public string Staff { get; set; }
        public bool HasChord { get; set; }
        int Forward { get; set; }
        int Backup { get; set; }
        bool HasForward { get { return  this.Forward != 0; } }
        bool HasBackup { get { return  this.Backup != 0; } }   
        public string Attack { get; set; }
        public string Release { get; set; }

        public XmlSerializationProperties() { }
        public XmlSerializationProperties(XmlSerializationProperties src) 
        { 
            this.Staff = src.Staff;
            this.Forward = src.Forward; 
            this.Backup = src.Backup;
            this.Attack = src.Attack;
            this.Release = src.Release;
            this.Voice = src.Voice; 
        }
    }

    public class TimedEventFactory
    {
        static public TimedEventFactory Instance { get; } = new TimedEventFactory();
        public int PulsesPerMeasure { get; set; } = int.MinValue;

        TimedEventFactory() { }

        public TimedEvent<ChordFormula> CreateTimedEvent(ChordFormula formula,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = DurationEnum.None
            };
            var time = new TimeContext(ctx);
            var result = new TimedEvent<ChordFormula>(formula, 
                time);
            return result;
        }

        public TimedEvent<Note> CreateTimedEvent(Note note,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            DurationEnum de,
            MusicXmlTimeModification timeModification,
            XElement xnote)
        {
            Debug.Assert(de != DurationEnum.Unknown);
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = de
            };
            var time = new TimeContext(ctx);
            var result = new TimedEvent<Note>(note,
                time);
            result.TimeModification = timeModification;
            return result;
        }
        public TimedEvent<Rest> CreateTimedEvent(Rest rest,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            DurationEnum de,
            MusicXmlTimeModification timeModification,
            XElement xnote)
        {
            //Debug.Assert(de != DurationEnum.None);
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = de
            };
            var time = new TimeContext(ctx);
            var result = new TimedEvent<Rest>(rest,
                time);
            result.TimeModification = timeModification;
            return result;
        }

        public TimedEvent<Forward> CreateTimedEvent(Forward rest,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            MusicXmlTimeModification timeModification)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration
            };
            var time = new TimeContext(ctx);
            var result = new TimedEvent<Forward>(rest,
                time);
            result.TimeModification = timeModification;
            return result;
        }

        public TimedEvent<Backup> CreateTimedEvent(Backup rest,
            RhythmicContext rhythm,
            int measureNumber,
            int start,
            int duration,
            MusicXmlTimeModification timeModification)
        {
            Debug.Assert(this.PulsesPerMeasure != int.MinValue);
            var ctx = new TimeContext.CreationContext()
            {
                MeasureNumber = measureNumber,
                Rhythm = rhythm,
                RelativeStart = start,
                RelativeEnd = start + duration,
                Duration = DurationEnum.None
            };
            var time = new TimeContext(ctx);
            var result = new TimedEvent<Backup>(rest,
                time);
            result.TimeModification = timeModification;
            return result;
        }

    }//class

}//ns

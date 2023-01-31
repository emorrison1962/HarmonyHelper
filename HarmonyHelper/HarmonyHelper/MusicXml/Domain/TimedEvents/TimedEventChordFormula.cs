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
    public class TimedEventChordFormula : TimedEventBase, IHasTimeContext, IEquatable<TimedEventChordFormula>, IComparable<TimedEventChordFormula>
    {
        #region Properties
        override public int SortOrder { get { return this.Event.SortOrder; } }
        public ChordFormula Event { get; set; }

        #endregion

        #region Construction
        public TimedEventChordFormula(TimedEventChordFormula src)
            : base(src)
        {
            var dst = src.Event.Copy();
            this.Event = dst;
            this.TimeContext = new TimeContext(src.TimeContext);
            this.Serialization = new XmlSerializationProperties(src.Serialization);
        }

        public TimedEventChordFormula(ChordFormula @event, TimeContext ctx)
            : base(ctx)
        {
            this.Event = @event;
        }

        #endregion

        #region Serialization

        public XElement ToXElementRootNote()
        {
#if false
  <root>
    <root-step>B</root-step>
    <root-alter>-1</root-alter>
  </root>
#endif

            var root = new XElement(XmlConstants.root);

            var root_step = new XElement(XmlConstants.root_step, this.Event.Root.Name[0]);
            root.Add(root_step);

            if (!this.Event.Root.IsNatural)
            {
                if (this.Event.Root.IsSharped)
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

        override public XElement ToXElement()
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
            var root = this.ToXElementRootNote();
            harmony.Add(root);

            var elems = this.Event.ChordType.ToXElements();
            harmony.Add(elems);

            //var kind = new XElement(XmlConstants.kind, this.Event.ChordType.GetMusicXmlName());
            //kind.Add(new XAttribute(XmlConstants.text,
            //    $"{this.Event.Root.Name[0]}{this.Event.ChordType.Name}"));
            //harmony.Add(kind);

#warning throw new NotImplementedException("How do I get the offset?");
            //var offset = new XElement(XmlConstants.offset);
            //harmony.Add(offset);

            return harmony;
        }

        #endregion

        public override string ToString()
        {
            return $"{this.GetType().Name} TimeContext={this.TimeContext}, Event={this.Event.ToString()}";
        }

        #region IEquatable
        public bool Equals(TimedEventChordFormula other)
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
            if (obj is TimedEventChordFormula)
                result = this.Equals(obj as TimedEventChordFormula);
            return result;
        }
        public int CompareTo(TimedEventChordFormula other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(TimedEventChordFormula a, TimedEventChordFormula b)
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
            return result;
        }
        public static bool operator ==(TimedEventChordFormula a, TimedEventChordFormula b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(TimedEventChordFormula a, TimedEventChordFormula b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion
    }//class
}//ns

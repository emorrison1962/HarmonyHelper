using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


namespace Eric.Morrison.Harmony
{
    public class UnresolvedTiedNote : IEquatable<UnresolvedTiedNote>
    {
        static int _instances = 0;
        protected int _instanceID = ++_instances;

        public IMusicXmlParser Parser { get; }
        public Note Note { get; set; }
        public int CurrentOffset { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        TieTypeEnum _TieType = TieTypeEnum.Unknown;
        public TieTypeEnum TieType
        {
            get
            {
                return this._TieType;
            }
            set
            {
                this._TieType = value;
                if (TieTypeEnum.Stop == this._TieType)
                {
                    this.Parser.TiedNoteResolvedAsync(this);
                }
            }
        }
        public UnresolvedTiedNote(IMusicXmlParser parser, XElement note, int CurrentOffset)
        {
            if (this._instanceID == 13)
            {
                new object();
            }
            this.Parser = parser;
            this.Note = this.ParseNote(note);
            this.CurrentOffset = CurrentOffset;
            this.ParseTie(note);
        }

        private void ParseTie(XElement note)
        {
#if false
<note attack="18">
  <duration>60</duration>
  <tie type="start" />
</note>
#endif
            var ties = note.Descendants(XmlConstants.tie).ToList();
            Debug.Assert(ties.Count == 1);
            var attrVal = ties[0].Attribute("type").Value;
            if (XmlConstants.start == attrVal)
                this._TieType = TieTypeEnum.Start;
            else
                this._TieType = TieTypeEnum.Stop;
        }

        Note ParseNote(XElement note)
        {
            var result = this.Parser.Parse_HarmonyHelper_Note(note.Descendants(XmlConstants.pitch).First());
            return result;
        }

        public int Resolve(int endTime)
        {//untested
            return CurrentOffset + endTime;
        }

        public bool Equals(UnresolvedTiedNote other)
        {
            bool result = false;
            if (this.Guid == other.Guid
                && this.CurrentOffset == other.CurrentOffset
                && this.Note == other.Note
                && this.TieType == other.TieType)
            {
                result = true;
            }
            return result;
        }

        public override int GetHashCode()
        {
            return this.Guid.GetHashCode()
                ^ this.CurrentOffset.GetHashCode()
                ^ this.Note.GetHashCode()
                ^ this.TieType.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is UnresolvedTiedNote)
            {
                result = this.Equals(obj as UnresolvedTiedNote);
            }
            else
            {
                result = base.Equals(obj);
            }
            return result;
        }

    }//class

}//ns

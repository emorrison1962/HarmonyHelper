using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


namespace Eric.Morrison.Harmony
{
    public class TiedNoteContext 
    {
        #region Properties

        public IMusicXmlParser Parser { get; }
        public Note Note { get; set; }
        public int Measure { get; set; }
        public int Offset { get; set; }
        public int Duration { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public TieTypeEnum TieType { get; set; }

        #endregion

        #region Construction
        public TiedNoteContext(IMusicXmlParser parser, XElement note, 
            TieTypeEnum tieType, int measure, int offset)
        {
            this.Parser = parser;
            this.Note = this.ParseNote(note);
            this.Measure = measure;
            this.Offset = offset;
            this.TieType = tieType;
            this.Duration = Parser.ParseDuration(note);

        }

        #endregion

        public bool TryResolve()
        {
            var result = false;
            if (this.TieType == TieTypeEnum.Stop)
            {
                this.Parser.ResolveTiedNote(this);
                //Action action = () => this.ResolveTiedNote();
                //action.BeginInvoke(null, null);
                result = true;
            }
            return result;
        }

        Note ParseNote(XElement note)
        {
            var result = this.Parser.Parse_HarmonyHelper_Note(note);
            return result;
        }

        public int Resolve(int endTime)
        {//untested
            return Offset + endTime;
        }

        void ResolveTiedNote()
        {
            Action action = () => this.Parser.ResolveTiedNote(this);
            action.BeginInvoke(null, null);
        }

        public bool Equals(TiedNoteContext other)
        {
            bool result = false;
            if (this.Note == other.Note)
            {
                result = true;
            }
            return result;
        }

        public override int GetHashCode()
        {
            return this.Guid.GetHashCode()
                ^ this.Offset.GetHashCode()
                ^ this.Note.GetHashCode()
                ^ this.TieType.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is TiedNoteContext)
            {
                result = this.Equals(obj as TiedNoteContext);
            }
            else
            {
                result = base.Equals(obj);
            }
            return result;
        }

        public override string ToString()
        {
            return this.Guid.ToString();
        }
    }//class

}//ns

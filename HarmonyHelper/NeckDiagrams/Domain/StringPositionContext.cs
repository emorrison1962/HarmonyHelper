using System;
using System.Collections.Generic;
using System.Text;

using Eric.Morrison.Harmony;

namespace NeckDiagrams.Domain
{
    public class StringPositionContext
    {
        public int Position { get; set; }
        public Note Note { get; set; }
        public NoteTypeEnum NoteType { get { return NoteTypeEnum.ChordTone; } }

        public StringPositionContext(int index, Note note)
        {
            this.Position = index;
            this.Note = note;
        }

        public bool IsValid { get { return Note != null; } }
    }
}

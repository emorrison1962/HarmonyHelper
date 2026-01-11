using System;
using System.Collections.Generic;
using System.Text;

using Eric.Morrison.Harmony;

namespace NeckDiagrams.Domain
{
    public class GuitarStringModel
    {
        public event EventHandler<GuitarStringModel> GuitarStringChanged;
        public NoteRange NoteRange { get; set; }

        public List<NoteName> _ActiveNotes = new List<NoteName>();
        public List<NoteName> ActiveNotes
        {
            get { return this._ActiveNotes; }
            set
            {
                this._ActiveNotes = value;
                this.OnGuitarStringChanged();
            }
        }

        public GuitarStringModel(NoteRange noteRange)
        {
            if (null == noteRange)
                throw new ArgumentNullException(nameof(noteRange));
            this.NoteRange = noteRange;
        }

        void OnGuitarStringChanged()
        {
            if (this.GuitarStringChanged != null)
                this.GuitarStringChanged(this, this);
        }
    }
}

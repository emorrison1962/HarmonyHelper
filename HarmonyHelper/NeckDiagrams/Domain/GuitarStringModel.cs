using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

using Eric.Morrison.Harmony;

using Microsoft.VisualBasic;

using NeckDiagrams.Properties;

using Newtonsoft.Json;

namespace NeckDiagrams.Domain
{
    public enum GuitarStringNdxEnum
    {
        None = -1,
        Sixth = 0,
        Fifth,
        Fourth,
        Third,
        Second,
        First
    };

    public class GuitarStringModel
    {
        const int ONE_OCTAVE = 1;

        public event EventHandler<GuitarStringModel> GuitarStringChanged;

        #region Properties
        Note _OpenNote { get; set; }
        public Note OpenNote
        {
            get { return this._OpenNote; }
            set
            {
                _OpenNote = value;
                this.SetNoteRange();
            }
        }

        NoteRange _NoteRange;
        public NoteRange NoteRange
        {
            get
            {
                if (null == this._NoteRange)
                    this.SetNoteRange();
                return this._NoteRange;
            }
            set
            {
                //if (null == value)
                //    throw new ArgumentNullException("value");
                this._NoteRange = value;
            }
        }

        public GuitarStringNdxEnum GuitarStringNdx { get; set; }

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

        #endregion

        #region Construction

        [Newtonsoft.Json.JsonConstructor]
        public GuitarStringModel() { }
        public GuitarStringModel(GuitarStringNdxEnum ndx, Note openNote)
        {
            if (null == openNote)
                throw new ArgumentNullException(nameof(openNote));
            if (ndx == GuitarStringNdxEnum.None)
                throw new ArgumentNullException(nameof(ndx));

            this.GuitarStringNdx = ndx;
            this.OpenNote = openNote;
        }

        #endregion

        void SetNoteRange()
        {
            if (null == this._NoteRange || this._NoteRange.LowerLimit != this._OpenNote)
                this._NoteRange = new NoteRange(this._OpenNote, ONE_OCTAVE);
        }

        void OnGuitarStringChanged()
        {
            if (this.GuitarStringChanged != null)
                this.GuitarStringChanged(this, this);
        }
    }

}//ns

using CommunityToolkit.Mvvm.ComponentModel;
using Eric.Morrison.Harmony;
using Microsoft.VisualBasic;
using NeckDiagrams.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

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

    public class GuitarStringVM : ObservableObject
    {
        const int ONE_OCTAVE = 1;

        #region Fields
        Note openNote;
        NoteRange noteRange;
        GuitarStringNdxEnum guitarStringNdx = GuitarStringNdxEnum.None;
        ObservableCollection<NoteName> activeNotes = new ObservableCollection<NoteName>();
        ObservableCollection<StringPositionVM> stringPositions = new ObservableCollection<StringPositionVM>();

        #endregion

        #region Properties

        public Note OpenNote
        {
            get => this.openNote;
            set
            {
                if (SetProperty(ref openNote, value))
                {
                    this.SetNoteRange();
                    OnPropertyChanged(nameof(OpenNote));
                }
            }
        }

        public NoteRange NoteRange
        {
            get => this.noteRange;
            set
            {
                if (SetProperty(ref noteRange, value))
                {
                    OnPropertyChanged(nameof(NoteRange));
                }
            }
        }

        public GuitarStringNdxEnum GuitarStringNdx
        {
            get => this.guitarStringNdx;
            set
            {
                if (SetProperty(ref guitarStringNdx, value))
                {
                    OnPropertyChanged(nameof(GuitarStringNdx));
                }
            }
        }

        public ObservableCollection<NoteName> ActiveNotes
        {
            get => this.activeNotes;
            set
            {
                if (SetProperty(ref activeNotes, value))
                {
                    OnPropertyChanged(nameof(ActiveNotes));
                }
            }
        }

        public ObservableCollection<StringPositionVM> StringPositions
        {
            get => this.stringPositions;
            set
            {
                if (SetProperty(ref stringPositions, value))
                {
                    OnPropertyChanged(nameof(StringPositions));
                }
            }
        }

        #endregion

        #region Construction

        [Newtonsoft.Json.JsonConstructor]
        public GuitarStringVM() { }
        public GuitarStringVM(GuitarStringNdxEnum ndx, Note openNote)
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
            if (null == this.noteRange || this.noteRange.LowerLimit != this.openNote)
                this.NoteRange = new NoteRange(this.openNote, ONE_OCTAVE);
        }

        internal void SetActiveNotes(List<NoteName> noteNames)
        {
            this.ActiveNotes.Clear();
            foreach (var item in noteNames)
            {   
                this.ActiveNotes.Add(item);
            }
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            this.SetNoteRange();
        }

    }//class

}//ns

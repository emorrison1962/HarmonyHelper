using CommunityToolkit.Mvvm.ComponentModel;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using System;
using System.Collections.Generic;
using System.Text;


namespace NeckDiagrams.Domain
{
    public class StringPositionVM : ObservableObject
    {
        public int Position { get; set; }
        public Note Note { get; set; }
        public NoteTypeEnum NoteType { get { return NoteTypeEnum.ChordTone; } }
        bool isActive = false;
        public bool IsActive
        {
            get => this.isActive;
            private set
            {
                if (SetProperty(ref isActive, value))
                {
                    OnPropertyChanged("IsActive");
                }
            }
        }



        public StringPositionVM(int index, Note note)
        {
            this.Position = index;
            this.Note = note;
        }

        public bool IsValid { get { return Note != null; } }
    }
}

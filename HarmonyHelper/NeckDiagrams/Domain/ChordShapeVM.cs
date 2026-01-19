using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using Newtonsoft.Json.Linq;

namespace NeckDiagrams.Domain
{
    public interface IChordShapeVM
    {
        ChordFormula ChordFormula { get; }
        GuitarStringCollection GuitarStringCollection { get; set; }

        void Set(ChordFormula cf);
    }

    public partial class ChordShapeVM : ObservableObject, IChordShapeVM
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        void foo()
        {
            OnPropertyChanged(nameof(this.ChordFormula));
        }


        #region Properties


        public int junk { get; set; }

        public ChordFormula chordFormula;
        public ChordFormula ChordFormula
        {
            get => this.chordFormula;
            private set
            {
                if (SetProperty(ref chordFormula, value))
                {
                    OnPropertyChanged(nameof(ChordFormula));
                }
            }
        }

        public List<NoteName> NoteNames => this.chordFormula.NoteNames;
        public GuitarStringCollection GuitarStringCollection
        {
            get { return GuitarStringCollection.LoadSettingsOrDefault(); }
            set { GuitarStringCollection.SaveToSettings(value); }
        }

        #endregion
        
        #region Construction
        public ChordShapeVM() { }

        #endregion    

        public void Set(ChordFormula cf)
        {
            this.ChordFormula = cf;

            foreach (GuitarStringVM gsm in this.GuitarStringCollection.Dictionary.Values)
            {
                gsm.ActiveNotes = cf.NoteNames;
            }

        }

    }//class
}//ns

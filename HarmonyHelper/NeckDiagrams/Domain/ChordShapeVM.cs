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
    public partial class ChordShapeVM : ObservableObject, IChordShapeVM
    {

        #region Fields
        public ChordFormula chordFormula;
        public List<NoteName> NoteNames => this.chordFormula.NoteNames;
        public GuitarStringCollection guitarStringCollection;

        #endregion

        #region Properties

        public ChordFormula ChordFormula
        {
            get => this.chordFormula;
            set
            {
                if (SetProperty(ref chordFormula, value))
                {
                    this.Set(value);
                    OnPropertyChanged(nameof(ChordFormula));
                }
            }
        }

        public GuitarStringCollection GuitarStringCollection
        {
            get => guitarStringCollection;
            set
            {
                if (SetProperty(ref guitarStringCollection, value))
                {
                    GuitarStringCollection.SaveToSettings(value); 
                    OnPropertyChanged(nameof(GuitarStringCollection));
                }
            }
        }

        #endregion

        #region Construction
        public ChordShapeVM() 
        { 
            this.chordFormula = ChordFormula.CMajor7;
            this.guitarStringCollection = GuitarStringCollection.LoadSettingsOrDefault(); 
        }

        #endregion    

         public void Set(ChordFormula cf)
        {
            //this.ChordFormula = cf;

            foreach (GuitarStringVM gsm in this.GuitarStringCollection.Dictionary.Values)
            {
                gsm.SetActiveNotes(cf.NoteNames);
            }

        }

    }//class

    public interface IChordShapeVM : INotifyPropertyChanged
    {
        ChordFormula ChordFormula { get; set; }
        GuitarStringCollection GuitarStringCollection { get; set; }

        void Set(ChordFormula cf);
    }//interface


}//ns

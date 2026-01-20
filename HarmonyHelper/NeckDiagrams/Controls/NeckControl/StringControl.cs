using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

using Eric.Morrison;
using Eric.Morrison.Harmony;

using NeckDiagrams.Domain;

namespace NeckDiagrams
{
    public partial class GuitarStringControl : UserControl 
    {
        const int FRET_COUNT = 13;

        #region Properties
        IChordShapeVM Model { get; set; }
        GuitarStringVM GuitarStringVM { get; set; }
        NoteRange NoteRange { get { return GuitarStringVM.NoteRange; } }
        ObservableCollection<NoteName> ActiveNotes { get { return GuitarStringVM?.ActiveNotes; } }
        public GuitarStringNdxEnum GuitarStringNdx { get; private set; }

        #endregion

        #region Construction
        GuitarStringControl()
        {
            InitializeComponent();
            this.Load += this.StringControl_Load;
            this.Layout += this.StringControl_Layout;
        }
        public GuitarStringControl(GuitarStringNdxEnum stringNumber)
            : this()
        {
            this.GuitarStringNdx = stringNumber;
        }

        private void StringControl_Load(object sender, EventArgs e)
        {
            Init();
            if (!DesignMode)
            {
                this.CreateControls();
                this.UpdatePositions();
            }
        }

        void Init()
        {
            if (this.Model == null)
            {
                this.Model = HarmonyHelper.IoC.Container.Resolve<IChordShapeVM>();
            }
            var gsvm = this.Model.GuitarStringCollection[GuitarStringNdx];
            gsvm.PropertyChanged += GuitarString_PropertyChanged;
            this.GuitarStringVM = gsvm;
            //this.Model.ModelChanged += Model_ModelChanged;
            //this.Model.ChordFormulaChanged += Model_ChordFormulaChanged;
            //this.Model.GuitarStringModelChanged += Model_GuitarStringModelChanged;
        }

        private void GuitarString_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        void CreateControls()
        {
            this.Controls.Clear();
            var ctls = new List<Control>();
            for (int i = 0; i < FRET_COUNT; ++i)
            {
                var note = this.NoteRange.Notes.NextOrFirst(i);
                var ctl = new StringPositionControl(new StringPositionVM(i, note));
                ctl.Dock = DockStyle.Left;
                ctls.Insert(0, ctl);
            }

            this.Controls.AddRange(ctls.ToArray());
        }

        //private void Model_ModelChanged(object sender, ChordShapeVM vm)
        //{
        //    this.GuitarStringModel = vm.GuitarStringCollection.Dictionary[this.GuitarStringNdx];
        //    this.UpdatePositions();
        //    this.Refresh();
        //}

        private void Model_ChordFormulaChanged(object sender, Eric.Morrison.Harmony.Chords.ChordFormula e)
        {
            throw new NotImplementedException();
        }

        private void Model_GuitarStringModelChanged(object sender, GuitarStringVM e)
        {
            this.UpdatePositions();
            this.Refresh();
        }

        private void UpdatePositions()
        {
            var ctls = this.Controls.Cast<StringPositionControl>();
            foreach (var ctl in ctls)
            {
                ctl.IsActive = this.ActiveNotes.Contains(ctl.Note.NoteName, new NoteNameValueEqualityComparer());
            }
        }

        private void StringControl_Layout(object sender, LayoutEventArgs e)
        {
            var cx = this.Width / FRET_COUNT;
            foreach (var ctl in this.Controls.Cast<Control>())
            {
                ctl.Width = cx;
                ctl.Height = this.Height;
            }
        }

    }//class
}//ns

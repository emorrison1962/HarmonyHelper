using System;
using System.Collections.Generic;
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
        GuitarStringVM GuitarStringModel { get { return this.Model.GuitarStringCollection.Dictionary[this.GuitarStringNdx];  } }
        NoteRange NoteRange { get { return GuitarStringModel.NoteRange; } }
        List<NoteName> ActiveNotes { get { return GuitarStringModel?.ActiveNotes; } }
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

        #endregion

        void InitModel()
        {
            //this.Model.ModelChanged += Model_ModelChanged;
            //this.Model.ChordFormulaChanged += Model_ChordFormulaChanged;
            //this.Model.GuitarStringModelChanged += Model_GuitarStringModelChanged;
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

        private void StringControl_Load(object sender, EventArgs e)
        {
            //this.Model.ModelChanged += this.ModelChanged_Handler;
            new object();

            if (!DesignMode)
            {
                this.CreateControls();
                this.UpdatePositions();
            }
        }

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

        private void UpdatePositions()
        {
            var ctls = this.Controls.Cast<StringPositionControl>();
            foreach (var ctl in ctls)
            {
                ctl.IsActive = this.ActiveNotes.Contains(ctl.Note.NoteName);
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

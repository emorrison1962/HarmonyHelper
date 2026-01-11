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
    public partial class StringControl : UserControl
    {
        const int FRET_COUNT = 13;
        NoteRange NoteRange { get { return StringModel.NoteRange; } }
        GuitarStringModel _StringModel;
        GuitarStringModel StringModel
        {
            get { return this._StringModel; }
            set { this._StringModel = value;
                value.GuitarStringChanged += GuitarStringChanged; }
        }

        private void GuitarStringChanged(object sender, GuitarStringModel e)
        {
            this.UpdatePositions();
            this.Refresh();
        }

        List<NoteName> ActiveNotes { get { return StringModel?.ActiveNotes; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StringNumber { get; set; }
        [Obsolete("", true)]
        HarmonyContext Model { get { return HarmonyHelper.IoC.Container.Resolve<IHarmonyContext>() as HarmonyContext; } }

        StringControl()
        {
            InitializeComponent();
            this.Load += this.StringControl_Load;
            this.Layout += this.StringControl_Layout;
        }
        public StringControl(int stringNum, GuitarStringModel gsModel, List<NoteName> activeNotes)
            : this()
        {
            this.StringNumber = stringNum;
            this.StringModel = gsModel;
            Debug.Assert(activeNotes.Count == 0);
        }


        private void StringControl_Load(object sender, EventArgs e)
        {
            //this.Model.ModelChanged += this.ModelChanged_Handler;
            new object();

            if (!DesignMode)
            {
                this.Controls.Clear();
                var ctls = new List<Control>();

                for (int i = 0; i < FRET_COUNT; ++i)
                {
                    var note = this.NoteRange.Notes.NextOrFirst(i);
                    var ctl = new StringPositionControl(new StringPositionContext(i, note));
                    ctl.Dock = DockStyle.Left;
                    ctls.Insert(0, ctl);
                }

                this.Controls.AddRange(ctls.ToArray());

                this.UpdatePositions();
            }
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

        public void ModelChanged_Handler(object sender, HarmonyContext model)
        {
            if (null != model.NoteNames)
            {
                this.StringModel.ActiveNotes = model.NoteNames;
                this.UpdatePositions();
                this.Refresh();
            }
        }



    }//class
}//ns

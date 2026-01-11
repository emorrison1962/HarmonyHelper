using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Scales;

using NeckDiagrams.Domain;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace NeckDiagrams
{
    public partial class NeckControl : UserControl
    {
        //List<NoteRange> NoteRanges { get; set; } = new List<NoteRange>();
        List<GuitarStringModel> GuitarStrings { get; set; } = new List<GuitarStringModel>();
        Scale MusicalScale { get; set; }
        public PrintDocument PrintDocument { get { return this.printDocument; } }
        //[Obsolete("")]
        //HarmonyContext _Model { get; set; } = null;
        //HarmonyContext Model
        //{
        //    get { return this._Model; }
        //    set
        //    {
        //        if (null != this._Model)
        //            value.ModelChanged -= ModelChanged_Handler;
        //        this._Model = value;
        //        value.ModelChanged += ModelChanged_Handler;
        //    }
        //}


        public NeckControl()
        {
            InitializeComponent();
            this.Load += this.NeckControl_Load;
            this.Layout += this.NeckControl_Layout;
            //this.Model = HarmonyHelper.IoC.Container.Resolve<IHarmonyContext>() as HarmonyContext;
            //this.Model.ModelChanged += ModelChanged_Handler;
        }

        private void NeckControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //this.Model.ModelChanged += this.ModelChanged_Handler;

                this.Controls.Clear();
                var ctls = new List<StringControl>();

                var string1 = new GuitarStringModel(new NoteRange(
                    new Note(NoteName.E, OctaveEnum.Octave3),
                    new Note(NoteName.E, OctaveEnum.Octave4)));

                var string2 = new GuitarStringModel(new NoteRange(
                    new Note(NoteName.B, OctaveEnum.Octave3),
                    new Note(NoteName.B, OctaveEnum.Octave4)));

                var string3 = new GuitarStringModel(new NoteRange(
                    new Note(NoteName.G, OctaveEnum.Octave2),
                    new Note(NoteName.G, OctaveEnum.Octave3)));

                var string4 = new GuitarStringModel(new NoteRange(
                    new Note(NoteName.D, OctaveEnum.Octave2),
                    new Note(NoteName.D, OctaveEnum.Octave3)));

                var string5 = new GuitarStringModel(new NoteRange(
                    new Note(NoteName.A, OctaveEnum.Octave1),
                    new Note(NoteName.A, OctaveEnum.Octave2)));

                var string6 = new GuitarStringModel(new NoteRange(
                    new Note(NoteName.E, OctaveEnum.Octave1),
                    new Note(NoteName.E, OctaveEnum.Octave2)));

                this.GuitarStrings = new List<GuitarStringModel>()
                { string1, string2, string3, string4, string5, string6 };

                for (int i = 0; i < this.GuitarStrings.Count; ++i)
                {
                    var gString = this.GuitarStrings[i];
                    gString.GuitarStringChanged += String_GuitarStringChanged;
                    var ctl = new StringControl(i, gString, new List<NoteName>());
                    ctl.Dock = DockStyle.Top;
                    ctls.Insert(0, ctl);
                }

                this.Controls.AddRange(ctls.ToArray());
                this.PerformLayout();
            }
        }

        private void String_GuitarStringChanged(object sender, GuitarStringModel e)
        {
            this.Refresh();
        }

        public void SetChord(ChordFormula cf)
        {
            foreach (var gs in this.GuitarStrings)
            {
                gs.ActiveNotes = cf.NoteNames;
            }
            this.Refresh();
        }
        private void NeckControl_MouseMove(object sender, MouseEventArgs e)
        {
#if false
			var graphics = Graphics.FromHwnd(this.Handle);
			var rc = new Rectangle(e.X - 50, e.Y - 50, e.X + 50, e.Y + 50);
			using (var font = new Font(FontFamily.GenericMonospace, 20))
			{
				graphics.FillRectangle(Brushes.White, new Rectangle(100, 100, 200, 50));
				graphics.DrawString($"X={e.X}, Y={e.Y}",
					font,
					Brushes.Black,
					new Point(100, 100));
			}
#endif
        }

        private void NeckControl_Layout(object sender, LayoutEventArgs e)
        {
            var cy = this.Height / 6;
            foreach (var ctl in this.Controls.Cast<Control>())
            {
                ctl.Height = cy;
                ctl.Width = this.Width;
            }
        }

        public void ModelChanged_Handler(object sender, HarmonyContext model)
        {
            new object();
            this.Refresh();
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            new object();
        }

        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            new object();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.OnPaint(new PaintEventArgs(e.Graphics, e.MarginBounds));
            new object();
        }

        private void printDocument_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            new object();
        }
    }//class
}//ns

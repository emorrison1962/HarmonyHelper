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
    public partial class NeckControl<T> : UserControl where T : INoteNameContainer
    {
        GuitarStringCollection GuitarStrings { get; set; }
        Scale MusicalScale { get; set; }
        public PrintDocument PrintDocument { get { return this.printDocument; } }

        public NeckControl()
        {
            InitializeComponent();
            this.GuitarStrings = GuitarStringCollection.LoadSettingsOrDefault();

            this.Load += this.NeckControl_Load;
            this.Layout += this.NeckControl_Layout;
        }

        private void NeckControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //this.Model.ModelChanged += this.ModelChanged_Handler;

                this.Controls.Clear();
                var ctls = new List<StringControl<T>>();

                foreach (var gs in this.GuitarStrings.Dictionary.Values)
                {
                    gs.GuitarStringChanged += String_GuitarStringChanged;
                    var ctl = new StringControl<T>(gs);
                    ctl.Dock = DockStyle.Top;
                    //ctls.Insert(0, ctl);
                    ctls.Add(ctl);
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
            foreach (var gs in this.GuitarStrings.Dictionary.Values)
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

        public void ModelChanged_Handler(object sender, HarmonyContext<T> model)
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

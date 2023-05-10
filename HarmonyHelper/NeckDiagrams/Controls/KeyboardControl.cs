using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony;

namespace NeckDiagrams.Controls
{
#pragma warning disable CA1416
    public partial class KeyboardControl : UserControl
    {
        Dictionary<Note, Region> NoteRegions = new();

        public void Arpeggiator_CurrentNoteChanged(object? sender, Arpeggiator args)
        {
            Debug.WriteLine($"\t\t\tArpeggiator_CurrentNoteChanged: {args.CurrentNote}");
            this.NoteChanged(args);
            new object();
        }

        private void NoteChanged(Arpeggiator arpeggiator)
        {
            this.NoteChanged(arpeggiator.CurrentNote);
        }

        Region LastRegion { get; set; }
        private void NoteChanged(Note currentNote)
        {
            if (this.NoteRegions.ContainsKey(currentNote))
            {
                if (null != this.LastRegion)
                {
                    this.Invalidate(this.LastRegion);
                    this.Refresh();
                }

                var region = this.NoteRegions[currentNote];
                using (var graphics = Graphics.FromHwnd(this.Handle))
                {
                    var rc = region.GetBounds(graphics);
                    var cx = Math.Min(rc.Width, rc.Height);
                    var rc2 = new RectangleF(
                        new PointF(rc.Bottom - cx, 0), 
                        new SizeF(cx, cx));
                    graphics.FillRegion(Brushes.Red, region);
                    //graphics.FillEllipse(Brushes.Red, rc);


                    this.LastRegion = region;
                }
            }
            new object();
        }

        public KeyboardControl()
        {
            InitializeComponent();
        }

        private void KeyboardControl_Load(object sender, EventArgs e)
        {

        }

        private void KeyboardControl_Paint(object sender, PaintEventArgs e)
        {
            this.DrawKeyboard(e.Graphics, e.ClipRectangle, 52);
        }

        private void DrawKeyboard(Graphics g, RectangleF rect, int numKeys)
        {
            float keyWidth = rect.Width / numKeys;
            float blackKeyWidth = keyWidth * 0.6f;
            float blackKeyHeight = rect.Height * 0.6f;
            float whiteKeyHeight = rect.Height;

            var note = new Note(NoteName.C, OctaveEnum.Octave1);
            for (int i = 0; i < numKeys; i++)
            {
                float x = rect.X + i * keyWidth;
                RectangleF keyRect = new RectangleF(x, rect.Y, keyWidth, whiteKeyHeight);

                // Draw white key
                g.FillRectangle(Brushes.White, keyRect);
                g.DrawRectangle(Pens.Black, keyRect.X, keyRect.Y, keyRect.Width, keyRect.Height);
                var region = new Region(keyRect);


                if (i % 7 != 2 && i % 7 != 6 && i < numKeys - 1)
                {
                    // Draw black key
                    float x1 = x + keyWidth - blackKeyWidth / 2;
                    float y1 = rect.Y;
                    RectangleF blackKeyRect = new RectangleF(x1, y1, blackKeyWidth, blackKeyHeight);
                    g.FillRectangle(Brushes.Black, blackKeyRect);
                    g.DrawRectangle(Pens.Black, blackKeyRect.X, blackKeyRect.Y, blackKeyRect.Width, blackKeyRect.Height);

                    var szHs = new SizeF(blackKeyRect.Width, blackKeyRect.Width);
                    var ptHs = new PointF(blackKeyRect.Location.X,
                        (blackKeyRect.Location.Y - blackKeyRect.Bottom) + blackKeyRect.Width);
                    var rcHs = new RectangleF(ptHs, szHs);
                    region = new Region(rcHs);
                }

                this.NoteRegions[note] = region;
                note++;
            }
        }

    }//class
}//ns

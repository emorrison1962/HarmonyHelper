using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        Dictionary<Note, Region> KeyRegions = new();
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
                    region = new Region(blackKeyRect);

                }

                this.KeyRegions[note] = region;
                note++;
            }
        }

    }//class
}//ns

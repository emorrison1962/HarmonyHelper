using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony.Rhythm;

namespace HarmonyHelperControls.WinForms
{
    public partial class Score : UserControl
    {
        const string TREBLE_CLEF = "\u0069";

        //E000
        //U+1D100–U+1D1FF

        public Score()
        {
            InitializeComponent();
        }

        private void Score_Paint(object sender, PaintEventArgs e)
        {
            this.DrawStaff(sender, e);
            this.DrawText(sender, e);
        }

        StaffGrid CreateStaffGrid(Point pt, int cx, TimeSignature ts)
        {
            var result = new StaffGrid(pt, cx, ts);
            return result;
        }
        void DrawStaff(object sender, PaintEventArgs e)
        {
            var staffGrid = this.CreateStaffGrid(e.ClipRectangle.Location, 
                e.ClipRectangle.Width, 
                new TimeSignature(4, 4));
            this.DrawStaffGrid(sender, e, staffGrid);

            using (var pen = new Pen(Color.Black, 2))
            {
                var x = e.ClipRectangle.Left;
                var cx = e.ClipRectangle.Width;
                var y = e.ClipRectangle.Top + 20;
                var cy = e.ClipRectangle.Height;

                var cxMin = x + 50;
                var cxMax = (cx - 50) - cxMin;
                var cyMin = 300;

                var cyLines = 15;

                const int MAX_STAFF_LINES = 5;
                for (int i = 0; i < MAX_STAFF_LINES; ++i)
                {
                    e.Graphics.DrawLine(pen,
                        new Point(cxMin, (i * cyLines) + cyMin),
                        new Point(cxMax, (i * cyLines) + cyMin));
                }

                var cyStaff = cyMin + (cyLines * (MAX_STAFF_LINES - 1));
                Debug.WriteLine((cyLines * (MAX_STAFF_LINES - 1)));

                const int MAX_MEASURES_PER_LINE = 8;
                var cxMeasure = (cxMax - cxMin) / MAX_MEASURES_PER_LINE + 1;
                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    e.Graphics.DrawLine(pen,
                        new Point(cxMin + (i * cxMeasure), cyMin),
                        new Point(cxMin + (i * cxMeasure), cyStaff));
                }
            }


            new object();
        }
        void DrawStaffGrid(object sender, PaintEventArgs e, StaffGrid staff)
        {
            staff.DrawStaff(sender, e);
            
            //e.Graphics.DrawRectangle(Pens.DarkRed, staff.StaffPrefixRectangle);
            //e.Graphics.DrawRectangles(Pens.DarkOrange, staff.MeasureGrid.Rectangles.ToArray());
            
        }

        private void DrawText(object sender, PaintEventArgs e)
        {
            using (var font = new Font("Petaluma", 50f, GraphicsUnit.Pixel))
            {
                //string str = TREBLE_CLEF;
                var brush = Brushes.Black;
                var pt = new Point(200, 200);
                //var pt = e.ClipRectangle.Location;
                //e.ClipRectangle.Width


                var str = "\u0069";
                //E000
                //U+1D100–U+1D1FF
                for (int i = 0xE000; i < 0xE0FF; ++i)
                {
                    str += $"\\u{i.ToString("X")} ";
                }
                //for (int i = 0x1D100; i < 0x1D1FF; ++i)
                //{
                //    str += $"\\u{i.ToString("X")}";
                //}

                new object();

                e.Graphics.DrawString(str, font, brush, pt);

            }
        }


    }//class
}//ns

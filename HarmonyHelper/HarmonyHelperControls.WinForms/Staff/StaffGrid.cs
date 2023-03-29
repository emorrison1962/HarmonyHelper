using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Rhythm;

namespace HarmonyHelperControls.WinForms
{
    public class StaffGrid
    {
        public const int MIN_STAFF_HEIGHT = 60;
        public RectangleF StaffPrefixRectangle { get; set; }
        public MeasureGrid MeasureGrid { get; set; }

        //E, G, B, D
        //F, A, C, E
        //clef, key, time


        public StaffGrid(Point location, int cxTotal, TimeSignature ts)
        {//| cxPrefix | m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 |
            var cx = cxTotal / 9;
            this.StaffPrefixRectangle = new RectangleF(location, new Size(cx, MIN_STAFF_HEIGHT));
            cxTotal -= cx;
            location.Offset(cx, 0);

            this.MeasureGrid = new MeasureGrid(location, cxTotal, ts);
        }

        public void DrawStaff(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Black, 2))
            {
                var left = e.ClipRectangle.Left;
                var cx = e.ClipRectangle.Width;
                var top = e.ClipRectangle.Top;
                var cy = top + MIN_STAFF_HEIGHT;

                var cyLineSpacing = 15;

                const int MAX_STAFF_LINES = 5;
                for (int i = 0; i < MAX_STAFF_LINES; ++i)
                {
                    e.Graphics.DrawLine(pen,
                        new Point(left, top + (i * cyLineSpacing)),
                        new Point(cx, top + (i * cyLineSpacing)));
                }

                const int MAX_MEASURES_PER_LINE = 8;
                var cxMeasure = (cx - left) / MAX_MEASURES_PER_LINE + 1;
                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    e.Graphics.DrawLine(pen,
                        new Point(left + (i * cxMeasure), top),
                        new Point(left + (i * cxMeasure), cy));
                }
            }


            new object();
        }

    }//class
}//ns

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Rhythm;

namespace HarmonyHelperControls.WinForms
{
    public class MeasureGrid
    {
        public List<RectangleF> Rectangles = new List<RectangleF>();
        public MeasureGrid(Point pt, int cxTotal, TimeSignature ts)
        {//| m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 | 
            var nRectangles = ts.BeatCount;
            var cx = cxTotal / nRectangles;
            for (int i = 0; i < nRectangles; ++i)
            {
                var rc = new RectangleF(pt, new Size(cx, StaffGrid.MIN_STAFF_HEIGHT));
                this.Rectangles.Add(rc);
                pt.Offset(cx, 0);
            }
        }
    }//class
}//ns

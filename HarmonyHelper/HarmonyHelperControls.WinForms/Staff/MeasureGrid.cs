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
        public MeasureGrid(PointF pt, float cxTotal, TimeSignature ts)
        {//| m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 | 
            var nRectangles = ts.BeatCount;
            var cx = cxTotal / nRectangles;

#warning FIXME
            for (int i = 0; i < nRectangles; ++i)
            {
                var rc = new RectangleF(pt, new SizeF(cx, 200));
                this.Rectangles.Add(rc);
            }
        }
    }//class
}//ns

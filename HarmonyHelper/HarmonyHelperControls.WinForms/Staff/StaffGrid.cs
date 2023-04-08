using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Rhythm;

namespace HarmonyHelperControls.WinForms
{
    public class StaffGrid
    {
        //public const int MIN_STAFF_HEIGHT = 60;
        public RectangleF StaffPrefixRectangle { get; set; }
        public MeasureGrid MeasureGrid { get; set; }

        //E, G, B, D
        //F, A, C, E
        //clef, key, time

        public FontContext FontContext { get; private set; }
        float LineSpacing { get; set; }
        public float BaseLine { get; private set; }

        public StaffGrid(FontContext fontMetrics, Point location, float cxTotal, TimeSignature ts)
        {//| cxPrefix | m1 | m2 | m3 | m4 | m5 | m6 | m7 | m8 |
            this.FontContext = fontMetrics;
            this.LineSpacing = fontMetrics.EmHeight / 2;
            this.BaseLine = fontMetrics.BaseLine;

            var ptBaseline = new PointF(location.X, this.BaseLine);
            var cx = cxTotal / 9;
            this.StaffPrefixRectangle = new RectangleF(ptBaseline, new SizeF(cx, fontMetrics.EmHeight));
            cxTotal -= FontContext.EmHeight;
            
            var pt = new PointF(location.X + cx, 0);
            this.MeasureGrid = new MeasureGrid(ptBaseline, cxTotal, ts);
        }

        RectangleF GetRectangle(RectangleF rc)
        {
            var x = rc.Location.X;
            var y = rc.Location.Y;// + this.FontContext.BaseLine;// + this.FontContext.EmHeight; 
            var cx = rc.Width;
            var cy = rc.Height;
            var result = new RectangleF(x, y, cx, cy);
            return result;
        }

        public void DrawStaffPrefix(PaintEventArgs pea)
        {
            var str = Runes.G_clef.ToString();
            var szStr = pea.Graphics.MeasureString(str, this.FontContext.Font);

            //var yOffset = this.FontContext.EmHeight / 4;
            //var cxNote = new SizeF(0, -((FontContext.BaseLine * 2) + yOffset * 2));
            //var qq = PointF.Add(this.Rectangle.Location, cxNote);

            pea.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //pea.Graphics.DrawString(str, this.FontContext.Font, Brushes.Black, qq);
            pea.Graphics.DrawString(str, this.FontContext.Font, Brushes.Black, this.Rectangle.Location);

        }

        RectangleF Rectangle { get; set; }
        public void DrawStaff(PaintEventArgs pea, RectangleF rawRect)
        {
            this.Rectangle = this.GetRectangle(rawRect);
            this.DrawStaffPrefix(pea);
            this.DrawNotes(pea);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            this.DrawDebugRectangle($"{MethodBase.GetCurrentMethod().Name}, rawRect", 
                pea,
                Brushes.Red,
                4,
                rawRect);
            this.DrawDebugRectangle($"{MethodBase.GetCurrentMethod().Name}, this.Rectangle",
                pea,
                Brushes.Blue,
                4,
                this.Rectangle);

#pragma warning restore CS8602 // Dereference of a possibly null reference.
            //using (var pen = new Pen(Brushes.Red, 4))
            //{
            //    rawRect.Width /= 2;
            //    pea.Graphics.DrawRectangle(pen, rawRect);
            //    pea.Graphics.FillRectangle(SystemBrushes.Control, rawRect);
            //    pea.Graphics.DrawString(,
            //        new Font("Courier New", 10), 
            //        Brushes.Black, 
            //        new PointF(rawRect.Location.X + 5, rawRect.Location.Y - 5));
            //}
            //using (var pen = new Pen(Brushes.Blue, 4))
            //{
            //    pea.Graphics.DrawRectangle(pen, this.Rectangle);
            //}


            using (var pen = new Pen(Color.Black, 2))
            {
                var left = this.Rectangle.Left;
                var cx = this.Rectangle.Width;
                var top = this.Rectangle.Top + this.FontContext.LineSpacing;
                var cy = this.Rectangle.Height;

                var cyLineSpacing = this.LineSpacing;

                const int MAX_STAFF_LINES = 5;
                for (int i = 0; i < MAX_STAFF_LINES; ++i)
                {
                    pea.Graphics.DrawLine(pen,
                        new PointF(left, top - (i * cyLineSpacing)),
                        new PointF(cx, top - (i * cyLineSpacing)));
                }

                const int MAX_MEASURES_PER_LINE = 4;
                var cxMeasure = (cx - left) / MAX_MEASURES_PER_LINE + 1;
                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    pea.Graphics.DrawLine(pen,
                        new PointF(left + (i * cxMeasure), top),
                        new PointF(left + (i * cxMeasure), top - (4 * cyLineSpacing)));
                }
            }


            new object();
        }

        private void DrawNotes(PaintEventArgs pea)
        {
            var pt = this.Rectangle.Location;
            var zz = this.FontContext.EmHeight / 4;
            pt.X += 80;
            for (int i = 0; i < 9; ++i)
            {
                var str = Runes.Black_notehead.ToString();
                pea.Graphics.DrawString(str,
                    this.FontContext.Font, Brushes.Black, pt);
                pt.X += 50;
                pt.Y -= (zz);
            }
        }

        void DrawDebugRectangle(string msg, PaintEventArgs pea, 
            Brush brush, int cxPen, RectangleF src)
        {
            using (var pen = new Pen(Brushes.Red, 4))
                using (var font = new Font("Courier New", 10))
            {
                //src.Width /= 2;
                pea.Graphics.DrawRectangle(pen, src);
                
                var msgSize = pea.Graphics.MeasureString(msg, font);
                var x = src.Width - msgSize.Width;
                var msgLocation = new PointF(x, src.Top);
                var msgRect = new RectangleF(msgLocation, msgSize);
                
                pea.Graphics.FillRectangle(SystemBrushes.Control, msgRect);
                pea.Graphics.DrawString($"{msg}",
                    font,
                    brush,
                    new PointF(msgRect.Location.X + 20, msgRect.Location.Y - 5));
            }
        }

    }//class
}//ns

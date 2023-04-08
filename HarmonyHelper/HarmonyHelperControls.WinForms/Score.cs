using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Eric.Morrison.Harmony.Rhythm;

using static System.Net.Mime.MediaTypeNames;

namespace HarmonyHelperControls.WinForms
{
    public partial class Score : UserControl
    {
        #region Properties
        string SelectedFontName { get { return "Bravura"; } }
        public Font LocalFont { get; set; }
        public FontContext FontContext { get; private set; }

        #endregion

        #region Construction
        public Score()
        {
            InitializeComponent();
#warning FIXME:
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        #endregion

        private void Score_Paint(object sender, PaintEventArgs pea)
        {
            using (this.LocalFont = new Font(this.SelectedFontName, 50))
            {
                this.FontContext = LocalFont.GetFontMetrics();
                this.DrawClientRect(pea);
                var rc = this.GetStaffRectangle(pea);
                this.DrawStaff(pea, rc);
                this.DrawText(pea, rc);
            }
        }

        StaffGrid CreateStaffGrid(Point pt, int cx, TimeSignature ts)
        {
            var result = new StaffGrid(this.FontContext, pt, cx, ts);
            return result;
        }

        public Rectangle GetStaffRectangle(PaintEventArgs pea)
        {
            Rectangle result = Rectangle.Empty;

            var pt = pea.ClipRectangle.Location;
            var width = pea.ClipRectangle.Width;

            var size = new Size(width, (int)this.FontContext.LineSpacing);
            result = new Rectangle(pt, size);

            //using (var pen = new Pen(Brushes.Magenta, 3))
            //{
            //    pea.Graphics.DrawRectangle(pen, result);
            //}

            return result;
        }

        [Conditional("DEBUG")]
        void DrawClientRect(PaintEventArgs pea)
        {
            pea.Graphics.DrawRectangle(Pens.Red, pea.ClipRectangle);
        }

        void DrawStaff(PaintEventArgs pea, Rectangle rc)
        {

            //var szStr = pea.Graphics.MeasureString(Runes.F_clef.ToString(), this.Font);

            var staffGrid = this.CreateStaffGrid(
                rc.Location,
                rc.Width,
                new TimeSignature(4, 4));
            this.DrawStaffGrid(pea, rc, staffGrid);

#if false
            using (var pen = new Pen(Color.Black, 2))
            {
                var x = rc.Left;
                var cx = rc.Width;
                var y = rc.Top + 20;
                var cy = rc.Height;

                var cxMin = x + 50;
                var cxMax = (cx - 50) - cxMin;
                var cyMin = 300;

                var cyLines = 15;

                const int MAX_STAFF_LINES = 5;
                for (int i = 0; i < MAX_STAFF_LINES; ++i)
                {
                    pea.Graphics.DrawLine(pen,
                        new Point(cxMin, (i * cyLines) + cyMin),
                        new Point(cxMax, (i * cyLines) + cyMin));
                }

                var cyStaff = cyMin + (cyLines * (MAX_STAFF_LINES - 1));
                Debug.WriteLine((cyLines * (MAX_STAFF_LINES - 1)));

                const int MAX_MEASURES_PER_LINE = 8;
                var cxMeasure = (cxMax - cxMin) / MAX_MEASURES_PER_LINE + 1;
                for (int i = 0; i <= MAX_MEASURES_PER_LINE; ++i)
                {
                    pea.Graphics.DrawLine(pen,
                        new Point(cxMin + (i * cxMeasure), cyMin),
                        new Point(cxMin + (i * cxMeasure), cyStaff));
                }
            }
#endif

            new object();
        }
        void DrawStaffGrid(PaintEventArgs pea, Rectangle rc, StaffGrid staff)
        {
            staff.DrawStaff(pea, rc);


            //e.Graphics.DrawRectangle(Pens.DarkRed, staff.StaffPrefixRectangle);
            //e.Graphics.DrawRectangles(Pens.DarkOrange, staff.MeasureGrid.Rectangles.ToArray());

        }

        private void DrawText(PaintEventArgs pea, Rectangle rc)
        {
            var brush = Brushes.Black;
            var pt = new PointF(rc.Location.X, rc.Location.Y);

            //var str = Runes.G_clef.ToString();
            //var szStr = pea.Graphics.MeasureString(str, this.LocalFont);
            //var zz = this.FontContext.EmHeight / 4;
            //var cxNote = new SizeF(0, - (2 * zz));//This places the treble clef in the correct spot.
            //pea.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //pea.Graphics.DrawString(str, this.LocalFont, Brushes.Black, PointF.Add(pt, cxNote));

            //var zz = this.FontContext.EmHeight / 4;
            //pt.X += 80;
            //for (int i = 0; i < 9; ++i)
            //{
            //    var str = Runes.Black_notehead.ToString();
            //    pea.Graphics.DrawString(str, 
            //        this.LocalFont, Brushes.Black, pt);
            //    pt.X += 50;
            //    pt.Y -= (zz);
            //}



            new object();
        }


    }//class

    public class FontContext
    {
        public float BaseLine { get; set; }
        public float EmHeight { get; set; } = 0;
        public float LineSpacing { get; set; } = 0;
        public float CellDescent { get; set; } = 0;
        public float CellAscent { get; set; } = 0;
        public Font Font { get; set; }
        public FontContext(Font font, float baseline, float emHeight, float lineSpacing, float cellDescent, float cellAscent)
        {
            Font= font;
            BaseLine = baseline;
            EmHeight = emHeight;
            LineSpacing = lineSpacing;
            CellDescent = cellDescent;
            CellAscent = cellAscent;
        }
    }


    public static class FontExtensions
    {
        static public FontContext GetFontMetrics(this Font font)
        {
            var cyLineSpacing = font.FontFamily.GetLineSpacing(FontStyle.Regular);
            var pxLineSpacing = font.Size * cyLineSpacing / font.FontFamily.GetEmHeight(FontStyle.Regular);

            var cyEm = font.FontFamily.GetEmHeight(FontStyle.Regular);
            var pxEmHeight = font.Size * cyEm / font.FontFamily.GetEmHeight(FontStyle.Regular);

            var cyDescent = font.FontFamily.GetCellDescent(FontStyle.Regular);
            var pxDescent = font.Size * cyDescent / font.FontFamily.GetEmHeight(FontStyle.Regular);

            var cyAscent = font.FontFamily.GetCellAscent(FontStyle.Regular);
            var pxAscent = font.Size * cyAscent / font.FontFamily.GetEmHeight(FontStyle.Regular);

            var yBaseline = cyDescent - cyEm;
            var pxBaseline = font.Size * yBaseline / font.FontFamily.GetEmHeight(FontStyle.Regular);

            var result = new FontContext(font, pxBaseline, pxEmHeight, pxLineSpacing, pxDescent, pxAscent);
            return result;
        }
    }//class

}//ns



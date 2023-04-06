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
        public Score()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Score_Paint(object sender, PaintEventArgs pea)
        {
            this.DrawClientRect(pea);
            var rc = this.GetStaffRectangle(pea);
            this.DrawStaff(pea, rc);
            this.DrawText(pea, rc);
        }

        StaffGrid CreateStaffGrid(Point pt, int cx, TimeSignature ts)
        {
            var result = new StaffGrid(pt, cx, ts);
            return result;
        }

        string SelectedFont { get { return "Bravura"; } }

        override public Font Font { get { return new Font(this.SelectedFont, 40); } }

        public Rectangle GetStaffRectangle(PaintEventArgs pea)
        {
            Rectangle result = Rectangle.Empty;
            using (var font = this.Font)
            {
                var cyLineSpacing = font.FontFamily.GetLineSpacing(FontStyle.Regular);
                var pxLineSpacing = font.Size * cyLineSpacing / font.FontFamily.GetEmHeight(FontStyle.Regular);

                var cyEm = font.FontFamily.GetEmHeight(FontStyle.Regular);
                var pxEm = font.Size * cyEm / font.FontFamily.GetEmHeight(FontStyle.Regular);

                var cyDescent = font.FontFamily.GetCellDescent(FontStyle.Regular);
                var pxDescent = font.Size * cyDescent / font.FontFamily.GetEmHeight(FontStyle.Regular);

                var cyAscent = font.FontFamily.GetCellAscent(FontStyle.Regular);
                var pxAscent = font.Size * cyAscent / font.FontFamily.GetEmHeight(FontStyle.Regular);

                var cyxTotal = pxEm + pxDescent+ pxAscent;

                var pt = pea.ClipRectangle.Location;
                var width = pea.ClipRectangle.Width;

                var size = new Size(width, (int)pxLineSpacing);
                result = new Rectangle(pt, size);

                using (var pen = new Pen(Brushes.Magenta, 3))
                {
                    pea.Graphics.DrawRectangle(pen, result);
                }
            }
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

            var staffGrid = this.CreateStaffGrid(rc.Location, 
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
            using (var font = this.Font)
            {
                ///////////////////////////////////////////////////
                var cyLineSpacing = font.FontFamily.GetLineSpacing(FontStyle.Regular);
                var pxLineSpacing = font.Size * cyLineSpacing / font.FontFamily.GetEmHeight(FontStyle.Regular);

                var cyEm = font.FontFamily.GetEmHeight(FontStyle.Regular);
                var pxEm = font.Size * cyEm / font.FontFamily.GetEmHeight(FontStyle.Regular);

                var cyDescent = font.FontFamily.GetCellDescent(FontStyle.Regular);
                var pxDescent = font.Size * cyDescent / font.FontFamily.GetEmHeight(FontStyle.Regular);

                var cyAscent = font.FontFamily.GetCellAscent(FontStyle.Regular);
                var pxAscent = font.Size * cyAscent / font.FontFamily.GetEmHeight(FontStyle.Regular);
                ///////////////////////////////////////////////////


                var brush = Brushes.Black;
                //var pt = rc.Location;
                var pt = new Point(rc.Location.X, rc.Location.Y + (int)pxAscent);

                var str = Runes.F_clef.ToString();
                str += (Runes.Eighth_note_quaver_stem_up)+(Runes.Black_notehead).ToString();


                var sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Near;

                pea.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                pea.Graphics.DrawString(str, font, Brushes.Black, pt, sf); //System.Drawing.StringFormat.GenericTypographic);

                pt.Y += font.Height;
                pea.Graphics.DrawString(str, font, Brushes.Black, pt, sf); 

                using (var pen = new Pen(Brushes.LimeGreen, 7))
                {
                    pea.Graphics.DrawRectangle(pen, rc);
                }

                new object();
            }
        }


    }//class
}//ns

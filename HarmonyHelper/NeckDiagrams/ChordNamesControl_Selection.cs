using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeckDiagrams.Controls
{
    public class MouseDragContext
    {
        public bool IsDragging { get; set; }
        public Point MouseDownPoint { get; set; }
        public Point MouseUpPoint { get; set; }
        public Point CurrentPoint { get; set; }
        public Rectangle CurrentRect { get; set; }
        public Point LastPoint { get; set; }
        public Rectangle LastRect { get; set; }

        public MouseDragContext(Point beginDrag)
        {
            MouseDownPoint = beginDrag;
            this.IsDragging = true;
        }

        public void SetCurrentPoint(Point currentPoint)
        {
            if (null != this.LastPoint)
            {
                var x = Math.Min(this.MouseDownPoint.X, currentPoint.X);
                var y = Math.Max(this.MouseDownPoint.Y, currentPoint.Y);
                
                var cxLast = Math.Min(
                    this.LastPoint.X - currentPoint.X,
                    currentPoint.X - this.LastPoint.X);
                var cyLast = Math.Min(
                    this.LastPoint.Y - currentPoint.Y,
                    currentPoint.Y - this.LastPoint.Y);


                //var x = this.MouseDownPoint.X;
                //var y = this.MouseDownPoint.Y;
                //var cxLast = this.LastPoint.X - currentPoint.X;
                //var cyLast = this.LastPoint.Y - currentPoint.Y;

                this.LastRect = new Rectangle(x, y, cxLast, cyLast);

                var cxCurrent = this.MouseDownPoint.X - currentPoint.X;
                var cyCurrent = this.MouseDownPoint.Y - currentPoint.Y;
                this.CurrentRect = new Rectangle(x, y, cxCurrent, cyCurrent);

            }


            this.LastPoint = this.CurrentPoint;
            this.CurrentPoint = currentPoint;
            //var size = new Size(end.X - start.X, end.Y - start.Y);
            this.LastRect = this.CurrentRect;


        }
    }
    partial class ChordNamesControl
    {
        MouseDragContext MouseDragContext { get; set; }
        private void ChordNamesControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseDragContext = new MouseDragContext(e.Location);
            this.Capture = true;
        }

        private void ChordNamesControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (null != this.MouseDragContext && this.MouseDragContext.IsDragging)
            {
                this.MouseDragContext.SetCurrentPoint(e.Location);
                this.DrawSelectionRectangle();
            }
        }

        void DrawSelectionRectangle()
        {
            using (var graphics = this._chordNamesTablePanel.CreateGraphics())
            {
                this._chordNamesTablePanel
                    .Invalidate(this.MouseDragContext.LastRect, true);

                // Create pen.
                Pen blackPen = new Pen(Color.Black, 3);

                // Create rectangle.
                

                //Debug.WriteLine($"{start}: {size}");

                // Draw rectangle to screen.
                graphics.DrawRectangle(blackPen,
                    this.MouseDragContext.CurrentRect);
                //graphics.FillRectangle(Brushes.Red, rect);
            }
        }

        private void ChordNamesControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            this.MouseIsDragging = false;
            //this.DragBeginPoint = e.Location;
            this.MouseDragContext = null;
        }
    }
}

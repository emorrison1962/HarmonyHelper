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

        public MouseDragContext()
        {
        }

        public void BeginDrag(Point beginDrag)
        {
            MouseDownPoint = beginDrag;
            this.IsDragging = true;
        }
        public void EndDrag()
        {
            this.IsDragging = false;
            this.MouseDownPoint = Point.Empty;
            this.MouseUpPoint = Point.Empty;
            this.CurrentPoint = Point.Empty;
            this.LastPoint = Point.Empty;
            this.CurrentRect = Rectangle.Empty;
            this.LastRect = Rectangle.Empty;
        }


    public void SetCurrentPoint(Point currentPoint)
        {
            this.LastPoint = this.CurrentPoint;
            this.CurrentPoint = currentPoint;
            if (null != this.LastPoint)
            {
                this.LastRect = this.GetRectangle(this.MouseDownPoint, this.LastPoint);
                this.CurrentRect = this.GetRectangle(this.MouseDownPoint, currentPoint);
            }
        }

        Rectangle GetRectangle(Point a, Point b)
        {
            int x = Math.Min(a.X, b.X);
            int y = Math.Min(a.Y, b.Y);
            int w = Math.Abs(a.X - b.X);
            int h = Math.Abs(a.Y - b.Y);
            var result = new Rectangle(x, y, w, h);
            return result;
        }

        public override string ToString()
        {
            return $"MouseDownPoint: {MouseDownPoint}, CurrentPoint: {CurrentPoint}, LastPoint: {LastPoint}, MouseUpPoint: {MouseUpPoint}, CurrentRect: {CurrentRect}, LastRect: {LastRect}";
        }
    }
    partial class ChordNamesControl
    {
        MouseDragContext MouseDragContext { get; set; }
        private void ChordNamesControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseDragContext.BeginDrag(e.Location);
            this.Capture = true;
        }

        private void ChordNamesControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (null != this.MouseDragContext && this.MouseDragContext.IsDragging)
            {
                this.TopLevelControl.Text = this.MouseDragContext.ToString();
                this.MouseDragContext.SetCurrentPoint(e.Location);
                this.Invalidate(true);
            }
        }

        private void ChordNamesControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            this.MouseIsDragging = false;
            this.MouseDragContext.EndDrag();
        }

        private void _chordNamesTablePanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.MouseDragContext.IsDragging)
            {
                this.DrawSelectionRectangle(e.Graphics);
            }
        }
        "
Pen pen = new Pen(Color.SlateBlue, 0.5f);

        graphics.PageUnit = GraphicsUnit.Pixel;        
            "
        void DrawSelectionRectangle(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Black, 3))
            {
                //this._chordNamesTablePanel
                //    .Invalidate(this.MouseDragContext.LastRect, true);
                //this._chordNamesTablePanel.Update();

                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawRectangle(pen,
                    this.MouseDragContext.CurrentRect);
            }
        }

    }//class
}//ns

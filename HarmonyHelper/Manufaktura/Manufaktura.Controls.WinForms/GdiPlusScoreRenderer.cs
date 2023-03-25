/*
 * Copyright 2018 Manufaktura Programów Jacek Salamon http://musicengravingcontrols.com/
 * MIT LICENCE
 
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using Manufaktura.Controls.Audio;
using Manufaktura.Controls.Model;
using Manufaktura.Controls.Model.Fonts;
using Manufaktura.Controls.Rendering;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Manufaktura.Controls.WinForms
{
    public class GdiPlusScoreRenderer : ScoreRenderer<Graphics>
    {
        private Dictionary<Primitives.Pen, Pen> _penCache = new Dictionary<Primitives.Pen, Pen>();

        public GdiPlusScoreRenderer(Graphics canvas) : base(canvas, new GdiPlusScoreRendererSettings())
        {
        }

        public GdiPlusScoreRenderer(Graphics canvas, GdiPlusScoreRendererSettings settings) : base(canvas, settings)
        {
        }

        public override bool CanDrawCharacterInBounds => true;
        public GdiPlusScoreRendererSettings TypedSettings => Settings as GdiPlusScoreRendererSettings;

        public override void DrawArc(Primitives.Rectangle rect, double startAngle, double sweepAngle, Primitives.Pen pen, MusicalSymbol owner)
        {
            if (!EnsureProperPage(owner)) return;
            if (Settings.RenderingMode != ScoreRenderingModes.Panorama)
            {
                rect = rect.Translate(CurrentScore.DefaultPageSettings);
            }

            Canvas.DrawArc(ConvertPen(pen), new RectangleF((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height), (float)startAngle, (float)sweepAngle);
        }

        public override void DrawBezier(Primitives.Point p1, Primitives.Point p2, Primitives.Point p3, Primitives.Point p4, Primitives.Pen pen, MusicalSymbol owner)
        {
            if (!EnsureProperPage(owner)) return;
            if (Settings.RenderingMode != ScoreRenderingModes.Panorama)
            {
                p1 = p1.Translate(CurrentScore.DefaultPageSettings);
                p2 = p2.Translate(CurrentScore.DefaultPageSettings);
                p3 = p3.Translate(CurrentScore.DefaultPageSettings);
                p4 = p4.Translate(CurrentScore.DefaultPageSettings);
            }

            Canvas.DrawBezier(ConvertPen(pen), new PointF((float)p1.X, (float)p1.Y), new PointF((float)p2.X, (float)p2.Y), new PointF((float)p3.X, (float)p3.Y), new PointF((float)p4.X, (float)p4.Y));
        }

        public override void DrawCharacterInBounds(char character, MusicFontStyles fontStyle, Primitives.Point location, Primitives.Size size, Primitives.Color color, MusicalSymbol owner)
        {
            if (!EnsureProperPage(owner)) return;
            if (Settings.RenderingMode != ScoreRenderingModes.Panorama)
                location = location.Translate(CurrentScore.DefaultPageSettings);

            var font = TypedSettings.GetFont(fontStyle);
            var path = new GraphicsPath();
            path.AddString(character.ToString(), font.FontFamily, (int)font.Style, Canvas.DpiY * font.Size / 72, new Point(0, 0), new StringFormat());
            var matrix = new Matrix();
            var matrix2 = new Matrix();
            var pathBounds = path.GetBounds();
            var scaleX = (float)size.Width / pathBounds.Width;
            var scaleY = (float)size.Height / pathBounds.Height;
            matrix2.Translate((float)location.X - (float)LinespacesToPixels(2.5), (float)location.Y - (float)LinespacesToPixels(2.5));  //TODO: Sprawdzić czemu się źle przesuwa i usunąć linespacestopixels
            matrix.Scale(scaleX, scaleY);
            path.Transform(matrix);
            path.Transform(matrix2);
            Canvas.DrawPath(new Pen(ConvertColor(color)), path);
            Canvas.FillPath(new SolidBrush(ConvertColor(color)), path);
        }

        public override void DrawLine(Primitives.Point startPoint, Primitives.Point endPoint, Primitives.Pen pen, MusicalSymbol owner)
        {
            if (!EnsureProperPage(owner)) return;
            if (Settings.RenderingMode != ScoreRenderingModes.Panorama)
            {
                startPoint = startPoint.Translate(CurrentScore.DefaultPageSettings);
                endPoint = endPoint.Translate(CurrentScore.DefaultPageSettings);
            }

            Canvas.DrawLine(ConvertPen(pen), new PointF((float)startPoint.X, (float)startPoint.Y), new PointF((float)endPoint.X, (float)endPoint.Y));
        }

        public override void DrawString(string text, MusicFontStyles fontStyle, Primitives.Point location, Primitives.Color color, MusicalSymbol owner)
        {
            if (!EnsureProperPage(owner)) return;
            if (Settings.RenderingMode != ScoreRenderingModes.Panorama)
            {
                location = location.Translate(CurrentScore.DefaultPageSettings);
            }

            var font = TypedSettings.GetFont(fontStyle);
            var baselineDesignUnits = font.FontFamily.GetCellAscent(font.Style);
            var baselinePixels = (baselineDesignUnits * font.Size) / font.FontFamily.GetEmHeight(font.Style);
            Canvas.DrawString(text, font, new SolidBrush(ConvertColor(color)), new PointF((float)location.X - 4, (float)location.Y - baselinePixels));
        }

        protected override void DrawPlaybackCursor(PlaybackCursorPosition position, Primitives.Point start, Primitives.Point end)
        {
        }

        private Color ConvertColor(Primitives.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private Pen ConvertPen(Primitives.Pen pen)
        {
            Pen gdiPen;
            if (_penCache.ContainsKey(pen)) gdiPen = _penCache[pen];
            else
            {
                gdiPen = new Pen(new SolidBrush(ConvertColor(pen.Color)), (float)pen.Thickness);
                _penCache.Add(pen, gdiPen);
            }
            return gdiPen;
        }
    }
}
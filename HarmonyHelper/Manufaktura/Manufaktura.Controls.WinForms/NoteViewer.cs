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

using Manufaktura.Controls.Model.Fonts;
using Manufaktura.Controls.Rendering;
using System.Drawing;
using System.Windows.Forms;

namespace Manufaktura.Controls.WinForms
{
    public partial class NoteViewer : Control
    {
        private readonly GdiPlusScoreRendererSettings rendererSettings = new GdiPlusScoreRendererSettings();
        public Model.Score DataSource { get; set; }
        public ScoreRenderingModes RenderingMode { get; set; } = ScoreRenderingModes.AllPages;
        public GdiPlusScoreRendererSettings Settings => rendererSettings;

        protected override bool DoubleBuffered
        {
            get
            {
                return true;    //Important for performance
            }
            set
            {
                //Do nothing
            }
        }

        public void LoadDefaultFont() => rendererSettings.SetPolihymniaFont();

        public void LoadDefaultFontFromPath(string fontPath)
        {
            rendererSettings.SetPolihymniaFontFromPath(fontPath);
        }

        public void SetFont(string fontName, FontProfile musicFontProfile)
        {
            rendererSettings.MusicFontProfile = musicFontProfile;
            foreach (var size in musicFontProfile.FontSizes)
                rendererSettings.SetFont(size.Key, fontName, (float)size.Value);
        }

        public void SetFontFromPath(string fontPath, FontProfile musicFontProfile)
        {
            rendererSettings.MusicFontProfile = musicFontProfile;
            foreach (var size in musicFontProfile.FontSizes)
                rendererSettings.SetFontFromPath(size.Key, fontPath, (float)size.Value);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (DataSource == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            GdiPlusScoreRenderer renderer = new GdiPlusScoreRenderer(e.Graphics, rendererSettings);
            renderer.Settings.PageWidth = Width;
            renderer.Settings.RenderingMode = RenderingMode;
            renderer.Render(DataSource);
        }
    }
}
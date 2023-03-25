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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace Manufaktura.Controls.WinForms
{
    public class GdiPlusScoreRendererSettings : ScoreRendererSettings
    {
        private Dictionary<MusicFontStyles, Font> defaultFonts = new Dictionary<MusicFontStyles, Font>()
            {
                {MusicFontStyles.MusicFont, new Font("Polihymnia", 27.5f, GraphicsUnit.Pixel)},
                {MusicFontStyles.GraceNoteFont, new Font("Polihymnia", 20, GraphicsUnit.Pixel)},
                {MusicFontStyles.StaffFont, new Font("Polihymnia", 30.5f, GraphicsUnit.Pixel)},
                {MusicFontStyles.LyricsFont, new Font("Times New Roman", 11, GraphicsUnit.Pixel)},
                {MusicFontStyles.DirectionFont, new Font("Microsoft Sans Serif", 11, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Pixel)},
                {MusicFontStyles.TimeSignatureFont, new Font("Microsoft Sans Serif", 14.5f, FontStyle.Bold, GraphicsUnit.Pixel)}
            };

        private Dictionary<MusicFontStyles, Font> fonts = new Dictionary<MusicFontStyles, Font>()
            {
                {MusicFontStyles.MusicFont, new Font("Polihymnia", 27.5f, GraphicsUnit.Pixel)},
                {MusicFontStyles.GraceNoteFont, new Font("Polihymnia", 20, GraphicsUnit.Pixel)},
                {MusicFontStyles.StaffFont, new Font("Polihymnia", 30.5f, GraphicsUnit.Pixel)},
                {MusicFontStyles.LyricsFont, new Font("Times New Roman", 11, GraphicsUnit.Pixel)},
                {MusicFontStyles.DirectionFont, new Font("Microsoft Sans Serif", 11, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Pixel)},
                {MusicFontStyles.TimeSignatureFont, new Font("Microsoft Sans Serif", 14.5f, FontStyle.Bold, GraphicsUnit.Pixel)}
            };

        private Dictionary<MusicFontStyles, PrivateFontCollection> fontCollections = new Dictionary<MusicFontStyles, PrivateFontCollection>();

        public GdiPlusScoreRendererSettings()
        {
        }

        public Font GetFont(MusicFontStyles style)
        {
            return fonts[style];
        }

        public void SetFont(MusicFontStyles style, string fontName, float fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            fonts[style] = new Font(fontName, fontSize, fontStyle, GraphicsUnit.Pixel);
        }

        public void SetFont(MusicFontStyles style, FontFamily family, float fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            fonts[style] = new Font(family, fontSize, fontStyle, GraphicsUnit.Pixel);
        }

        public void SetFontFromPath(MusicFontStyles style, string fontPath, float fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            var privateFonts = new PrivateFontCollection();
            if (fontCollections.ContainsKey(style))
            {
                fontCollections[style].Dispose();
                fontCollections[style] = privateFonts;
            }
            else fontCollections.Add(style, privateFonts);

            privateFonts.AddFontFile(fontPath);
            SetFont(style, privateFonts.Families[0], fontSize, fontStyle);
        }

        public override void SetPolihymniaFont()
        {
            base.SetPolihymniaFont();

            fonts[MusicFontStyles.MusicFont] = defaultFonts[MusicFontStyles.MusicFont];
            fonts[MusicFontStyles.GraceNoteFont] = defaultFonts[MusicFontStyles.GraceNoteFont];
            fonts[MusicFontStyles.StaffFont] = defaultFonts[MusicFontStyles.StaffFont];
        }

        public void SetPolihymniaFontFromPath(string fontPath)
        {
            base.SetPolihymniaFont();
            foreach (var fontStyle in new[] { MusicFontStyles.MusicFont, MusicFontStyles.GraceNoteFont, MusicFontStyles.StaffFont })
            {
                var defaultFont = defaultFonts[fontStyle];
                SetFontFromPath(fontStyle, fontPath, defaultFont.Size, defaultFont.Style);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelperControls.WinForms.Domain
{
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
            Font = font;
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

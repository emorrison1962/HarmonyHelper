using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Manufaktura.Controls.Model.Fonts;

namespace NeckDiagrams.Feature_Controls
{
    public partial class ScoreControl_Scratchpad : UserControl
    {
        public ScoreControl_Scratchpad()
        {
            InitializeComponent();
            this.foo();
        }

        void foo()
        {
            var str = string.Empty;
            //E000
            //U+1D100–U+1D1FF
            //for (int i = 0x0; i < 0x69; ++i)
            //{
            //    str += $"\\u{i.ToString("X4")} ";
            //}
            //for (int i = 0xE000; i < 0xE0FF; ++i)
            //{
            //    str += $"\\u{i.ToString("X4")} ";
            //}

            //var mf = new PolihymniaFont();
            for (int i = 0xE010, ndx = 0; i < 0xE024; ++i, ++ndx)
            {//"U+F52C"
                str += $"\\u{i.ToString("X4")} ";

                var r1 = new Rune(i);

                var array = new char[100];
                var arraySpan = new Span<char>(array);
                var count = r1.EncodeToUtf16(arraySpan);
                if (Rune.TryGetRuneAt(str, ndx, out var r2))
                {
                    new object();
                }

            }


            //for (int i = 0x1D100; i < 0x1D1FF; ++i)
            //{
            //    str += $"\\u{i.ToString("X5")} ";
            //}

            var font = new Font("Petaluma Script", 20);
            //var font = new Font("Polihymnia", 40);
            

            this._rtb.Font = font; 
            this._rtb.Text = str;
            new object();
        }



    }//class
}//ns

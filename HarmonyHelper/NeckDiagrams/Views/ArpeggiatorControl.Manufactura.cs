using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Manufaktura.Controls.Audio;
using Manufaktura.Controls.Linq;
using Manufaktura.Controls.Parser.MusicXml;
using Manufaktura.Controls.WinForms;

namespace NeckDiagrams.Controls
{
    public partial class ArpeggiatorControl
    {
        void PopulateNoteViewer(XDocument doc)
        {
            var settings = _noteViewer.Settings;
            var sw = Stopwatch.StartNew();
            var score = doc.ToScore(new MusicXmlNormalizer());

            //score.FirstStaff.Height = 400;
            //foreach (var measure in score.FirstStaff.Measures)
            //{
            //	measure.Width = 400;
            //}

            _noteViewer.DataSource = score;
            _noteViewer.Refresh();
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);

        }
    }//class
}//ns

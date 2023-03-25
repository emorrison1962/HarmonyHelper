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
		void PopulateNoteViwer(XDocument doc)
		{
			var sw = Stopwatch.StartNew();
			var score = doc.ToScore(new MusicXmlNormalizer());
            _noteViewer.DataSource = score;
            _noteViewer.Refresh();
			sw.Stop();
			Debug.WriteLine(sw.ElapsedMilliseconds);

        }
    }//class
}//ns

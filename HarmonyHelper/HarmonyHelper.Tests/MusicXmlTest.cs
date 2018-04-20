using Eric.Morrison.Harmony.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony
{
	[TestClass]
	public class MusicXmlTest
	{
		class XmlContext
		{
			public int MeasureNumber = 0;
			public XDocument Document;
		}

		class LogContext
		{
			//public readonly int BARS_PER_LINE = 2;
			public readonly int BARS_PER_LINE = 1;
			public int chordCount = 0;
		}

		XmlContext XmlCtx = new XmlContext();
		LogContext LogCtx = new LogContext();

		[TestMethod()]
		public void TheChickenTest()
		{
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.SixthPosition);
			var chordFormula = ChordFormulaCatalog.Bb7;
			var chord = new Chord(chordFormula, noteRange);
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { chord };
			{
				chords.Add(new Chord(ChordFormulaCatalog.Bb7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.Bb7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.Bb7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.Eb7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.Eb7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.D7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.G7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.C7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.C7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.C7, noteRange));
				chords.Add(new Chord(ChordFormulaCatalog.C7, noteRange));
			}


			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);

			this.RegisterMusicXmlObservers(arpeggiator);

			arpeggiator.Arpeggiate();

			new object();
		}

		[TestMethod()]
		public void TheCycle_12Frets_Test()
		{
			var noteRange = new NoteRange(
				new Note(NoteName.B, OctaveEnum.Octave0),
				new Note(NoteName.G, OctaveEnum.Octave3));

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
			ChordTypesEnum chordType = ChordTypesEnum.None;
			const int CYCLE_MAX = 11;
			for (int i = 0; i <= CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.G;
					key = KeySignature.CMajor;
					chordType = ChordTypesEnum.Dominant7th;
				}
				else
				{
					chordType = ChordTypesEnum.Dominant7th;
					key = key + IntervalsEnum.Perfect4th;
					root = root + new IntervalContext(key, IntervalsEnum.Perfect4th);
				}

				var formula = ChordFormulaFactory.Create(root, chordType, key);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);
			}


			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversal,
				noteRange, 4, startingNote, true);

			this.RegisterMusicXmlObservers(arpeggiator);

			arpeggiator.Arpeggiate();

			new object();
		}

		void RegisterMusicXmlObservers(Arpeggiator arpeggiator)
		{
			arpeggiator.ArpeggiationContextChanged += Ctx_NoOpObserver;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Log_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;
		}


		private void Ctx_Starting(object sender, Arpeggiator e)
		{
			this.Log_Starting(sender, e);
			this.XML_Starting(sender, e);
		}
		private void Ctx_ChordChanged(object sender, Arpeggiator ctx)
		{
			this.Log_ChordChanged(sender, ctx);
			this.XML_ChordChanged(sender, ctx);
		}
		private void Ctx_CurrentNoteChanged(object sender, Arpeggiator ctx)
		{
			this.Log_CurrentNoteChanged(sender, ctx);
			this.XML_CurrentNoteChanged(sender, ctx);
		}
		private void Ctx_Ending(object sender, Arpeggiator e)
		{
			this.Log_Ending(sender, e);
			this.XML_Ending(sender, e);
		}
		private void Ctx_NoOpObserver(object sender, Arpeggiator ctx)
		{ }



		private void Log_Ending(object sender, Arpeggiator e)
		{
			Debug.WriteLine("||");
		}

		private void Log_Starting(object sender, Arpeggiator e)
		{
			Debug.Write("|");
		}

		private void Log_CurrentNoteChanged(object sender, Arpeggiator ctx)
		{
			var function = ctx.CurrentChord.Formula.GetChordToneFunction(ctx.CurrentNote.NoteName);
			var functionStr = $"({function.ToStringEx()})";
			if (functionStr != "(m7)" && functionStr != "(△3)")
				functionStr = "    ";

			var noteStr = string.Empty;
			noteStr = $"{ctx.CurrentNote.ToString()}{(int)ctx.CurrentNote.Octave}";
			noteStr = $"{noteStr,-9}";
			noteStr = $"{noteStr}{g_direction}{functionStr}";
			//if (g_directionChanged)
			//{
			//	noteStr = ctx.CurrentNote.ToString();
			//	noteStr = string.Format("{0}", noteStr);
			//	noteStr += string.Format("({1}){0,-3}", (int)ctx.CurrentNote.Octave, functionStr);
			//}
			//else 
			//{
			//	noteStr = $"{"."} {"",-3}";
			//}

			//if (functionStr != "m7" && functionStr != "△3")
			//{// print spaces
			//	noteStr = $"{" . "} {" ", 3}";
			//}

			Debug.Write(noteStr);
			g_directionChanged = false;
		}
		bool g_directionChanged = false;
		private void Log_DirectionChanged(object sender, Arpeggiator ctx)
		{
			const string ASC = "˄";
			const string DESC = "˅";

			var direction = ctx.Direction.HasFlag(DirectionEnum.Ascending) ? ASC : DESC;
			Debug.Write(direction);
			g_directionChanged = true;
			g_direction = direction;
		}
		string g_direction = string.Empty;

		private void Log_ChordChanged(object sender, Arpeggiator ctx)
		{
			if (LogCtx.chordCount > 0 && LogCtx.chordCount % LogCtx.BARS_PER_LINE == 0)
				Debug.WriteLine(" |");
			Debug.Write(string.Format(" | ({0}) ", ctx.CurrentChord.Name));
			++LogCtx.chordCount;
		}





		private void XML_Starting(object sender, Arpeggiator e)
		{
			string fileContent = Resources.MusicXML_TEMPLATE_02;
			XmlCtx.Document = XDocument.Parse(fileContent);
			new object();
		}
		private void XML_ChordChanged(object sender, Arpeggiator ctx)
		{
			++XmlCtx.MeasureNumber;
			this.CreateMeasure(ctx.CurrentChord.Root.NoteName.ToString());
		}
		private void XML_Ending(object sender, Arpeggiator e)
		{
			XmlCtx.Document.Save(@"c:\temp\_xml.xml");
			new object();
		}
		private void XML_CurrentNoteChanged(object sender, Arpeggiator ctx)
		{
			#region FORMAT
			const string FORMAT = @"
	  <note>
		<pitch>
		  <step>{0}</step>
		  {1}
		  <octave>{2}</octave>
		</pitch>
		<duration>1</duration>
		<voice>1</voice>
		<type>quarter</type>
		<staff>{3}</staff>
	  </note>";
			#endregion

			var octave = 2 + (int)ctx.CurrentNote.Octave;
			var note = ctx.CurrentNote.NoteName.ToString();

			var alter = string.Empty;
			if (note.EndsWith(FLAT))
			{
				alter = "<alter>-1</alter>";
			}
			else if (note.EndsWith(SHARP))
			{
				alter = "<alter>1</alter>";
			}
			note = note.Replace(FLAT, string.Empty);
			note = note.Replace(SHARP, string.Empty);

			var splitPoint = new Note(NoteName.C, OctaveEnum.Octave2);
			int staff = 1;
			if (splitPoint > ctx.CurrentNote)
			{
				staff = 2;
			}

			var xml = string.Format(FORMAT, note, alter, octave, staff);
			var elem = XElement.Parse(xml);

			var measure = XmlCtx.Document.Root.Descendants("measure").Last();
			//XElement part = null;
			//var measure = part.Descendants("measure").Last();
			measure.Add(elem);
			new object();
		}


		const string FLAT = "♭";
		const string SHARP = "♯";


		private void CreateMeasure(string chordRoot)
		{
			var rootAlter = string.Empty;
			if (chordRoot.EndsWith(FLAT))
				rootAlter = "<root-alter>-1</root-alter>";
			if (chordRoot.EndsWith(SHARP))
				rootAlter = "<root-alter>1</root-alter>";

			chordRoot = chordRoot.Replace(FLAT, string.Empty);
			chordRoot = chordRoot.Replace(SHARP, string.Empty);

			var print = string.Empty;
			if (1 == XmlCtx.MeasureNumber)
			{

				print = @"
<print>
  <system-layout>
	<system-margins>
	  <left-margin>21.00</left-margin>
	  <right-margin>0.00</right-margin>
	</system-margins>
	<top-system-distance>195.00</top-system-distance>
  </system-layout>
  <staff-layout number=""2"">
	<staff-distance>65.00</staff-distance>
  </staff-layout>
</print>
<attributes>
  <divisions>1</divisions>
  <key>
	<fifths>0</fifths>
  </key>
  <staves>2</staves>
  <clef number = ""1"">
	 <sign>G</sign>
	 <line>2</line>
   </clef>
   <clef number = ""2"">
	  <sign>F</sign>
	  <line>4</line>
	</clef>
  </attributes>
  ";


			}

			#region MEASURE_XML
			const string MEASURE_XML = @"
	<measure number=""{0}"">
{3}
		<harmony print-frame=""no"">
		<root>
		  <root-step>{1}</root-step>
		  {2}
		</root>
		<kind text = ""7"" >dominant</kind>
	  </harmony>
	</measure>";
			#endregion
			var xml = string.Format(MEASURE_XML, XmlCtx.MeasureNumber, chordRoot, rootAlter, print);

			//Debug.WriteLine(xml);
			var measureElem = XElement.Parse(xml);


			var elems = XmlCtx.Document.Root.Descendants("part");
			foreach (var part in elems)
			{
				part.Add(measureElem);
			}
			new object();
		}


	}//class
}//ns

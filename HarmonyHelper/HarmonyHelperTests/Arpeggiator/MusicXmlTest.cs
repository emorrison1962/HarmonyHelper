﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.MusicXml;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arpeggiator_Tests
{
	[TestClass]
	public class ArpeggiatorMusicXmlTest
	{
		class XmlContext
		{
			public int MeasureNumber = 0;
			public XDocument Document { get; set; } = new XDocument();
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
			var chordFormula = ChordFormula.BbDominant7;
			var chord = new Chord(chordFormula, noteRange);
			var startingNote = new Note(chordFormula.Root, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var chords = new List<Chord>() { chord };
			{
				chords.Add(new Chord(ChordFormula.BbDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.BbDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.BbDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.EbDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.EbDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.DDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.GDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.CDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.CDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.CDominant7, noteRange));
				chords.Add(new Chord(ChordFormula.CDominant7, noteRange));
			}


			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);


            this.Part = new MusicXmlPart(PartTypeEnum.Melody,
                new MusicXmlPartIdentifier("P1", "Bass"));

            this.RegisterMusicXmlObservers(arpeggiator);

			arpeggiator.Arpeggiate();

			new object();
		}
        MusicXmlPart Part { get; set; }
        MusicXmlModel CreateModel(MusicXmlScoreMetadata metadata, RhythmicContext rhythm, List<MusicXmlPart> parts)
        {
            var result = new MusicXmlModel();
            result.Metadata = metadata;
            result.Rhythm = rhythm;
            foreach (var part in parts)
            {
                result.Add(part);
            }

            //this.CreateSections(result);

            return result;
        }


        [TestMethod()]
		public void TheCycle_12Frets_Test()
		{
			var noteRange = new NoteRange(
				new Note(NoteName.B, OctaveEnum.Octave2),
				new Note(NoteName.G, OctaveEnum.Octave5));

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
            ChordIntervalsEnum chordType = ChordIntervalsEnum.None;
			const int CYCLE_MAX = 11;
			for (int i = 0 ; i <= CYCLE_MAX ; ++i)
			{
				if (null == root)
				{
					root = NoteName.G;
					key = KeySignature.CMajor;
					chordType = ChordIntervalsEnum.Dominant7;
				}
				else
				{
					chordType = ChordIntervalsEnum.Dominant7;
					key += Interval.Perfect4th;
					root += ChordToneInterval.Eleventh;
				}

				var formula = ChordFormulaFactory.Get(root, chordType);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);
			}


			var startingNote = chords[0].Root;
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversal,
				//DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

            this.Part = new MusicXmlPart(PartTypeEnum.Melody,
                new MusicXmlPartIdentifier("P1", "Bass"));

            this.RegisterMusicXmlObservers(arpeggiator);

			arpeggiator.Arpeggiate();

			new object();
		}

		MusicXmlModel Model { get; set; }

        private void XML_Starting(object sender, Arpeggiator e)
        {
            //string fileContent = Resources.MusicXML_TEMPLATE_02;
            //XmlCtx.Document = XDocument.Parse(fileContent);
            new object();
        }
        private void XML_ChordChanged(object sender, Arpeggiator ctx)
        {
            ++XmlCtx.MeasureNumber;
            this.CreateMeasure(ctx);
        }
        private void XML_Ending(object sender, Arpeggiator e)
        {
            //XmlCtx.Document.Save(@"c:\temp\_xml.xml");
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

#if false
			var octave = (int)ctx.CurrentNote.Octave;
			var note = ctx.CurrentNote.NoteName.ToString();
			//if (ctx.CurrentNote.NoteName == NoteName.Cb)
			//	++octave;


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

			var splitPoint = new Note(NoteName.C, OctaveEnum.Octave4);
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

#endif
            new object();
        }

        const string FLAT = "♭";
        const string SHARP = "♯";

        private void CreateMeasure(Arpeggiator ctx)
        {
			var measure = new MusicXmlMeasure(this.Part, XmlCtx.MeasureNumber);
            this.Part.Add(measure);
#if false
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

#endif
            new object();
        }



        [TestMethod()]
		public void Parser_Test()
		{
            this.Model = new MusicXmlModel();

            //var chordTxt = "dm7 g7 cm7 f7 bbm7 eb7 abm7 db7";
            var chordTxt = "eb7 abm7 db7";
			var success = false;

			if (ChordFormulaParser.TryParse(chordTxt, out var key, out List<ChordFormula> formulas, out string message))
			{
				formulas.ForEach(x => Debug.WriteLine(x));
				success = true;
			}

			if (success)
			{
				var noteRange = new NoteRange(
					new Note(NoteName.B, OctaveEnum.Octave1),
					new Note(NoteName.B, OctaveEnum.Octave4));

				new object();

				var startingNote = new Note(formulas[0].Root,
				//OctaveEnum.Octave1);
				OctaveEnum.Octave2);
				var notesToPlay = 4;

				var contexts = new List<ArpeggiationContext>();
				formulas.ForEach(x => contexts.Add(new ArpeggiationContext(x, noteRange, notesToPlay)));

				var arpeggiator = new Arpeggiator(contexts,
					//DirectionEnum.Ascending,
					DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversal,
					noteRange, 4, startingNote, true);

				this.RegisterMusicXmlObservers(arpeggiator);

				arpeggiator.Arpeggiate();
			}
			new object();
		}

		void RegisterMusicXmlObservers(Arpeggiator arpeggiator)
		{
			arpeggiator.ArpeggiationContextChanged += Ctx_NoOpObserver;

			arpeggiator.ChordChanged += this.Log_ChordChanged;
			arpeggiator.ChordChanged += this.XML_ChordChanged;


			arpeggiator.DirectionChanged += Log_DirectionChanged;


			arpeggiator.CurrentNoteChanged += this.Log_CurrentNoteChanged;
			arpeggiator.CurrentNoteChanged += this.XML_CurrentNoteChanged;

			//arpeggiator.Starting += Log_Starting;
			arpeggiator.Starting += XML_Starting;


			arpeggiator.Ending += this.Log_Ending;
			arpeggiator.Ending += this.XML_Ending;
		}


		private void Ctx_NoOpObserver(object sender, Arpeggiator ctx)
		{ }



		private void Log_Ending(object sender, Arpeggiator e)
		{
			Debug.WriteLine("");
			//Debug.WriteLine("||");
		}

		private void Log_Starting(object sender, Arpeggiator e)
		{
			Debug.Write("|");
		}

		private void Log_CurrentNoteChanged(object sender, Arpeggiator ctx)
		{
			var noteStr = string.Empty;
			noteStr = $" {g_direction}{ctx.CurrentNote.ToString()}";
			//noteStr = $"{noteStr}{g_direction}{functionStr}";
			//noteStr = $"{noteStr,9}";
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
		}
		private void Log_DirectionChanged(object sender, Arpeggiator ctx)
		{
			const string ASC = "˄";
			const string DESC = "˅";

			var direction = ctx.Direction.HasFlag(DirectionEnum.Ascending) ? ASC : DESC;
			Debug.Write(direction);
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







	}//class
}//ns

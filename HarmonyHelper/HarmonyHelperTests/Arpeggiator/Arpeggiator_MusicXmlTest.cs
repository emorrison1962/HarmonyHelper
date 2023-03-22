using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.MusicXml;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MusicXml.Tests;

using zHarmonyHelperTests_Arpeggiator;

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


			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
                DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote,
				noteRange, 4, startingNote, true);

            var musicXmlObservers = new MusicXmlObservers(arpeggiator);

            arpeggiator.Arpeggiate();
            var part = musicXmlObservers.Part;
			var staff = part.Staves.First();
			staff.Clef = new MusicXmlClef(ClefEnum.Bass, 1);

            var model = this.CreateModel(part);
            new object();

            MusicXmlExporterTests.Export($@"c:\temp\{MethodBase.GetCurrentMethod().Name}.xml", model);
            new object();
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

			var contexts = new List<ArpeggiationChordContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote,
				//DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

            var musicXmlObservers = new MusicXmlObservers(arpeggiator);

            arpeggiator.Arpeggiate();
            var part = musicXmlObservers.Part;
            var model = this.CreateModel(part);
            new object();

            MusicXmlExporterTests.Export($@"c:\temp\{MethodBase.GetCurrentMethod().Name}.xml", model);


            new object();
		}

		MusicXmlModel Model { get; set; }




        [TestMethod()]
		public void Parser_Test()
		{
            this.Model = new MusicXmlModel();

            //var chordTxt = "dm7 g7 cm7 f7 bbm7 eb7 abm7 db7";
            var chordTxt = "c7 f7 bb7 eb7 ab7 db7 gb7 b7 e7 a7 d7 g7";
			var success = false;

			if (ChordFormulaParser.TryParse(chordTxt, out var key, out List<ChordFormula> formulas, out string message))
			{
				//formulas.ForEach(x => Debug.WriteLine(x));
				success = true;
			}
			else 
			{ 
				Assert.Fail("Couldn't parse chords.");
			}

			if (success)
			{
                var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.EigthPosition);

                new object();

				var startingNote = new Note(formulas[0].Root,
				//OctaveEnum.Octave1);
				OctaveEnum.Octave2);
				var notesToPlay = 4;

				var contexts = new List<ArpeggiationChordContext>();
				formulas.ForEach(x => contexts.Add(new ArpeggiationChordContext(x, noteRange, notesToPlay)));

				var arpeggiator = new Arpeggiator(contexts,
					DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote,
					noteRange, 4, startingNote, true);

                //this.RegisterTraceObservers(arpeggiator);
                var musicXmlObservers = new MusicXmlObservers(arpeggiator);

                arpeggiator.Arpeggiate();
                var part = musicXmlObservers.Part;
				var model = this.CreateModel(part);
                new object();

				MusicXmlExporterTests.Export($@"c:\temp\{MethodBase.GetCurrentMethod().Name}.xml", model);

            }
            new object();
        }

        MusicXmlModel CreateModel(MusicXmlPart part)
        {
            var isValid = part.IsValid();
            Debug.Assert(isValid);

            var result = new MusicXmlModel();
            result.Add(part);

            isValid = result.IsValid();
            Debug.Assert(isValid);

            return result;
        }
        MusicXmlModel CreateModel(List<MusicXmlPart> parts)
        {
            var result = new MusicXmlModel();
            foreach (var part in parts)
            {
                result.Add(part);
            }
            return result;
        }

        void RegisterTraceObservers(Arpeggiator arpeggiator)
		{
            arpeggiator.Starting += Log_Starting;
            arpeggiator.NoteChanged += this.Log_CurrentNoteChanged;
            arpeggiator.DirectionChanged += Log_DirectionChanged;
            arpeggiator.ChordChanged += this.Log_ChordChanged;
			arpeggiator.Ending += this.Log_Ending;
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

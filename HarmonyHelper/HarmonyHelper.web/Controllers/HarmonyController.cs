using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HarmonyHelper.web.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class HarmonyController : Controller
	{
		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//    return new string[] { "Harmony", "Controller" };
		//}


		[HttpGet]
		[Route("GetData")]
		public IActionResult GetData()
		{
			var models = this.GenerateTestData();
			//var json = JsonConvert.SerializeObject(models);
			//var ob = JsonConvert.DeserializeObject(json);
			//Debug.WriteLine(json);
			var result = new JsonResult(models);
			return result;
		}

		List<StaveNoteVM> GenerateTestData()
		{
			const int CYCLE_MAX = 11;
			var noteRange = new FiveStringBassRange(FiveStringBassPositionEnum.TwelfthPosition);

			var chords = new List<Chord>();
			NoteName root = null;
			KeySignature key = null;
			ChordType chordType = ChordType.Augmented;

			for (int i = 0; i <= CYCLE_MAX; ++i)
			{
				if (null == root)
				{
					root = NoteName.D;
					key = KeySignature.CMajor;
					chordType = ChordType.Minor7th;
				}
				else
				{
					if (chordType == ChordType.Dominant7th)
					{
						chordType = ChordType.Minor7th;
						key = key - Interval.Major2nd;
					}
					else
					{
						chordType = ChordType.Dominant7th;
					}
					root = root + new IntervalContext(key, Interval.Perfect4th);
				}

				var formula = ChordFormulaFactory.Create(root, chordType, key);
				var chord = new Chord(formula, noteRange);
				chords.Add(chord);

				//Debug.Write("key="+key.ToString()+":");
				//Debug.Write("("+chord.Name+"):");
				//Debug.WriteLine(chord.ToString());

				new object();

			}

			new object();

			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote);


			var notes = new List<Note>();
			var Arpeggiator_CurrentNoteChanged =
				new EventHandler<Arpeggiator>(
					new Action<object, Arpeggiator>((sender, ctx) =>
					  {
						  notes.Add(ctx.CurrentNote);
					  }));

			arpeggiator.CurrentNoteChanged += Arpeggiator_CurrentNoteChanged;
			arpeggiator.Arpeggiate();
			new object();

			var result = new List<StaveNoteVM>();
			notes.ForEach(x => result.Add(new StaveNoteVM(x)));
			return result;
		}

		//private void Arpeggiator_CurrentNoteChanged(object sender, Arpeggiator ctx)
		//{
		//    throw new System.NotImplementedException();
		//}
	}


	public class StaveNoteVM
	{
		public string clef { get { return "treble"; } }
		public List<string> keys { get; set; } = new List<string>();//['c/4'],
		public string duration { get { return "q"; } }
		public bool auto_stem { get { return true; } }

		public StaveNoteVM(Note note)
		{
			var nn = note.NoteName.Name.ToLower().Replace("♯", "#").Replace("♭", "b");
			var o = 1 + (int)note.Octave;

			var s = $"{nn}/{o}";
			keys.Add(s);
		}
	}


}
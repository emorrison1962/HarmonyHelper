using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eric.Morrison.Harmony;

namespace HarmornyHelper.forms
{
	public partial class ArpeggiosControl 
	{
		List<ArpeggiationResult> ArpeggiationResults { get; set; } = new List<ArpeggiationResult>();
		class ArpeggiationResult
		{
			public Chord Chord { get; set; }
			public List<Note> Notes { get; set; } = new List<Note>();
			public ArpeggiationResult(Chord chord)
			{
				this.Chord = chord;
			}
			public override string ToString()
			{
				//return $"{GetType().Name}: Chord={Chord.Name} Notes={string.Join(", ", Notes)}";
				return $"Chord={Chord.Name} Notes={string.Join(", ", Notes)}";  
			}
		}
		private void Arpeggiate(List<Chord> chords)
		{

			var noteRange = new NoteRange(
				new Note(NoteName.B, OctaveEnum.Octave1),
				new Note(NoteName.B, OctaveEnum.Octave4));

			chords.ForEach(x => x.Set(noteRange));

			new object();

			var startingNote = new Note(chords[0].Root.NoteName, OctaveEnum.Octave2);
			var notesToPlay = 4;

			var contexts = new List<ArpeggiationContext>();
			chords.ForEach(x => contexts.Add(new ArpeggiationContext(x, notesToPlay)));

			var arpeggiator = new Arpeggiator(contexts,
				DirectionEnum.Ascending,
				noteRange, 4, startingNote, true);

			arpeggiator.ArpeggiationContextChanged += Observe_ArpeggiationContextChanged;
			arpeggiator.ChordChanged += Ctx_ChordChanged;
			arpeggiator.DirectionChanged += Ctx_DirectionChanged;
			arpeggiator.CurrentNoteChanged += Ctx_CurrentNoteChanged;
			arpeggiator.Starting += Ctx_Starting;
			arpeggiator.Ending += Ctx_Ending;


			arpeggiator.Arpeggiate();

			new object();
		}

		private void Observe_ArpeggiationContextChanged(object sender, Arpeggiator ctx)
		{
		}
		private void Ctx_ChordChanged(object sender, Arpeggiator ctx)
		{
			this.ArpeggiationResults.Add(new ArpeggiationResult(ctx.CurrentChord));
		}

		private void Ctx_DirectionChanged(object sender, Arpeggiator ctx)
		{
		}

		private void Ctx_CurrentNoteChanged(object sender, Arpeggiator ctx)
		{
			this.ArpeggiationResults.Last().Notes.Add(ctx.CurrentNote);
			this.ArpeggiatedNotes.Add(ctx.CurrentNote);
		}

		private void Ctx_Ending(object sender, Arpeggiator e)
		{
		}

		private void Ctx_Starting(object sender, Arpeggiator e)
		{
			this.ArpeggiatedNotes.Clear();
			this.ArpeggiationResults.Clear();
		}

	}
}

using HarmornyHelper.forms.Controls;
using Manufaktura.Controls.Extensions;
using Manufaktura.Controls.Model;
using Manufaktura.Music.Model;
using Manufaktura.Music.Model.MajorAndMinor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Harmony = Eric.Morrison.Harmony;

namespace HarmornyHelper.forms
{
	public partial class ArpeggiosControl : NoteViewerControlBase
	{
		enum ClefEnum
		{
			None = 0,
			Treble,
			Bass
		};

		#region Properties
		List<Harmony.Note> ArpeggiatedNotes { get; set; } = new List<Harmony.Note>();
		Harmony.KeySignature SelectedKey { get; set; }
		ClefEnum SelectedClef { get; set; }

		#endregion

		#region Construction
		public ArpeggiosControl()
		{
			InitializeComponent();
		}



		protected override void OnLoad(EventArgs e)
		{
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			base.OnLoad(e);

			this.NoteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NoteViewer.CreateControl();
			this._outputPanel.Controls.Add(this.NoteViewer);

			this._comboKey.SelectedItem = this._comboKey.Keys[0];
			this._comboKey_SelectionChangeCommitted(null, null);

			this._tbChords.Text = "dm7 g7 cmaj7 a7";
		}

		#endregion

		protected void Populate(List<Harmony.Chord> chords)
		{
			this.Arpeggiate(chords);
			var score = this.BuildScore(chords);
			this.NoteViewer.DataSource = score;
			this.NoteViewer.PerformLayout();
			this.NoteViewer.Refresh();
		}

		readonly Pitch STAFF_PITCH_THRESHOLD = new Pitch(Step.F, 0, 4);


		Score BuildScore(List<Harmony.Chord> chords)
		{

			Score result = null;
#if true

			#region KeySignature
			var key = this.SelectedKey;
			var flags = MajorAndMinorScaleFlags.MajorFlat;
			if (key.UsesSharps)
				flags = MajorAndMinorScaleFlags.MajorSharp;
			#endregion

			//var clef = this.SelectedClef == ClefEnum.Treble ? Clef.Treble : Clef.Bass;

			#region Create the Score and Staves
			result = new Score();
			result.AddStaff(Clef.Treble, TimeSignature.CommonTime, key.NoteName.ToStep(), flags);
			var trebleStaff = result.Staves.Last();
			result.AddStaff(Clef.Bass, TimeSignature.CommonTime, key.NoteName.ToStep(), flags);
			var bassStaff = result.Staves.Last();
			#endregion

			foreach (var arpResult in this.ArpeggiationResults)
			{
				var pitches = arpResult.Notes.ToPitches();
				//var durations = new List<int>();
				//pitches.ForEach(x => durations.Add(4));

				foreach (var pitch in pitches)
				{
					var note = new Note(pitch, RhythmicDuration.Quarter);
					var rest = new Rest(RhythmicDuration.Quarter);
					MusicalSymbol trebleSymbol = rest;
					MusicalSymbol bassSymbol = rest;
					if (pitch >= STAFF_PITCH_THRESHOLD)
						trebleSymbol = note;
					else
						bassSymbol = note;

					trebleStaff.Elements.Add(trebleSymbol);
							//.AddRhythm(durations.ToArray())
							//.AddLyrics(arpResult.Chord.Formula.Name));

					bassStaff.Elements.Add(bassSymbol);
							//.AddRhythm(durations.ToArray())
							//.AddLyrics(arpResult.Chord.Formula.Name));
				}
				trebleStaff.AddBarline(BarlineStyle.Regular);
				bassStaff.AddBarline(BarlineStyle.Regular);
			}

			//staff.Elements.AddRange(StaffBuilder.FromPitches(pitches.ToArray())
			//	.AddRhythm(durations.ToArray()));
			//	//.AddLyrics(formula.Name));
			//staff.AddBarline(BarlineStyle.Regular);
#endif
			return result;
		}

		void ParseChords()
		{
			var input = this._tbChords.Text;
			if (Harmony.ChordParser.TryParse(input, this.SelectedKey, out List<Harmony.Chord> chords, out string message))
			{
				this.Populate(chords);
			}
		}

		#region EventHandlers
		private void _bnParse_Click(object sender, EventArgs e)
		{
			this.ParseChords();
		}
		private void _comboKey_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.SelectedKey = _comboKey.SelectedItem as Harmony.KeySignature;
		}


		private void _comboClef_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.SelectedClef = (ClefEnum)Enum.Parse(typeof(ClefEnum), _comboClef.SelectedItem.ToString());
		}

		#endregion
	}//class
}//ns

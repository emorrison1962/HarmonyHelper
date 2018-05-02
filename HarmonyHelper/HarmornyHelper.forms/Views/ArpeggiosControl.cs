using HarmornyHelper.forms.Controls;
using Manufaktura.Controls.Model;
using Manufaktura.Controls.WinForms;
using Manufaktura.Music.Model;
using Manufaktura.Music.Model.MajorAndMinor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Harmony = Eric.Morrison.Harmony;

namespace HarmornyHelper.forms
{
	public partial class ArpeggiosControl : NoteViewerControlBase
	{
		readonly Pitch STAFF_PITCH_THRESHOLD = new Pitch(Step.F, 0, 4);
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
		List<NoteViewer> NoteViewers { get; set; } = new List<NoteViewer>();
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

			this._comboKey.SelectedItem = this._comboKey.Keys[0];
			this._comboKey_SelectionChangeCommitted(null, null);

			//this._tbChords.Text = "dm7 g7 cm7 f7 bbm7 eb7 abm7 db7";
			this._tbChords.Text = "eb7 abm7 db7";
			this._bnParse_Click(null, null);

		}

		#endregion

		protected void Populate(List<Harmony.Chord> chords)
		{
			this.Arpeggiate(chords);
			this.BuildNoteViewers();

			// var score = this.BuildScore(chords);


		}



		void BuildNoteViewers()
		{
			const int BARS_PER_LINE = 8;

			this.RemoveNoteViewers();
			while (0 < this.ArpeggiationResults.Count)
			{
				var arpResults = this.ArpeggiationResults.Take(BARS_PER_LINE).ToList();

				arpResults.ForEach(x => _tbDiags.Text += x.ToString() + Environment.NewLine);
				_tbDiags.Text += Environment.NewLine;

				arpResults.ForEach(x => this.ArpeggiationResults.Remove(x));

				var noteViewer = this.BuildNoteViewer(arpResults);
				this.AddNoteViewer(noteViewer);
			}
		}

		private void AddNoteViewer(NoteViewer nv)
		{
			this.NoteViewers.Add(nv);

			nv.Dock = System.Windows.Forms.DockStyle.Top;
			nv.CreateControl();
			this._panelNoteViewers.Controls.Add(nv);

			// nv.DataSource = score;
			if (this.NoteViewers.Count % 2 == 0)
				nv.BackColor = System.Drawing.Color.Aquamarine;
			else
				nv.BackColor = System.Drawing.Color.MistyRose;

			var s = nv.PreferredSize;
			nv.ClientSize = new Size(this._panelNoteViewers.ClientSize.Width, 150);

			nv.PerformLayout();
			nv.Refresh();
		}

		void RemoveNoteViewers()
		{
			foreach (var nv in this.NoteViewers)
			{
				this._panelNoteViewers.Controls.Remove(nv);
			}
		}

		NoteViewer  BuildNoteViewer(List<ArpeggiationResult> arpResults)
		{
			var result = new NoteViewer();
			var score = this.BuildScore(arpResults);
			result.DataSource = score;
			return result;
		}

		Score BuildScore(List<ArpeggiationResult> arpResults)
		{

			Score result = null;

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

			foreach (var arpResult in arpResults)
			{
				var pitches = arpResult.Notes.ToPitches();
				//var durations = new List<int>();
				//pitches.ForEach(x => durations.Add(4));

				var firstTime = true;
				foreach (var pitch in pitches)
				{
					var note = new Note(pitch, RhythmicDuration.Quarter);
					var empty = new Rest(RhythmicDuration.Quarter);
					empty.IsVisible = false;

					MusicalSymbol trebleSymbol = empty;
					MusicalSymbol bassSymbol = empty;

					trebleSymbol = note;
					trebleSymbol.IsVisible = false;
					bassSymbol = note;
					bassSymbol.IsVisible = false;
					if (pitch >= STAFF_PITCH_THRESHOLD)
						trebleSymbol.IsVisible = true;
					else
						bassSymbol.IsVisible = true;

					if (firstTime)
					{
						firstTime = false;
						var lyrics = new Lyrics(SyllableType.None, arpResult.Chord.Formula.Name);
						note.Lyrics.Add(lyrics);
					}

					trebleStaff.Elements.Add(trebleSymbol);
					bassStaff.Elements.Add(bassSymbol);
				}
				trebleStaff.AddBarline(BarlineStyle.Regular);
				bassStaff.AddBarline(BarlineStyle.Regular);
			}


			//result.Pages.First().Height = 800;
#if DEBUG
			//var scoreService = new ScoreService();
			//scoreService.CurrentStaff = result.FirstStaff;
			//scoreService.BeginNewStaff();
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

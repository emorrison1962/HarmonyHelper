using HarmornyHelper.forms.Controls;
using Manufaktura.Controls.Extensions;
using Manufaktura.Controls.Model;
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
		List<Harmony.Note> ArpeggiatedNotes { get; set; } = new List<Harmony.Note>();
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

			this._tbChords.Text = "dm7 g7 cmaj7 a7";
		}

		private void _bnParse_Click(object sender, EventArgs e)
		{
			var input = this._tbChords.Text;

			if (Harmony.ChordParser.TryParse(input, out List<Harmony.Chord> chords, out string message))
			{
				this.Populate(chords);
			}
		}

		protected void Populate(List<Harmony.Chord> chords)
		{
			this.Arpeggiate(chords);
			var score = this.BuildScore(chords);
			this.NoteViewer.DataSource = score;
			this.NoteViewer.PerformLayout();
			this.NoteViewer.Refresh();
		}

		Score BuildScore(List<Harmony.Chord> chords) 
		{

			Score result = null;
#if true

			var clef = Clef.Treble;
			var key = chords[0].Key;

			var flags = MajorAndMinorScaleFlags.MajorFlat;
			if (key.UsesSharps)
				flags = MajorAndMinorScaleFlags.MajorSharp;

			if (null == result)
			{
				result = Score.CreateOneStaffScore(clef, key.NoteName.ToStep(), flags);
			}
			else
			{
				result.AddStaff(clef, null, key.NoteName.ToStep(), flags);
			}

			var staff = result.Staves.Last();
			var pitches = this.ArpeggiatedNotes.ToPitches();
			var durations = new List<int>();
			pitches.ForEach(x => durations.Add(4));

			while (pitches.Count > 0)
			{
				staff.Elements.AddRange(StaffBuilder.FromPitches(pitches.Take(4).ToArray())
		.AddRhythm(durations.Take(4).ToArray()));
				//.AddLyrics(formula.Name));
				staff.AddBarline(BarlineStyle.Regular);

				pitches.RemoveRange(0, 4);
				durations.RemoveRange(0, 4);
			}


			//staff.Elements.AddRange(StaffBuilder.FromPitches(pitches.ToArray())
			//	.AddRhythm(durations.ToArray()));
			//	//.AddLyrics(formula.Name));
			//staff.AddBarline(BarlineStyle.Regular);
#endif
			return result;
		}


	}//class
}//ns

using Manufaktura.Controls.Extensions;
using Manufaktura.Controls.Model;
using Manufaktura.Controls.WinForms;
using Manufaktura.Music.Model;
using Manufaktura.Music.Model.MajorAndMinor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Harmony = Eric.Morrison.Harmony;

namespace HarmornyHelper.forms
{

	public partial class ScalesControl : UserControl
	{
		TextBox TextBox
		{
			get { return this._textBox; }
		}

		NoteViewer NoteViewer { get; set; } = new NoteViewer();

		public List<Harmony.KeySignature> Keys { get; set; } = new List<Harmony.KeySignature>();
		public Harmony.KeySignature SelectedKey { get; set; }
		public Harmony.ScaleFormulaBase SelectedScaleFormula { get; set; }

		public ScalesControl()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			this.Dock = System.Windows.Forms.DockStyle.Fill;
			base.OnLoad(e);

			//this.SuspendLayout();
			//this.GetModes();
			//this.ResumeLayout();
			this.PopulateKeysCombo();
			this.PopulateScaleTypesCombo();

			this.NoteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.NoteViewer.CreateControl();
			this._outputPanel.Controls.Add(this.NoteViewer);
		}

		#region Initialization
		void PopulateKeysCombo()
		{
			this.Keys = Harmony.KeySignature.MajorKeys;
			this._comboKeys.Items.AddRange(this.Keys.ToArray());
			this._comboKeys.SelectedItem = this.Keys[0];
			this._comboKeys_SelectionChangeCommitted(null, null);
		}

		void PopulateScaleTypesCombo()
		{
			var catalog = new Harmony.ScaleFormulaCatalog();
			var list = catalog.Formulas.Where(x => x.Key == this.SelectedKey).ToList();
			list.ForEach(x => Debug.WriteLine(x.GetType()));
			// this._comboScaleTypes.DisplayMember = "Name";
			this._comboScaleTypes.DataSource = list;
			this._comboScaleTypes.SelectedItem = list[0];
			this._comboScaleTypes_SelectionChangeCommitted(null, null);
		}


		#endregion

		void Populate()
		{
			if (null != this.SelectedScaleFormula)
			{
				var score = this.BuildScore((dynamic)this.SelectedScaleFormula);
				this.NoteViewer.DataSource = score;

				this.NoteViewer.PerformLayout();
				this.NoteViewer.Refresh();
			}
		}

		public List<Harmony.Mode> GetModes()
		{
			var result = new List<Harmony.Mode>();
			var modeEnums = this.GetModeEnums();
			this.TextBox.Clear();
			foreach (var @enum in modeEnums)
			{
				var formula = new Harmony.ModalScaleFormulaBase(this.SelectedKey, @enum);
				var root = new Harmony.Note(formula.NoteNames[0], Harmony.OctaveEnum.Octave4);
				var mode = new Harmony.Mode(this.SelectedKey, @enum, new Harmony.NoteRange(root, 1));
				result.Add(mode);
				this.TextBox.AppendText($"{mode.ToString()}{Environment.NewLine}");
				this.TextBox.AppendText($"{string.Join(",", mode.Notes)}{Environment.NewLine}");
				this.TextBox.AppendText($"{Environment.NewLine}");

				Debug.WriteLine(mode);
			}
			this.TextBox.AppendText(Environment.NewLine);
			Debug.WriteLine("");
			new Object();
			return result;
		}


		Score BuildScore(Harmony.PentatonicMajorScaleFormula formula)
		{
			Score result = null;

			var root = new Harmony.Note(formula.NoteNames[0], Harmony.OctaveEnum.Octave4);
			var scale = new Harmony.Scale(this.SelectedKey, formula, new Harmony.NoteRange(root, 1));

			var clef = Clef.Treble;
			var key = formula.Key.NoteName.ToStep();

			var flags = MajorAndMinorScaleFlags.MajorFlat;
			if (formula.Key.UsesSharps)
				flags = MajorAndMinorScaleFlags.MajorSharp;

			if (null == result)
			{
				result = Score.CreateOneStaffScore(clef, key, flags);
			}
			else
			{
				result.AddStaff(clef, null, key, flags);
			}

			var staff = result.Staves.Last();
			var pitches = this.GetPitches(scale);
			var durations = new List<int>();
			pitches.ForEach(x => durations.Add(4));

			staff.Elements.AddRange(StaffBuilder.FromPitches(pitches.ToArray())
				.AddRhythm(durations.ToArray()).AddLyrics(formula.Name));
			staff.AddBarline(BarlineStyle.Regular);

			return result;
		}
		Score BuildScore(Harmony.NonatonicBluesScaleFormula formula)
		{
			return null;
		}
		Score BuildScore(Harmony.WholeToneScaleFormula formula)
		{
			return null;
		}
		Score BuildScore(Harmony.DiminishedHalfWholeScaleFormula formula)
		{
			return null;
		}
		Score BuildScore(Harmony.DiminishedWholeHalfScaleFormula formula)
		{
			return null;
		}

		Score BuildScore(Harmony.ModalScaleFormulaBase formula)
		{
			Score result = null;
			var modes = this.GetModes();
			foreach (var mode in modes)
			{
				var clef = Clef.Treble;
				var key = mode.Key.NoteName.ToStep();

				var flags = MajorAndMinorScaleFlags.MajorFlat;
				if (mode.Key.UsesSharps)
					flags = MajorAndMinorScaleFlags.MajorSharp;

				if (null == result)
				{
					//result.AddStaff(clef, null, key, flags);
					result = Score.CreateOneStaffScore(clef, key, flags);
				}
				else
				{
					result.AddStaff(clef, null, key, flags);
				}

				var staff = result.Staves.Last();
				var pitches = this.GetPitches(mode);
				var durations = new List<int>();
				pitches.ForEach(x => durations.Add(4));

				staff.Elements.AddRange(StaffBuilder.FromPitches(pitches.ToArray())
					.AddRhythm(durations.ToArray()).AddLyrics(mode.Name));
				staff.AddBarline(BarlineStyle.Regular);

			}
			return result;
		}

		List<Pitch> GetPitches(Harmony.ScaleBase scale)
		{
			var result = new List<Pitch>();
			scale.Notes.ToList().ForEach(x => result.Add(x.ToPitch()));


			Debug.WriteLine($"{string.Join(",", result)}");

			Debug.WriteLine($"{string.Join(",", scale.Notes)}");

			//result.ForEach(x => Debug.WriteLine(x.StepName))
			return result;
		}





		List<Harmony.ModeEnum> GetModeEnums()
		{
			var result = Enum.GetValues(typeof(Harmony.ModeEnum)).Cast<Harmony.ModeEnum>().ToList();
			return result;
		}


		private void _comboKeys_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.SelectedKey = this._comboKeys.SelectedItem as Harmony.KeySignature;
			this.Populate();
		}

		private void _comboScaleTypes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			new object();
			this.SelectedScaleFormula = this._comboScaleTypes.SelectedItem as Harmony.ScaleFormulaBase;
			this.Populate();
		}
	}//class

}//ns

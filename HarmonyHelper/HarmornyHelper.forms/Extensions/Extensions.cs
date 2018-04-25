using Manufaktura.Music.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Harmony = Eric.Morrison.Harmony;

namespace HarmornyHelper.forms
{
	static class Extensions
	{

		static public Pitch ToPitch(this Harmony.Note src)
		{
			var step = src.NoteName.ToStep();
			var result = Pitch.FromStep(step, (int)src.Octave);
			return result;
		}
		static public Pitch ToPitch(this Harmony.NoteName src)
		{
			var step = src.ToStep();
			var result = Pitch.FromStep(step);
			return result;
		}


		static public Step ToStep(this Harmony.NoteName src)
		{
			Step step = null;
			switch (src.Name)
			{
				case "B♯": step = Step.BSharp; break;
				case "C": step = Step.C; break;
				case "C♯": step = Step.CSharp; break;
				case "D♭": step = Step.Db; break;
				case "D": step = Step.D; break;
				case "D♯": step = Step.DSharp; break;
				case "E♭": step = Step.Eb; break;
				case "E": step = Step.E; break;
				case "F♭": step = Step.Fb; break;
				case "E♯": step = Step.ESharp; break;
				case "F": step = Step.F; break;
				case "F♯": step = Step.FSharp; break;
				case "G♭": step = Step.Gb; break;
				case "G": step = Step.G; break;
				case "G♯": step = Step.GSharp; break;
				case "A♭": step = Step.Ab; break;
				case "A": step = Step.A; break;
				case "A♯": step = Step.ASharp; break;
				case "B♭": step = Step.Bb; break;
				case "B": step = Step.B; break;
				case "C♭": step = Step.Cb; break;
				default:
					break;
			}
			return step;
		}

		static public List<Pitch> ToPitches(this List<Harmony.Note> src)
		{
			var result = new List<Pitch>();
			src.ForEach(x => result.Add(x.ToPitch()));
			return result;
		}

	}//class
}//ns

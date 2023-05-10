using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

using static System.Net.Mime.MediaTypeNames;

namespace Eric.Morrison.Harmony.Chords
{
	public static class ChordFormulaParser
	{
		const int NDX_ROOT = 1;
		const int NDX_ROOT_ACCIDENTAL = 2;
		const int NDX_CHORD_TYPE = 3;
		const int NDX_BASS = 4;
		const int NDX_BASS_ACCIDENTAL = 5;

		static string REGEX;

		static ChordFormulaParser()
		{
			String notes = "^([cdefgab])";
			String accidentals = "(#|##|b|bb)?";

			String chordTypes =
                @"(dominant|maj13#11|sus2sus4|maj9#11|maj7b5|maj7#5|maj7+|m6add9|maj11|maj13|madd9|mmaj7|mmaj9|7sus4|7b5|7b5b9|7b5#9|7#5b9|13#11|maj7|maj9|add9|-7b5|m7b5|m7#5|13b9|11b9|dim7|sus4|sus2|sus|maj|min|m11|m13|7b5|7#5|7b9|7#9|9#5|aug|dim|-7|m7|m9|m6|11|13|\+|-5|6|-|7|9|m|)";

			String bass = "?[\\/]?([cdefgab])?";

			REGEX = notes + accidentals + chordTypes + bass + accidentals;
		}

		static public List<ChordFormula> Parse(string input)
		{
            ChordFormulaParser.TryParse(input, out var key, out var chords, out var msg);
            return chords;
		}


        static public bool TryParse(string input, out KeySignature key, out List<ChordFormula> formulas, out string message)
		{
			var result = false;
			key = null;
			message = string.Empty;
			formulas = new List<ChordFormula>();

			var strings = PreParse(input);

			var successCount = 0;
			foreach (var s in strings)
			{
				if (TryParseImpl(key, s, out ChordFormula formula, out message))
				{
					formulas.Add(formula);
					++successCount;
				}
				else
				{
					break;
				}
			}
			if (string.IsNullOrEmpty(message))
				result = true;

            key = KeySignature.DetermineKey(formulas);

			return result;
		}

		static List<string> PreParse(string input)
		{
			var result = new List<string>();
			input = input.ToLower();
			result = input.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			result.RemoveAll(x => "nc" == x);
			return result;
		}

		static bool TryParseImpl(KeySignature key, string input, out ChordFormula chordFormula, out string message)
		{
			var result = false;
			message = null;
			chordFormula = null;


			NoteName root = null;
			NoteName bass = null;
			var chordType = ChordIntervalsEnum.None;
			bool success = false;
			// Debug.WriteLine(input);
			var match = Regex.Match(input, REGEX);
#pragma warning disable CS0168 // Variable is declared but never used
            try
			{
				if (match.Success)
				{
					if (match.Groups[NDX_ROOT].Success)
					{
						var note = match.Groups[NDX_ROOT].ToString();
						var accidental = string.Empty;
						if (match.Groups[NDX_ROOT_ACCIDENTAL].Success)
							accidental = match.Groups[NDX_ROOT_ACCIDENTAL].ToString();

						var rootStr = note + accidental;
						root = ParseNoteName(rootStr);
					}

					if (match.Groups[NDX_CHORD_TYPE].Success)
					{
						var ctStr = match.Groups[NDX_CHORD_TYPE].ToString();
						chordType = ParseChordType(ctStr, out string error);
						Debug.Assert(ChordIntervalsEnum.None != chordType);
						if (ChordIntervalsEnum.None == chordType)
							message = error;
					}

					if (match.Groups[NDX_BASS].Success)
					{
						var note = match.Groups[NDX_BASS].ToString();
						var accidental = string.Empty;
						if (match.Groups[NDX_BASS_ACCIDENTAL].Success)
							accidental = match.Groups[NDX_BASS_ACCIDENTAL].ToString();

						var bassStr = note + accidental;
						bass = ParseNoteName(bassStr);
					}

					success = true;
				}
				else
				{
					message = $"Error parsing chord: \"{input}\"";
					new object();
				}
			}
			catch (NotSupportedException ex)
			{
				message = $"Unsupported chord type ({ex.Message})";
			}
			catch (Exception ex)
			{
				throw;
			}
#pragma warning restore CS0168 // Variable is declared but never used

            if (success)
			{
				chordFormula = ChordFormula.Catalog.First(x => root == x.Root && x.ChordType == chordType);
                chordFormula = ChordFormula.Create(chordFormula.Root, chordFormula.ChordType);

                if (null != bass)
					chordFormula.SetBassNote(bass);
			}

			if (success)
				result = true;

			return result;
		}

		static NoteName ParseNoteName(string input)
		{

			NoteName result = null;

			#region switch (input)
			switch (input)
			{
				case "b♯":
				case "b#":
					result = NoteName.BSharp;
					break;
				case "c":
					result = NoteName.C;
					break;
				case "c♯":
				case "c#":
					result = NoteName.CSharp;
					break;
				case "db":
				case "d♭":
					result = NoteName.Db;
					break;
				case "d":
					result = NoteName.D;
					break;
				case "d#":
				case "d♯":
					result = NoteName.DSharp;
					break;
				case "eb":
				case "e♭":
					result = NoteName.Eb;
					break;
				case "e":
					result = NoteName.E;
					break;
				case "fb":
				case "f♭":
					result = NoteName.Fb;
					break;
				case "e#":
				case "e♯":
					result = NoteName.ESharp;
					break;
				case "f":
					result = NoteName.F;
					break;
				case "f#":
				case "f♯":
					result = NoteName.FSharp;
					break;
				case "gb":
				case "g♭":
					result = NoteName.Gb;
					break;
				case "g":
					result = NoteName.G;
					break;
				case "g#":
				case "g♯":
					result = NoteName.GSharp;
					break;
				case "ab":
				case "a♭":
					result = NoteName.Ab;
					break;
				case "a":
					result = NoteName.A;
					break;
				case "a#":
				case "a♯":
					result = NoteName.ASharp;
					break;
				case "bb":
				case "b♭":
					result = NoteName.Bb;
					break;
				case "b":
					result = NoteName.B;
					break;
				case "cb":
				case "c♭":
					result = NoteName.Cb;
					break;
				default:
					throw new NotSupportedException(input);
			}
			#endregion

			return result;

		}

		static ChordIntervalsEnum ParseChordType(string input, out string message)
		{
			message = null;
			var result = ChordIntervalsEnum.None;

			#region switch (input)
			switch (input)
			{
				#region Major chords
				case "":
				case "maj":
					result = ChordIntervalsEnum.Major;
					break;
				case "6":
					result = ChordIntervalsEnum.Major6;
					break;
				case "maj7":
					result = ChordIntervalsEnum.Major7;
					break;
				case "maj9":
					result = ChordIntervalsEnum.Major9;
					break;
				case "maj11":
					result = ChordIntervalsEnum.Major11;
					break;
				case "maj13":
					result = ChordIntervalsEnum.Major13;
					break;
				#endregion


				case "maj9#11":
					break;
				case "maj13#11":
					result = ChordIntervalsEnum.Major13Aug11;
                    break;
				case "add9":
					result = ChordIntervalsEnum.MajorMu;
					break;
				case "maj7b5":
					result = ChordIntervalsEnum.Major7b5;
					break;
				case "maj7#5":
                    result = ChordIntervalsEnum.Major7Aug;
                    break;


				#region Minor chords
				case "min":
				case "m":
				case "-":
					result = ChordIntervalsEnum.Minor;
					break;
				case "m6":
					result = ChordIntervalsEnum.Minor6;
					break;
				case "m7":
				case "-7":
					result = ChordIntervalsEnum.Minor7;
					break;
				case "m9":
					result = ChordIntervalsEnum.Minor9;
					break;
				case "m11":
					result = ChordIntervalsEnum.Minor11;
					break;
				case "m13":
					result = ChordIntervalsEnum.Minor13;
					break;
				#endregion


				case "madd9":
					result = ChordIntervalsEnum.MinorAdd9;
					break;
				case "m6add9":
					break;
				case "mmaj7":
					result = ChordIntervalsEnum.MinorMajor7;
					break;
				case "mmaj9":
                    throw new NotImplementedException();
                    break;


				case "-7b5":
				case "m7b5":
					result = ChordIntervalsEnum.HalfDiminished;
					break;
				case "m7#5":
                    throw new NotImplementedException();
                    break;


                #region Diatonic Dominant chords
                case "dominant":
                case "7":
					result = ChordIntervalsEnum.Dominant7;
					break;
				case "9":
					result = ChordIntervalsEnum.Dominant9;
					break;
				case "11":
					result = ChordIntervalsEnum.Dominant11;
					break;
				case "13":
					result = ChordIntervalsEnum.Dominant13;
					break;

                #endregion

                case "7b5":
					result = ChordIntervalsEnum.Dominant7b5;
                    break;


                case "7#5":
					result = ChordIntervalsEnum.Dominant7Sharp5;
                    break;
				case "7b9":
					result = ChordIntervalsEnum.Dominant7b9;
					break;
				case "7#9":
					result = ChordIntervalsEnum.Dominant7Sharp9;
					break;
				case "7b5b9":
                    throw new NotImplementedException();
                    break;
				case "7b5#9":
                    throw new NotImplementedException();
                    break;
				case "7#5b9":
				case "9#5":
				case "13#11":
				case "13b9":
				case "11b9":
                    throw new NotImplementedException();
                case "aug":
				case "+":
					result = ChordIntervalsEnum.Augmented;
					break;
				case "dim":
					result = ChordIntervalsEnum.Diminished;
					break;
				case "dim7":
					result = ChordIntervalsEnum.Diminished7;
					break;

                case "sus":
                case "sus4":
					result = ChordIntervalsEnum.Sus4;
					break;
				case "sus2":
					result = ChordIntervalsEnum.Sus2;
					break;
				case "sus2sus4":
					result = ChordIntervalsEnum.Sus2Sus4;
					break;
				case "7sus4":
					result = ChordIntervalsEnum.Dominant7Sus4;
					break;


				case "-5":
                    throw new NotImplementedException();
                    break;
				default:
					throw new NotSupportedException(input);
			}

			#endregion

			if (result == ChordIntervalsEnum.None)
			{
				message = $"Unsupported chord type ({input})";
				Debug.WriteLine($"{input}");
			}
			return result;
		}

	}//class
}//ns

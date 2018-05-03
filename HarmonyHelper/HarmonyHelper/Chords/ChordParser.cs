using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Eric.Morrison.Harmony
{
	public static class ChordParser
	{
		const int NOTE = 1;
		const int ACCIDENTAL = 2;
		const int CHORD_TYPE = 3;
		const int BASS = 4;

		static string REGEX;

		static ChordParser()
		{

			String notes = "^([cdefgab])";
			String accidentals = "(#|##|b|bb)?";
			String chords =
			//@"(maj|maj7|maj9|maj11|maj13|maj9#11|maj13#11|6|add9|maj7b5|maj7#5|min|-7|-|m7|m9|m11|m13|
			//m6 | madd9 | m6add9 | mmaj7 | mmaj9 | m7b5 | m7#5|7|9|11|13|7sus4|7b5|7#5|7b9|7#9|7b5b9|7b5#9|
			//7#5b9|9#5|13#11|13b9|11b9|aug|\+|dim|dim7|sus4|sus2|sus2sus4|-5|)";
			@"(maj13#11|sus2sus4|maj9#11|maj7b5|maj7#5|m6add9|maj11|maj13|madd9|mmaj7|mmaj9|7sus4|7b5b9|7b5#9|7#5b9|13#11|maj7|maj9|add9|-7b5|m7b5|m7#5|13b9|11b9|dim7|sus4|sus2|maj|min|m11|m13|7b5|7#5|7b9|7#9|9#5|aug|dim|-7|m7|m9|m6|11|13|\+|-5|6|-|7|9|m)";
			//String bass = "/([CDEFGAB])";
			REGEX = notes + accidentals + chords;// + bass;
		}

		static public bool TryParse(string input, out List<Chord> chords, out string messageResult)
		{
			return TryParse(input, null, out chords, out messageResult);
		}

		static public bool TryParse(string input, KeySignature key, out List<Chord> chords, out string messageResult)
		{
			//foo();

			var result = false;
			messageResult = string.Empty;
			chords = new List<Chord>();

			var strings = PreProcess(input);

			var success = false;
			foreach (var incoming in strings)
			{
				success = TryParseImpl(incoming, out Chord chord, out string message, key);
				if (success)
				{
					chords.Add(chord);
				}
				else
				{
					messageResult = message;
					break;
				}
			}
			if (success)
				result = true;

			return result;
		}

		static List<string> PreProcess(string input)
		{
			var result = new List<string>();
			input = input.ToLower();
			result = input.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			return result;
		}

		static bool TryParseImpl(string input, out Chord chord, out string message, KeySignature key = null)
		{
			var result = false;
			message = null;
			chord = null;


			// Debug.WriteLine(input);
			var success = false;
			var match = Regex.Match(input, REGEX);
			if (match.Success)
			{
				success = true;
			}
			else
			{
				message = $"Error parsing chord: \"{input}\"";
				new object();
			}

			NoteName root = null;
			if (success)
			{
				success = false;
				try
				{
					if (TryParseNoteName(match, out root))
						success = true;
				}
				catch (Exception ex)
				{
					throw;
				}
			}

			var chordType = ChordType.None;
			if (success)
			{
				try
				{
					success = false;
					if (TryParseChordType(match, out chordType, out string error))
						success = true;
					else
						message = error;
				}
				catch (NotSupportedException ex)
				{
					message = $"Unsupported chord type ({ex.Message})";
				}
				catch (Exception ex)
				{
					throw;
				}
			}

			if (success)
			{
				if (null == key)
					key = KeySignature.Catalog.First(x => x.NoteName.Name == root.Name);
				var formula = new ChordFormula(root, chordType, key);
				chord = new Chord(formula, NoteRange.Default);
			}

			if (success)
				result = true;

			return result;
		}

		static void foo()
		{
			//var result = new List<string>();
			//result = input.Split(new string[] { "|"}, StringSplitOptions.RemoveEmptyEntries).ToList();

			//result.ForEach(x => Debug.WriteLine($"case \"{x.Trim()}\": \r\n break;"));
			//NoteName.Catalog.ForEach(x => Debug.WriteLine($"case \"{x.ToString().ToLower()}\": \r\n break;"));


			var result = new List<string>();
			String chords =
			@"(maj|maj7|maj9|maj11|maj13|maj9#11|maj13#11|6|add9|maj7b5|maj7#5|min|-7|-|m7|m9|m11|m13|
m6 | madd9 | m6add9 | mmaj7 | mmaj9 | m7b5 | m7#5|7|9|11|13|7sus4|7b5|7#5|7b9|7#9|7b5b9|7b5#9|
7#5b9|9#5|13#11|13b9|11b9|aug|\+|dim|dim7|sus4|sus2|sus2sus4|-5|)";

			chords = chords.TrimStart('(');
			chords = chords.TrimEnd(')');

			result = chords.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			var seq1 = result.Select(x => x = x.Trim());
			var seq = seq1.OrderByDescending(x => x.Length);

			Debug.WriteLine(string.Join("|", seq));

		}

		static bool TryParseNoteName(Match match, out NoteName noteName)
		{
			var note = match.Groups[NOTE].ToString();
			var accidental = match.Groups[ACCIDENTAL].ToString();
			var input = note + accidental;

			noteName = null;
			var result = false;

			#region switch (input)
			switch (input)
			{
				case "b♯":
				case "b#":
					noteName = NoteName.BSharp;
					break;
				case "c":
					noteName = NoteName.C;
					break;
				case "c♯":
				case "c#":
					noteName = NoteName.CSharp;
					break;
				case "db":
				case "d♭":
					noteName = NoteName.Db;
					break;
				case "d":
					noteName = NoteName.D;
					break;
				case "d#":
				case "d♯":
					noteName = NoteName.DSharp;
					break;
				case "eb":
				case "e♭":
					noteName = NoteName.Eb;
					break;
				case "e":
					noteName = NoteName.E;
					break;
				case "fb":
				case "f♭":
					noteName = NoteName.Fb;
					break;
				case "e#":
				case "e♯":
					noteName = NoteName.ESharp;
					break;
				case "f":
					noteName = NoteName.F;
					break;
				case "f#":
				case "f♯":
					noteName = NoteName.FSharp;
					break;
				case "gb":
				case "g♭":
					noteName = NoteName.Gb;
					break;
				case "g":
					noteName = NoteName.G;
					break;
				case "g#":
				case "g♯":
					noteName = NoteName.GSharp;
					break;
				case "ab":
				case "a♭":
					noteName = NoteName.Ab;
					break;
				case "a":
					noteName = NoteName.A;
					break;
				case "a#":
				case "a♯":
					noteName = NoteName.ASharp;
					break;
				case "bb":
				case "b♭":
					noteName = NoteName.Bb;
					break;
				case "b":
					noteName = NoteName.B;
					break;
				case "cb":
				case "c♭":
					noteName = NoteName.Cb;
					break;
				default:
					throw new NotSupportedException(input);
			}
			#endregion

			if (null != noteName)
				result = true;
			return result;

		}

		static bool TryParseChordType(Match match, out ChordType ct, out string message)
		{
			message = null;
			var input = match.Groups[CHORD_TYPE].ToString();
			//var bassNote = match.Groups[BASS].ToString();


			ct = ChordType.None;
			bool result = false;

			#region switch (input)
			switch (input)
			{
				case "maj":
					ct = ChordType.Major;
					break;
				case "maj7":
					ct = ChordType.Major7th;
					break;
				case "maj9":
					break;
				case "maj11":
					break;
				case "maj13":
					break;
				case "maj9#11":
					break;
				case "maj13#11":
					break;
				case "6":
					break;
				case "add9":
					break;
				case "maj7b5":
					break;
				case "maj7#5":
					break;
				case "min":
				case "m":
				case "-":
					ct = ChordType.Minor;
					break;
				case "m7":
				case "-7":
					ct = ChordType.Minor7th;
					break;
				case "m9":
					break;
				case "m11":
					break;
				case "m13":
					break;
				case "m6":
					break;
				case "madd9":
					break;
				case "m6add9":
					break;
				case "mmaj7":
					break;
				case "mmaj9":
					break;
				case "-7b5":
				case "m7b5":
					ct = ChordType.HalfDiminished;
					break;
				case "m7#5":
					break;
				case "7":
					ct = ChordType.Dominant7th;
					break;
				case "9":
					break;
				case "11":
					break;
				case "13":
					break;
				case "7sus4":
					break;
				case "7b5":
					break;
				case "7#5":
					break;
				case "7b9":
					break;
				case "7#9":
					break;
				case "7b5b9":
					break;
				case "7b5#9":
					break;
				case "7#5b9":
					break;
				case "9#5":
					break;
				case "13#11":
					break;
				case "13b9":
					break;
				case "11b9":
					break;
				case "aug":
				case "+":
					ct = ChordType.Augmented;
					break;
				case "dim":
					ct = ChordType.Diminished;
					break;
				case "dim7":
					ct = ChordType.Diminished7;
					break;
				case "sus4":
					break;
				case "sus2":
					break;
				case "sus2sus4":
					break;
				case "-5":
					break;
				default:
					throw new NotSupportedException(input);
			}

			#endregion

			if (ct != ChordType.None)
				result = true;
			if (!result)
			{
				message = $"Unsupported chord type ({input})";
			}
			return result;
		}



	}
}

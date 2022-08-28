using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Eric.Morrison.Harmony.Chords
{
	[Obsolete("", true)]
	public static class ChordParser
	{
		//const int NOTE = 1;
		//const int ACCIDENTAL = 2;
		//const int CHORD_TYPE = 3;
		//const int BASS = 4;
		const int NDX_ROOT = 1;
		const int NDX_ROOT_ACCIDENTAL = 2;
		const int NDX_CHORD_TYPE = 3;
		const int NDX_BASS = 4;
		const int NDX_BASS_ACCIDENTAL = 5;

		static string REGEX;

		static ChordParser()
		{

			String notes = "^([cdefgab])";
			String accidentals = "(#|##|b|bb)?";
			String chordTypes =
				@"(maj13#11|sus2sus4|maj9#11|maj7b5|maj7#5|m6add9|maj11|maj13|madd9|mmaj7|mmaj9|7sus4|7b5b9|7b5#9|7#5b9|13#11|maj7|maj9|add9|-7b5|m7b5|m7#5|13b9|11b9|dim7|sus4|sus2|maj|min|m11|m13|7b5|7#5|7b9|7#9|9#5|aug|dim|-7|m7|m9|m6|11|13|\+|-5|6|-|7|9|m|)";
			//@"(maj13#11|sus2sus4|maj9#11|maj7b5|maj7#5|m6add9|maj11|maj13|madd9|mmaj7|mmaj9|7sus4|7b5b9|7b5#9|7#5b9|13#11|maj7|maj9|add9|-7b5|m7b5|m7#5|13b9|11b9|dim7|sus4|sus2|maj|min|m11|m13|7b5|7#5|7b9|7#9|9#5|aug|dim|-7|m7|m9|m6|11|13|\+|-5|6|-|7|9|m||)";
			String bass = "?[\\/]?([cdefgab])?";

			REGEX = notes + accidentals + chordTypes + bass + accidentals;
		}


#if false
^[A-G](b|#)?((m(aj)?|M|aug|dim|sus)([2-7]|9|13)?)?(\/[A-G](b|#)?)?$

#endif
		static public bool TryParse(string input, out List<Chord> chords, out string messageResult)
		{
			//Debug.WriteLine(REGEX);
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

		static bool TryParseFormulas(string input, out List<ChordFormula> formulas, out string message, KeySignature key = null)
		{
			var result = false;
			message = string.Empty;
			formulas = new List<ChordFormula>();

			var strings = PreProcess(input);

			foreach (var s in strings)
			{
				if (TryParseImpl(s, out ChordFormula formula, out message, key))
				{
					formulas.Add(formula);
				}
				else
				{
					break;
				}
			}

			return result;
		}


		static bool TryParseImpl(string input, out ChordFormula chordFormula, out string message, KeySignature key = null)
		{
			var result = false;
			message = null;
			chordFormula = null;


			NoteName root = null;
			NoteName bass = null;
			var chordType = ChordType.None;
			bool success = false;
			// Debug.WriteLine(input);
			var match = Regex.Match(input, REGEX);
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
						if (ChordType.None == chordType)
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

			if (success)
			{
				if (null == key)
					key = KeySignature.Catalog.First(x => x.NoteName.Name == root.Name);
				chordFormula = new ChordFormula(root, chordType, key);
				if (null != bass)
					chordFormula.SetBassNote(bass);
			}

			if (success)
				result = true;

			return result;
		}

		static bool TryParseImpl(string input, out Chord chord, out string message, KeySignature key = null)
		{
			var result = false;
			message = null;
			chord = null;

			var success = TryParseImpl(input, out ChordFormula formula, out message, key);
			if (success)
			{
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

		static ChordType ParseChordType(string input, out string message)
		{
			message = null;
			var result = ChordType.None;

			#region switch (input)
			switch (input)
			{
				#region Major chords
				case "":
				case "maj":
					result = ChordType.Major;
					break;
				case "6":
					result = ChordType.Major6th;
					break;
				case "maj7":
					result = ChordType.Major7th;
					break;
				case "maj9":
					result = ChordType.Major9th;
					break;
				case "maj11":
					result = ChordType.Major11th;
					break;
				case "maj13":
					result = ChordType.Major13th;
					break;
				#endregion


				case "maj9#11":
					break;
				case "maj13#11":
					break;
				case "add9":
					result = ChordType.MajorAdd9;
					break;
				case "maj7b5":
					result = ChordType.Major7b5;
					break;
				case "maj7#5":
					break;


				#region Minor chords
				case "min":
				case "m":
				case "-":
					result = ChordType.Minor;
					break;
				case "m6":
					result = ChordType.Minor6th;
					break;
				case "m7":
				case "-7":
					result = ChordType.Minor7th;
					break;
				case "m9":
					result = ChordType.Minor9th;
					break;
				case "m11":
					result = ChordType.Minor11th;
					break;
				case "m13":
					result = ChordType.Minor13th;
					break;
				#endregion


				case "madd9":
					result = ChordType.MinorAdd9;
					break;
				case "m6add9":
					break;
				case "mmaj7":
					result = ChordType.MinorMaj7th;
					break;
				case "mmaj9":
					break;


				case "-7b5":
				case "m7b5":
					result = ChordType.HalfDiminished;
					break;
				case "m7#5":
					break;


				#region Diatonic Dominant chords
				case "7":
					result = ChordType.Dominant7th;
					break;
				case "9":
					result = ChordType.Dominant9th;
					break;
				case "11":
					result = ChordType.Dominant11th;
					break;
				case "13":
					result = ChordType.Dominant13th;
					break;

				#endregion


				case "7b5":
					break;
				case "7#5":
					break;
				case "7b9":
					result = ChordType.Dominant7b9;
					break;
				case "7#9":
					result = ChordType.Dominant7Sharp9;
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
					result = ChordType.Augmented;
					break;
				case "dim":
					result = ChordType.Diminished;
					break;
				case "dim7":
					result = ChordType.Diminished7;
					break;

				case "sus4":
					result = ChordType.Sus4;
					break;
				case "sus2":
					result = ChordType.Sus2;
					break;
				case "sus2sus4":
					result = ChordType.Sus2Sus4;
					break;
				case "7sus4":
					result = ChordType.SevenSus4;
					break;


				case "-5":
					break;
				default:
					throw new NotSupportedException(input);
			}

			#endregion

			if (result == ChordType.None)
			{
				message = $"Unsupported chord type ({input})";
				Debug.WriteLine($"{input}");
			}
			return result;
		}



	}

	public static class ChordFormulaParser
	{
		//const int NOTE = 1;
		//const int ACCIDENTAL = 2;
		//const int CHORD_TYPE = 3;
		//const int BASS = 4;
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
				@"(maj13#11|sus2sus4|maj9#11|maj7b5|maj7#5|m6add9|maj11|maj13|madd9|mmaj7|mmaj9|7sus4|7b5b9|7b5#9|7#5b9|13#11|maj7|maj9|add9|-7b5|m7b5|m7#5|13b9|11b9|dim7|sus4|sus2|maj|min|m11|m13|7b5|7#5|7b9|7#9|9#5|aug|dim|-7|m7|m9|m6|11|13|\+|-5|6|-|7|9|m|)";
			//@"(maj13#11|sus2sus4|maj9#11|maj7b5|maj7#5|m6add9|maj11|maj13|madd9|mmaj7|mmaj9|7sus4|7b5b9|7b5#9|7#5b9|13#11|maj7|maj9|add9|-7b5|m7b5|m7#5|13b9|11b9|dim7|sus4|sus2|maj|min|m11|m13|7b5|7#5|7b9|7#9|9#5|aug|dim|-7|m7|m9|m6|11|13|\+|-5|6|-|7|9|m||)";
			String bass = "?[\\/]?([cdefgab])?";

			REGEX = notes + accidentals + chordTypes + bass + accidentals;
		}


#if false
^[A-G](b|#)?((m(aj)?|M|aug|dim|sus)([2-7]|9|13)?)?(\/[A-G](b|#)?)?$

#endif
		//static public bool TryParse(string input, out List<Chord> chords, out string messageResult)
		//{
		//	//Debug.WriteLine(REGEX);
		//	return TryParse(input, null, out chords, out messageResult);
		//}

		//static public bool TryParse(string input, KeySignature key, out List<Chord> chords, out string messageResult)
		//{
		//	//foo();

		//	var result = false;
		//	messageResult = string.Empty;
		//	chords = new List<Chord>();

		//	var strings = PreProcess(input);

		//	var success = false;
		//	foreach (var incoming in strings)
		//	{
		//		success = TryParseImpl(incoming, out Chord chord, out string message, key);
		//		if (success)
		//		{
		//			chords.Add(chord);
		//		}
		//		else
		//		{
		//			messageResult = message;
		//			break;
		//		}
		//	}
		//	if (success)
		//		result = true;

		//	return result;
		//}

		static List<string> PreProcess(string input)
		{
			var result = new List<string>();
			input = input.ToLower();
			result = input.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			result.RemoveAll(x => "nc" == x);
			return result;
		}

		static public bool TryParse(string input, out KeySignature key, out List<ChordFormula> formulas, out string message)
		{
			var result = false;
			key = null;
			message = string.Empty;
			formulas = new List<ChordFormula>();

			var strings = PreProcess(input);

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

			if (KeySignature.TryDetermineKey(formulas,
							out var matchedKey,
							out var probableKey))
			{ 
				key = matchedKey;
			}
			else 
			{
				key = probableKey;
			}

			return result;
		}

		static bool TryParseImpl(KeySignature key, string input, out ChordFormula chordFormula, out string message)
		{
			var result = false;
			message = null;
			chordFormula = null;


			NoteName root = null;
			NoteName bass = null;
			var chordType = ChordType.None;
			bool success = false;
			// Debug.WriteLine(input);
			var match = Regex.Match(input, REGEX);
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
						if (ChordType.None == chordType)
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

			if (success)
			{
				if (null == key)
					key = KeySignature.Catalog.First(x => x.NoteName.Name == root.Name);
				chordFormula = new ChordFormula(root, chordType, key);
				if (null != bass)
					chordFormula.SetBassNote(bass);
			}

			if (success)
				result = true;

			return result;
		}

		static bool TryParseImpl(string input, out Chord chord, out string message, KeySignature key = null)
		{
			var result = false;
			message = null;
			chord = null;

			var success = TryParseImpl(key, input, out ChordFormula formula, out message);
			if (success)
			{
				chord = new Chord(formula, NoteRange.Default);
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

		static ChordType ParseChordType(string input, out string message)
		{
			message = null;
			var result = ChordType.None;

			#region switch (input)
			switch (input)
			{
				#region Major chords
				case "":
				case "maj":
					result = ChordType.Major;
					break;
				case "6":
					result = ChordType.Major6th;
					break;
				case "maj7":
					result = ChordType.Major7th;
					break;
				case "maj9":
					result = ChordType.Major9th;
					break;
				case "maj11":
					result = ChordType.Major11th;
					break;
				case "maj13":
					result = ChordType.Major13th;
					break;
				#endregion


				case "maj9#11":
					break;
				case "maj13#11":
					break;
				case "add9":
					result = ChordType.MajorAdd9;
					break;
				case "maj7b5":
					result = ChordType.Major7b5;
					break;
				case "maj7#5":
					break;


				#region Minor chords
				case "min":
				case "m":
				case "-":
					result = ChordType.Minor;
					break;
				case "m6":
					result = ChordType.Minor6th;
					break;
				case "m7":
				case "-7":
					result = ChordType.Minor7th;
					break;
				case "m9":
					result = ChordType.Minor9th;
					break;
				case "m11":
					result = ChordType.Minor11th;
					break;
				case "m13":
					result = ChordType.Minor13th;
					break;
				#endregion


				case "madd9":
					result = ChordType.MinorAdd9;
					break;
				case "m6add9":
					break;
				case "mmaj7":
					result = ChordType.MinorMaj7th;
					break;
				case "mmaj9":
					break;


				case "-7b5":
				case "m7b5":
					result = ChordType.HalfDiminished;
					break;
				case "m7#5":
					break;


				#region Diatonic Dominant chords
				case "7":
					result = ChordType.Dominant7th;
					break;
				case "9":
					result = ChordType.Dominant9th;
					break;
				case "11":
					result = ChordType.Dominant11th;
					break;
				case "13":
					result = ChordType.Dominant13th;
					break;

				#endregion


				case "7b5":
					break;
				case "7#5":
					break;
				case "7b9":
					result = ChordType.Dominant7b9;
					break;
				case "7#9":
					result = ChordType.Dominant7Sharp9;
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
					result = ChordType.Augmented;
					break;
				case "dim":
					result = ChordType.Diminished;
					break;
				case "dim7":
					result = ChordType.Diminished7;
					break;

				case "sus4":
					result = ChordType.Sus4;
					break;
				case "sus2":
					result = ChordType.Sus2;
					break;
				case "sus2sus4":
					result = ChordType.Sus2Sus4;
					break;
				case "7sus4":
					result = ChordType.SevenSus4;
					break;


				case "-5":
					break;
				default:
					throw new NotSupportedException(input);
			}

			#endregion

			if (result == ChordType.None)
			{
				message = $"Unsupported chord type ({input})";
				Debug.WriteLine($"{input}");
			}
			return result;
		}

	}//class
}//ns

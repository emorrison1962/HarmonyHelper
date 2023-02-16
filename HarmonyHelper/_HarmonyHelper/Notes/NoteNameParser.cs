using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.Notes
{
	public class NoteNameParser
	{
		const int NDX_NOTE = 1;
		const int NDX_NOTE_ACCIDENTAL = 2;
		static string REGEX;

		
		static NoteNameParser()
		{
			String notes = "^([cdefgab])";
			String accidentals = "(#|##|b|bb)?";
			REGEX = notes + accidentals;
		}

		static public bool TryParse(string input, out List<NoteName> notes, out string message)
		{
			var result = false;
			message = string.Empty;
			notes = new List<NoteName>();

			var strings = PreParse(input);

			var successCount = 0;
			foreach (var s in strings)
			{
				if (TryParseImpl(s, out var nn, out message))
				{
					notes.Add(nn);
					++successCount;
				}
				else
				{
					break;
				}
			}
			if (string.IsNullOrEmpty(message))
				result = true;

			return result;
		}

		static List<string> PreParse(string input)
		{
			var result = new List<string>();
			input = input.ToLower();
			result = input.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
			return result;
		}

		static bool TryParseImpl(string input, out NoteName nn, out string message)
		{
			var result = false;
			message = null;
			nn = null;

			bool success = false;
			// Debug.WriteLine(input);
			var match = Regex.Match(input, REGEX);
			try
			{
				if (match.Success)
				{
					if (match.Groups[NDX_NOTE].Success)
					{
						var note = match.Groups[NDX_NOTE].ToString();
						var accidental = string.Empty;
						if (match.Groups[NDX_NOTE_ACCIDENTAL].Success)
							accidental = match.Groups[NDX_NOTE_ACCIDENTAL].ToString();

						var noteStr = note + accidental;
						nn = ParseNoteName(noteStr);
					}

					success = true;
				}
				else
				{
					message = $"Error parsing NoteName: \"{input}\"";
					new object();
				}
			}
			catch (Exception ex)
			{
				throw;
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
	}//class

}//ns

﻿using System;
using System.Collections.Generic;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Scales
{
	public class MelodicMinorModalScaleFormula : ModalScaleFormulaBase
	{
		override public string ModeName { get { return this.GetModeName(); } }

		public MelodicMinorModalScaleFormula(KeySignature key, ModeEnum mode) : base(key, mode)
		{
			this.Name = this.GetModeName();
		}

		protected override void Init()
		{
			base.InitImpl();
		}

		protected override void PopulateIntervals()
		{
			var result = new List<ScaleToneInterval>();
			switch (this.Mode)
			{

				case ModeEnum.Ionian:
					result.AddRange(new[] {
						ScaleToneInterval.Major2nd,
						ScaleToneInterval.Minor3rd,
						ScaleToneInterval.Perfect4th,
						ScaleToneInterval.Perfect5th,
						ScaleToneInterval.Major6th,
						ScaleToneInterval.Major7th, });
					break;
				case ModeEnum.Dorian:
					result.AddRange(new[] {
						ScaleToneInterval.Minor2nd,
						ScaleToneInterval.Minor3rd,
						ScaleToneInterval.Perfect4th,
						ScaleToneInterval.Perfect5th,
						ScaleToneInterval.Major6th,
						ScaleToneInterval.Minor7th, });
					break;
				case ModeEnum.Phrygian:
					result.AddRange(new[] {
						ScaleToneInterval.Major2nd,
						ScaleToneInterval.Major3rd,
						ScaleToneInterval.Augmented4th,
						ScaleToneInterval.Augmented5th,
						ScaleToneInterval.Major6th,
						ScaleToneInterval.Major7th, });
					break;
				case ModeEnum.Lydian:
					result.AddRange(new[] {
						ScaleToneInterval.Major2nd,
						ScaleToneInterval.Major3rd,
						ScaleToneInterval.Augmented4th,
						ScaleToneInterval.Perfect5th,
						ScaleToneInterval.Major6th,
						ScaleToneInterval.Minor7th, });
					break;
				case ModeEnum.Mixolydian:
					result.AddRange(new[] {
						ScaleToneInterval.Major2nd,
						ScaleToneInterval.Major3rd,
						ScaleToneInterval.Perfect4th,
						ScaleToneInterval.Perfect5th,
						ScaleToneInterval.Minor6th,
						ScaleToneInterval.Minor7th, });
					break;
				case ModeEnum.Aeolian:
					result.AddRange(new[] {
						ScaleToneInterval.Major2nd,
						ScaleToneInterval.Minor3rd,
						ScaleToneInterval.Perfect4th,
						ScaleToneInterval.Diminished5th,
						ScaleToneInterval.Minor6th,
						ScaleToneInterval.Minor7th, });
					break;
				case ModeEnum.Locrian:
					result.AddRange(new[] {
						ScaleToneInterval.Minor2nd,
						ScaleToneInterval.Minor3rd,
						ScaleToneInterval.Diminished4th,
						ScaleToneInterval.Diminished5th,
						ScaleToneInterval.Minor6th,
						ScaleToneInterval.Minor7th, });
					break;

			}
			this.Intervals = result;
		}
		protected override ScaleToneInterval GetDistanceFromKeyRoot(ModeEnum mode)
		{
			var result = ScaleToneInterval.Root;
			switch (mode)
			{
				case ModeEnum.Ionian:
					result = ScaleToneInterval.Root;
					break;
				case ModeEnum.Dorian:
					result = ScaleToneInterval.Major2nd;
					break;
				case ModeEnum.Phrygian:
					result = ScaleToneInterval.Minor3rd;
					break;
				case ModeEnum.Lydian:
					result = ScaleToneInterval.Perfect4th;
					break;
				case ModeEnum.Mixolydian:
					result = ScaleToneInterval.Perfect5th;
					break;
				case ModeEnum.Aeolian:
					result = ScaleToneInterval.Major6th;
					break;
				case ModeEnum.Locrian:
					result = ScaleToneInterval.Major7th;
					break;
				default:
					throw new ArgumentOutOfRangeException();
					break;
			}
			return result;
		}

		public override string ToString()
		{
			var result = string.Empty;
			result = $"{this.NoteNames[0]} {this.GetModeName()} {string.Join(",", this.NoteNames)}";
			return result;
		}


		const string IONIAN_NAME = "Melodic Minor";
		const string DORIAN_NAME = "Phrygian #6";
		const string PHRYGIAN_NAME = "Lydian Augmented";
		const string LYDIAN_NAME = "Overtone Scale";
		const string MIXOLYDIAN_NAME = "Mixolydian b6";
		const string AEOLIAN_NAME = "Locrian #2";
		const string LOCRIAN_NAME = "Altered Scale";

		string GetModeName()
		{
			string result = null;
			switch (this.Mode)
			{
				case ModeEnum.Ionian:
					result = IONIAN_NAME;
					break;
				case ModeEnum.Dorian:
					result = DORIAN_NAME;
					break;
				case ModeEnum.Phrygian:
					result = PHRYGIAN_NAME;
					break;
				case ModeEnum.Lydian:
					result = LYDIAN_NAME;
					break;
				case ModeEnum.Mixolydian:
					result = MIXOLYDIAN_NAME;
					break;
				case ModeEnum.Aeolian:
					result = AEOLIAN_NAME;
					break;
				case ModeEnum.Locrian:
					result = LOCRIAN_NAME;
					break;
				default:
					throw new ArgumentOutOfRangeException();
					break;
			}
			result = $"Melodic Minor {result}";
			return result;
		}

	}//class

}

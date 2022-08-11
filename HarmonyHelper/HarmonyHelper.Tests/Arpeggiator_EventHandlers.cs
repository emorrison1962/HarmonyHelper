using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eric.Morrison.Harmony.Arpeggiator;

namespace Eric.Morrison.Harmony.Tests
{
	public partial class ArpeggiatorTests
	{
		void RegisterEventHandlers(Arpeggiator arpeggiator)
		{
            arpeggiator.Starting += Arpeggiator_Starting;
            arpeggiator.ChordChanging += Arpeggiator_ChordChanging;
            arpeggiator.ChordChanged += Arpeggiator_ChordChanged;
            arpeggiator.ArpeggiationContextChanging += Arpeggiator_ArpeggiationContextChanging;
            arpeggiator.ArpeggiationContextChanged += Arpeggiator_ArpeggiationContextChanged;
            arpeggiator.CurrentNoteChanging += Arpeggiator_CurrentNoteChanging;
            arpeggiator.CurrentNoteChanged += Arpeggiator_CurrentNoteChanged;
            arpeggiator.DirectionChanging += Arpeggiator_DirectionChanging;
            arpeggiator.DirectionChanged += Arpeggiator_DirectionChanged;
            arpeggiator.Ending += Arpeggiator_Ending;
        }

        private void Arpeggiator_Starting(object sender, ArpeggiatorEventArgs args)
		{
			Debug.Write("||");
		}

		DirectionEnum? _lastDirection;
		int _chordCount = 0;
		const int BARS_PER_LINE = 2;

		private void Arpeggiator_ArpeggiationContextChanging(object sender, ArpeggiationContextChangingEventArgs args)
		{
			//Debug.Write("|");
		}
		private void Arpeggiator_ArpeggiationContextChanged(object sender, ArpeggiatorEventArgs args)
		{
			//if (_chordCount > 0 && _chordCount % BARS_PER_LINE == 0)
			//	Debug.WriteLine(" |");
			//Debug.Write(string.Format(" | "));
		}


		private void Arpeggiator_ChordChanging(object sender, ChordChangingEventArgs args)
		{
            if (_chordCount > 0 && _chordCount % BARS_PER_LINE == 0)
                Debug.WriteLine(" |");

			if (_chordCount > 0)
				Debug.Write(" | ");
            //++_chordCount;
		}
		private void Arpeggiator_ChordChanged(object sender, ArpeggiatorEventArgs args)
		{
			var ctx = args.Arpeggiator;
			Debug.Write(string.Format("{0,5} ", "(" + ctx.CurrentChord.Name + ")"));
			++_chordCount;
		}


		private void Arpeggiator_CurrentNoteChanging(object sender, NoteChangingEventArgs args)
		{
			//Debug.Write(noteStr);
		}
		private void Arpeggiator_CurrentNoteChanged(object sender, ArpeggiatorEventArgs args)
		{
			var ctx = args.Arpeggiator;
			if (null != this.noteRangeUsageStatistics)
				this.noteRangeUsageStatistics.AddReference(ctx.CurrentNote);
			var directionChanged = true;
			if (_lastDirection.HasValue)
			{
				if (_lastDirection.Value == ctx.Direction)
				{
					directionChanged = false;
				}
			}
			_lastDirection = ctx.Direction;

			var noteStr = ctx.CurrentNote.ToString();
			if (!directionChanged)
			{
				noteStr = string.Format(" {0,-2}", noteStr);
			}
			else
			{
				noteStr = string.Format("{0,-2}", noteStr);
			}
			Debug.Write(noteStr);
		}

		private void Arpeggiator_DirectionChanging(object sender, DirectionChangingEventArgs args)
		{
			const string ASC = "˄";
			const string DESC = "˅";

			//var direction = args.Next == DirectionEnum.Ascending ? ASC : DESC;
			//Debug.Write(direction);
		}
		private void Arpeggiator_DirectionChanged(object sender, ArpeggiatorEventArgs args)
		{
			const string ASC = "˄";
			const string DESC = "˅";

			var direction = ctx.Direction == DirectionEnum.Ascending ? ASC : DESC;
			Debug.Write(direction);
		}

		private void Arpeggiator_Ending(object sender, ArpeggiatorEventArgs args)
		{
			Debug.WriteLine("||");
		}


	}//class
}//ns

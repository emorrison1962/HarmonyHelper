using System;
using System.Collections.Generic;
using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public interface IHarmonyModel
	{
		List<HarmonyModelItem> Items { get; set; }
		KeySignature KeySignature { get; set; }
		List<NoteName> NoteNames { get; }

		event EventHandler<HarmonyModel> ModelChanged;
	}
}
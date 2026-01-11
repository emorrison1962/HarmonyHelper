using System;
using System.Collections.Generic;
using System.Runtime.Caching;

using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public interface IHarmonyContext
	{
		List<HarmonyModelItem> Items { get; set; }
		KeySignature KeySignature { get; set; }
		List<NoteName> NoteNames { get; }
	}
}
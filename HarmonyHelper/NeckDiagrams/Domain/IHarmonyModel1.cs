using System;
using System.Collections.Generic;
using System.Runtime.Caching;

using Eric.Morrison.Harmony;

namespace NeckDiagrams
{
	public interface IHarmonyContext<T> where T : INoteNameContainer
    {
		KeySignature KeySignature { get; set; }
		List<NoteName> NoteNames { get; }
        T Value { get; }

    }
}
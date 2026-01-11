using System;
using System.Collections.Generic;
using System.Text;

namespace NeckDiagrams.Domain
{
    [Flags]
    public enum NoteTypeEnum
    {
        None = 0,
        ChordTone = 1,
        ScaleTone = 1 << 1
    }

    [Obsolete("")]
    [Flags]
    public enum ModelItemTypeEnum
    {
        Scale = 1,
        Arpeggio = 1 << 2,
        //Chord = 1 << 3
    }



}//ns

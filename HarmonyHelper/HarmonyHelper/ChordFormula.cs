using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public class ChordFormula
    {
        #region Chords
        static public readonly ChordFormula C7;
        static public readonly ChordFormula F7;
        static public readonly ChordFormula Bb7;
        static public readonly ChordFormula Eb7;
        static public readonly ChordFormula Ab7;
        static public readonly ChordFormula Db7;
        static public readonly ChordFormula Gb7;
        static public readonly ChordFormula B7;
        static public readonly ChordFormula E7;
        static public readonly ChordFormula A7;
        static public readonly ChordFormula D7;
        static public readonly ChordFormula G7;
        #endregion

        #region Properties
        static public List<ChordFormula> Chords { get; private set; } = new List<ChordFormula>();

        public NoteName Root { get; set; }
        public NoteName Third { get; set; }
        public NoteName Fifth { get; set; }
        public NoteName Seventh { get; set; }
        public KeySignature KeySignature { get; set; }
        public ChordTypesEnum ChordType { get; set; }
        public ChordFunctionEnum ChordFunction { get; set; }

        #endregion

        #region Construction
        static ChordFormula()
        {
            var dominant7th = ChordTypesEnum.Dominant7th;
            var dominant = ChordFunctionEnum.V;
            Chords.Add(C7 = new ChordFormula(NoteName.C, dominant7th, dominant, KeySignature.FMajor));
            Chords.Add(F7 = new ChordFormula(NoteName.F, dominant7th, dominant, KeySignature.BbMajor));
            Chords.Add(Bb7 = new ChordFormula(NoteName.Bb, dominant7th, dominant, KeySignature.EbMajor));
            Chords.Add(Eb7 = new ChordFormula(NoteName.Eb, dominant7th, dominant, KeySignature.AbMajor));
            Chords.Add(Ab7 = new ChordFormula(NoteName.Ab, dominant7th, dominant, KeySignature.DbMajor));
            Chords.Add(Db7 = new ChordFormula(NoteName.Db, dominant7th, dominant, KeySignature.GbMajor));

#warning Gb dominant does not have sharped key signature.
            Chords.Add(Gb7 = new ChordFormula(NoteName.Gb, dominant7th, dominant, KeySignature.BMajor));


            Chords.Add(B7 = new ChordFormula(NoteName.B, dominant7th, dominant, KeySignature.EMajor));
            Chords.Add(E7 = new ChordFormula(NoteName.E, dominant7th, dominant, KeySignature.AMajor));
            Chords.Add(A7 = new ChordFormula(NoteName.A, dominant7th, dominant, KeySignature.DMajor));
            Chords.Add(D7 = new ChordFormula(NoteName.D, dominant7th, dominant, KeySignature.GMajor));
            Chords.Add(G7 = new ChordFormula(NoteName.G, dominant7th, dominant, KeySignature.CMajor));
        }

        //private ChordFormula(params NotesEnum[] notes)
        //{
        //    this.Root = notes[0];
        //    this.Third = notes[1];
        //    this.Fifth = notes[2];
        //    this.Seventh = notes[3];
        //}

        private ChordFormula(NoteName root, ChordTypesEnum chordType, 
            ChordFunctionEnum chordFunction, KeySignature keySignature)
        {
            this.KeySignature = keySignature;
            this.ChordType = chordType;
            this.ChordFunction = chordFunction;

            this.Root = root;
            var interval = chordType.GetThird();
            this.Third = NotesCollection.Get(root, interval);

            interval = chordType.GetFifth();
            this.Fifth = NotesCollection.Get(root, interval);

            interval = chordType.GetSeventh();
            this.Seventh = NotesCollection.Get(root, interval);
        }


        #endregion

        public static ChordFormula operator +(ChordFormula chord, IntervalsEnum interval)
        {
            var txedRoot = NotesCollection.Get(chord.Root, interval);
            var txedKey = KeySignatureCollection.Get(chord.KeySignature, interval);

            var result = new ChordFormula(txedRoot, chord.ChordType, chord.ChordFunction, txedKey);
            return result;
        }

        public static ChordFormula operator -(ChordFormula chord, IntervalsEnum interval)
        {
            var txedRoot = NotesCollection.Get(chord.Root, interval, DirectionEnum.Descending);
            var txedKey = KeySignatureCollection.Get(chord.KeySignature, interval, DirectionEnum.Descending);

            var result = new ChordFormula(txedRoot, chord.ChordType, chord.ChordFunction, txedKey);
            return result;
        }

        public override string ToString()
        {
            var r = this.Root.ToString();
            var third = this.Third.ToString();
            var fifth = this.Fifth.ToString();
            var seventh = this.Seventh.ToString();

            var result = string.Format("{0},{1},{2},{3}", r, third, fifth, seventh);
            return result;
        }

    }//class
}//ns

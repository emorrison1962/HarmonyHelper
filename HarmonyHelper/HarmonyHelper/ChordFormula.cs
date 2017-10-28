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

        public NotesEnum Root { get; set; }
        public NotesEnum Third { get; set; }
        public NotesEnum Fifth { get; set; }
        public NotesEnum Seventh { get; set; }
        public KeySignatureEnum KeySignature { get; set; }
        public ChordTypesEnum ChordType { get; set; }
        public ChordFunctionEnum ChordFunction { get; set; }

        #endregion

        #region Construction
        static ChordFormula()
        {
            var dominant7th = ChordTypesEnum.Dominant7th;
            var dominant = ChordFunctionEnum.V;
            Chords.Add(C7 = new ChordFormula(NotesEnum.C, dominant7th, dominant, KeySignatureEnum.FMajor));
            Chords.Add(F7 = new ChordFormula(NotesEnum.F, dominant7th, dominant, KeySignatureEnum.BbMajor));
            Chords.Add(Bb7 = new ChordFormula(NotesEnum.Bb, dominant7th, dominant, KeySignatureEnum.EbMajor));
            Chords.Add(Eb7 = new ChordFormula(NotesEnum.Eb, dominant7th, dominant, KeySignatureEnum.AbMajor));
            Chords.Add(Ab7 = new ChordFormula(NotesEnum.Ab, dominant7th, dominant, KeySignatureEnum.DbMajor));
            Chords.Add(Db7 = new ChordFormula(NotesEnum.Db, dominant7th, dominant, KeySignatureEnum.GbMajor));

#warning Gb dominant does not have sharped key signature.
            Chords.Add(Gb7 = new ChordFormula(NotesEnum.Gb, dominant7th, dominant, KeySignatureEnum.BMajor));


            Chords.Add(B7 = new ChordFormula(NotesEnum.B, dominant7th, dominant, KeySignatureEnum.EMajor));
            Chords.Add(E7 = new ChordFormula(NotesEnum.E, dominant7th, dominant, KeySignatureEnum.AMajor));
            Chords.Add(A7 = new ChordFormula(NotesEnum.A, dominant7th, dominant, KeySignatureEnum.DMajor));
            Chords.Add(D7 = new ChordFormula(NotesEnum.D, dominant7th, dominant, KeySignatureEnum.GMajor));
            Chords.Add(G7 = new ChordFormula(NotesEnum.G, dominant7th, dominant, KeySignatureEnum.CMajor));
        }

        //private ChordFormula(params NotesEnum[] notes)
        //{
        //    this.Root = notes[0];
        //    this.Third = notes[1];
        //    this.Fifth = notes[2];
        //    this.Seventh = notes[3];
        //}

        private ChordFormula(NotesEnum root, ChordTypesEnum chordType, 
            ChordFunctionEnum chordFunction, KeySignatureEnum keySignature)
        {
            this.KeySignature = keySignature;
            this.ChordType = chordType;
            this.ChordFunction = chordFunction;

            this.Root = root;
            var interval = chordType.Get3rd();
            this.Third = NotesEnumCollection.Get(root, interval);

            interval = chordType.Get5th();
            this.Fifth = NotesEnumCollection.Get(root, interval);

            interval = chordType.Get7th();
            this.Seventh = NotesEnumCollection.Get(root, interval);
        }


        #endregion

        public static ChordFormula operator +(ChordFormula chord, IntervalsEnum interval)
        {
            var txedRoot = NotesEnumCollection.Get(chord.Root, interval);
            var txedKey = KeySignatureEnumCollection.Get(chord.KeySignature, interval);

            var result = new ChordFormula(txedRoot, chord.ChordType, chord.ChordFunction, txedKey);
            return result;
        }

        public static ChordFormula operator -(ChordFormula chord, IntervalsEnum interval)
        {
            var txedRoot = NotesEnumCollection.Get(chord.Root, interval, DirectionEnum.Descending);
            var txedKey = KeySignatureEnumCollection.Get(chord.KeySignature, interval, DirectionEnum.Descending);

            var result = new ChordFormula(txedRoot, chord.ChordType, chord.ChordFunction, txedKey);
            return result;
        }

        public override string ToString()
        {
            var useSharps = false;
            if (NotesEnum.B == this.Root
                || NotesEnum.E == this.Root
                || NotesEnum.A == this.Root
                || NotesEnum.D == this.Root
                || NotesEnum.G == this.Root)
            {
                useSharps = true;
            }

            var r = this.Root.ToString(useSharps);
            var third = this.Third.ToString(useSharps);
            var fifth = this.Fifth.ToString(useSharps);
            var seventh = this.Seventh.ToString(useSharps);

            var result = string.Format("{0},{1},{2},{3}", r, third, fifth, seventh);
            return result;
        }

    }//class
}//ns

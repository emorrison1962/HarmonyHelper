using System;
using System.Diagnostics;
using System.Linq;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.MusicXml;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Eric.Morrison.Harmony.NoteName;

namespace Enums
{
    [TestClass]
    public class EnumsTests
    {
        [TestMethod]
        public void EnumTests()
        {
            ChordIntervalsEnum chordTypeEnum = ChordIntervalsEnum.Dominant11b9;

            var isDominant = false;
            var isAltered = false;

            if (chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalMajor3rd)
                && chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalMinor7th))
            {
                isDominant = true;
            }
            Assert.IsTrue(isDominant);

            if (isDominant)
            {
                if (chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalDiminished5th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalAugmented5th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalFlat9th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalSharp9th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalFlat11th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalAugmented11th)
                    || chordTypeEnum.HasFlag(ChordIntervalsEnum.IntervalFlat13th)
                    )
                {
                    isAltered = true;
                }
            }
            Assert.IsTrue(isAltered);

            new object();
        }

        [TestMethod]
        public void GenerateChordTypeCatalogTest()
        {
            var catalog = Enum.GetValues(typeof(ChordIntervalsEnum))
                .Cast<ChordIntervalsEnum>()
                .ToList()
                .Where(x => x != ChordIntervalsEnum.IsChord
                    && x.HasFlag(ChordIntervalsEnum.IsChord))
                .OrderBy(x => x.Name())
                .ToList();

            foreach (var e in catalog)
            {
                var code = @$"case ChordIntervalsEnum.{e}: 
{{
result = """";
break;
}}";
                Debug.WriteLine(code);
            }

            new object();
        }

        [TestMethod]
        public void ExplicitNoteValuesEnum_Bitmask_Test()
        {
            var nn1 = NoteName.C;
            var nn2 = NoteName.CSharp;

            var ev1 = nn1.ExplicitValue;
            var bits = ToBitsString(ev1);
            Debug.WriteLine(bits);

            var ev2 = nn2.ExplicitValue;
            bits = ToBitsString(ev2);
            Debug.WriteLine(bits);

            Debug.WriteLine(ToBitsString(nn1.ExplicitValue & ExplicitNoteValuesEnum.NoteNameBitwiseMask));
            Debug.WriteLine(ToBitsString(nn2.ExplicitValue & ExplicitNoteValuesEnum.NoteNameBitwiseMask));

            new object();
            //ChordIntervalsEnum
            //ExplicitNoteValuesEnum
        }

        string ToBitsString(ExplicitNoteValuesEnum src)
        {
            var bytes = BitConverter.GetBytes((uint)src);
            //var result = Convert.ToString(bytes[0], 2).PadLeft(8, '0');
            //result += Convert.ToString(bytes[1], 2).PadLeft(8, '0');
            //result += Convert.ToString(bytes[2], 2).PadLeft(8, '0');
            //result += Convert.ToString(bytes[3], 2).PadLeft(8, '0');

            var result = string.Join(" : ",
                bytes.Reverse().ToList()
                    .Select(x => Convert.ToString(x, 2)
                    .PadLeft(8, '0')));


            //var result = string.Format(" : ExplicitNoteValuesEnum={0}:{1}:{2}:{3}",
            //    bytes[0].ToString("X2"),
            //    bytes[1].ToString("X2"),
            //    bytes[2].ToString("X2"),
            //    bytes[3].ToString("X2"));
            return result;
        }


    }//class
}//ns

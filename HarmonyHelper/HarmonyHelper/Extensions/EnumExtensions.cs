using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{

    public static class ChordTypesEnumExtensions
    {
        public static IntervalsEnum Get3rd(this ChordTypesEnum cte)
        {
            var result = IntervalsEnum.Unknown;

            var icte = (int)cte;
            var mask = (int)(IntervalsEnum.Major3rd | IntervalsEnum.Minor3rd);

            var which = (icte & mask);
            result = (IntervalsEnum)which;

            return result;
        }
        public static IntervalsEnum Get5th(this ChordTypesEnum cte)
        {
            var result = IntervalsEnum.Unknown;
            var icte = (int)cte;
            var mask = (int)(IntervalsEnum.Diminished5th
                | IntervalsEnum.Perfect5th
                | IntervalsEnum.Augmented5th);

            var which = (icte & mask);
            result = (IntervalsEnum)which;
            return result;
        }
        public static IntervalsEnum Get7th(this ChordTypesEnum cte)
        {
            var result = IntervalsEnum.Unknown;
            var icte = (int)cte;
            var mask = (int)(IntervalsEnum.Minor7th
                | IntervalsEnum.Major7th);
            var which = (icte & mask);
            result = (IntervalsEnum)which;
            return result;
        }

        public static IntervalsEnum Invert(this IntervalsEnum interval)
        {
            var result = IntervalsEnum.Unknown;
            switch (interval)
            {


        case IntervalsEnum.Minor2nd:
            result = IntervalsEnum.Major7th;
            break;
                case IntervalsEnum.Major2nd:
            result = IntervalsEnum.Minor7th;
            break;
                case IntervalsEnum.Minor3rd:
            result = IntervalsEnum.Major6th;
            break;
                case IntervalsEnum.Major3rd:
            result = IntervalsEnum.Minor6th;
            break;
                case IntervalsEnum.Perfect4th:
                    result = IntervalsEnum.Perfect5th;
                    break;
                case IntervalsEnum.Augmented4th:
                    result = IntervalsEnum.Diminished5th;
                    break;
                case IntervalsEnum.Perfect5th:
                    result = IntervalsEnum.Perfect4th;
                    break;
                //case IntervalsEnum.Augmented5th:
                //    result = IntervalsEnum.Diminished4th;
                    //break;
                case IntervalsEnum.Minor6th:
                    result = IntervalsEnum.Major3rd;
                    break;
                case IntervalsEnum.Major6th:
                    result = IntervalsEnum.Minor3rd;
                    break;
                case IntervalsEnum.Minor7th:
                    result = IntervalsEnum.Major2nd;
                    break;
                case IntervalsEnum.Major7th:
                    result = IntervalsEnum.Minor2nd;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }


        public static bool UsesSharps(this KeySignatureEnum ks)
        {
            var result = false;
            if (KeySignatureEnum.OneSharps == ks
                || KeySignatureEnum.TwoSharps == ks
                || KeySignatureEnum.ThreeSharps == ks
                || KeySignatureEnum.FourSharps == ks
                || KeySignatureEnum.FiveSharps == ks
                || KeySignatureEnum.SixSharps == ks
                || KeySignatureEnum.SevenSharps == ks)
            {
                result = true;
            }
            return result;
        }

        public static bool UsesFlats(this KeySignatureEnum ks)
        {
            var result = false;
            if (KeySignatureEnum.OneFlats == ks
                || KeySignatureEnum.TwoFlats == ks
                || KeySignatureEnum.ThreeFlats == ks
                || KeySignatureEnum.FourFlats == ks
                || KeySignatureEnum.FiveFlats == ks
                || KeySignatureEnum.SixFlats == ks
                || KeySignatureEnum.SevenFlats == ks)
            {
                result = true;
            }
            return result;
        }


        public static bool Affects(this KeySignatureEnum kse, NotesEnum note)
        {
            var result = false;
            var map = new Dictionary<KeySignatureEnum, IEnumerable<NotesEnum>>();

            //NoAccidentals = 0,
            map.Add(KeySignatureEnum.NoAccidentals, new List<NotesEnum>() );
            map.Add(KeySignatureEnum.OneSharps, new[] { NotesEnum.Gb });// F#
            map.Add(KeySignatureEnum.TwoSharps,// F♯, C♯
                            new[] { NotesEnum.Gb,
                NotesEnum.Db,});
            map.Add(KeySignatureEnum.ThreeSharps,// F♯, C♯, G♯
            new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,});
            
            map.Add(KeySignatureEnum.FourSharps,// F♯, C♯, G♯, D♯
            new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,});
            
            map.Add(KeySignatureEnum.FiveSharps,// F♯, C♯, G♯, D♯, A♯
            new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,
                NotesEnum.Bb,});
            
            map.Add(KeySignatureEnum.SixSharps,// F♯, C♯, G♯, D♯, A♯, E♯
            new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,
                NotesEnum.Bb,
                NotesEnum.F});
            
            map.Add(KeySignatureEnum.SevenSharps, // F♯, C♯, G♯, D♯, A♯, E♯, B♯
            new[] { NotesEnum.Gb,
                NotesEnum.Db,
                NotesEnum.Ab,
                NotesEnum.Eb,
                NotesEnum.Bb,
                NotesEnum.F,
                NotesEnum.C });

            map.Add(KeySignatureEnum.OneFlats,// B♭
            new[] { NotesEnum.Bb,
            });

            map.Add(KeySignatureEnum.TwoFlats,// B♭, E♭
            new[] { NotesEnum.Bb,
                NotesEnum.Eb,
            });

            map.Add(KeySignatureEnum.ThreeFlats,// B♭, E♭, A♭
            new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
            });

            map.Add(KeySignatureEnum.FourFlats,// B♭, E♭, A♭, D♭
            new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
            });

            map.Add(KeySignatureEnum.FiveFlats,// B♭, E♭, A♭, D♭, G♭
            new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
                NotesEnum.Gb,
            });

            map.Add(KeySignatureEnum.SixFlats,// B♭, E♭, A♭, D♭, G♭, C♭
            new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
                NotesEnum.Gb,
                NotesEnum.Cb,
            });

            map.Add(KeySignatureEnum.SevenFlats,// B♭, E♭, A♭, D♭, G♭, C♭, F♭
            new[] { NotesEnum.Bb,
                NotesEnum.Eb,
                NotesEnum.Ab,
                NotesEnum.Db,
                NotesEnum.Gb,
                NotesEnum.Cb,
                NotesEnum.Fb
            });


            var notes = map[kse];
            if (notes.Contains(note))
                result = true;

            //switch (note)
            //{
            //    case NotesEnum.C:
            //        break;
            //    case NotesEnum.Db:
            //        break;
            //    case NotesEnum.D:
            //        break;
            //    case NotesEnum.Eb:
            //        break;
            //    case NotesEnum.E:
            //        break;
            //    case NotesEnum.F:
            //        break;
            //    case NotesEnum.Gb:
            //        break;
            //    case NotesEnum.G:
            //        break;
            //    case NotesEnum.Ab:
            //        break;
            //    case NotesEnum.A:
            //        break;
            //    case NotesEnum.Bb:
            //        break;
            //    case NotesEnum.B:
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}

            return result;
        }

    }

    public static class EnumExtensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }
}

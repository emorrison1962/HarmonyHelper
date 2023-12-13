using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
    public class ModalInterchangeGrid : IEquatable<ModalInterchangeGrid>
    {
        public List<ModalInterchangeGridRow> Rows { get; private set; } = new List<ModalInterchangeGridRow>();

        #region Operators
        //public static bool operator ==(IEnumerable<Grid> a, IEnumerable<Grid> b)
        //{
        //    var result = Compare(a, b) == 0;
        //    return result;
        //}
        //public static bool operator !=(IEnumerable<Grid> a, IEnumerable<Grid> b)
        //{
        //    var result = Compare(a, b) != 0;
        //    return result;
        //}


        public static bool operator ==(ModalInterchangeGrid a, ModalInterchangeGrid b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(ModalInterchangeGrid a, ModalInterchangeGrid b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion

        #region IComparable

        public int CompareTo(ModalInterchangeGrid other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(ModalInterchangeGrid a, ModalInterchangeGrid b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = 0;

            var aRows = a.Rows.OrderBy(x => x.ModeName).ToList();
            var bRows = b.Rows.OrderBy(x => x.ModeName).ToList();
            for (int i = 0; i < aRows.Count(); ++i)
            {
                var aRow = aRows[i];
                var bRow = bRows[i];
                result = aRow.CompareTo(bRow);
                if (result != 0)
                {
                    return result;
                }
            }

            return result;
        }

        virtual public bool Equals(ModalInterchangeGrid other)
        {
            var result = false;
            if (0 == Compare(this, other))
                result = true;
            return result;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is ModalInterchangeGrid)
            {
                result = this.Equals(obj as ModalInterchangeGrid);
            }
            else
            {
                base.Equals(obj);
            }
            return result;

        }

        static public bool Equals(ModalInterchangeGrid a, ModalInterchangeGrid b)
        {
            throw new NotImplementedException();
        }
        static public bool Equals(List<ModalInterchangeGrid> a, List<ModalInterchangeGrid> b)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            var result = 0;
            this.Rows.ForEach(x => result ^= x.GetHashCode());
            return result;
        }

        #endregion

        public override string ToString()
        {
            var result = $"{nameof(ModalInterchangeGrid)}";
            foreach (var row in this.Rows) 
            {
                result += $"{Environment.NewLine}{row.ToString()}";
            }
            return result;
        }
    }
    public class ModalInterchangeGridRow : IEquatable<ModalInterchangeGridRow>
    {
        #region Properties
        public KeySignature Key { get; set; }
        public string ModeName { get; set; }
        public List<ChordFormula> Chords { get; set; } = new List<ChordFormula>();
        //public IList<ChordFormula> Chords { get { return _Chords; } }

        public void Add(ChordFormula formula)
        {
            //Allow adding nulls.
            this.Chords.Add(formula);
        }
        #endregion

        #region Construction
        public ModalInterchangeGridRow(KeySignature key, string modeName)
        {
            this.Key = key;
            this.ModeName = modeName;
        }

        #endregion

        #region Operators
        public static bool operator ==(ModalInterchangeGridRow a, ModalInterchangeGridRow b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(ModalInterchangeGridRow a, ModalInterchangeGridRow b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion

        #region IComparable

        public int CompareTo(ModalInterchangeGridRow other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(ModalInterchangeGridRow a, ModalInterchangeGridRow b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = 0;
            result = a.Key.CompareTo(b.Key);
            if (result == 0)
                result = a.ModeName.CompareTo(b.ModeName);
            Debug.Assert(a.Chords.Count() == b.Chords.Count());
            for (int i = 0; i < a.Chords.Count(); ++i)
            {
                var cfA = a.Chords[i];
                var cfB = b.Chords[i];
                if (null != cfA && null != cfB)
                {
                    if (0 == cfA.CompareTo(cfB))
                    {
                        continue;
                    }
                    else
                    {
                        result = cfA.CompareTo(cfB);
                        break;
                    }
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is ModalInterchangeGridRow)
            {
                result = this.Equals(obj as ModalInterchangeGridRow);
            }
            else
            {
                base.Equals(obj);
            }
            return result;

        }

        public bool Equals(ModalInterchangeGridRow other)
        {
            var result = false;
            if (0 == Compare(this, other))
                result = true;
            return result;
        }

        static public bool Equals(List<ModalInterchangeGridRow> a, List<ModalInterchangeGridRow> b)
        {
            var result = false;
            throw new NotImplementedException();
            return result;
        }



        public override int GetHashCode()
        {
            var result = this.Key.GetHashCode()
                ^ this.ModeName.GetHashCode();
            this.Chords.ForEach(x => result ^= x.GetHashCode());

            return result;
        }

        #endregion

        public override string ToString()
        {
            return $"{nameof(ModalInterchangeGridRow)}: {ModeName} {string.Join(", ", Chords.Select(x => x.Name))}";
        }
    }//class
}//ns

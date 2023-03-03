using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.Chords;

namespace Eric.Morrison.Harmony.HarmonicAnalysis.Rules
{
    public class Grid : IEquatable<Grid>
    {
        public List<GridRow> Rows { get; private set; } = new List<GridRow>();

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


        public static bool operator ==(Grid a, Grid b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(Grid a, Grid b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion

        #region IComparable

        public int CompareTo(Grid other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(Grid a, Grid b)
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

        virtual public bool Equals(Grid other)
        {
            var result = false;
            if (this.Rows == other.Rows)
                result = true;
            return result;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Grid)
            {
                result = this.Equals(obj as Grid);
            }
            else
            {
                base.Equals(obj);
            }
            return result;

        }

        static public bool Equals(List<Grid> a, List<Grid> b)
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

    }
    public class GridRow : IEquatable<GridRow>
    {
        #region Properties
        public KeySignature Key { get; private set; }
        public string ModeName { get; private set; }
        public List<ChordFormula> Chords { get; private set; } = new List<ChordFormula>();

        #endregion

        #region Construction
        public GridRow(KeySignature key, string modeName)
        {
            this.Key = key;
            this.ModeName = modeName;
        }

        #endregion

        #region Operators
        public static bool operator ==(GridRow a, GridRow b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(GridRow a, GridRow b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }

        #endregion

        #region IComparable

        public int CompareTo(GridRow other)
        {
            var result = Compare(this, other);
            return result;
        }
        public static int Compare(GridRow a, GridRow b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            var result = a.CompareTo(b);
            return result;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is GridRow)
            {
                result = this.Equals(obj as GridRow);
            }
            else
            {
                base.Equals(obj);
            }
            return result;

        }

        public bool Equals(GridRow other)
        {
            var result = false;
            if (this.Key == other.Key)
                if (this.ModeName == other.ModeName)
                    if (this.Chords == other.Chords)
                    {
                        result = true;
                    }
            return result;
        }

        static public bool Equals(List<GridRow> a, List<GridRow> b)
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
    }//class
}//ns

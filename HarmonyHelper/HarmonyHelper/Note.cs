﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public class Note : IEquatable<Note>, IComparable<Note>
    {
        #region Properties
        public NoteName NoteName { get; private set; }

        public OctaveEnum Octave { get; set; }

        //public KeySignature KeySignature { get; private set; }
        #endregion

        #region Construction
        public Note(Note src)
        {
            this.NoteName = src.NoteName;
            this.Octave = src.Octave;
        }
        public Note(NoteName nn, OctaveEnum octave)
        {
            this.NoteName = nn;
            this.Octave = octave;
        //this.UsesSharps = usesSharps;
    }
        
        #endregion

        public override string ToString()
        {
            throw new NotSupportedException();
            var result = this.NoteName.ToString();

            //var result = string.Format("{0}, NoteName={1}, Octave={2}", 
            //    base.ToString(), this.NoteName, this.Octave);
            return result;
        }

        public string ToString(KeySignature key)
        {
            if (null == key)
                throw new ArgumentNullException();

            var result = this.NoteName.ToString(key);
            return result;
        }

        public string ToString(ToStringEnum verbosity, KeySignature key)
        {
            if (null == key)
                throw new ArgumentNullException();

            var result = this.NoteName.ToString(key);
            return result;
        }


        public bool Equals(Note other)
        {
            var result = false;
            if (this.NoteName == other.NoteName
                && this.Octave == other.Octave)
                result = true;
            return result;
        }

        public static bool operator <(Note a, Note b)
        {
            var result = Compare(a, b) < 0;
            return result;
        }
        public static bool operator >(Note a, Note b)
        {
            var result = Compare(a, b) > 0;
            return result;
        }
        public static bool operator <=(Note a, Note b)
        {
            var result = Compare(a, b) <= 0;
            return result;
        }
        public static bool operator >=(Note a, Note b)
        {
            var result = Compare(a, b) >= 0;
            return result;
        }
        public static bool operator ==(Note a, Note b)
        {
            var result = Compare(a, b) == 0;
            return result;
        }
        public static bool operator !=(Note a, Note b)
        {
            var result = Compare(a, b) != 0;
            return result;
        }
        public int CompareTo(Note other)
        {
            var result = this.CompareTo(other);
            return result;
        }
        public static int Compare(Note a, Note b)
        {
            if (object.ReferenceEquals(null, a) && object.ReferenceEquals(null, b))
            //if (null == a && null == b)
                return 0;
            else if (object.ReferenceEquals(null, a))
            //else if (null == a)
                return -1;
            else if (object.ReferenceEquals(null, b))
            //else if (null == b)
                return 1;

            if (a.Octave == b.Octave)
            {
                if (a.NoteName == b.NoteName)
                    return 0;
                else if (a.NoteName < b.NoteName)
                    return -1;
                else 
                    return 1;
            }
            else if (a.Octave < b.Octave)
                return -1;
            else
                return 1;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }//class

    public class NoteComparer : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return Note.Compare(x, y);
        }
    }
}//ns

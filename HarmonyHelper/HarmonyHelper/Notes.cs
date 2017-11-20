using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric.Morrison.Harmony
{
    public class Note : IEquatable<Note>, IComparable<Note>
    {
        #region Properties
        public NotesEnum NoteName { get; set; }

        public OctaveEnum Octave { get; set; }

        public bool UsesSharps { get; set; }
        #endregion

        #region Construction
        public Note(Note src)
        {
            this.NoteName = src.NoteName;
            this.Octave = src.Octave;
        }
        public Note(NotesEnum note, OctaveEnum octave)
        {
            this.NoteName = note;
            this.Octave = octave;
            //this.UsesSharps = usesSharps;
        }
        
        #endregion

        public override string ToString()
        {
            var result = string.Format("{0}, NoteName={1}, Octave={2}", 
                base.ToString(), this.NoteName, this.Octave);
            return result;
        }

        public string ToString(ToStringEnum verbosity, KeySignature key)
        {
            if (null == key)
                throw new ArgumentNullException();

            var result = string.Empty;
            if (key.Affects(this.NoteName))
            {
                new object();
            }
            else
            {
                result = this.NoteName.ToString();
            }
            //if (key.UsesSharps())
            //{
            //    result = this.ToString(ToStringEnum.Minimal, true);
            //}
            //else if (key.UsesFlats())
            //{
            //    result = this.NoteName.ToString();
            //    if ("B" == result)
            //        result = "Cb";
            //    else if ("E" == result)
            //        result = "Fb";
            //}
            return result;
        }

        public string ToString(ToStringEnum verbosity, bool useSharped = false)
        {
            var result = string.Empty;

            var noteString = this.NoteName.ToString();
            if (useSharped)
            {
                if (noteString.EndsWith("b"))
                {
                    var noteToSharp = Enum.GetValues(typeof(NotesEnum)).OfType<NotesEnum>()
                        .Where(x => x < this.NoteName).Last().ToString();
                    if (null != noteToSharp)
                        noteString = noteToSharp + "#";
                }
            }

            if (verbosity == ToStringEnum.Minimal)
            {
                //result = string.Format("{0} {1}",
                //        this.NoteName, 
                //        this.Octave.ToString().Replace("Octave", string.Empty));
                result = noteString;
            }
            else if (verbosity == ToStringEnum.Normal)
            {
                result = this.ToString();
            }
            else if (verbosity == ToStringEnum.Detailed)
            {
                throw new NotImplementedException();
            }
            else if (verbosity == ToStringEnum.Diagnostic)
            {
                throw new NotImplementedException();
            }

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

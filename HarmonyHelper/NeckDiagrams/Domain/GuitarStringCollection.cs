using System;
using System.Collections.Generic;
using System.Text;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;

using NeckDiagrams.Properties;

using Newtonsoft.Json;

namespace NeckDiagrams.Domain
{
    public class GuitarStringCollection 
    {

        #region Properties
        public Dictionary<GuitarStringNdxEnum, GuitarStringVM> Dictionary { get; set; } = new Dictionary<GuitarStringNdxEnum, GuitarStringVM>();

        #endregion

        #region Static Methods
        static public bool TryLoadSettings(out GuitarStringCollection coll)
        {
            var json = Settings.Default.GuitarStringCollection;
            coll = JsonConvert.DeserializeObject<GuitarStringCollection>(json);
            var result = false;
            if (null != coll)
                result = true;
            return result;

        }

        static public void SaveToSettings(GuitarStringCollection coll)
        {
            var json = JsonConvert.SerializeObject(coll);
            Settings.Default.GuitarStringCollection = json;
            Settings.Default.Save();
        }

        static public GuitarStringCollection CreateDefaultCollection()
        {
            var list = new List<GuitarStringVM>();
            //6th String(Thickest): Low E(E2)
            var note = new Note(NoteName.E, OctaveEnum.Octave2);
            list.Add(new GuitarStringVM(GuitarStringNdxEnum.Sixth, note));
            //5th String: A(A2)
            note = new Note(NoteName.A, OctaveEnum.Octave2);
            list.Add(new GuitarStringVM(GuitarStringNdxEnum.Fifth, note));
            //4th String: D(D3)
            note = new Note(NoteName.D, OctaveEnum.Octave3);
            list.Add(new GuitarStringVM(GuitarStringNdxEnum.Fourth, note));
            //3rd String: G(G3)
            note = new Note(NoteName.G, OctaveEnum.Octave3);
            list.Add(new GuitarStringVM(GuitarStringNdxEnum.Third, note));
            //2nd String: B(B3)
            note = new Note(NoteName.B, OctaveEnum.Octave2);
            list.Add(new GuitarStringVM(GuitarStringNdxEnum.Second, note));
            //1st String(Thinnest): High E(E4)
            note = new Note(NoteName.E, OctaveEnum.Octave4);
            list.Add(new GuitarStringVM(GuitarStringNdxEnum.First, note));

            var result = new GuitarStringCollection(list);
            return result;
        }

        static public GuitarStringCollection LoadSettingsOrDefault()
        {
            if (!GuitarStringCollection.TryLoadSettings(out var result))
                result = GuitarStringCollection.CreateDefaultCollection();
            return result;
        }

        static public GuitarStringCollection Clone(GuitarStringCollection coll)
        {
            var json = JsonConvert.SerializeObject(coll);
            var result = JsonConvert.DeserializeObject<GuitarStringCollection>(json);
            return result;
        }

        #endregion

        #region Construction
        [Newtonsoft.Json.JsonConstructor]
        public GuitarStringCollection() { }
        public GuitarStringCollection(List<GuitarStringVM> list)
        {
            foreach (var str in list)
            {
                if (this.Dictionary.ContainsKey(str.GuitarStringNdx))
                    throw new ArgumentOutOfRangeException(nameof(str));

                this.Dictionary.Add(str.GuitarStringNdx, str);
            }
        }

        #endregion

        public GuitarStringVM Get(GuitarStringNdxEnum ndx)
        {
            var result = Dictionary[ndx];
            return result;
        }

        public GuitarStringVM this[GuitarStringNdxEnum ndx]
        {
            get { return Dictionary[ndx]; }
            set { Dictionary[ndx] = value; }
        }

    }//class
}//ns

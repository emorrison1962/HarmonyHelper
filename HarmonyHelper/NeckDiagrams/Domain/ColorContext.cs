using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

using Eric.Morrison.Harmony;

using NeckDiagrams.Properties;

using Newtonsoft.Json;

namespace NeckDiagrams.Domain
{
    public class ColorContext
    {
        const string ROOT = "Root";
        const string SECOND = "Second";
        const string THIRD = "Third";
        const string FOURTH = "Fourth";
        const string FIFTH = "Fifth";
        const string SIXTH = "Sixth";
        const string SEVENTH = "Seventh";
        const string NINTH = "Ninth";
        const string ELEVENTH = "Eleventh";
        const string THIRTEENTH = "Thirteenth";

        static Dictionary<ChordFunctionEnum, string> Names { get; set; } = new Dictionary<ChordFunctionEnum, string>();
        static ColorContext()
        {
            Names.Add(ChordFunctionEnum.Root, ROOT);
            Names.Add(ChordFunctionEnum.Second, SECOND);
            Names.Add(ChordFunctionEnum.Third, THIRD);
            Names.Add(ChordFunctionEnum.Fourth, FOURTH);
            Names.Add(ChordFunctionEnum.Fifth, FIFTH);
            Names.Add(ChordFunctionEnum.Sixth, SIXTH);
            Names.Add(ChordFunctionEnum.Seventh, SEVENTH);
            Names.Add(ChordFunctionEnum.Ninth, NINTH);
            Names.Add(ChordFunctionEnum.Eleventh, ELEVENTH);
            Names.Add(ChordFunctionEnum.Thirteenth, THIRTEENTH);
        }

        public Color Color { get; set; }
        public ChordFunctionEnum ChordFunction { get; set; }
        public string Label { get { return Names[this.ChordFunction]; } }
        public ColorContext() { }
        public ColorContext(ChordFunctionEnum cfe, Color color)
        {
            this.ChordFunction = cfe;
            this.Color = color;
        }

        void Init()
        {
        }
    }//class

    public class ColorContextCollection : IColorContextCollection
    {
        #region Properties
        [Newtonsoft.Json.JsonProperty]
        Dictionary<ChordFunctionEnum, ColorContext> Dictionary { get; set; } = new Dictionary<ChordFunctionEnum, ColorContext>();

        #endregion

        #region Static Methods
        static bool TryLoadSettings(out ColorContextCollection coll)
        {
            var result = false;
            coll = null;
            try
            {
                var json = Settings.Default.ColorContextCollection;
                coll = JsonConvert.DeserializeObject<ColorContextCollection>(json);
                if (null != coll && coll.Dictionary.Count > 0)
                    result = true;
            }
            catch (Exception)
            {
                new object();
            }
            return result;
        }

        static ColorContextCollection CreateDefaultCollection()
        {
            var list = new List<ColorContext>();

            list.Add(new ColorContext(ChordFunctionEnum.Root, Color.Red));         
            list.Add(new ColorContext(ChordFunctionEnum.Second, Color.HotPink));
            list.Add(new ColorContext(ChordFunctionEnum.Third, Color.Orange));
            list.Add(new ColorContext(ChordFunctionEnum.Fourth, Color.Yellow));
            list.Add(new ColorContext(ChordFunctionEnum.Fifth, Color.Violet));
            list.Add(new ColorContext(ChordFunctionEnum.Sixth, Color.LimeGreen));
            list.Add(new ColorContext(ChordFunctionEnum.Seventh, Color.HotPink));
            
            list.Add(new ColorContext(ChordFunctionEnum.Ninth, Color.DarkBlue));
            list.Add(new ColorContext(ChordFunctionEnum.Eleventh, Color.DarkRed));
            list.Add(new ColorContext(ChordFunctionEnum.Thirteenth, Color.DarkViolet));

            var result = new ColorContextCollection(list);
            return result;
        }

        static public ColorContextCollection LoadSettingsOrDefault()
        {
            if (!ColorContextCollection.TryLoadSettings(out var result))
                result = ColorContextCollection.CreateDefaultCollection();
            return result;
        }

        static public void SaveToSettings(ColorContextCollection coll)
        {
            var json = JsonConvert.SerializeObject(coll);
            Settings.Default.ColorContextCollection = json;
            Settings.Default.Save();
        }

        static ColorContextCollection Clone(ColorContextCollection coll)
        {
            var json = JsonConvert.SerializeObject(coll);
            var result = JsonConvert.DeserializeObject<ColorContextCollection>(json);
            return result;
        }

        #endregion

        #region Construction
        [Newtonsoft.Json.JsonConstructor]
        public ColorContextCollection() { }
        public ColorContextCollection(List<ColorContext> list)
        {
            foreach (var item in list)
            {
                if (this.Dictionary.ContainsKey(item.ChordFunction))
                    throw new ArgumentOutOfRangeException(nameof(item));

                this.Dictionary.Add(item.ChordFunction, item);
            }
        }

        #endregion

        public Color GetColor(ChordFunctionEnum ndx)
        {
            var result = this.Dictionary[ndx].Color;
            return result;
        }
        public ColorContext Get(ChordFunctionEnum ndx)
        {
            var result = this.Dictionary[ndx];
            return result;
        }

        public Color this[ChordFunctionEnum key]
        {
            get => this.Dictionary[key].Color;
            set => this.Dictionary[key].Color = value;
        }

    }//class

    public interface IColorContextCollection
    {
        Color this[ChordFunctionEnum key] { get; set; }
        ColorContext Get(ChordFunctionEnum ndx);
        Color GetColor(ChordFunctionEnum ndx);
    }//class

}//ns

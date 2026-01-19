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
        const string ROOT   = "Root";
        const string SECOND = "Second/ Ninth";
        const string THIRD  = "Third";
        const string FOURTH = "Fourth/ Eleventh";
        const string FIFTH  = "Fifth";
        const string SIXTH  = "Sixth/ Thirteenth";
        const string SEVENTH = "Seventh";

        static Dictionary<IntervalRoleTypeEnum, string> Names { get; set; } = new Dictionary<IntervalRoleTypeEnum, string>();
        static ColorContext() 
        {
            Names.Add(IntervalRoleTypeEnum.Root, ROOT);
            Names.Add(IntervalRoleTypeEnum.Second, SECOND );
            Names.Add(IntervalRoleTypeEnum.Third, THIRD  );
            Names.Add(IntervalRoleTypeEnum.Fourth, FOURTH );
            Names.Add(IntervalRoleTypeEnum.Fifth, FIFTH  );
            Names.Add(IntervalRoleTypeEnum.Sixth, SIXTH  );
            Names.Add(IntervalRoleTypeEnum.Seventh, SEVENTH);
        }

        public Color Color { get; set; }
        public IntervalRoleTypeEnum ChordFunction { get; set; }
        public string Label { get { return Names[this.ChordFunction]; } }
        public ColorContext() { }
        public ColorContext(IntervalRoleTypeEnum cfe, Color color)
        {
            this.ChordFunction = cfe;
            this.Color = color;
        }

        void Init()
        {
        }
#if false
#endif
    }//class

    public class ColorContextCollection
    {
        #region Properties
        public Dictionary<IntervalRoleTypeEnum, ColorContext> Dictionary { get; set; } = new Dictionary<IntervalRoleTypeEnum, ColorContext>();

        #endregion

        #region Static Methods
        static public bool TryLoadSettings(out ColorContextCollection coll)
        {
            var result = false;
            coll = null;
            try
            {
                var json = Settings.Default.ColorContextCollection;
                coll = JsonConvert.DeserializeObject<ColorContextCollection>(json);
                if (null != coll)
                    result = true;
            }
            catch (Exception)
            {
                new object();
            }
            return result;
        }

        static public void SaveToSettings(ColorContextCollection coll)
        {
            var json = JsonConvert.SerializeObject(coll);
            Settings.Default.ColorContextCollection = json;
            Settings.Default.Save();
        }

        static public ColorContextCollection CreateDefaultCollection()
        {
            var list = new List<ColorContext>();

            list.Add(new ColorContext(IntervalRoleTypeEnum.Root, Color.Red));
            list.Add(new ColorContext(IntervalRoleTypeEnum.Second, Color.HotPink));
            list.Add(new ColorContext(IntervalRoleTypeEnum.Third, Color.Orange));
            list.Add(new ColorContext(IntervalRoleTypeEnum.Fourth, Color.Yellow));
            list.Add(new ColorContext(IntervalRoleTypeEnum.Fifth, Color.Violet));
            list.Add(new ColorContext(IntervalRoleTypeEnum.Sixth, Color.LimeGreen));
            list.Add(new ColorContext(IntervalRoleTypeEnum.Seventh, Color.HotPink));

            var result = new ColorContextCollection(list);
            return result;
        }

        static public ColorContextCollection LoadSettingsOrDefault()
        {
            if (!ColorContextCollection.TryLoadSettings(out var result))
                result = ColorContextCollection.CreateDefaultCollection();
            return result;
        }

        static public ColorContextCollection Clone(ColorContextCollection coll)
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

        public Color GetColor(IntervalRoleTypeEnum ndx)
        {
            var result = this.Dictionary[ndx].Color;
            return result;
        }
        public ColorContext Get(IntervalRoleTypeEnum ndx)
        {
            var result = this.Dictionary[ndx];
            return result;
        }

    }



}//ns

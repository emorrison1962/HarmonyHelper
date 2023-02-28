using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper.Chords
{
    [Serializable]
    public abstract class ChordEntityBase : ClassBase
    {
        virtual public List<KeySignature> Keys { get; protected set; } = new List<KeySignature>();  

        public ChordEntityBase(IEnumerable<KeySignature> keys)
        {
            this.Keys = keys.ToList();
        }
        public ChordEntityBase(KeySignature key)
        {
            if (null != key)
                this.Keys.Add(key);
        }

        public ChordEntityBase()
        {
        }
    }//class
}//ns

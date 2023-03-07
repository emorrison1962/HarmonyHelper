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
        virtual protected HashSet<KeySignature> _Keys { get; set; } = new HashSet<KeySignature>();  
        virtual public IEnumerable<KeySignature> Keys { get { return _Keys.ToList().AsReadOnly(); } }

        public ChordEntityBase(IEnumerable<KeySignature> keys)
        {
            this._Keys = keys.ToHashSet();
        }
        public ChordEntityBase(KeySignature key)
        {
            if (null != key)
                this._Keys.Add(key);
        }

        public ChordEntityBase()
        {
        }
    }//class
}//ns

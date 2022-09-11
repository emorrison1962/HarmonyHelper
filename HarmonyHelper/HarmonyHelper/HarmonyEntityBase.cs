using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
    public abstract class HarmonyEntityBase : ClassBase
    {
        public KeySignature Key { get; protected set; }

        public HarmonyEntityBase(KeySignature key)
        {
            this.Key = key;
        }
		public HarmonyEntityBase()
		{
			this.Key = null;
		}
	}//class
}//ns

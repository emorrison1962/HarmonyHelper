using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	[Serializable]
	public abstract class ClassBase
    {
        static int _instances = 0;
        protected int _instanceID = 0;
        public ClassBase()
        {
            this._instanceID = ++_instances;
        }
    }
}

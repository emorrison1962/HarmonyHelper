using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlPartIdentifier
    {
        public string ID;
        public string Name;
        public MusicXmlPartIdentifier(string ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
        public override string ToString()
        {
            return $"{nameof(MusicXmlPartIdentifier)}: ID={ID}, Name={Name}";
        }
    }//class

}//ns

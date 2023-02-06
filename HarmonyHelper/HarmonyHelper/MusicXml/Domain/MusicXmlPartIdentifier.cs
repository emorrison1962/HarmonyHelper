using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class MusicXmlPartIdentifier: IHasIsValid
    {
        public string ID;
        public string Name;
        public MusicXmlPartIdentifier(string ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }

        public bool IsValid()
        {
            var result = true; 
            if (string.IsNullOrEmpty(this.ID)) 
            { 
                result = false;
                Debug.Assert(result);
            }
            return result;
        }

        public override string ToString()
        {
            return $"{nameof(MusicXmlPartIdentifier)}: ID={ID}, Name={Name}";
        }
    }//class

}//ns

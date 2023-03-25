using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class TimeModification
    {
        public int Normal { get; set; }
        public int Actual { get; set; }

        public TimeModification(XElement xtime_modification)
        {
#if false
        <time-modification>
            <actual-notes>3</actual-notes>
            <normal-notes>2</normal-notes>
            <normal-type>eighth</normal-type>
        </time-modification>
#endif
            this.Actual = int.Parse(xtime_modification.Element(XmlConstants.actual_notes).Value);
            this.Normal = int.Parse(xtime_modification.Element(XmlConstants.normal_notes).Value);
        }

        public int GetDuration(int duration)
        {
            var result = (duration * this.Normal) / this.Actual;
            return result;
        }
    }//class

}//ns

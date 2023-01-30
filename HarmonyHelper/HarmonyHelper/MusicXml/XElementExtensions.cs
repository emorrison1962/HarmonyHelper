using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public static partial class XElementExtensions
    {
        static public TieTypeEnum GetTieType(this XElement xnote)
        {
#if false
<note attack="18">
  <duration>60</duration>
  <tie type="start" />
</note>
#endif
            var result = TieTypeEnum.None;
            var ties = xnote.Element(XmlConstants.notations).Elements(XmlConstants.tied).ToList();

            if (ties.Count == 1)
            {
                var attrVal = ties[0].Attribute(XmlConstants.type).Value;
                if (XmlConstants.start == attrVal)
                {
                    result = TieTypeEnum.Start;
                }
                else
                {
                    result = TieTypeEnum.Stop;
                }
            }
            return result;
        }

    }//class
}//ns

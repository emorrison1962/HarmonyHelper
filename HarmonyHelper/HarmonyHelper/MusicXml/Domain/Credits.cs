using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public class Identification : IHasIsValid
    {
        public List<Creator> Creators { get; set; } = new List<Creator>();

        public Identification()
        {
        }

        public Identification(List<Creator> Creators)
        {
            this.Creators = Creators;
        }

        public Identification(Creator Creator)
        {
            this.Creators.Add(Creator);
        }

        public XElement ToXElement()
        {
#if false
    <creator type="composer">Ivan "Boogaloo" Joe Jones
Arr. 6EQUJ5</creator>
#endif
            var xidentification = new XElement(XmlConstants.identification);
            foreach (var creator in this.Creators)
            {
                var xcreator = new XElement(XmlConstants.creator, creator.CreatorName);
                if (!string.IsNullOrEmpty(creator.CreatorType))
                {
                    xcreator.Add(new XAttribute(XmlConstants.type, creator.CreatorType));
                }
                xidentification.Add(xcreator);
            }
            xidentification.Add(this.GetEncoding());
            return xidentification;
        }

        XElement GetEncoding()
        {
#if false
    <encoding>
      <software>Finale v25 for Windows</software>
      <encoding-date>2018-04-23</encoding-date>
    </encoding>
#endif

            var fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var template = $@"
 <encoding>
  <encoding-date>{this.GetNow()}</encoding-date>
  <software>{fvi.ProductName}, Version {fvi.ProductVersion}</software>
 </encoding>";
            var result = XElement.Parse(template);
            return result;

        }

        public string GetNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public bool IsValid()
        {
            bool result = true;
            //if (!this.Creators.Any())
            //{
            //    result = false;
            //    Debug.Assert(result);
            //}
            return result;
        }

    }//class

    public class Credits : IHasIsValid
    {
        #region Properties
        public string? WorkNumber { get; set; }
        public string? WorkTitle { get; set; }
        public string? MovementNumber { get; set; }
        public string? MovementTitle { get; set; }

        #endregion

        #region Construction
        //[Obsolete]
        public Credits() { }
        public Credits(string WorkTitle) 
        { 
            this.WorkTitle = WorkTitle;
        }

        #endregion

        public List<XElement> ToXElements()
        {
            var result = new List<XElement>();
#if false
<score-partwise>
   <work>
      <work-number>D. 911</work-number>
      <work-title>Winterreise</work-title>
   </work>
   <movement-number>22</movement-number>
   <movement-title>Mut</movement-title>
</score-partwise>
#endif
            var work = new XElement(XmlConstants.work);
            if (!string.IsNullOrEmpty(this.WorkNumber))
                work.Add(XmlConstants.work_number, this.WorkNumber);
            if (!string.IsNullOrEmpty(this.WorkTitle))
                work.Add(XmlConstants.work_title, this.WorkTitle);
            result.Add(work);

            if (!string.IsNullOrEmpty(this.MovementNumber))
                result.Add(new XElement(XmlConstants.movement_number, this.MovementNumber));
            if (!string.IsNullOrEmpty(this.MovementTitle))
                result.Add(new XElement(XmlConstants.movement_title, this.MovementTitle));

            return result;
        }

        public bool IsValid()
        {
            var result = true;
            if (string.IsNullOrEmpty(this.WorkNumber)
                && string.IsNullOrEmpty(this.WorkTitle)
                && string.IsNullOrEmpty(this.MovementNumber)
                && string.IsNullOrEmpty(this.MovementTitle))
            {
                result = true;
                Debug.Assert(result);
            }
            return result;
        }
    }//class

    public class Creator
    {
        public enum CreatorTypeEnum
        {
            composer, 
            lyricist, 
            arranger
        }

        public string CreatorType { get; set; }
        public string CreatorName { get; set; }
        public Creator(CreatorTypeEnum creatorType, string creatorName)
        {
            this.CreatorType = Enum.GetName(creatorType);
            this.CreatorName = creatorName;
        }
        public Creator(string creatorType, string creatorName)
        {
            this.CreatorType = creatorType;
            this.CreatorName = creatorName;
        }
    }//class
}//ns

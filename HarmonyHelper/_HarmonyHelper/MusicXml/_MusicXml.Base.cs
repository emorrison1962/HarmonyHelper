using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Eric.Morrison.Harmony.MusicXml
{
    abstract public class MusicXmlBase
    {
        [Obsolete("", true)]
        static public bool ValidateMusicXmlSchema(XDocument doc)
        {//https://www.c-sharpcorner.com/article/how-to-validate-xml-using-xsd-in-c-sharp/
            var result = false;
            try
            {
                XmlSchemaSet schemaSet = new XmlSchemaSet();

                var xsd = Helpers.LoadEmbeddedResource("xml.xsd");
                var textReader = new StringReader(xsd);
                var schema = XmlSchema.Read(textReader, ValidationEventHandler);
                schemaSet.Add(schema);

                xsd = Helpers.LoadEmbeddedResource("xlink.xsd");
                textReader = new StringReader(xsd);
                schema = XmlSchema.Read(textReader, ValidationEventHandler);
                schemaSet.Add(schema);

                xsd = Helpers.LoadEmbeddedResource("musicxml.xsd");
                textReader = new StringReader(xsd);
                schema = XmlSchema.Read(textReader, ValidationEventHandler);
                schemaSet.Add(schema);

                doc.Validate(schemaSet, ValidationEventHandler);
                result = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
                result = false;
            }
            return result;
        }
        public static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning) 
                Debug.WriteLine(e.Message);
            else if (e.Severity == XmlSeverityType.Error)
                throw new Exception(e.Message);
        }
    

    
    }//class
}//ns

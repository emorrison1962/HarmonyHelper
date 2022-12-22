using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Eric.Morrison.Harmony.MusicXml
{
    abstract public class MusicXmlBase
    {
        static public bool ValidateMusicXmlSchema(XDocument doc)
        {
            var result = false;
            try
            {
                var xsd = LoadEmbeddedResource("musicxml.xsd");
                var reader = new StringReader(xsd);
                var schema = XmlSchema.Read(reader, ValidationEventHandler);

                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(schema);

                xsd = LoadEmbeddedResource("xlink.xsd");
                reader = new StringReader(xsd);
                schema = XmlSchema.Read(reader, ValidationEventHandler);
                schemaSet.Add(schema);

                xsd = LoadEmbeddedResource("xml.xsd");
                reader = new StringReader(xsd);
                schema = XmlSchema.Read(reader, ValidationEventHandler);
                schemaSet.Add(schema);

                doc.Validate(schemaSet, ValidationEventHandler);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        protected static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error)
                    throw new Exception(e.Message);
            }
        }
        static public string LoadEmbeddedResource(string partialName)
        {
            var result = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
            var resource = assembly.GetManifestResourceNames()
                .Where(x => x.Contains(partialName)).FirstOrDefault();
            using (var sr = new StreamReader(assembly
                .GetManifestResourceStream(resource)))
            {
                result = sr.ReadToEnd();
            }
            return result;
        }
    }//class
}//ns

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [Obsolete("", true)]
        static public bool ValidateMusicXmlSchema(XDocument doc)
        {//https://www.c-sharpcorner.com/article/how-to-validate-xml-using-xsd-in-c-sharp/
            var result = false;
            try
            {
                XmlSchemaSet schemaSet = new XmlSchemaSet();

                var xsd = LoadEmbeddedResource("musicxml.xsd");
                var reader = new StringReader(xsd);
                var schema = XmlSchema.Read(reader, ValidationEventHandler);
                schemaSet.Add(schema);

                xsd = LoadEmbeddedResource("xlink.xsd");
                reader = new StringReader(xsd);
                schema = XmlSchema.Read(reader, ValidationEventHandler);
                schemaSet.Add(schema);

                xsd = LoadEmbeddedResource("xml.xsd");
                reader = new StringReader(xsd);
                schema = XmlSchema.Read(reader, ValidationEventHandler);
                schemaSet.Add(schema);

                doc.Validate(schemaSet, ValidationEventHandler, true);
                result = true;
            }
            catch (Exception ex)
            {
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
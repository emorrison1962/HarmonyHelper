using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison
{
    static public class Helpers
    {
        static public string LoadEmbeddedResource(string partialName)
        {
            var result = string.Empty;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var resource = assembly.GetManifestResourceNames()
                    .Where(x => x.Contains(partialName)).FirstOrDefault();
                if (resource != null)
                {
                    using (var sr = new StreamReader(assembly
                        .GetManifestResourceStream(resource)))
                    {
                        result = sr.ReadToEnd();
                    }
                    break;
                }
            }
            return result;
        }
    }//class
}//ns

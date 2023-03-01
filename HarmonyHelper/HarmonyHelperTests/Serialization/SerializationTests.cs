using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Eric.Morrison.Harmony.Scales;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests.Serialization
{
    [TestClass()]
    public class SerializationTests
    {
        [TestMethod()]
        public void SerializeNoteName()
        {
            var assembly = Assembly.GetAssembly(typeof(NoteName));
            var types = assembly.GetTypes().ToList();
            foreach (var type in types)
            {
                //if (type.Name == "NoteName")
                if (type.BaseType == typeof(ClassBase))
                {
                    Debug.WriteLine(type.Name);
                    new Object();
                }
            }
            new object();
        }
    }//class
}//ns

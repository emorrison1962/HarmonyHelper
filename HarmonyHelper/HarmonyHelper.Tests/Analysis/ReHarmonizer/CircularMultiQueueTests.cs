using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eric.Morrison.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace Eric.Morrison.Collections.Generic.Tests
{
    [TestClass()]
    public class CircularMultiQueueTests
    {
        [TestMethod()]
        public void GetCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNextTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            var multiQ = new CircularMultiQueue<char, int>();    
            var a = new List<int>() { 1, 3, 5, 7, 9};
            var b = new List<int>() { 2, 4, 6, 8};
            multiQ.Add('a', a);
            multiQ.Add('b', b);

            foreach (var list in multiQ)
            { 
                Debug.WriteLine(String.Join(", ", list));
                new Object();
            }
            new object();
        }
    }
}
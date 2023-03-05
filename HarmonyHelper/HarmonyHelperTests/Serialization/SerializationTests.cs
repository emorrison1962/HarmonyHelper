using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.HarmonicAnalysis.Rules;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

using static Eric.Morrison.Harmony.HarmonicAnalysis.Rules.BorrowedChordHarmonicAnalysisRule;

namespace Eric.Morrison.Harmony.Tests.Serialization
{
    [TestClass()]
    public class SerializationTests
    {
        [TestMethod()]
        public void GenerateTests()
        {
            var assembly = Assembly.GetAssembly(typeof(NoteName));
            var types = assembly.GetTypes().ToList();
            foreach (var type in types)
            {
                if (type.Name == "NoteName")
                {
                    new object();
                }

                if (type.IsSerializable)
                {
                    var code = $@"
        [TestMethod()]
        public void Serialize{type.Name}()
        {{
            Assert.Fail();
        }}";
                    Debug.WriteLine(code);
                    new Object();
                }
            }
            new object();
        }

        [TestMethod()]
        public void SerializeNoteName()
        {
            var nn = NoteName.G;
            
            var json = JsonConvert.SerializeObject(nn);
            Debug.WriteLine(json);
            var deserialized = JsonConvert.DeserializeObject<NoteName>(json);

            Assert.AreEqual(nn, deserialized);

            new object();
        }

        [TestMethod()]
        public void SerializeKeySignature()
        {
            var key = KeySignature.AbMajor;

            var json = JsonConvert.SerializeObject(key);
            Debug.WriteLine(json);
            var deserialized = JsonConvert.DeserializeObject<KeySignature>(json);

            Assert.AreEqual(key, deserialized);

            new object();
        }

        [TestMethod()]
        public void SerializeInterval()
        {
            var actual = Interval.Augmented4th;

            var json = JsonConvert.SerializeObject(actual);
            Debug.WriteLine(json);
            var deserialized = JsonConvert.DeserializeObject<Interval>(json);

            Assert.AreEqual(actual, deserialized);

            new object();
        }
        
        [TestMethod()]
        public void SerializeChordToneInterval()
        {
            var cti = ChordToneInterval.Augmented11th;

            var json = JsonConvert.SerializeObject(cti, Formatting.Indented);
            Debug.WriteLine(json);
            var deserialized = JsonConvert.DeserializeObject<ChordToneInterval>(json);

            Assert.AreEqual(cti, deserialized);

            new object();
        }


        [TestMethod()]
        public void SerializeChordType()
        {
            var ct = ChordType.Dominant7Sharp9;

            var json = JsonConvert.SerializeObject(ct, Formatting.Indented);
            Debug.WriteLine(json);
            var deserialized = JsonConvert.DeserializeObject<ChordType>(json);

            Assert.AreEqual(ct, deserialized);

            new object();
        }

        [TestMethod()]
        public void SerializeChordFormula()
        {
            var formula = ChordFormula.A7sharp9;

            var json = JsonConvert.SerializeObject(formula, Formatting.Indented);
            Debug.WriteLine(json);
            var deserialized = JsonConvert.DeserializeObject<ChordFormula>(json);

            Assert.AreEqual(formula, deserialized);

            new object();
        }


        [TestMethod()]
        public void SerializeChordEntityBase()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void SerializeClassBase()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BorrowedChordGridsTest()
        {
            foreach (var key in KeySignature.Catalog)
            {
                var rule = new BorrowedChordHarmonicAnalysisRule();
                var result = rule.CreateGrids(key);
                Assert.IsNotNull(result);

                var json = JsonConvert.SerializeObject(result, Formatting.Indented);
                var serialized = JsonConvert.DeserializeObject<List<Grid>>(json);

                for (int i = 0; i < result.Count; ++i)
                {
                    var a = result[i];
                    var b = serialized[i];
                    Assert.AreEqual(a, b);
                }
                new object();
            }
            new object();
        }


    }//class
}//ns

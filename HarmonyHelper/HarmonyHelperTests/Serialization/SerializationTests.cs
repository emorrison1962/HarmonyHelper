using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
using Eric.Morrison.Harmony.Scales;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

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
        public void SerializeModeEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeIntervalValuesEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeIntervalFunctionalValuesEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeOctaveEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeChordTypesEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeChordTonesBitmaskEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeDirectionEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeFiveStringBassPositionEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeGuitarPositionEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeToStringEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeChordFunctionEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeChordToneFunctionEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeScaleToneFunctionEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeIntervalRoleTypeEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeIsDiatonicEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeChordFormulaContainsEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeClassBase()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeDurationEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeTieTypeEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeClefEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializePartTypeEnum()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void SerializeBarlineStyleEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeEndingTypeEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeRepeatEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeNoteValuesEnum()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SerializeExplicitNoteValuesEnum()
        {
            Assert.Fail();
        }

    }//class
}//ns

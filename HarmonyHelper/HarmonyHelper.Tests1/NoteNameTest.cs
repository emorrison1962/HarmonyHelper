// <copyright file="NoteNameTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections.Generic;
using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Intervals;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eric.Morrison.Harmony.Tests
{
    /// <summary>This class contains parameterized unit tests for NoteName</summary>
    [PexClass(typeof(NoteName))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NoteNameTest
    {
        /// <summary>Test stub for get_AccidentalCount()</summary>
        [PexMethod]
        public int AccidentalCountGetTest([PexAssumeUnderTest]NoteName target)
        {
            int result = target.AccidentalCount;
            return result;
            // TODO: add assertions to method NoteNameTest.AccidentalCountGetTest(NoteName)
        }

        /// <summary>Test stub for get_Catalog()</summary>
        [PexMethod]
        public IEnumerable<NoteName> CatalogGetTest()
        {
            IEnumerable<NoteName> result = NoteName.Catalog;
            return result;
            // TODO: add assertions to method NoteNameTest.CatalogGetTest()
        }

        /// <summary>Test stub for Compare(NoteName, NoteName)</summary>
        [PexMethod]
        public int CompareTest(NoteName a, NoteName b)
        {
            int result = NoteName.Compare(a, b);
            return result;
            // TODO: add assertions to method NoteNameTest.CompareTest(NoteName, NoteName)
        }

        /// <summary>Test stub for CompareTo(NoteName)</summary>
        [PexMethod]
        public int CompareToTest([PexAssumeUnderTest]NoteName target, NoteName other)
        {
            int result = target.CompareTo(other);
            return result;
            // TODO: add assertions to method NoteNameTest.CompareToTest(NoteName, NoteName)
        }

        /// <summary>Test stub for Copy()</summary>
        [PexMethod]
        public NoteName CopyTest([PexAssumeUnderTest]NoteName target)
        {
            NoteName result = target.Copy();
            return result;
            // TODO: add assertions to method NoteNameTest.CopyTest(NoteName)
        }

        /// <summary>Test stub for Copy(NoteName)</summary>
        [PexMethod]
        public NoteName CopyTest01(NoteName src)
        {
            NoteName result = NoteName.Copy(src);
            return result;
            // TODO: add assertions to method NoteNameTest.CopyTest01(NoteName)
        }

        /// <summary>Test stub for Equals(NoteName)</summary>
        [PexMethod]
        public bool EqualsTest([PexAssumeUnderTest]NoteName target, NoteName other)
        {
            bool result = target.Equals(other);
            return result;
            // TODO: add assertions to method NoteNameTest.EqualsTest(NoteName, NoteName)
        }

        /// <summary>Test stub for Equals(Object)</summary>
        [PexMethod]
        public bool EqualsTest01([PexAssumeUnderTest]NoteName target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method NoteNameTest.EqualsTest01(NoteName, Object)
        }

        /// <summary>Test stub for GetEnharmonicEquivalents(NoteName)</summary>
        [PexMethod]
        public List<NoteName> GetEnharmonicEquivalentsTest(NoteName nn)
        {
            List<NoteName> result = NoteName.GetEnharmonicEquivalents(nn);
            return result;
            // TODO: add assertions to method NoteNameTest.GetEnharmonicEquivalentsTest(NoteName)
        }

        /// <summary>Test stub for GetHashCode()</summary>
        [PexMethod]
        public int GetHashCodeTest([PexAssumeUnderTest]NoteName target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method NoteNameTest.GetHashCodeTest(NoteName)
        }

        /// <summary>Test stub for IsValidTransposition(NoteName, Interval)</summary>
        [PexMethod]
        public bool IsValidTranspositionTest(NoteName note, Interval interval)
        {
            bool result = NoteName.IsValidTransposition(note, interval);
            return result;
            // TODO: add assertions to method NoteNameTest.IsValidTranspositionTest(NoteName, Interval)
        }

        /// <summary>Test stub for get_MaxValue()</summary>
        [PexMethod]
        public int MaxValueGetTest()
        {
            int result = NoteName.MaxValue;
            return result;
            // TODO: add assertions to method NoteNameTest.MaxValueGetTest()
        }

        /// <summary>Test stub for get_MinValue()</summary>
        [PexMethod]
        public int MinValueGetTest()
        {
            int result = NoteName.MinValue;
            return result;
            // TODO: add assertions to method NoteNameTest.MinValueGetTest()
        }

        /// <summary>Test stub for ResolveInterval(Interval, NoteName, NoteName, Boolean)</summary>
        [PexMethod]
        public Interval ResolveIntervalTest(
            Interval interval,
            NoteName a,
            NoteName b,
            bool invert
        )
        {
            Interval result = NoteName.ResolveInterval(interval, a, b, invert);
            return result;
            // TODO: add assertions to method NoteNameTest.ResolveIntervalTest(Interval, NoteName, NoteName, Boolean)
        }

        /// <summary>Test stub for ResolveNoteName(NoteName, Interval, Int32)</summary>
        [PexMethod]
        public NoteName ResolveNoteNameTest(
            NoteName src,
            Interval interval,
            int noteVal
        )
        {
            NoteName result = NoteName.ResolveNoteName(src, interval, noteVal);
            return result;
            // TODO: add assertions to method NoteNameTest.ResolveNoteNameTest(NoteName, Interval, Int32)
        }

        /// <summary>Test stub for ToString()</summary>
        [PexMethod]
        public string ToStringTest([PexAssumeUnderTest]NoteName target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method NoteNameTest.ToStringTest(NoteName)
        }

        /// <summary>Test stub for TryTransposeUp(NoteName, Interval, NoteName&amp;, NoteName&amp;)</summary>
        [PexMethod]
        public bool TryTransposeUpTest(
            NoteName src,
            Interval interval,
            out NoteName txposed,
            out NoteName enharmonicEquivelent
        )
        {
            bool result = NoteName.TryTransposeUp
                              (src, interval, out txposed, out enharmonicEquivelent);
            return result;
            // TODO: add assertions to method NoteNameTest.TryTransposeUpTest(NoteName, Interval, NoteName&, NoteName&)
        }

        /// <summary>Test stub for op_Addition(NoteName, Interval)</summary>
        [PexMethod]
        public NoteName op_AdditionTest(NoteName note, Interval interval)
        {
            NoteName result = note + interval;
            return result;
            // TODO: add assertions to method NoteNameTest.op_AdditionTest(NoteName, Interval)
        }

        /// <summary>Test stub for op_Equality(NoteName, NoteName)</summary>
        [PexMethod]
        public bool op_EqualityTest(NoteName a, NoteName b)
        {
            bool result = a == b;
            return result;
            // TODO: add assertions to method NoteNameTest.op_EqualityTest(NoteName, NoteName)
        }

        /// <summary>Test stub for op_Explicit(Int32)</summary>
        [PexMethod]
        public NoteName op_ExplicitTest(int i)
        {
            NoteName result = (NoteName)i;
            return result;
            // TODO: add assertions to method NoteNameTest.op_ExplicitTest(Int32)
        }

        /// <summary>Test stub for op_GreaterThanOrEqual(NoteName, NoteName)</summary>
        [PexMethod]
        public bool op_GreaterThanOrEqualTest(NoteName a, NoteName b)
        {
            bool result = a >= b;
            return result;
            // TODO: add assertions to method NoteNameTest.op_GreaterThanOrEqualTest(NoteName, NoteName)
        }

        /// <summary>Test stub for op_GreaterThan(NoteName, NoteName)</summary>
        [PexMethod]
        public bool op_GreaterThanTest(NoteName a, NoteName b)
        {
            bool result = a > b;
            return result;
            // TODO: add assertions to method NoteNameTest.op_GreaterThanTest(NoteName, NoteName)
        }

        /// <summary>Test stub for op_Implicit(NoteName)</summary>
        [PexMethod]
        public int op_ImplicitTest(NoteName nn)
        {
            int result = (int)nn;
            return result;
            // TODO: add assertions to method NoteNameTest.op_ImplicitTest(NoteName)
        }

        /// <summary>Test stub for op_Inequality(NoteName, NoteName)</summary>
        [PexMethod]
        public bool op_InequalityTest(NoteName a, NoteName b)
        {
            bool result = a != b;
            return result;
            // TODO: add assertions to method NoteNameTest.op_InequalityTest(NoteName, NoteName)
        }

        /// <summary>Test stub for op_LessThanOrEqual(NoteName, NoteName)</summary>
        [PexMethod]
        public bool op_LessThanOrEqualTest(NoteName a, NoteName b)
        {
            bool result = a <= b;
            return result;
            // TODO: add assertions to method NoteNameTest.op_LessThanOrEqualTest(NoteName, NoteName)
        }

        /// <summary>Test stub for op_LessThan(NoteName, NoteName)</summary>
        [PexMethod]
        public bool op_LessThanTest(NoteName a, NoteName b)
        {
            bool result = a < b;
            return result;
            // TODO: add assertions to method NoteNameTest.op_LessThanTest(NoteName, NoteName)
        }

        /// <summary>Test stub for op_Subtraction(NoteName, Interval)</summary>
        [PexMethod]
        public NoteName op_SubtractionTest(NoteName note, Interval interval)
        {
            NoteName result = note - interval;
            return result;
            // TODO: add assertions to method NoteNameTest.op_SubtractionTest(NoteName, Interval)
        }

        /// <summary>Test stub for op_Subtraction(NoteName, NoteName)</summary>
        [PexMethod]
        public Interval op_SubtractionTest01(NoteName a, NoteName b)
        {
            Interval result = a - b;
            return result;
            // TODO: add assertions to method NoteNameTest.op_SubtractionTest01(NoteName, NoteName)
        }
    }
}

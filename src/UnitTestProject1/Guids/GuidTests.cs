using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Guids;
using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable ExpressionIsAlwaysNull

namespace UnitTestProject1.Guids {

    [TestClass]
    public class GuidTests {

        [TestMethod]
        public void HasValue() {

            Guid guid1 = default;
            Guid guid2 = Guid.Empty;
            Guid guid3 = Guid.NewGuid();

            Guid? guid4 = default;
            Guid? guid5 = Guid.Empty;
            Guid? guid6 = Guid.NewGuid();

            Assert.IsFalse(guid1.HasValue());
            Assert.IsFalse(guid2.HasValue());
            Assert.IsTrue(guid3.HasValue());

            Assert.IsFalse(guid4.HasValue());
            Assert.IsFalse(guid5.HasValue());
            Assert.IsTrue(guid6.HasValue());

        }

        [TestMethod]
        public void IsEmpty() {

            Guid guid1 = default;
            Guid guid2 = Guid.Empty;
            Guid guid3 = Guid.NewGuid();

            Assert.IsTrue(guid1.IsEmpty(), "#1 -> " + guid1);
            Assert.IsTrue(guid2.IsEmpty(), "#2 -> " + guid2);
            Assert.IsFalse(guid3.IsEmpty(), "#3 -> " + guid3);

        }

        [TestMethod]
        public void IsNullOrEmpty() {

            Guid? guid1 = default;
            Guid? guid2 = Guid.Empty;
            Guid? guid3 = Guid.NewGuid();

            Assert.IsTrue(guid1.IsNullOrEmpty(), "#1 -> " + guid1);
            Assert.IsTrue(guid2.IsNullOrEmpty(), "#2 -> " + guid2);
            Assert.IsFalse(guid3.IsNullOrEmpty(), "#3 -> " + guid3);

        }

        [TestMethod]
        public void ToGuid() {

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", GuidUtils.ToGuid(0).ToString(), "#1A");
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", 0.ToGuid().ToString(), "#1B");
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", ((long)0).ToGuid().ToString(), "#1C");

            Assert.AreEqual("00000400-0000-0000-0000-000000000000", GuidUtils.ToGuid(1024).ToString(), "#2A");
            Assert.AreEqual("00000400-0000-0000-0000-000000000000", 1024.ToGuid().ToString(), "#2B");
            Assert.AreEqual("00000400-0000-0000-0000-000000000000", ((long)1024).ToGuid().ToString(), "#2C");

            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", GuidUtils.ToGuid(int.MaxValue).ToString(), "#3A");
            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", int.MaxValue.ToGuid().ToString(), "#3B");
            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", ((long)int.MaxValue).ToGuid().ToString(), "#3C");

            Assert.AreEqual("ffffffff-ffff-7fff-0000-000000000000", GuidUtils.ToGuid(long.MaxValue).ToString(), "#2A");
            Assert.AreEqual("ffffffff-ffff-7fff-0000-000000000000", long.MaxValue.ToGuid().ToString(), "#4B");

        }

        [TestMethod]
        public void ToGuidArray1() {

            int[] input = { 0, 1024, int.MaxValue };

            Guid[] result1 = GuidUtils.ToGuidArray(input);
            Guid[] result2 = input.ToGuidArray();

            Assert.AreEqual(3, result1.Length);
            Assert.AreEqual(3, result2.Length);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result1[0].ToString());
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result2[0].ToString());

            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result1[1].ToString());
            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result2[1].ToString());

            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result1[2].ToString());
            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result2[2].ToString());

        }

        [TestMethod]
        public void ToGuidArray2() {

            List<int> input = new[] { 0, 1024, int.MaxValue }.ToList();

            Guid[] result1 = GuidUtils.ToGuidArray(input);
            Guid[] result2 = input.ToGuidArray();

            Assert.AreEqual(3, result1.Length);
            Assert.AreEqual(3, result2.Length);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result1[0].ToString());
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result2[0].ToString());

            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result1[1].ToString());
            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result2[1].ToString());

            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result1[2].ToString());
            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result2[2].ToString());

        }

        [TestMethod]
        public void ToGuidArray3() {

            long[] input = { 0, 1024, int.MaxValue, long.MaxValue };

            Guid[] result1 = GuidUtils.ToGuidArray(input);
            Guid[] result2 = input.ToGuidArray();

            Assert.AreEqual(4, result1.Length);
            Assert.AreEqual(4, result2.Length);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result1[0].ToString());
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result2[0].ToString());

            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result1[1].ToString());
            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result2[1].ToString());

            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result1[2].ToString());
            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result2[2].ToString());

            Assert.AreEqual("ffffffff-ffff-7fff-0000-000000000000", result1[3].ToString());
            Assert.AreEqual("ffffffff-ffff-7fff-0000-000000000000", result2[3].ToString());

        }

        [TestMethod]
        public void ToGuidArray4() {

            List<long> input = new[] { 0, 1024, int.MaxValue, long.MaxValue }.ToList();

            Guid[] result1 = GuidUtils.ToGuidArray(input);
            Guid[] result2 = input.ToGuidArray();

            Assert.AreEqual(4, result1.Length);
            Assert.AreEqual(4, result2.Length);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result1[0].ToString());
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result2[0].ToString());

            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result1[1].ToString());
            Assert.AreEqual("00000400-0000-0000-0000-000000000000", result2[1].ToString());

            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result1[2].ToString());
            Assert.AreEqual("7fffffff-0000-0000-0000-000000000000", result2[2].ToString());

            Assert.AreEqual("ffffffff-ffff-7fff-0000-000000000000", result1[3].ToString());
            Assert.AreEqual("ffffffff-ffff-7fff-0000-000000000000", result2[3].ToString());

        }

        [TestMethod]
        public void ToInt32() {

            Guid guid1 = new Guid("00000000-0000-0000-0000-000000000000");
            Guid guid2 = new Guid("00000400-0000-0000-0000-000000000000");
            Guid guid3 = new Guid("7fffffff-0000-0000-0000-000000000000");

            Assert.AreEqual(0, GuidUtils.ToInt32(guid1), "#1A");
            Assert.AreEqual(0, guid1.ToInt32(), "#1B");

            Assert.AreEqual(1024, GuidUtils.ToInt32(guid2), "#2A");
            Assert.AreEqual(1024, guid2.ToInt32(), "#2B");

            Assert.AreEqual(int.MaxValue, GuidUtils.ToInt32(guid3), "#3A");
            Assert.AreEqual(int.MaxValue, guid3.ToInt32(), "#3B");

        }

        [TestMethod]
        public void ToInt64() {

            Guid guid1 = new Guid("00000000-0000-0000-0000-000000000000");
            Guid guid2 = new Guid("00000400-0000-0000-0000-000000000000");
            Guid guid3 = new Guid("7fffffff-0000-0000-0000-000000000000");
            Guid guid4 = new Guid("ffffffff-ffff-7fff-0000-000000000000");

            Assert.AreEqual(0, GuidUtils.ToInt64(guid1), "#1A");
            Assert.AreEqual(0, guid1.ToInt64(), "#1B");

            Assert.AreEqual(1024, GuidUtils.ToInt64(guid2), "#2A");
            Assert.AreEqual(1024, guid2.ToInt64(), "#2B");

            Assert.AreEqual(int.MaxValue, GuidUtils.ToInt64(guid3), "#3A");
            Assert.AreEqual(int.MaxValue, guid3.ToInt64(), "#3B");

            Assert.AreEqual(long.MaxValue, GuidUtils.ToInt64(guid4), "#4A");
            Assert.AreEqual(long.MaxValue, guid4.ToInt64(), "#4B");

        }

        [TestMethod]
        public void ToInt32Array() {

            Guid[] input = new Guid[] {
                new Guid("00000000-0000-0000-0000-000000000000"),
                new Guid("00000400-0000-0000-0000-000000000000"),
                new Guid("7fffffff-0000-0000-0000-000000000000")
            };

            int[] result1 = GuidUtils.ToInt32Array(input);
            int[] result2 = input.ToInt32Array();

            Assert.AreEqual(3, result1.Length);
            Assert.AreEqual(3, result2.Length);

            Assert.AreEqual(0, result1[0], "#1A");
            Assert.AreEqual(0, result2[0], "#1B");

            Assert.AreEqual(1024, result1[1], "#2A");
            Assert.AreEqual(1024, result2[1], "#2B");

            Assert.AreEqual(int.MaxValue, result1[2], "#3A");
            Assert.AreEqual(int.MaxValue, result2[2], "#3B");

        }

        [TestMethod]
        public void ToInt64Array() {

            Guid[] input = new Guid[] {
                new Guid("00000000-0000-0000-0000-000000000000"),
                new Guid("00000400-0000-0000-0000-000000000000"),
                new Guid("7fffffff-0000-0000-0000-000000000000"),
                new Guid("ffffffff-ffff-7fff-0000-000000000000")
            };

            long[] result1 = GuidUtils.ToInt64Array(input);
            long[] result2 = input.ToInt64Array();

            Assert.AreEqual(4, result1.Length);
            Assert.AreEqual(4, result2.Length);

            Assert.AreEqual(0, result1[0], "#1A");
            Assert.AreEqual(0, result2[0], "#1B");

            Assert.AreEqual(1024, result1[1], "#2A");
            Assert.AreEqual(1024, result2[1], "#2B");

            Assert.AreEqual(int.MaxValue, result1[2], "#3A");
            Assert.AreEqual(int.MaxValue, result2[2], "#3B");

            Assert.AreEqual(long.MaxValue, result1[3], "#4A");
            Assert.AreEqual(long.MaxValue, result2[3], "#4B");

        }

    }

}
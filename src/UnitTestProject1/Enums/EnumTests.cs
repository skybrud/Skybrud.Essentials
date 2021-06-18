using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Enums;

namespace UnitTestProject1.Enums {

    [TestClass]
    public class EnumTests {

        [TestMethod]
        public void GetEnumValues() {

            Enum[] values = EnumUtils.GetEnumValues(typeof(SortOrder));

            Assert.AreEqual(2, values.Length);

            Assert.AreEqual(values[0], SortOrder.Ascending);
            Assert.AreEqual(values[1], SortOrder.Descending);

        }

        [TestMethod]
        public void GetEnumValuesOfT() {

            SortOrder[] values = EnumUtils.GetEnumValues<SortOrder>();

            Assert.AreEqual(2, values.Length);

            Assert.AreEqual(values[0], SortOrder.Ascending);
            Assert.AreEqual(values[1], SortOrder.Descending);

        }

        [TestMethod]
        public void ParseEnum() {

            var samples = new[] {
                new { Input = default(string), Expected = HttpStatusCode.OK },
                new { Input = "", Expected = HttpStatusCode.OK },
                new { Input = "ok", Expected = HttpStatusCode.OK },
                new { Input = "OK", Expected = HttpStatusCode.OK },
                new { Input = "Ok", Expected = HttpStatusCode.OK },
                new { Input = "Not found", Expected = HttpStatusCode.NotFound },
                new { Input = "NOT FOUND", Expected = HttpStatusCode.NotFound },
                new { Input = "NotFound", Expected = HttpStatusCode.NotFound },
                new { Input = "not found", Expected = HttpStatusCode.NotFound }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, EnumUtils.ParseEnum(sample.Input, HttpStatusCode.OK));
            }

        }

        [TestMethod]
        public void ParseEnumArray() {

            var samples = new[] {
                new { Input = default(string), Expected = new HttpStatusCode[0] },
                new { Input = "", Expected = new HttpStatusCode[0] },
                new { Input = "ok", Expected = new [] { HttpStatusCode.OK } },
                new { Input = "OK", Expected = new [] { HttpStatusCode.OK } },
                new { Input = "Ok", Expected = new [] { HttpStatusCode.OK } },
                new { Input = "notfound", Expected = new [] { HttpStatusCode.NotFound } },
                new { Input = "NOTFOUND", Expected = new [] { HttpStatusCode.NotFound } },
                new { Input = "NotFound", Expected = new [] { HttpStatusCode.NotFound } },
                new { Input = "ok,notfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK,NOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK,NotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "ok notfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK NOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK NotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "ok\nnotfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\nNOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\nNotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "ok\tnotfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\tNOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\tNotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } }
            };

            foreach (var sample in samples) {

                HttpStatusCode[] array = EnumUtils.ParseEnumArray<HttpStatusCode>(sample.Input);

                Assert.AreEqual(sample.Expected.Length, array.Length);
                for (int i = 0; i < array.Length; i++) {
                    Assert.AreEqual(sample.Expected[i], array[i]);
                }

                bool result = EnumUtils.TryParseEnumArray(sample.Input, out array);

                Assert.AreEqual(true, result);
                Assert.AreEqual(sample.Expected.Length, array.Length);
                for (int i = 0; i < array.Length; i++) {
                    Assert.AreEqual(sample.Expected[i], array[i]);
                }

            }

        }

        [TestMethod]
        public void TryParseEnum() {
            
            bool status1 = EnumUtils.TryParseEnum(null, out HttpStatusCode result1);
            bool status2 = EnumUtils.TryParseEnum("", out HttpStatusCode result2);
            bool status3 = EnumUtils.TryParseEnum("ok", out HttpStatusCode result3);
            bool status4 = EnumUtils.TryParseEnum("OK", out HttpStatusCode result4);
            bool status5 = EnumUtils.TryParseEnum("Ok", out HttpStatusCode result5);
            bool status6 = EnumUtils.TryParseEnum("Not found", out HttpStatusCode result6);
            bool status7 = EnumUtils.TryParseEnum("NOT FOUND", out HttpStatusCode result7);
            bool status8 = EnumUtils.TryParseEnum("NotFound", out HttpStatusCode result8);
            bool status9 = EnumUtils.TryParseEnum("not found", out HttpStatusCode result9);

            Assert.IsFalse(status1);
            Assert.AreEqual(result1, default);

            Assert.IsFalse(status2);
            Assert.AreEqual(result2, default);

            Assert.IsTrue(status3);
            Assert.AreEqual(result3, HttpStatusCode.OK);

            Assert.IsTrue(status4);
            Assert.AreEqual(result4, HttpStatusCode.OK);

            Assert.IsTrue(status5);
            Assert.AreEqual(result5, HttpStatusCode.OK);

            Assert.IsTrue(status6);
            Assert.AreEqual(result6, HttpStatusCode.NotFound);

            Assert.IsTrue(status7);
            Assert.AreEqual(result7, HttpStatusCode.NotFound);

            Assert.IsTrue(status8);
            Assert.AreEqual(result8, HttpStatusCode.NotFound);

            Assert.IsTrue(status9);
            Assert.AreEqual(result9, HttpStatusCode.NotFound);

        }

        [TestMethod]
        public void Min() {

            var result1 = EnumUtils.Min(HttpStatusCode.OK, HttpStatusCode.NotFound);
            var result2 = EnumUtils.Min(HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.OK, result1, "#1");
            Assert.AreEqual(HttpStatusCode.OK, result2, "#2");

        }

        [TestMethod]
        public void MinArray() {

            var result1 = EnumUtils.Min(HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue);
            var result2 = EnumUtils.Min(HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.Continue, result1, "#1");
            Assert.AreEqual(HttpStatusCode.Continue, result2, "#2");

        }

        [TestMethod]
        public void MinList() {

            var result1 = EnumUtils.Min(new List<HttpStatusCode> { HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue });
            var result2 = EnumUtils.Min(new List<HttpStatusCode> { HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK });

            Assert.AreEqual(HttpStatusCode.Continue, result1, "#1");
            Assert.AreEqual(HttpStatusCode.Continue, result2, "#2");

        }

        [TestMethod]
        public void Max() {

            var result1 = EnumUtils.Max(HttpStatusCode.OK, HttpStatusCode.NotFound);
            var result2 = EnumUtils.Max(HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.NotFound, result1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2");

        }

        [TestMethod]
        public void MaxArray() {

            var result1 = EnumUtils.Max(HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue);
            var result2 = EnumUtils.Max(HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.NotFound, result1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2");

        }

        [TestMethod]
        public void MaxList() {

            var result1 = EnumUtils.Max(new List<HttpStatusCode> { HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue });
            var result2 = EnumUtils.Max(new List<HttpStatusCode> { HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK });

            Assert.AreEqual(HttpStatusCode.NotFound, result1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2");

        }

    }

}
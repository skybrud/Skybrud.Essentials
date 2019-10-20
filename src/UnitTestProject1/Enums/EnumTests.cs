using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Enums;

namespace UnitTestProject1.Enums {

    [TestClass]
    public class EnumTests {

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
        public void Min() {

            var result1 = EnumUtils.Min(HttpStatusCode.OK, HttpStatusCode.NotFound);
            var result2 = EnumUtils.Min(HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.OK, result1, "#1");
            Assert.AreEqual(HttpStatusCode.OK, result2, "#2");

        }

        [TestMethod]
        public void Max() {

            var result1 = EnumUtils.Max(HttpStatusCode.OK, HttpStatusCode.NotFound);
            var result2 = EnumUtils.Max(HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.NotFound, result1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2");

        }

    }

}
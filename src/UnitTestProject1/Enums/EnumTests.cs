using System;
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
                Assert.AreEqual(sample.Expected, EnumHelpers.ParseEnum(sample.Input, HttpStatusCode.OK));
            }

        }

    }

}
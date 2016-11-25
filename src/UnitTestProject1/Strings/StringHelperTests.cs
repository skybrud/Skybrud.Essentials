using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;

namespace UnitTestProject1.Strings {

    [TestClass]
    public class StringHelperTests {

        [TestMethod]
        public void ParseBoolean() {
            
            Assert.AreEqual(true, StringHelper.ParseBoolean("true"), "Check #1 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("false"), "Check #2 failed");
            Assert.AreEqual(true, StringHelper.ParseBoolean("True"), "Check #3 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("False"), "Check #4 failed");

            Assert.AreEqual(true, StringHelper.ParseBoolean("1"), "Check #5 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("0"), "Check #6 failed");
            
            Assert.AreEqual(true, StringHelper.ParseBoolean("t"), "Check #7 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("f"), "Check #8 failed");
            Assert.AreEqual(true, StringHelper.ParseBoolean("T"), "Check #9 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("F"), "Check #10 failed");
            
            Assert.AreEqual(false, StringHelper.ParseBoolean(""));
            Assert.AreEqual(false, StringHelper.ParseBoolean(default(string)));
            Assert.AreEqual(false, StringHelper.ParseBoolean(default(object)));

        }

        [TestMethod]
        public void ToUnderscore() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "HelloWorld", Expected = "hello_world" },
                new { Input = "helloWorld", Expected = "hello_world" },
                new { Input = "HELLO_WORLD", Expected = "hello_world" },
                new { Input = "HelloWorld", Expected = "hello_world" },
                new { Input = "Hello World", Expected = "hello_world" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "not_found" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "not_implemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToUnderscore(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToUnderscore(sample.Input));
            }

        }

        [TestMethod]
        public void ToCamelCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "helloWorld" },
                new { Input = "HELLO_WORLD", Expected = "helloWorld" },
                new { Input = "HelloWorld", Expected = "helloWorld" },
                new { Input = "Hello World", Expected = "helloWorld" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "notFound" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "notImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
            }

        }

        [TestMethod]
        public void ToPascalCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "HelloWorld" },
                new { Input = "HELLO_WORLD", Expected = "HelloWorld" },
                new { Input = "HelloWorld", Expected = "HelloWorld" },
                new { Input = "Hello World", Expected = "HelloWorld" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "NotFound" },
                new { Input = HttpStatusCode.OK, Expected = "Ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "NotImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
            }

        }

        [TestMethod]
        public void FirstCharToUpper() {

            var samples = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "Hello_world" },
                new { Input = "HELLO_WORLD", Expected = "HELLO_WORLD" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, StringHelper.FirstCharToUpper(sample.Input));
            }

        }

    }

}
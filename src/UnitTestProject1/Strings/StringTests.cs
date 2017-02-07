using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;

namespace UnitTestProject1.Strings {

    [TestClass]
    public class StringTests {

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

            Assert.AreEqual(true, StringUtils.ParseBoolean("true"), "Check #1 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("false"), "Check #2 failed");
            Assert.AreEqual(true, StringUtils.ParseBoolean("True"), "Check #3 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("False"), "Check #4 failed");

            Assert.AreEqual(true, StringUtils.ParseBoolean("1"), "Check #5 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("0"), "Check #6 failed");

            Assert.AreEqual(true, StringUtils.ParseBoolean("t"), "Check #7 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("f"), "Check #8 failed");
            Assert.AreEqual(true, StringUtils.ParseBoolean("T"), "Check #9 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("F"), "Check #10 failed");

            Assert.AreEqual(false, StringUtils.ParseBoolean(""));
            Assert.AreEqual(false, StringUtils.ParseBoolean(default(string)));
            Assert.AreEqual(false, StringUtils.ParseBoolean(default(object)));

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
                new { Input = "Hello World", Expected = "hello_world" },
                new { Input = "Hello (World)", Expected = "hello_world" },
                new { Input = "Hello / World", Expected = "hello_world" },
                new { Input = "Hello % World", Expected = "hello_world" },
                new { Input = "      Hello World", Expected = "hello_world" },
                new { Input = "Hello World      ", Expected = "hello_world" },
                new { Input = "Hello      World", Expected = "hello_world" },
                new { Input = "______Hello World", Expected = "hello_world" },
                new { Input = "Hello World______", Expected = "hello_world" },
                new { Input = "Hello______World", Expected = "hello_world" },
                new { Input = "Rød grød med fløde", Expected = "rød_grød_med_fløde" },
                new { Input = "øv bøv", Expected = "øv_bøv" },
                new { Input = "Øv bøv", Expected = "øv_bøv" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "not_found" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "not_implemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToUnderscore(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToUnderscore(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToUnderscore(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToUnderscore(sample.Input));
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
                new { Input = "Hello World", Expected = "helloWorld" },
                new { Input = "Hello (World)", Expected = "helloWorld" },
                new { Input = "Hello / World", Expected = "helloWorld" },
                new { Input = "Hello % World", Expected = "helloWorld" },
                new { Input = "      Hello World", Expected = "helloWorld" },
                new { Input = "Hello World      ", Expected = "helloWorld" },
                new { Input = "Hello      World", Expected = "helloWorld" },
                new { Input = "______Hello World", Expected = "helloWorld" },
                new { Input = "Hello World______", Expected = "helloWorld" },
                new { Input = "Hello______World", Expected = "helloWorld" },
                new { Input = "Rød grød med fløde", Expected = "rødGrødMedFløde" },
                new { Input = "øv bøv", Expected = "øvBøv" },
                new { Input = "Øv bøv", Expected = "øvBøv" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "notFound" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "notImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCamelCase(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCamelCase(sample.Input));
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
                new { Input = "Hello World", Expected = "HelloWorld" },
                new { Input = "Hello (World)", Expected = "HelloWorld" },
                new { Input = "Hello / World", Expected = "HelloWorld" },
                new { Input = "Hello % World", Expected = "HelloWorld" },
                new { Input = "      Hello World", Expected = "HelloWorld" },
                new { Input = "Hello World      ", Expected = "HelloWorld" },
                new { Input = "Hello      World", Expected = "HelloWorld" },
                new { Input = "______Hello World", Expected = "HelloWorld" },
                new { Input = "Hello World______", Expected = "HelloWorld" },
                new { Input = "Hello______World", Expected = "HelloWorld" },
                new { Input = "Rød grød med fløde", Expected = "RødGrødMedFløde" },
                new { Input = "øv bøv", Expected = "ØvBøv" },
                new { Input = "Øv bøv", Expected = "ØvBøv" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "NotFound" },
                new { Input = HttpStatusCode.OK, Expected = "Ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "NotImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToPascalCase(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToPascalCase(sample.Input));
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
                Assert.AreEqual(sample.Expected, StringUtils.FirstCharToUpper(sample.Input));
            }

        }

        [TestMethod]
        public void WordCount() {

            string[] samples = {
                "Bacon ipsum dolor amet cupim beef ribs bresaola ribeye kevin fatback bacon sirloin picanha meatball! Hamburger bacon pig shoulder? Flank strip steak shoulder, tri-tip ham hock tenderloin meatball alcatra andouille boudin pork doner turkey. Turkey andouille doner swine turducken brisket kielbasa picanha jerky meatball burgdoggen pork shoulder ribeye. Ground round ball tip tenderloin tongue beef hamburger meatball porchetta filet mignon ham hock shoulder burgdoggen pig andouille tail. Pork chop shank bacon, pastrami corned beef fatback kevin. Fatback leberkas pork kielbasa, pork chop burgdoggen picanha meatball brisket spare ribs beef ribs.\n\nTenderloin prosciutto kielbasa beef ribs turducken jowl. Ball tip leberkas capicola, frankfurter kevin bresaola swine turducken pancetta meatloaf. Beef ribs corned beef cupim venison alcatra. Bresaola jerky porchetta beef ribs meatball, ball tip cow sausage cupim kielbasa. Frankfurter sausage tail brisket tenderloin cupim ham hock ribeye sirloin. Frankfurter biltong beef turducken."
            };

            foreach (string sample in samples) {

                int count1 = StringUtils.WordCount(sample);
                int count2 = sample.Split(new[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;

                Assert.AreEqual(count1, count2);

            }

        }

        [TestMethod]
        public void HighlightKeywords() {

            var samples = new [] {
                new {
                    Input = "Bacon ipsum dolor amet cupim beef ribs bresaola ribeye kevin fatback bacon sirloin picanha meatball.",
                    Output = "<span class=\"highlighted\">Bacon</span> ipsum dolor amet cupim <span class=\"highlighted\">beef</span> ribs bresaola ribeye kevin fatback <span class=\"highlighted\">bacon</span> sirloin picanha meatball."
                }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Output, StringUtils.HighlightKeywords(sample.Input, "highlighted", "bacon", "beef"));

            }

        }


        

    }

}
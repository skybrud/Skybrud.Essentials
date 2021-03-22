using System;
using System.Globalization;
using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

#pragma warning disable 618

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

            Assert.AreEqual(true, StringUtils.ParseBoolean("on"), "Check #11 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("off"), "Check #12 failed");
            Assert.AreEqual(true, StringUtils.ParseBoolean("On"), "Check #13 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("Off"), "Check #14 failed");
            Assert.AreEqual(true, StringUtils.ParseBoolean("ON"), "Check #15 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("OFF"), "Check #16 failed");

            Assert.AreEqual(false, StringUtils.ParseBoolean(""));
            Assert.AreEqual(false, StringUtils.ParseBoolean(default(string)));
            Assert.AreEqual(false, StringUtils.ParseBoolean(default(object)));

        }

        [TestMethod]
        public void ParseInt32() {

            Assert.AreEqual(0, StringUtils.ParseInt32(null), "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32(""), "Check #2 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32(null, 3), "Check #3 failed");
            Assert.AreEqual(4, StringUtils.ParseInt32("", 4), "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt32("1"), "Check #5 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32("2"), "Check #6 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32(" 1 "), "Check #7 failed");

            Assert.AreEqual(0, default(string).ToInt32(), "Check #8 failed");
            Assert.AreEqual(0, "".ToInt32(), "Check #9 failed");

            Assert.AreEqual(3, default(string).ToInt32(3), "Check #10 failed");
            Assert.AreEqual(4, "".ToInt32(4), "Check #11 failed");

            Assert.AreEqual(1, "1".ToInt32(), "Check #12 failed");
            Assert.AreEqual(2, "2".ToInt32(), "Check #13 failed");
            Assert.AreEqual(1, " 1 ".ToInt32(), "Check #14 failed");

            Assert.AreEqual(int.MaxValue, StringUtils.ParseInt32("2147483647"), "Check #15 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32("2147483648"), "Check #16 failed");

        }

        [TestMethod]
        public void ParseInt32Array() {

            Assert.AreEqual(0, StringUtils.ParseInt32Array(null).Length, "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32Array("").Length, "Check #2 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32Array("a").Length, "Check #3 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32Array("_").Length, "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt32Array("42").Length, "Check #5 failed");
            Assert.AreEqual(42, StringUtils.ParseInt32Array("42")[0], "Check #6 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32Array("1,2,3").Length, "Check #7 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32Array("1,2,3")[0], "Check #8 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32Array("1,2,3")[1], "Check #9 failed");
            Assert.AreEqual(3, StringUtils.ParseInt32Array("1,2,3")[2], "Check #10 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32Array("1 2 3").Length, "Check #11 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32Array("1 2 3")[0], "Check #12 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32Array("1 2 3")[1], "Check #13 failed");
            Assert.AreEqual(3, StringUtils.ParseInt32Array("1 2 3")[2], "Check #14 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32Array("1_2_3", '_').Length, "Check #15 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32Array("1_2_3", '_')[0], "Check #16 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32Array("1_2_3", '_')[1], "Check #17 failed");
            Assert.AreEqual(3, StringUtils.ParseInt32Array("1_2_3", '_')[2], "Check #18 failed");

        }

        [TestMethod]
        public void ParseInt64() {

            Assert.AreEqual(0, StringUtils.ParseInt64(null), "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64(""), "Check #2 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64(null, 3), "Check #3 failed");
            Assert.AreEqual(4, StringUtils.ParseInt64("", 4), "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt64("1"), "Check #5 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64("2"), "Check #6 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64(" 1 "), "Check #7 failed");

            Assert.AreEqual(0, default(string).ToInt64(), "Check #8 failed");
            Assert.AreEqual(0, "".ToInt64(), "Check #9 failed");

            Assert.AreEqual(3, default(string).ToInt64(3), "Check #10 failed");
            Assert.AreEqual(4, "".ToInt64(4), "Check #11 failed");

            Assert.AreEqual(1, "1".ToInt64(), "Check #12 failed");
            Assert.AreEqual(2, "2".ToInt64(), "Check #13 failed");
            Assert.AreEqual(1, " 1 ".ToInt64(), "Check #14 failed");

            Assert.AreEqual(long.MaxValue, StringUtils.ParseInt64("9223372036854775807"), "Check #15 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64("9223372036854775808"), "Check #16 failed");

        }

        [TestMethod]
        public void ParseInt64Array() {

            Assert.AreEqual(0, StringUtils.ParseInt64Array(null).Length, "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64Array("").Length, "Check #2 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64Array("a").Length, "Check #3 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64Array("_").Length, "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt64Array("42").Length, "Check #5 failed");
            Assert.AreEqual(42, StringUtils.ParseInt64Array("42")[0], "Check #6 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64Array("1,2,3").Length, "Check #7 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64Array("1,2,3")[0], "Check #8 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64Array("1,2,3")[1], "Check #9 failed");
            Assert.AreEqual(3, StringUtils.ParseInt64Array("1,2,3")[2], "Check #10 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64Array("1 2 3").Length, "Check #11 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64Array("1 2 3")[0], "Check #12 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64Array("1 2 3")[1], "Check #13 failed");
            Assert.AreEqual(3, StringUtils.ParseInt64Array("1 2 3")[2], "Check #14 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64Array("1_2_3", '_').Length, "Check #15 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64Array("1_2_3", '_')[0], "Check #16 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64Array("1_2_3", '_')[1], "Check #17 failed");
            Assert.AreEqual(3, StringUtils.ParseInt64Array("1_2_3", '_')[2], "Check #18 failed");

        }

        [TestMethod]
        public void ParseDouble() {

            Assert.AreEqual(0, StringUtils.ParseDouble(null), "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseDouble(""), "Check #2 failed");

            Assert.AreEqual(3.14, StringUtils.ParseDouble("3.14"), "Check #3 failed");

            // Danish decimal separator is treated as thousand separator due to invariant culture
            Assert.AreEqual(314, StringUtils.ParseDouble("3,14"), "Check #4 failed");
            Assert.AreEqual(3140, StringUtils.ParseDouble("3,140"), "Check #5 failed");

            Assert.AreEqual(3.14, "3.14".ToDouble());
            Assert.AreEqual(1, "nope".ToDouble(1));

        }

        [TestMethod]
        public void ParseDoubleDanish() {

            CultureInfo culture = CultureInfo.CurrentUICulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");

            ParseDouble();

            Thread.CurrentThread.CurrentCulture = culture;

        }

        [TestMethod]
        public void ParseDoubleArray() {

            double[] result = StringUtils.ParseDoubleArray("3.14 -1.234567");

            Assert.AreEqual(2, result.Length, "Check #1 failed");
            Assert.AreEqual(3.14, result[0], "Check #2 failed");
            Assert.AreEqual(-1.234567, result[1], "Check #2 failed");

        }

        [TestMethod]
        public void ParseDoubleArrayDanish() {

            CultureInfo culture = CultureInfo.CurrentUICulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");

            ParseDoubleArray();

            Thread.CurrentThread.CurrentCulture = culture;

        }

        [TestMethod]
        public void ParseGuidArray() {

            string input1 = "714a1347-99a3-419e-83ce-eec2d3211912 c07fe838-4584-4cef-a4cd-851ff890bf3f";
            string input2 = "{317C35F9-2D1B-4E81-9DF3-EFA04CAE01ED} (317C35F9-2D1B-4E81-9DF3-EFA04CAE01ED) hello 16F77374E26F4F8397590A58F34211C4";

            Guid[] guid1 = StringUtils.ParseGuidArray(input1);
            Guid[] guid2 = StringUtils.ParseGuidArray(input2);

            Assert.AreEqual(2, guid1.Length, "Check #1 failed");
            Assert.AreEqual("714a1347-99a3-419e-83ce-eec2d3211912", guid1[0].ToString(), "Check #2 failed");
            Assert.AreEqual("c07fe838-4584-4cef-a4cd-851ff890bf3f", guid1[1].ToString(), "Check #3 failed");

            Assert.AreEqual(3, guid2.Length, "Check #4 failed");
            Assert.AreEqual("317c35f9-2d1b-4e81-9df3-efa04cae01ed", guid2[0].ToString(), "Check #5 failed");
            Assert.AreEqual("317c35f9-2d1b-4e81-9df3-efa04cae01ed", guid2[1].ToString(), "Check #6 failed");
            Assert.AreEqual("16f77374-e26f-4f83-9759-0a58f34211c4", guid2[2].ToString(), "Check #7 failed"); 

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
                Assert.AreEqual(sample.Expected, sample.Input.ToUnderscore());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToUnderscore(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToUnderscore(sample.Input));
                Assert.AreEqual(sample.Expected, sample.Input.ToUnderscore());
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
                Assert.AreEqual(sample.Expected, sample.Input.ToCamelCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, sample.Input.ToCamelCase());
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
                Assert.AreEqual(sample.Expected, sample.Input.ToPascalCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, sample.Input.ToPascalCase());
            }

        }

        [TestMethod]
        public void ToLower() {

            var samples = new[] {
                new { Input = HttpStatusCode.Accepted, Expected = "accepted" },
                new { Input = HttpStatusCode.InternalServerError, Expected = "internalservererror" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.BadRequest, Expected = "badrequest" },
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, StringUtils.ToLower(sample.Input));
                Assert.AreEqual(sample.Expected, sample.Input.ToLower());
            }

        }
        
        [TestMethod]
        public void ToUpper() {

            var samples = new[] {
                new { Input = HttpStatusCode.Accepted, Expected = "ACCEPTED" },
                new { Input = HttpStatusCode.InternalServerError, Expected = "INTERNALSERVERERROR" },
                new { Input = HttpStatusCode.OK, Expected = "OK" },
                new { Input = HttpStatusCode.BadRequest, Expected = "BADREQUEST" },
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, StringUtils.ToUpper(sample.Input));
                Assert.AreEqual(sample.Expected, sample.Input.ToUpper());
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
                Assert.AreEqual(sample.Expected, sample.Input.FirstCharToUpper());
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

        [TestMethod]
        public void StripHtml() {

            var samples = new[] {
                new { Input = default(string), Output = "" },
                new { Input = "", Output = "" },
                new { Input = "<p>Hello World</p>", Output = "Hello World" },
                new { Input = "Hello<br />World", Output = "HelloWorld" },
                new { Input = "<p>Hello World &amp; Goodbye World</p>", Output = "Hello World & Goodbye World" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input));
            }

        }

        [TestMethod]
        public void StripHtmlIgnore() {

            var samples = new[] {
                new { Input = default(string), Output = "", Ignore = new []{"strong"} },
                new { Input = "", Output = "", Ignore = new []{"strong"} },
                new { Input = "<p>Hello <strong>World</strong></p>", Output = "Hello <strong>World</strong>", Ignore = new []{"strong"} },
                new { Input = "<ul><li><a href=\"#hest\"><strong>Hest</strong><br /></a></li></ul>", Output = "<a href=\"#hest\">Hest</a>", Ignore = new []{"a"} }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input, sample.Ignore));
            }

        }

        [TestMethod]
        public void IsInt32() {

            Assert.AreEqual(false, StringUtils.IsInt32(""), "#1");
            Assert.AreEqual(false, StringUtils.IsInt32("a"), "#2");
            Assert.AreEqual(true, StringUtils.IsInt32("42"), "#3");
            Assert.AreEqual(true, StringUtils.IsInt32("1234"), "#4");
            Assert.AreEqual(false, StringUtils.IsInt32("a1234"), "#5");
            Assert.AreEqual(false, StringUtils.IsInt32("a1234a"), "#6");
            Assert.AreEqual(false, StringUtils.IsInt32("1234a"), "#7");
            Assert.AreEqual(false, StringUtils.IsInt32("$1234"), "#8");
            Assert.AreEqual(false, StringUtils.IsInt32("1234kr"), "#9");

            Assert.AreEqual(true, StringUtils.IsInt32(int.MinValue + ""), "#10");
            Assert.AreEqual(true, StringUtils.IsInt32(int.MaxValue + ""), "#11");

            Assert.AreEqual(false, StringUtils.IsInt32(long.MinValue + ""), "#12");
            Assert.AreEqual(false, StringUtils.IsInt32(long.MaxValue + ""), "#13");

        }

        [TestMethod]
        public void IsInt64() {

            Assert.AreEqual(false, StringUtils.IsInt64(""), "#1");
            Assert.AreEqual(false, StringUtils.IsInt64("a"), "#2");
            Assert.AreEqual(true, StringUtils.IsInt64("42"), "#3");
            Assert.AreEqual(true, StringUtils.IsInt64("1234"), "#4");
            Assert.AreEqual(false, StringUtils.IsInt64("a1234"), "#5");
            Assert.AreEqual(false, StringUtils.IsInt64("a1234a"), "#6");
            Assert.AreEqual(false, StringUtils.IsInt64("1234a"), "#7");
            Assert.AreEqual(false, StringUtils.IsInt64("$1234"), "#8");
            Assert.AreEqual(false, StringUtils.IsInt64("1234kr"), "#9");

            Assert.AreEqual(true, StringUtils.IsInt64(int.MinValue + ""), "#10");
            Assert.AreEqual(true, StringUtils.IsInt64(int.MaxValue + ""), "#11");

            Assert.AreEqual(true, StringUtils.IsInt64(long.MinValue + ""), "#12");
            Assert.AreEqual(true, StringUtils.IsInt64(long.MaxValue + ""), "#13");

        }

        [TestMethod]
        public void IsFloat() {

            Assert.AreEqual(false, StringUtils.IsFloat(""), "#1");
            Assert.AreEqual(false, StringUtils.IsFloat("a"), "#2");
            Assert.AreEqual(true, StringUtils.IsFloat("42"), "#3");
            Assert.AreEqual(true, StringUtils.IsFloat("1234"), "#4");
            Assert.AreEqual(false, StringUtils.IsFloat("a1234"), "#5");
            Assert.AreEqual(false, StringUtils.IsFloat("a1234a"), "#6");
            Assert.AreEqual(false, StringUtils.IsFloat("1234a"), "#7");
            Assert.AreEqual(false, StringUtils.IsFloat("$1234"), "#8");
            Assert.AreEqual(false, StringUtils.IsFloat("1234kr"), "#9");

            Assert.AreEqual(true, StringUtils.IsFloat(int.MinValue + ""), "#10");
            Assert.AreEqual(true, StringUtils.IsFloat(int.MaxValue + ""), "#11");

            Assert.AreEqual(true, StringUtils.IsFloat(long.MinValue + ""), "#12");
            Assert.AreEqual(true, StringUtils.IsFloat(long.MaxValue + ""), "#13");

            Assert.AreEqual(true, StringUtils.IsFloat("-3.14159265358979"), "#14");
            Assert.AreEqual(true, StringUtils.IsFloat("+3.14159265358979"), "#15");

            Assert.AreEqual(true, "3.14".IsFloat(), "#16");
            Assert.AreEqual(false, "nope".IsFloat(), "#17");

            Assert.AreEqual("3.1400000", "3.14".IsFloat(out float value1) ? value1.ToString("F7") : "0", "#18");
            Assert.AreEqual(0, "nope".IsFloat(out float value2) ? value2 : 0, "#19");

        }

        [TestMethod]
        public void IsDouble() {

            Assert.AreEqual(false, StringUtils.IsDouble(""), "#1");
            Assert.AreEqual(false, StringUtils.IsDouble("a"), "#2");
            Assert.AreEqual(true, StringUtils.IsDouble("42"), "#3");
            Assert.AreEqual(true, StringUtils.IsDouble("1234"), "#4");
            Assert.AreEqual(false, StringUtils.IsDouble("a1234"), "#5");
            Assert.AreEqual(false, StringUtils.IsDouble("a1234a"), "#6");
            Assert.AreEqual(false, StringUtils.IsDouble("1234a"), "#7");
            Assert.AreEqual(false, StringUtils.IsDouble("$1234"), "#8");
            Assert.AreEqual(false, StringUtils.IsDouble("1234kr"), "#9");

            Assert.AreEqual(true, StringUtils.IsDouble(int.MinValue + ""), "#10");
            Assert.AreEqual(true, StringUtils.IsDouble(int.MaxValue + ""), "#11");

            Assert.AreEqual(true, StringUtils.IsDouble(long.MinValue + ""), "#12");
            Assert.AreEqual(true, StringUtils.IsDouble(long.MaxValue + ""), "#13");

            Assert.AreEqual(true, StringUtils.IsDouble("-3.14159265358979"), "#14");
            Assert.AreEqual(true, StringUtils.IsDouble("+3.14159265358979"), "#15");

            Assert.AreEqual(true, "3.14".IsDouble(), "#16");
            Assert.AreEqual(false, "nope".IsDouble(), "#17");

            Assert.AreEqual(3.14, "3.14".IsDouble(out double value1) ? value1 : 0, "#18");
            Assert.AreEqual(0, "nope".IsDouble(out double value2) ? value2 : 0, "#19");

        }

        [TestMethod]
        public void IsAlphanumeric() {

            Assert.AreEqual(false, StringUtils.IsAlphanumeric(""), "#1");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("dQw4w9WgXcQ"), "#2");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("aaa"), "#3");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("AAA"), "#4");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("123"), "#5");
            Assert.AreEqual(false, StringUtils.IsAlphanumeric("$123"), "#6");
            Assert.AreEqual(false, StringUtils.IsAlphanumeric("123.456"), "#7");

        }

        [TestMethod]
        public void IsAlphanumericExtensionMethod() {

            Assert.AreEqual(false, "".IsAlphanumeric(), "#1");
            Assert.AreEqual(true, "dQw4w9WgXcQ".IsAlphanumeric(), "#2");
            Assert.AreEqual(true, "aaa".IsAlphanumeric(), "#3");
            Assert.AreEqual(true, "AAA".IsAlphanumeric(), "#4");
            Assert.AreEqual(true, "123".IsAlphanumeric(), "#5");
            Assert.AreEqual(false, "$123".IsAlphanumeric(), "#6");
            Assert.AreEqual(false, "123.456".IsAlphanumeric(), "#7");

        }

        [TestMethod]
        public void IsAlphabetic() {

            Assert.AreEqual(false, StringUtils.IsAlphabetic(null), "#1");
            Assert.AreEqual(false, StringUtils.IsAlphabetic(""), "#2");
            Assert.AreEqual(false, StringUtils.IsAlphabetic("dQw4w9WgXcQ"), "#3");
            Assert.AreEqual(true, StringUtils.IsAlphabetic("dQwXwZWgXcQ"), "#4");
            Assert.AreEqual(true, StringUtils.IsAlphabetic("aaa"), "#5");
            Assert.AreEqual(true, StringUtils.IsAlphabetic("AAA"), "#6");
            Assert.AreEqual(false, StringUtils.IsAlphabetic("123"), "#7");
            Assert.AreEqual(false, StringUtils.IsAlphabetic("$123"), "#8");
            Assert.AreEqual(false, StringUtils.IsAlphabetic("123.456"), "#9");

            Assert.AreEqual(false, StringUtils.IsAlphabetic("æ"), "#10");
            Assert.AreEqual(false, StringUtils.IsAlphabetic("ø"), "#11");
            Assert.AreEqual(false, StringUtils.IsAlphabetic("å"), "#12");

        }

        [TestMethod]
        public void IsAlphabeticExtensionMethod() {

            Assert.AreEqual(false, default(string).IsAlphabetic(), "#1");
            Assert.AreEqual(false, "".IsAlphabetic(), "#2");
            Assert.AreEqual(false, "dQw4w9WgXcQ".IsAlphabetic(), "#3");
            Assert.AreEqual(true, "dQwXwZWgXcQ".IsAlphabetic(), "#4");
            Assert.AreEqual(true, "aaa".IsAlphabetic(), "#5");
            Assert.AreEqual(true, "AAA".IsAlphabetic(), "#6");
            Assert.AreEqual(false, "123".IsAlphabetic(), "#7");
            Assert.AreEqual(false, "$123".IsAlphabetic(), "#8");
            Assert.AreEqual(false, "123.456".IsAlphabetic(), "#9");

            Assert.AreEqual(false, "æ".IsAlphabetic(), "#10");
            Assert.AreEqual(false, "ø".IsAlphabetic(), "#11");
            Assert.AreEqual(false, "å".IsAlphabetic(), "#12");

        }

        [TestMethod]
        public void ToPlural() {

            foreach (SingularPluralTestItem item in SingularPluralTestItem.Items)
            {
                Assert.AreEqual(item.Plural, StringUtils.ToPlural(item.Singular), item.Singular + " => " + StringUtils.ToPlural(item.Singular));
            }

        }

        [TestMethod]
        public void ToSingular() {

            foreach (SingularPluralTestItem item in SingularPluralTestItem.Items) {
                Assert.AreEqual(item.Singular, StringUtils.ToSingular(item.Plural), item.Plural + " => " + StringUtils.ToSingular(item.Plural));
                if (item.PluralAlternatives != null) {
                    for (int i = 0; i < item.PluralAlternatives.Length; i++) {
                        Assert.AreEqual(item.Singular, StringUtils.ToSingular(item.PluralAlternatives[i]), item.Plural + " => " + StringUtils.ToSingular(item.PluralAlternatives[i]));
                    }
                }
            }

        }

        public class SingularPluralTestItem {

            public string Singular { get; private set; }

            public string Plural { get; private set; }

            public string[] PluralAlternatives { get; private set; }

            public static SingularPluralTestItem[] Items = {
                new SingularPluralTestItem { Singular = "ability", Plural = "abilities" },
                new SingularPluralTestItem { Singular = "address", Plural = "addresses" },
                new SingularPluralTestItem { Singular = "agency", Plural = "agencies" },
                new SingularPluralTestItem { Singular = "baby", Plural = "babies" },
                new SingularPluralTestItem { Singular = "bacterium", Plural = "bacteria" },
                new SingularPluralTestItem { Singular = "basis", Plural = "bases" },
                new SingularPluralTestItem { Singular = "bird", Plural = "birds" },
                new SingularPluralTestItem { Singular = "box", Plural = "boxes" },
                new SingularPluralTestItem { Singular = "bus", Plural = "buses" },
                new SingularPluralTestItem { Singular = "cat", Plural = "cats" },
                new SingularPluralTestItem { Singular = "chateau", Plural = "chateaux" },
                new SingularPluralTestItem { Singular = "child", Plural = "children" },
                new SingularPluralTestItem { Singular = "company", Plural = "companies" },
                new SingularPluralTestItem { Singular = "country", Plural = "countries" },
                new SingularPluralTestItem { Singular = "datum", Plural = "data" },
                new SingularPluralTestItem { Singular = "diagnosis", Plural = "diagnoses" },
                new SingularPluralTestItem { Singular = "dog", Plural = "dogs" },
                new SingularPluralTestItem { Singular = "fix", Plural = "fixes" },
                new SingularPluralTestItem { Singular = "fox", Plural = "foxes" },
                new SingularPluralTestItem { Singular = "genre", Plural = "genres" },
                new SingularPluralTestItem { Singular = "half", Plural = "halves" },
                new SingularPluralTestItem { Singular = "index", Plural = "indeces" },
                new SingularPluralTestItem { Singular = "location", Plural = "locations" },
                new SingularPluralTestItem { Singular = "man", Plural = "men" },
                new SingularPluralTestItem { Singular = "medium", Plural = "media" },
                new SingularPluralTestItem { Singular = "mouse", Plural = "mice" },
                new SingularPluralTestItem { Singular = "movie", Plural = "movies" },
                new SingularPluralTestItem { Singular = "person", Plural = "people" },
                new SingularPluralTestItem { Singular = "phenomenon", Plural = "phenomena" },
                new SingularPluralTestItem { Singular = "process", Plural = "processes" },
                new SingularPluralTestItem { Singular = "query", Plural = "queries" },
                new SingularPluralTestItem { Singular = "quiz", Plural = "quizzes" },
                new SingularPluralTestItem { Singular = "radius", Plural = "radii" },
                new SingularPluralTestItem { Singular = "safe", Plural = "saves" },
                new SingularPluralTestItem { Singular = "salesperson", Plural = "salespeople" },
                new SingularPluralTestItem { Singular = "search", Plural = "searches" },
                new SingularPluralTestItem { Singular = "seraph", Plural = "seraphim", PluralAlternatives = new []{ "seraphs"} },
                new SingularPluralTestItem { Singular = "serie", Plural = "series" },
                new SingularPluralTestItem { Singular = "show", Plural = "shows" },
                new SingularPluralTestItem { Singular = "spokesman", Plural = "spokesmen" },
                new SingularPluralTestItem { Singular = "spokeswoman", Plural = "spokeswomen" },
                new SingularPluralTestItem { Singular = "status", Plural = "statuses" },
                new SingularPluralTestItem { Singular = "trapezium", Plural = "trapezia", PluralAlternatives = new []{ "trapeziums"} },
                new SingularPluralTestItem { Singular = "trapezoid", Plural = "trapezoids" },
                new SingularPluralTestItem { Singular = "switch", Plural = "switches" },
                new SingularPluralTestItem { Singular = "wife", Plural = "wives" },
                new SingularPluralTestItem { Singular = "woman", Plural = "women" },
                new SingularPluralTestItem { Singular = "zebra", Plural = "zebras" }
            };

        }

    }

}

#pragma warning restore 618
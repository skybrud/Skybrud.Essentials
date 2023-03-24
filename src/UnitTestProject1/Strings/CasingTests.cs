using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

#pragma warning disable 618

namespace UnitTestProject1.Strings {

    [TestClass]
    public class CasingTests {

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
                new { Input = "Øv bøv", Expected = "øvBøv" },
                new { Input = "URLValueParser OMG Bacon    Hello \"#¤%&/&%()/=   ", Expected = "urlValueParserOmgBaconHello" },
                new { Input = "AbC", Expected = "abC" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "notFound" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "notImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.CamelCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToCamelCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.CamelCase));
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
                new { Input = "Øv bøv", Expected = "ØvBøv" },
                new { Input = "URLValueParser OMG Bacon    Hello \"#¤%&/&%()/=   ", Expected = "UrlValueParserOmgBaconHello" },
                new { Input = "AbC", Expected = "AbC" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "NotFound" },
                new { Input = HttpStatusCode.OK, Expected = "Ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "NotImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.PascalCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToPascalCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.PascalCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToPascalCase());
            }

        }

        [TestMethod]
        public void ToKebabCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "hello-world" },
                new { Input = "HELLO_WORLD", Expected = "hello-world" },
                new { Input = "HelloWorld", Expected = "hello-world" },
                new { Input = "Hello World", Expected = "hello-world" },
                new { Input = "Hello (World)", Expected = "hello-world" },
                new { Input = "Hello / World", Expected = "hello-world" },
                new { Input = "Hello % World", Expected = "hello-world" },
                new { Input = "      Hello World", Expected = "hello-world" },
                new { Input = "Hello World      ", Expected = "hello-world" },
                new { Input = "Hello      World", Expected = "hello-world" },
                new { Input = "______Hello World", Expected = "hello-world" },
                new { Input = "Hello World______", Expected = "hello-world" },
                new { Input = "Hello______World", Expected = "hello-world" },
                new { Input = "Rød grød med fløde", Expected = "rød-grød-med-fløde" },
                new { Input = "Den grimme Ælling", Expected = "den-grimme-ælling" },
                new { Input = "øv bøv", Expected = "øv-bøv" },
                new { Input = "Øv bøv", Expected = "øv-bøv" },
                new { Input = "URLValueParser OMG Bacon    Hello \"#¤%&/&%()/=   ", Expected = "url-value-parser-omg-bacon-hello" },
                new { Input = "AbC", Expected = "ab-c" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "not-found" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "not-implemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringUtils.ToKebabCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.KebabCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToKebabCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringUtils.ToKebabCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.KebabCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToKebabCase());
            }

        }

        [TestMethod]
        public void ToHeaderCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "Hello-World" },
                new { Input = "HELLO_WORLD", Expected = "Hello-World" },
                new { Input = "HelloWorld", Expected = "Hello-World" },
                new { Input = "Hello World", Expected = "Hello-World" },
                new { Input = "Hello (World)", Expected = "Hello-World" },
                new { Input = "Hello / World", Expected = "Hello-World" },
                new { Input = "Hello % World", Expected = "Hello-World" },
                new { Input = "      Hello World", Expected = "Hello-World" },
                new { Input = "Hello World      ", Expected = "Hello-World" },
                new { Input = "Hello      World", Expected = "Hello-World" },
                new { Input = "______Hello World", Expected = "Hello-World" },
                new { Input = "Hello World______", Expected = "Hello-World" },
                new { Input = "Hello______World", Expected = "Hello-World" },
                new { Input = "Rød grød med fløde", Expected = "Rød-Grød-Med-Fløde" },
                new { Input = "Den grimme Ælling", Expected = "Den-Grimme-Ælling" },
                new { Input = "øv bøv", Expected = "Øv-Bøv" },
                new { Input = "Øv bøv", Expected = "Øv-Bøv" },
                new { Input = "URLValueParser OMG Bacon    Hello \"#¤%&/&%()/=   ", Expected = "Url-Value-Parser-Omg-Bacon-Hello" },
                new { Input = "AbC", Expected = "Ab-C" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "Not-Found" },
                new { Input = HttpStatusCode.OK, Expected = "Ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "Not-Implemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringUtils.ToHeaderCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.HeaderCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToHeaderCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringUtils.ToHeaderCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.HeaderCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToHeaderCase());
            }

        }

        [TestMethod]
        public void ToTrainCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "HELLO-WORLD" },
                new { Input = "HELLO_WORLD", Expected = "HELLO-WORLD" },
                new { Input = "HelloWorld", Expected = "HELLO-WORLD" },
                new { Input = "Hello World", Expected = "HELLO-WORLD" },
                new { Input = "Hello (World)", Expected = "HELLO-WORLD" },
                new { Input = "Hello / World", Expected = "HELLO-WORLD" },
                new { Input = "Hello % World", Expected = "HELLO-WORLD" },
                new { Input = "      Hello World", Expected = "HELLO-WORLD" },
                new { Input = "Hello World      ", Expected = "HELLO-WORLD" },
                new { Input = "Hello      World", Expected = "HELLO-WORLD" },
                new { Input = "______Hello World", Expected = "HELLO-WORLD" },
                new { Input = "Hello World______", Expected = "HELLO-WORLD" },
                new { Input = "Hello______World", Expected = "HELLO-WORLD" },
                new { Input = "Rød grød med fløde", Expected = "RØD-GRØD-MED-FLØDE" },
                new { Input = "Den grimme Ælling", Expected = "DEN-GRIMME-ÆLLING" },
                new { Input = "øv bøv", Expected = "ØV-BØV" },
                new { Input = "Øv bøv", Expected = "ØV-BØV" },
                new { Input = "URLValueParser OMG Bacon    Hello \"#¤%&/&%()/=   ", Expected = "URL-VALUE-PARSER-OMG-BACON-HELLO" },
                new { Input = "AbC", Expected = "AB-C" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "NOT-FOUND" },
                new { Input = HttpStatusCode.OK, Expected = "OK" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "NOT-IMPLEMENTED" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringUtils.ToTrainCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.TrainCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToTrainCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringUtils.ToTrainCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.TrainCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToTrainCase());
            }

        }

        [TestMethod]
        public void ToSnakeCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "hello_world" },
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
                new { Input = "Den grimme Ælling", Expected = "den_grimme_ælling" },
                new { Input = "øv bøv", Expected = "øv_bøv" },
                new { Input = "Øv bøv", Expected = "øv_bøv" },
                new { Input = "URLValueParser OMG Bacon    Hello \"#¤%&/&%()/=   ", Expected = "url_value_parser_omg_bacon_hello" },
                new { Input = "AbC", Expected = "ab_c" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "not_found" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "not_implemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringUtils.ToSnakeCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.SnakeCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToSnakeCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringUtils.ToSnakeCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.SnakeCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToSnakeCase());
            }

        }

        [TestMethod]
        public void ToConstantCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "HELLO_WORLD" },
                new { Input = "HELLO_WORLD", Expected = "HELLO_WORLD" },
                new { Input = "HelloWorld", Expected = "HELLO_WORLD" },
                new { Input = "Hello World", Expected = "HELLO_WORLD" },
                new { Input = "Hello (World)", Expected = "HELLO_WORLD" },
                new { Input = "Hello / World", Expected = "HELLO_WORLD" },
                new { Input = "Hello % World", Expected = "HELLO_WORLD" },
                new { Input = "      Hello World", Expected = "HELLO_WORLD" },
                new { Input = "Hello World      ", Expected = "HELLO_WORLD" },
                new { Input = "Hello      World", Expected = "HELLO_WORLD" },
                new { Input = "______Hello World", Expected = "HELLO_WORLD" },
                new { Input = "Hello World______", Expected = "HELLO_WORLD" },
                new { Input = "Hello______World", Expected = "HELLO_WORLD" },
                new { Input = "Rød grød med fløde", Expected = "RØD_GRØD_MED_FLØDE" },
                new { Input = "Den grimme Ælling", Expected = "DEN_GRIMME_ÆLLING" },
                new { Input = "øv bøv", Expected = "ØV_BØV" },
                new { Input = "Øv bøv", Expected = "ØV_BØV" },
                new { Input = "URLValueParser OMG Bacon    Hello \"#¤%&/&%()/=   ", Expected = "URL_VALUE_PARSER_OMG_BACON_HELLO" },
                new { Input = "AbC", Expected = "AB_C" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "NOT_FOUND" },
                new { Input = HttpStatusCode.OK, Expected = "OK" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "NOT_IMPLEMENTED" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringUtils.ToConstantCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.ConstantCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToConstantCase());
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringUtils.ToConstantCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCasing(sample.Input, TextCasing.ConstantCase));
                Assert.AreEqual(sample.Expected, sample.Input.ToConstantCase());
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

    }

}
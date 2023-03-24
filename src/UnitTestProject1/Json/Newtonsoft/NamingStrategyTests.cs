using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Skybrud.Essentials.Json.Newtonsoft.Serialization;
using Skybrud.Essentials.Strings;

namespace UnitTestProject1.Json.Newtonsoft {

    [TestClass]
    public class NamingStrategyTests {

        [TestMethod]
        public void TestCasings() {

            HelloValue value = new HelloValue("");

            var samples = new[] {
                new { Expected = "helloworld", Casing = TextCasing.LowerCase },
                new { Expected = "HELLOWORLD", Casing = TextCasing.UpperCase },
                new { Expected = "helloWorld", Casing = TextCasing.CamelCase },
                new { Expected = "HelloWorld", Casing = TextCasing.PascalCase },
                new { Expected = "hello-world", Casing = TextCasing.KebabCase },
                new { Expected = "Hello-World", Casing = TextCasing.HeaderCase },
                new { Expected = "HELLO-WORLD", Casing = TextCasing.TrainCase },
                new { Expected = "hello_world", Casing = TextCasing.SnakeCase },
                new { Expected = "HELLO_WORLD", Casing = TextCasing.ConstantCase }
            };

            foreach (var sample in samples) {

                string expected = "{\"" + sample.Expected + "\":\"\"}";

                JsonSerializerSettings settings = new JsonSerializerSettings {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new TextCasingNamingStrategy(sample.Casing) }
                };

                string result = JsonConvert.SerializeObject(value, settings);

                Assert.AreEqual(expected, result, sample.Casing.ToString());

            }

        }

        public class HelloValue {

            public string HelloWorld { get; }

            public HelloValue(string helloWorld) {
                HelloWorld = helloWorld;
            }

        }

    }

}
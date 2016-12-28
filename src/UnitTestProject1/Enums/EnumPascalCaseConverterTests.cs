using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Enums;

namespace UnitTestProject1.Enums {
    
    [TestClass]
    public class EnumPascalCaseConverterTests {
    
        [TestMethod]
        public void TestMethod1() {

            SampleClass sc1 = new SampleClass {
                StringValue = "Hello World",
                EnumValue = HttpStatusCode.NotFound
            };

            string json = JsonConvert.SerializeObject(sc1, Formatting.None);

            Assert.AreEqual("{\"string\":\"Hello World\",\"enum\":\"NotFound\"}", json);

            SampleClass sc2 = JsonConvert.DeserializeObject<SampleClass>(json);

            Assert.AreEqual(sc1.StringValue, sc2.StringValue);
            Assert.AreEqual(sc1.EnumValue, sc2.EnumValue);

        }

        public class SampleClass {

            [JsonProperty("string")]
            public string StringValue { get; set; }

            [JsonProperty("enum")]
            [JsonConverter(typeof(EnumPascalCaseConverter))]
            public HttpStatusCode EnumValue { get; set; }

        }
    
    }

}
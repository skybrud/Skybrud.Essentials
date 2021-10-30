using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Converters;
using Skybrud.Essentials.Json.Extensions;
using System.Collections.Specialized;

namespace UnitTestProject1.Json.Converters {
    
    [TestClass]
    public class NameValueCollectionTests {

        [TestMethod]
        public void Serialize1() {

            Sample1 sample = new Sample1();

            JObject obj = JObject.FromObject(sample);

            JObject query = obj.GetObject("query");

            Assert.IsNull(query);

        }

        [TestMethod]
        public void Serialize2() {

            Sample1 sample = new Sample1 {
                Query = new NameValueCollection {
                    {"hi", "hej"}
                }
            };

            JObject obj = JObject.FromObject(sample);

            JObject query = obj.GetObject("query");

            Assert.IsNotNull(query);
            Assert.AreEqual("hej", query.GetString("hi"));

        }

        [TestMethod]
        public void Deserialize1() {

            JObject obj = new JObject();

            Sample1 value = obj.ToObject<Sample1>();

            Assert.IsNull(value.Query);

        }

        [TestMethod]
        public void Deserialize2() {

            JObject obj = new JObject {
                {"query", new JObject()}
            };

            Sample1 value = obj.ToObject<Sample1>();

            Assert.IsNotNull(value.Query);
            Assert.IsNull(value.Query["hi"]);

        }

        [TestMethod]
        public void Deserialize3() {

            JObject obj = new JObject {
                {"query", new JObject {
                    {"hi", "hej"}
                }}
            };

            Sample1 value = obj.ToObject<Sample1>();

            Assert.IsNotNull(value.Query);
            Assert.AreEqual("hej", value.Query["hi"]);

        }

        public class Sample1 {
            
            [JsonProperty("query")]
            [JsonConverter(typeof(NameValueCollectionJsonConverter))]
            public NameValueCollection Query { get; set; }

        }

    }

}
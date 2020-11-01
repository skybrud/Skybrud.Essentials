using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Json.Converters.Enums;

namespace UnitTestProject1.Enums {
    
    [TestClass]
    public class EnumArrayJsonConverterTests {
    
        [TestMethod]
        public void ToObject() {

            JObject json = new JObject {
                {"null", null},
                {"string", "ascending,descending"},
                {"array", new JArray("ascending", "descending")},
                {"nope", "ascending,descending,nope"}
            };


            var sample = json.ToObject<SampleClass>();

            Assert.IsNull(sample.Null);

            Assert.IsNotNull(sample.String);
            Assert.AreEqual(2, sample.String.Length);
            Assert.AreEqual(SortOrder.Ascending, sample.String[0]);
            Assert.AreEqual(SortOrder.Descending, sample.String[1]);

            Assert.IsNotNull(sample.Array);
            Assert.AreEqual(2, sample.Array.Length);
            Assert.AreEqual(SortOrder.Ascending, sample.Array[0]);
            Assert.AreEqual(SortOrder.Descending, sample.Array[1]);

            Assert.IsNotNull(sample.Nope);
            Assert.AreEqual(2, sample.Nope.Length);
            Assert.AreEqual(SortOrder.Ascending, sample.Nope[0]);
            Assert.AreEqual(SortOrder.Descending, sample.Nope[1]);

        }

        public class SampleClass {

            [JsonProperty("null")]
            [JsonConverter(typeof(EnumArrayJsonConverter))]
            public SortOrder[] Null { get; set; }

            [JsonProperty("string")]
            [JsonConverter(typeof(EnumArrayJsonConverter))]
            public SortOrder[] String { get; set; }

            [JsonProperty("array")]
            [JsonConverter(typeof(EnumArrayJsonConverter))]
            public SortOrder[] Array { get; set; }

            [JsonProperty("nope")]
            [JsonConverter(typeof(EnumArrayJsonConverter))]
            public SortOrder[] Nope { get; set; }
        }
    
    }

}
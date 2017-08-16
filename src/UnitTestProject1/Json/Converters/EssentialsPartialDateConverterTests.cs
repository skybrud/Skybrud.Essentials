using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Json.Converters {

    [TestClass]
    public class EssentialsPartialDateConverterTests {

        [TestMethod]
        public void Serialize() {

            Sample pd1 = new Sample(2017);
            Sample pd2 = new Sample(2017, 8);
            Sample pd3 = new Sample(2017, 8, 17);

            Assert.AreEqual("{\"date\":\"2017-00-00\"}", JsonConvert.SerializeObject(pd1));
            Assert.AreEqual("{\"date\":\"2017-08-00\"}", JsonConvert.SerializeObject(pd2));
            Assert.AreEqual("{\"date\":\"2017-08-17\"}", JsonConvert.SerializeObject(pd3));

        }

        [TestMethod]
        public void Deserialize() {

            Sample pd1 = new Sample(2017);
            Sample pd2 = new Sample(2017, 8);
            Sample pd3 = new Sample(2017, 8, 17);

            Sample parsed1 = JsonConvert.DeserializeObject<Sample>("{\"date\":\"2017-00-00\"}");
            Assert.AreEqual(pd1.PartialDate.Year, parsed1.PartialDate.Year);
            Assert.AreEqual(pd1.PartialDate.Month, parsed1.PartialDate.Month);
            Assert.AreEqual(pd1.PartialDate.Day, parsed1.PartialDate.Day);

            Sample parsed2 = JsonConvert.DeserializeObject<Sample>("{\"date\":\"2017-08-00\"}");
            Assert.AreEqual(pd2.PartialDate.Year, parsed2.PartialDate.Year);
            Assert.AreEqual(pd2.PartialDate.Month, parsed2.PartialDate.Month);
            Assert.AreEqual(pd2.PartialDate.Day, parsed2.PartialDate.Day);

            Sample parsed3 = JsonConvert.DeserializeObject<Sample>("{\"date\":\"2017-08-17\"}");
            Assert.AreEqual(pd3.PartialDate.Year, parsed3.PartialDate.Year);
            Assert.AreEqual(pd3.PartialDate.Month, parsed3.PartialDate.Month);
            Assert.AreEqual(pd3.PartialDate.Day, parsed3.PartialDate.Day);

        }

        class Sample {

            [JsonProperty("date")]
            public EssentialsPartialDate PartialDate { get; private set; }

            public Sample() { }

            public Sample(int year) {
                PartialDate = new EssentialsPartialDate(year);
            }

            public Sample(int year, int month) {
                PartialDate = new EssentialsPartialDate(year, month);
            }

            public Sample(int year, int month, int day) {
                PartialDate = new EssentialsPartialDate(year, month, day);
            }

        }

    }

}
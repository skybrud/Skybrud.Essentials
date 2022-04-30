using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Locations;

namespace UnitTestProject1.Locations {

    [TestClass]
    public class LocationTests {

#pragma warning disable 618

        [TestMethod]
        public void GetDistance() {

            // Values used for comparison comes from lines plotted into Google Maps. Google uses a varying number
            // decimals depending on the distance, so we loose a bit precision when rounding. But the results of this
            // unit test still shows that the method works (eg. the test will fail if using the mean radius rather than
            // the equatorial radius).

            var samples = new[] {
                new { From = new EssentialsLocation(55.6946159, 10.0366974), To = new EssentialsLocation(55.6477614, 10.1589203), Expected = "9.28", Decimals = 2 },
                new { From = new EssentialsLocation(54.8671242, 7.7124023), To = new EssentialsLocation(56.8159142, 12.2113037), Expected = "355", Decimals = 0 },
                new { From = new EssentialsLocation(49.2104204, -6.1083984), To = new EssentialsLocation(59.578851, 22.9833984), Expected = "2184", Decimals = 0 },
                new { From = new EssentialsLocation(12.3829283, -71.3671875), To = new EssentialsLocation(71.2443555, 25.4882813), Expected = "8958", Decimals = 0 }
            };

            foreach (var sample in samples) {

                string format = "{0:0." + ("".PadLeft(sample.Decimals, '0')) + "}";

                Assert.AreEqual(sample.Expected, string.Format(CultureInfo.InvariantCulture, format, LocationHelper.GetDistance(sample.From, sample.To) / 1000), "#1");
                Assert.AreEqual(sample.Expected, string.Format(CultureInfo.InvariantCulture, format, LocationUtils.GetDistance(sample.From, sample.To) / 1000), "#2");

            }

        }

#pragma warning restore 618

    }

}
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Maps;
using Skybrud.Essentials.Maps.Geometry;

namespace UnitTestProject1.Maps {

    [TestClass]
    public class DistanceTests {

        [TestMethod]
        public void GetDistance() {

            var samples = new[] {
                new { From = new Point(55.6946159, 10.0366974), To = new Point(55.6477614, 10.1589203), Expected = "9.29", Decimals = 2 },
                new { From = new Point(54.8671242, 7.7124023), To = new Point(56.8159142, 12.2113037), Expected = "356", Decimals = 0 },
                new { From = new Point(49.2104204, -6.1083984), To = new Point(59.578851, 22.9833984), Expected = "2188", Decimals = 0 },
                new { From = new Point(12.3829283, -71.3671875), To = new Point(71.2443555, 25.4882813), Expected = "8952", Decimals = 0 }
            };

            foreach (var sample in samples) {

                string format = "{0:0." + ("".PadLeft(sample.Decimals, '0')) + "}";

                double result1 = PointUtils.GetDistance(sample.From, sample.To);
                double result2 = PointUtils.GetDistance(sample.From.Latitude, sample.From.Longitude, sample.To.Latitude, sample.To.Longitude);

                Assert.AreEqual(sample.Expected, string.Format(CultureInfo.InvariantCulture, format, result1 / 1000), "#1");
                Assert.AreEqual(sample.Expected, string.Format(CultureInfo.InvariantCulture, format, result2 / 1000), "#2");

            }

        }

    }

}
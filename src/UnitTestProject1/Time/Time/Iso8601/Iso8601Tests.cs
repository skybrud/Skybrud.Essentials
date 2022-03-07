using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time.Iso8601;
using System;

using static UnitTestProject1.TestConstants;

namespace UnitTestProject1.Time.Time.Iso8601 {
    
    [TestClass]
    public class Iso8601Tests {

        [TestMethod]
        public void TryParseFormat() {

            using (new CultureDisposable(DanishCulture)) {

                bool success1 = Iso8601Utils.TryParse("2022-03-07T16:50:23Z", out DateTimeOffset result1);
                string actual1 = result1.ToString(Iso8601Constants.DateTimeMilliseconds);

                bool success2 = Iso8601Utils.TryParse("2022-03-07T16:50:23.123Z", out DateTimeOffset result2);
                string actual2 = result2.ToString(Iso8601Constants.DateTimeMilliseconds);

                bool success3 = Iso8601Utils.TryParse("2022-03-07T17:50:23+01:00", out DateTimeOffset result3);
                string actual3 = result3.ToString(Iso8601Constants.DateTimeMilliseconds);

                bool success4 = Iso8601Utils.TryParse("2022-03-07T17:50:23.123+01:00", out DateTimeOffset result4);
                string actual4 = result4.ToString(Iso8601Constants.DateTimeMilliseconds);

                bool success5 = Iso8601Utils.TryParse("Monday, 07 March 2022 17:50:23", out DateTimeOffset _);

                Assert.IsTrue(success1, "#1 Successful");
                Assert.AreEqual("2022-03-07T16:50:23.000+00:00", actual1, "#1 AreEqual");

                Assert.IsTrue(success2, "#2 Successful");
                Assert.AreEqual("2022-03-07T16:50:23.123+00:00", actual2, "#2 AreEqual");

                Assert.IsTrue(success3, "#3 Successful");
                Assert.AreEqual("2022-03-07T17:50:23.000+01:00", actual3, "#3 AreEqual");

                Assert.IsTrue(success4, "#4 Successful");
                Assert.AreEqual("2022-03-07T17:50:23.123+01:00", actual4, "#4 AreEqual");

                Assert.IsFalse(success5, "#5 Successful");

            }

        }

    }

}
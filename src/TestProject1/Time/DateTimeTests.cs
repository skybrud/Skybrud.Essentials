using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Extensions;

namespace TestProject1.Time {

    [TestClass]
    public class DateTimeTests {

        [TestMethod]
        public void Min() {

            DateTime dt1 = new(2022, 5, 1, 0, 0, 0);
            DateTime dt2 = new(2023, 5, 1, 0, 0, 0);

            Assert.AreEqual(dt1, TimeUtils.Min(dt1, dt2));

        }

        [TestMethod]
        public void Max() {

            DateTime dt1 = new(2022, 5, 1, 0, 0, 0);
            DateTime dt2 = new(2023, 5, 1, 0, 0, 0);

            Assert.AreEqual(dt2, TimeUtils.Max(dt1, dt2));

        }

        [TestMethod]
        public void ToIso8601() {

            var samples = new[] {
                new { Expected = "2023-08-17T07:35:00.000Z", Input = new DateTime(2023, 8, 17, 07, 35, 0, DateTimeKind.Utc) }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Expected, sample.Input.ToIso8601());

            }

        }

    }

}
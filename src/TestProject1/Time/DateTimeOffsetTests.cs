using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Extensions;

namespace TestProject1.Time {

    [TestClass]
    public class DateTimeOffsetTests {

        [TestMethod]
        public void Min() {

            DateTimeOffset dt1 = new(2022, 5, 1, 0, 0, 0, TimeSpan.FromHours(2));
            DateTimeOffset dt2 = new(2023, 5, 1, 0, 0, 0, TimeSpan.FromHours(2));

            Assert.AreEqual(dt1, TimeUtils.Min(dt1, dt2));

        }

        [TestMethod]
        public void Max() {

            DateTimeOffset dt1 = new(2022, 5, 1, 0, 0, 0, TimeSpan.FromHours(2));
            DateTimeOffset dt2 = new(2023, 5, 1, 0, 0, 0, TimeSpan.FromHours(2));

            Assert.AreEqual(dt2, TimeUtils.Max(dt1, dt2));

        }

        [TestMethod]
        public void ToIso8601() {

            var samples = new[] {
                new {
                    Expected = "2023-08-17T06:35:00.000Z",
                    Input = new DateTimeOffset(2023, 8, 17, 6, 35, 0, TimeSpan.FromHours(0))
                },
                new {
                    Expected = "2023-08-17T08:35:00.000+02:00",
                    Input = new DateTimeOffset(2023, 8, 17, 8, 35, 0, TimeSpan.FromHours(2))
                }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Expected, sample.Input.ToIso8601());

            }

        }

    }

}
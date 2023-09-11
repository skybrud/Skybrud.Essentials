using Skybrud.Essentials.Time.Extensions;

namespace TestProject1.Time {

    [TestClass]
    public class TimeSpanTests {

        [TestMethod]
        public void ToIso8601() {

            var samples = new[] {
                new { Expected = "PT0S", Input = TimeSpan.Zero },
                new { Expected = "PT2S", Input = TimeSpan.FromSeconds(2) },
                new { Expected = "PT2M", Input = TimeSpan.FromMinutes(2) },
                new { Expected = "PT3H", Input = TimeSpan.FromHours(3) },
                new { Expected = "P1DT1H", Input = TimeSpan.FromHours(25) }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Expected, sample.Input.ToIso8601());

            }

        }

    }

}
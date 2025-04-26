using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time.UnixTime;

namespace UnitTestProject1.Time.Formats {

    [TestClass]
    public class UnixTimeTests {

        #region Unix time -> DateTime

        [TestMethod]
        public void GetDateTimeFromUnixTime_Int32() {

            var samples = new[] {
                new { Timestamp = 1483384930, Date = new DateTime(2017, 1, 2, 19, 22, 10, DateTimeKind.Utc) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp).DateTime, "\n\n" + sample.Timestamp + " (UnixTimeUtils)");
            }

        }

        [TestMethod]
        public void GetDateTimeFromUnixTime_Int64() {

            var samples = new[] {
                new { Timestamp = 1483384930L, Date = new DateTime(2017, 1, 2, 19, 22, 10, DateTimeKind.Utc) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp).DateTime, "\n\n" + sample.Timestamp + " (UnixTimeUtils)");
            }

        }

        [TestMethod]
        public void GetDateTimeFromUnixTime_Double() {

            var samples = new[] {
                new { Timestamp = 1483384930d, Date = new DateTime(2017, 1, 2, 19, 22, 10, DateTimeKind.Utc) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp).DateTime, "\n\n" + sample.Timestamp + " (UnixTimeUtils)");
            }

        }

        [TestMethod]
        public void GetDateTimeFromUnixTime_String() {

            var samples = new[] {
                new { Timestamp = "1483384930", Date = new DateTime(2017, 1, 2, 19, 22, 10, DateTimeKind.Utc) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp).DateTime, "\n\n" + sample.Timestamp + " (UnixTimeUtils)");
            }

        }

        #endregion

        #region Unix time -> DateTimeOffset

        [TestMethod]
        public void GetDateTimeOffsetFromUnixTime_Int32() {

            var samples = new[] {
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 19, 22, 10, TimeSpan.Zero) },
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 18, 22, 10, TimeSpan.FromHours(-1)) },
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 20, 22, 10, TimeSpan.FromHours(+1)) }
            };

            int n = 1;
            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp), $"\n\n#{n}. {sample.Timestamp} (UnixTimeUtils)");
                n++;
            }

        }

        [TestMethod]
        public void GetDateTimeOffsetFromUnixTime_Int64() {

            var samples = new[] {
                new { Timestamp = 1483384930L, Date = new DateTimeOffset(2017, 1, 2, 19, 22, 10, TimeSpan.Zero) },
                new { Timestamp = 1483384930L, Date = new DateTimeOffset(2017, 1, 2, 18, 22, 10, TimeSpan.FromHours(-1)) },
                new { Timestamp = 1483384930L, Date = new DateTimeOffset(2017, 1, 2, 20, 22, 10, TimeSpan.FromHours(+1)) }
            };

            int n = 1;
            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp), $"\n\n#{n}. {sample.Timestamp} (UnixTimeUtils)");
                n++;
            }

        }

        [TestMethod]
        public void GetDateTimeOffsetFromUnixTime_Double() {

            var samples = new[] {
                new { Timestamp = 1483384930d, Date = new DateTimeOffset(2017, 1, 2, 19, 22, 10, TimeSpan.Zero) },
                new { Timestamp = 1483384930d, Date = new DateTimeOffset(2017, 1, 2, 18, 22, 10, TimeSpan.FromHours(-1)) },
                new { Timestamp = 1483384930d, Date = new DateTimeOffset(2017, 1, 2, 20, 22, 10, TimeSpan.FromHours(+1)) }
            };

            int n = 1;
            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp), $"\n\n#{n}. {sample.Timestamp} (UnixTimeUtils)");
                n++;
            }

        }

        [TestMethod]
        public void GetDateTimeOffsetFromUnixTime_String() {

            var samples = new[] {
                new { Timestamp = "1483384930", Date = new DateTimeOffset(2017, 1, 2, 19, 22, 10, TimeSpan.Zero) },
                new { Timestamp = "1483384930", Date = new DateTimeOffset(2017, 1, 2, 18, 22, 10, TimeSpan.FromHours(-1)) },
                new { Timestamp = "1483384930", Date = new DateTimeOffset(2017, 1, 2, 20, 22, 10, TimeSpan.FromHours(+1)) }
            };

            int n = 1;
            foreach (var sample in samples) {
                Assert.AreEqual(sample.Date, UnixTimeUtils.FromSeconds(sample.Timestamp), $"\n\n#{n}. {sample.Timestamp} (UnixTimeUtils)");
                n++;
            }

        }

        #endregion

        #region DateTime -> Unix time

        [TestMethod]
        public void GetUnixTimeFromDateTime() {

            var samples = new[] {
                new { Timestamp = 1483384930, Date = new DateTime(2017, 1, 2, 19, 22, 10, DateTimeKind.Utc) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Timestamp, (long) UnixTimeUtils.ToSeconds(sample.Date), "\n\n" + sample.Date + " (UnixTimeUtils)");
            }

        }

        [TestMethod]
        public void GetUnixTimeFromDateTimeAsDouble() {

            var samples = new[] {
                new { Timestamp = 1483384930d, Date = new DateTime(2017, 1, 2, 19, 22, 10, DateTimeKind.Utc) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Timestamp, UnixTimeUtils.ToSeconds(sample.Date), "\n\n" + sample.Date + " (UnixTimeUtils)");
            }

        }

        #endregion

        #region DateTimeOffset -> Unix time

        [TestMethod]
        public void GetUnixTimeFromDateTimeOffset() {

            var samples = new[] {
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 19, 22, 10, TimeSpan.Zero) },
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 18, 22, 10, TimeSpan.FromHours(-1)) },
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 20, 22, 10, TimeSpan.FromHours(+1)) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Timestamp, UnixTimeUtils.ToSeconds(sample.Date), "\n\n" + sample.Date + " (UnixTimeUtils)");
            }

        }

        [TestMethod]
        public void GetUnixTimeFromDateTimeOffsetAsDouble() {

            var samples = new[] {
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 19, 22, 10, TimeSpan.Zero) },
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 18, 22, 10, TimeSpan.FromHours(-1)) },
                new { Timestamp = 1483384930, Date = new DateTimeOffset(2017, 1, 2, 20, 22, 10, TimeSpan.FromHours(+1)) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Timestamp, UnixTimeUtils.ToSeconds(sample.Date), "\n\n" + sample.Date + " (UnixTimeUtils)");
            }

        }

        #endregion

    }

}
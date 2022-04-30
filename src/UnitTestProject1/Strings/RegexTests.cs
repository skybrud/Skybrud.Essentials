using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable PossibleMultipleEnumeration

namespace UnitTestProject1.Strings {

    [TestClass]
    public class RegexTests {

        [TestMethod]
        public void IsMatch() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out Match match);

            Assert.IsTrue(success);
            Assert.IsTrue(match.Success);

            Assert.AreEqual("2022", match.Groups[1].Value);
            Assert.AreEqual("04", match.Groups[2].Value);
            Assert.AreEqual("30", match.Groups[3].Value);
            Assert.AreEqual(string.Empty, match.Groups[4].Value);
            Assert.AreEqual(string.Empty, match.Groups[5].Value);

        }

        [TestMethod]
        public void IsMatchNull() {

            bool success = RegexUtils.IsMatch(null, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out Match match);

            Assert.IsFalse(success);
            Assert.IsFalse(match.Success);

            Assert.AreEqual(string.Empty, match.Groups[1].Value);
            Assert.AreEqual(string.Empty, match.Groups[2].Value);
            Assert.AreEqual(string.Empty, match.Groups[3].Value);
            Assert.AreEqual(string.Empty, match.Groups[4].Value);
            Assert.AreEqual(string.Empty, match.Groups[5].Value);

        }

        [TestMethod]
        public void IsMatchEmpty() {

            bool success = RegexUtils.IsMatch(string.Empty, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out Match match);

            Assert.IsFalse(success);
            Assert.IsFalse(match.Success);

            Assert.AreEqual(string.Empty, match.Groups[1].Value);
            Assert.AreEqual(string.Empty, match.Groups[2].Value);
            Assert.AreEqual(string.Empty, match.Groups[3].Value);
            Assert.AreEqual(string.Empty, match.Groups[4].Value);
            Assert.AreEqual(string.Empty, match.Groups[5].Value);

        }

        [TestMethod]
        public void IsMatchStringOne() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out string year);

            Assert.IsTrue(success);

            Assert.AreEqual("2022", year);

        }

        [TestMethod]
        public void IsMatchStringTwo() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out string year, out string month);

            Assert.IsTrue(success);

            Assert.AreEqual("2022", year);
            Assert.AreEqual("04", month);

        }

        [TestMethod]
        public void IsMatchStringThree() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out string year, out string month, out string day);

            Assert.IsTrue(success);

            Assert.AreEqual("2022", year);
            Assert.AreEqual("04", month);
            Assert.AreEqual("30", day);

        }

        [TestMethod]
        public void IsMatchStringFour() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out string year, out string month, out string day, out string fourth);

            Assert.IsTrue(success);

            Assert.AreEqual("2022", year);
            Assert.AreEqual("04", month);
            Assert.AreEqual("30", day);
            Assert.AreEqual(string.Empty, fourth);

        }

        [TestMethod]
        public void IsMatchStringFive() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out string year, out string month, out string day, out string fourth, out string fifth);

            Assert.IsTrue(success);

            Assert.AreEqual("2022", year);
            Assert.AreEqual("04", month);
            Assert.AreEqual("30", day);
            Assert.AreEqual(string.Empty, fourth);
            Assert.AreEqual(string.Empty, fifth);

        }

        [TestMethod]
        public void IsMatchInt32One() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out int year);

            Assert.IsTrue(success);

            Assert.AreEqual(2022, year);

        }

        [TestMethod]
        public void IsMatchInt32Two() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out int year, out int month);

            Assert.IsTrue(success);

            Assert.AreEqual(2022, year);
            Assert.AreEqual(4, month);

        }

        [TestMethod]
        public void IsMatchInt32Three() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out int year, out int month, out int day);

            Assert.IsTrue(success);

            Assert.AreEqual(2022, year);
            Assert.AreEqual(4, month);
            Assert.AreEqual(30, day);

        }

        [TestMethod]
        public void IsMatchInt32Four() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out int year, out int month, out int day, out int fourth);

            Assert.IsTrue(success);

            Assert.AreEqual(2022, year);
            Assert.AreEqual(4, month);
            Assert.AreEqual(30, day);
            Assert.AreEqual(0, fourth);

        }

        [TestMethod]
        public void IsMatchInt32Five() {

            string input = "2022-04-30";

            bool success = RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out int year, out int month, out int day, out int fourth, out int fifth);

            Assert.IsTrue(success);

            Assert.AreEqual(2022, year);
            Assert.AreEqual(4, month);
            Assert.AreEqual(30, day);
            Assert.AreEqual(0, fourth);
            Assert.AreEqual(0, fifth);

        }

        [TestMethod]
        public void OmgBacon() {

            bool success = RegexUtils.IsMatch("http://omgbacon.dk/", "^([a-z]+)://([a-z0-9\\._-]+)/", out string scheme, out string host);

            Assert.IsTrue(success);

            Assert.AreEqual("http", scheme);
            Assert.AreEqual("omgbacon.dk", host);

        }

        [TestMethod]
        public void OmgBacon2() {

            bool success = RegexUtils.IsMatch("http://omgbacon.dk/", "^([a-z]+)://([a-z0-9\\._-]+)/", out UrlMatch match);

            Assert.IsTrue(success);

            Assert.AreEqual("http", match.Scheme);
            Assert.AreEqual("omgbacon.dk", match.Host);

        }

        [TestMethod]
        public void Date() {

            bool success = RegexUtils.IsMatch("2022-04-30", "^([0-9]{4})-([0-9]{2})-([0-9]{2})$", out DateMatch match);

            Assert.IsTrue(success);

            Assert.AreEqual(2022, match.Year);
            Assert.AreEqual(4, match.Month);
            Assert.AreEqual(30, match.Day);

        }

        [TestMethod]
        public void DateEnumerable() {

            bool success = RegexUtils.IsMatch("2022-04-30 1988-08-17", "([0-9]{4})-([0-9]{2})-([0-9]{2})", out IEnumerable<DateMatch> matches);

            Assert.IsTrue(success);

            Assert.AreEqual(2, matches.Count());

            var first = matches.First();
            var second = matches.Last();

            Assert.AreEqual(2022, first.Year);
            Assert.AreEqual(4, first.Month);
            Assert.AreEqual(30, first.Day);

            Assert.AreEqual(1988, second.Year);
            Assert.AreEqual(8, second.Month);
            Assert.AreEqual(17, second.Day);

        }

        [TestMethod]
        public void DateArrayEnumerable() {

            bool success = RegexUtils.IsMatch("2022-04-30 1988-08-17", "([0-9]{4})-([0-9]{2})-([0-9]{2})", out DateMatch[] matches);

            Assert.IsTrue(success);

            Assert.AreEqual(2, matches.Length);

            var first = matches[0];
            var second = matches[1];

            Assert.AreEqual(2022, first.Year);
            Assert.AreEqual(4, first.Month);
            Assert.AreEqual(30, first.Day);

            Assert.AreEqual(1988, second.Year);
            Assert.AreEqual(8, second.Month);
            Assert.AreEqual(17, second.Day);

        }

        public class UrlMatch {

            public string Scheme { get; }

            public string Host { get; }

            public UrlMatch(Match match) {
                Scheme = match.Groups[1].Value;
                Host = match.Groups[2].Value;
            }

        }

        public class DateMatch {

            public int Year { get; }

            public int Month { get; }

            public int Day { get; }

            public DateMatch(Match match) {
                Year = match.Groups[1].Value.ToInt32();
                Month = match.Groups[2].Value.ToInt32();
                Day = match.Groups[3].Value.ToInt32();
            }

        }

    }

}
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Time.Rfc822 {

    /// <summary>
    /// Static class for working with date and time according to the <strong>RFC 822</strong> specification.
    /// </summary>
    public static class Rfc822Utils {

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToString(DateTime timestamp) {
            return timestamp.ToString("ddd, dd MMM yyyy HH:mm:ss zzzz", CultureInfo.InvariantCulture).Remove(29, 1);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToString(DateTimeOffset timestamp) {
            return timestamp.ToString("ddd, dd MMM yyyy HH:mm:ss zzzz", CultureInfo.InvariantCulture).Remove(29, 1);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the
        /// <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
#pragma warning disable 618
        public static string ToString(EssentialsDateTime timestamp) {
#pragma warning restore 618
            return ToString(timestamp.DateTime);
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> formatted date to a corresponding instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted date.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset Parse(string rfc822) {

            if (string.IsNullOrWhiteSpace(rfc822)) throw new ArgumentNullException(nameof(rfc822));

            Match m1 = Regex.Match(rfc822, "^([a-zø]+), ([0-9]+) ([a-z]+) ([0-9]{4}) ([0-9]{2}):([0-9]{2}):([0-9]{2}) (([0-9-+:]+)|([a-z]+))$", RegexOptions.IgnoreCase);

            if (!m1.Success) return DateTimeOffset.ParseExact(rfc822, "ddd, dd MMM yyyy HH:mm:ss K", CultureInfo.InvariantCulture).ToLocalTime();

            // The RFC 822 specification describes a few predefined time zones, which we
            // need to convert to an offset instead, since "DateTimeOffset" can't parse the
            // time zone
            string timezone = string.IsNullOrWhiteSpace(m1.Groups[9].Value) ? NormalizeTimeZone(m1.Groups[10].Value) : m1.Groups[9].Value.Replace(":", "");

            // Generate a new input string based on our conversions
            string str = string.Format(
                "{0}, {1} {2} {3} {4}:{5}:{6} {7}",
                m1.Groups[1].Value,
                m1.Groups[2].Value.PadLeft(2, '0'),
                m1.Groups[3].Value,
                m1.Groups[4].Value,
                m1.Groups[5].Value,
                m1.Groups[6].Value,
                m1.Groups[7].Value,
                timezone
            );

            return DateTimeOffset.ParseExact(str, "ddd, dd MMM yyyy HH:mm:ss K", CultureInfo.InvariantCulture);

        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> formatted date to its <see cref="DateTime"/>
        /// equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted date.</param>
        /// <param name="result">When this method returns, contains the <see cref="DateTime"/> value
        /// equivalent to the date and time contained in <paramref name="rfc822"/>, if the conversion succeeded, or
        /// <see cref="DateTime.MinValue"/> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="rfc822"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string rfc822, out DateTime result) {

            if (TryParse(rfc822, out DateTimeOffset dto)) {
                result = dto.DateTime;
                return true;
            }

            result = default;
            return false;

        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> formatted date to its <see cref="DateTimeOffset"/>
        /// equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted date.</param>
        /// <param name="result">When this method returns, contains the <see cref="DateTimeOffset"/> value
        /// equivalent to the date and time contained in <paramref name="rfc822"/>, if the conversion succeeded, or
        /// <see cref="DateTimeOffset.MinValue"/> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="rfc822"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string rfc822, out DateTimeOffset result) {

            if (string.IsNullOrWhiteSpace(rfc822)) {
                result = default;
                return false;
            }

            Match m1 = Regex.Match(rfc822, "^([a-zø]+), ([0-9]+) ([a-z]+) ([0-9]{4}) ([0-9]{2}):([0-9]{2}):([0-9]{2}) (([0-9-+:]+)|([a-z]+))$", RegexOptions.IgnoreCase);

            if (!m1.Success) {
                return DateTimeOffset.TryParseExact(rfc822, "ddd, dd MMM yyyy HH:mm:ss K", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            }

            // The RFC 822 specification describes a few predefined time zones, which we
            // need to convert to an offset instead, since "DateTimeOffset" can't parse the
            // time zone
            string timezone = string.IsNullOrWhiteSpace(m1.Groups[9].Value) ? NormalizeTimeZone(m1.Groups[10].Value) : m1.Groups[9].Value.Replace(":", "");

            // Generate a new input string based on our conversions
            string str = string.Format(
                "{0}, {1} {2} {3} {4}:{5}:{6} {7}",
                m1.Groups[1].Value,
                m1.Groups[2].Value.PadLeft(2, '0'),
                m1.Groups[3].Value,
                m1.Groups[4].Value,
                m1.Groups[5].Value,
                m1.Groups[6].Value,
                m1.Groups[7].Value,
                timezone
            );

            return DateTimeOffset.TryParseExact(str, "ddd, dd MMM yyyy HH:mm:ss K", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

        }

        /// <summary>
        /// The RFC 822 specification describes a number of predefined time zones - eg. <c>EST</c>
        /// (Eastern Standard Time), <c>UT</c> (Universal Time) and <c>GMT</c>
        /// (Greenwich Mean Time) - which <see cref="DateTimeOffset"/> isn't able to parse on it's own,
        /// so we need to convert the time zone to an offset instead - eg <c>+01:00</c>.
        /// </summary>
        /// <param name="timeZone">The time zone value to be normalized.</param>
        /// <returns>The normalized time zone.</returns>
        /// <see>
        ///     <cref>https://www.w3.org/Protocols/rfc822/#z28</cref>
        /// </see>
        public static string NormalizeTimeZone(string timeZone) {
            switch (timeZone) {
                case "UT":
                case "UTC":
                case "Z":
                case "GMT":
                    return "+0000";
                case "A":
                    return "-0100";
                case "B":
                    return "-0200";
                case "C":
                    return "-0300";
                case "D":
                case "EDT":
                    return "-0400";
                case "E":
                case "EST":
                case "CDT":
                    return "-0500";
                case "F":
                case "CST":
                case "MDT":
                    return "-0600";
                case "G":
                case "MST":
                case "PDT":
                    return "-0700";
                case "H":
                case "PST":
                    return "-0800";
                case "I":
                    return "-0900";
                case "K":
                    return "-1000";
                case "L":
                    return "-1100";
                case "M":
                    return "-1200";
                case "N":
                    return "+0100";
                case "O":
                    return "+0200";
                case "P":
                    return "+0300";
                case "Q":
                    return "+0400";
                case "R":
                    return "+0500";
                case "S":
                    return "+0600";
                case "T":
                    return "+0700";
                case "U":
                    return "+0800";
                case "V":
                    return "+0900";
                case "W":
                    return "+1000";
                case "X":
                    return "+1100";
                case "Y":
                    return "+1200";
                default:
                    return "";
            }
        }

    }

}
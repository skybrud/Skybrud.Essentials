using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc822(DateTime timestamp) {
            return timestamp.ToString("ddd, dd MMM yyyy HH:mm:ss") + " " + timestamp.ToString("zzzz").Replace(":", "");
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc822(DateTimeOffset timestamp) {
            return timestamp.ToString("ddd, dd MMM yyyy HH:mm:ss") + " " + timestamp.ToString("zzzz").Replace(":", "");
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToRfc822(EssentialsDateTime timestamp) {
            if (timestamp == null) throw new ArgumentNullException("timestamp");
            return ToRfc822(timestamp.DateTime);
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> date to an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted string.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>
        public static DateTime Rfc822ToDateTime(string rfc822) {
            return Rfc822ToDateTimeOffset(rfc822).DateTime;
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc822"/> date to an instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="rfc822">The string with the RFC 822 formatted string.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset Rfc822ToDateTimeOffset(string rfc822) {

            if (String.IsNullOrWhiteSpace(rfc822)) throw new ArgumentNullException("rfc822");

            Match m1 = Regex.Match(rfc822, "^([a-zø]+), ([0-9]+) ([a-z]+) ([0-9]{4}) ([0-9]{2}):([0-9]{2}):([0-9]{2}) (([0-9-+:]+)|([a-z]+))$", RegexOptions.IgnoreCase);

            if (!m1.Success) return DateTimeOffset.ParseExact(rfc822, "ddd, dd MMM yyyy HH:mm:ss K", CultureInfo.InvariantCulture).ToLocalTime();

            // The RFC 822 specification describes a few predefined time zones, which we
            // need to convert to an offset instead, since "DateTimeOffset" can't parse the
            // time zone
            string timezone = String.IsNullOrWhiteSpace(m1.Groups[9].Value) ? NormalizeRfc822TimeZone(m1.Groups[10].Value) : m1.Groups[9].Value.Replace(":", "");

            // Generate a new input string based on our conversions
            string str = String.Format(
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
        /// The RFC 822 specification describes a number of predefined time zones - eg. <code>EST</code>
        /// (Eastern Standard Time), <code>UT</code> (Universal Time) and <code>GMT</code>
        /// (Greenwich Mean Time) - which <see cref="DateTimeOffset"/> isn't able to parse on it's own,
        /// so we need to convert the time zone to an offset instead - eg <code>+01:00</code>.
        /// </summary>
        /// <param name="timezone">The time zone value to be normalized.</param>
        /// <returns>Returns the normalized time zone.</returns>
        /// <see>
        ///     <cref>https://www.w3.org/Protocols/rfc822/#z28</cref>
        /// </see>
        public static string NormalizeRfc822TimeZone(string timezone) {
            switch (timezone) {
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
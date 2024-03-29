﻿using System;

// ReSharper disable InconsistentNaming

#pragma warning disable IDE1006 // Naming Styles (.NET 6.0 seems to have a different convention than all other target frameworks)

namespace Skybrud.Essentials.Time.UnixTime {

    /// <summary>
    /// Static utility class with various methods for working with Unix time.
    /// </summary>
    public static class UnixTimeUtils {

        #region Constants

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing the start of the Unix epoch.
        /// </summary>
        private static readonly DateTime DateTimeUnixTimeStartUtc = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets an instance of <see cref="DateTimeOffset"/> representing the start of the Unix epoch.
        /// </summary>
        private static readonly DateTimeOffset DateTimeOffsetUnixTimeStartUtc = new(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

        #endregion

        #region Properties

        /// <summary>
        /// Returns the amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        public static double CurrentSeconds => (DateTime.UtcNow - DateTimeUnixTimeStartUtc).TotalSeconds;

        /// <summary>
        /// Returns the amount of milliseconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        public static double CurrentMilliseconds => (DateTime.UtcNow - DateTimeUnixTimeStartUtc).TotalMilliseconds;

        #endregion

        #region Member methods

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(int seconds) {
            return DateTimeOffsetUnixTimeStartUtc.AddSeconds(seconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(long seconds) {
            return DateTimeOffsetUnixTimeStartUtc.AddSeconds(seconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(double seconds) {
            return DateTimeOffsetUnixTimeStartUtc.AddSeconds(seconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(string? seconds) {
            return seconds is null ? default : DateTimeOffsetUnixTimeStartUtc.AddSeconds(long.Parse(seconds));
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="milliseconds">The Unix timestamp specified in milliseconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromMilliseconds(long milliseconds) {
            return DateTimeOffsetUnixTimeStartUtc.AddMilliseconds(milliseconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="milliseconds">The Unix timestamp specified in milliseconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromMilliseconds(double milliseconds) {
            return DateTimeOffsetUnixTimeStartUtc.AddMilliseconds(milliseconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="milliseconds">The Unix timestamp specified in milliseconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromMilliseconds(string? milliseconds) {
            return milliseconds is null ? default : DateTimeOffsetUnixTimeStartUtc.AddMilliseconds(long.Parse(milliseconds));
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="timestamp"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The isntance of <see cref="DateTime"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="double"/> representing the Unix timestamp.</returns>
        public static double ToSeconds(DateTime timestamp) {
            return (timestamp.ToUniversalTime() - DateTimeUnixTimeStartUtc).TotalSeconds;
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="timestamp"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The isntance of <see cref="DateTimeOffset"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="double"/> representing the Unix timestamp.</returns>
        public static double ToSeconds(DateTimeOffset timestamp) {
            return (timestamp.ToUniversalTime() - DateTimeOffsetUnixTimeStartUtc).TotalSeconds;
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="timestamp"/>. The Unix timestamp is defined as the
        /// amount of milliseconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The isntance of <see cref="DateTime"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="double"/> representing the Unix timestamp.</returns>
        public static double ToMilliseconds(DateTime timestamp) {
            return (timestamp.ToUniversalTime() - DateTimeUnixTimeStartUtc).TotalMilliseconds;
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="timestamp"/>. The Unix timestamp is defined as the
        /// amount of milliseconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The isntance of <see cref="DateTimeOffset"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="double"/> representing the Unix timestamp.</returns>
        public static double ToMilliseconds(DateTimeOffset timestamp) {
            return (timestamp.ToUniversalTime() - DateTimeOffsetUnixTimeStartUtc).TotalMilliseconds;
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a <see cref="long"/> according to <paramref name="format"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>The timestamp as an instance of <see cref="long"/></returns>.
        public static long ToInt64(DateTime timestamp, UnixTimeFormat format) {
            return (long) ToDouble(timestamp, format);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a <see cref="long"/> according to <paramref name="format"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>The timestamp as an instance of <see cref="long"/></returns>.
        public static long ToInt64(DateTimeOffset timestamp, UnixTimeFormat format) {
            return (long) ToDouble(timestamp, format);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a <see cref="long"/> according to <paramref name="format"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>The timestamp as an instance of <see cref="long"/></returns>.
        public static long ToInt64(EssentialsTime timestamp, UnixTimeFormat format) {
            return (long) ToDouble(timestamp.DateTimeOffset, format);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a <see cref="double"/> according to <paramref name="format"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>The timestamp as an instance of <see cref="double"/></returns>.
        public static double ToDouble(DateTime timestamp, UnixTimeFormat format) {
            return format == UnixTimeFormat.Seconds ? ToSeconds(timestamp) : ToMilliseconds(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a <see cref="double"/> according to <paramref name="format"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>The timestamp as an instance of <see cref="double"/></returns>.
        public static double ToDouble(DateTimeOffset timestamp, UnixTimeFormat format) {
            return format == UnixTimeFormat.Seconds ? ToSeconds(timestamp) : ToMilliseconds(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a <see cref="double"/> according to <paramref name="format"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>The timestamp as an instance of <see cref="double"/></returns>.
        public static double ToDouble(EssentialsTime timestamp, UnixTimeFormat format) {
            return ToDouble(timestamp.DateTimeOffset, format);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format of <paramref name="timestamp"/> - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>An instance of <see cref="DateTime"/>.</returns>.
        public static DateTime ToDateTime(double timestamp, UnixTimeFormat format) {
            return (format == UnixTimeFormat.Seconds ? FromSeconds(timestamp) : FromMilliseconds(timestamp)).DateTime;
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to an instance of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <param name="format">The format of <paramref name="timestamp"/> - <see cref="UnixTimeFormat.Seconds"/> or <see cref="UnixTimeFormat.Milliseconds"/>.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>.
        public static DateTimeOffset ToDateTimeOffset(double timestamp, UnixTimeFormat format) {
            return format == UnixTimeFormat.Seconds ? FromSeconds(timestamp) : FromMilliseconds(timestamp);
        }

        #endregion

    }

}
using System;
using Skybrud.Essentials.Time.UnixTime;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        #region Common

        /// <summary>
        /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <returns>An instance of <see cref="int"/> representing the current Unix timestamp.</returns>
        [Obsolete("Use UnixTimeUtils.CurrentSeconds property instead.")]
        public static int GetCurrentUnixTimestamp() {
            return (int) UnixTimeUtils.CurrentSeconds;
        }

        /// <summary>
        /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <returns>An instance of <see cref="double"/> representing the current Unix timestamp.</returns>
        [Obsolete("Use UnixTimeUtils.CurrentSeconds property instead.")]
        public static double GetCurrentUnixTimestampAsDouble() {
            return UnixTimeUtils.CurrentSeconds;
        }

        #endregion

        #region Unix time -> DateTime

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(int) method instead.")]
        public static DateTime GetDateTimeFromUnixTime(int timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp).DateTime;
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(long) method instead.")]
        public static DateTime GetDateTimeFromUnixTime(long timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp).DateTime;
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(double) method instead.")]
        public static DateTime GetDateTimeFromUnixTime(double timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp).DateTime;
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(string) method instead.")]
        public static DateTime GetDateTimeFromUnixTime(string timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp).DateTime;
        }

        #endregion

        #region Unix time -> DateTimeOffset

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(int) method instead.")]
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(int timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(long) method instead.")]
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(long timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(double) method instead.")]
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(double timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        [Obsolete("Use UnixTimeUtils.FromSeconds(string) method instead.")]
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(string timestamp) {
            return UnixTimeUtils.FromSeconds(timestamp);
        }

        #endregion

        #region DateTime -> Unix time

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="date"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTime"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="int"/> representing the Unix timestamp.</returns>
        [Obsolete("Use UnixTimeUtils.ToSeconds(DateTime) method instead.")]
        public static int GetUnixTimeFromDateTime(DateTime date) {
            return (int) UnixTimeUtils.ToSeconds(date);
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="date"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTime"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="double"/> representing the Unix timestamp.</returns>
        [Obsolete("Use UnixTimeUtils.ToSeconds(DateTime) method instead.")]
        public static double GetUnixTimeFromDateTimeAsDouble(DateTime date) {
            return UnixTimeUtils.ToSeconds(date);
        }

        #endregion

        #region DateTimeOffset -> Unix time

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="date"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTimeOffset"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="System.Int32"/> representing the Unix timestamp.</returns>
        [Obsolete("Use UnixTimeUtils.ToSeconds(DateTimeOffset) method instead.")]
        public static int GetUnixTimeFromDateTimeOffset(DateTimeOffset date) {
            return (int) UnixTimeUtils.ToSeconds(date);
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="date"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTimeOffset"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="System.Double"/> representing the Unix timestamp.</returns>
        [Obsolete("Use UnixTimeUtils.ToSeconds(DateTimeOffset) method instead.")]
        public static double GetUnixTimeFromDateTimeOffsetAsDouble(DateTimeOffset date) {
            return UnixTimeUtils.ToSeconds(date);
        }

        #endregion

    }

}
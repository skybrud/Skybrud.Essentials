using System;

namespace Skybrud.Essentials.Time {

    public static partial class TimeHelper {

        #region Common

        /// <summary>
        /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <returns>An instance of <see cref="System.Int32"/> representing the current Unix timestamp.</returns>
        public static int GetCurrentUnixTimestamp() {
            return TimeUtils.GetCurrentUnixTimestamp();
        }

        /// <summary>
        /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <returns>An instance of <see cref="System.Double"/> representing the current Unix timestamp.</returns>
        public static double GetCurrentUnixTimestampAsDouble() {
            return TimeUtils.GetCurrentUnixTimestampAsDouble();
        }

        #endregion

        #region Unix time -> DateTime

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(int timestamp) {
            return TimeUtils.GetDateTimeFromUnixTime(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(long timestamp) {
            return TimeUtils.GetDateTimeFromUnixTime(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(double timestamp) {
            return TimeUtils.GetDateTimeFromUnixTime(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(string timestamp) {
            return TimeUtils.GetDateTimeFromUnixTime(timestamp);
        }

        #endregion

        #region Unix time -> DateTimeOffset

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(int timestamp) {
            return TimeUtils.GetDateTimeOffsetFromUnixTime(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(long timestamp) {
            return TimeUtils.GetDateTimeOffsetFromUnixTime(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(double timestamp) {
            return TimeUtils.GetDateTimeOffsetFromUnixTime(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset GetDateTimeOffsetFromUnixTime(string timestamp) {
            return TimeUtils.GetDateTimeOffsetFromUnixTime(timestamp);
        }

        #endregion

        #region DateTime -> Unix time

        /// <summary>
        /// Returns the Unix timestamp for the specified <c>date</c>. The Unix timestamp is defined as the amount
        /// of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTime"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="System.Int32"/> representing the Unix timestamp.</returns>
        public static int GetUnixTimeFromDateTime(DateTime date) {
            return TimeUtils.GetUnixTimeFromDateTime(date);
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <c>date</c>. The Unix timestamp is defined as the amount
        /// of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTime"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="System.Double"/> representing the Unix timestamp.</returns>
        public static double GetUnixTimeFromDateTimeAsDouble(DateTime date) {
            return TimeUtils.GetUnixTimeFromDateTimeAsDouble(date);
        }

        #endregion

        #region DateTimeOffset -> Unix time

        /// <summary>
        /// Returns the Unix timestamp for the specified <c>date</c>. The Unix timestamp is defined as the amount
        /// of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTimeOffset"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="System.Int32"/> representing the Unix timestamp.</returns>
        public static int GetUnixTimeFromDateTimeOffset(DateTimeOffset date) {
            return TimeUtils.GetUnixTimeFromDateTimeOffset(date);
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <c>date</c>. The Unix timestamp is defined as the amount
        /// of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="date">The isntance of <see cref="DateTimeOffset"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="System.Double"/> representing the Unix timestamp.</returns>
        public static double GetUnixTimeFromDateTimeOffsetAsDouble(DateTimeOffset date) {
            return TimeUtils.GetUnixTimeFromDateTimeOffsetAsDouble(date);
        }

        #endregion

    }

}
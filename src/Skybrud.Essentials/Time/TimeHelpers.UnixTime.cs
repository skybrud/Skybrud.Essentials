using System;

namespace Skybrud.Essentials.Time {

    public static partial class TimeHelpers {

        #region Unix time

        /// <summary>
        /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="System.Int32"/> representing the current Unix timestamp.</returns>
        public static int GetCurrentUnixTimestamp() {
            return (int) Math.Floor(GetCurrentUnixTimestampAsDouble());
        }

        /// <summary>
        /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="System.Double"/> representing the current Unix timestamp.</returns>
        public static double GetCurrentUnixTimestampAsDouble() {
            return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>Returns the timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(int timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>Returns the timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(long timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>Returns the timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(double timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTime"/> based on the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp specified in seconds.</param>
        /// <returns>Returns the timestamp as an instance of <see cref="DateTime"/>.</returns>
        public static DateTime GetDateTimeFromUnixTime(string timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Int64.Parse(timestamp));
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <code>date</code>. The Unix timestamp is defined as the amount
        /// of seconds since the start of the Unix epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="System.Int32"/> representing the Unix timestamp.</returns>
        public static int GetUnixTimeFromDateTime(DateTime date) {
            return (int) GetUnixTimeFromDateTimeAsDouble(date);
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <code>date</code>. The Unix timestamp is defined as the amount
        /// of seconds since the start of the Unix epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="System.Double"/> representing the Unix timestamp.</returns>
        public static double GetUnixTimeFromDateTimeAsDouble(DateTime date) {
            return (date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        #endregion

    }

}
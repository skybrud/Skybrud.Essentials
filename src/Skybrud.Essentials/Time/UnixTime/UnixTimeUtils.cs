using System;

namespace Skybrud.Essentials.Time.UnixTime {

    /// <summary>
    /// Static utility class with various methods for working with Unix time.
    /// </summary>
    public static class UnixTimeUtils {

        /// <summary>
        /// Returns the amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        public static double CurrentSeconds => (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

        /// <summary>
        /// Returns the amount of milliseconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        public static double CurrentMilliseconds => (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(int seconds) {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero).AddSeconds(seconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(long seconds) {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero).AddSeconds(seconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(double seconds) {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero).AddSeconds(seconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="DateTimeOffset"/> based on the amount of seconds since the start of the
        /// Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="seconds">The Unix timestamp specified in seconds.</param>
        /// <returns>The timestamp as an instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset FromSeconds(string seconds) {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero).AddSeconds(long.Parse(seconds));
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="timestamp"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The isntance of <see cref="DateTime"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="double"/> representing the Unix timestamp.</returns>
        public static double ToSeconds(DateTime timestamp) {
            return (timestamp.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        /// <summary>
        /// Returns the Unix timestamp for the specified <paramref name="timestamp"/>. The Unix timestamp is defined as the
        /// amount of seconds since the start of the Unix epoch - that is <c>1st of January, 1970 - 00:00:00 GMT</c>.
        /// </summary>
        /// <param name="timestamp">The isntance of <see cref="DateTimeOffset"/> the timestamp should be based on.</param>
        /// <returns>An instance of <see cref="double"/> representing the Unix timestamp.</returns>
        public static double ToSeconds(DateTimeOffset timestamp) {
            return (timestamp.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero)).TotalSeconds;
        }

    }

}
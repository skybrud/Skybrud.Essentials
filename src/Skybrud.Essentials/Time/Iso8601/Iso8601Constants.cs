using System;

namespace Skybrud.Essentials.Time.Iso8601 {

    /// <summary>
    /// Class with various constants related to the <strong>ISO 8601</strong> standard.
    /// </summary>
    public static class Iso8601Constants {

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        [Obsolete("Use 'Date' property instead.")]
        public const string DateFormat = Date;

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        public const string Date = "yyyy-MM-dd";

        /// <summary>
        /// ISO 8601 date and time format.
        /// </summary>
        [Obsolete("Use 'DateTimeSeconds' property instead.")]
        public const string DateTimeFormat = DateTimeSeconds;

        /// <summary>
        /// ISO 8601 date and time format.
        /// </summary>
        public const string DateTimeSeconds = "yyyy-MM-ddTHH:mm:ssK";

        /// <summary>
        /// ISO 8601 date and time format.
        ///
        /// A <c>Z</c> is appended to the end of the result, indicating that the timestamp is specified in
        /// <strong>Zulu time</strong> (aka <strong>UTC</strong>).
        /// </summary>
        public const string DateTimeSecondsZulu = "yyyy-MM-ddTHH:mm:ssZ";

        /// <summary>
        /// ISO 8601 date and time format, including milliseconds.
        /// </summary>
        public const string DateTimeMilliseconds = "yyyy-MM-ddTHH:mm:ss.fffK";

        /// <summary>
        /// ISO 8601 date and time format, including milliseconds.
        ///
        /// A <c>Z</c> is appended to the end of the result, indicating that the timestamp is specified in
        /// <strong>Zulu time</strong> (aka <strong>UTC</strong>).
        /// </summary>
        public const string DateTimeMillisecondsZulu = "yyyy-MM-ddTHH:mm:ss.fffZ";

        /// <summary>
        /// An array with known ISO 8601 date time formats used when attempt to parse ISO 8601 values.
        /// </summary>
        internal static readonly string[] DateTimeFormats = {
            DateTimeSecondsZulu,
            DateTimeSeconds,
            DateTimeMillisecondsZulu,
            DateTimeMilliseconds
        };

    }

}
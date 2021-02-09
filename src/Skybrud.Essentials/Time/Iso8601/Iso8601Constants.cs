namespace Skybrud.Essentials.Time.Iso8601 {

    /// <summary>
    /// Class with various constants related to the <strong>ISO 8601</strong> standard.
    /// </summary>
    public static class Iso8601Constants {

        /// <summary>
        /// ISO 8601 date and time format.
        /// </summary>
        public const string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// ISO 8601 date and time format.
        /// </summary>
        public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssK";

        internal static readonly string[] DateTimeFormats = {
            "yyyy-MM-ddTHH:mm:ssZ",
            "yyyy-MM-ddTHH:mm:ssK",
            "yyyy-MM-ddTHH:mm:ss.fffZ",
            "yyyy-MM-ddTHH:mm:ss.fffK"
        };

    }

}
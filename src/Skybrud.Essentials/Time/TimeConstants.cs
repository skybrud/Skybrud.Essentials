using System;
using Skybrud.Essentials.Time.Iso8601;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class with varius time related constants.
    /// </summary>
    public static class TimeConstants {

        /// <summary>
        /// Class with varius constants related to date and time.
        /// </summary>
        public static class DateAndTime {

            /// <summary>
            /// Returns the <strong>ISO 8601</strong> format for specifying both date and time.
            /// </summary>
            [Obsolete($"Use '{nameof(Iso8601Constants.DateTimeSeconds)}' instead.")]
            public const string Iso8601DateFormat = "yyyy-MM-ddTHH:mm:ssK";

        }

    }

}
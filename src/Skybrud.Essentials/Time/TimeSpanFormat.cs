using System;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Enum class describing a <see cref="TimeSpan"/> format.
    /// </summary>
    public enum TimeSpanFormat {

        /// <summary>
        /// Indicates that <see cref="TimeSpan"/> should be formatted as seconds.
        /// </summary>
        Seconds,

        /// <summary>
        /// Indicates that <see cref="TimeSpan"/> should be formatted as milliseconds.
        /// </summary>
        Milliseconds,

        /// <summary>
        /// Indicates that <see cref="TimeSpan"/> should be formatted as an ISO 8601 duration string.
        /// </summary>
        Iso8601

    }

}
using System;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Time.Iso8601;

namespace Skybrud.Essentials.Time.Extensions {

    /// <summary>
    /// Static class with various extension methods for the <see cref="TimeSpan"/> struct.
    /// </summary>
    public static class TimeSpanExtensions {

        /// <summary>
        /// Returns an ISO 8601 formatted string based on the specified <see cref="TimeSpan"/> <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The <see cref="TimeSpan"/> value.</param>
        /// <returns>An ISO 8601 formatted string.</returns>
        public static string ToIso8601(this TimeSpan value) {
            return Iso8601Utils.ToString(value);
        }

        /// <summary>
        /// Returns an ISO 8601 formatted string based on the specified <see cref="TimeSpan"/> <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The <see cref="TimeSpan"/> value.</param>
        /// <returns>An ISO 8601 formatted string, or <see langword="null"/> if <paramref name="value"/> is <see langword="null"/>.</returns>
        [return: NotNullIfNotNull("value")]
        public static string? ToIso8601(this TimeSpan? value) {
            return value is null ? null : Iso8601Utils.ToString(value.Value);
        }

    }

}
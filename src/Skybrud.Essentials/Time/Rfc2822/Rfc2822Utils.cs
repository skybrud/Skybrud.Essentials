using System;
using Skybrud.Essentials.Time.Rfc822;

namespace Skybrud.Essentials.Time.Rfc2822 {

    /// <summary>
    /// Static class for working with date and time according to the <strong>RFC 2822</strong> specification.
    /// </summary>
    public static class Rfc2822Utils {

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToString(DateTime timestamp) {
            return Rfc822Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
        public static string ToString(DateTimeOffset timestamp) {
            return Rfc822Utils.ToString(timestamp);
        }

        /// <summary>
        /// Converts the specified <paramref name="timestamp"/> to a string representation as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        /// <param name="timestamp">The timestamp to be converted.</param>
        /// <returns>The timestamp formatted as a RFC 822 date string.</returns>
#pragma warning disable 618
        public static string ToString(EssentialsDateTime timestamp) {
#pragma warning restore 618
            return Rfc822Utils.ToString(timestamp.DateTime);
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc2822"/> formatted date to a corresponding instance of <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="rfc2822">The string with the RFC 2822 formatted date.</param>
        /// <returns>An instance of <see cref="DateTimeOffset"/>.</returns>
        public static DateTimeOffset Parse(string rfc2822) {
            return Rfc822Utils.Parse(rfc2822);
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc2822"/> formatted date to its <see cref="DateTime"/>
        /// equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="rfc2822">The string with the RFC 2822 formatted date.</param>
        /// <param name="result">When this method returns, contains the <see cref="DateTime"/> value
        /// equivalent to the date and time contained in <paramref name="rfc2822"/>, if the conversion succeeded, or
        /// <see cref="DateTime.MinValue"/> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="rfc2822"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string rfc2822, out DateTime result) {
            return Rfc822Utils.TryParse(rfc2822, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="rfc2822"/> formatted date to its <see cref="DateTimeOffset"/>
        /// equivalent and returns a value that indicates whether the conversion
        /// succeeded.
        /// </summary>
        /// <param name="rfc2822">The string with the RFC 2822 formatted date.</param>
        /// <param name="result">When this method returns, contains the <see cref="DateTimeOffset"/> value
        /// equivalent to the date and time contained in <paramref name="rfc2822"/>, if the conversion succeeded, or
        /// <see cref="DateTimeOffset.MinValue"/> if the conversion failed.</param>
        /// <returns><c>true</c> if the <paramref name="rfc2822"/> parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string rfc2822, out DateTimeOffset result) {
            return Rfc822Utils.TryParse(rfc2822, out result);
        }

    }

}
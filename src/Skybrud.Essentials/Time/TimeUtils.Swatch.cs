using System;

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        /// <summary>
        /// Nested class for working with <strong>Swatch Internet Time</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
        /// </see>
        public static class Swatch {

            #region Properties

            /// <summary>
            /// Returns the current <strong>Swatch Internet Time</strong>.
            /// </summary>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
            /// </see>
            /// <returns>A <see cref="double"/> reprenting the current <strong>Swatch Internet Time</strong>.</returns>
            public static double Now => DateTime.UtcNow.AddHours(1).TimeOfDay.TotalMilliseconds / 86400d;

            #endregion

            #region Methods

            /// <summary>
            /// Returns the specified <paramref name="timestamp"/> as <strong>Swatch Internet Time</strong>.
            /// </summary>
            /// <param name="timestamp">An instance of <see cref="DateTime"/> representing the timestamp.</param>
            /// <returns>A <see cref="double"/> reprenting the <strong>Swatch Internet Time</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
            /// </see>
            public static double ToDouble(DateTime timestamp) {
                return timestamp.ToUniversalTime().AddHours(1).TimeOfDay.TotalMilliseconds / 86400d;
            }

            /// <summary>
            /// Returns the specified <paramref name="timestamp"/> as <strong>Swatch Internet Time</strong>.
            /// </summary>
            /// <param name="timestamp">An instance of <see cref="DateTimeOffset"/> representing the timestamp.</param>
            /// <returns>A <see cref="double"/> reprenting the <strong>Swatch Internet Time</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
            /// </see>
            public static double ToDouble(DateTimeOffset timestamp) {
                return timestamp.ToUniversalTime().AddHours(1).TimeOfDay.TotalMilliseconds / 86400d;
            }

            /// <summary>
            /// Returns the specified <paramref name="timestamp"/> as <strong>Swatch Internet Time</strong>.
            /// </summary>
            /// <param name="timestamp">An instance of <see cref="EssentialsTime"/> representing the timestamp.</param>
            /// <returns>A <see cref="double"/> reprenting the <strong>Swatch Internet Time</strong>.</returns>
            /// <see>
            ///     <cref>https://en.wikipedia.org/wiki/Swatch_Internet_Time</cref>
            /// </see>
            public static double ToDouble(EssentialsTime timestamp) {
                if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
                return ToDouble(timestamp.DateTimeOffset);
            }

            /// <summary>
            /// Parses the specified <strong>Swatch Internet Time</strong> <paramref name="beats"/> into a corresponding instance of <see cref="TimeSpan"/>.
            /// </summary>
            /// <param name="beats">The amount of beats, according to <strong>Swatch Internet Time</strong>.</param>
            /// <returns>An instance of <see cref="TimeSpan"/>.</returns>
            public static TimeSpan ToTimeSpan(int beats) {
                return TimeSpan.FromMilliseconds(beats * 86400d);
            }

            /// <summary>
            /// Parses the specified <strong>Swatch Internet Time</strong> <paramref name="beats"/> into a corresponding instance of <see cref="TimeSpan"/>.
            /// </summary>
            /// <param name="beats">The amount of beats, according to <strong>Swatch Internet Time</strong>.</param>
            /// <returns>An instance of <see cref="TimeSpan"/>.</returns>
            public static TimeSpan ToTimeSpan(double beats) {
                return TimeSpan.FromMilliseconds(beats * 86400d);
            }

            #endregion

        }

    }

}
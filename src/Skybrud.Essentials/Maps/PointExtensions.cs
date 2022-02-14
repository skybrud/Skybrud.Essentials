using Skybrud.Essentials.Maps.Geometry;
using System;

namespace Skybrud.Essentials.Maps {

    /// <summary>
    /// Class with various extension methods for and related to <see cref="IPoint"/>.
    /// </summary>
    public static class PointExtensions {

        /// <summary>
        /// Calculates the distance in metres between two GPS points.
        /// </summary>
        /// <param name="point">The first point.</param>
        /// <param name="otherPoint">The second point.</param>
        /// <returns>The distance in metres between the two points.</returns>
        /// <remarks>The distance is calculated using the <see cref="EarthConstants.EquatorialRadius"/> of Earth.</remarks>
        public static double GetDistance(this IPoint point, IPoint otherPoint) {
            return PointUtils.GetDistance(point, otherPoint);
        }

        /// <summary>
        /// Calculates the distance in metres between two GPS points on a spheroid.
        /// </summary>
        /// <param name="point">The first point.</param>
        /// <param name="otherPoint">The second point.</param>
        /// <param name="radius">The equatorial radius of the spheroid.</param>
        /// <returns>The distance in metres between the two points.</returns>
        public static double GetDistance(this IPoint point, IPoint otherPoint, double radius) {
            return PointUtils.GetDistance(point, otherPoint, radius);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="point"/> is equal to <strong>Null Island</strong>, that is
        /// where both <see cref="IPoint.Latitude"/> and <see cref="IPoint.Longitude"/> are <c>0</c>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns><c>true</c> if both <see cref="IPoint.Latitude"/> and <see cref="IPoint.Longitude"/> are equal to <c>0</c>; otherwise <c>false</c>.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Null_Island</cref>
        /// </see>
        public static bool IsNullIsland(this IPoint point) {
            return PointUtils.IsNullIsland(point);
        }

    }

}
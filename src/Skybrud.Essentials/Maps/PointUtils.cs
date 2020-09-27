using System;
using Skybrud.Essentials.Maps.Geometry;
using static Skybrud.Essentials.Maps.EarthConstants;

namespace Skybrud.Essentials.Maps {

    /// <summary>
    /// Static utility class with helper methods related to locations.
    /// </summary>
    public static class PointUtils {

        /// <summary>
        /// Calculates the distance in metres between two GPS points.
        /// </summary>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <returns>The distance in metres between the two points.</returns>
        /// <remarks>The distance is calculated using the <see cref="EquatorialRadius"/> of Earth.</remarks>
        public static double GetDistance(IPoint point1, IPoint point2) {
            if (point1 == null) throw new ArgumentNullException(nameof(point1));
            if (point2 == null) throw new ArgumentNullException(nameof(point2));
            return GetDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude, EquatorialRadius);
        }

        /// <summary>
        /// Calculates the distance in metres between two GPS points on a spheroid.
        /// </summary>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <param name="radius">The equatorial radius of the spheroid.</param>
        /// <returns>The distance in metres between the two points.</returns>
        public static double GetDistance(IPoint point1, IPoint point2, double radius) {
            if (point1 == null) throw new ArgumentNullException(nameof(point1));
            if (point2 == null) throw new ArgumentNullException(nameof(point2));
            return GetDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude, radius);
        }

        /// <summary>
        /// Calculates the distance in metres between two GPS points.
        /// </summary>
        /// <param name="lat1">The latitude of the first point.</param>
        /// <param name="lng1">The longitude of the first point.</param>
        /// <param name="lat2">The latitude of the second point.</param>
        /// <param name="lng2">The longitude of the second point.</param>
        /// <returns>The distance in metres between the two points.</returns>
        /// <remarks>The distance is calculated using the <see cref="EquatorialRadius"/> of Earth.</remarks>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2) {
            return GetDistance(lat1, lng1, lat2, lng2, EquatorialRadius);
        }

        /// <summary>
        /// Calculates the distance in metres between two GPS points on a spheroid.
        /// </summary>
        /// <param name="lat1">The latitude of the first point.</param>
        /// <param name="lng1">The longitude of the first point.</param>
        /// <param name="lat2">The latitude of the second point.</param>
        /// <param name="lng2">The longitude of the second point.</param>
        /// <param name="radius">The equatorial radius of the spheroid.</param>
        /// <returns>The distance in metres between the two points.</returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2, double radius) {

            // Result should match: https://developers.google.com/maps/documentation/javascript/reference/3/geometry#spherical.computeDistanceBetween

            double ee = Math.PI * lat1 / 180;
            double f = Math.PI * lng1 / 180;
            double g = Math.PI * lat2 / 180;
            double h = Math.PI * lng2 / 180;
            double i = Math.Cos(ee) * Math.Cos(g) * Math.Cos(f) * Math.Cos(h) + Math.Cos(ee) * Math.Sin(f) * Math.Cos(g) * Math.Sin(h) + Math.Sin(ee) * Math.Sin(g);
            double j = Math.Acos(i);

            // Multiply with the equatorial radius of Earth
            return radius * j;

        }

        /// <summary>
        /// Returns whether the specified point identified by the specified <paramref name="latitude"/> and
        /// <paramref name="longitude"/> is equal to <strong>Null Island</strong>, that is
        /// where both <see cref="IPoint.Latitude"/> and <see cref="IPoint.Longitude"/> are <c>0</c>.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <returns><c>true</c> if both <paramref name="latitude"/> and <paramref name="longitude"/> are equal to
        /// <c>0</c>; otherwise <c>false</c>.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Null_Island</cref>
        /// </see>
        public static bool IsNullIsland(double latitude, double longitude) {
            return Math.Abs(latitude) < double.Epsilon && Math.Abs(longitude) < double.Epsilon;
        }
        
        /// <summary>
        /// Returns whether the specified <paramref name="point"/> is equal to <strong>Null Island</strong>, that is
        /// where both <see cref="IPoint.Latitude"/> and <see cref="IPoint.Longitude"/> are <c>0</c>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns><c>true</c> if both <see cref="IPoint.Latitude"/> and <see cref="IPoint.Longitude"/> are equal to
        /// <c>0</c>; otherwise <c>false</c>.</returns>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Null_Island</cref>
        /// </see>
        public static bool IsNullIsland(IPoint point) {
            return point == null || Math.Abs(point.Latitude) < double.Epsilon && Math.Abs(point.Longitude) < double.Epsilon;
        }

    }

}
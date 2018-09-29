using System;
using Skybrud.Essentials.Maps.Shapes;
using static Skybrud.Essentials.Maps.EarthConstants;

namespace Skybrud.Essentials.Maps {

    /// <summary>
    /// Static utility class with helper methods related to locations.
    /// </summary>
    public class DistanceUtils {
        
        /// <summary>
        /// Calculates the distance in metres between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        /// <returns>The distance in metres between the two locations.</returns>
        public static double GetDistance(IPoint loc1, IPoint loc2) {
            if (loc1 == null) throw new ArgumentNullException(nameof(loc1));
            if (loc2 == null) throw new ArgumentNullException(nameof(loc2));
            return GetDistance(loc1.Latitude, loc1.Longitude, loc2.Latitude, loc2.Longitude, EquatorialRadius);
        }

        /// <summary>
        /// Calculates the distance in metres between two GPS points on a spheroid.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        /// <param name="radius">The equatorial radius of the spheroid.</param>
        /// <returns>The distance in metres between the two locations.</returns>
        public static double GetDistance(IPoint loc1, IPoint loc2, double radius) {
            if (loc1 == null) throw new ArgumentNullException(nameof(loc1));
            if (loc2 == null) throw new ArgumentNullException(nameof(loc2));
            return GetDistance(loc1.Latitude, loc1.Longitude, loc2.Latitude, loc2.Longitude, radius);
        }

        /// <summary>
        /// Calculates the distance in metres between two GPS locations.
        /// </summary>
        /// <param name="lat1">The latitude of the first location.</param>
        /// <param name="lng1">The longitude of the first location.</param>
        /// <param name="lat2">The latitude of the second location.</param>
        /// <param name="lng2">The longitude of the second location.</param>
        /// <returns>The distance in metres between the two locations.</returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2) {
            return GetDistance(lat1, lng2, lat2, lng2, EquatorialRadius);
        }

        /// <summary>
        /// Calculates the distance in metres between two GPS points on a spheroid.
        /// </summary>
        /// <param name="lat1">The latitude of the first location.</param>
        /// <param name="lng1">The longitude of the first location.</param>
        /// <param name="lat2">The latitude of the second location.</param>
        /// <param name="lng2">The longitude of the second location.</param>
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

    }

}
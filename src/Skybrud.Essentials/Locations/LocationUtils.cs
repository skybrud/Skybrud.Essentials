﻿using System;
using Skybrud.Essentials.Maps;
using Skybrud.Essentials.Maps.Geometry;

namespace Skybrud.Essentials.Locations {

    /// <summary>
    /// Static utility class with helper methods related to locations.
    /// </summary>
    [Obsolete("Use the DistanceUtils class instead.")]
    public static class LocationUtils {

        #region Constants

        /// <summary>
        /// Gets the equatorial radius of Earth (in meters).
        /// 
        /// Notice: When comparing with various online services, they seem to use 6378137 meters for the equatorial
        /// radius of Earth, while 6378136.6 meters for the equatorial radius is more precise.
        /// </summary>
        /// <see>
        ///     <cref>https://web.archive.org/web/20130826043456/http://asa.usno.navy.mil/SecK/2011/Astronomical_Constants_2011.txt</cref>
        /// </see>
        public const double EarthEquatorialRadiusMeters = EarthConstants.EquatorialRadius;

        #endregion

        #region Static methods

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        /// <returns>The distance in meters between the two locations.</returns>
        public static double GetDistance(IPoint loc1, IPoint loc2) {
            if (loc1 == null) throw new ArgumentNullException(nameof(loc1));
            if (loc2 == null) throw new ArgumentNullException(nameof(loc2));
            return DistanceUtils.GetDistance(loc1.Latitude, loc1.Longitude, loc2.Latitude, loc2.Longitude);
        }

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="lat1">The latitude of the first location.</param>
        /// <param name="lng1">The longitude of the first location.</param>
        /// <param name="lat2">The latitude of the second location.</param>
        /// <param name="lng2">The longitude of the second location.</param>
        /// <returns>The distance in meters between the two locations.</returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2) {
            return DistanceUtils.GetDistance(lat1, lng1, lat2, lng2);
        }

        #endregion

    }

}
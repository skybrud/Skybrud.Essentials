namespace Skybrud.Essentials.Locations.Extensions {
    
    public static class LocationExtensions {

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        public static double GetDistance(this ILocation loc1, ILocation loc2) {
            return LocationHelper.GetDistance(loc1, loc2);
        }

    }

}
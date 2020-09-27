using System;
using Skybrud.Essentials.Maps.Geometry;

namespace Skybrud.Essentials.Maps {
    
    /// <summary>
    /// Class with various extension methods for and related to <see cref="IPoint"/>.
    /// </summary>
    public static class PointExtensions {
        
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
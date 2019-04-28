namespace Skybrud.Essentials.Maps.Geometry {

    /// <summary>
    /// Class representing a point identified by latitude and longitude.
    /// </summary>
    public class Point : IPoint {

        /// <summary>
        /// Gets or sets the latitude of the location. The latitude specifies the north-south position (Y-axis) of a point on the Earth's surface.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the location. The longitude specifies the east-west position (X-axis) of a point on the Earth's surface.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Initializes a new point with default <see cref="Latitude"/> and <see cref="Longitude"/> (both <c>0</c>).
        /// </summary>
        public Point() { }
        
        /// <summary>
        /// Initializes a new point with the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public Point(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

    }

}
namespace Skybrud.Essentials.Maps.Shapes {

    /// <summary>
    /// Interface representing a point identified by latitude and longitude.
    /// </summary>
    public interface IPoint {

        /// <summary>
        /// Gets the latitude of the location. The latitude specifies the north-south position (Y-axis) of a point on the Earth's surface.
        /// </summary>
        double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the location. The longitude specifies the east-west position (X-axis) of a point on the Earth's surface.
        /// </summary>
        double Longitude { get; }

    }

}
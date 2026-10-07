namespace Skybrud.Essentials.Maps;

/// <summary>
/// Static class with constants about Earth.
/// </summary>
public static class EarthConstants {

    /// <summary>
    /// Gets the equatorial radius of the WGS84 reference ellipsoid (in metres).
    /// </summary>
    /// <remarks>
    /// This is the defining semi-major axis of the WGS84 ellipsoid and is used
    /// by GPS and most GIS software.
    /// </remarks>
    /// <see href="https://en.wikipedia.org/wiki/Earth_radius"/>
    public const double EquatorialRadius = 6378137;

    /// <summary>
    /// Gets the mean radius of Earth (in metres).
    ///
    /// This is the International Union of Geodesy and Geophysics (IUGG) mean
    /// Earth radius. It is commonly used when approximating Earth as a sphere,
    /// providing a better overall approximation than the equatorial or polar
    /// radius alone.
    /// </summary>
    /// <see href="https://en.wikipedia.org/wiki/Earth_radius"/>
    public const double MeanRadius = 6371008.8;

}
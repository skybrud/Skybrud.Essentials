namespace Skybrud.Essentials.Maps;

/// <summary>
/// Provides astronomical constants.
///
/// Unlike the geodetic constants in <see cref="EarthConstants"/>, the
/// constants in this class follow astronomical reference values published
/// by organizations such as the U.S. Naval Observatory (USNO) and the
/// International Earth Rotation and Reference Systems Service (IERS).
/// </summary>
public class AstronomicalConstants {

    /// <summary>
    /// Gets the equatorial radius of Earth (in metres).
    ///
    /// Notice: When comparing with various online services, they seem to use 6378137 metres for the equatorial
    /// radius of Earth, while 6378136.6 metres for the equatorial radius is more precise.
    /// </summary>
    /// <see href="https://web.archive.org/web/20130826043456/http://asa.usno.navy.mil/SecK/2011/Astronomical_Constants_2011.txt" />
    public const double EquatorialRadius = 6378136.6;

}
namespace Skybrud.Essentials.Maps {

    /// <summary>
    /// Static class with constants about Earth.
    /// </summary>
    public static class EarthConstants {

        /// <summary>
        /// Gets the equatorial radius of Earth (in metres).
        /// 
        /// Notice: When comparing with various online services, they seem to use 6378137 metres for the equatorial
        /// radius of Earth, while 6378136.6 metres for the equatorial radius is more precise.
        /// </summary>
        /// <see>
        ///     <cref>https://web.archive.org/web/20130826043456/http://asa.usno.navy.mil/SecK/2011/Astronomical_Constants_2011.txt</cref>
        /// </see>
        public const double EquatorialRadius = 6378136.6;

    }

}
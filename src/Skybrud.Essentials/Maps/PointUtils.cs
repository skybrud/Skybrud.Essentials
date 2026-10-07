using System;
using Skybrud.Essentials.Maps.Geometry;
using static Skybrud.Essentials.Maps.EarthConstants;
// ReSharper disable InconsistentNaming

namespace Skybrud.Essentials.Maps;

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

        // Start by trying to calculate the distance using Vincenty's formula, which is more accurate for long distances. If it fails to converge, fall back to the Haversine formula.
        if (TryGetVincentyDistance(lat1, lng1, lat2, lng2, radius, out double result)) return result;
        return GetHaversineDistance(lat1, lng1, lat2, lng2, radius);

    }

    /// <summary>
    /// Returns whether the specified point identified by the specified <paramref name="latitude"/> and
    /// <paramref name="longitude"/> is equal to <strong>Null Island</strong>, that is
    /// where both <see cref="IPoint.Latitude"/> and <see cref="IPoint.Longitude"/> are <c>0</c>.
    /// </summary>
    /// <param name="latitude">The latitude of the point.</param>
    /// <param name="longitude">The longitude of the point.</param>
    /// <returns><see langword="true"/> if both <paramref name="latitude"/> and <paramref name="longitude"/> are equal to
    /// <c>0</c>; otherwise <see langword="false"/>.</returns>
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
    /// <returns><see langword="true"/> if both <see cref="IPoint.Latitude"/> and <see cref="IPoint.Longitude"/> are equal to
    /// <c>0</c>; otherwise <see langword="false"/>.</returns>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/Null_Island</cref>
    /// </see>
    public static bool IsNullIsland(IPoint? point) {
        return point == null || Math.Abs(point.Latitude) < double.Epsilon && Math.Abs(point.Longitude) < double.Epsilon;
    }

    #region Spherical Law of Cosines

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the spherical law of cosines.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This method implements the spherical law of cosines. It produces the same great-circle distance as the
    /// Haversine formula but uses a different trigonometric formulation.
    /// </remarks>
    public static double GetSphericalLawOfCosinesDistance(IPoint point1, IPoint point2) {
        if (point1 == null) throw new ArgumentNullException(nameof(point1));
        if (point2 == null) throw new ArgumentNullException(nameof(point2));
        return GetSphericalLawOfCosinesDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude, EquatorialRadius);
    }

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the spherical law of cosines.
    ///
    /// The calculation assumes a spherical body with the specified radius.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <param name="radius">The radius of the spherical body, in metres.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This method implements the spherical law of cosines. It produces the same great-circle distance as the
    /// Haversine formula but uses a different trigonometric formulation.
    /// </remarks>
    public static double GetSphericalLawOfCosinesDistance(IPoint point1, IPoint point2, double radius) {
        if (point1 == null) throw new ArgumentNullException(nameof(point1));
        if (point2 == null) throw new ArgumentNullException(nameof(point2));
        return GetSphericalLawOfCosinesDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude, radius);
    }

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the spherical law of cosines.
    /// </summary>
    /// <param name="latitude1">The latitude of the first point, in degrees.</param>
    /// <param name="longitude1">The longitude of the first point, in degrees.</param>
    /// <param name="latitude2">The latitude of the second point, in degrees.</param>
    /// <param name="longitude2">The longitude of the second point, in degrees.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This method implements the spherical law of cosines. It produces the same great-circle distance as the
    /// Haversine formula but uses a different
    /// trigonometric formulation.
    /// </remarks>
    public static double GetSphericalLawOfCosinesDistance(double latitude1, double longitude1, double latitude2, double longitude2) {
        return GetSphericalLawOfCosinesDistance(latitude1, longitude1, latitude2, longitude2, EquatorialRadius);
    }

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the spherical law of cosines.
    ///
    /// The calculation assumes a spherical body with the specified radius.
    /// </summary>
    /// <param name="latitude1">The latitude of the first point, in degrees.</param>
    /// <param name="longitude1">The longitude of the first point, in degrees.</param>
    /// <param name="latitude2">The latitude of the second point, in degrees.</param>
    /// <param name="longitude2">The longitude of the second point, in degrees.</param>
    /// <param name="radius">The radius of the spherical body, in metres.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This method implements the spherical law of cosines. It produces the same great-circle distance as the
    /// Haversine formula but uses a different
    /// trigonometric formulation.
    /// </remarks>
    public static double GetSphericalLawOfCosinesDistance(double latitude1, double longitude1, double latitude2, double longitude2, double radius) {

        // Result should match: https://developers.google.com/maps/documentation/javascript/reference/3/geometry#spherical.computeDistanceBetween

        double ee = Math.PI * latitude1 / 180;
        double f = Math.PI * longitude1 / 180;
        double g = Math.PI * latitude2 / 180;
        double h = Math.PI * longitude2 / 180;
        double i = Math.Cos(ee) * Math.Cos(g) * Math.Cos(f) * Math.Cos(h) +
                   Math.Cos(ee) * Math.Sin(f) * Math.Cos(g) * Math.Sin(h) + Math.Sin(ee) * Math.Sin(g);
        double j = Math.Acos(i);

        // Multiply with the equatorial radius of Earth
        return radius * j;

    }

    #endregion

    #region Haversine Formula

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the Haversine formula.
    ///
    /// The calculation assumes a spherical Earth and uses <see cref="MeanRadius"/> as the Earth's radius.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This method provides a good approximation for most applications. For higher accuracy over long distances,
    /// consider using an ellipsoidal geodesic algorithm such as Vincenty's formulae or Karney's algorithm.
    /// </remarks>
    public static double GetHaversineDistance(IPoint point1, IPoint point2) {
        if (point1 == null) throw new ArgumentNullException(nameof(point1));
        if (point2 == null) throw new ArgumentNullException(nameof(point2));
        return GetHaversineDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude, MeanRadius);
    }

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the Haversine formula.
    ///
    /// The calculation assumes a spherical body with the specified radius.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <param name="radius">The radius of the spherical body, in metres.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This overload can be used to calculate distances on spherical models of Earth or on other planetary bodies by
    /// supplying the appropriate radius.
    /// </remarks>
    public static double GetHaversineDistance(IPoint point1, IPoint point2, double radius) {
        if (point1 == null) throw new ArgumentNullException(nameof(point1));
        if (point2 == null) throw new ArgumentNullException(nameof(point2));
        return GetHaversineDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude, radius);
    }

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the Haversine formula.
    ///
    /// The calculation assumes a spherical Earth and uses <see cref="MeanRadius"/> as the Earth's radius.
    /// </summary>
    /// <param name="latitude1">The latitude of the first point, in degrees.</param>
    /// <param name="longitude1">The longitude of the first point, in degrees.</param>
    /// <param name="latitude2">The latitude of the second point, in degrees.</param>
    /// <param name="longitude2">The longitude of the second point, in degrees.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This method provides a good approximation for most applications. For higher accuracy over long distances,
    /// consider using an ellipsoidal geodesic algorithm such as Vincenty's formulae or Karney's algorithm.
    /// </remarks>
    public static double
        GetHaversineDistance(double latitude1, double longitude1, double latitude2, double longitude2) {
        return GetHaversineDistance(latitude1, longitude1, latitude2, longitude2, MeanRadius);
    }

    /// <summary>
    /// Calculates the great-circle distance between two geographic coordinates using the Haversine formula.
    ///
    /// The calculation assumes a spherical body with the specified radius.
    /// </summary>
    /// <param name="latitude1">The latitude of the first point, in degrees.</param>
    /// <param name="longitude1">The longitude of the first point, in degrees.</param>
    /// <param name="latitude2">The latitude of the second point, in degrees.</param>
    /// <param name="longitude2">The longitude of the second point, in degrees.</param>
    /// <param name="radius">The radius of the spherical body, in metres.</param>
    /// <returns>The great-circle distance between the two points, in metres.</returns>
    /// <remarks>
    /// This overload can be used to calculate distances on spherical models of Earth or on other planetary bodies by
    /// supplying the appropriate radius.
    /// </remarks>
    public static double GetHaversineDistance(double latitude1, double longitude1, double latitude2, double longitude2, double radius) {

        double lat1 = DegreesToRadians(latitude1);
        double lat2 = DegreesToRadians(latitude2);
        double deltaLatitude = DegreesToRadians(latitude2 - latitude1);
        double deltaLongitude = DegreesToRadians(longitude2 - longitude1);

        double a =
            Math.Sin(deltaLatitude / 2) *
            Math.Sin(deltaLatitude / 2) +
            Math.Cos(lat1) *
            Math.Cos(lat2) *
            Math.Sin(deltaLongitude / 2) *
            Math.Sin(deltaLongitude / 2);

        double c = 2 * Math.Atan2(
            Math.Sqrt(a),
            Math.Sqrt(1 - a));

        return radius * c;

    }

    #endregion

    #region Vincenty's Inverse Formula

    /// <summary>
    /// Calculates the geodesic distance between two geographic coordinates using Vincenty's inverse formula.
    ///
    /// The calculation models Earth as the WGS84 reference ellipsoid and is generally more accurate than spherical
    /// methods such as the Haversine formula, especially over long distances.
    /// </summary>
    /// <param name="point1">The first geographic point.</param>
    /// <param name="point2">The second geographic point.</param>
    /// <returns>The geodesic distance between the two points, in metres.</returns>
    public static double GetVincentyDistance(IPoint point1, IPoint point2) {
        if (point1 == null) throw new ArgumentNullException(nameof(point1));
        if (point2 == null) throw new ArgumentNullException(nameof(point2));
        return GetVincentyDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);
    }

    /// <summary>
    /// Calculates the geodesic distance between two geographic coordinates using Vincenty's inverse formula.
    ///
    /// The calculation models Earth as the WGS84 reference ellipsoid and is generally more accurate than spherical
    /// methods such as the Haversine formula, especially over long distances.
    /// </summary>
    /// <param name="latitude1">The latitude of the first point, in degrees.</param>
    /// <param name="longitude1">The longitude of the first point, in degrees.</param>
    /// <param name="latitude2">The latitude of the second point, in degrees.</param>
    /// <param name="longitude2">The longitude of the second point, in degrees.</param>
    /// <returns>The geodesic distance between the two points, in metres.</returns>
    /// <remarks>
    /// Vincenty's inverse formula computes the shortest distance between two
    /// points on the WGS84 reference ellipsoid. While highly accurate for most
    /// point pairs, the iterative algorithm may fail to converge for nearly
    /// antipodal points.
    /// </remarks>
    public static double GetVincentyDistance(double latitude1, double longitude1, double latitude2, double longitude2) {
        return TryGetVincentyDistance(latitude1, longitude1, latitude2, longitude2, out double result)
            ? result
            : throw new InvalidOperationException(
                "The Vincenty distance calculation did not converge. The coordinates may be nearly antipodal.");
    }

    /// <summary>
    /// Computes the geodesic distance between two geographic coordinates on the WGS84 ellipsoid using Vincenty’s
    /// inverse formula.
    /// </summary>
    /// <remarks>Returns zero for coincident coordinates. Longitude difference is normalized to the range
    /// [-180, 180]. Vincenty iteration may fail to converge for some nearly antipodal coordinate pairs.</remarks>
    /// <param name="latitude1">Latitude of the first coordinate, in decimal degrees.</param>
    /// <param name="longitude1">Longitude of the first coordinate, in decimal degrees.</param>
    /// <param name="latitude2">Latitude of the second coordinate, in decimal degrees.</param>
    /// <param name="longitude2">Longitude of the second coordinate, in decimal degrees.</param>
    /// <param name="result">Distance between the two coordinates, in meters, when the method returns <see langword="true"/>; otherwise
    /// <c>0</c>.</param>
    /// <returns><see langword="true"/> if the algorithm converges and a distance is produced; otherwise <see langword="false"/>.</returns>
    public static bool TryGetVincentyDistance(double latitude1, double longitude1, double latitude2, double longitude2, out double result) {
        return TryGetVincentyDistance(latitude1, longitude1, latitude2, longitude2, EquatorialRadius, out result);
    }

    /// <summary>
    /// Computes the geodesic distance between two geographic coordinates on the WGS84 ellipsoid using Vincenty’s
    /// inverse formula.
    /// </summary>
    /// <remarks>Returns zero for coincident coordinates. Longitude difference is normalized to the range
    /// [-180, 180]. Vincenty iteration may fail to converge for some nearly antipodal coordinate pairs.</remarks>
    /// <param name="latitude1">Latitude of the first coordinate, in decimal degrees.</param>
    /// <param name="longitude1">Longitude of the first coordinate, in decimal degrees.</param>
    /// <param name="latitude2">Latitude of the second coordinate, in decimal degrees.</param>
    /// <param name="longitude2">Longitude of the second coordinate, in decimal degrees.</param>
    /// <param name="radius">Equatorial radius of the ellipsoid, in meters.</param>
    /// <param name="result">Distance between the two coordinates, in meters, when the method returns <see langword="true"/>; otherwise
    /// <c>0</c>.</param>
    /// <returns><see langword="true"/> if the algorithm converges and a distance is produced; otherwise <see langword="false"/>.</returns>
    public static bool TryGetVincentyDistance(double latitude1, double longitude1, double latitude2, double longitude2, double radius, out double result) {

        const double Flattening = 1.0 / 298.257223563;

        double semiMajorAxis = radius;
        double semiMinorAxis = semiMajorAxis * (1.0 - Flattening);

        // If the two points are equal, the distance is 0
        if (Math.Abs(latitude1 - latitude2) < double.Epsilon && Math.Abs(longitude1 - longitude2) < double.Epsilon) {
            result = 0;
            return true;
        }

        double phi1 = DegreesToRadians(latitude1);
        double phi2 = DegreesToRadians(latitude2);

        // Normalize longitude difference into [-180, 180].
        double longitudeDifference = NormalizeLongitude(longitude2 - longitude1);

        double L = DegreesToRadians(longitudeDifference);

        double reducedLatitude1 = Math.Atan((1.0 - Flattening) * Math.Tan(phi1));
        double reducedLatitude2 = Math.Atan((1.0 - Flattening) * Math.Tan(phi2));

        double sinU1 = Math.Sin(reducedLatitude1);
        double cosU1 = Math.Cos(reducedLatitude1);
        double sinU2 = Math.Sin(reducedLatitude2);
        double cosU2 = Math.Cos(reducedLatitude2);

        double lambda = L;

        double sinSigma = 0.0;
        double cosSigma = 0.0;
        double sigma = 0.0;
        double cosSquaredAlpha = 0.0;
        double cosTwoSigmaM = 0.0;

        const int maximumIterations = 200;
        const double convergenceTolerance = 1e-12;

        bool converged = false;

        for (int iteration = 0; iteration < maximumIterations; iteration++) {

            double sinLambda = Math.Sin(lambda);
            double cosLambda = Math.Cos(lambda);

            double x = cosU2 * sinLambda;
            double y = cosU1 * sinU2 - sinU1 * cosU2 * cosLambda;

            sinSigma = Math.Sqrt(x * x + y * y);

            if (sinSigma == 0.0) {
                result = 0;
                return true;
            }

            cosSigma = sinU1 * sinU2 + cosU1 * cosU2 * cosLambda;

            sigma = Math.Atan2(sinSigma, cosSigma);

            double sinAlpha = cosU1 * cosU2 * sinLambda / sinSigma;

            cosSquaredAlpha = 1.0 - sinAlpha * sinAlpha;

            // cos(2σm) is undefined for equatorial geodesics,
            // where cos²α is zero. Its limiting value is zero.
            cosTwoSigmaM = cosSquaredAlpha > 1e-16 ? cosSigma - 2.0 * sinU1 * sinU2 / cosSquaredAlpha : 0.0;

            double C = Flattening / 16.0 * cosSquaredAlpha * (4.0 + Flattening * (4.0 - 3.0 * cosSquaredAlpha));

            double previousLambda = lambda;

            lambda = L + (1.0 - C) * Flattening * sinAlpha * (
                sigma +
                C * sinSigma * (
                    cosTwoSigmaM +
                    C * cosSigma * (-1.0 + 2.0 * cosTwoSigmaM * cosTwoSigmaM)
                )
            );

            if (Math.Abs(lambda - previousLambda) <=
                convergenceTolerance) {
                converged = true;
                break;
            }

        }

        if (!converged) {
            result = 0;
            return false;
        }

        double uSquared = cosSquaredAlpha * (semiMajorAxis * semiMajorAxis - semiMinorAxis * semiMinorAxis) / (semiMinorAxis * semiMinorAxis);

        double A = 1.0 + uSquared / 16384.0 * (
            4096.0 + uSquared * (
                -768.0 +
                uSquared * (
                    320.0 - 175.0 * uSquared
                )
            )
        );

        double B = uSquared / 1024.0 * (
            256.0 +
            uSquared * (
                -128.0 +
                uSquared * (74.0 - 47.0 * uSquared)
            )
        );

        double cosTwoSigmaMSquared = cosTwoSigmaM * cosTwoSigmaM;

        double sinSigmaSquared = sinSigma * sinSigma;

        double deltaSigma = B * sinSigma * (
            cosTwoSigmaM +
            B / 4.0 * (
                cosSigma * (
                    -1.0 +
                    2.0 * cosTwoSigmaMSquared
                ) - B / 6.0 * cosTwoSigmaM * (
                    -3.0 +
                    4.0 * sinSigmaSquared
                ) * (
                    -3.0 +
                    4.0 * cosTwoSigmaMSquared
                )
            )
        );

        result = semiMinorAxis * A * (sigma - deltaSigma);
        return true;

        static double NormalizeLongitude(double longitude) {
            longitude %= 360.0;
            return longitude switch {
                > 180.0 => longitude - 360.0,
                < -180.0 => longitude + 360.0,
                _ => longitude
            };
        }

    }

    #endregion

    private static double DegreesToRadians(double degrees) {
        return degrees * Math.PI / 180.0;
    }

}
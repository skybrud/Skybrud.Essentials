using System;
using Skybrud.Essentials.Maps.Geometry;

namespace Skybrud.Essentials.Locations {

    /// <summary>
    /// Interface representing a location based on a latitude and longitude.
    /// </summary>
    [Obsolete("Use the IPoint interface instead.")]
    public interface ILocation : IPoint { }

}
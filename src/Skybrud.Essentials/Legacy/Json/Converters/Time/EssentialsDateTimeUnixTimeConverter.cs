﻿using Skybrud.Essentials.Time;
using System;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// Converts an instance of <see cref="EssentialsDateTime"/> to and from a Unix timestamp.
    /// </summary>
    [Obsolete("Use UnixTimeConverter instead.")]
    public class EssentialsDateTimeUnixTimeConverter : UnixTimeConverter { }

}
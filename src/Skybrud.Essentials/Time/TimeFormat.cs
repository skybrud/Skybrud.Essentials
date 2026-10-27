using System;

namespace Skybrud.Essentials.Time;

/// <summary>
/// Enum class representing a time format.
/// </summary>
public enum TimeFormat {

    /// <summary>
    /// Indicates that the format is <strong>ISO 8601</strong>.
    /// </summary>
    /// <see>
    ///     <cref>https://en.wikipedia.org/wiki/ISO_8601</cref>
    /// </see>
    Iso8601,

    /// <summary>
    /// Indicates that the format is <strong>RFC 822</strong>.
    /// </summary>
    Rfc822,

    /// <summary>
    /// Indicates that the format is <strong>RFC 2822</strong>.
    /// </summary>
    Rfc2822,

    /// <summary>
    /// Indicates that the format is <strong>Unix time</strong> seconds.
    /// </summary>
    UnixTimeSeconds,

    /// <summary>
    /// Indicates that the format is <strong>Unix time</strong> milliseconds.
    /// </summary>
    UnixTimeMilliseconds,

    /// <summary>
    /// Use <see cref="UnixTimeSeconds"/> instead.
    /// </summary>
    [Obsolete("Use UnixTimeSeconds' instead.")]
    UnixTime = UnixTimeSeconds

}
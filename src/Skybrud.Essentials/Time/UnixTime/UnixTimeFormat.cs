namespace Skybrud.Essentials.Time.UnixTime;

/// <summary>
/// Enum class indicating whether a given timestamp  is or should be represented by <see cref="Seconds"/> or <see cref="Milliseconds"/>.
/// </summary>
public enum UnixTimeFormat {

    /// <summary>
    /// Indicates that a given timestamp is or should be represented by seconds.
    /// </summary>
    Seconds,

    /// <summary>
    /// Indicates that a given timestamp is or should be represented by milliseconds.
    /// </summary>
    Milliseconds

}
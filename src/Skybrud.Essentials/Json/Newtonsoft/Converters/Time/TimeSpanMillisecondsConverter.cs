using System;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters.Time;

/// <summary>
/// JSON converter for serializing and deserializing between instances of <see cref="TimeSpan"/> and the total
/// amount of milliseconds represented by the time span.
/// </summary>
public class TimeSpanMillisecondsConverter : TimeSpanConverter {

    /// <summary>
    /// Initialized a new instance.
    /// </summary>
    public TimeSpanMillisecondsConverter() : base(TimeSpanFormat.Milliseconds) { }

}
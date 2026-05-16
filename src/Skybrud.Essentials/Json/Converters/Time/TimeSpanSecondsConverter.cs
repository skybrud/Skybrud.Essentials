using System;
using Skybrud.Essentials.Json.Newtonsoft.Converters.Time;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// JSON converter for serializing and deserializing between instances of <see cref="TimeSpan"/> and the total
    /// amount of seconds represented by the time span.
    /// </summary>
    [Obsolete($"Use the '{nameof(TimeSpanConverter)}' class instead.")]
    public class TimeSpanSecondsConverter : TimeSpanConverter {

        /// <summary>
        /// Initialized a new instance.
        /// </summary>
        public TimeSpanSecondsConverter() : base(TimeSpanFormat.Seconds)  { }

    }

}
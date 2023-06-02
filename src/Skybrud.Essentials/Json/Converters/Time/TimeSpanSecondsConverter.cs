using System;
using Skybrud.Essentials.Json.Newtonsoft.Converters.Time;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// JSON converter for seriqalizing and deserializating between instances of <see cref="TimeSpan"/> and the total
    /// amount of seconds represented by the time span.
    /// </summary>
    public class TimeSpanSecondsConverter : TimeSpanConverter {

        /// <summary>
        /// Initialized a new instance.
        /// </summary>
        public TimeSpanSecondsConverter() : base(TimeSpanFormat.Seconds)  { }

    }

}
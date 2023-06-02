using System;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters {

    /// <summary>
    /// JSON converter for serializing and deserializing instances of <see cref="TimeSpan"/> according to <see cref="Time.TimeSpanConverter.Format"/>.
    /// </summary>
    [Obsolete("Use the 'Skybrud.Essentials.Json.Newtonsoft.Converters.Time.TimeSpanConverter' converter instead.")]
    public class TimeSpanConverter : Time.TimeSpanConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public TimeSpanConverter() { }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">The format to be used when serializing to JSON.</param>
        public TimeSpanConverter(TimeSpanFormat format) : base(format) { }


    }

}
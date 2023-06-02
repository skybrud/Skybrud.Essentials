using System;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// Converts a timestamp (eg. <see cref="DateTime"/> or <see cref="DateTimeOffset"/>) to <see cref="Newtonsoft.Converters.Time.TimeConverter.Format"/>.
    /// </summary>
    [Obsolete("Use the 'Skybrud.Essentials.Json.Newtonsoft.Converters.Time.TimeConverter' converter instead.")]
    public class TimeConverter : Newtonsoft.Converters.Time.TimeConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public TimeConverter() { }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">The format to be used when serializing to JSON.</param>
        public TimeConverter(TimeFormat format) : base(format) { }

    }

}
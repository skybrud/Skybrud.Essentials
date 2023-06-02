using System;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.UnixTime;

namespace Skybrud.Essentials.Json.Converters.Time {

    /// <summary>
    /// Converts an instance of either <see cref="EssentialsDateTime"/> or <see cref="DateTime"/> to and from a Unix timestamp.
    /// </summary>
    [Obsolete("Use the 'Skybrud.Essentials.Json.Newtonsoft.Converters.Time.UnixTimeConverter' converter instead.")]
    public class UnixTimeConverter : Newtonsoft.Converters.Time.UnixTimeConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public UnixTimeConverter() { }

        /// <summary>
        /// Initializes a new converter for the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">The format to be used when serializing to JSON.</param>
        public UnixTimeConverter(UnixTimeFormat format) : base(format) { }

    }

}
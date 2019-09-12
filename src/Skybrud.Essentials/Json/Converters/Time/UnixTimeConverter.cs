using System;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Json.Converters.Time {
    
    /// <summary>
    /// Converts an instance of either <see cref="EssentialsDateTime"/> or <see cref="DateTime"/> to and from a Unix timestamp.
    /// </summary>
    public class UnixTimeConverter : TimeConverter {

        /// <summary>
        /// Initializes a new converter with default options.
        /// </summary>
        public UnixTimeConverter() : base(TimeFormat.UnixTime) { }

    }

}
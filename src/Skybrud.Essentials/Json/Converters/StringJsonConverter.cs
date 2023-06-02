using System;

namespace Skybrud.Essentials.Json.Converters {

    /// <summary>
    /// JSON converter for serializing objects into their <see cref="object.ToString"/> equivalent.
    /// </summary>
    [Obsolete("Use the 'Skybrud.Essentials.Json.Newtonsoft.Converters.StringJsonConverter' converter instead.")]
    public class StringJsonConverter : Newtonsoft.Converters.StringJsonConverter { }

}
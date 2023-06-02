#if NET_FRAMEWORK

using System;
using System.Collections.Specialized;

namespace Skybrud.Essentials.Json.Converters {

    /// <summary>
    /// JSON converter class for serializing and deserializing <see cref="NameValueCollection"/> instances.
    ///
    /// The serializes value will be a JSON object. If you wish to serialize to an URL encoded string instead, see the <see cref="StringJsonConverter"/>.
    /// </summary>
    [Obsolete("use the 'Skybrud.Essentials.Json.Newtonsoft.Converters.NameValueCollectionJsonConverter' converter instead.")]
    public class NameValueCollectionJsonConverter : Newtonsoft.Converters.NameValueCollectionJsonConverter { }

}

#endif
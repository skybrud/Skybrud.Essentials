using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft;

/// <summary>
/// Class representing an object that was parsed from an instance of <see cref="global::Newtonsoft.Json.Linq.JObject"/>.
///
/// The <see cref="global::Newtonsoft.Json.Linq.JObject"/> may be <see langword="null"/> (aka optional). Use <see cref="JsonObjectBase"/> if the <see cref="global::Newtonsoft.Json.Linq.JObject"/> instance should not be <see langword="null"/> (aka required).
/// </summary>
public class JsonNullableObjectBase {

    #region Properties

    /// <summary>
    /// Gets the internal <see cref="global::Newtonsoft.Json.Linq.JObject"/> the object was created from.
    /// </summary>
    [JsonIgnore]
    public JObject? JObject { get; }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="global::Newtonsoft.Json.Linq.JObject"/> representing the object.</param>
    protected JsonNullableObjectBase(JObject? json) {
        JObject = json;
    }

    #endregion

}
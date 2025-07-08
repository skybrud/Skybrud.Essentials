using Newtonsoft.Json.Serialization;

namespace Skybrud.Essentials.Json.Newtonsoft.Serialization;

/// <summary>
/// Contract resolver using a <see cref="CamelCaseNamingStrategy"/>.
/// </summary>
public class CamelCaseJsonContractResolver : DefaultContractResolver {

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    public CamelCaseJsonContractResolver() {
        NamingStrategy = new CamelCaseNamingStrategy();
    }

}
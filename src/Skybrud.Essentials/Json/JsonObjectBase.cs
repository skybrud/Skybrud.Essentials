using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json {

    /// <summary>
    /// Class representing an object that was parsed from an instance of <see cref="global::Newtonsoft.Json.Linq.JObject"/>.
    /// </summary>
    public class JsonObjectBase {

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
        protected JsonObjectBase(JObject? json) {
            JObject = json;
        }

        #endregion

    }

}
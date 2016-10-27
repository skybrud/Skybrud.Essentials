using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json {
    
    /// <summary>
    /// Class representing an object that was parsed from an instance of <see cref="JObject"/>.
    /// </summary>
    public class JsonObjectBase {
        
        #region Properties

        /// <summary>
        /// Gets the internal <see cref="JObject"/> the object was created from.
        /// </summary>
        [JsonIgnore]
        public JObject JObject { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="JsonObjectBase"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="JsonObjectBase"/>.</returns>
        protected JsonObjectBase(JObject obj) {
            JObject = obj;
        }

        #endregion

    }

}
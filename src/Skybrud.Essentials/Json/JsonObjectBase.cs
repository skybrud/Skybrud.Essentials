using System;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json {

    /// <summary>
    /// Class representing an object that was parsed from an instance of <see cref="JObject"/>.
    /// </summary>
    [Obsolete("Use the 'Skybrud.Essentials.Json.Newtonsoft.JsonObjectBase' class instead.")]
    public class JsonObjectBase : Newtonsoft.JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected JsonObjectBase(JObject? json) : base(json) { }

        #endregion

    }

}
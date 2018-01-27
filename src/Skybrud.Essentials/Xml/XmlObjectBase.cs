using System.Xml.Linq;
using Newtonsoft.Json;

namespace Skybrud.Essentials.Xml {

    /// <summary>
    /// Class representing an object that was parsed from an instance of <see cref="System.Xml.Linq.XElement"/>.
    /// </summary>
    public class XmlObjectBase {

        #region Properties

        /// <summary>
        /// Gets the internal <see cref="System.Xml.Linq.XElement"/> the object was created from.
        /// </summary>
        [JsonIgnore]
        public XElement XElement { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="xml"/>.
        /// </summary>
        /// <param name="xml">The instance of <see cref="System.Xml.Linq.XElement"/> representing the object.</param>
        /// <returns>An instance of <see cref="XmlObjectBase"/>.</returns>
        protected XmlObjectBase(XElement xml) {
            XElement = xml;
        }

        #endregion

    }

}
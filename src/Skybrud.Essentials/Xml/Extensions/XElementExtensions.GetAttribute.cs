using System.Xml.Linq;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        /// <summary>
        /// Gets the first attribute matching the the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <see cref="XAttribute"/>, or <c>null</c> if no attributes were matched.</returns>
        public static XAttribute GetAttribute(this XElement element, XName name) {
            return element == null ? null : element.Attribute(name);
        }

    }

}
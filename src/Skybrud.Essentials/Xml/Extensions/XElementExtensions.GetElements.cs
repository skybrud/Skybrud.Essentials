using System;
using System.Linq;
using System.Xml.Linq;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the elements.</param>
        /// <returns>An array of <see cref="XElement"/>.</returns>
        public static XElement[] GetElements(this XElement element, XName name) {
            return element?.Elements(name).ToArray() ?? new XElement[0];
        }
        
        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <paramref name="name"/> and parses each element using <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the elements.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>The elements as parsed by the specified <paramref name="callback"/>.</returns>
        public static T[] GetElements<T>(this XElement element, XName name, Func<XElement, T> callback) {
            return element?.Elements(name).Select(callback).ToArray() ?? new T[0];
        }

    }

}
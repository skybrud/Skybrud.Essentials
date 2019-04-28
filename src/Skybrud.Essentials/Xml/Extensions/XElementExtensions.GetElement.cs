using System;
using System.Xml.Linq;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <returns>An instance of <see cref="XElement"/>, or <c>null</c> if <paramref name="name"/> doesn't match any elements.</returns>
        public static XElement GetElement(this XElement element, XName name) {
            return element?.Element(name);
        }

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <paramref name="name"/> and parses it using <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if <paramref name="name"/> doesn't match any elements.</returns>
        public static T GetElement<T>(this XElement element, XName name, Func<XElement, T> callback) {
            XElement child = element?.Element(name);
            return child == null ? default : callback(child);
        }

    }

}
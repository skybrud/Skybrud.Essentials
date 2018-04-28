#if I_CAN_HAZ_XPATH

using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>An array of <see cref="XElement"/>.</returns>
        public static XElement[] GetElements(this XElement element, string expression) {
            return element == null ? new XElement[0] : element.XPathSelectElements(expression).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <returns>An array of <see cref="XElement"/>.</returns>
        public static XElement[] GetElements(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return element == null ? new XElement[0] : element.XPathSelectElements(expression, resolver).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <paramref name="expression"/> and parses each element using <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="callback">A callback function for parsing the elements.</param>
        /// <returns>The elements as parsed by the specified <paramref name="callback"/>.</returns>
        public static T[] GetElements<T>(this XElement element, string expression, Func<XElement, T> callback) {
            return element == null ? new T[0] : element.XPathSelectElements(expression).Select(callback).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <paramref name="expression"/> and parses each element using <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <param name="callback">A callback function for parsing the elements.</param>
        /// <returns>The elements as parsed by the specified <paramref name="callback"/>.</returns>
        public static T[] GetElements<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<XElement, T> callback) {
            return element == null ? new T[0] : element.XPathSelectElements(expression, resolver).Select(callback).ToArray();
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> representing the elelement matching the specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="callback">A callback function for parsing the elements.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetElements<T>(this XElement element, string expression, Func<XElement, IXmlNamespaceResolver, T> callback, IXmlNamespaceResolver resolver) {
            return (
                from child in element.XPathSelectElements(expression, resolver)
                select callback(child, resolver)
            ).ToArray();
        }

        /// <summary>
        /// Gets an array of <typeparamref name="T"/> representing the elelement matching the specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="callback">A callback function for parsing the elements.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <param name="resolver2">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetElements<T>(this XElement element, string expression, Func<XElement, IXmlNamespaceResolver, T> callback, IXmlNamespaceResolver resolver, IXmlNamespaceResolver resolver2) {
            return (
                from child in element.XPathSelectElements(expression, resolver)
                select callback(child, resolver2)
            ).ToArray();
        }

    }

}

#endif
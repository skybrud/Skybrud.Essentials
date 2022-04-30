
using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

#if I_CAN_HAZ_XPATH

namespace Skybrud.Essentials.Xml.Extensions {
    public static partial class XElementExtensions {

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>An instance of <see cref="XElement"/>, or <c>null</c> if <paramref name="expression"/> doesn't match any elements.</returns>
        public static XElement GetElement(this XElement element, string expression) {
            return element?.XPathSelectElement(expression);
        }

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <paramref name="expression"/> and parses it using <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if <paramref name="expression"/> doesn't match any elements.</returns>
        public static T GetElement<T>(this XElement element, string expression, Func<XElement, T> callback) {
            XElement child = element?.XPathSelectElement(expression);
            return child == null ? default(T) : callback(child);
        }

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <returns>An instance of <see cref="XElement"/>, or <c>null</c> if <paramref name="expression"/> doesn't match any elements.</returns>
        public static XElement GetElement(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return element?.XPathSelectElement(expression, resolver);
        }

        /// <summary>
        /// Gets the first <see cref="XElement"/> matching the specified <paramref name="expression"/> and parses it using <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if <paramref name="expression"/> doesn't match any elements.</returns>
        public static T GetElement<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<XElement, T> callback) {
            XElement child = element?.XPathSelectElement(expression, resolver);
            return child == null ? default(T) : callback(child);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the first element matching the specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type of the item to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if <paramref name="expression"/> doesn't match any elements.</returns>
        public static T GetElement<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<XElement, IXmlNamespaceResolver, T> callback) {
            XElement child = element.XPathSelectElement(expression, resolver);
            return child == null ? default(T) : callback(child, resolver);
        }

    }

}

#endif
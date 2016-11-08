using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <code>name</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the elements.</param>
        /// <returns>Returns an array of <see cref="XElement"/>.</returns>
        public static XElement[] GetElements(this XElement element, XName name) {
            return element == null ? new XElement[0] : element.Elements(name).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <code>expression</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>Returns an array of <see cref="XElement"/>.</returns>
        public static XElement[] GetElements(this XElement element, string expression) {
            return element == null ? new XElement[0] : element.XPathSelectElements(expression).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <code>expression</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <returns>Returns an array of <see cref="XElement"/>.</returns>
        public static XElement[] GetElements(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return element == null ? new XElement[0] : element.XPathSelectElements(expression, resolver).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <code>name</code> and parses each element using <code>callback</code>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the elements.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>Returns the elements as parsed by the specified <code>callback</code>.</returns>
        public static T[] GetElements<T>(this XElement element, XName name, Func<XElement, T> callback) {
            return element == null ? new T[0] : element.Elements(name).Select(callback).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <code>expression</code> and parses each element using <code>callback</code>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="callback">A callback function for parsing the elements.</param>
        /// <returns>Returns the elements as parsed by the specified <code>callback</code>.</returns>
        public static T[] GetElements<T>(this XElement element, string expression, Func<XElement, T> callback) {
            return element == null ? new T[0] : element.XPathSelectElements(expression).Select(callback).ToArray();
        }

        /// <summary>
        /// Gets an array of <see cref="XElement"/> matching the specified <code>expression</code> and parses each element using <code>callback</code>.
        /// </summary>
        /// <typeparam name="T">The type of the items to be returned.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <param name="callback">A callback function for parsing the elements.</param>
        /// <returns>Returns the elements as parsed by the specified <code>callback</code>.</returns>
        public static T[] GetElements<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<XElement, T> callback) {
            return element == null ? new T[0] : element.XPathSelectElements(expression, resolver).Select(callback).ToArray();
        }

        public static T[] GetElements<T>(this XElement element, string expression, Func<XElement, IXmlNamespaceResolver, T> func, IXmlNamespaceResolver resolver) {
            return (
                from child in element.XPathSelectElements(expression, resolver)
                select func(child, resolver)
            ).ToArray();
        }

        public static T[] GetElements<T>(this XElement element, string expression, Func<XElement, IXmlNamespaceResolver, T> func, IXmlNamespaceResolver resolver, IXmlNamespaceResolver resolver2) {
            return (
                from child in element.XPathSelectElements(expression, resolver)
                select func(child, resolver2)
            ).ToArray();
        }

    }

}
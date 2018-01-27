using System;
using System.Xml;
using System.Xml.Linq;

namespace Skybrud.Essentials.Xml.Extensions {

    /// <summary>
    /// Static class with various extension methods for <see cref="XElement"/>.
    /// </summary>
    public static partial class XElementExtensions {

        /// <summary>
        /// Gets whether the first element matching the specified <paramref name="name"/> has a value.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <returns><code>true</code> if an element was found and has a value; otherwise <code>false</code>.</returns>
        public static bool HasElementValue(this XElement element, XName name) {

            // Get the element matching "name"
            XElement child = GetElement(element, name);

            // Check whether the element was found and has a value
            return child != null && !String.IsNullOrWhiteSpace(child.Value);

        }

        #if I_CAN_HAZ_XPATH

        /// <summary>
        /// Gets whether the first element matching the specified XPath <paramref name="expression"/> has a value.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns><code>true</code> if an element was found and has a value; otherwise <code>false</code>.</returns>
        public static bool HasElementValue(this XElement element, string expression) {

            // Get the element matching "name"
            XElement child = GetElement(element, expression);

            // Check whether the element was found and has a value
            return child != null && !String.IsNullOrWhiteSpace(child.Value);

        }

        /// <summary>
        /// Gets whether the first element matching the specified XPath <paramref name="expression"/> has a value.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <returns><code>true</code> if an element was found and has a value; otherwise <code>false</code>.</returns>
        public static bool HasElementValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {

            // Get the element matching "name"
            XElement child = GetElement(element, expression, resolver);

            // Check whether the element was found and has a value
            return child != null && !String.IsNullOrWhiteSpace(child.Value);

        }

        #endif

        /// <summary>
        /// Gets the outer XML of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The XML element.</param>
        /// <returns>A string representing the outer XML of <paramref name="element"/>.</returns>
        /// <see>
        ///     <cref>https://stackoverflow.com/a/1704579</cref>
        /// </see>
        public static string GetOuterXml(this XElement element) {
            return XmlUtils.GetOuterXml(element);
        }

        /// <summary>
        /// Gets the inner XML of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The XML element.</param>
        /// <returns>A string representing the inner XML of <paramref name="element"/>.</returns>
        /// <see>
        ///     <cref>https://stackoverflow.com/a/1704579</cref>
        /// </see>
        public static string GetInnerXml(this XElement element) {
            return XmlUtils.GetInnerXml(element);
        }

    }

}
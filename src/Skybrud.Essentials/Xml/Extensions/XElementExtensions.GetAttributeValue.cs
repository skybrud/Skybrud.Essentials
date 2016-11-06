using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        #region Get element value as System.String

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>, or <code>null</code> if
        /// <code>name</code> doesn't match any attributes.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns the value of the attribute, or <code>null</code> if not found.</returns>
        public static string GetAttributeValue(this XElement element, XName name) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? null : child.Value;
        }

        public static T GetAttributeValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(T) : callback(child.Value);
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>expression</code>, or <code>null</code> if the
        /// expression doesn't match any attributes.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>Returns the value of the attribute, or <code>null</code> if not found.</returns>
        public static string GetAttributeValue(this XElement element, string expression) {
            return GetAttributeValue(element, expression, null);
        }

        public static string GetAttributeValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {

            if (element == null) return null;

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object> result = (IEnumerable<object>) element.XPathEvaluate(expression, resolver);

            // Get the first instance of "XAttribute"
            XAttribute attr = result.OfType<XAttribute>().FirstOrDefault();

            // Get the value or return "null"
            return attr == null ? null : attr.Value;

        }

        public static T GetAttributeValue<T>(this XElement element, string expression, Func<string, T> callback) {
            string value = GetAttributeValue(element, expression);
            return value == null ? default(T) : callback(value);
        }

        public static T GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<string, T> callback) {
            string value = GetAttributeValue(element, expression, resolver);
            return value == null ? default(T) : callback(value);
        }

        #endregion

    }

}
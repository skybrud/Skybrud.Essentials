﻿#if I_CAN_HAZ_XPATH

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        /// <summary>
        /// Gets the first attribute matching the the specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">An instance of <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression to match.</param>
        /// <returns>An instance of <see cref="XAttribute"/>, or <c>null</c> if no attributes were matched.</returns>
        public static XAttribute? GetAttribute(this XElement? element, string expression) {
            return GetAttribute(element, expression, null);
        }

        /// <summary>
        /// Gets the first attribute matching the the specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">An instance of <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression to match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression.</param>
        /// <returns>An instance of <see cref="XAttribute"/>, or <c>null</c> if no attributes were matched.</returns>
        public static XAttribute? GetAttribute(this XElement? element, string expression, IXmlNamespaceResolver? resolver) {

            // If "expression" is just the name of the attribute, we convert the expression to an instance of "XName"
            if (Regex.IsMatch(expression, "^[0-9a-zA-Z_]+$")) return GetAttribute(element, (XName) expression);

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object>? result = element?.XPathEvaluate(expression, resolver) as IEnumerable<object>;

            // Get the first instance of "XAttribute"
            return result?.OfType<XAttribute>().FirstOrDefault();

        }

    }

}

#endif
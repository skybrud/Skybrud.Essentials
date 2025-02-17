using System;
using System.Xml.Linq;

namespace Skybrud.Essentials.Xml.Exceptions;

/// <summary>
/// Class representing an XMl related exception.
/// </summary>
public class XmlException : Exception {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The exception message.</param>
    public XmlException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="message"/> and <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception, if any.</param>
    public XmlException(string message, Exception? innerException) : base(message, innerException) { }

    /// <summary>
    /// Initializes a new exception to indicate that an XPath <paramref name="expression"/> didn't match any attributes or elements.
    /// </summary>
    /// <param name="element">The parent element.-</param>
    /// <param name="expression">The XPath expression.</param>
    /// <returns>An instance of <see cref="XmlXPathException"/>.</returns>
    public static XmlXPathException XPathExpressionNotFound(XElement element, string expression) {
        return new XmlXPathException(element, expression, $"XPath '{expression}' did not match an attribute or element.");
    }

    /// <summary>
    /// Initializes a new exception to indicate that the value of the attribute or element matching the specified  XPath <paramref name="expression"/> could not be converted to the desired type.
    /// </summary>
    /// <param name="element">The parent element.</param>
    /// <param name="expression">The XPath expression.</param>
    /// <param name="parentType">A string indicating the parent type (<c>attribute</c> or <c>element</c>).</param>
    /// <param name="valueType">A text decribing the value type.</param>
    /// <returns>An instance of <see cref="XmlConvertException"/>.</returns>
    public static XmlConvertException ConversionFailed(XElement element, string expression, string parentType, string valueType) {
        return new XmlConvertException(element, expression, $"Resolved {parentType} value doesn't match a valid {valueType}.");
    }

}
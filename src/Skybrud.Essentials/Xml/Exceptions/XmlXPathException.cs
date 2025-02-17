using System.Xml.Linq;

namespace Skybrud.Essentials.Xml.Exceptions;

/// <summary>
/// Exception representing an XPath related exception.
/// </summary>
public class XmlXPathException : XmlException {

    /// <summary>
    /// The parent element.
    /// </summary>
    public XElement Element { get; }

    /// <summary>
    /// The XPath expression.
    /// </summary>
    public string Expression { get; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="element"/>, <paramref name="expression"/> and <paramref name="message"/>.
    /// </summary>
    /// <param name="element">The parent element.</param>
    /// <param name="expression">The XPath expression.</param>
    /// <param name="message">The exception message.</param>
    public XmlXPathException(XElement element, string expression, string message) : base(message) {
        Element = element;
        Expression = expression;
    }

}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Strings;

using XmlException = Skybrud.Essentials.Xml.Exceptions.XmlException;

namespace Skybrud.Essentials.Xml.Extensions;

public partial class XPathExtensions {

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a double-precision floating point number, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The double-precision floating point number.</returns>
    public static double GetDoubleValue(this XElement element, string expression) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression), out double result) ? result : 0;
    }

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a double-precision floating point number, <c>0</c> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The double-precision floating point number.</returns>
    public static double GetDoubleValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression, resolver), out double result) ? result : 0;
    }

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a double-precision floating point number, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The double-precision floating point number if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static double GetDoubleValue(this XElement element, string expression, double fallback) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression), out double result) ? result : fallback;
    }

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a double-precision floating point number, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The double-precision floating point number if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static double GetDoubleValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, double fallback) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression, resolver), out double result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <typeparamref name="TResult"/> value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be converted to first a double-precision floating point number, the default value of <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type to convert to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">A callback function used for converting the double-precision floating point number to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetDoubleValue<TResult>(this XElement element, string expression, Func<double, TResult> callback) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression), out double result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the <typeparamref name="TResult"/> value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be converted to first a double-precision floating point number, the default value of <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type to convert to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">A callback function used for converting the double-precision floating point number to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetDoubleValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<double, TResult> callback) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression, resolver), out double result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified
    /// XPath <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not
    /// be converted to a double-precision floating point number, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The double-precision floating point number.</returns>
    public static double? GetDoubleValueOrNull(this XElement element, string expression) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression), out double? result) ? result : null;
    }

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found, ot the value can not be
    /// converted to a double-precision floating point number, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The double-precision floating point number.</returns>
    public static double? GetDoubleValueOrNull(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression, resolver), out double? result) ? result : null;
    }

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a double-precision floating point number, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The value converted to a double-precision floating point number.</returns>
    public static double GetRequiredDoubleValue(this XElement element, string expression) {
        return GetRequiredDoubleValue(element, expression, null);
    }

    /// <summary>
    /// Returns the double-precision floating point number of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to a double-precision floating point number, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The value converted to a double-precision floating point number.</returns>
    public static double GetRequiredDoubleValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        if (!TryGetAttributeOrElementValue(element, expression, resolver, out string? value, out string? parentType)) throw XmlException.XPathExpressionNotFound(element, expression);
        return StringUtils.TryParseDouble(value, out double result) ? result : throw XmlException.ConversionFailed(element, expression, parentType, "double-precision floating point number");
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="double"/>, the <see cref="double"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="double"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="double"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the <see cref="double"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredDoubleValue<TResult>(this XElement element, string expression, Func<double, TResult> callback) where TResult : notnull {
        return callback(GetRequiredDoubleValue(element, expression));
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="double"/>, the <see cref="double"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="double"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the <see cref="double"/> value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the <see cref="double"/> value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredDoubleValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<double, TResult> callback) where TResult : notnull {
        return callback(GetRequiredDoubleValue(element, expression, resolver));
    }

    /// <summary>
    /// Attempts to get a double-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the double-precision floating point number if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDoubleValue(this XElement element, string expression, out double result) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a double-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the double-precision floating point number if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDoubleValue(this XElement element, string expression, [NotNullWhen(true)] out double? result) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a double-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the double-precision floating point number if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDoubleValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, out double result) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression, resolver), out result);
    }

    /// <summary>
    /// Attempts to get a double-precision floating point number from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the double-precision floating point number if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDoubleValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out double? result) {
        return StringUtils.TryParseDouble(GetStringValue(element, expression, resolver), out result);
    }

}
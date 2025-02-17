#if NETSTANDARD1_3_OR_GREATER || NET45_OR_GREATER || NET5_0_OR_GREATER

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using XmlException = Skybrud.Essentials.Xml.Exceptions.XmlException;

// ReSharper disable IntroduceOptionalParameters.Local

namespace Skybrud.Essentials.Xml.Extensions;

public partial class XPathExtensions {

    /// <summary>
    /// Returns the value of the first attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The attribute or element value if found; otherwise, <see langword="null"/>.</returns>
    public static string? GetStringValue(this XElement element, string expression) {
        return TryGetStringValue(element, expression, out string? result) ? result : null;
    }

    /// <summary>
    /// Returns the value of the first attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The attribute or element value if found; otherwise, <see langword="null"/>.</returns>
    public static string? GetStringValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return TryGetStringValue(element, expression, resolver, out string? result) ? result : null;
    }

    /// <summary>
    /// Returns the string value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found,
    /// <paramref name="fallback"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The string value if successful; otherwise, <paramref name="fallback"/>.</returns>
    [return: NotNullIfNotNull(nameof(fallback))]
    public static string? GetStringValue(this XElement element, string expression, string? fallback) {
        return GetStringValue(element, expression) ?? fallback;
    }

    /// <summary>
    /// Returns the string value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element value isn't found,
    /// <paramref name="fallback"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The string value if successful; otherwise, <paramref name="fallback"/>.</returns>
    [return: NotNullIfNotNull(nameof(fallback))]
    public static string? GetStringValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, string? fallback) {
        return GetStringValue(element, expression, resolver) ?? fallback;
    }

    /// <summary>
    /// Returns the value of the first attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">A callback function used for converting the attribute or element value.</param>
    /// <returns>The attribute or element value if found; otherwise, <see langword="null"/>.</returns>
    public static TResult? GetStringValue<TResult>(this XElement element, string expression, Func<string, TResult> callback) {
        return TryGetStringValue(element, expression, out string? result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the value of the first attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element isn't found, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">A callback function used for converting the attribute or element value.</param>
    /// <returns>The attribute or element value if found; otherwise, <see langword="null"/>.</returns>
    public static TResult? GetStringValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<string, TResult> callback) {
        return TryGetStringValue(element, expression, resolver, out string? result) ? callback(result) : default;
    }

    /// <summary>
    /// Attempts to get the value of an attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the attribute or element value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching attribute or element value is found; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetStringValue(this XElement element, string expression, [NotNullWhen(true)] out string? result) {

        // Not sure if the returned value can ever be anything other than 'IEnumerable'...
        if (element.XPathEvaluate(expression) is not IEnumerable value) {
            result = null;
            return false;
        }

        // We really only care about the first item, but since the 'IEnumerable' interface doesn't
        // describe a '.FirstOrDefault()' method similar to 'IEnumerable<T>' interface, we need to
        // iterate over the collection
        foreach (object item in value) {

            // Not sure if an item can be anything else than 'XAttribute' and 'XElement' ¯\_(ツ)_/¯
            switch (item) {
                case XAttribute attr:
                    result = attr.Value;
                    return true;
                case XElement el:
                    result = el.Value;
                    return true;
                default:
                    result = null;
                    return false;
            }

        }

        // Return false as the expression didn't match anything
        result = null;
        return false;

    }

    /// <summary>
    /// Attempts to get the value of an attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the attribute or element value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a matching attribute or element value is found; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetStringValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out string? result) {

        if (element.XPathEvaluate(expression, resolver) is not IEnumerable value) {
            result = null;
            return false;
        }

        foreach (object item in value) {

            switch (item) {
                case XAttribute attr:
                    result = attr.Value;
                    return true;
                case XElement el:
                    result = el.Value;
                    return true;
                default:
                    result = null;
                    return false;
            }

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a matching attribute or element isn't found, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The attribute or element value.</returns>
    /// <exception cref="Exception">If a matching attribute or element isn't found.</exception>
    public static string GetRequiredStringValue(this XElement element, string expression) {
        return GetRequiredStringValue(element, expression, null);
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a matching attribute or element isn't found, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The attribute or element value.</returns>
    /// <exception cref="Exception">If a matching attribute or element isn't found.</exception>
    public static string GetRequiredStringValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        if (TryGetStringValue(element, expression, out string? value)) return value;
        throw XmlException.XPathExpressionNotFound(element, expression);
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If an
    /// attribute or element is found, the value is converted to <typeparamref name="TResult"/> using the specified
    /// <paramref name="callback"/> function. If a matching atteibute or element isn't found, the default value of
    /// <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the value.</param>
    /// <returns>The converted value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult GetRequiredStringValue<TResult>(this XElement element, string expression, Func<string, TResult> callback) where TResult : notnull {
        return GetRequiredStringValue(element, expression, null, callback);
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If an
    /// attribute or element is found, the value is converted to <typeparamref name="TResult"/> using the specified
    /// <paramref name="callback"/> function. If a matching atteibute or element isn't found, the default value of
    /// <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the value.</param>
    /// <returns>The converted value if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult GetRequiredStringValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<string, TResult> callback) where TResult : notnull {
        return callback(GetRequiredStringValue(element, expression, resolver));
    }

    private static bool TryGetAttributeOrElementValue(XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out string? result, [NotNullWhen(true)] out string? parentType) {

        if (element.XPathEvaluate(expression, resolver) is not IEnumerable enumerable) {
            result = null;
            parentType = null;
            return false;
        }

        foreach (object? item in enumerable) {

            switch (item) {
                case XAttribute attr:
                    result = attr.Value;
                    parentType = "attribute";
                    return true;
                case XElement el:
                    result = el.Value;
                    parentType = "element";
                    return true;
            }

            break;

        }

        result = null;
        parentType = null;
        return false;

    }

}

#endif
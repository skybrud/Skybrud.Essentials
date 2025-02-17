#if NETSTANDARD1_3_OR_GREATER || NET45_OR_GREATER || NET5_0_OR_GREATER

using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Strings;

using XmlException = Skybrud.Essentials.Xml.Exceptions.XmlException;

namespace Skybrud.Essentials.Xml.Extensions;

public partial class XPathExtensions {

    /// <summary>
    /// Returns the GUID value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a GUID value,
    /// <see cref="Guid.Empty"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The GUID value if successful; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static Guid GetGuidValue(this XElement element, string expression) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression), out Guid result) ? result : Guid.Empty;
    }

    /// <summary>
    /// Returns the GUID value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a GUID value,
    /// <see cref="Guid.Empty"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The GUID value if successful; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static Guid GetGuidValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression, resolver), out Guid result) ? result : Guid.Empty;
    }

    /// <summary>
    /// Returns the GUID value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a GUID value,
    /// <paramref name="fallback"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The GUID value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static Guid GetGuidValue(this XElement element, string expression, Guid fallback) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression), out Guid result) ? result : fallback;
    }

    /// <summary>
    /// Returns the GUID value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a GUID value,
    /// <paramref name="fallback"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The GUID value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static Guid GetGuidValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, Guid fallback) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression, resolver), out Guid result) ? result : fallback;
    }

    /// <summary>
    /// Returns the <typeparamref name="TResult"/> value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to GUID value, the default value of <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type to convert to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">A callback function used for converting the GUID value to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetGuidValue<TResult>(this XElement element, string expression, Func<Guid, TResult> callback) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression), out Guid result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the <typeparamref name="TResult"/> value of the attribute or element matching the specified XPath
    /// <paramref name="expression"/>. If a matching attribute or element isn't found, or the value can not be
    /// converted to GUID value, the default value of <typeparamref name="TResult"/> is returned instead.
    /// </summary>
    /// <typeparam name="TResult">The type to convert to.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">A callback function used for converting the GUID value to <typeparamref name="TResult"/>.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> if successful; otherwise, the default value of <typeparamref name="TResult"/>.</returns>
    public static TResult? GetGuidValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<Guid, TResult> callback) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression, resolver), out Guid result) ? callback(result) : default;
    }

    /// <summary>
    /// Returns the GUID value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a GUID value,
    /// <see langword="null"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The GUID value if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidValueOrNull(this XElement element, string expression) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression), out Guid? result) ? result : null;
    }

    /// <summary>
    /// Returns the GUID value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a GUID value,
    /// <see langword="null"/> is returned insetad.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The GUID value if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidValueOrNull(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression, resolver), out Guid? result) ? result : null;
    }

    /// <summary>
    /// Returns the GUID of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element isn't found, or the value can not be converted to a GUID value, an exception is
    /// thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The GUID value.</returns>
    public static Guid GetRequiredGuidValue(this XElement element, string expression) {
        return GetRequiredGuidValue(element, expression, null);
    }

    /// <summary>
    /// Returns the GUID value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element isn't found, or the value can not be converted to a GUID value, an exception
    /// is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The GUID value.</returns>
    public static Guid GetRequiredGuidValue(this XElement element, string expression, IXmlNamespaceResolver? resolver) {
        if (!TryGetAttributeOrElementValue(element, expression, resolver, out string? value, out string? parentType)) throw XmlException.XPathExpressionNotFound(element, expression);
        return StringUtils.TryParseGuid(value, out Guid result) ? result : throw XmlException.ConversionFailed(element, expression, parentType, "GUID value");
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a GUID, the GUID value is converted using the
    /// specified <paramref name="callback"/> function. If a matching attribute or element isn't found, or the value
    /// doesn't match a GUID value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the GUID value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the GUID value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredGuidValue<TResult>(this XElement element, string expression, Func<Guid, TResult> callback) where TResult : notnull {
        return callback(GetRequiredGuidValue(element, expression));
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a GUID, the GUID value is converted using the
    /// specified <paramref name="callback"/> function. If a matching attribute or element isn't found, or the value
    /// doesn't match a GUID value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TResult">The type to which the GUID value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the GUID value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredGuidValue<TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<Guid, TResult> callback) where TResult : notnull {
        return callback(GetRequiredGuidValue(element, expression, resolver));
    }

    /// <summary>
    /// Attempts to get a GUID value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the GUID value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuidValue(this XElement element, string expression, out Guid result) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a GUID value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the GUID value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuidValue(this XElement element, string expression, [NotNullWhen(true)] out Guid? result) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get a GUID value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the GUID value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuidValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, out Guid result) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression, resolver), out result);
    }

    /// <summary>
    /// Attempts to get a GUID value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the GUID value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuidValue(this XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out Guid? result) {
        return StringUtils.TryParseGuid(GetStringValue(element, expression, resolver), out result);
    }

}

#endif
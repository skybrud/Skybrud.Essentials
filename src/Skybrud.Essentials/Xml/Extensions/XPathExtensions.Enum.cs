using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Enums;
using XmlException = Skybrud.Essentials.Xml.Exceptions.XmlException;

namespace Skybrud.Essentials.Xml.Extensions;

public partial class XPathExtensions {

    /// <summary>
    /// Returns the enum value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a
    /// <typeparamref name="TEnum"/> value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The enum value.</returns>
    public static TEnum GetEnumValue<TEnum>(this XElement element, string expression, TEnum fallback) where TEnum : struct, Enum {
        return GetEnumValue(element, expression, null, fallback);
    }

    /// <summary>
    /// Returns the enum value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a
    /// <typeparamref name="TEnum"/> value, <paramref name="fallback"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The enum value.</returns>
    public static TEnum GetEnumValue<TEnum>(this XElement element, string expression, IXmlNamespaceResolver? resolver, TEnum fallback) where TEnum : struct, Enum {
        return EnumUtils.TryParseEnum(GetStringValue(element, expression, resolver), out TEnum result) ? result : fallback;
    }

    /// <summary>
    /// Returns the enum value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a
    /// <typeparamref name="TEnum"/> value, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The enum value if found; otherwise, <see langword="null"/>.</returns>
    public static TEnum? GetEnumValueOrNull<TEnum>(this XElement element, string expression) where TEnum : struct, Enum {
        return EnumUtils.TryParseEnum(GetStringValue(element, expression), out TEnum result) ? result : null;
    }

    /// <summary>
    /// Returns the enum value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element value isn't found, ot the value can not be converted to a
    /// <typeparamref name="TEnum"/> value, <see langword="null"/> is returned instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The enum value if found; otherwise, <see langword="null"/>.</returns>
    public static TEnum? GetEnumValueOrNull<TEnum>(this XElement element, string expression, IXmlNamespaceResolver? resolver) where TEnum : struct, Enum {
        return EnumUtils.TryParseEnum(GetStringValue(element, expression, resolver), out TEnum result) ? result : null;
    }

    /// <summary>
    /// Returns the enum value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element isn't found, or the value can not be converted to a
    /// <typeparamref name="TEnum"/> value, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <returns>The enum value.</returns>
    public static TEnum GetRequiredEnumValue<TEnum>(this XElement element, string expression) where TEnum : struct, Enum {
        return GetRequiredEnumValue<TEnum>(element, expression, null);
    }

    /// <summary>
    /// Returns the enum value of the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// If a matching attribute or element isn't found, or the value can not be converted to a
    /// <typeparamref name="TEnum"/> value, an exception is thrown instead.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <returns>The enum value.</returns>
    public static TEnum GetRequiredEnumValue<TEnum>(this XElement element, string expression, IXmlNamespaceResolver? resolver) where TEnum : struct, Enum {
        if (!TryGetAttributeOrElementValue(element, expression, resolver, out string? value, out string? parentType)) throw XmlException.XPathExpressionNotFound(element, expression);
        return EnumUtils.TryParseEnum(value, out TEnum result) ? result : throw XmlException.ConversionFailed(element, expression, parentType, "enum value");
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches an enum value, the enum value is converted using
    /// the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match an enum value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <typeparam name="TResult">The type to which the enum value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="callback">The callback function used for converting the enum value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredEnumValue<TEnum, TResult>(this XElement element, string expression, Func<TEnum, TResult> callback) where TEnum : struct, Enum where TResult : notnull {
        return callback(GetRequiredEnumValue<TEnum>(element, expression));
    }

    /// <summary>
    /// Returns the value of the attribute or element matching the specified XPath <paramref name="expression"/>. If a
    /// matching attribute or element is found, and the value matches a <see cref="double"/>, the <see cref="double"/>
    /// value is converted using the specified <paramref name="callback"/> function. If a matching attribute or element
    /// isn't found, or the value doesn't match a <see cref="double"/> value, an exception is thrown instead.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <typeparam name="TResult">The type to which the enum value will be converted.</typeparam>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="callback">The callback function used for converting the enum value to an instance of <typeparamref name="TResult"/>.</param>
    /// <returns>The converted <typeparamref name="TResult"/> value.</returns>
    public static TResult GetRequiredEnumValue<TEnum, TResult>(this XElement element, string expression, IXmlNamespaceResolver? resolver, Func<TEnum, TResult> callback) where TEnum : struct, Enum where TResult : notnull {
        return callback(GetRequiredEnumValue<TEnum>(element, expression, resolver));
    }

    /// <summary>
    /// Attempts to get an enum value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the enum value if successful; otherwise, the default value of <typeparamref name="TEnum"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetEnumValue<TEnum>(this XElement element, string expression, out TEnum result) where TEnum : struct, Enum {
        return EnumUtils.TryParseEnum(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get an enum value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="result">When this method returns, holds the enum value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetEnumValue<TEnum>(this XElement element, string expression, [NotNullWhen(true)] out TEnum? result) where TEnum : struct, Enum {
        return EnumUtils.TryParseEnum(GetStringValue(element, expression), out result);
    }

    /// <summary>
    /// Attempts to get an enum value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the enum value if successful; otherwise, the default value of <typeparamref name="TEnum"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetEnumValue<TEnum>(this XElement element, string expression, IXmlNamespaceResolver? resolver, out TEnum result) where TEnum : struct, Enum {
        return EnumUtils.TryParseEnum(GetStringValue(element, expression, resolver), out result);
    }

    /// <summary>
    /// Attempts to get an enum value from the attribute or element matching the specified XPath <paramref name="expression"/>.
    /// </summary>
    /// <param name="element">The <see cref="XElement"/>.</param>
    /// <param name="expression">The XPath expression to match.</param>
    /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes in the XPath expression.</param>
    /// <param name="result">When this method returns, holds the enum value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetEnumValue<TEnum>(this XElement element, string expression, IXmlNamespaceResolver? resolver, [NotNullWhen(true)] out TEnum? result) where TEnum : struct, Enum {
        return EnumUtils.TryParseEnum(GetStringValue(element, expression, resolver), out result);
    }

}
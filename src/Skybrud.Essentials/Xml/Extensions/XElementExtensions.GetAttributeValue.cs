using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

// ReSharper disable RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        #region Get attribute value as System.String

        /// <summary>
        /// Gets the value of the attribute matching the specified <paramref name="name"/>, or an empty string if
        /// <paramref name="name"/> doesn't match any attributes.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <see cref="String"/> representing the attribute value, or an empty string if
        /// a matching attribute wasn't found not found.</returns>
        public static string GetAttributeValue(this XElement? element, XName name) {
            XAttribute? attr = element?.GetAttribute(name);
            return attr?.Value ?? string.Empty;
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// <paramref name="name"/>. If a matching attribute wasn't found, an empty string will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or an empty string if
        /// a matching attribute wasn't found not found.</returns>
        public static T GetAttributeValue<T>(this XElement? element, XName name, Func<string, T> callback) {
            XAttribute? attr = element?.GetAttribute(name);
            return attr == null ? default! : callback(attr.Value);
        }

        #endregion

        #region Get attribute value as System.Int32

        /// <summary>
        /// Gets an instance of <see cref="Int32"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int32"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <see cref="Int32"/> representing the attribute value, or the default value
        /// of <see cref="Int32"/> if a matching attribute wasn't found.</returns>
        public static int GetAttributeValueAsInt32(this XElement? element, XName name) {
            return GetAttributeValueAsInt32(element, name, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int32"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int32"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="value">An instance of <see cref="Int32"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsInt32(this XElement? element, XName name, out int value) {
            return GetAttributeValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsInt32<T>(this XElement? element, XName name, Func<int, T> callback) {
            return GetAttributeValue(element, name, out int value) ? callback(value) : default!;
        }

        #endregion

        #region Get attribute value as System.Int64

        /// <summary>
        /// Gets an instance of <see cref="Int64"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int64"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <see cref="Int64"/> representing the attribute value, or the default value
        /// of <see cref="Int64"/> if a matching attribute wasn't found.</returns>
        public static long GetAttributeValueAsInt64(this XElement? element, XName name) {
            return GetAttributeValueAsInt64(element, name, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int64"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int64"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="value">An instance of <see cref="Int64"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsInt64(this XElement? element, XName name, out long value) {
            return GetAttributeValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T? GetAttributeValueAsInt64<T>(this XElement? element, XName name, Func<long, T> callback) {
            return GetAttributeValue(element, name, out long value) ? callback(value) : default;
        }

        #endregion

        #region Get attribute value as System.Single

        /// <summary>
        /// Gets an instance of <see cref="Single"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Single"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <see cref="Single"/> representing the attribute value, or the default value
        /// of <see cref="Single"/> if a matching attribute wasn't found.</returns>
        public static float GetAttributeValueAsSingle(this XElement? element, XName name) {
            return GetAttributeValueAsSingle(element, name, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Single"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Single"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="value">An instance of <see cref="Single"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsSingle(this XElement? element, XName name, out float value) {
            return GetAttributeValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T? GetAttributeValueAsSingle<T>(this XElement? element, XName name, Func<float, T> callback) {
            return GetAttributeValue(element, name, out float value) ? callback(value) : default;
        }

        #endregion

        #region Get attribute value as System.Double

        /// <summary>
        /// Gets an instance of <see cref="Double"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Double"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <see cref="Double"/> representing the attribute value, or the default value
        /// of <see cref="Double"/> if a matching attribute wasn't found.</returns>
        public static double GetAttributeValueAsDouble(this XElement? element, XName name) {
            return GetAttributeValueAsDouble(element, name, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Double"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Double"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="value">An instance of <see cref="Double"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsDouble(this XElement? element, XName name, out double value) {
            return GetAttributeValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T? GetAttributeValueAsDouble<T>(this XElement? element, XName name, Func<double, T> callback) {
            return GetAttributeValue(element, name, out double value) ? callback(value) : default;
        }

        #endregion

        #region Get attribute value as System.Boolean

        /// <summary>
        /// Gets an instance of <see cref="Boolean"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Boolean"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <see cref="Boolean"/> representing the attribute value, or the default value
        /// of <see cref="Boolean"/> if a matching attribute wasn't found.</returns>
        public static bool GetAttributeValueAsBoolean(this XElement element, XName name) {
            return GetAttributeValueAsBoolean(element, name, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Boolean"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Boolean"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="value">An instance of <see cref="Boolean"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsBoolean(this XElement? element, XName name, out bool value) {

            // Get the attribute from the specified "element"
            XAttribute? attr = GetAttribute(element, name);

            // Parse the value (if "attr" is not "null")
            value = attr != null && StringUtils.ParseBoolean(attr.Value);

            // Returns whether the attribute was found
            return attr != null;

        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute ins't found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T? GetAttributeValueAsBoolean<T>(this XElement? element, XName name, Func<bool, T> callback) {
            return GetAttributeValueAsBoolean(element, name, out bool value) ? callback(value) : default;
        }

        #endregion

        #region Get attribute value as System.Boolean (deprecated due to wrong naming)

#pragma warning disable 1591

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static bool GetAttributeAsBoolean(this XElement? element, XName name) {
            return GetAttributeValueAsBoolean(element, name, x => x);
        }

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static bool GetAttributeAsBoolean(this XElement? element, XName name, out bool value) {
            return GetAttributeValueAsBoolean(element, name, out value);
        }

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static T? GetAttributeAsBoolean<T>(this XElement? element, XName name, Func<bool, T> callback) {
            return GetAttributeValueAsBoolean(element, name, callback);
        }

#pragma warning restore 1591

        #endregion

        #region Get attribute value as System.Enum

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the attribute should match.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value.</returns>
        public static T GetAttributeValueAsEnum<T>(this XElement? element, XName name) where T : struct {
            XAttribute? child = element?.Attribute(name);
            return child == null ? default : EnumUtils.ParseEnum<T>(child.Value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified <paramref name="name"/>. If the attribute value can't be converted, <paramref name="fallback"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the attribute should match.</param>
        /// <param name="fallback">An instance of <typeparamref name="T"/> used as fallback.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value.</returns>
        public static T GetAttributeValueAsEnum<T>(this XElement? element, XName name, T fallback) where T : struct {
            XAttribute? child = element?.Attribute(name);
            return child == null ? fallback : EnumUtils.ParseEnum(child.Value, fallback);
        }

        #endregion

        #region Get attribute value as T

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute isn't found (or doesn't have a value), the
        /// default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>An instance of <typeparamref name="T"/> represnting the attribute value, or the default
        /// value of <typeparamref name="T"/> if not found.</returns>
        public static T? GetAttributeValue<T>(this XElement? element, XName name) {
            XAttribute? attr = GetAttribute(element, name);
            return attr == null ? default : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified <paramref name="name"/>. If a matching attribute isn't found (or doesn't have a value), the
        /// default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="value">The converted value.</param>
        /// <returns><c>true</c> if the attribute was found and has a value, otherwise <c>false</c>.</returns>
        public static bool GetAttributeValue<T>(this XElement? element, XName name, [NotNullWhen(true)] out T? value) {

            // Get the first attribute matching "name"
            XAttribute? attr = GetAttribute(element, name);

            // Fallback to the default value if the attribute wasn't found (or doesn't have a value)
            if (string.IsNullOrWhiteSpace(attr?.Value)) {
                value = default;
                return false;
            }

            // Convert the attribute value to the type of T
            value = (T) Convert.ChangeType(attr!.Value, typeof(T), CultureInfo.InvariantCulture);
            return true;

        }

        /// <summary>
        /// Gets an instance of <typeparamref name="TResult"/> representing the value of the first attribute matching
        /// the specified <paramref name="name"/>. If a matching attribute isn't found (or doesn't have a value), the
        /// default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should initially be converted to.</typeparam>
        /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="TResult"/>.</returns>
        public static TResult? GetAttributeValue<T, TResult>(this XElement? element, XName name, Func<T, TResult?> callback) {
            XAttribute? attr = GetAttribute(element, name);
            return attr == null ? default : callback((T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        #endregion

    }

}
#if I_CAN_HAZ_XPATH

using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        #region Get element value as System.String

        /// <summary>
        /// Gets the element value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <see cref="String"/> representing the element value.</returns>
        public static string GetElementValue(this XElement element, string expression) {
            return GetElementValue(element, expression, default(IXmlNamespaceResolver));
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the element value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValue<T>(this XElement element, string expression, Func<string, T> callback) {
            return GetElementValue(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets the element value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="String"/> representing the element value.</returns>
        public static string GetElementValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XElement attr = element?.GetElement(expression, resolver);
            return attr?.Value ?? "";
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the element value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<string, T> callback) {
            string value = GetElementValue(element, expression, resolver);
            return value == null ? default(T) : callback(value);
        }

        #endregion

        #region Get element value as System.Int32
        
        /// <summary>
        /// Gets an integer value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <see cref="Int32"/> representing the element value.</returns>
        public static int GetElementValueAsInt32(this XElement element, string expression) {
            return GetElementValueAsInt32(element, expression, default(IXmlNamespaceResolver), x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the integer value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsInt32<T>(this XElement element, string expression, Func<int, T> callback) {
            return GetElementValueAsInt32(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets an integer value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Int32"/> representing the element value.</returns>
        public static int GetElementValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsInt32(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets an integer value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Int32"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver, out int value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the integer value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsInt32<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<int, T> callback) {
            return GetElementValue(element, expression, resolver, out int value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Int64
        
        /// <summary>
        /// Gets a long value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <see cref="Int64"/> representing the element value.</returns>
        public static long GetElementValueAsInt64(this XElement element, string expression) {
            return GetElementValueAsInt64(element, expression, default(IXmlNamespaceResolver), x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the long value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsInt64<T>(this XElement element, string expression, Func<long, T> callback) {
            return GetElementValueAsInt64(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets a long value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Int64"/> representing the element value.</returns>
        public static long GetElementValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsInt64(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets a long value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Int64"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver, out long value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the long value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsInt64<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<long, T> callback) {
            return GetElementValue(element, expression, resolver, out long value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Single
        
        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <see cref="Single"/> representing the element value.</returns>
        public static float GetElementValueAsSingle(this XElement element, string expression) {
            return GetElementValueAsSingle(element, expression, default(IXmlNamespaceResolver), x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the float value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsSingle<T>(this XElement element, string expression, Func<float, T> callback) {
            return GetElementValueAsSingle(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Single"/> representing the element value.</returns>
        public static float GetElementValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsSingle(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Single"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver, out float value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the float value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsSingle<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<float, T> callback) {
            return GetElementValue(element, expression, resolver, out float value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Single (alias GetElementValueAsFloat)
        
        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <see cref="Single"/> representing the element value.</returns>
        public static float GetElementValueAsFloat(this XElement element, string expression) {
            return GetElementValueAsSingle(element, expression, default(IXmlNamespaceResolver), x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the float value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsFloat<T>(this XElement element, string expression, Func<float, T> callback) {
            return GetElementValueAsSingle(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Single"/> representing the element value.</returns>
        public static float GetElementValueAsFloat(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsSingle(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Single"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsFloat(this XElement element, string expression, IXmlNamespaceResolver resolver, out float value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the float value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsFloat<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<float, T> callback) {
            return GetElementValue(element, expression, resolver, out float value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Double
        
        /// <summary>
        /// Gets a double value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <see cref="Double"/> representing the element value.</returns>
        public static double GetElementValueAsDouble(this XElement element, string expression) {
            return GetElementValueAsDouble(element, expression, default(IXmlNamespaceResolver), x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the double value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsDouble<T>(this XElement element, string expression, Func<double, T> callback) {
            return GetElementValueAsDouble(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets a double value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Double"/> representing the element value.</returns>
        public static double GetElementValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsDouble(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets a double value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Double"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver, out double value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the double value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsDouble<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<double, T> callback) {
            return GetElementValue(element, expression, resolver, out double value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Boolean
        
        /// <summary>
        /// Gets a boolean value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <see cref="Boolean"/> representing the element value.</returns>
        public static bool GetElementValueAsBoolean(this XElement element, string expression) {
            return GetElementValueAsBoolean(element, expression, default(IXmlNamespaceResolver), x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the boolean value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsBoolean<T>(this XElement element, string expression, Func<bool, T> callback) {
            return GetElementValueAsBoolean(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets a boolean value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Boolean"/> representing the element value.</returns>
        public static bool GetElementValueAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsBoolean(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets a boolean value representing the value of the first element matching the specified XPath
        /// <paramref name="expression"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Boolean"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver, out bool value) {

            // Get the element from the specified "element"
            XElement child = GetElement(element, expression, resolver);

            // Parse the value (if "attr" is not "null")
            value = child != null && StringUtils.ParseBoolean(child.Value);

            // Returns whether the attribute was found
            return child != null;

        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the boolean value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsBoolean<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<bool, T> callback) {
            return GetElementValueAsBoolean(element, expression, resolver, out bool value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Boolean (deprecated due to wrong naming)

        #pragma warning disable 1591
        
        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static bool GetElementAsBoolean(this XElement element, string expression) {
            return GetElementAsBoolean(element, expression, default(IXmlNamespaceResolver), x => x);
        }

        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static T GetElementAsBoolean<T>(this XElement element, string expression, Func<bool, T> callback) {
            return GetElementAsBoolean(element, expression, default(IXmlNamespaceResolver), callback);
        }

        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static bool GetElementAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementAsBoolean(element, expression, resolver, x => x);
        }

        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static bool GetElementAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver, out bool value) {

            // Get the attribute from the specified "element"
            XElement attr = GetElement(element, expression, resolver);

            // Parse the value (if "attr" is not "null")
            value = attr != null && StringUtils.ParseBoolean(attr.Value);

            // Returns whether the attribute was found
            return attr != null;

        }

        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static T GetElementAsBoolean<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<bool, T> callback) {
            return GetElementAsBoolean(element, expression, resolver, out bool value) ? callback(value) : default(T);
        }

        #pragma warning restore 1591

        #endregion

        #region Get element value as System.Enum
        
        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, string expression) where T : struct {
            return GetElementValueAsEnum<T>(element, expression, default(IXmlNamespaceResolver));
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>. If the element value can't be converted,
        /// <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="fallback">An instance of <typeparamref name="T"/> used as fallback.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, string expression, T fallback) where T : struct {
            return GetElementValueAsEnum(element, expression, default(IXmlNamespaceResolver), fallback);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) where T : struct {

            // Get the child element matching "expression"
            XElement child = GetElement(element, expression, resolver);

            // Convert the element value to the type of T
            return child == null ? default(T) : EnumUtils.ParseEnum<T>(child.Value);
        
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>. If the element value can't be converted,
        /// <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="fallback">An instance of <typeparamref name="T"/> used as fallback.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, T fallback) where T : struct {

            // Get the child element matching "expression"
            XElement child = GetElement(element, expression, resolver);

            // Convert the element value to the type of T
            return child == null ? fallback : EnumUtils.ParseEnum(child.Value, fallback);
        
        }

        #endregion

        #region Get element value as T
        
        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>. If a matching element isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetElementValue<T>(this XElement element, string expression) {
            return GetElementValue<T>(element, expression, default(IXmlNamespaceResolver));
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="TResult"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>. If a matching element isn't found (or doesn't have a value),
        /// the default value of <typeparamref name="TResult"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should initially be converted to.</typeparam>
        /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="callback">The callback method used for converting the element value.</param>
        /// <returns>An instance of <typeparamref name="TResult"/> representing the element value.</returns>
        public static TResult GetElementValue<T, TResult>(this XElement element, string expression, Func<T, TResult> callback) {
            return GetElementValue(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>. If a matching element isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetElementValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) {

            // Get the element matching "expression"
            XElement child = GetElement(element, expression, resolver);

            // Fallback to the default value if the element wasn't found (or doesn't have a value)
            if (string.IsNullOrWhiteSpace(child?.Value)) return default(T);

            // Convert the element value to the type of T
            return (T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture);
        
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>. If a matching element isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="value">The converted value.</param>
        /// <returns><c>true</c> if the element was found and has a value, otherwise <c>false</c>.</returns>
        public static bool GetElementValue<T>(this XElement element, string expression, out T value) {

            // Get the element matching "expression"
            XElement child = GetElement(element, expression);

            // Fallback to the default value if the element wasn't found (or doesn't have a value)
            if (string.IsNullOrWhiteSpace(child?.Value)) {
                value = default(T);
                return false;
            }

            // Convert the element value to the type of T
            value = (T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture);
            return true;

        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>. If a matching element isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">The converted value.</param>
        /// <returns><c>true</c> if the element was found and has a value, otherwise <c>false</c>.</returns>
        public static bool GetElementValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, out T value) {

            // Get the element matching "expression"
            XElement child = GetElement(element, expression, resolver);

            // Fallback to the default value if the element wasn't found (or doesn't have a value)
            if (string.IsNullOrWhiteSpace(child?.Value)) {
                value = default(T);
                return false;
            }

            // Convert the element value to the type of T
            value = (T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture);
            return true;
        
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="TResult"/> representing the value of the first element matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should initially be converted to.</typeparam>
        /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the element should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the element value.</param>
        /// <returns>An instance of <typeparamref name="TResult"/> representing the element value.</returns>
        public static TResult GetElementValue<T, TResult>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<T, TResult> callback) {

            // Get the element matching "expression"
            XElement child = GetElement(element, expression, resolver);

            // Fallback to the default value if the element wasn't found (or doesn't have a value)
            if (string.IsNullOrWhiteSpace(child?.Value)) return default(TResult);

            // Convert the element value to the type of T and invoke the callback
            return callback((T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture));

        }

        #endregion

    }

}

#endif
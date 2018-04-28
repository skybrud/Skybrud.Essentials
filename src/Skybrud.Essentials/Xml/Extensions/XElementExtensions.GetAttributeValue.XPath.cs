#if I_CAN_HAZ_XPATH

using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        #region Get attribute value as System.String
        
        /// <summary>
        /// Gets the value of the attribute matching the specified XPath <paramref name="expression"/>, or an empty
        /// string if <paramref name="expression"/> doesn't match any attributes.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>An instance of <see cref="String"/> representing the attribute value, or an empty string if
        /// a matching attribute wasn't found not found.</returns>
        public static string GetAttributeValue(this XElement element, string expression) {
            return GetAttributeValue(element, expression, null);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute wasn't found, an empty string will be returned
        /// instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or an empty string if
        /// a matching attribute wasn't found not found.</returns>
        public static T GetAttributeValue<T>(this XElement element, string expression, Func<string, T> callback) {
            return GetAttributeValue(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified XPath <paramref name="expression"/>, or an empty
        /// string if <paramref name="expression"/> doesn't match any attributes.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="String"/> representing the attribute value, or an empty string if
        /// a matching attribute wasn't found not found.</returns>
        public static string GetAttributeValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XAttribute attr = element == null ? null : element.GetAttribute(expression, resolver);
            return attr == null ? String.Empty : attr.Value;
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute wasn't found, an empty string will be returned
        /// instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or an empty string if
        /// a matching attribute wasn't found not found.</returns>
        public static T GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<string, T> callback) {
            string value = GetAttributeValue(element, expression, resolver);
            return value == null ? default(T) : callback(value);
        }
        
        #endregion

        #region Get attribute value as System.Int32
        
        /// <summary>
        /// Gets an instance of <see cref="Int32"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int32"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <returns>An instance of <see cref="Int32"/> representing the attribute value, or the default value
        /// of <see cref="Int32"/> if a matching attribute wasn't found.</returns>
        public static int GetAttributeValueAsInt32(this XElement element, string expression) {
            return GetAttributeValueAsInt32(element, expression, null, x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsInt32<T>(this XElement element, string expression, Func<int, T> callback) {
            return GetAttributeValueAsInt32(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int32"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int32"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Int32"/> representing the attribute value, or the default value
        /// of <see cref="Int32"/> if a matching attribute wasn't found.</returns>
        public static int GetAttributeValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsInt32(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int32"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int32"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="value">An instance of <see cref="Int32"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsInt32(this XElement element, string expression, out int value) {
            return GetAttributeValue(element, expression, out value);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int32"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int32"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Int32"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver, out int value) {
            return GetAttributeValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsInt32<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<int, T> callback) {
            int value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Int64
        
        /// <summary>
        /// Gets an instance of <see cref="Int64"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int64"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <returns>An instance of <see cref="Int64"/> representing the attribute value, or the default value
        /// of <see cref="Int64"/> if a matching attribute wasn't found.</returns>
        public static long GetAttributeValueAsInt64(this XElement element, string expression) {
            return GetAttributeValueAsInt64(element, expression, null, x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsInt64<T>(this XElement element, string expression, Func<long, T> callback) {
            return GetAttributeValueAsInt64(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int64"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int64"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Int64"/> representing the attribute value, or the default value
        /// of <see cref="Int64"/> if a matching attribute wasn't found.</returns>
        public static long GetAttributeValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsInt64(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int64"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int64"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="value">An instance of <see cref="Int64"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsInt64(this XElement element, string expression, out long value) {
            return GetAttributeValue(element, expression, out value);
        }

        /// <summary>
        /// Gets an instance of <see cref="Int64"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Int64"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Int64"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver, out long value) {
            return GetAttributeValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsInt64<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<long, T> callback) {
            long value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Single
        
        /// <summary>
        /// Gets an instance of <see cref="Single"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Single"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <returns>An instance of <see cref="Single"/> representing the attribute value, or the default value
        /// of <see cref="Single"/> if a matching attribute wasn't found.</returns>
        public static float GetAttributeValueAsSingle(this XElement element, string expression) {
            return GetAttributeValueAsSingle(element, expression, null, x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsSingle<T>(this XElement element, string expression, Func<float, T> callback) {
            return GetAttributeValueAsSingle(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets an instance of <see cref="Single"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Single"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Single"/> representing the attribute value, or the default value
        /// of <see cref="Single"/> if a matching attribute wasn't found.</returns>
        public static float GetAttributeValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsSingle(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Single"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Single"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="value">An instance of <see cref="Single"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsSingle(this XElement element, string expression, out float value) {
            return GetAttributeValue(element, expression, out value);
        }

        /// <summary>
        /// Gets an instance of <see cref="Single"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Single"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Single"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver, out float value) {
            return GetAttributeValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsSingle<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<float, T> callback) {
            float value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Double
        
        /// <summary>
        /// Gets an instance of <see cref="Double"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Double"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <returns>An instance of <see cref="Double"/> representing the attribute value, or the default value
        /// of <see cref="Double"/> if a matching attribute wasn't found.</returns>
        public static double GetAttributeValueAsDouble(this XElement element, string expression) {
            return GetAttributeValueAsDouble(element, expression, null, x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsDouble<T>(this XElement element, string expression, Func<double, T> callback) {
            return GetAttributeValueAsDouble(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets an instance of <see cref="Double"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Double"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Double"/> representing the attribute value, or the default value
        /// of <see cref="Double"/> if a matching attribute wasn't found.</returns>
        public static double GetAttributeValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsDouble(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Double"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Double"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="value">An instance of <see cref="Double"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsDouble(this XElement element, string expression, out double value) {
            return GetAttributeValue(element, expression, out value);
        }

        /// <summary>
        /// Gets an instance of <see cref="Double"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Double"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Double"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver, out double value) {
            return GetAttributeValue(element, expression, resolver, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsDouble<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<double, T> callback) {
            double value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Boolean
        
        /// <summary>
        /// Gets an instance of <see cref="Boolean"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Boolean"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <returns>An instance of <see cref="Boolean"/> representing the attribute value, or the default value
        /// of <see cref="Boolean"/> if a matching attribute wasn't found.</returns>
        public static bool GetAttributeValueAsBoolean(this XElement element, string expression) {
            return GetAttributeValueAsBoolean(element, expression, null, x => x);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsBoolean<T>(this XElement element, string expression, Func<bool, T> callback) {
            return GetAttributeValueAsBoolean(element, expression, default(IXmlNamespaceResolver), callback);
        }

        /// <summary>
        /// Gets an instance of <see cref="Boolean"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Boolean"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <see cref="Boolean"/> representing the attribute value, or the default value
        /// of <see cref="Boolean"/> if a matching attribute wasn't found.</returns>
        public static bool GetAttributeValueAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsBoolean(element, expression, resolver, x => x);
        }

        /// <summary>
        /// Gets an instance of <see cref="Boolean"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Boolean"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="value">An instance of <see cref="Boolean"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsBoolean(this XElement element, string expression, out bool value) {
            return GetAttributeValueAsBoolean(element, expression, default(IXmlNamespaceResolver), out value);
        }

        /// <summary>
        /// Gets an instance of <see cref="Boolean"/> representing the value of the attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute ins't found, the default value of
        /// <see cref="Boolean"/> will be returned instead.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">An instance of <see cref="Boolean"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetAttributeValueAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver, out bool value) {

            // Get the attribute from the specified "element"
            XAttribute attr = GetAttribute(element, expression, resolver);

            // Parse the value (if "attr" is not "null")
            value = attr != null && StringUtils.ParseBoolean(attr.Value);

            // Returns whether the attribute was found
            return attr != null;

        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the attribute matching the specified
        /// XPath <paramref name="expression"/>. If a matching attribute ins't found found, the default value of
        /// <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value, or the default value
        /// of <typeparamref name="T"/> if a matching attribute wasn't found.</returns>
        public static T GetAttributeValueAsBoolean<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<bool, T> callback) {
            bool value;
            return GetAttributeValueAsBoolean(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Boolean (deprecated due to wrong naming)

        #pragma warning disable 1591

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static bool GetAttributeAsBoolean(this XElement element, string expression) {
            return GetAttributeValueAsBoolean(element, expression, null, x => x);
        }

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static T GetAttributeAsBoolean<T>(this XElement element, string expression, Func<bool, T> callback) {
            return GetAttributeValueAsBoolean(element, expression, default(IXmlNamespaceResolver), callback);
        }

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static bool GetAttributeAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsBoolean(element, expression, resolver, x => x);
        }

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static bool GetAttributeAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver, out bool value) {
            return GetAttributeValueAsBoolean(element, expression, resolver, out value);
        }

        [Obsolete("Use the GetAttributeValueAsBoolean method instead.")]
        public static T GetAttributeAsBoolean<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<bool, T> callback) {
            return GetAttributeValueAsBoolean(element, expression, resolver, callback);
        }

        #pragma warning restore 1591

        #endregion

        #region Get attribute value as System.Enum
        
        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value.</returns>
        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression) where T : struct {
            return GetAttributeValueAsEnum<T>(element, expression, null);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>. If the attribute value can't be converted,
        /// <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="fallback">An instance of <typeparamref name="T"/> used as fallback.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value.</returns>
        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression, T fallback) where T : struct {
            return GetAttributeValueAsEnum(element, expression, null, fallback);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value.</returns>
        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) where T : struct {

            // Get the attribute matching "expression"
            XAttribute attr = GetAttribute(element, expression, resolver);

            // Convert the attribute value to the type of T
            return attr == null ? default(T) : EnumUtils.ParseEnum<T>(attr.Value);
        
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>. If the attribute value can't be converted,
        /// <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="fallback">An instance of <typeparamref name="T"/> used as fallback.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the attribute value.</returns>
        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, T fallback) where T : struct {

            // Get the attribute matching "expression"
            XAttribute attr = GetAttribute(element, expression, resolver);

            // Convert the attribute value to the type of T
            return attr == null ? fallback : EnumUtils.ParseEnum(attr.Value, fallback);
        
        }

        #endregion

        #region Get attribute value as T
        
        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetAttributeValue<T>(this XElement element, string expression) {
            return GetAttributeValue<T>(element, expression, default(IXmlNamespaceResolver));
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="TResult"/> representing the value of the first attribute matching
        /// the specified XPath <paramref name="expression"/>. If a matching attribute isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="TResult"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should initially be converted to.</typeparam>
        /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="TResult"/> representing the attribute value.</returns>
        public static TResult GetAttributeValue<T, TResult>(this XElement element, string expression, Func<T, TResult> callback) {
            return GetAttributeValue(element, expression, null, callback);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XAttribute attr = GetAttribute(element, expression, resolver);
            return attr == null ? default(T) : (T)Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>. If a matching attribute isn't found (or doesn't have a
        /// value), the default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="value">The converted value.</param>
        /// <returns><c>true</c> if the attribute was found and has a value, otherwise <c>false</c>.</returns>
        public static bool GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, out T value) {
            XAttribute attr = GetAttribute(element, expression, resolver);
            value = attr == null ? default(T) : (T)Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
            return attr != null;
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="TResult"/> representing the value of the first attribute matching the
        /// specified XPath <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should initially be converted to.</typeparam>
        /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression the attribute should match.</param>
        /// <param name="resolver">An instance of <see cref="IXmlNamespaceResolver"/> for resolving namespace prefixes
        /// in the XPath expression.</param>
        /// <param name="callback">The callback method used for converting the attribute value.</param>
        /// <returns>An instance of <typeparamref name="TResult"/> representing the attribute value.</returns>
        public static TResult GetAttributeValue<T, TResult>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<T, TResult> callback) {
            XAttribute attr = GetAttribute(element, expression, resolver);
            return attr == null ? default(TResult) : callback((T)Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        #endregion

    }

}

#endif
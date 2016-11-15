using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Enums;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        #region Get attribute value as System.String

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>, or <code>null</code> if
        /// <code>name</code> doesn't match any attributes.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns the value of the attribute, or <code>null</code> if not found.</returns>
        public static string GetAttributeValue(this XElement element, XName name) {
            XAttribute child = element == null ? null : element.GetAttribute(name);
            return child == null ? null : child.Value;
        }

        public static T GetAttributeValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XAttribute child = element == null ? null : element.GetAttribute(name);
            return child == null ? default(T) : callback(child.Value);
        }

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>expression</code>, or <code>null</code> if the
        /// expression doesn't match any attributes.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>Returns the value of the attribute, or <code>null</code> if not found.</returns>
        public static string GetAttributeValue(this XElement element, string expression) {
            return GetAttributeValue(element, expression, null);
        }

        public static T GetAttributeValue<T>(this XElement element, string expression, Func<string, T> callback) {
            return GetAttributeValue(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static string GetAttributeValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XAttribute attr = element == null ? null : element.GetAttribute(expression, resolver);
            return attr == null ? null : attr.Value;
        }

        public static T GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<string, T> callback) {
            string value = GetAttributeValue(element, expression, resolver);
            return value == null ? default(T) : callback(value);
        }
        
        #endregion

        #region Get attribute value as System.Int32

        public static int GetAttributeValueAsInt32(this XElement element, XName name) {
            return GetAttributeValueAsInt32(element, name, x => x);
        }

        public static T GetAttributeValueAsInt32<T>(this XElement element, XName name, Func<int, T> callback) {
            int value;
            return GetAttributeValue(element, name, out value) ? callback(value) : default(T);
        }

        public static int GetAttributeValueAsInt32(this XElement element, string expression) {
            return GetAttributeValueAsInt32(element, expression, null, x => x);
        }

        public static T GetAttributeValueAsInt32<T>(this XElement element, string expression, Func<int, T> callback) {
            return GetAttributeValueAsInt32(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static int GetAttributeValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsInt32(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsInt32<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<int, T> callback) {
            int value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Int64

        public static long GetAttributeValueAsInt64(this XElement element, XName name) {
            return GetAttributeValueAsInt64(element, name, x => x);
        }

        public static T GetAttributeValueAsInt64<T>(this XElement element, XName name, Func<long, T> callback) {
            long value;
            return GetAttributeValue(element, name, out value) ? callback(value) : default(T);
        }

        public static long GetAttributeValueAsInt64(this XElement element, string expression) {
            return GetAttributeValueAsInt64(element, expression, null, x => x);
        }

        public static T GetAttributeValueAsInt64<T>(this XElement element, string expression, Func<long, T> callback) {
            return GetAttributeValueAsInt64(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static long GetAttributeValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsInt64(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsInt64<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<long, T> callback) {
            long value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Single

        public static float GetAttributeValueAsSingle(this XElement element, XName name) {
            return GetAttributeValueAsSingle(element, name, x => x);
        }

        public static T GetAttributeValueAsSingle<T>(this XElement element, XName name, Func<float, T> callback) {
            float value;
            return GetAttributeValue(element, name, out value) ? callback(value) : default(T);
        }

        public static float GetAttributeValueAsSingle(this XElement element, string expression) {
            return GetAttributeValueAsSingle(element, expression, null, x => x);
        }

        public static T GetAttributeValueAsSingle<T>(this XElement element, string expression, Func<float, T> callback) {
            return GetAttributeValueAsSingle(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static float GetAttributeValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsSingle(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsSingle<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<float, T> callback) {
            float value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Double

        public static double GetAttributeValueAsDouble(this XElement element, XName name) {
            return GetAttributeValueAsDouble(element, name, x => x);
        }

        public static T GetAttributeValueAsDouble<T>(this XElement element, XName name, Func<double, T> callback) {
            double value;
            return GetAttributeValue(element, name, out value) ? callback(value) : default(T);
        }

        public static double GetAttributeValueAsDouble(this XElement element, string expression) {
            return GetAttributeValueAsDouble(element, expression, null, x => x);
        }

        public static T GetAttributeValueAsDouble<T>(this XElement element, string expression, Func<double, T> callback) {
            return GetAttributeValueAsDouble(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static double GetAttributeValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsDouble(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsDouble<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<double, T> callback) {
            double value;
            return GetAttributeValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get attribute value as System.Boolean

        public static bool GetAttributeAsBoolean(this XElement element, XName name) {
            return GetAttributeAsBoolean(element, name, x => x);
        }

        public static T GetAttributeAsBoolean<T>(this XElement element, XName name, Func<bool, T> callback) {

            // Get the attribute from the specified "element"
            XAttribute attr = element.GetAttribute(name);
            if (attr == null) return default(T);

            // Get the value as a lower case string
            string value = attr.Value.ToLower();

            // Parse the value using the specified callback
            return callback(value == "true" || value == "1" || value == "t");

        }

        public static bool GetAttributeAsBoolean(this XElement element, string expression) {
            return GetAttributeAsBoolean(element, expression, null, x => x);
        }

        public static T GetAttributeAsBoolean<T>(this XElement element, string expression, Func<bool, T> callback) {
            return GetAttributeAsBoolean(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static bool GetAttributeAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeAsBoolean(element, expression, resolver, x => x);
        }

        public static T GetAttributeAsBoolean<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<bool, T> callback) {

            // Get the first attribute matching "expression"
            XAttribute attr = element.GetAttribute(expression, resolver);
            if (attr == null) return default(T);

            // Get the value as a lower case string
            string value = attr.Value.ToLower();

            // Parse the value using the specified callback
            return callback(value == "true" || value == "1" || value == "t");

        }

        #endregion

        #region Get attribute value as System.Enum

        public static T GetAttributeValueAsEnum<T>(this XElement element, XName name) where T : struct {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(T) : EnumHelpers.ParseEnum<T>(child.Value);
        }

        public static T GetAttributeValueAsEnum<T>(this XElement element, XName name, T fallback) where T : struct {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? fallback : EnumHelpers.ParseEnum(child.Value, fallback);
        }

        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression) where T : struct {
            return GetAttributeValueAsEnum<T>(element, expression, null);
        }

        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression, T fallback) where T : struct {
            return GetAttributeValueAsEnum(element, expression, null, fallback);
        }

        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) where T : struct {
            XAttribute attr = GetAttribute(element, expression, resolver);
            return attr == null ? default(T) : EnumHelpers.ParseEnum<T>(attr.Value);
        }

        public static T GetAttributeValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, T fallback) where T : struct {
            XAttribute attr = GetAttribute(element, expression, resolver);
            return attr == null ? fallback : EnumHelpers.ParseEnum(attr.Value, fallback);
        }

        #endregion

        #region Get attribute value as T

        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <returns>Returns an instance of <code>T</code> represnting the attribute value, or the default value of
        /// <code>T</code> if not found.</returns>
        public static T GetAttributeValue<T>(this XElement element, XName name) {
            XAttribute attr = GetAttribute(element, name);
            return attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
        }
        
        public static bool GetAttributeValue<T>(this XElement element, XName name, out T value) {
            XAttribute attr = GetAttribute(element, name);
            value = attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
            return attr != null;
        }
        
        /// <summary>
        /// Gets the value of the attribute matching the specified <code>name</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="element">The instance of <see cref="XElement"/> holding the attribute.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the attribute.</param>
        /// <param name="callback">A callback function for parsing the attribute value.</param>
        /// <returns>Returns the value as parsed by the specified <code>callback</code>.</returns>
        public static TResult GetAttributeValue<T, TResult>(this XElement element, XName name, Func<T, TResult> callback) {
            XAttribute attr = GetAttribute(element, name);
            return attr == null ? default(TResult) : callback((T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        public static T GetAttributeValue<T>(this XElement element, string expression) {
            return GetAttributeValue<T>(element, expression, default(IXmlNamespaceResolver));
        }

        public static TResult GetAttributeValue<T, TResult>(this XElement element, string expression, Func<T, TResult> callback) {
            return GetAttributeValue(element, expression, null, callback);
        }

        public static T GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XAttribute attr = GetAttribute(element, expression, resolver);
            return attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        public static bool GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, out T value) {
            XAttribute attr = GetAttribute(element, expression, resolver);
            value = attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
            return attr != null;
        }

        public static TResult GetAttributeValue<T, TResult>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<T, TResult> callback) {
            XAttribute attr = GetAttribute(element, expression, resolver);
            return attr == null ? default(TResult) : callback((T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        #endregion

    }

}
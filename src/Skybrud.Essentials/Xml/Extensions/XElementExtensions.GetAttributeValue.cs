using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;
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
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? null : child.Value;
        }

        public static T GetAttributeValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XAttribute child = element == null ? null : element.Attribute(name);
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

        public static string GetAttributeValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {

            if (element == null) return null;

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object> result = (IEnumerable<object>) element.XPathEvaluate(expression, resolver);

            // Get the first instance of "XAttribute"
            XAttribute attr = result.OfType<XAttribute>().FirstOrDefault();

            // Get the value or return "null"
            return attr == null ? null : attr.Value;

        }

        public static T GetAttributeValue<T>(this XElement element, string expression, Func<string, T> callback) {
            string value = GetAttributeValue(element, expression);
            return value == null ? default(T) : callback(value);
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

            // Get the attribute from the specified "element"
            XAttribute attr = element == null ? null : element.Attribute(name);

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Int32"
            int value = Int32.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        public static int GetAttributeValueAsInt32(this XElement element, string expression) {
            return GetAttributeValueAsInt32(element, expression, null, x => x);
        }

        public static int GetAttributeValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsInt32(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsInt32<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<int, T> callback) {

            // Returns the default value of "T" if "element" is "null"
            if (element == null) return default(T);

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object> result = (IEnumerable<object>)element.XPathEvaluate(expression, resolver);

            // Get the first instance of "XAttribute"
            XAttribute attr = result.OfType<XAttribute>().FirstOrDefault();

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Int32"
            int value = Int32.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        #endregion

        #region Get attribute value as System.Int64

        public static long GetAttributeValueAsInt64(this XElement element, XName name) {
            return GetAttributeValueAsInt64(element, name, x => x);
        }

        public static T GetAttributeValueAsInt64<T>(this XElement element, XName name, Func<long, T> callback) {

            // Get the attribute from the specified "element"
            XAttribute attr = element == null ? null : element.Attribute(name);

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Int64"
            long value = Int64.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        public static long GetAttributeValueAsInt64(this XElement element, string expression) {
            return GetAttributeValueAsInt64(element, expression, null, x => x);
        }

        public static long GetAttributeValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsInt64(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsInt64<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<long, T> callback) {

            // Returns the default value of "T" if "element" is "null"
            if (element == null) return default(T);

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object> result = (IEnumerable<object>)element.XPathEvaluate(expression, resolver);

            // Get the first instance of "XAttribute"
            XAttribute attr = result.OfType<XAttribute>().FirstOrDefault();

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Int64"
            long value = Int64.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        #endregion

        #region Get attribute value as System.Single

        public static float GetAttributeValueAsSingle(this XElement element, XName name) {
            return GetAttributeValueAsSingle(element, name, x => x);
        }

        public static T GetAttributeValueAsSingle<T>(this XElement element, XName name, Func<float, T> callback) {

            // Get the attribute from the specified "element"
            XAttribute attr = element == null ? null : element.Attribute(name);

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Single"
            float value = Single.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        public static float GetAttributeValueAsSingle(this XElement element, string expression) {
            return GetAttributeValueAsSingle(element, expression, null, x => x);
        }

        public static float GetAttributeValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsSingle(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsSingle<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<float, T> callback) {

            // Returns the default value of "T" if "element" is "null"
            if (element == null) return default(T);

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object> result = (IEnumerable<object>)element.XPathEvaluate(expression, resolver);

            // Get the first instance of "XAttribute"
            XAttribute attr = result.OfType<XAttribute>().FirstOrDefault();

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Single"
            float value = Single.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        #endregion

        #region Get attribute value as System.Double

        public static double GetAttributeValueAsDouble(this XElement element, XName name) {
            return GetAttributeValueAsDouble(element, name, x => x);
        }

        public static T GetAttributeValueAsDouble<T>(this XElement element, XName name, Func<double, T> callback) {

            // Get the attribute from the specified "element"
            XAttribute attr = element == null ? null : element.Attribute(name);

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Double"
            double value = Double.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        public static double GetAttributeValueAsDouble(this XElement element, string expression) {
            return GetAttributeValueAsDouble(element, expression, null, x => x);
        }

        public static double GetAttributeValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeValueAsDouble(element, expression, resolver, x => x);
        }

        public static T GetAttributeValueAsDouble<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<double, T> callback) {

            // Returns the default value of "T" if "element" is "null"
            if (element == null) return default(T);

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object> result = (IEnumerable<object>)element.XPathEvaluate(expression, resolver);

            // Get the first instance of "XAttribute"
            XAttribute attr = result.OfType<XAttribute>().FirstOrDefault();

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Parse the string value into an instance of "Double"
            double value = Double.Parse(attr.Value, CultureInfo.InvariantCulture);

            // Parse the value using the specified callback
            return callback(value);

        }

        #endregion

        #region Get attribute value as System.Boolean

        public static bool GetAttributeAsBoolean(this XElement element, XName name) {
            return GetAttributeAsBoolean(element, name, x => x);
        }

        public static T GetAttributeAsBoolean<T>(this XElement element, XName name, Func<bool, T> callback) {

            // Get the attribute from the specified "element"
            XAttribute attr = element == null ? null : element.Attribute(name);

            // Return the default value of "T" if an attribute isn't found
            if (attr == null) return default(T);

            // Get the value as a lower case string
            string value = attr.Value.ToLower();

            // Parse the value using the specified callback
            return callback(value == "true" || value == "1" || value == "t");

        }

        public static bool GetAttributeAsBoolean(this XElement element, string expression) {
            return GetAttributeAsBoolean(element, expression, null, x => x);
        }

        public static bool GetAttributeAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetAttributeAsBoolean(element, expression, resolver, x => x);
        }

        public static T GetAttributeAsBoolean<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<bool, T> callback) {

            // Returns the default value of "T" if "element" is "null"
            if (element == null) return default(T);

            // Get the matches as a collection of "object" (rather than just "object")
            IEnumerable<object> result = (IEnumerable<object>)element.XPathEvaluate(expression, resolver);

            // Get the first instance of "XAttribute"
            XAttribute attr = result.OfType<XAttribute>().FirstOrDefault();

            // Return the default value of "T" if an attribute isn't found
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
            return GetAttributeValue<string, T>(element, expression, null);
        }

        public static TResult GetAttributeValue<T, TResult>(this XElement element, string expression, Func<T, TResult> callback) {
            return GetAttributeValue(element, expression, null, callback);
        }

        public static T GetAttributeValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XAttribute attr = GetAttribute(element, expression);
            return attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        public static TResult GetAttributeValue<T, TResult>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<T, TResult> callback) {
            XAttribute attr = GetAttribute(element, expression);
            return attr == null ? default(TResult) : callback((T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        #endregion

    }

}
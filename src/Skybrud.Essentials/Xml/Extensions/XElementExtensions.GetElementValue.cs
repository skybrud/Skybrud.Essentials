using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        #region Get element value as System.String

        public static string GetElementValue(this XElement element, XName name) {
            XElement child = element == null ? null : element.GetElement(name);
            return child == null ? null : child.Value;
        }

        public static T GetElementValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XElement child = element == null ? null : element.GetElement(name);
            return child == null ? default(T) : callback(child.Value);
        }

        public static string GetElementValue(this XElement element, string expression) {
            return GetElementValue(element, expression, null);
        }

        public static T GetElementValue<T>(this XElement element, string expression, Func<string, T> callback) {
            return GetElementValue(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static string GetElementValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XElement attr = element == null ? null : element.GetElement(expression, resolver);
            return attr == null ? null : attr.Value;
        }

        public static T GetElementValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<string, T> callback) {
            string value = GetElementValue(element, expression, resolver);
            return value == null ? default(T) : callback(value);
        }

        #endregion

        #region Get element value as System.Int32

        public static int GetElementValueAsInt32(this XElement element, XName name) {
            return GetElementValueAsInt32(element, name, x => x);
        }

        public static bool GetElementValueAsInt32(this XElement element, XName name, out int value) {
            return GetElementValue(element, name, out value);
        }

        public static T GetElementValueAsInt32<T>(this XElement element, XName name, Func<int, T> callback) {
            int value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        public static int GetElementValueAsInt32(this XElement element, string expression) {
            return GetElementValueAsInt32(element, expression, null, x => x);
        }

        public static T GetElementValueAsInt32<T>(this XElement element, string expression, Func<int, T> callback) {
            return GetElementValueAsInt32(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static int GetElementValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsInt32(element, expression, resolver, x => x);
        }

        public static bool GetElementValueAsInt32(this XElement element, string expression, IXmlNamespaceResolver resolver, out int value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        public static T GetElementValueAsInt32<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<int, T> callback) {
            int value;
            return GetElementValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Int64

        public static long GetElementValueAsInt64(this XElement element, XName name) {
            return GetElementValueAsInt64(element, name, x => x);
        }

        public static bool GetElementValueAsInt64(this XElement element, XName name, out long value) {
            return GetElementValue(element, name, out value);
        }

        public static T GetElementValueAsInt64<T>(this XElement element, XName name, Func<long, T> callback) {
            long value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        public static long GetElementValueAsInt64(this XElement element, string expression) {
            return GetElementValueAsInt64(element, expression, null, x => x);
        }

        public static T GetElementValueAsInt64<T>(this XElement element, string expression, Func<long, T> callback) {
            return GetElementValueAsInt64(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static long GetElementValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsInt64(element, expression, resolver, x => x);
        }

        public static bool GetElementValueAsInt64(this XElement element, string expression, IXmlNamespaceResolver resolver, out long value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        public static T GetElementValueAsInt64<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<long, T> callback) {
            long value;
            return GetElementValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Single

        public static float GetElementValueAsSingle(this XElement element, XName name) {
            return GetElementValueAsSingle(element, name, x => x);
        }

        public static bool GetElementValueAsSingle(this XElement element, XName name, out float value) {
            return GetElementValue(element, name, out value);
        }

        public static T GetElementValueAsSingle<T>(this XElement element, XName name, Func<float, T> callback) {
            float value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        public static float GetElementValueAsSingle(this XElement element, string expression) {
            return GetElementValueAsSingle(element, expression, null, x => x);
        }

        public static T GetElementValueAsSingle<T>(this XElement element, string expression, Func<float, T> callback) {
            return GetElementValueAsSingle(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static float GetElementValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsSingle(element, expression, resolver, x => x);
        }

        public static bool GetElementValueAsSingle(this XElement element, string expression, IXmlNamespaceResolver resolver, out float value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        public static T GetElementValueAsSingle<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<float, T> callback) {
            float value;
            return GetElementValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Double

        public static double GetElementValueAsDouble(this XElement element, XName name) {
            return GetElementValueAsDouble(element, name, x => x);
        }

        public static bool GetElementValueAsDouble(this XElement element, XName name, out double value) {
            return GetElementValue(element, name, out value);
        }

        public static T GetElementValueAsDouble<T>(this XElement element, XName name, Func<double, T> callback) {
            double value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        public static double GetElementValueAsDouble(this XElement element, string expression) {
            return GetElementValueAsDouble(element, expression, null, x => x);
        }

        public static T GetElementValueAsDouble<T>(this XElement element, string expression, Func<double, T> callback) {
            return GetElementValueAsDouble(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static double GetElementValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementValueAsDouble(element, expression, resolver, x => x);
        }

        public static bool GetElementValueAsDouble(this XElement element, string expression, IXmlNamespaceResolver resolver, out double value) {
            return GetElementValue(element, expression, resolver, out value);
        }

        public static T GetElementValueAsDouble<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<double, T> callback) {
            double value;
            return GetElementValue(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Boolean

        public static bool GetElementAsBoolean(this XElement element, XName name) {
            return GetElementAsBoolean(element, name, x => x);
        }

        public static bool GetElementAsBoolean(this XElement element, XName name, out bool value) {

            // Get the attribute from the specified "element"
            XElement attr = GetElement(element, name);

            // Parse the value (if "attr" is not "null")
            value = attr == null ? default(bool) : StringHelper.ParseBoolean(attr.Value);

            // Returns whether the attribute was found
            return attr != null;

        }

        public static T GetElementAsBoolean<T>(this XElement element, XName name, Func<bool, T> callback) {
            bool value;
            return GetElementAsBoolean(element, name, out value) ? callback(value) : default(T);
        }

        public static bool GetElementAsBoolean(this XElement element, string expression) {
            return GetElementAsBoolean(element, expression, null, x => x);
        }

        public static T GetElementAsBoolean<T>(this XElement element, string expression, Func<bool, T> callback) {
            return GetElementAsBoolean(element, expression, default(IXmlNamespaceResolver), callback);
        }

        public static bool GetElementAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            return GetElementAsBoolean(element, expression, resolver, x => x);
        }

        public static bool GetElementAsBoolean(this XElement element, string expression, IXmlNamespaceResolver resolver, out bool value) {

            // Get the attribute from the specified "element"
            XElement attr = GetElement(element, expression, resolver);

            // Parse the value (if "attr" is not "null")
            value = attr == null ? default(bool) : StringHelper.ParseBoolean(attr.Value);

            // Returns whether the attribute was found
            return attr != null;

        }

        public static T GetElementAsBoolean<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<bool, T> callback) {
            bool value;
            return GetElementAsBoolean(element, expression, resolver, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Enum

        public static T GetElementValueAsEnum<T>(this XElement element, XName name) where T : struct {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? default(T) : EnumHelper.ParseEnum<T>(child.Value);
        }

        public static T GetElementValueAsEnum<T>(this XElement element, XName name, T fallback) where T : struct {
            XAttribute child = element == null ? null : element.Attribute(name);
            return child == null ? fallback : EnumHelper.ParseEnum(child.Value, fallback);
        }

        public static T GetElementValueAsEnum<T>(this XElement element, string expression) where T : struct {
            return GetElementValueAsEnum<T>(element, expression, null);
        }

        public static T GetElementValueAsEnum<T>(this XElement element, string expression, T fallback) where T : struct {
            return GetElementValueAsEnum(element, expression, null, fallback);
        }

        public static T GetElementValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) where T : struct {
            XElement attr = GetElement(element, expression, resolver);
            return attr == null ? default(T) : EnumHelper.ParseEnum<T>(attr.Value);
        }

        public static T GetElementValueAsEnum<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, T fallback) where T : struct {
            XElement attr = GetElement(element, expression, resolver);
            return attr == null ? fallback : EnumHelper.ParseEnum(attr.Value, fallback);
        }

        #endregion

        #region Get element value as T

        public static T GetElementValue<T>(this XElement element, XName name) {
            XElement attr = GetElement(element, name);
            return attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        public static bool GetElementValue<T>(this XElement element, XName name, out T value) {
            XElement attr = GetElement(element, name);
            value = attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
            return attr != null;
        }

        public static TResult GetElementValue<T, TResult>(this XElement element, XName name, Func<T, TResult> callback) {
            XElement attr = GetElement(element, name);
            return attr == null ? default(TResult) : callback((T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        public static T GetElementValue<T>(this XElement element, string expression) {
            return GetElementValue<T>(element, expression, default(IXmlNamespaceResolver));
        }

        public static TResult GetElementValue<T, TResult>(this XElement element, string expression, Func<T, TResult> callback) {
            return GetElementValue(element, expression, null, callback);
        }

        public static T GetElementValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XElement attr = GetElement(element, expression, resolver);
            return attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        public static bool GetElementValue<T>(this XElement element, string expression, IXmlNamespaceResolver resolver, out T value) {
            XElement attr = GetElement(element, expression, resolver);
            value = attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture);
            return attr != null;
        }

        public static TResult GetElementValue<T, TResult>(this XElement element, string expression, IXmlNamespaceResolver resolver, Func<T, TResult> callback) {
            XElement attr = GetElement(element, expression, resolver);
            return attr == null ? default(TResult) : callback((T) Convert.ChangeType(attr.Value, typeof(T), CultureInfo.InvariantCulture));
        }

        #endregion

    }

}
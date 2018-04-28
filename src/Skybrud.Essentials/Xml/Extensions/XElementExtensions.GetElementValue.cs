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
        /// Gets the value of the element matching the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <see cref="String"/> representing the element value.</returns>
        public static string GetElementValue(this XElement element, XName name) {
            XElement child = element == null ? null : element.GetElement(name);
            return child == null ? "" : child.Value;
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the element value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XElement child = element == null ? null : element.GetElement(name);
            return child == null ? default(T) : callback(child.Value);
        }
        
        #endregion

        #region Get element value as System.Int32

        /// <summary>
        /// Gets an integer value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <see cref="Int32"/> representing the element value.</returns>
        public static int GetElementValueAsInt32(this XElement element, XName name) {
            return GetElementValueAsInt32(element, name, x => x);
        }

        /// <summary>
        /// Gets an integer value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <param name="value">An instance of <see cref="Int32"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsInt32(this XElement element, XName name, out int value) {
            return GetElementValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the integer value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsInt32<T>(this XElement element, XName name, Func<int, T> callback) {
            int value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }
        
        #endregion

        #region Get element value as System.Int64

        /// <summary>
        /// Gets a long value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <see cref="Int64"/> representing the element value.</returns>
        public static long GetElementValueAsInt64(this XElement element, XName name) {
            return GetElementValueAsInt64(element, name, x => x);
        }

        /// <summary>
        /// Gets a long value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <param name="value">An instance of <see cref="Int64"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsInt64(this XElement element, XName name, out long value) {
            return GetElementValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the long value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsInt64<T>(this XElement element, XName name, Func<long, T> callback) {
            long value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Single

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <see cref="Single"/> representing the element value.</returns>
        public static float GetElementValueAsSingle(this XElement element, XName name) {
            return GetElementValueAsSingle(element, name, x => x);
        }

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <param name="value">An instance of <see cref="Single"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsSingle(this XElement element, XName name, out float value) {
            return GetElementValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the float value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsSingle<T>(this XElement element, XName name, Func<float, T> callback) {
            float value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Single (alias GetElementValueAsFloat)

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <see cref="Single"/> representing the element value.</returns>
        public static float GetElementValueAsFloat(this XElement element, XName name) {
            return GetElementValueAsSingle(element, name, x => x);
        }

        /// <summary>
        /// Gets a float value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <param name="value">An instance of <see cref="Single"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsFloat(this XElement element, XName name, out float value) {
            return GetElementValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the float value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsFloat<T>(this XElement element, XName name, Func<float, T> callback) {
            float value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Double

        /// <summary>
        /// Gets a double value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <see cref="Double"/> representing the element value.</returns>
        public static double GetElementValueAsDouble(this XElement element, XName name) {
            return GetElementValueAsDouble(element, name, x => x);
        }

        /// <summary>
        /// Gets a double value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <param name="value">An instance of <see cref="Double"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsDouble(this XElement element, XName name, out double value) {
            return GetElementValue(element, name, out value);
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the double value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsDouble<T>(this XElement element, XName name, Func<double, T> callback) {
            double value;
            return GetElementValue(element, name, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Boolean

        /// <summary>
        /// Gets a boolean value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <see cref="Boolean"/> representing the element value.</returns>
        public static bool GetElementValueAsBoolean(this XElement element, XName name) {
            return GetElementValueAsBoolean(element, name, x => x);
        }

        /// <summary>
        /// Gets a boolean value representing the value of the first element matching the specified
        /// <paramref name="name"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <param name="value">An instance of <see cref="Boolean"/> representing the element value.</param>
        /// <returns><c>true</c> if a matching element was found; otherwise <c>false</c>.</returns>
        public static bool GetElementValueAsBoolean(this XElement element, XName name, out bool value) {

            // Get the element from the specified "element"
            XElement child = GetElement(element, name);

            // Parse the value (if "attr" is not "null")
            value = child != null && StringUtils.ParseBoolean(child.Value);

            // Returns whether the element was found
            return child != null;

        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the boolean value.</param>
        /// <returns>An instance of <see cref="Boolean"/> representing the element value.</returns>
        public static T GetElementValueAsBoolean<T>(this XElement element, XName name, Func<bool, T> callback) {
            bool value;
            return GetElementValueAsBoolean(element, name, out value) ? callback(value) : default(T);
        }

        #endregion

        #region Get element value as System.Boolean (deprecated due to wrong naming)

        #pragma warning disable 1591

        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static bool GetElementAsBoolean(this XElement element, XName name) {
            return GetElementAsBoolean(element, name, x => x);
        }

        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static bool GetElementAsBoolean(this XElement element, XName name, out bool value) {

            // Get the attribute from the specified "element"
            XElement attr = GetElement(element, name);

            // Parse the value (if "attr" is not "null")
            value = attr != null && StringUtils.ParseBoolean(attr.Value);

            // Returns whether the attribute was found
            return attr != null;

        }

        [Obsolete("Use the GetElementValueAsBoolean method instead.")]
        public static T GetElementAsBoolean<T>(this XElement element, XName name, Func<bool, T> callback) {
            bool value;
            return GetElementAsBoolean(element, name, out value) ? callback(value) : default(T);
        }

        #pragma warning restore 1591

        #endregion

        #region Get element value as System.Enum

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, XName name) where T : struct {

            // Get the child element matching "name"
            XElement child = GetElement(element, name);

            // Convert the element value to the type of T
            return child == null ? default(T) : EnumUtils.ParseEnum<T>(child.Value);
        
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>. If the element value can't be converted, <paramref name="fallback"/> is
        /// returned instead.
        /// </summary>
        /// <typeparam name="T">The enum type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> the element should match.</param>
        /// <param name="fallback">An instance of <typeparamref name="T"/> used as fallback.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the element value.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, XName name, T fallback) where T : struct {

            // Get the child element matching "name"
            XElement child = element == null ? null : element.Element(name);

            // Convert the element value to the type of T
            return child == null ? fallback : EnumUtils.ParseEnum(child.Value, fallback);
        
        }
        
        #endregion

        #region Get element value as T

        /// <summary>
        /// Gets the value as an instance of <typeparamref name="T"/> of the first element matching the specified
        /// <paramref name="name"/>. If the element isn't found (or doesn't have a value), <typeparamref name="T"/>
        /// will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetElementValue<T>(this XElement element, XName name) {
            
            // Get the element matching "name"
            XElement child = GetElement(element, name);

            // Fallback to the default value if the element wasn't found (or doesn't have a value)
            if (child == null || String.IsNullOrWhiteSpace(child.Value)) return default(T);

            // Convert the element value to the type of T
            return (T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture);
        
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="T"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>. If a matching element isn't found (or doesn't have a value), the
        /// default value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="value">The converted value.</param>
        /// <returns><c>true</c> if the element was found and has a value, otherwise <c>false</c>.</returns>
        public static bool GetElementValue<T>(this XElement element, XName name, out T value) {

            // Get the element matching "name"
            XElement child = GetElement(element, name);

            // Fallback to the default value if the element wasn't found (or doesn't have a value)
            if (child == null || String.IsNullOrWhiteSpace(child.Value)) {
                value = default(T);
                return false;
            }

            // Convert the element value to the type of T
            value = (T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture);
            return true;
        
        }

        /// <summary>
        /// Gets an instance of <typeparamref name="TResult"/> representing the value of the first element matching the
        /// specified <paramref name="name"/>. If a matching element isn't found (or doesn't have a value), the default
        /// value of <typeparamref name="T"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type the value should initially be converted to.</typeparam>
        /// <typeparam name="TResult">The type the value should be converted to.</typeparam>
        /// <param name="element">The <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> identifying the element.</param>
        /// <param name="callback">The callback method used for converting the element value.</param>
        /// <returns>An instance of <typeparamref name="TResult"/>.</returns>
        public static TResult GetElementValue<T, TResult>(this XElement element, XName name, Func<T, TResult> callback) {

            // Get the element matching "name"
            XElement child = GetElement(element, name);

            // Fallback to the default value if the element wasn't found (or doesn't have a value)
            if (child == null || String.IsNullOrWhiteSpace(child.Value)) return default(TResult);

            // Convert the element value to the type of T and invoke the callback
            return callback((T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture));
        
        }

        #endregion

    }

}
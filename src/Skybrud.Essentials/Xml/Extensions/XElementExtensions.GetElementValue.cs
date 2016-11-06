using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Skybrud.Essentials.Enums;

namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        /// <summary>
        /// Gets the value of the first element matching the specified <code>expression</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">The XPath expression.</param>
        /// <returns>Returns the value of the element, or <code>null</code> if not found.</returns>
        public static string GetElementValue(this XElement element, string expression) {
            XElement child = element == null ? null : element.XPathSelectElement(expression);
            return child == null ? null : child.Value;
        }

        /// <summary>
        /// Gets the value of the first element matching the specified <code>expression</code>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="expression">A <see cref="System.String"/> that contains an XPath expression..</param>
        /// <param name="resolver">An <see cref="IXmlNamespaceResolver"/> for the namespace prefixes in the XPath expression..</param>
        /// <returns>Returns the value of the element, or <code>null</code> if not found.</returns>
        public static string GetElementValue(this XElement element, string expression, IXmlNamespaceResolver resolver) {
            XElement child = element == null ? null : element.XPathSelectElement(expression, resolver);
            return child == null ? null : child.Value;
        }

        /// <summary>
        /// Gets the value of the first child element with the specified <see cref="XName"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> to match.</param>
        /// <returns>Returns the value of the element, or <code>null</code> if not found.</returns>
        public static string GetElementValue(this XElement element, XName name) {
            XElement child = element == null ? null : element.Element(name);
            return child == null ? null : child.Value;
        }

        /// <summary>
        /// Gets the value of the first child element with the specified <see cref="XName"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <returns>Returns an instance of <code>T</code> represnting the attribute value, or the default value of
        /// <code>T</code> if not found.</returns>
        public static T GetElementValue<T>(this XElement element, XName name) {
            XElement child = element == null ? null : element.Element(name);
            return child == null ? default(T) : (T) Convert.ChangeType(child.Value, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the value of the first child element with the specified <see cref="XName"/>.
        /// </summary>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">The <see cref="XName"/> to match.</param>
        /// <param name="callback">A callback function for parsing the element.</param>
        /// <returns>Returns the value as parsed by the specified <code>callback</code>.</returns>
        public static T GetElementValue<T>(this XElement element, XName name, Func<string, T> callback) {
            XElement child = element == null ? null : element.Element(name);
            return callback(child == null || String.IsNullOrWhiteSpace(child.Value) ? null : child.Value);
        }

        public static int GetElementValueAsInt32(this XElement element, XName name) {
            XElement xChild = element == null ? null : element.Element(name);
            return xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(int) : Int32.Parse(xChild.Value);
        }

        public static T GetElementValueAsInt32<T>(this XElement element, XName name, Func<int, T> callback) {
            XElement xChild = element == null ? null : element.Element(name);
            return callback(xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(int) : Int32.Parse(xChild.Value));
        }

        public static long GetElementValueAsInt64(this XElement element, XName name) {
            XElement xChild = element == null ? null : element.Element(name);
            return xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(long) : Int64.Parse(xChild.Value);
        }

        public static T GetElementValueAsInt64<T>(this XElement element, XName name, Func<long, T> callback) {
            XElement xChild = element == null ? null : element.Element(name);
            return callback(xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(long) : Int64.Parse(xChild.Value));
        }

        public static float GetElementValueAsFloat(this XElement element, XName name) {
            XElement xChild = element == null ? null : element.Element(name);
            return xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(float) : Single.Parse(xChild.Value);
        }

        public static T GetElementValueAsFloat<T>(this XElement element, XName name, Func<float, T> callback) {
            XElement xChild = element == null ? null : element.Element(name);
            return callback(xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(float) : Single.Parse(xChild.Value));
        }

        public static double GetElementValueAsDouble(this XElement element, XName name) {
            XElement xChild = element == null ? null : element.Element(name);
            return xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(double) : Double.Parse(xChild.Value);
        }

        public static T GetElementValueAsDouble<T>(this XElement element, XName name, Func<double, T> callback) {
            XElement xChild = element == null ? null : element.Element(name);
            return callback(xChild == null || String.IsNullOrWhiteSpace(xChild.Value) ? default(double) : Double.Parse(xChild.Value));
        }

        /// <summary>
        /// Gets an instance of <code>T</code> based on the value of the element matching the specified
        /// <code>name</code>. An exception of the type <see cref="EnumParseException"/> will be thrown if the
        /// element value doesn't match any of the values of <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <returns>Returns an instance of </returns>
        public static T GetElementValueAsEnum<T>(this XElement element, XName name) where T : struct {
            XElement child = element == null ? null : element.Element(name);
            return EnumHelpers.ParseEnum<T>(child == null ? null : child.Value);
        }

        /// <summary>
        /// Gets an instance of <code>T</code> based on the value of the element matching the specified
        /// <code>name</code>. If the value cant be parsed, <code>fallback</code> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="element">The parent <see cref="XElement"/>.</param>
        /// <param name="name">An instance of <see cref="XName"/> identifying the element.</param>
        /// <param name="fallback">A fallback used if the element value doesn't match any of the values of
        /// <code>T</code>.</param>
        /// <returns>Returns an instance of <code>T</code>.</returns>
        public static T GetElementValueAsEnum<T>(this XElement element, XName name, T fallback) where T : struct {
            XElement child = element == null ? null : element.Element(name);
            return child == null ? fallback : EnumHelpers.ParseEnum(child.Value, fallback);
        }

    }

}
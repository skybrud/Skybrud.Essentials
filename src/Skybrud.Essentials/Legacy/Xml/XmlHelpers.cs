using System;
using System.Xml.Linq;

// ReSharper disable CheckNamespace

namespace Skybrud.Essentials.Xml {

    /// <summary>
    /// Static helper methods for working with XML.
    /// </summary>
    [Obsolete("Use the XmlUtils class instead.")]
    public static class XmlHelpers {

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XElement"/>.
        /// </summary>
        /// <param name="xml">The XML to be parsed.</param>
        /// <returns>An instance of <see cref="XElement"/>.</returns>
        public static XElement ParseXmlElement(string xml) {
            return XmlUtils.ParseXmlElement(xml);
        }

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XElement"/>, which is then converted
        /// into an instance of <typeparamref name="T"/> using the specified <paramref name="callback"/> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="xml">The XML to be parsed.</param>
        /// <param name="callback">The callback function used for converted the parsed <see cref="XElement"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the specified <paramref name="xml"/>.</returns>
        public static T ParseXmlElement<T>(string xml, Func<XElement, T> callback) {
            return XmlUtils.ParseXmlElement(xml, callback);
        }

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XDocument"/>.
        /// </summary>
        /// <param name="xml">The XML to be parsed.</param>
        /// <returns>An instance of <see cref="XDocument"/>.</returns>
        public static XDocument ParseXmlDocument(string xml) {
            return XmlUtils.ParseXmlDocument(xml);
        }

        /// <summary>
        /// Parses the specified <paramref name="xml"/> into an instance of <see cref="XDocument"/>, which is then converted
        /// into an instance of <typeparamref name="T"/> using the specified <paramref name="callback"/> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="xml">The XML to be parsed.</param>
        /// <param name="callback">The callback function used for converted the parsed <see cref="XDocument"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the specified <paramref name="xml"/>.</returns>
        public static T ParseXmlDocument<T>(string xml, Func<XDocument, T> callback) {
            return XmlUtils.ParseXmlDocument(xml, callback);
        }

        /// <summary>
        /// Loads the XML document at specified <paramref name="path"/> and returns it as an instance of
        /// <see cref="XElement"/>.
        /// </summary>
        /// <param name="path">The path to the XML document.</param>
        /// <returns>An instance of <see cref="XElement"/>.</returns>
        public static XElement LoadXmlElement(string path) {
            return XmlUtils.LoadXmlElement(path);
        }

        /// <summary>
        /// Loads the XML document at specified <paramref name="path"/>, which is then converted into an instance of
        /// <typeparamref name="T"/> using the specified <paramref name="callback"/> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="path">The path to the XML document.</param>
        /// <param name="callback">The callback function used for converting the loaded <see cref="XElement"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the XML.</returns>
        public static T LoadXmlElement<T>(string path, Func<XElement, T> callback) {
            return XmlUtils.LoadXmlElement(path, callback);
        }

        /// <summary>
        /// Loads the XML document at specified <paramref name="path"/> and returns it as an instance of
        /// <see cref="XDocument"/>.
        /// </summary>
        /// <param name="path">The path to the XML document.</param>
        /// <returns>An instance of <see cref="XDocument"/>.</returns>
        public static XDocument LoadXmlDocument(string path) {
            return XmlUtils.LoadXmlDocument(path);
        }

        /// <summary>
        /// Loads the XML document at specified <paramref name="path"/>, which is then converted into an instance of
        /// <typeparamref name="T"/> using the specified <paramref name="callback"/> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="path">The path to the XML document.</param>
        /// <param name="callback">The callback function used for converting the loaded <see cref="XDocument"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the XML document.</returns>
        public static T LoadXmlDocument<T>(string path, Func<XDocument, T> callback) {
            return XmlUtils.LoadXmlDocument(path, callback);
        }

    }

}
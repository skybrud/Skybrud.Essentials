using System;
using System.Xml;
using System.Xml.Linq;

namespace Skybrud.Essentials.Xml {
    
    /// <summary>
    /// Static helper methods for working with XML.
    /// </summary>
    public static class XmlUtils {

        /// <summary>
        /// Parses the specified <code>xml</code> into an instance of <see cref="XElement"/>.
        /// </summary>
        /// <param name="xml">The XML to be parsed.</param>
        /// <returns>Returns an instance of <see cref="XElement"/>.</returns>
        public static XElement ParseXmlElement(string xml) {
            return XElement.Parse(xml);
        }

        /// <summary>
        /// Parses the specified <code>xml</code> into an instance of <see cref="XElement"/>, which is then converted
        /// into an instance of <code>T</code> using the specified <code>callback</code> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="xml">The XML to be parsed.</param>
        /// <param name="callback">The callback function used for converted the parsed <see cref="XElement"/>.</param>
        /// <returns>Returns an instance of <code>T</code> representing the specified <code>xml</code>.</returns>
        public static T ParseXmlElement<T>(string xml, Func<XElement, T> callback) {
            return callback(XElement.Parse(xml));
        }

        /// <summary>
        /// Parses the specified <code>xml</code> into an instance of <see cref="XDocument"/>.
        /// </summary>
        /// <param name="xml">The XML to be parsed.</param>
        /// <returns>Returns an instance of <see cref="XDocument"/>.</returns>
        public static XDocument ParseXmlDocument(string xml) {
            return XDocument.Parse(xml);
        }

        /// <summary>
        /// Parses the specified <code>xml</code> into an instance of <see cref="XDocument"/>, which is then converted
        /// into an instance of <code>T</code> using the specified <code>callback</code> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="xml">The XML to be parsed.</param>
        /// <param name="callback">The callback function used for converted the parsed <see cref="XDocument"/>.</param>
        /// <returns>Returns an instance of <code>T</code> representing the specified <code>xml</code>.</returns>
        public static T ParseXmlDocument<T>(string xml, Func<XDocument, T> callback) {
            return callback(XDocument.Parse(xml));
        }

        /// <summary>
        /// Loads the XML document at specified <code>path</code> and returns it as an instance of
        /// <see cref="XElement"/>.
        /// </summary>
        /// <param name="path">The path to the XML document.</param>
        /// <returns>Returns an instance of <see cref="XElement"/>.</returns>
        public static XElement LoadXmlElement(string path) {
            return XElement.Load(path);
        }

        /// <summary>
        /// Loads the XML document at specified <code>path</code>, which is then converted into an instance of
        /// <code>T</code> using the specified <code>callback</code> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="path">The path to the XML document.</param>
        /// <param name="callback">The callback function used for converting the loaded <see cref="XElement"/>.</param>
        /// <returns>Returns an instance of <code>T</code> representing the specified <code>xml</code>.</returns>
        public static T LoadXmlElement<T>(string path, Func<XElement, T> callback) {
            return callback(XElement.Load(path));
        }

        /// <summary>
        /// Loads the XML document at specified <code>path</code> and returns it as an instance of
        /// <see cref="XDocument"/>.
        /// </summary>
        /// <param name="path">The path to the XML document.</param>
        /// <returns>Returns an instance of <see cref="XDocument"/>.</returns>
        public static XDocument LoadXmlDocument(string path) {
            return XDocument.Load(path);
        }

        /// <summary>
        /// Loads the XML document at specified <code>path</code>, which is then converted into an instance of
        /// <code>T</code> using the specified <code>callback</code> function.
        /// </summary>
        /// <typeparam name="T">The type of the instance to be returned.</typeparam>
        /// <param name="path">The path to the XML document.</param>
        /// <param name="callback">The callback function used for converting the loaded <see cref="XDocument"/>.</param>
        /// <returns>Returns an instance of <code>T</code> representing the XML document.</returns>
        public static T LoadXmlDocument<T>(string path, Func<XDocument, T> callback) {
            return callback(XDocument.Load(path));
        }

        /// <summary>
        /// Gets the outer XML of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The XML element.</param>
        /// <returns>A string representing the outer XML of <paramref name="element"/>.</returns>
        /// <see>
        ///     <cref>https://stackoverflow.com/a/1704579</cref>
        /// </see>
        public static string GetOuterXml(XElement element) {
            if (element == null) throw new ArgumentNullException("element");
            XmlReader reader = element.CreateReader();
            reader.MoveToContent();
            return reader.ReadOuterXml();
        }

        /// <summary>
        /// Gets the inner XML of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The XML element.</param>
        /// <returns>A string representing the inner XML of <paramref name="element"/>.</returns>
        /// <see>
        ///     <cref>https://stackoverflow.com/a/1704579</cref>
        /// </see>
        public static string GetInnerXml(XElement element) {
            if (element == null) throw new ArgumentNullException("element");
            XmlReader reader = element.CreateReader();
            reader.MoveToContent();
            return reader.ReadInnerXml();
        }

    }

}
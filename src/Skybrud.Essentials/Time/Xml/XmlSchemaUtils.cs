using System;
using System.Xml;

namespace Skybrud.Essentials.Time.Xml {
    
    /// <summary>
    /// Class with various utility methods for working with XML schema.
    /// </summary>
    /// <see>
    ///     <cref>https://www.w3.org/TR/xmlschema-2/#duration</cref>
    /// </see>
    public class XmlSchemaUtils {

        /// <summary>
        /// Parses the specified <paramref name="xmlSchemaDuration"/> into a corresponding <see cref="TimeSpan"/> instance.
        /// </summary>
        /// <param name="xmlSchemaDuration">The duration using the XML schema format.</param>
        /// <returns>An instance of <see cref="TimeSpan"/>.</returns>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xmlschema-2/#duration</cref>
        /// </see>
        public static TimeSpan ParseDuration(string xmlSchemaDuration) {
            return XmlConvert.ToTimeSpan(xmlSchemaDuration);
        }

        /// <summary>
        /// Converts the specified <paramref name="duration"/> to a corresponding XML schema duration.
        /// </summary>
        /// <param name="duration">The duration to be converted.</param>
        /// <returns>A <see cref="string"/> representing the XML schema duration.</returns>
        /// <see>
        ///     <cref>https://www.w3.org/TR/xmlschema-2/#duration</cref>
        /// </see>
        public static string ToString(TimeSpan duration) {
            return XmlConvert.ToString(duration);
        }

    }

}
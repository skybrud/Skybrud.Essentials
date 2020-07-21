using System;
using JetBrains.Annotations;

namespace Skybrud.Essentials.Common {

    /// <summary>
    /// Class representing an exception for a property that is not set.
    /// </summary>
    public class PropertyNotSetException : Exception {

        #region Properties

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception for the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public PropertyNotSetException([InvokerParameterName] string propertyName) : this(propertyName, "Property cannot be empty.") { }

        /// <summary>
        /// Initializes a new exception for the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="message">The message of the exception.</param>
        public PropertyNotSetException([InvokerParameterName] string propertyName, string message) : base(message) {
            PropertyName = propertyName;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        public override string Message => string.IsNullOrEmpty(PropertyName) ? base.Message : base.Message + Environment.NewLine + "Property name: " + PropertyName;

        #endregion

    }

}
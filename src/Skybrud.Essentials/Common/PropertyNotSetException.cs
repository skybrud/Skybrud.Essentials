using System;

namespace Skybrud.Essentials.Common {

    /// <summary>
    /// Class representing an exception for a property that is not set.
    /// </summary>
    public class PropertyNotSetException : Exception {

        #region Properties

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception for the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public PropertyNotSetException(string propertyName) : this(propertyName, "Property cannot be empty.") { }

        /// <summary>
        /// Initializes a new exception for the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="message">The message of the exception.</param>
        public PropertyNotSetException(string propertyName, string message) : base(message) {
            PropertyName = propertyName;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        public override string Message {
            get { return String.IsNullOrEmpty(PropertyName) ? base.Message : base.Message + Environment.NewLine + "Property name: " + PropertyName; }
        }

        #endregion

    }

}
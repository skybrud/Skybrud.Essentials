using System;

namespace Skybrud.Essentials.Enums {
    
    /// <summary>
    /// Class representing an exception for when a string cant be parsed into an enum value.
    /// </summary>
    public class EnumParseException : Exception {

        #region Properties

        /// <summary>
        /// Gets the <see cref="Type"/> of the enum.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="type"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="type">The type of the enum.</param>
        /// <param name="value">The invalid value.</param>
        public EnumParseException(Type type, string value) {
            Type = type;
            Value = value;
        }
        
        #endregion

        #region Member methods

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        public override string Message => $"Unable to parse enum of type {Type.Name} from value \"{Value}\"";

        #endregion

    }

}
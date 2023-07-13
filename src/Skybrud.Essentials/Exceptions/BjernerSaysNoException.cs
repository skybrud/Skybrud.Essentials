using System;

namespace Skybrud.Essentials.Exceptions {

    /// <summary>
    /// Created as an internal joke.
    /// </summary>
    public class BjernerSaysNoException : Exception {

        /// <summary>
        /// Initializes a new exception with a standard message.
        /// </summary>
        public BjernerSaysNoException() : base("Bjerner says NO!!!") { }

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exeption.</param>
        public BjernerSaysNoException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exeption.</param>
        /// <param name="innerException">An optional inner exception.</param>
        public BjernerSaysNoException(string message, Exception? innerException) : base(message, innerException) { }

    }

}
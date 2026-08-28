using System;

namespace Skybrud.Essentials.Exceptions;

/// <summary>
/// Exception class for situations that call for flipping the table.
/// </summary>
public class TableFlipException : Exception {

    /// <summary>
    /// Initializes a new exception with a standard message.
    /// </summary>
    public TableFlipException() : base("(╯°□°)╯︵ ┻━┻") { }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public TableFlipException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">An optional inner exception.</param>
    public TableFlipException(string message, Exception? innerException) : base(message, innerException) { }

}
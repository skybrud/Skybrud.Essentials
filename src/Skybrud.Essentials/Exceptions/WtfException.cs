using System;

namespace Skybrud.Essentials.Exceptions;

/// <summary>
/// Exception class for those truly WTF moments...
/// </summary>
public class WtfException : Exception {

    /// <summary>
    /// Initializes a new exception with a standard message.
    /// </summary>
    public WtfException() : base("WTF?!?") { }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public WtfException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">An optional inner exception.</param>
    public WtfException(string message, Exception? innerException) : base(message, innerException) { }

}
using System;

namespace Skybrud.Essentials.Exceptions;

/// <summary>
/// Exception class for situations where the answer is simply no.
/// </summary>
public class NopeException : Exception {

    /// <summary>
    /// Initializes a new instance of the <see cref="NopeException"/> class.
    /// </summary>
    public NopeException() : base("Nope!") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NopeException"/> class with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public NopeException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NopeException"/> class with the specified <paramref name="message"/> and
    /// <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public NopeException(string message, Exception? innerException) : base(message, innerException) { }

}
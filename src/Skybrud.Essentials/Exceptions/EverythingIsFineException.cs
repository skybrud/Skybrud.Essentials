using System;

namespace Skybrud.Essentials.Exceptions;

/// <summary>
/// Exception class for situations where everything is obviously fine.
/// </summary>
public class EverythingIsFineException : Exception {

    /// <summary>
    /// Initializes a new instance of the <see cref="EverythingIsFineException"/> class.
    /// </summary>
    public EverythingIsFineException() : base("Everything is fine. 🔥") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EverythingIsFineException"/> class with the specified
    /// <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public EverythingIsFineException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EverythingIsFineException"/> class with the specified
    /// <paramref name="message"/> and <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public EverythingIsFineException(string message, Exception? innerException) : base(message, innerException) { }

}
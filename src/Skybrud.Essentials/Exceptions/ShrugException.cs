using System;

namespace Skybrud.Essentials.Exceptions;

/// <summary>
/// Exception class for situations where the only reasonable response is a shrug.
/// </summary>
public class ShrugException : Exception {

    /// <summary>
    /// Initializes a new instance of the <see cref="ShrugException"/> class.
    /// </summary>
    public ShrugException() : base(@"¯\_(ツ)_/¯") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ShrugException"/> class with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ShrugException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ShrugException"/> class with the specified <paramref name="message"/> and
    /// <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ShrugException(string message, Exception? innerException) : base(message, innerException) { }

}
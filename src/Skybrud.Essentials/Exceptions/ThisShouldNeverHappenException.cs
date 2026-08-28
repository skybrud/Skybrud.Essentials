using System;

namespace Skybrud.Essentials.Exceptions;

/// <summary>
/// Represents an exception that indicates an impossible or unexpected state.
/// </summary>
public class ThisShouldNeverHappenException : Exception {

    /// <summary>
    /// Initializes a new instance of the <see cref="ThisShouldNeverHappenException"/> class with a default message.
    /// </summary>
    public ThisShouldNeverHappenException() : base("This should never happen!") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThisShouldNeverHappenException"/> class with the specified message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public ThisShouldNeverHappenException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThisShouldNeverHappenException"/> class with the specified message and inner exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The inner exception.</param>
    public ThisShouldNeverHappenException(string message, Exception? innerException) : base(message, innerException) { }

}
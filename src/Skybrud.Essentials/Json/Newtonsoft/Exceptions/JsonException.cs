using System;

namespace Skybrud.Essentials.Json.Newtonsoft.Exceptions;

/// <summary>
/// Class representing an exception related to the JSON.net implementation.
/// </summary>
public class JsonException : Exception {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The exception message.</param>
    public JsonException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="message"/> and <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception, if any.</param>
    public JsonException(string message, Exception? innerException) : base(message, innerException) { }

}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#pragma warning disable CS8777

namespace Skybrud.Essentials.Common;

/// <summary>
/// Class representing an exception for a property that is not set.
/// </summary>
public class PropertyNotSetException : Exception {

    #region Properties

    /// <summary>
    /// Gets the name of the property.
    /// </summary>
    public string PropertyName { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new exception for the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="propertyName">The name of the property.</param>
    public PropertyNotSetException([JetBrains.Annotations.InvokerParameterName] string propertyName) : this(propertyName, "Property cannot be empty.") { }

    /// <summary>
    /// Initializes a new exception for the property with the specified <paramref name="propertyName"/>.
    /// </summary>
    /// <param name="propertyName">The name of the property.</param>
    /// <param name="message">The message of the exception.</param>
    public PropertyNotSetException([JetBrains.Annotations.InvokerParameterName] string propertyName, string message) : base(message) {
        PropertyName = propertyName;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets the message of the exception.
    /// </summary>
    public override string Message => string.IsNullOrEmpty(PropertyName) ? base.Message : base.Message + Environment.NewLine + "Property name: " + PropertyName;

    #endregion

    #region Static methods

    /// <summary>
    /// Throws a <see cref="PropertyNotSetException"/> if the specified <paramref name="value"/> is <see langword="null"/>.
    /// </summary>
    /// <param name="value">The property value to validate.</param>
    /// <param name="propertyName">The name of the property. This is automatically supplied by the compiler.</param>
    /// <exception cref="PropertyNotSetException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
    public static void ThrowIfNull([NotNull] object? value, [CallerArgumentExpression(nameof(value))] string? propertyName = null) {
        if (value is null) throw new PropertyNotSetException(propertyName!, "Property cannot be null.");
    }

    /// <summary>
    /// Throws a <see cref="PropertyNotSetException"/> if <paramref name="value"/> is <see langword="null"/> or an empty string.
    /// </summary>
    /// <param name="value">The property value to validate.</param>
    /// <param name="propertyName">The name of the property. This is automatically provided by the compiler when omitted.</param>
    /// <exception cref="PropertyNotSetException">Thrown when <paramref name="value"/> is <see langword="null"/> or empty.</exception>
    public static void ThrowIfNullOrEmpty([NotNull] string? value, [CallerArgumentExpression(nameof(value))] string? propertyName = null) {
        if (string.IsNullOrEmpty(value)) throw new PropertyNotSetException(propertyName!, "Property cannot be null or empty.");
    }

    /// <summary>
    /// Throws a <see cref="PropertyNotSetException"/> if the specified <paramref name="value"/> is <see langword="null"/>, empty, or consists only of whitespace characters.
    /// </summary>
    /// <param name="value">The property value to validate.</param>
    /// <param name="propertyName">The name of the property. This is automatically supplied by the compiler.</param>
    /// <exception cref="PropertyNotSetException">Thrown when <paramref name="value"/> is <see langword="null"/>, empty, or whitespace.</exception>
    public static void ThrowIfNullOrWhiteSpace([NotNull] string? value, [CallerArgumentExpression(nameof(value))] string? propertyName = null) {
        if (string.IsNullOrWhiteSpace(value)) throw new PropertyNotSetException(propertyName!, "Property cannot be null or whitespace.");
    }

    #endregion

}
using System;

namespace Skybrud.Essentials.Configuration.Exceptions;

/// <summary>
/// Represents an error related to a configuration value.
/// </summary>
public abstract class ConfigurationException : Exception {

    /// <summary>
    /// Gets the path of the configuration section or value associated with the error.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="path">The path of the configuration section or value associated with the error.</param>
    protected ConfigurationException(string message, string path) : base(message) {
        Path = path;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="path">The path of the configuration section or value associated with the error.</param>            
    /// <param name="innerException">The exception that caused the current exception.</param>
    protected ConfigurationException(string message, string path, Exception? innerException) : base(message, innerException) {
        Path = path;
    }

    /// <summary>
    /// Creates a new <see cref="MissingConfigurationException"/> for the specified configuration path.
    /// </summary>
    /// <param name="path">The configuration path.</param>
    /// <returns>A new <see cref="MissingConfigurationException"/> instance.</returns>
    public static MissingConfigurationException Missing(string path) {
        return new MissingConfigurationException(path);
    }

    /// <summary>
    /// Creates a new <see cref="InvalidConfigurationException"/> for a value that does not match the specified type.
    /// </summary>
    /// <param name="path">The configuration path.</param>
    /// <param name="type">The expected type.</param>
    /// <returns>A new <see cref="InvalidConfigurationException"/> instance.</returns>
    public static InvalidConfigurationException Invalid(string path, Type type) {
        return new InvalidConfigurationException($"The value of the required configuration section '{path}' does not match a '{type}' value.", path, null);
    }

    /// <summary>
    /// Creates a new <see cref="InvalidConfigurationException"/> for a value that does not match the specified type.
    /// </summary>
    /// <param name="path">The configuration path.</param>
    /// <param name="type">The expected type name.</param>
    /// <returns>A new <see cref="InvalidConfigurationException"/> instance.</returns>
    public static InvalidConfigurationException Invalid(string path, string type) {
        return new InvalidConfigurationException($"The value of the required configuration section '{path}' does not match a '{type}' value.", path, null);
    }

    /// <summary>
    /// Creates a new <see cref="InvalidConfigurationException"/> for a value that does not match the specified type.
    /// </summary>
    /// <param name="path">The configuration path.</param>
    /// <param name="type">The expected type.</param>
    /// <param name="value">The invalid value.</param>
    /// <returns>A new <see cref="InvalidConfigurationException"/> instance.</returns>
    public static InvalidConfigurationException Invalid(string path, Type type, string value) {
        return new InvalidConfigurationException($"The value of the required configuration section '{path}' does not match a '{type}' value: {value}", path, value);
    }

    /// <summary>
    /// Creates a new <see cref="InvalidConfigurationException"/> for a value that does not match the specified type.
    /// </summary>
    /// <param name="path">The configuration path.</param>
    /// <param name="type">The expected type name.</param>
    /// <param name="value">The invalid value.</param>
    /// <returns>A new <see cref="InvalidConfigurationException"/> instance.</returns>
    public static InvalidConfigurationException Invalid(string path, string type, string value) {
        return new InvalidConfigurationException($"The value of the required configuration section '{path}' does not match a '{type}' value: {value}", path, value);
    }

}
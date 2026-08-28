namespace Skybrud.Essentials.Configuration.Exceptions;

/// <summary>
/// Represents an error where a configuration value is invalid.
/// </summary>
public class InvalidConfigurationException : ConfigurationException {

    /// <summary>
    /// Gets the invalid configuration value.
    /// </summary>
    public string? Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class.
    /// </summary>
    /// <param name="path">The path of the invalid configuration value.</param>
    /// <param name="value">The invalid configuration value.</param>
    public InvalidConfigurationException(string path, string value) : base($"Invalid value specified for configuration key '{path}': '{value}'.", path) {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class with an error message, the
    /// configuration path, and the invalid value.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="path">The configuration path where the invalid value was found.</param>
    /// <param name="value">The invalid configuration value.</param>
    public InvalidConfigurationException(string message, string path, string? value) : base(message, path) {
        Value = value;
    }

}
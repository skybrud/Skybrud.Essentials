namespace Skybrud.Essentials.Configuration.Exceptions;

/// <summary>
/// Represents an error where a required configuration section or value is missing.
/// </summary>
public class MissingConfigurationException : ConfigurationException {

    /// <summary>
    /// Initializes a new instance of the <see cref="MissingConfigurationException"/> class.
    /// </summary>
    /// <param name="path">The path of the missing configuration section or value.</param>
    public MissingConfigurationException(string path) : base($"The required configuration key '{path}' is missing or empty.", path) { }

}
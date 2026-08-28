#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Skybrud.Essentials.Configuration.Exceptions;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Essentials.Configuration;

/// <summary>
/// Static class with various extension methods for the <see cref="IConfiguration"/>.
/// </summary>
public static class ConfigurationExtensions {

    #region Boolean

    /// <summary>
    /// Gets the boolean value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The boolean value if successful; otherwise, <see langword="false"/>.</returns>
    public static bool GetBoolean(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToBoolean();
    }

    /// <summary>
    /// Gets the boolean value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The boolean value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static bool GetBoolean(this IConfiguration configuration, string key, bool fallback) {
        return configuration.GetSection(key).Value.ToBoolean(fallback);
    }

    /// <summary>
    /// Gets the boolean value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The boolean value if successful; otherwise, <see langword="null"/>.</returns>
    public static bool? GetBooleanOrNull(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToBooleanOrNull();
    }

    /// <summary>
    /// Returns the boolean value of the section with the specified <paramref name="key"/>. If the section is missing,
    /// or its value doesn't match a boolean value, an exception will be thrown instead.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the section.</param>
    /// <returns>The boolean value of the section.</returns>
    /// <exception cref="Exception">If the section is missing or empty.</exception>
    public static bool GetRequiredBoolean(this IConfiguration configuration, string key) {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return StringUtils.TryParseBoolean(value, out bool result) ? result : throw ConfigurationException.Invalid(configuration.GetFullPath(key), typeof(bool));
    }

    /// <summary>
    /// Attempts to get the boolean value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the boolean value if successful; otherwise, <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IConfiguration configuration, string key, out bool result) {
        return configuration.GetSection(key).Value.TryParseBoolean(out result);
    }

    /// <summary>
    /// Attempts to get the boolean value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the boolean value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this IConfiguration configuration, string key, [NotNullWhen(true)] out bool? result) {
        return configuration.GetSection(key).Value.TryParseBoolean(out result);
    }

    #endregion

    #region Int32

    /// <summary>
    /// Gets the 32-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The 32-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static int GetInt32(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToInt32();
    }

    /// <summary>
    /// Gets the 32-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The 32-bit integer value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static int GetInt32(this IConfiguration configuration, string key, int fallback) {
        return configuration.GetSection(key).Value.ToInt32(fallback);
    }

    /// <summary>
    /// Gets the 32-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The 32-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static int? GetInt32OrNull(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToInt32OrNull();
    }

    /// <summary>
    /// Returns the 32-bit integer value of the section with the specified <paramref name="key"/>. If the section is
    /// missing, or its value doesn't match a <see cref="int"/> value, an exception will be thrown instead.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the section.</param>
    /// <returns>The 32-bit integer value of the section.</returns>
    /// <exception cref="Exception">If the section is missing or empty.</exception>
    public static int GetRequiredInt32(this IConfiguration configuration, string key) {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return StringUtils.TryParseInt32(value, out int result) ? result : throw ConfigurationException.Invalid(configuration.GetFullPath(key), typeof(int));
    }

    /// <summary>
    /// Attempts to get the 32-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the 32-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IConfiguration configuration, string key, out int result) {
        return configuration.GetSection(key).Value.TryParseInt32(out result);
    }

    /// <summary>
    /// Attempts to get the 32-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the 32-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt32(this IConfiguration configuration, string key, [NotNullWhen(true)] out int? result) {
        return configuration.GetSection(key).Value.TryParseInt32(out result);
    }

    #endregion

    #region Int64

    /// <summary>
    /// Gets the 64-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The 64-bit integer value if successful; otherwise, <c>0</c>.</returns>
    public static long GetInt64(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToInt64();
    }

    /// <summary>
    /// Gets the 64-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The 64-bit integer value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static long GetInt64(this IConfiguration configuration, string key, long fallback) {
        return configuration.GetSection(key).Value.ToInt64(fallback);
    }

    /// <summary>
    /// Gets the 64-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The 64-bit integer value if successful; otherwise, <see langword="null"/>.</returns>
    public static long? GetInt64OrNull(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToInt64OrNull();
    }

    /// <summary>
    /// Returns the 64-bit integer value of the section with the specified <paramref name="key"/>. If the section is
    /// missing, or its value doesn't match a <see cref="long"/> value, an exception will be thrown instead.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the section.</param>
    /// <returns>The 64-bit integer value of the section.</returns>
    /// <exception cref="Exception">If the section is missing or empty.</exception>
    public static long GetRequiredInt64(this IConfiguration configuration, string key) {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return StringUtils.TryParseInt64(value, out long result) ? result : throw ConfigurationException.Invalid(configuration.GetFullPath(key), typeof(long));
    }

    /// <summary>
    /// Attempts to get the 64-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the 64-bit integer value if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IConfiguration configuration, string key, out long result) {
        return configuration.GetSection(key).Value.TryParseInt64(out result);
    }

    /// <summary>
    /// Attempts to get the 64-bit integer value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the 64-bit integer value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetInt64(this IConfiguration configuration, string key, [NotNullWhen(true)] out long? result) {
        return configuration.GetSection(key).Value.TryParseInt64(out result);
    }

    #endregion

    #region String

    /// <summary>
    /// Gets the string value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>A string value if successful; otherwise, <see langword="null"/>.</returns>
    public static string? GetString(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.NullIfWhiteSpace();
    }

    /// <summary>
    /// Returns the string value of the section with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the section.</param>
    /// <returns>The string value of the section.</returns>
    /// <exception cref="Exception">If the section is missing or empty.</exception>
    public static string GetRequiredString(this IConfiguration configuration, string key) {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return value;
    }

    /// <summary>
    /// Attempts to get the string value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetString(this IConfiguration configuration, string key, [NotNullWhen(true)] out string? result) {
        result = configuration.GetSection(key).Value.NullIfWhiteSpace();
        return result is not null;
    }

    #endregion

    #region Float

    /// <summary>
    /// Gets the single-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The single-precision floating point number if successful; otherwise, <c>0</c>.</returns>
    public static float GetFloat(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToFloat();
    }

    /// <summary>
    /// Gets the single-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The single-precision floating point number if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static float GetFloat(this IConfiguration configuration, string key, float fallback) {
        return configuration.GetSection(key).Value.ToFloat(fallback);
    }

    /// <summary>
    /// Gets the single-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The single-precision floating point number if successful; otherwise, <see langword="null"/>.</returns>
    public static float? GetFloatOrNull(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToFloatOrNull();
    }

    /// <summary>
    /// Returns the single-precision floating point number (<see cref="float"/>) value of the section with the specified <paramref name="key"/>. If the section is missing, or its value doesn't match a <see cref="float"/> value, an exception will be thrown instead.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the section.</param>
    /// <returns>The single-precision floating point number value of the section.</returns>
    /// <exception cref="Exception">If the section is missing or empty.</exception>
    public static float GetRequiredFloat(this IConfiguration configuration, string key) {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return StringUtils.TryParseFloat(value, out float result) ? result : throw ConfigurationException.Invalid(configuration.GetFullPath(key), typeof(float));
    }

    /// <summary>
    /// Attempts to get the single-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the single-precision floating point number if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IConfiguration configuration, string key, out float result) {
        return configuration.GetSection(key).Value.TryParseFloat(out result);
    }

    /// <summary>
    /// Attempts to get the single-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the single-precision floating point number if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetFloat(this IConfiguration configuration, string key, [NotNullWhen(true)] out float? result) {
        return configuration.GetSection(key).Value.TryParseFloat(out result);
    }

    #endregion

    #region Double

    /// <summary>
    /// Gets the double-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The double-precision floating point number if successful; otherwise, <c>0</c>.</returns>
    public static double GetDouble(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToDouble();
    }

    /// <summary>
    /// Gets the double-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The double-precision floating point number if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static double GetDouble(this IConfiguration configuration, string key, double fallback) {
        return configuration.GetSection(key).Value.ToDouble(fallback);
    }

    /// <summary>
    /// Gets the double-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The double-precision floating point number if successful; otherwise, <see langword="null"/>.</returns>
    public static double? GetDoubleOrNull(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToDoubleOrNull();
    }

    /// <summary>
    /// Returns the double-precision floating point number (<see cref="double"/>) value of the section with the
    /// specified <paramref name="key"/>. If the section is missing, or its value doesn't match a <see cref="double"/>
    /// value, an exception will be thrown instead.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the section.</param>
    /// <returns>The double-precision floating point number value of the section.</returns>
    /// <exception cref="Exception">If the section is missing or empty.</exception>
    public static double GetRequiredDouble(this IConfiguration configuration, string key) {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return StringUtils.TryParseDouble(value, out double result) ? result : throw ConfigurationException.Invalid(configuration.GetFullPath(key), typeof(double));
    }

    /// <summary>
    /// Attempts to get the double-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the double-precision floating point number if successful; otherwise, <c>0</c>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IConfiguration configuration, string key, out double result) {
        return configuration.GetSection(key).Value.TryParseDouble(out result);
    }

    /// <summary>
    /// Attempts to get the double-precision floating point number with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds the double-precision floating point number if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetDouble(this IConfiguration configuration, string key, [NotNullWhen(true)] out double? result) {
        return configuration.GetSection(key).Value.TryParseDouble(out result);
    }

    #endregion

    #region GUID

    /// <summary>
    /// Gets GUID value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The GUID value if successful; otherwise, <see cref="Guid.Empty"/>.</returns>
    public static Guid GetGuid(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToGuid();
    }

    /// <summary>
    /// Gets GUID value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>The GUID value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static Guid GetGuid(this IConfiguration configuration, string key, Guid fallback) {
        return configuration.GetSection(key).Value.ToGuid(fallback);
    }

    /// <summary>
    /// Gets GUID value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <returns>The GUID value if successful; otherwise, <see langword="null"/>.</returns>
    public static Guid? GetGuidOrNull(this IConfiguration configuration, string key) {
        return configuration.GetSection(key).Value.ToGuidOrNull();
    }

    /// <summary>
    /// Returns the GUID value of the section with the specified <paramref name="key"/>. If the section is missing, or
    /// its value doesn't match a GUID value, an exception will be thrown instead.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the section.</param>
    /// <returns>The GUID value of the section.</returns>
    /// <exception cref="Exception">If the section is missing or empty.</exception>
    public static Guid GetRequiredGuid(this IConfiguration configuration, string key) {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return StringUtils.TryParseGuid(value, out Guid result) ? result : throw ConfigurationException.Invalid(configuration.GetFullPath(key), typeof(Guid));
    }

    /// <summary>
    /// Attempts to get GUID value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds GUID value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IConfiguration configuration, string key, out Guid result) {
        return configuration.GetSection(key).Value.TryParseGuid(out result);
    }

    /// <summary>
    /// Attempts to get GUID value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key.</param>
    /// <param name="result">When this method returns, holds GUID value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetGuid(this IConfiguration configuration, string key, [NotNullWhen(true)] out Guid? result) {
        return configuration.GetSection(key).Value.TryParseGuid(out result);
    }

    #endregion

    #region Enum

    /// <summary>
    /// Returns the <typeparamref name="TEnum"/> value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the configuration section.</param>
    /// <returns>An enum value if successful; otherwise, the default value of <typeparamref name="TEnum"/>.</returns>
    public static TEnum GetEnum<TEnum>(this IConfiguration configuration, string key) where TEnum : struct, Enum {
        return configuration.GetSection(key).Value.ToEnum<TEnum>();
    }

    /// <summary>
    /// Returns the <typeparamref name="TEnum"/> value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the configuration section.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>An enum value if successful; otherwise, <paramref name="fallback"/>.</returns>
    public static TEnum GetEnum<TEnum>(this IConfiguration configuration, string key, TEnum fallback) where TEnum : struct, Enum {
        return configuration.GetSection(key).Value.ToEnum(fallback);
    }

    /// <summary>
    /// Returns the <typeparamref name="TEnum"/> value with the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the configuration section.</param>
    /// <returns>An enum value if successful; otherwise, <see langword="null"/>.</returns>
    public static TEnum? GetEnumOrNull<TEnum>(this IConfiguration configuration, string key) where TEnum : struct, Enum {
        return configuration.GetSection(key).Value.ToEnumOrNull<TEnum>();
    }

    /// <summary>
    /// Returns the <typeparamref name="TEnum"/> value of the section with the specified <paramref name="key"/>. If the section is missing, or its value doesn't match a <typeparamref name="TEnum"/> value, an exception will be thrown instead.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the configuration section.</param>
    /// <returns>The <typeparamref name="TEnum"/> value of the section.</returns>
    /// <exception cref="Exception">If the section is missing, empty or the conversion fails.</exception>
    public static TEnum GetRequiredEnum<TEnum>(this IConfiguration configuration, string key) where TEnum : struct, Enum {
        string? value = configuration.GetSection(key).Value;
        if (string.IsNullOrWhiteSpace(value)) throw ConfigurationException.Missing(configuration.GetFullPath(key));
        return EnumUtils.TryParseEnum(value, out TEnum result) ? result : throw ConfigurationException.Invalid(configuration.GetFullPath(key), typeof(TEnum));
    }

    /// <summary>
    /// Attempts to get the <typeparamref name="TEnum"/> value of the section matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the configuration section.</param>
    /// <param name="result">When this method returns, holds the s<typeparamref name="TEnum"/> value if successful; otherwise, the default value of <typeparamref name="TEnum"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetEnum<TEnum>(this IConfiguration configuration, string key, out TEnum result) where TEnum : struct, Enum {
        return configuration.GetSection(key).Value.TryParseEnum(out result);
    }

    /// <summary>
    /// Attempts to get the <typeparamref name="TEnum"/> value of the section matching the specified <paramref name="key"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="key">The key of the configuration section.</param>
    /// <param name="result">When this method returns, holds the <typeparamref name="TEnum"/> value if successful; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetEnum<TEnum>(this IConfiguration configuration, string key, [NotNullWhen(true)] out TEnum? result) where TEnum : struct, Enum {
        return configuration.GetSection(key).Value.TryParseEnum(out result);
    }

    #endregion

    #region TimeSpan (Duration)

    /// <summary>
    /// Returns the duration specified at the given configuration <paramref name="path"/>, or <see langword="default"/> if no value is specified.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="path">The path of the configuration value.</param>
    /// <returns>
    /// The configured duration, or <see langword="default"/> if no value is specified.
    /// </returns>
    /// <exception cref="InvalidConfigurationException">
    /// Thrown if a value is specified but cannot be parsed as a <see cref="TimeSpan"/>.
    /// </exception>
    public static TimeSpan GetTimeSpan(this IConfiguration configuration, string path) {
        return configuration.GetTimeSpan(path, TimeSpan.Zero);
    }

    /// <summary>
    /// Returns the duration specified at the given configuration <paramref name="path"/>, or the specified <paramref name="fallback"/> if no value is specified.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="path">The path of the configuration value.</param>
    /// <param name="fallback">The duration to return if no value is specified.</param>
    /// <returns>
    /// The configured duration, or <paramref name="fallback"/> if no value is specified.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The configured value may be specified as a number of minutes, a <see cref="TimeSpan"/> value, or an XML Schema duration (ISO 8601 duration).
    /// </para>
    /// <para>
    /// A numeric value is interpreted as a number of minutes. For example, <c>15</c> represents 15 minutes.
    /// A <see cref="TimeSpan"/> value may be specified using a format such as <c>00:15:00</c>, while an ISO 8601 duration
    /// may be specified using a format such as <c>PT15M</c>.
    /// </para>
    /// </remarks>
    /// <exception cref="InvalidConfigurationException"> Thrown if a value is specified but cannot be parsed as a <see cref="TimeSpan"/>.</exception>
    public static TimeSpan GetTimeSpan(this IConfiguration configuration, string path, TimeSpan fallback) {

        // Get the value as a string - return the fallback value if the value is missing
        if (!configuration.TryGetString(path, out string? value)) return fallback;

        // If configured value is a numeric value, we assume it's in minutes
        if (int.TryParse(value, out int minutes)) return TimeSpan.FromMinutes(minutes);

        // Try to parse as TimeSpan
        if (TimeSpan.TryParse(value, out TimeSpan timeSpan)) return timeSpan;

        // Try to parse as "TimeSpan" or XML schema duration (aka ISO 8601 duration)
        if (TimeUtils.TryParseTimeSpan(value, out TimeSpan duration)) return duration;

        // Eventually throw an exception if we can't parse the value
        throw ConfigurationException.Invalid(configuration.GetFullPath(path), typeof(TimeSpan));

    }

    /// <summary>
    /// Gets the required duration specified at the given configuration <paramref name="path"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="path">The path of the configuration value.</param>
    /// <returns>The configured duration.</returns>
    /// <remarks>
    /// <para>
    /// The configured value may be specified as a number of minutes, a <see cref="TimeSpan"/> value, or an XML Schema duration (ISO 8601 duration).
    /// </para>
    /// <para>
    /// A numeric value is interpreted as a number of minutes. For example, <c>15</c> represents 15 minutes.
    /// A <see cref="TimeSpan"/> value may be specified using a format such as <c>00:15:00</c>, while an ISO 8601 duration
    /// may be specified using a format such as <c>PT15M</c>.
    /// </para>
    /// </remarks>
    /// <exception cref="MissingConfigurationException">Thrown if no value is specified at <paramref name="path"/>.</exception>
    /// <exception cref="InvalidConfigurationException">Thrown if a value is specified but cannot be parsed as a duration.</exception>
    public static TimeSpan GetRequiredTimeSpan(this IConfiguration configuration, string path) {

        // Get the value as a string - throw an exception if the value is missing
        if (!configuration.TryGetString(path, out string? value)) throw ConfigurationException.Missing(configuration.GetFullPath(path));

        // If configured value is a numeric value, we assume it's in minutes
        if (int.TryParse(value, out int minutes)) return TimeSpan.FromMinutes(minutes);

        // Try to parse as TimeSpan
        if (TimeSpan.TryParse(value, out TimeSpan timeSpan)) return timeSpan;

        // Try to parse as "TimeSpan" or XML schema duration (aka ISO 8601 duration)
        if (TimeUtils.TryParseTimeSpan(value, out TimeSpan duration)) return duration;

        // Eventually throw an exception if we can't parse the value
        throw ConfigurationException.Invalid(configuration.GetFullPath(path), typeof(TimeSpan));

    }

    /// <summary>
    /// Attempts to get the duration specified at the given configuration <paramref name="path"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="path">The path of the configuration value.</param>
    /// <param name="result">
    /// When this method returns <see langword="true"/>, contains the parsed duration; otherwise <see cref="TimeSpan.Zero"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if a value is specified at <paramref name="path"/> and can be parsed as a duration;
    /// otherwise <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// Numeric values are interpreted as a number of minutes (e.g. <c>5</c> for five minutes). Other values are parsed
    /// first as a <see cref="TimeSpan"/> (e.g. <c>00:05:00</c> for five minutes) and then as an XML Schema duration,
    /// which also supports ISO 8601 durations (e.g. <c>PT5M</c> for five minutes).
    /// </remarks>
    public static bool TryGetTimeSpan(this IConfiguration configuration, string path, out TimeSpan result) {

        result = TimeSpan.Zero;

        // Get the value as a string - return false if the value is missing
        if (!configuration.TryGetString(path, out string? value)) return false;

        // If configured value is a numeric value, we assume it's in minutes
        if (int.TryParse(value, out int minutes)) {
            result = TimeSpan.FromMinutes(minutes);
            return true;
        }

        // Try to parse as "TimeSpan" or XML schema duration (aka ISO 8601 duration)
        if (TimeUtils.TryParseTimeSpan(value, out TimeSpan timeSpan)) {
            result = timeSpan;
            return true;
        }

        // Eventually return false if we can't parse the value
        return false;

    }

    #endregion

    /// <summary>
    /// Returns the full configuration path for the specified <paramref name="configuration"/> and <paramref name="path"/>.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="path">The path relative to <paramref name="configuration"/>.</param>
    /// <returns>The full configuration path.</returns>
    public static string GetFullPath(this IConfiguration configuration, string path) {
        if (configuration is IConfigurationSection section) {
            return ConfigurationPath.Combine(section.Path, path);
        }
        return path;
    }

}

#endif
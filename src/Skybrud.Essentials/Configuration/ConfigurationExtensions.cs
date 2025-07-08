using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
        return StringUtils.TryParseBoolean(value, out bool result) ? result : throw new Exception($"The value of the required configuration section '{key}' does not match a '{typeof(bool)}' value.");
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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
        return StringUtils.TryParseInt32(value, out int result) ? result : throw new Exception($"The value of the required configuration section '{key}' does not match a '{typeof(int)}' value.");
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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
        return StringUtils.TryParseInt64(value, out long result) ? result : throw new Exception($"The value of the required configuration section '{key}' does not match a '{typeof(long)}' value.");
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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
        return StringUtils.TryParseFloat(value, out float result) ? result : throw new Exception($"The value of the required configuration section '{key}' does not match a '{typeof(float)}' value.");
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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
        return StringUtils.TryParseDouble(value, out double result) ? result : throw new Exception($"The value of the required configuration section '{key}' does not match a '{typeof(double)}' value.");
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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
        return StringUtils.TryParseGuid(value, out Guid result) ? result : throw new Exception($"The value of the required configuration section '{key}' does not match a '{typeof(Guid)}' value.");
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
        if (string.IsNullOrWhiteSpace(value)) throw new Exception($"The required configuration section '{key}' is missing or empty.");
        return EnumUtils.TryParseEnum(value, out TEnum result) ? result : throw new Exception($"The value of the required configuration section '{key}' does not match an enum value of '{typeof(TEnum)}' value.");
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

}
using System;
using System.Data;
using System.Globalization;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Data.Extensions;

/// <summary>
/// Provides forgiving, nullable, try-pattern, and required typed accessors for <see cref="DataRow"/> columns.
/// </summary>
/// <remarks>
/// Missing columns, <see cref="DBNull.Value"/>, and invalid conversions are treated as unavailable values.
/// These methods do not suppress errors caused by an invalid <see cref="DataRow"/> state.
/// </remarks>
public static class DataRowExtensions {

    /// <summary>Gets a column value, treating missing columns and database nulls as <see langword="null"/>.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The raw value, or <see langword="null"/> if unavailable.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="row"/> or <paramref name="columnName"/> is <see langword="null"/>.</exception>
    public static object? GetValue(this DataRow row, string columnName) {
        Guard.ThrowIfNull(row);
        Guard.ThrowIfNullOrWhiteSpace(columnName);
        if (!row.Table.Columns.Contains(columnName)) return null;
        object value = row[columnName];
        return value == DBNull.Value ? null : value;
    }

    /// <summary>Attempts to read a non-null raw column value.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the value, or <see langword="null"/> if unavailable.</param>
    /// <returns><see langword="true"/> if a non-null value exists; otherwise <see langword="false"/>.</returns>
    public static bool TryGetValue(this DataRow row, string columnName, out object? value) {
        value = row.GetValue(columnName);
        return value != null;
    }

    #region String

    /// <summary>Gets the string representation of a column, or <see langword="null"/> if unavailable.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The string value, or <see langword="null"/>.</returns>
    public static string? GetString(this DataRow row, string columnName) {
        return row.GetString(columnName, null);
    }

    /// <summary>Gets the string representation of a column, using a fallback if unavailable.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned if the column is missing, null, or cannot be converted.</param>
    /// <returns>The converted string, or <paramref name="fallback"/>.</returns>
    public static string? GetString(this DataRow row, string columnName, string? fallback) {
        return row.TryGetString(columnName, out string? value) ? value : fallback;
    }

    /// <summary>Attempts to get the string representation of a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the string, or <see langword="null"/> if conversion fails.</param>
    /// <returns><see langword="true"/> on success; otherwise <see langword="false"/>.</returns>
    public static bool TryGetString(this DataRow row, string columnName, out string? value) {
        object? raw = row.GetValue(columnName);
        value = raw == null ? null : Convert.ToString(raw, CultureInfo.InvariantCulture);
        return value != null;
    }

    /// <summary>Gets a required string from the specified column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted string, including an empty string if that is the stored value.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static string GetRequiredString(this DataRow row, string columnName) {
        return row.TryGetString(columnName, out string? value) ? value! : ThrowRequired<string>(columnName);
    }

    #endregion

    #region Int16

    /// <summary>Gets the 16-bit signed integer in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static short GetInt16(this DataRow row, string columnName) {
        return row.GetInt16(columnName, 0);
    }

    /// <summary>Gets the 16-bit signed integer in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static short GetInt16(this DataRow row, string columnName, short fallback) {
        return row.TryGetInt16(columnName, out short value) ? value : fallback;
    }

    /// <summary>Gets the nullable 16-bit signed integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static short? GetInt16OrNull(this DataRow row, string columnName) {
        return row.TryGetInt16(columnName, out short value) ? value : null;
    }

    /// <summary>Gets the required 16-bit signed integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted 16-bit signed integer.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static short GetRequiredInt16(this DataRow row, string columnName) {
        return row.TryGetInt16(columnName, out short value) ? value : ThrowRequired<short>(columnName);
    }

    /// <summary>Attempts to read a 16-bit signed integer from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetInt16(this DataRow row, string columnName, out short value) {
        return TryConvert(row.GetValue(columnName), Convert.ToInt16, out value);
    }

    #endregion

    #region Int32

    /// <summary>Gets the 32-bit signed integer in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static int GetInt32(this DataRow row, string columnName) {
        return row.GetInt32(columnName, 0);
    }

    /// <summary>Gets the 32-bit signed integer in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static int GetInt32(this DataRow row, string columnName, int fallback) {
        return row.TryGetInt32(columnName, out int value) ? value : fallback;
    }

    /// <summary>Gets the nullable 32-bit signed integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static int? GetInt32OrNull(this DataRow row, string columnName) {
        return row.TryGetInt32(columnName, out int value) ? value : null;
    }

    /// <summary>Gets the required 32-bit signed integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted 32-bit signed integer.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static int GetRequiredInt32(this DataRow row, string columnName) {
        return row.TryGetInt32(columnName, out int value) ? value : ThrowRequired<int>(columnName);
    }

    /// <summary>Attempts to read a 32-bit signed integer from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetInt32(this DataRow row, string columnName, out int value) {
        return TryConvert(row.GetValue(columnName), Convert.ToInt32, out value);
    }

    #endregion

    #region Int64

    /// <summary>Gets the 64-bit signed integer in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static long GetInt64(this DataRow row, string columnName) {
        return row.GetInt64(columnName, 0);
    }

    /// <summary>Gets the 64-bit signed integer in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static long GetInt64(this DataRow row, string columnName, long fallback) {
        return row.TryGetInt64(columnName, out long value) ? value : fallback;
    }

    /// <summary>Gets the nullable 64-bit signed integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static long? GetInt64OrNull(this DataRow row, string columnName) {
        return row.TryGetInt64(columnName, out long value) ? value : null;
    }

    /// <summary>Gets the required 64-bit signed integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted 64-bit signed integer.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static long GetRequiredInt64(this DataRow row, string columnName) {
        return row.TryGetInt64(columnName, out long value) ? value : ThrowRequired<long>(columnName);
    }

    /// <summary>Attempts to read a 64-bit signed integer from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetInt64(this DataRow row, string columnName, out long value) {
        return TryConvert(row.GetValue(columnName), Convert.ToInt64, out value);
    }

    #endregion

    #region UInt16

    /// <summary>Gets the 16-bit unsigned integer in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static ushort GetUInt16(this DataRow row, string columnName) {
        return row.GetUInt16(columnName, 0);
    }

    /// <summary>Gets the 16-bit unsigned integer in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static ushort GetUInt16(this DataRow row, string columnName, ushort fallback) {
        return row.TryGetUInt16(columnName, out ushort value) ? value : fallback;
    }

    /// <summary>Gets the nullable 16-bit unsigned integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static ushort? GetUInt16OrNull(this DataRow row, string columnName) {
        return row.TryGetUInt16(columnName, out ushort value) ? value : null;
    }

    /// <summary>Gets the required 16-bit unsigned integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted 16-bit unsigned integer.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static ushort GetRequiredUInt16(this DataRow row, string columnName) {
        return row.TryGetUInt16(columnName, out ushort value) ? value : ThrowRequired<ushort>(columnName);
    }

    /// <summary>Attempts to read a 16-bit unsigned integer from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetUInt16(this DataRow row, string columnName, out ushort value) {
        return TryConvert(row.GetValue(columnName), Convert.ToUInt16, out value);
    }

    #endregion

    #region UInt32

    /// <summary>Gets the 32-bit unsigned integer in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static uint GetUInt32(this DataRow row, string columnName) {
        return row.GetUInt32(columnName, 0);
    }

    /// <summary>Gets the 32-bit unsigned integer in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static uint GetUInt32(this DataRow row, string columnName, uint fallback) {
        return row.TryGetUInt32(columnName, out uint value) ? value : fallback;
    }

    /// <summary>Gets the nullable 32-bit unsigned integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static uint? GetUInt32OrNull(this DataRow row, string columnName) {
        return row.TryGetUInt32(columnName, out uint value) ? value : null;
    }

    /// <summary>Gets the required 32-bit unsigned integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted 32-bit unsigned integer.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static uint GetRequiredUInt32(this DataRow row, string columnName) {
        return row.TryGetUInt32(columnName, out uint value) ? value : ThrowRequired<uint>(columnName);
    }

    /// <summary>Attempts to read a 32-bit unsigned integer from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetUInt32(this DataRow row, string columnName, out uint value) {
        return TryConvert(row.GetValue(columnName), Convert.ToUInt32, out value);
    }

    #endregion

    #region UInt64

    /// <summary>Gets the 64-bit unsigned integer in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static ulong GetUInt64(this DataRow row, string columnName) {
        return row.GetUInt64(columnName, 0);
    }

    /// <summary>Gets the 64-bit unsigned integer in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static ulong GetUInt64(this DataRow row, string columnName, ulong fallback) {
        return row.TryGetUInt64(columnName, out ulong value) ? value : fallback;
    }

    /// <summary>Gets the nullable 64-bit unsigned integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static ulong? GetUInt64OrNull(this DataRow row, string columnName) {
        return row.TryGetUInt64(columnName, out ulong value) ? value : null;
    }

    /// <summary>Gets the required 64-bit unsigned integer in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted 64-bit unsigned integer.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static ulong GetRequiredUInt64(this DataRow row, string columnName) {
        return row.TryGetUInt64(columnName, out ulong value) ? value : ThrowRequired<ulong>(columnName);
    }

    /// <summary>Attempts to read a 64-bit unsigned integer from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetUInt64(this DataRow row, string columnName, out ulong value) {
        return TryConvert(row.GetValue(columnName), Convert.ToUInt64, out value);
    }

    #endregion

    #region Float (Single)

    /// <summary>Gets the single-precision floating-point number in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static float GetFloat(this DataRow row, string columnName) {
        return row.GetFloat(columnName, 0);
    }

    /// <summary>Gets the single-precision floating-point number in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static float GetFloat(this DataRow row, string columnName, float fallback) {
        return row.TryGetFloat(columnName, out float value) ? value : fallback;
    }

    /// <summary>Gets the nullable single-precision floating-point number in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static float? GetFloatOrNull(this DataRow row, string columnName) {
        return row.TryGetFloat(columnName, out float value) ? value : null;
    }

    /// <summary>Gets the required single-precision floating-point number in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted single-precision floating-point number.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static float GetRequiredFloat(this DataRow row, string columnName) {
        return row.TryGetFloat(columnName, out float value) ? value : ThrowRequired<float>(columnName);
    }

    /// <summary>Attempts to read a single-precision floating-point number from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetFloat(this DataRow row, string columnName, out float value) {
        return TryConvert(row.GetValue(columnName), Convert.ToSingle, out value);
    }

    #endregion

    #region Double

    /// <summary>Gets the double-precision floating-point number in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static double GetDouble(this DataRow row, string columnName) {
        return row.GetDouble(columnName, 0);
    }

    /// <summary>Gets the double-precision floating-point number in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static double GetDouble(this DataRow row, string columnName, double fallback) {
        return row.TryGetDouble(columnName, out double value) ? value : fallback;
    }

    /// <summary>Gets the nullable double-precision floating-point number in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static double? GetDoubleOrNull(this DataRow row, string columnName) {
        return row.TryGetDouble(columnName, out double value) ? value : null;
    }

    /// <summary>Gets the required double-precision floating-point number in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted double-precision floating-point number.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static double GetRequiredDouble(this DataRow row, string columnName) {
        return row.TryGetDouble(columnName, out double value) ? value : ThrowRequired<double>(columnName);
    }

    /// <summary>Attempts to read a double-precision floating-point number from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetDouble(this DataRow row, string columnName, out double value) {
        return TryConvert(row.GetValue(columnName), Convert.ToDouble, out value);
    }

    #endregion

    #region Decimal

    /// <summary>Gets the decimal number in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>0</c> if conversion fails.</returns>
    public static decimal GetDecimal(this DataRow row, string columnName) {
        return row.GetDecimal(columnName, 0);
    }

    /// <summary>Gets the decimal number in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static decimal GetDecimal(this DataRow row, string columnName, decimal fallback) {
        return row.TryGetDecimal(columnName, out decimal value) ? value : fallback;
    }

    /// <summary>Gets the nullable decimal number in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static decimal? GetDecimalOrNull(this DataRow row, string columnName) {
        return row.TryGetDecimal(columnName, out decimal value) ? value : null;
    }

    /// <summary>Gets the required decimal number in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted decimal number.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static decimal GetRequiredDecimal(this DataRow row, string columnName) {
        return row.TryGetDecimal(columnName, out decimal value) ? value : ThrowRequired<decimal>(columnName);
    }

    /// <summary>Attempts to read a decimal number from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetDecimal(this DataRow row, string columnName, out decimal value) {
        return TryConvert(row.GetValue(columnName), Convert.ToDecimal, out value);
    }

    #endregion

    #region Boolean

    /// <summary>Gets the Boolean in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>false</c> if conversion fails.</returns>
    public static bool GetBoolean(this DataRow row, string columnName) {
        return row.GetBoolean(columnName, false);
    }

    /// <summary>Gets the Boolean in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static bool GetBoolean(this DataRow row, string columnName, bool fallback) {
        return row.TryGetBoolean(columnName, out bool value) ? value : fallback;
    }

    /// <summary>Gets the nullable Boolean in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static bool? GetBooleanOrNull(this DataRow row, string columnName) {
        return row.TryGetBoolean(columnName, out bool value) ? value : null;
    }

    /// <summary>Gets the required Boolean in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted Boolean.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static bool GetRequiredBoolean(this DataRow row, string columnName) {
        return row.TryGetBoolean(columnName, out bool value) ? value : ThrowRequired<bool>(columnName);
    }

    /// <summary>Attempts to read a Boolean from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetBoolean(this DataRow row, string columnName, out bool value) {

        switch (row.GetValue(columnName)) {

            case null:
                value = false;
                return false;

            case bool boolean:
                value = boolean;
                return true;

            case string str:
                return StringUtils.TryParseBoolean(str, out value);

            case IConvertible convertible:
                return StringUtils.TryParseBoolean(Convert.ToString(convertible, CultureInfo.InvariantCulture), out value);

            default:
                value = false;
                return false;

        }

    }

    #endregion

    #region Guid

    /// <summary>Gets the GUID in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>Guid.Empty</c> if conversion fails.</returns>
    public static Guid GetGuid(this DataRow row, string columnName) {
        return row.GetGuid(columnName, Guid.Empty);
    }

    /// <summary>Gets the GUID in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static Guid GetGuid(this DataRow row, string columnName, Guid fallback) {
        return row.TryGetGuid(columnName, out Guid value) ? value : fallback;
    }

    /// <summary>Gets the nullable GUID in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static Guid? GetGuidOrNull(this DataRow row, string columnName) {
        return row.TryGetGuid(columnName, out Guid value) ? value : null;
    }

    /// <summary>Gets the required GUID in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted GUID.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static Guid GetRequiredGuid(this DataRow row, string columnName) {
        return row.TryGetGuid(columnName, out Guid value) ? value : ThrowRequired<Guid>(columnName);
    }

    /// <summary>Attempts to read a GUID from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetGuid(this DataRow row, string columnName, out Guid value) {
        object? raw = row.GetValue(columnName);
        switch (raw) {
            case Guid guid:
                value = guid;
                return true;
            default:
                return Guid.TryParse(raw as string, out value);
        }
    }

    #endregion

    #region DateTime

    /// <summary>Gets the date and time in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>default</c> if conversion fails.</returns>
    public static DateTime GetDateTime(this DataRow row, string columnName) {
        return row.GetDateTime(columnName, default);
    }

    /// <summary>Gets the date and time in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static DateTime GetDateTime(this DataRow row, string columnName, DateTime fallback) {
        return row.TryGetDateTime(columnName, out DateTime value) ? value : fallback;
    }

    /// <summary>Gets the nullable date and time in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static DateTime? GetDateTimeOrNull(this DataRow row, string columnName) {
        return row.TryGetDateTime(columnName, out DateTime value) ? value : null;
    }

    /// <summary>Gets the required date and time in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted date and time.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static DateTime GetRequiredDateTime(this DataRow row, string columnName) {
        return row.TryGetDateTime(columnName, out DateTime value) ? value : ThrowRequired<DateTime>(columnName);
    }

    /// <summary>
    /// Attempts to get the date and time value of the specified column.
    /// </summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">
    /// When this method returns, contains the converted date and time value
    /// if the conversion succeeded; otherwise, <see langword="default"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the column exists, contains a non-null value,
    /// and can be converted to <see cref="DateTime"/>; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public static bool TryGetDateTime(this DataRow row, string columnName, out DateTime value) {
        return TryConvert(row.GetValue(columnName), Convert.ToDateTime, out value);
    }

    #endregion

    #region DateTimeOffset

    /// <summary>Gets the date and time with offset in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>default</c> if conversion fails.</returns>
    public static DateTimeOffset GetDateTimeOffset(this DataRow row, string columnName) {
        return row.GetDateTimeOffset(columnName, default);
    }

    /// <summary>Gets the date and time with offset in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static DateTimeOffset GetDateTimeOffset(this DataRow row, string columnName, DateTimeOffset fallback) {
        return row.TryGetDateTimeOffset(columnName, out DateTimeOffset value) ? value : fallback;
    }

    /// <summary>Gets the nullable date and time with offset in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static DateTimeOffset? GetDateTimeOffsetOrNull(this DataRow row, string columnName) {
        return row.TryGetDateTimeOffset(columnName, out DateTimeOffset value) ? value : null;
    }

    /// <summary>Gets the required date and time with offset in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted date and time with offset.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static DateTimeOffset GetRequiredDateTimeOffset(this DataRow row, string columnName) {
        return row.TryGetDateTimeOffset(columnName, out DateTimeOffset value)
            ? value
            : ThrowRequired<DateTimeOffset>(columnName);
    }

    /// <summary>Attempts to read a date and time with offset from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetDateTimeOffset(this DataRow row, string columnName, out DateTimeOffset value) {
        object? raw = row.GetValue(columnName);
        switch (raw) {
            case DateTimeOffset offset:
                value = offset;
                return true;
            case DateTime dateTime:
                value = new DateTimeOffset(dateTime);
                return true;
            default:
                return DateTimeOffset.TryParse(raw as string, CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
        }
    }

    #endregion

    #region TimeSpan

    /// <summary>Gets the time interval in a column, or the type's default value if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <c>default</c> if conversion fails.</returns>
    public static TimeSpan GetTimeSpan(this DataRow row, string columnName) {
        return row.GetTimeSpan(columnName, TimeSpan.Zero);
    }

    /// <summary>Gets the time interval in a column, using a fallback if unavailable or invalid.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="fallback">The value returned when the column is missing, null, or invalid.</param>
    /// <returns>The converted value, or <paramref name="fallback"/>.</returns>
    public static TimeSpan GetTimeSpan(this DataRow row, string columnName, TimeSpan fallback) {
        return row.TryGetTimeSpan(columnName, out TimeSpan value) ? value : fallback;
    }

    /// <summary>Gets the nullable time interval in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The converted value, or <see langword="null"/> if unavailable or invalid.</returns>
    public static TimeSpan? GetTimeSpanOrNull(this DataRow row, string columnName) {
        return row.TryGetTimeSpan(columnName, out TimeSpan value) ? value : null;
    }

    /// <summary>Gets the required time interval in a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>The converted time interval.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the column is missing, null, or cannot be converted.</exception>
    public static TimeSpan GetRequiredTimeSpan(this DataRow row, string columnName) {
        return row.TryGetTimeSpan(columnName, out TimeSpan value) ? value : ThrowRequired<TimeSpan>(columnName);
    }

    /// <summary>Attempts to read a time interval from a column.</summary>
    /// <param name="row">The row to read.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="value">Receives the converted value on success, or its default value on failure.</param>
    /// <returns><see langword="true"/> if conversion succeeds; otherwise <see langword="false"/>.</returns>
    public static bool TryGetTimeSpan(this DataRow row, string columnName, out TimeSpan value) {
        object? raw = row.GetValue(columnName);
        if (raw is TimeSpan span) {
            value = span;
            return true;
        }
        return TimeSpan.TryParse(raw as string, CultureInfo.InvariantCulture, out value);
    }

    #endregion

    /// <summary>Throws an exception indicating that a required column has no convertible value.</summary>
    /// <typeparam name="T">The expected result type.</typeparam>
    /// <param name="columnName">The name of the required column.</param>
    /// <returns>This method never returns a value.</returns>
    /// <exception cref="InvalidOperationException">Always thrown.</exception>
    private static T ThrowRequired<T>(string columnName) {
        throw new InvalidOperationException($"Column '{columnName}' is required and must contain a valid {typeof(T).Name} value.");
    }

    /// <summary>Attempts a culture-invariant conversion without throwing for expected conversion failures.</summary>
    /// <typeparam name="T">The target type.</typeparam>
    /// <param name="input">The value to convert.</param>
    /// <param name="converter">The conversion function.</param>
    /// <param name="value">Receives the converted value or its default.</param>
    /// <returns><see langword="true"/> on success; otherwise <see langword="false"/>.</returns>
    private static bool TryConvert<T>(object? input, Func<object, IFormatProvider, T> converter, out T value) {
        value = default!;
        if (input == null) return false;
        if (input is T typed) { value = typed; return true; }
        try {
            value = converter(input, CultureInfo.InvariantCulture);
            return true;
        } catch (FormatException) {
            return false;
        } catch (InvalidCastException) {
            return false;
        } catch (OverflowException) {
            return false;
        }
    }

}
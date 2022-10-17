using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Collections.Extensions;
using Skybrud.Essentials.Strings;

// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
// ReSharper disable RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Enums {

    /// <summary>
    /// Utility class with various static helper methods for working with enums.
    /// </summary>
    public static class EnumUtils {

        /// <summary>
        /// Gets an array of all values of the specified enum class <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum class.</typeparam>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetEnumValues<T>() where T : struct {
            return (T[]) Enum.GetValues(typeof(T));
        }

        /// <summary>
        /// Gets an array of all values of the specified enum <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of the enum class.</param>
        /// <returns>An array of <see cref="Enum"/>.</returns>
        public static Enum[] GetEnumValues(Type type) {
            return Enum.GetValues(type).Cast<Enum>().ToArray();
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into the enum of type <typeparamref name="T"/>. If
        /// <paramref name="str"/> cannot be parsed, an exception of type <see cref="EnumParseException"/> will be
        /// thrown instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An enum of type <typeparamref name="T"/> from the specified <paramref name="str"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="str"/> is <c>null</c> (or white space).</exception>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        /// <exception cref="EnumParseException">If <paramref name="str"/> doesn't match any of the values of
        /// <typeparamref name="T"/>.</exception>
        public static T ParseEnum<T>(string? str) where T : struct {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(nameof(str));
            if (TryParseEnum(str, out T value)) return value;
            throw new EnumParseException(typeof(T), str!);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> into an instance of <paramref name="enumType"/>.
        /// </summary>
        /// <param name="str">The string value to be converted.</param>
        /// <param name="enumType"></param>
        /// <returns>An instance of <paramref name="enumType"/>.</returns>
        /// <exception cref="EnumParseException">If <paramref name="enumType"/> didn't match an enum value as specified
        /// in <paramref name="str"/>.</exception>
        public static object ParseEnum(string str, Type enumType) {

            // Throw an exception if "str" isn't specified
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(nameof(str));
            if (enumType is null) throw new ArgumentNullException(nameof(enumType));

            // Convert the input string to camel case and lowercase (morel likely to get a match)
            string enumText = StringUtils.ToCamelCase(str).ToLower();

            // Look through each enum value of "enumType"
            foreach (object value in Enum.GetValues(enumType)) {
                if (StringUtils.ToCamelCase(value.ToString()).ToLower() == enumText) return value;
            }

            // Throw an exception if we didn't find a match
            throw new EnumParseException(enumType, str);

        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into the enum of type <typeparamref name="T"/>. If
        /// <paramref name="str"/> cannot be parsed, the value <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback if the enum could not be parsed.</param>
        /// <returns>An enum of type <typeparamref name="T"/> from the specified <paramref name="str"/>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        public static T ParseEnum<T>(string str, T fallback) where T : struct {
            if (string.IsNullOrWhiteSpace(str)) return fallback;
            return TryParseEnum(str, out T value) ? value : fallback;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value to an enum of type
        /// <typeparamref name="T"/>. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="value">When this method returns, contains an object of type <typeparamref name="T"/> whose
        /// value is represented by value. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        public static bool TryParseEnum<T>(string? str, out T value) where T : struct {

            // Check whether the type of T is an enum
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");

            // Initialize "value"
            value = default;

            // Check whether the specified string is NULL (or white space)
            if (string.IsNullOrWhiteSpace(str)) return false;

            // Convert "str" to camel case and then lowercase
            string modified = StringUtils.ToCamelCase(str + string.Empty).ToLowerInvariant();

            // Parse the enum
            foreach (T v in GetEnumValues<T>()) {
                string ordinal = Convert.ChangeType(v, typeof(int)) + string.Empty;
                string? name = v.ToString()?.ToLowerInvariant();
                if (ordinal != modified && name != modified) continue;
                value = v;
                return true;
            }

            return false;

        }

        /// <summary>
        /// Converts the string representation of the name or numeric value to an enum of type
        /// <typeparamref name="T"/>. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="value">When this method returns, contains an object of type <typeparamref name="T"/> whose
        /// value is represented by value. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        public static bool TryParseEnum<T>(string? str, [NotNullWhen(true)] out T? value) where T : struct {

            // Check whether the type of T is an enum
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");

            // Initialize "value"
            value = null;

            // Check whether the specified string is NULL (or white space)
            if (string.IsNullOrWhiteSpace(str)) return false;

            // Convert "str" to camel case and then lowercase
            string modified = StringUtils.ToCamelCase(str + string.Empty).ToLowerInvariant();

            // Parse the enum
            foreach (T v in GetEnumValues<T>()) {
                string ordinal = Convert.ChangeType(v, typeof(int)) + string.Empty;
                string? name = v.ToString()?.ToLowerInvariant();
                if (ordinal != modified && name != modified) continue;
                value = v;
                return true;
            }

            return false;

        }

        /// <summary>
        /// Converts the string representation of the name or numeric value to an enum of the specified <paramref name="type"/>. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="str">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="type">The type of the enum.</param>
        /// <param name="value">When this method returns, contains a value of type <see cref="Enum"/>. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseEnum(string? str, Type type, out Enum value) {

            // Check whether the specified string is NULL (or white space)
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(nameof(str));

            // Check whether the type of T is an enum
            if (IsEnum(type) == false) throw new ArgumentException("Specified type must be an enum.");

            // Initialize "value"
            value = default!;

            // Check whether the specified string is NULL (or white space)
            if (string.IsNullOrWhiteSpace(str)) return false;

            // Convert "str" to camel case and then lowercase
            string modified = StringUtils.ToCamelCase(str + string.Empty).ToLowerInvariant();

            // Parse the enum
            foreach (Enum v in GetEnumValues(type)) {
                string ordinal = Convert.ChangeType(v, typeof(int)) + string.Empty;
                string name = v.ToString().ToLowerInvariant();
                if (ordinal != modified && name != modified) continue;
                value = v;
                return true;
            }

            return false;

        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> into an array of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">A string value containing one or more enum values.</param>
        /// <returns>An array of <typeparamref name="T"/> with the converted values.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        /// <exception cref="EnumParseException">If one or more values can't be converted.</exception>
        public static T[] ParseEnumArray<T>(string? str) where T : struct {
            if (string.IsNullOrWhiteSpace(str)) return ArrayUtils.Empty<T>();
            return (
                from piece in str!.Split(StringUtils.DefaultSeparators, StringSplitOptions.RemoveEmptyEntries)
                select ParseEnum<T>(piece)
            ).ToArray();
        }


        /// <summary>
        /// Converts the specified <paramref name="str"/> into an array of <paramref name="type"/>.
        /// </summary>
        /// <param name="str">A string value containing one or more enum values.</param>
        /// <param name="type">The enum type.</param>
        /// <returns>An instance of <see cref="Array"/> containing the parsed enum values.</returns>
        public static Array ParseEnumArray(string? str, Type type) {
            return ParseEnumArray(str, type, StringUtils.DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> into an array of <paramref name="type"/>.
        /// </summary>
        /// <param name="str">A string value containing one or more enum values.</param>
        /// <param name="type">The enum type.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An instance of <see cref="Array"/> containing the parsed enum values.</returns>
        public static Array ParseEnumArray(string? str, Type type, char[] separators) {
            // TODO: Return static empty array
            return ParseEnumArray((str ?? string.Empty).Split(separators, StringSplitOptions.RemoveEmptyEntries), type);
        }

        /// <summary>
        /// Converts the specified array of <paramref name="pieces"/> into an array of <paramref name="type"/>.
        /// </summary>
        /// <param name="pieces">Array of enum string representation.</param>
        /// <param name="type">The enum type.</param>
        /// <returns>An instanceo of <see cref="Array"/> containing the parsed enum values.</returns>
        public static Array ParseEnumArray(string[] pieces, Type type) {

            List<Enum> temp = new();

            foreach (string piece in pieces) {
                if (TryParseEnum(piece, type, out Enum value)) {
                    temp.Add(value);
                }
            }

            return temp.Cast(type).ToArray(type);

        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> into an array of <typeparamref name="T"/>. The return value
        /// indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">A string value containing one or more enum values.</param>
        /// <param name="array">The array of <typeparamref name="T"/> with the converted values.</param>
        /// <returns><c>true</c> if the value parameter was converted successfully; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        public static bool TryParseEnumArray<T>(string? str, [NotNullWhen(true)] out T[]? array) where T : struct {

            // An empty string (or white space) is treated as a valid value as it may indicate an empty array
            if (string.IsNullOrWhiteSpace(str)) {
                array = ArrayUtils.Empty<T>();
                return true;
            }

            List<T> temp = new();
            array = null;

            // Iterate over and try to parse the each individual value
            foreach (string piece in str!.Split(StringUtils.DefaultSeparators, StringSplitOptions.RemoveEmptyEntries)) {
                if (!TryParseEnum(piece, out T value)) return false;
                temp.Add(value);
            }

            array = temp.ToArray();
            return true;

        }

        /// <summary>
        /// Returns the minimum value of the enum values <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="a">The first enum value.</param>
        /// <param name="b">The second enum value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the minimum value.</returns>
        public static T Min<T>(T a, T b) where T : struct {
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            return (T) Enum.ToObject(typeof(T), Math.Min(Convert.ToInt32(a), Convert.ToInt32(b)));
        }

        /// <summary>
        /// Returns the minimum value of the specified enum <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="values">The enum values to compare.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the minimum value.</returns>
        public static T Min<T>(params T[] values) where T : struct {
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            if (values == null) throw new ArgumentNullException(nameof(values));
            return (T) Enum.ToObject(typeof(T), values.Min(x => Convert.ToInt32(x)));
        }

        /// <summary>
        /// Returns the minimum value of the specified enum <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="values">The enum values to compare.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the minimum value.</returns>
        public static T Min<T>(IEnumerable<T> values) where T : struct {
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            if (values == null) throw new ArgumentNullException(nameof(values));
            return (T) Enum.ToObject(typeof(T), values.Min(x => Convert.ToInt32(x)));
        }

        /// <summary>
        /// Returns the maximum value of the enum values <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="a">The first enum value.</param>
        /// <param name="b">The second enum value.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the maximum value.</returns>
        public static T Max<T>(T a, T b) where T : struct {
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            return (T) Enum.ToObject(typeof(T), Math.Max(Convert.ToInt32(a), Convert.ToInt32(b)));
        }

        /// <summary>
        /// Returns the maximum value of the specified enum <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="values">The enum values to compare.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the maximum value.</returns>
        public static T Max<T>(params T[] values) where T : struct {
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            if (values == null) throw new ArgumentNullException(nameof(values));
            return (T) Enum.ToObject(typeof(T), values.Max(x => Convert.ToInt32(x)));
        }

        /// <summary>
        /// Returns the maximum value of the specified enum <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="values">The enum values to compare.</param>
        /// <returns>An instance of <typeparamref name="T"/> representing the maximum value.</returns>
        public static T Max<T>(IEnumerable<T> values) where T : struct {
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            if (values == null) throw new ArgumentNullException(nameof(values));
            return (T) Enum.ToObject(typeof(T), values.Max(x => Convert.ToInt32(x)));
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> value to an enum of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="input">The input value to be converted.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T FromInt32<T>(int input) where T : struct {
            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            return (T) Enum.ToObject(typeof(T), input);
        }

        internal static T FromInt32WhereTIsEnum<T>(int input) where T : Enum {

            // This method is internal for now. Ideally the "FromInt32" method above should have a constraint on T as
            // an Enum instead of struct, but changing this may be a breaking change.

            if (IsEnum<T>() == false) throw new ArgumentException("Generic type T must be an enum.");
            return (T) Enum.ToObject(typeof(T), input);

        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> value to a enum of type <paramref name="type"/>.
        /// </summary>
        /// <param name="input">The input value to be converted.</param>
        /// <param name="type">The enum type.</param>
        /// <returns>An instance of <see cref="Enum"/>.</returns>
        public static Enum FromInt32(int input, Type type) {
            if (IsEnum(type) == false) throw new ArgumentException("Specified type must be an enum.");
            return (Enum) Enum.ToObject(type, input);
        }

        /// <summary>
        /// Returns whether <typeparamref name="T"/> is an enum.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <returns><c>true</c> if <typeparamref name="T"/> is an enum; otherwise <c>false</c>.</returns>
        public static bool IsEnum<T>() {
            return IsEnum(typeof(T));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> is an enum.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if <paramref name="type"/> is an enum; otherwise <c>false</c>.</returns>
        public static bool IsEnum(Type type) {
            return type.GetTypeInfo().IsEnum;
        }

        /// <summary>
        /// Returns whether the ordinal value of the specified enum <paramref name="value"/> is between
        /// <paramref name="min"/> and <paramref name="max"/> (both inclusive).
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is between <paramref name="min"/> and
        /// <paramref name="max"/>; otherwise, <c>false</c>.</returns>
        public static bool IsBetween(Enum value, int min, int max) {
            int v = Convert.ToInt32(value);
            return v >= min && v <= max;
        }

        /// <summary>
        /// Returns whether the ordinal value of the specified enum <paramref name="value"/> is between
        /// <paramref name="min"/> and <paramref name="max"/> (both inclusive).
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is between <paramref name="min"/> and
        /// <paramref name="max"/>; otherwise, <c>false</c>.</returns>
        public static bool IsBetween(Enum value, Enum min, Enum max) {
            int v = Convert.ToInt32(value);
            return v >= Convert.ToInt32(min) && v <= Convert.ToInt32(max);
        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Skybrud.Essentials.Strings;

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
        public static T ParseEnum<T>(string str) where T : struct {
            if (TryParseEnum(str, out T value)) return value;
            throw new EnumParseException(typeof(T), str);
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
        public static bool TryParseEnum<T>(string str, out T value) where T : struct {

            // Check whether the specified string is NULL (or white space)
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(nameof(str));

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
                string name = v.ToString().ToLowerInvariant();
                if (ordinal == modified || name == modified) {
                    value = v;
                    return true;
                }
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
        public static T[] ParseEnumArray<T>(string str) where T : struct {
            return (
                from piece in (str ?? string.Empty).Split(new[] { ',', ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                select ParseEnum<T>(piece)
            ).ToArray();
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
        public static bool TryParseEnumArray<T>(string str, out T[] array) where T : struct {

            List<T> temp = new List<T>();
            array = null;

            // Iterate over and try to parse the each individual value
            foreach (string piece in (str ?? string.Empty).Split(new[] {',', ' ', '\r', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries)) {
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
            string name = Enum.GetName(typeof(T), Math.Min(Convert.ToInt32(a), Convert.ToInt32(b)));
            return (T) Enum.Parse(typeof(T), name ?? throw new InvalidOperationException(), true);
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
            string name = Enum.GetName(typeof(T), Math.Max(Convert.ToInt32(a), Convert.ToInt32(b)));
            return (T) Enum.Parse(typeof(T), name ?? throw new InvalidOperationException(), true);
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
            
            #if NET_FRAMEWORK
            return type.IsEnum;
            #endif
            
            #if NET_STANDARD
            return type.GetTypeInfo().IsEnum;
            #endif

        }

    }

}
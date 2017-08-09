using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Parses the specified <paramref name="str"/> into the enum of type <typeparamref name="T"/>. If
        /// <paramref name="str"/> cannot be parsed, an exception of type <see cref="EnumParseException"/> will be
        /// thrown instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An enum of type <typeparamref name="T"/> from the specified <paramref name="str"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="str"/> is <code>null</code> (or white space).</exception>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        /// <exception cref="EnumParseException">If <paramref name="str"/> doesn't match any of the values of
        /// <typeparamref name="T"/>.</exception>
        public static T ParseEnum<T>(string str) where T : struct {
            T value;
            if (TryParseEnum(str, out value)) return value;
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
            if (String.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("str");

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
            T value;
            if (String.IsNullOrWhiteSpace(str)) return fallback;
            return TryParseEnum(str, out value) ? value : fallback;
        }

        /// <summary>
        /// Converts the string representation of the name or numeric value to an enum of type
        /// <typeparamref name="T"/>. The return value indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string representation of the enumeration name or underlying value to convert.</param>
        /// <param name="value">When this method returns, contains an object of type <typeparamref name="T"/> whose
        /// value is represented by value. This parameter is passed uninitialized.</param>
        /// <returns><code>true</code> if the value parameter was converted successfully; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        public static bool TryParseEnum<T>(string str, out T value) where T : struct {

            // Check whether the specified string is NULL (or white space)
            if (String.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("str");

            // Check whether the type of T is an enum
            if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

            // Initialize "value"
            value = default(T);

            // Convert "str" to camel case and then lowercase
            string modified = StringUtils.ToCamelCase(str + "").ToLowerInvariant();

            // Parse the enum
            foreach (T v in GetEnumValues<T>()) {
                string ordinal = Convert.ChangeType(v, TypeCode.Int32) + "";
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
                from piece in (str ?? "").Split(new[] { ',', ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
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
        /// <returns><code>true</code> if the value parameter was converted successfully; otherwise, <code>false</code>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        public static bool TryParseEnumArray<T>(string str, out T[] array) where T : struct {

            List<T> temp = new List<T>();
            array = null;

            // Iterate over and try to parse the each individual value
            foreach (string piece in (str ?? "").Split(new[] {',', ' ', '\r', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries)) {
                T value;
                if (!TryParseEnum(piece, out value)) return false;
                temp.Add(value);
            }

            array = temp.ToArray();
            return true;

        }

    }

}
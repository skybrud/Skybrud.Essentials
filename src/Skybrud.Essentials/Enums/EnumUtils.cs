using System;
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
        /// <returns>Returns an array of <typeparamref name="T"/>.</returns>
        public static T[] GetEnumValues<T>() where T : struct {
            return (T[]) Enum.GetValues(typeof(T));
        }

        /// <summary>
        /// Parses the specified <code>str</code> into the enum of type <typeparamref name="T"/>. If <code>str</code>
        /// cannot be parsed, an exception of type <see cref="EnumParseException"/> will be thrown instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>Returns an enum of type <typeparamref name="T"/> from the specified <code>str</code>.</returns>
        /// <exception cref="ArgumentNullException">If <code>str</code> is <code>null</code> (or white space).</exception>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        /// <exception cref="EnumParseException">If <code>str</code> doesn't match any of the values of
        /// <typeparamref name="T"/>.</exception>
        public static T ParseEnum<T>(string str) where T : struct {
            T value;
            if (TryParseEnum(str, out value)) return value;
            throw new EnumParseException(typeof(T), str);
        }

        /// <summary>
        /// Parses the specified <code>str</code> into the enum of type <typeparamref name="T"/>. If <code>str</code>
        /// cannot be parsed, the value <code>fallback</code> will be returned instead.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback if the enum could not be parsed.</param>
        /// <returns>Returns an enum of type <typeparamref name="T"/> from the specified <code>str</code>.</returns>
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
        /// <returns>Returns <code>true</code> if the value parameter was converted successfully; otherwise,
        /// <code>false</code>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        public static bool TryParseEnum<T>(string str, out T value) where T : struct {

            // Check whether the specified string is NULL (or white space)
            if (String.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("str");

            // Check whether the type of T is an enum
            if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

            // Initialize "value"
            value = default(T);

            // Convert "str" to camel case and then lowercase
            string modified = StringHelper.ToCamelCase(str + "").ToLowerInvariant();

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

    }

}
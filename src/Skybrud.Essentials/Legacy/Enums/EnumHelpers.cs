using System;

// ReSharper disable CheckNamespace

namespace Skybrud.Essentials.Enums {

    /// <summary>
    /// Utility class with various static helper methods for working with enums.
    /// </summary>
    [Obsolete("Use the EnumUtils class instead.")]
    public static class EnumHelpers {

        /// <summary>
        /// Gets an array of all values of the specified enum class <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum class.</typeparam>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        [Obsolete("Use the EnumUtils class instead.")]
        public static T[] GetEnumValues<T>() where T : struct {
            return EnumUtils.GetEnumValues<T>();
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into the enum of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An enum of type <typeparamref name="T"/> from the specified <paramref name="str"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="str"/> is <c>null</c> (or white space).</exception>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        /// <exception cref="EnumParseException">If <paramref name="str"/> doesn't match any of the values of <typeparamref name="T"/>.</exception>
        [Obsolete("Use the EnumUtils class instead.")]
        public static T ParseEnum<T>(string str) where T : struct {
            return EnumUtils.ParseEnum<T>(str);
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into the enum of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback if the enum could not be parsed.</param>
        /// <returns>An enum of type <typeparamref name="T"/> from the specified <paramref name="str"/>.</returns>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not an enum class.</exception>
        [Obsolete("Use the EnumUtils class instead.")]
        public static T ParseEnum<T>(string str, T fallback) where T : struct {
            return EnumUtils.ParseEnum(str, fallback);
        }

    }

}
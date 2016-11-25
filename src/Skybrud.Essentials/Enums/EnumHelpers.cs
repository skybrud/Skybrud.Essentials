using System;

namespace Skybrud.Essentials.Enums {

    /// <summary>
    /// Utility class with various static helper methods for working with enums.
    /// </summary>
    [Obsolete("Use the EnumHelper class instead.")]
    public static class EnumHelpers {

        /// <summary>
        /// Gets an array of all values of the specified enum class <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum class.</typeparam>
        /// <returns>Returns an array of <code>T</code>.</returns>
        [Obsolete("Use the EnumHelper class instead.")]
        public static T[] GetEnumValues<T>() where T : struct {
            return EnumHelper.GetEnumValues<T>();
        }

        /// <summary>
        /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
        /// <exception cref="ArgumentNullException">If <code>str</code> is <code>null</code> (or white space).</exception>
        /// <exception cref="ArgumentException">If <code>T</code> is not an enum class.</exception>
        /// <exception cref="EnumParseException">If <code>str</code> doesn't match any of the values of <code>T</code>.</exception>
        [Obsolete("Use the EnumHelper class instead.")]
        public static T ParseEnum<T>(string str) where T : struct {
            return EnumHelper.ParseEnum<T>(str);
        }

        /// <summary>
        /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback if the enum could not be parsed.</param>
        /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
        /// <exception cref="ArgumentException">If <code>T</code> is not an enum class.</exception>
        [Obsolete("Use the EnumHelper class instead.")]
        public static T ParseEnum<T>(string str, T fallback) where T : struct {
            return EnumHelper.ParseEnum(str, fallback);
        }

    }

}
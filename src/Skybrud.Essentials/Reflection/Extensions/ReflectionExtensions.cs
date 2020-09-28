using System;

namespace Skybrud.Essentials.Reflection.Extensions {
    
    /// <summary>
    /// Extension methods for working with reflection.
    /// </summary>
    public static class ReflectionExtensions  {

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <c>null</c> if no matches.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this Enum value, out T result) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute<T>(value, out result);
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><c>true</c>c> if one or more attributes are found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttributes<T>(this Enum value, out T[] result) where T : Attribute {
            return ReflectionUtils.HasCustomAttributes<T>(value, out result);
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="value">The enum value to get attributes for.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(this Enum value) where T : Attribute {
            return ReflectionUtils.GetCustomAttributes<T>(value);
        }

    }

}
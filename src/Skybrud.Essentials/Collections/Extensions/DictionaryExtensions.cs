using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Collections.Extensions {
    
    /// <summary>
    /// Static class with various dictionary related extension methods.
    /// </summary>
    public static class DictionaryExtensions {

        /// <summary>
        /// Returns the boolean value (<see cref="bool"/>) of the dictionary item with the specified
        /// <paramref name="key"/>. If a matching dictionary doesn't exist or it's value can not be converted to a
        /// <see cref="bool"/> value, <see langword="false"/> is returned instead.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <returns>The <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</returns>
        public static bool GetBoolean(this IDictionary<object, object?>? dictionary, object key) {
            return TryGetBoolean(dictionary, key, out bool value) ? value : default;
        }

        /// <summary>
        /// Returns the boolean value (<see cref="bool"/>) of the dictionary item with the specified
        /// <paramref name="key"/>. If a matching dictionary doesn't exist or it's value can not be converted to a
        /// <see cref="bool"/> value, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <returns>The <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</returns>
        public static bool? GetBooleanOrNull(this IDictionary<object, object?>? dictionary, object key) {
            return TryGetBoolean(dictionary, key, out bool? value) ? value : default;
        }

        /// <summary>
        /// Returns the 32-bit integer value of the dictionary item with the specified <paramref name="key"/>. If a
        /// matching dictionary doesn't exist or it's value can not be converted to a <see cref="int"/> value, <c>0</c>
        /// is returned instead.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <returns>The <see cref="int"/> value if successful; otherwise, <c>0</c>.</returns>
        public static int GetInt32(this IDictionary<object, object?>? dictionary, object key) {
            return TryGetInt32(dictionary, key, out int result) ? result : 0;
        }

        /// <summary>
        /// Returns the 32-bit integer value of the dictionary item with the specified <paramref name="key"/>. If a
        /// matching dictionary doesn't exist or it's value can not be converted to a <see cref="int"/> value,
        /// <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <returns>The <see cref="int"/> value if successful; otherwise, <see langword="null"/>.</returns>
        public static int? GetInt32OrNull(this IDictionary<object, object?>? dictionary, object key) {
            return TryGetInt32(dictionary, key, out int? result) ? result : null;
        }

        /// <summary>
        /// Returns the 64-bit integer value of the dictionary item with the specified <paramref name="key"/>. If a
        /// matching dictionary doesn't exist or it's value can not be converted to a <see cref="long"/> value, <c>0</c>
        /// is returned instead.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <returns>The <see cref="long"/> value if successful; otherwise, <c>0</c>.</returns>
        public static long GetInt64(this IDictionary<object, object?>? dictionary, object key) {
            return TryGetInt64(dictionary, key, out long result) ? result : 0;
        }

        /// <summary>
        /// Returns the 64-bit integer value of the dictionary item with the specified <paramref name="key"/>. If a
        /// matching dictionary doesn't exist or it's value can not be converted to a <see cref="long"/> value,
        /// <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <returns>The <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</returns>
        public static long? GetInt64OrNull(this IDictionary<object, object?>? dictionary, object key) {
            return TryGetInt64(dictionary, key, out long? result) ? result : null;
        }

        /// <summary>
        /// Returns the string value of the dictionary item with the specified <paramref name="key"/>. If a matching dictionary item is found, but the value isn't a <see cref="string"/>, the value s converted to it's culture invariant string representation. If a matching dictionary isn't found, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <returns>The <see cref="string"/> value if successful; otherwise, <see langword="null"/>.</returns>
        public static string? GetString(this IDictionary<object, object?>? dictionary, object key) {
            return TryGetString(dictionary, key, out string? result) ? result : null;
        }

        /// <summary>
        /// Attempts to get a boolean value (<see cref="bool"/>) from the dictionary item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this IDictionary<object, object?>? dictionary, object key, out bool result) {

            if (dictionary is null || !dictionary.TryGetValue(key, out object? value)) {
                result = default;
                return false;
            }

            switch (value) {

                case bool boolean:
                    result = boolean;
                    return true;

                case string str:
                    return StringUtils.TryParseBoolean(str, out result);

                default:
                    result = default;
                    return false;

            }

        }

        /// <summary>
        /// Attempts to get a boolean value (<see cref="bool"/>) from the dictionary item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this IDictionary<object, object?>? dictionary, object key, out bool? result) {

            if (dictionary is null || !dictionary.TryGetValue(key, out object? value)) {
                result = default;
                return false;
            }

            switch (value) {

                case bool boolean:
                    result = boolean;
                    return true;

                case string str:
                    return StringUtils.TryParseBoolean(str, out result);

                default:
                    result = default;
                    return false;

            }

        }

        /// <summary>
        /// Attempts to get a 32-bit integer value (<see cref="int"/>) from the with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt32(this IDictionary<object, object?>? dictionary, object key, out int result) {

            if (dictionary is null || !dictionary.TryGetValue(key, out object? value)) {
                result = default;
                return false;
            }

            switch (value) {

                case int number:
                    result = number;
                    return true;

                case long longValue:
                    if (longValue is >= int.MinValue and <= int.MaxValue) {
                        result = (int) longValue;
                        return true;
                    }
                    result = default;
                    return false;

                case string str:
                    return int.TryParse(str, out result);

                default:
                    result = default;
                    return false;

            }

        }
        
        /// <summary>
        /// Attempts to get a 32-bit integer value (<see cref="int"/>) from the with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt32(this IDictionary<object, object?>? dictionary, object key, [NotNullWhen(true)] out int? result) {

            if (TryGetInt32(dictionary, key, out int value)) {
                result = value;
                return true;
            }

            result = null;
            return false;

        }

        /// <summary>
        /// Attempts to get a 64-bit integer value (<see cref="long"/>) from the with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt64(this IDictionary<object, object?>? dictionary, object key, out long result) {

            if (dictionary is null || !dictionary.TryGetValue(key, out object? value)) {
                result = default;
                return false;
            }

            switch (value) {

                case int intValue:
                    result = intValue;
                    return true;

                case long longValue:
                    result = longValue;
                    return true;

                case string str:
                    return long.TryParse(str, default, CultureInfo.InvariantCulture, out result);

                default:
                    result = default;
                    return false;

            }

        }

        /// <summary>
        /// Attempts to get a 64-bit integer value (<see cref="int"/>) from the with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt64(this IDictionary<object, object?>? dictionary, object key, [NotNullWhen(true)] out long? result) {

            if (TryGetInt64(dictionary, key, out long value)) {
                result = value;
                return true;
            }

            result = null;
            return false;

        }

        /// <summary>
        /// Attempts to get the string value with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key of the dictionary item.</param>
        /// <param name="result">When this method returns, holds the <see cref="string"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetString(this IDictionary<object, object?>? dictionary, object key, [NotNullWhen(true)] out string? result) {

            if (dictionary is null || !dictionary.TryGetValue(key, out object? value)) {
                result = null;
                return false;
            }

            result = string.Format(CultureInfo.InvariantCulture, "{0}", value);
            return true;


        }

    }

}
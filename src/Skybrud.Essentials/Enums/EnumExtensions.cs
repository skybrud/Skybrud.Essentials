using System;
using System.Collections.Generic;

namespace Skybrud.Essentials.Enums {

    /// <summary>
    /// Class with various extension methods for working with enums.
    /// </summary>
    public static class EnumExtensions {

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into an enum vlaue of <paramref name="type"/>.
        /// </summary>
        /// <param name="input">The ordinal value of the enum.</param>
        /// <param name="type">The enum type.</param>
        /// <returns>An instance of <see cref="Enum"/>.</returns>
        public static Enum ToEnum(this int input, Type type) {
            return EnumUtils.FromInt32(input, type);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string into an enum vlaue of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="input">The ordinal value of the enum.</param>
        /// <returns>An instance of <see cref="Enum"/>.</returns>
        public static T ToEnum<T>(this int input) where T : Enum {
            return EnumUtils.FromInt32WhereTIsEnum<T>(input);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to it's corresponding <see cref="int"/> ordinal value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>An instance of <see cref="int"/> representing the ordinal value of the enum.</returns>
        public static int ToInt32(this Enum value) {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> into the individual flags that it represents.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>An instance of <see cref="IEnumerable{TEnum}"/>.</returns>
        public static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum value) where TEnum : Enum {
            // ReSharper disable once LoopCanBeConvertedToQuery
            if (Convert.ToInt32(value) == 0) {
                yield return default!;
            } else {
                foreach (Enum flag in Enum.GetValues(value.GetType())) {
                    if (Convert.ToInt32(flag) > 0 && value.HasFlag(flag)) yield return (TEnum) flag;
                }
            }
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
        public static bool IsBetween(this Enum value, int min, int max) {
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
        public static bool IsBetween(this Enum value, Enum min, Enum max) {
            int v = Convert.ToInt32(value);
            return v >= Convert.ToInt32(min) && v <= Convert.ToInt32(max);
        }

    }

}
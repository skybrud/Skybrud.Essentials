using System;

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

    }

}
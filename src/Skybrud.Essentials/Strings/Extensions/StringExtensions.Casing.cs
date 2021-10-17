using System;
using System.Collections.Generic;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Converts the specified <paramref name="str"/> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToCamelCase(this string str) {
            return StringUtils.ToCamelCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a camel cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToCamelCase(this Enum value) {
            return StringUtils.ToCamelCase(value);
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a camel cased string (also referred to as lower
        /// camel casing). If <paramref name="values"/> contains more than one enum value, the names will be separated
        /// by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToCamelCase<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToCamelCase(values);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        public static string ToPascalCase(this string str) {
            return StringUtils.ToPascalCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a Pascal cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        public static string ToPascalCase(this Enum value) {
            return StringUtils.ToPascalCase(value);
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a Pascal cased string (also referred to as upper
        /// camel casing). If <paramref name="values"/> contains more than one enum value, the names will be separated
        /// by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToPascalCase<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToPascalCase(values);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a kebab cased string (lower case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The kebab cased string.</returns>
        public static string ToKebabCase(this string str) {
            return StringUtils.ToKebabCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a kebab cased string (lower case words separated by hyphens).
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToKebabCase(this Enum value) {
            return StringUtils.ToKebabCase(value);
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a kebab cased string (lower case words separated
        /// by hyphens). If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToKebabCase<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToKebabCase(values);
        }
        
        /// <summary>
        /// Converts the specified <paramref name="str"/> to a train cased string (upper case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The train cased string.</returns>
        public static string ToTrainCase(this string str) {
            return StringUtils.ToTrainCase(str);
        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a train cased string (upper case words separated by hyphens).
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToTrainCase(this Enum value) {
            return StringUtils.ToTrainCase(value);
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a train cased string (upper case words separated
        /// by hyphens). If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToTrainCase<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToTrainCase(values);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(this string str) {
            return StringUtils.ToUnderscore(str);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a lower case string with words separated by
        /// underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(this Enum value) {
            return StringUtils.ToUnderscore(value);
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a lower case string with words separated by
        /// underscores. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToUnderscore(values);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a lower case string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The lower case version of <paramref name="value"/>.</returns>
        public static string ToLower(this Enum value) {
            return value.ToString().ToLower();
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a lower case string. If <paramref name="values"/>
        /// contains more than one enum value, the names will be separated by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The lower case version of <paramref name="values"/>.</returns>
        public static string ToLower<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToLower(values);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to an upper case string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The upper case version of <paramref name="value"/>.</returns>
        public static string ToUpper(this Enum value) {
            return value.ToString().ToUpper();
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to an upper case string. If <paramref name="values"/>
        /// contains more than one enum value, the names will be separated by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The upper case version of <paramref name="values"/>.</returns>
        public static string ToUpper<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToUpper(values);
        }

        /// <summary>
        /// Uppercases the first character of a the specified <paramref name="str"/>. If <paramref name="str"/> is
        /// either <c>null</c> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be uppercased.</param>
        /// <returns>The input string with the first character has been uppercased.</returns>
        public static string FirstCharToUpper(this string str) {
            return string.IsNullOrEmpty(str) ? string.Empty : string.Concat(str.Substring(0, 1).ToUpper(), str.Substring(1));
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a string with the enum name is formatted using the specified <paramref name="casing"/>.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <param name="casing">The casing of the output string.</param>
        /// <returns>The output string, matching the specified <paramref name="casing"/>.</returns>
        public static string ToCasing(this Enum value, TextCasing casing) {
            return StringUtils.ToCasing(value, casing);
        }
        
        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a string where the enum names are formatted using the specified <paramref name="casing"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <param name="casing">The casing of the output string.</param>
        /// <returns>The output string, matching the specified <paramref name="casing"/>.</returns>
        public static string ToCasing<TEnum>(this IEnumerable<TEnum> values, TextCasing casing) where TEnum : Enum {
            return StringUtils.ToCasing(values, casing);
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a new string formatted using the specified <paramref name="casing"/>.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <param name="casing">The casing of the output string.</param>
        /// <returns>The output string, matching the specified <paramref name="casing"/>.</returns>
        public static string ToCasing(this string str, TextCasing casing) {
            return StringUtils.ToCasing(str, casing);
        }

    }

}
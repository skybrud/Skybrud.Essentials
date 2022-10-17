using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// ReSharper disable RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        private static readonly char[] _casingSeparators = { ' ', '_' };

        /// <summary>
        /// Converts the specified <paramref name="str"/> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToCamelCase(string? str) {

            // Convert the string to lowercase initially for better results (eg. if the string is already camel cased)
            str = ToUnderscore(str);

            // Split the string by space or underscore
            string[] pieces = str.Split(_casingSeparators, StringSplitOptions.RemoveEmptyEntries);

            // Join the pieces again and uppercase the first character of each piece but the first
            return string.Join(string.Empty, pieces.Select((t, i) => i == 0 ? t : FirstCharToUpper(t)));

        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a camel cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToCamelCase(Enum value) {
            return ToCamelCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a camel cased string (also referred to as lower
        /// camel casing). If <paramref name="values"/> contains more than one enum value, the names will be separated
        /// by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToCamelCase<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToCamelCase(e));
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        public static string ToPascalCase(string? str) {

            // Convert the string to lowercase initially for better results (eg. if the string is already camel cased)
            str = ToUnderscore(str);

            // Split the string by space or underscore
            string[] pieces = str.Split(_casingSeparators, StringSplitOptions.RemoveEmptyEntries);

            // Join the pieces again and uppercase the first character of each piece
            return string.Join(string.Empty, from piece in pieces select FirstCharToUpper(piece));

        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a Pascal cased string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        public static string ToPascalCase(Enum value) {
            return ToPascalCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a Pascal cased string (also referred to as upper
        /// camel casing). If <paramref name="values"/> contains more than one enum value, the names will be separated
        /// by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToPascalCase<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToPascalCase(e));
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a kebab cased string (lower case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The kebab cased string.</returns>
        public static string ToKebabCase(string? str) {

            // Return right away if null or white space
            if (string.IsNullOrWhiteSpace(str)) return str ?? string.Empty;

            // Replace invalid characters
            str = Regex.Replace(str, "[\\W_]+", " ").Trim();

            // Replace multiple whitespaces
            str = Regex.Replace(str, "[ ]{2,}", " ");

            // Convert to lower case (with upper case letters prefixed with hyphens)
            return Regex.Replace(str, @"(\p{Ll})(\p{Lu})", "$1-$2").Replace(" ", "-").Replace("--", "-").ToLower();

        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a kebab cased string (lower case words separated by hyphens).
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToKebabCase(Enum value) {
            return ToKebabCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a kebab cased string (lower case words separated
        /// by hyphens). If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToKebabCase<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToKebabCase(e));
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a train cased string (upper case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The train cased string.</returns>
        public static string ToTrainCase(string? str) {

            // Return right away if null or white space
            if (string.IsNullOrWhiteSpace(str)) return str ?? string.Empty;

            // Replace invalid characters
            str = Regex.Replace(str, "[\\W_]+", " ").Trim();

            // Replace multiple whitespaces
            str = Regex.Replace(str, "[ ]{2,}", " ");

            // Convert to upper case (with upper case letters prefixed with hyphens)
            return Regex.Replace(str, @"(\p{Ll})(\p{Lu})", "$1-$2").Replace(" ", "-").Replace("--", "-").ToUpper();

        }

        /// <summary>
        /// Converts the name of the specified enum <paramref name="value"/> to a train cased string (upper case words separated by hyphens).
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToTrainCase(Enum value) {
            return ToTrainCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a train cased string (upper case words separated
        /// by hyphens). If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToTrainCase<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToTrainCase(e));
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(string? str) {

            // Return right away if null or white space
            if (string.IsNullOrWhiteSpace(str)) return str ?? string.Empty;

            // Replace invalid characters
            str = Regex.Replace(str, "[\\W_]+", " ").Trim();

            // Replace multiple whitespaces
            str = Regex.Replace(str, "[ ]{2,}", " ");

            // Convert to lowercase (with uppercase letters prefixed with underscore)
            return Regex.Replace(str, @"(\p{Ll})(\p{Lu})", "$1_$2").Replace(" ", "_").Replace("__", "_").ToLower();

        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a lower case string with words separated by
        /// underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(Enum value) {
            return ToUnderscore(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a lower case string with words separated by
        /// underscores. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToUnderscore(e));
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a lower case string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The lower case version of <paramref name="value"/>.</returns>
        public static string ToLower(Enum value) {
            return value.ToString().ToLower();
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a lower case string. If <paramref name="values"/>
        /// contains more than one enum value, the names will be separated by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The lower case version of <paramref name="values"/>.</returns>
        public static string ToLower<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToLower(e));
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to an upper case string.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The upper case version of <paramref name="value"/>.</returns>
        public static string ToUpper(Enum value) {
            return value.ToString().ToUpper();
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to an upper case string. If <paramref name="values"/>
        /// contains more than one enum value, the names will be separated by commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The upper case version of <paramref name="values"/>.</returns>
        public static string ToUpper<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToUpper(e));
        }

        /// <summary>
        /// Uppercases the first character of a the specified <paramref name="str"/>. If <paramref name="str"/> is
        /// either <c>null</c> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be uppercased.</param>
        /// <returns>The input string with the first character has been uppercased.</returns>
        public static string FirstCharToUpper(string? str) {
#if NET5_0_OR_GREATER
            return string.IsNullOrEmpty(str) ? string.Empty : string.Concat(str[..1].ToUpper(), str[1..]);
#else
            return string.IsNullOrEmpty(str) ? string.Empty : string.Concat(str!.Substring(0, 1).ToUpper(), str.Substring(1));
#endif
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a string where the enum name is formatted using the specified <paramref name="casing"/>.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <param name="casing">The casing of the output string.</param>
        /// <returns>The output string, matching the specified <paramref name="casing"/>.</returns>
        public static string ToCasing(Enum value, TextCasing casing) {
            return ToCasing(value.ToString(), casing);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a string where the enum names are formatted using the specified <paramref name="casing"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <param name="casing">The casing of the output string.</param>
        /// <returns>The output string, matching the specified <paramref name="casing"/>.</returns>
        public static string ToCasing<TEnum>(IEnumerable<TEnum> values, TextCasing casing) where TEnum : Enum {
            return string.Join(",", from e in values select ToCasing(e, casing));
        }

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a new string formatted using the specified <paramref name="casing"/>.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <param name="casing">The casing of the output string.</param>
        /// <returns>The output string, matching the specified <paramref name="casing"/>.</returns>
        public static string ToCasing(string? str, TextCasing casing) {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            return casing switch {
                TextCasing.LowerCase => str!.ToLower(),
                TextCasing.UpperCase => str!.ToUpper(),
                TextCasing.CamelCase => ToCamelCase(str),
                TextCasing.PascalCase => ToPascalCase(str),
                TextCasing.KebabCase => ToKebabCase(str),
                TextCasing.TrainCase => ToTrainCase(str),
                TextCasing.Underscore => ToUnderscore(str),
                _ => throw new ArgumentException($"Unknown casing {casing}", nameof(casing))
            };
        }

    }

}
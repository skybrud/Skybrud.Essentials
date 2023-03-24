using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        #region Constants

        internal const char Null = (char) 0;

        internal const char Hyphen = '-';

        internal const char Underscore = '_';

        internal const char Space = ' ';

        #endregion

        #region ToCamelCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToCamelCase(string? str) {
            return ToCasing(str, false, null, Null);
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

        #endregion

        #region ToPascalCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        public static string ToPascalCase(string? str) {
            return ToCasing(str, true, null, Null);
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

        #endregion

        #region ToKebabCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a kebab cased string (lower case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The kebab cased string.</returns>
        public static string ToKebabCase(string? str) {
            return ToCasing(str, false, false, Hyphen);
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

        #endregion

        #region ToHeaderCase(...)

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to a new lower camel cased string, but with the
        /// first character in each word as upper case, and words separator by hyphens.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The converted string in header case.</returns>
        public static string ToHeaderCase(string? input) {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            // TODO: Should probably be optimized?
            return ToCasingList(input!, true, false)
                .Select(x => x.FirstCharToUpper())
                .Join(Hyphen);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a new lower camel cased string, but with the first
        /// character in each word as upper case, and words separator by hyphens.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string in header case.</returns>
        public static string ToHeaderCase(Enum value) {
            return ToHeaderCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a new lower camel cased string, but with the first
        /// character in each word as upper case, and words separator by hyphens. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string in header case.</returns>
        public static string ToHeaderCase<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToHeaderCase(e));
        }

        #endregion

        #region ToTrainCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a train cased string (upper case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The train cased string.</returns>
        public static string ToTrainCase(string? str) {
            return ToCasing(str, true, true, Hyphen);
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

        #endregion

        #region ToSnakeCase(...)

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToSnakeCase(string? input) {
            return ToCasing(input, false, false, Underscore);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a lower case string with words separated by
        /// underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToSnakeCase(Enum value) {
            return ToSnakeCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a lower case string with words separated by
        /// underscores. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToSnakeCase<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToSnakeCase(e));
        }

        #endregion

        #region ToUnderscore(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(string? str) {
            return ToSnakeCase(str);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a lower case string with words separated by
        /// underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(Enum value) {
            return ToSnakeCase(value);
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
            return ToSnakeCase(values);
        }

        #endregion

        #region ToConstantCase(...)

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to a upper case string with words separated by underscores.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToConstantCase(string? input) {
            return ToCasing(input, true, true, Underscore);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a upper case string with words separated by
        /// underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToConstantCase(Enum value) {
            return ToConstantCase(value.ToString());
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a upper case string with words separated by
        /// underscores. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToConstantCase<TEnum>(IEnumerable<TEnum> values) where TEnum : Enum {
            return string.Join(",", from e in values select ToConstantCase(e));
        }

        #endregion

        #region ToLower(...)

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

        #endregion

        #region ToUpper(...)

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

        #endregion

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
                TextCasing.HeaderCase => ToHeaderCase(str),
                TextCasing.TrainCase => ToTrainCase(str),
                TextCasing.SnakeCase => ToSnakeCase(str),
                TextCasing.ConstantCase => ToConstantCase(str),
                _ => throw new ArgumentException($"Unknown casing {casing}", nameof(casing))
            };
        }

        private static IReadOnlyList<string> ToCasingList(string input, bool firstToUpper, bool? upperCase) {

            StringBuilder buffer = new();
            List<string> words = new();

            for (int i = 0; i < input.Length; i++) {

                char c = input[i];
                char n = i < input.Length - 1 ? input[i + 1] : (char) 0;

                char d = upperCase == null ? char.ToLowerInvariant(c) : (upperCase.Value ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c));

                // If "c" is neither a letter or digit, it's either a white space character or some kind of unwanted character. In either case, this means that we clar the buffer and expect a new word
                if (!char.IsLetterOrDigit(c)) {
                    if (buffer.Length > 0) words.Add(buffer.ToString());
                    buffer.Clear();
                    continue;
                }

                // If the buffer is empty, it means we're at the start of a new word. If we're at the very first word and "firstToUpper" is "false", so make sure the word starts with a lower case character
                if (buffer.Length == 0) {
                    if (words.Count == 0 && !firstToUpper) {
                        buffer.Append(char.ToLowerInvariant(c));
                    } else if (upperCase is false) {
                        buffer.Append(char.ToLowerInvariant(c));
                    } else {
                        buffer.Append(char.ToUpperInvariant(c));
                    }
                    continue;
                }

                // If the current character is upper case, but the next character is lower case, it means that we're at the beginning of a new word
                if (char.IsUpper(c) && char.IsLower(n)) {
                    if (buffer.Length > 0) words.Add(buffer.ToString());
                    buffer.Clear();
                    buffer.Append(ToCase(c, upperCase is not false));
                    continue;
                }

                // If the current character is lower case, but the next character is upper case, it means that we're at the last character of the current word
                if (char.IsLower(c) && char.IsUpper(n)) {
                    buffer.Append(d);
                    words.Add(buffer.ToString());
                    buffer.Clear();
                    continue;
                }

                // In any other case, we append "d"
                buffer.Append(d);

            }

            if (buffer.Length > 0) words.Add(buffer.ToString());

            return words;

        }

        private static string ToCasing(string? input, bool firstToUpper, bool? upperCase, char separator) {

            if (string.IsNullOrEmpty(input)) return string.Empty;

            IReadOnlyList<string> words = ToCasingList(input!, firstToUpper, upperCase);

#if NET6_0_OR_GREATER
            return separator > 0 ? string.Join(separator, words) : string.Join("", words);
#else
            return separator > 0 ? string.Join(separator.ToString(), words) : string.Join("", words);
#endif

        }

        private static char ToCase(char c, bool upper) {
            return upper ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c);
        }

    }

}
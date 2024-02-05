﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

// ReSharper disable once RedundantSuppressNullableWarningExpression

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        #region ToCamelCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to camel case (also referred to as lower camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The camel cased string.</returns>
        public static string ToCamelCase(this string? str) {
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

        #endregion

        #region ToPascalCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to Pascal case (also referred to as upper camel casing).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The Pascal cased string.</returns>
        public static string ToPascalCase(this string? str) {
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

        #endregion

        #region ToKebabCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a kebab cased string (lower case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The kebab cased string.</returns>
        public static string ToKebabCase(this string? str) {
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

        #endregion

        #region ToHeaderCase(...)

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to a new lower camel cased string, but with the
        /// first character in each word as upper case, and words separator by hyphens.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The converted string in header case.</returns>
        public static string ToHeaderCase(this string? input) {
            return StringUtils.ToHeaderCase(input);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a new lower camel cased string, but with the first
        /// character in each word as upper case, and words separator by hyphens.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string in header case.</returns>
        public static string ToHeaderCase(this Enum value) {
            return StringUtils.ToHeaderCase(value);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a new lower camel cased string, but with the first
        /// character in each word as upper case, and words separator by hyphens. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string in header case.</returns>
        public static string ToHeaderCase<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToHeaderCase(values);
        }

        #endregion

        #region ToTrainCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a train cased string (upper case words separated by hyphens).
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The train cased string.</returns>
        public static string ToTrainCase(this string? str) {
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

        #endregion

        #region ToSnakeCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToSnakeCase(this string? str) {
            return StringUtils.ToSnakeCase(str);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to a lower case string with words separated by
        /// underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToSnakeCase(this Enum value) {
            return StringUtils.ToSnakeCase(value);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to a lower case string with words separated by
        /// underscores. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToSnakeCase<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToSnakeCase(values);
        }

        #endregion

        #region ToUnderscore(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to a lower case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToUnderscore(this string? str) {
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

        #endregion

        #region ToConstantCase(...)

        /// <summary>
        /// Converts the specified <paramref name="str"/> to an upper case string with words separated by underscores.
        /// </summary>
        /// <param name="str">The string to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToConstantCase(this string? str) {
            return StringUtils.ToConstantCase(str);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="value"/> to an upper case string with words separated by
        /// underscores.
        /// </summary>
        /// <param name="value">The enum value to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToConstantCase(this Enum value) {
            return StringUtils.ToConstantCase(value);
        }

        /// <summary>
        /// Converts the specified enum <paramref name="values"/> to an upper case string with words separated by
        /// underscores. If <paramref name="values"/> contains more than one enum value, the names will be separated by
        /// commas.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToConstantCase<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum {
            return StringUtils.ToConstantCase(values);
        }

        #endregion

        #region ToLower(...)

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

        #endregion

        #region ToUpper(...)

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

        #endregion

        #if NET45_OR_GREATER || NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER

        /// <summary>
        /// Returns a title cased version of the specified <paramref name="input"/> string according to the invariant culture.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The converted string in title case format.</returns>
        /// <see>
        ///     <cref>https://learn.microsoft.com/en-us/dotnet/api/system.globalization.textinfo.totitlecase</cref>
        /// </see>
        [return: NotNullIfNotNull("input")]
        public static string? ToTitleCase(this string? input) {
            return ToTitleCase(input, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a title cased version of the specified <paramref name="input"/> string according to <paramref name="culture"/>.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <param name="culture">The culture to be used for the conversion.</param>
        /// <returns>The converted string in title case format.</returns>
        /// <see>
        ///     <cref>https://learn.microsoft.com/en-us/dotnet/api/system.globalization.textinfo.totitlecase</cref>
        /// </see>
        [return: NotNullIfNotNull("input")]
        public static string? ToTitleCase(this string? input, CultureInfo culture) {
            return string.IsNullOrWhiteSpace(input) ? input : culture.TextInfo.ToTitleCase(input);
        }

#endif

        /// <summary>
        /// Lower cases the first character of a the specified <paramref name="str"/>. If <paramref name="str"/> is
        /// either <see langword="null"/> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be lower cased.</param>
        /// <returns>The input string with the first character has been lower cased.</returns>
        public static string FirstCharToLower(this string? str) {
#if NET5_0_OR_GREATER
            return string.IsNullOrEmpty(str) ? string.Empty : string.Concat(str[..1].ToLowerInvariant(), str[1..]);
#else
            return string.IsNullOrEmpty(str) ? string.Empty : string.Concat(str!.Substring(0, 1).ToLowerInvariant(), str.Substring(1));
#endif
        }

        /// <summary>
        /// Upper cases the first character of a the specified <paramref name="str"/>. If <paramref name="str"/> is
        /// either <see langword="null"/> or empty, an empty string will be returned instead.
        /// </summary>
        /// <param name="str">The string which first character should be upper cased.</param>
        /// <returns>The input string with the first character has been upper cased.</returns>
        public static string FirstCharToUpper(this string? str) {
#if NET5_0_OR_GREATER
            return string.IsNullOrEmpty(str) ? string.Empty : string.Concat(str![..1].ToUpperInvariant(), str[1..]);
#else
            return string.IsNullOrEmpty(str) ? string.Empty : string.Concat(str!.Substring(0, 1).ToUpperInvariant(), str.Substring(1));
#endif
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
        public static string ToCasing(this string? str, TextCasing casing) {
            return StringUtils.ToCasing(str, casing);
        }

    }

}
﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Gets whether the string matches a double (<see cref="double"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a double; otherwise <c>false</c>.</returns>
        public static bool IsDouble(string str) {
            return double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="double"/>. If the parsing fails,
        /// the default value of <see cref="double"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double ParseDouble(string str) {
            double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out double value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="double"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="double"/>.</returns>
        public static double ParseDouble(string str, double fallback) {
            return double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out double value) ? value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="double"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>An array of double-precision doubleing-point values (<see cref="double"/>).</returns>
        public static double[] ParseDoubleArray(string input) {
            return ParseDoubleArray(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into an array of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Values in the list that can't be converted to
        /// <see cref="double"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of double-precision doubleing-point values (<see cref="double"/>).</returns>
        public static double[] ParseDoubleArray(string input, params char[] separators) {
            return ParseDoubleList(input, separators).ToArray();
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Supported separators are <c>,</c>, <c> </c>,
        /// <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list that can't be converted to <see cref="double"/> will
        /// be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <returns>A list of 32-bit signed integer values (<see cref="double"/>).</returns>
        public static List<double> ParseDoubleList(string input) {
            return ParseDoubleList(input, DefaultSeparators);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string of numeric values into a list of corresponding
        /// double-precision doubleing-point values (<see cref="double"/>). Values in the list that can't be converted to
        /// <see cref="double"/> will be ignored.
        /// </summary>
        /// <param name="input">The string of numeric values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of double-precision doubleing-point values (<see cref="double"/>).</returns>
        public static List<double> ParseDoubleList(string input, params char[] separators) {

            List<double> temp = new();

            foreach (string piece in input.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                if (double.TryParse(piece, NumberStyles.Any, CultureInfo.InvariantCulture, out double result)) {
                    temp.Add(result);
                }
            }

            return temp;

        }

    }

}
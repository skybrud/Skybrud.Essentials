﻿using System;

namespace Skybrud.Essentials.Strings.Extensions {

    public static partial class StringExtensions {

        /// <summary>
        /// Converts a comma separated string into an array of integers.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        [Obsolete("Use ToInt32Array instead.")]
        public static int[] CsvToInt(this string str) {
            return StringUtils.ParseInt32Array(str);
        }

        /// <summary>
        /// Parses a comma separated string into an array of <see cref="int"/>.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        [Obsolete("Use ToInt32Array instead.")]
        public static int[] ParseInt32Array(this string str) {
            return StringUtils.ParseInt32Array(str);
        }

        /// <summary>
        /// Parses a comma separated string into an array of <see cref="long"/>.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="long"/>.</returns>
        [Obsolete("Use ToInt64Array instead.")]
        public static long[] ParseInt64Array(this string str) {
            return StringUtils.ParseInt64Array(str);
        }

    }

}
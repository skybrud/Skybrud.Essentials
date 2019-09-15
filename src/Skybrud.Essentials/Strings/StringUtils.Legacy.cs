using System;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Converts a comma separated string into an array of integers.
        /// </summary>
        /// <param name="str">The comma separated string to be converted.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        [Obsolete("Use ParseInt32Array instead.")]
        public static int[] CsvToInt(string str) {
            return ParseInt32Array(str);
        }

    }

}
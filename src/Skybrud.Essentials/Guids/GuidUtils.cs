using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Essentials.Collections;

namespace Skybrud.Essentials.Guids {

    /// <summary>
    /// Static class with various utility methods for working with GUIDs.
    /// </summary>
    public class GuidUtils {

        /// <summary>
        /// Converts the specified <paramref name="value"/> into a <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ToGuid(int value) {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> into a <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ToGuid(long value) {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(int[]? values) {
            return values?.Select(ToGuid).ToArray() ?? ArrayUtils.Empty<Guid>();
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(IEnumerable<int>? values) {
            return values?.Select(ToGuid).ToArray() ?? ArrayUtils.Empty<Guid>();
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(long[]? values) {
            return values?.Select(ToGuid).ToArray() ?? ArrayUtils.Empty<Guid>();
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(IEnumerable<long>? values) {
            return values?.Select(ToGuid).ToArray() ?? ArrayUtils.Empty<Guid>();
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="value"/> to a numerical representation.
        /// </summary>
        /// <param name="value">The GUID to be converted.</param>
        /// <returns>An <see cref="int"/> representation of the GUID.</returns>
        public static int ToInt32(Guid value) {
            return BitConverter.ToInt32(value.ToByteArray(), 0);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="int"/> representations of the specified GUIDs.</returns>
        public static int[] ToInt32Array(Guid[]? values) {
            return values?.Select(ToInt32).ToArray() ?? ArrayUtils.Empty<int>();
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="int"/> representations of the specified GUIDs.</returns>
        public static int[] ToInt32Array(IEnumerable<Guid>? values) {
            return values?.Select(ToInt32).ToArray() ?? ArrayUtils.Empty<int>();
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="value"/> to a numerical representation.
        /// </summary>
        /// <param name="value">The GUID to be converted.</param>
        /// <returns>An <see cref="long"/> representation of the GUID.</returns>
        public static long ToInt64(Guid value) {
            return BitConverter.ToInt64(value.ToByteArray(), 0);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="long"/> representations of the specified GUIDs.</returns>
        public static long[] ToInt64Array(Guid[]? values) {
            return values?.Select(ToInt64).ToArray() ?? ArrayUtils.Empty<long>();
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="long"/> representations of the specified GUIDs.</returns>
        public static long[] ToInt64Array(IEnumerable<Guid>? values) {
            return values?.Select(ToInt64).ToArray() ?? ArrayUtils.Empty<long>();
        }

    }

}
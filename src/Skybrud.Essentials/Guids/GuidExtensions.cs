using System;
using System.Collections.Generic;

namespace Skybrud.Essentials.Guids {

    /// <summary>
    /// Static class with various extension methods for or in relation to the <see cref="Guid"/>.
    /// </summary>
    public static class GuidExtensions {

        /// <summary>
        /// Returns whether the specified GUID <paramref name="value"/> is different from <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="value">The GUID value.</param>
        /// <returns><c>false</c> if <paramref name="value"/> is either <c>null</c> or <see cref="Guid.Empty"/>; otherwise <c>false</c>.</returns>
        public static bool HasValue(this Guid value) {
            return value != Guid.Empty;
        }

        /// <summary>
        /// Returns whether the specified GUID <paramref name="value"/> is neither <c>null</c> or equal to <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="value">The GUID value.</param>
        /// <returns><c>false</c> if <paramref name="value"/> is either <c>null</c> or <see cref="Guid.Empty"/>; otherwise <c>false</c>.</returns>
        public static bool HasValue(this Guid? value) {
            return value != null && value.Value != Guid.Empty;
        }

        /// <summary>
        /// Returns whether the specified GUID <paramref name="value"/> is empty.
        /// </summary>
        /// <param name="value">The GUID value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is equal to <see cref="Guid.NewGuid"/>; otherwise <c>false</c>.</returns>
        public static bool IsEmpty(this Guid value) {
            return value == Guid.Empty;
        }

        /// <summary>
        /// Returns whether the specified GUID <paramref name="value"/> is either <c>null</c> or <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="value">The GUID value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> is either <c>null</c> or <see cref="Guid.Empty"/>; otherwise <c>false</c>.</returns>
        public static bool IsNullOrEmpty(this Guid? value) {
            return value == null || value.Value == Guid.Empty;
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> into a <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ToGuid(this int value) {
            return GuidUtils.ToGuid(value);
        }

        /// <summary>
        /// Converts the specified <paramref name="value"/> into a <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <returns>An instance of <see cref="Guid"/>.</returns>
        public static Guid ToGuid(this long value) {
            return GuidUtils.ToGuid(value);
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this int[]? values) {
            return GuidUtils.ToGuidArray(values);
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this IEnumerable<int>? values) {
            return GuidUtils.ToGuidArray(values);
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this long[]? values) {
            return GuidUtils.ToGuidArray(values);
        }

        /// <summary>
        /// Converts the specified array of numeric <paramref name="values"/> to a corresponding <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this IEnumerable<long>? values) {
            return GuidUtils.ToGuidArray(values);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="value"/> to a numerical representation.
        /// </summary>
        /// <param name="value">The GUID to be converted.</param>
        /// <returns>An <see cref="int"/> representation of the GUID.</returns>
        public static int ToInt32(this Guid value) {
            return GuidUtils.ToInt32(value);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="int"/> representations of the specified GUIDs.</returns>
        public static int[] ToInt32Array(this Guid[]? values) {
            return GuidUtils.ToInt32Array(values);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="int"/> representations of the specified GUIDs.</returns>
        public static int[] ToInt32Array(this IEnumerable<Guid>? values) {
            return GuidUtils.ToInt32Array(values);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="value"/> to a numerical representation.
        /// </summary>
        /// <param name="value">The GUID to be converted.</param>
        /// <returns>An <see cref="long"/> representation of the GUID.</returns>
        public static long ToInt64(this Guid value) {
            return GuidUtils.ToInt64(value);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="long"/> representations of the specified GUIDs.</returns>
        public static long[] ToInt64Array(this Guid[]? values) {
            return GuidUtils.ToInt64Array(values);
        }

        /// <summary>
        /// Converts the specified GUID <paramref name="values"/> to their numerical representations.
        /// </summary>
        /// <param name="values">A collection of GUIDs to be converted.</param>
        /// <returns>An array of <see cref="long"/> representations of the specified GUIDs.</returns>
        public static long[] ToInt64Array(this IEnumerable<Guid>? values) {
            return GuidUtils.ToInt64Array(values);
        }

    }

}
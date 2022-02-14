using System;

namespace Skybrud.Essentials.Collections {

    internal static class ArrayUtils {

        /// <summary>
        /// Constants-like value for an empty int array - as we can't use <c>Array.Empty&lt;int&gt;</c> across all target frameworks.
        /// </summary>
        public static readonly int[] EmptyInt32Array = new int[0];

        /// <summary>
        /// Constants-like value for an empty long array - as we can't use <c>Array.Empty&lt;long&gt;</c> across all target frameworks.
        /// </summary>
        public static readonly long[] EmptyInt64Array = new long[0];

        /// <summary>
        /// Constants-like value for an empty GUID array - as we can't use <c>Array.Empty&lt;Guid&gt;</c> across all target frameworks.
        /// </summary>
        public static readonly Guid[] EmptyGuidArray = new Guid[0];

    }

}
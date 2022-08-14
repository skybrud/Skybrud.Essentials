// ReSharper disable UseArrayEmptyMethod

namespace Skybrud.Essentials.Collections {

    /// <summary>
    /// Static class with various logic for working with arrays.
    /// </summary>
    public static class ArrayUtils {

#if NET46_OR_GREATER || NETSTANDARD1_3_OR_GREATER


        /// <summary>
        /// Returns an empty array.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        /// <see>
        ///     <cref>https://docs.microsoft.com/en-us/dotnet/api/system.array.empty?view=net-6.0</cref>
        /// </see>
        public static T[] Empty<T>() {
            return System.Array.Empty<T>();
        }

#else

        /// <summary>
        /// Returns an empty array.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        /// <remarks>As <c>Array.Empty&lt;T&gt;</c> method isn't available in the current target framework, this method
        /// replicates what the <c>Array.Empty&lt;T&gt;</c> does in newer target frameworks.</remarks>
        /// <see>
        ///     <cref>https://docs.microsoft.com/en-us/dotnet/api/system.array.empty?view=net-6.0</cref>
        /// </see>
        public static T[] Empty<T>() {
            return EmptyArray<T>.Value;
        }

        private static class EmptyArray<T> {
            internal static readonly T[] Value = new T[0];
        }

#endif

    }

}
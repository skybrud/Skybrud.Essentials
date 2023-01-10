#if I_CAN_HAZ_SECURITY

namespace Skybrud.Essentials.Security.Extensions {

    /// <summary>
    /// Static class with variois Base64 related extension methods.
    /// </summary>
    public static class Base64Extensions {

        /// <summary>
        /// Returns a Base64 encoded version of the specified <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to be encoded.</param>
        /// <returns>The Base64 encoded string.</returns>
        public static string Base64Encode(this string input) {
            return SecurityUtils.Base64Encode(input);
        }

        /// <summary>
        /// Returns a Base64 decoded version of the specified <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to be decoded.</param>
        /// <returns>The Base64 decoded string.</returns>
        public static string Base64Decode(this string input) {
            return SecurityUtils.Base64Decode(input);
        }

    }

}

#endif
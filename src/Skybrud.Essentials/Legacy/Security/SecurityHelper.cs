#if NET_FRAMEWORK

using System;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable CheckNamespace

namespace Skybrud.Essentials.Security {

    /// <summary>
    /// Static class with miscellaneous helper methods.
    /// </summary>
    [Obsolete("Use the SecurityUtils class instead.")]
    public static class SecurityHelper {

        /// <summary>
        /// Base64 encodes the specified <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to be encoded.</param>
        /// <returns>The Base64 encoded string.</returns>
        public static string Base64Encode(string input) {
            return SecurityUtils.Base64Encode(input);
        }

        /// <summary>
        /// Base64 decodes the specified <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to be decoded.</param>
        /// <returns>The Base64 decoded string.</returns>
        public static string Base64Decode(string input) {
            return SecurityUtils.Base64Decode(input);
        }

        /// <summary>
        /// Gets the MD5 hash of <paramref name="input"/>, and returns that hash. The input string is converted
        /// using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5Hash(string input) {
            return SecurityUtils.GetMd5Hash(input);
        }

        /// <summary>
        /// Gets the MD5 hash of <paramref name="input"/>, and returns that hash. The input string is converted
        /// using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5Hash(string input, Encoding encoding) {
            return SecurityUtils.GetMd5Hash(input, encoding);
        }

        /// <summary>
        /// Gets the MD5 hash of the file specified by the <paramref name="path"/>. The hash is a 64-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5HashFromFile(string path) {
            return SecurityUtils.GetMd5HashFromFile(path);
        }

        /// <summary>
        /// Gets the SHA1 hash of <paramref name="input"/>, and returns that hash. The input string is converted
        /// using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1Hash(string input) {
            return SecurityUtils.GetSha1Hash(input);
        }

        /// <summary>
        /// Gets the SHA1 hash of <paramref name="input"/>, and returns that hash. The input string is converted
        /// using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1Hash(string input, Encoding encoding) {
            return SecurityUtils.GetSha1Hash(input, encoding);
        }

        /// <summary>
        /// Gets the SHA1 hash of the file specified by the <paramref name="path"/>. The hash is a 40-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1FromFile(string path) {
            return SecurityUtils.GetSha1FromFile(path);
        }

        /// <summary>
        /// Gets the SHA256 hash of <paramref name="input"/>, and returns that hash. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256Hash(string input) {
            return SecurityUtils.GetSha256Hash(input);
        }

        /// <summary>
        /// Gets the SHA256 hash of <paramref name="input"/>, and returns that hash. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256Hash(string input, Encoding encoding) {
            return SecurityUtils.GetSha256Hash(input, encoding);
        }

        /// <summary>
        /// Gets the SHA256 hash of the file specified by the <paramref name="path"/>. The hash is a 64-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256HashFromFile(string path) {
            return SecurityUtils.GetSha256HashFromFile(path);
        }

        /// <summary>
        /// Gets the SHA512 hash of <paramref name="input"/>, and returns that hash. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512Hash(string input) {
            return SecurityUtils.GetSha512Hash(input);
        }

        /// <summary>
        /// Gets the SHA512 hash of <paramref name="input"/>, and returns that hash. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512Hash(string input, Encoding encoding) {
            return SecurityUtils.GetSha512Hash(input, encoding);
        }

        /// <summary>
        /// Gets the SHA512 hash of the file specified by the <paramref name="path"/>. The hash is a 128-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512HashFromFile(string path) {
            return SecurityUtils.GetSha512HashFromFile(path);
        }

        /// <summary>
        /// Gets the hash of <paramref name="input"/> using the specified <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="input">The input string to be hashed.</param>
        /// <returns>The hash as a hexadecimal number.</returns>
        public static string GetHash(HashAlgorithm algorithm, string input) {
            return SecurityUtils.GetHash(algorithm, input);
        }

        /// <summary>
        /// Gets the hash of <paramref name="input"/> using the specified <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="input">The input string to be hashed.</param>
        /// <param name="encoding">The encoding to be used.</param>
        /// <returns>The hash as a hexadecimal number.</returns>
        public static string GetHash(HashAlgorithm algorithm, string input, Encoding encoding) {
            return SecurityUtils.GetHash(algorithm, input, encoding);
        }

        /// <summary>
        /// Gets the hash of the file specified by the <paramref name="path"/> using the specified <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetHashFromFile(HashAlgorithm algorithm, string path) {
            return SecurityUtils.GetHashFromFile(algorithm, path);
        }

    }

}

#endif
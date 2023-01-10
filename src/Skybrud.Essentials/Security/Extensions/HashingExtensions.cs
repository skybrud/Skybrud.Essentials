#if I_CAN_HAZ_SECURITY

using System.Text;
using System;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Security.Extensions {

    /// <summary>
    /// Static class with various extension methods related to hashing.
    /// </summary>
    public static class HashingExtensions {

        #region ToMd5Guid

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static Guid ToMd5Guid(this string input) {
            return SecurityUtils.GetMd5Guid(input);
        }

        /// <summary>
        /// Gets the MD5 hash of <paramref name="input"/>, and returns that hash. The input string is converted using
        /// <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static Guid ToMd5Guid(this string input, Encoding encoding) {
            return SecurityUtils.GetMd5Guid(input, encoding);
        }

        #endregion

        #region ToMd5Hash...

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string ToMd5Hash(this string input) {
            return SecurityUtils.GetMd5Hash(input);
        }

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string ToMd5Hash(this string input, HexFormat format) {
            return SecurityUtils.GetMd5Hash(input, format);
        }

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string ToMd5Hash(this string input, Encoding encoding) {
            return SecurityUtils.GetMd5Hash(input, encoding);
        }

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string ToMd5Hash(this string input, HexFormat format, Encoding encoding) {
            return SecurityUtils.GetMd5Hash(input, format, encoding);
        }

        #endregion

        #region ToSha1Hash...

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToSha1Hash(this string input) {
            return SecurityUtils.GetSha1Hash(input);
        }

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToSha1Hash(this string input, HexFormat format) {
            return SecurityUtils.GetSha1Hash(input, format);
        }

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToSha1Hash(this string input, Encoding encoding) {
            return SecurityUtils.GetSha1Hash(input, encoding);
        }

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToSha1Hash(this string input, HexFormat format, Encoding encoding) {
            return SecurityUtils.GetSha1Hash(input, format, encoding);
        }

        #endregion

        #region ToSha256Hash...

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToSha256Hash(this string input) {
            return SecurityUtils.GetSha256Hash(input);
        }

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToSha256Hash(this string input, HexFormat format) {
            return SecurityUtils.GetSha256Hash(input, format);
        }

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToSha256Hash(this string input, Encoding encoding) {
            return SecurityUtils.GetSha256Hash(input, encoding);
        }

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToSha256Hash(this string input, HexFormat format, Encoding encoding) {
            return SecurityUtils.GetSha256Hash(input, format, encoding);
        }

        #endregion

        #region ToSha512Hash...

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToSha512Hash(this string input) {
            return SecurityUtils.GetSha512Hash(input);
        }

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToSha512Hash(this string input, HexFormat format) {
            return SecurityUtils.GetSha512Hash(input, format);
        }

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using
        /// <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToSha512Hash(this string input, Encoding encoding) {
            return SecurityUtils.GetSha512Hash(input, encoding);
        }

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using
        /// <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToSha512Hash(this string input, HexFormat format, Encoding encoding) {
            return SecurityUtils.GetSha512Hash(input, format, encoding);
        }

        #endregion

        #region ToHmacSha1Hash

        /// <summary>
        /// Returns the HMACSHA1 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToHmacSha1Hash(this string value, string key) {
            return SecurityUtils.GetHmacSha1Hash(key, value);
        }

        /// <summary>
        /// Returns the HMACSHA1 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToHmacSha1Hash(this string value, string key, HexFormat format) {
            return SecurityUtils.GetHmacSha1Hash(key, value, format);
        }

        /// <summary>
        /// Returns the HMACSHA1 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToHmacSha1Hash(this string value, string key, Encoding encoding) {
            return SecurityUtils.GetHmacSha1Hash(key, value, encoding);
        }

        /// <summary>
        /// Returns the HMACSHA1 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string ToHmacSha1Hash(this string value, string key, HexFormat format, Encoding encoding) {
            return SecurityUtils.GetHmacSha1Hash(key, value, format, encoding);
        }

        #endregion

        #region ToHmacSha256Hash

        /// <summary>
        /// Returns the HMACSHA256 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToHmacSha256Hash(this string value, string key) {
            return SecurityUtils.GetHmacSha256Hash(key, value);
        }

        /// <summary>
        /// Returns the HMACSHA256 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToHmacSha256Hash(this string value, string key, HexFormat format) {
            return SecurityUtils.GetHmacSha256Hash(key, value, format);
        }

        /// <summary>
        /// Returns the HMACSHA256 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToHmacSha256Hash(this string value, string key, Encoding encoding) {
            return SecurityUtils.GetHmacSha256Hash(key, value, encoding);
        }

        /// <summary>
        /// Returns the HMACSHA256 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string ToHmacSha256Hash(this string value, string key, HexFormat format, Encoding encoding) {
            return SecurityUtils.GetHmacSha256Hash(key, value, format, encoding);
        }

        #endregion

        #region ToHmacSha512Hash

        /// <summary>
        /// Returns the HMACSHA512 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToHmacSha512Hash(this string value, string key) {
            return SecurityUtils.GetHmacSha512Hash(key, value);
        }

        /// <summary>
        /// Returns the HMACSHA512 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToHmacSha512Hash(this string value, string key, HexFormat format) {
            return SecurityUtils.GetHmacSha512Hash(key, value, format);
        }

        /// <summary>
        /// Returns the HMACSHA512 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToHmacSha512Hash(this string value, string key, Encoding encoding) {
            return SecurityUtils.GetHmacSha512Hash(key, value, encoding);
        }

        /// <summary>
        /// Returns the HMACSHA512 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string ToHmacSha512Hash(this string value, string key, HexFormat format, Encoding encoding) {
            return SecurityUtils.GetHmacSha512Hash(key, value, format, encoding);
        }

        #endregion

    }

}

#endif
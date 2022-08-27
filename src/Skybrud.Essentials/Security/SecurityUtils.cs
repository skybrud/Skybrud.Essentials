#if I_CAN_HAZ_SECURITY

using Skybrud.Essentials.Strings;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Skybrud.Essentials.Security {

    /// <summary>
    /// Static class with miscellaneous helper methods.
    /// </summary>
    public static class SecurityUtils {

#region Base64...

        /// <summary>
        /// Base64 encodes the specified <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to be encoded.</param>
        /// <returns>The Base64 encoded string.</returns>
        public static string Base64Encode(string input) {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// Base64 decodes the specified <paramref name="input"/> string.
        /// </summary>
        /// <param name="input">The input string to be decoded.</param>
        /// <returns>The Base64 decoded string.</returns>
        public static string Base64Decode(string input) {
            return Encoding.UTF8.GetString(Convert.FromBase64String(input));
        }

#endregion

#region GetMd5Guid

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static Guid GetMd5Guid(string input) {
            return GetMd5Guid(input, Encoding.UTF8);
        }

        /// <summary>
        /// Gets the MD5 hash of <paramref name="input"/>, and returns that hash. The input string is converted using
        /// <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static Guid GetMd5Guid(string input, Encoding encoding) {
            using MD5 md5 = MD5.Create();
            return new Guid(md5.ComputeHash(encoding.GetBytes(input)));
        }

#endregion

#region GetMd5Hash...

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5Hash(string input) {
            using MD5 md5 = MD5.Create();
            return GetHash(md5, input);
        }

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5Hash(string input, HexFormat format) {
            using MD5 md5 = MD5.Create();
            return GetHash(md5, input, format);
        }

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5Hash(string input, Encoding encoding) {
            using MD5 md5 = MD5.Create();
            return GetHash(md5, input, encoding);
        }

        /// <summary>
        /// Returns the MD5 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5Hash(string input, HexFormat format, Encoding encoding) {
            using MD5 md5 = MD5.Create();
            return GetHash(md5, input, format, encoding);
        }

        /// <summary>
        /// Gets the MD5 hash of the file specified by the <paramref name="path"/>. The hash is a 32-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 32-character hexadecimal number.</returns>
        public static string GetMd5HashFromFile(string path) {
            using MD5 md5 = MD5.Create();
            return GetHashFromFile(md5, path);
        }

#endregion

#region GetSha1Hash...

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1Hash(string input) {
            using SHA1 sha1 = SHA1.Create();
            return GetHash(sha1, input);
        }

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1Hash(string input, HexFormat format) {
            using SHA1 sha1 = SHA1.Create();
            return GetHash(sha1, input, format);
        }

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1Hash(string input, Encoding encoding) {
            using SHA1 sha1 = SHA1.Create();
            return GetHash(sha1, input, encoding);
        }

        /// <summary>
        /// Returns the SHA1 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1Hash(string input, HexFormat format, Encoding encoding) {
            using SHA1 sha1 = SHA1.Create();
            return GetHash(sha1, input, format, encoding);
        }

        /// <summary>
        /// Gets the SHA1 hash of the file specified by the <paramref name="path"/>. The hash is a 40-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetSha1FromFile(string path) {
            using SHA1 sha1 = SHA1.Create();
            return GetHashFromFile(sha1, path);
        }

#endregion

#region GetSha256Hash...

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256Hash(string input) {
            using SHA256 sha256 = SHA256.Create();
            return GetHash(sha256, input);
        }

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256Hash(string input, HexFormat format) {
            using SHA256 sha256 = SHA256.Create();
            return GetHash(sha256, input);
        }

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256Hash(string input, Encoding encoding) {
            using SHA256 sha256 = SHA256.Create();
            return GetHash(sha256, input, encoding);
        }

        /// <summary>
        /// Returns the SHA256 hash of <paramref name="input"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256Hash(string input, HexFormat format, Encoding encoding) {
            using SHA256 sha256 = SHA256.Create();
            return GetHash(sha256, input, encoding);
        }

        /// <summary>
        /// Returns the SHA256 hash of the file specified by the <paramref name="path"/>. The hash is a 64-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetSha256HashFromFile(string path) {
            using SHA256 sha256 = SHA256.Create();
            return GetHashFromFile(sha256, path);
        }

#endregion

#region GetSha512Hash...

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512Hash(string input) {
            using SHA512 sha512 = SHA512.Create();
            return GetHash(sha512, input);
        }

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512Hash(string input, HexFormat format) {
            using SHA512 sha512 = SHA512.Create();
            return GetHash(sha512, input, format);
        }

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using
        /// <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512Hash(string input, Encoding encoding) {
            using SHA512 sha512 = SHA512.Create();
            return GetHash(sha512, input, encoding);
        }

        /// <summary>
        /// Returns the SHA512 hash of <paramref name="input"/>. The input string is converted using
        /// <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512Hash(string input, HexFormat format, Encoding encoding) {
            using SHA512 sha512 = SHA512.Create();
            return GetHash(sha512, input, format, encoding);
        }

        /// <summary>
        /// Returns the SHA512 hash of the file specified by the <paramref name="path"/>. The hash is a 64-character
        /// hexadecimal number.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetSha512HashFromFile(string path) {
            using SHA512 sha512 = SHA512.Create();
            return GetHashFromFile(sha512, path);
        }

#endregion

#region GetHmacSha1Hash

        /// <summary>
        /// Returns the HMACSHA1 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetHmacSha1Hash(string key, string value) {
            return GetHmacSha1Hash(key, value, default, Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HMACSHA1 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetHmacSha1Hash(string key, string value, HexFormat format) {
            return GetHmacSha1Hash(key, value, format, Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HMACSHA1 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 40-character hexadecimal number.</returns>
        public static string GetHmacSha1Hash(string key, string value, Encoding encoding) {
            return GetHmacSha1Hash(key, value, default, encoding);
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
        public static string GetHmacSha1Hash(string key, string value, HexFormat format, Encoding encoding) {
            using HMACSHA1 hmac = new (encoding.GetBytes(key));
            return GetHash(hmac, value, format, encoding);
        }

#endregion

#region GetHmacSha256Hash

        /// <summary>
        /// Returns the HMACSHA256 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetHmacSha256Hash(string key, string value) {
            return GetHmacSha256Hash(key, value, default, Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HMACSHA256 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetHmacSha256Hash(string key, string value, HexFormat format) {
            return GetHmacSha256Hash(key, value, format, Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HMACSHA256 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetHmacSha256Hash(string key, string value, Encoding encoding) {
            return GetHmacSha256Hash(key, value, default, encoding);
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
        public static string GetHmacSha256Hash(string key, string value, HexFormat format, Encoding encoding) {
            using HMACSHA256 hmac = new (encoding.GetBytes(key));
            return GetHash(hmac, value, format, encoding);
        }

#endregion

#region GetHmacSha512Hash

        /// <summary>
        /// Returns the HMACSHA512 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetHmacSha512Hash(string key, string value) {
            return GetHmacSha512Hash(key, value, default, Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HMACSHA512 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetHmacSha512Hash(string key, string value, HexFormat format) {
            return GetHmacSha512Hash(key, value, format, Encoding.UTF8);
        }

        /// <summary>
        /// Returns the HMACSHA512 hash generated from the specified <paramref name="key"/> and
        /// <paramref name="value"/>. The input string is converted using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="key">The key to be used for the hashing.</param>
        /// <param name="value">The input value to be hashed.</param>
        /// <param name="encoding">The encoding to be used for the conversion.</param>
        /// <returns>The hash as a 128-character hexadecimal number.</returns>
        public static string GetHmacSha512Hash(string key, string value, Encoding encoding) {
            return GetHmacSha512Hash(key, value, default, encoding);
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
        public static string GetHmacSha512Hash(string key, string value, HexFormat format, Encoding encoding) {
            using HMACSHA512 hmac = new (encoding.GetBytes(key));
            return GetHash(hmac, value, format, encoding);
        }

#endregion

        /// <summary>
        /// Gets the hash of <paramref name="input"/> using the specified <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="input">The input string to be hashed.</param>
        /// <returns>The hash as a hexadecimal number.</returns>
        public static string GetHash(HashAlgorithm algorithm, string input) {
            return GetHash(algorithm, input, Encoding.UTF8);
        }

        /// <summary>
        /// Gets the hash of <paramref name="input"/> using the specified <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="input">The input string to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a hexadecimal number.</returns>
        public static string GetHash(HashAlgorithm algorithm, string input, HexFormat format) {
            return GetHash(algorithm, input, format, Encoding.UTF8);
        }

        /// <summary>
        /// Gets the hash of <paramref name="input"/> using the specified <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="input">The input string to be hashed.</param>
        /// <param name="encoding">The encoding to be used.</param>
        /// <returns>The hash as a hexadecimal number.</returns>
        public static string GetHash(HashAlgorithm algorithm, string input, Encoding encoding) {
            return BitConverter.ToString(algorithm.ComputeHash(encoding.GetBytes(input))).Replace("-", string.Empty).ToLower();
        }

        /// <summary>
        /// Gets the hash of <paramref name="input"/> using the specified <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="input">The input string to be hashed.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <param name="encoding">The encoding to be used.</param>
        /// <returns>The hash as a hexadecimal number.</returns>
        public static string GetHash(HashAlgorithm algorithm, string input, HexFormat format, Encoding encoding) {
            return StringUtils.ToHexString(algorithm.ComputeHash(encoding.GetBytes(input)), format);
        }

        /// <summary>
        /// Gets the hash of the file specified by the <paramref name="path"/> using the specified
        /// <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="path">The path of the file.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetHashFromFile(HashAlgorithm algorithm, string path) {
            using FileStream stream = File.OpenRead(path);
            return StringUtils.ToHexString(algorithm.ComputeHash(stream));
        }

        /// <summary>
        /// Gets the hash of the file specified by the <paramref name="path"/> using the specified
        /// <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">The algorithm to be used.</param>
        /// <param name="path">The path of the file.</param>
        /// <param name="format">The format to be used for the HEX string.</param>
        /// <returns>The hash as a 64-character hexadecimal number.</returns>
        public static string GetHashFromFile(HashAlgorithm algorithm, string path, HexFormat format) {
            using FileStream stream = File.OpenRead(path);
            return StringUtils.ToHexString(algorithm.ComputeHash(stream), format);
        }

    }

}

#endif
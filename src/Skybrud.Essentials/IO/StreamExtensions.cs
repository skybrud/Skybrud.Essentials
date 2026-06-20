using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable MethodOverloadWithOptionalParameter

namespace Skybrud.Essentials.IO;

/// <summary>
/// Static class with various extension methods for working with <see cref="Stream"/> instances.
/// </summary>
public static class StreamExtensions {

    /// <summary>
    /// Converts the specified <paramref name="stream"/> to a byte array.
    /// </summary>
    /// <param name="stream">The input stream.</param>
    /// <returns>A <see cref="byte"/> array.</returns>
    public static byte[] ToArray(this Stream stream) {
        return StreamUtils.ToArray(stream);
    }

    /// <summary>
    /// Converts the specified <paramref name="stream"/> to a byte array.
    /// </summary>
    /// <param name="stream">The input stream.</param>
    /// <returns>A <see cref="byte"/> array.</returns>
    public static async Task<byte[]> ToArrayAsync(this Stream stream) {
        return await StreamUtils.ToArrayAsync(stream);
    }

    /// <summary>
    /// Creates a new stream based from the specified byte array <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <returns>The created <see cref="Stream"/>.</returns>
    public static Stream ToStream(this byte[] value) {
        return StreamUtils.ToStream(value);
    }

    /// <summary>
    /// Creates a new stream based from the specified string <paramref name="value"/> using UTF-8 as the encoding.
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <returns>The created <see cref="Stream"/>.</returns>
    public static Stream ToStream(this string value) {
        return StreamUtils.ToStream(value, Encoding.UTF8);
    }

    /// <summary>
    /// Returns a string value representing the contents of the stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="encoding">The encoding to be used.</param>
    /// <returns>An instance of <see cref="string"/> representing the contents of the stream.</returns>
    public static string ToString(this Stream stream, Encoding encoding) {
        return StreamUtils.ToString(stream, encoding);
    }

    /// <summary>
    /// Reads the entire contents of the stream and returns it as a string.
    /// </summary>
    /// <param name="stream">The stream to read from. The stream must be readable.</param>
    /// <param name="encoding">The character encoding to use when decoding the stream. If <see langword="null"/>, <see cref="Encoding.UTF8"/> is used.</param>
    /// <returns>A string that contains the contents of the stream.</returns>
    /// <exception cref="ArgumentNullException"> Thrown if <paramref name="stream"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the stream does not support reading.</exception>
    public static string ReadAsString(this Stream stream, Encoding? encoding = null) {
        encoding ??= Encoding.UTF8;
        using StreamReader reader = new(stream, encoding, detectEncodingFromByteOrderMarks: true);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Asynchronously reads the entire contents of the stream and returns it as a string.
    /// </summary>
    /// <param name="stream">The stream to read from. The stream must be readable.</param>
    /// <param name="encoding">The character encoding to use when decoding the stream. If <see langword="null"/>, <see cref="Encoding.UTF8"/> is used.</param>
    /// <returns>A task that represents the asynchronous read operation. The task result contains the contents of the stream as a string.</returns>
    /// <exception cref="ArgumentNullException"> Thrown if <paramref name="stream"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the stream does not support reading.</exception>
    public static async Task<string> ReadAsStringAsync(this Stream stream, Encoding? encoding = null) {
        encoding ??= Encoding.UTF8;
        using StreamReader reader = new(stream, encoding, detectEncodingFromByteOrderMarks: true);
        return await reader.ReadToEndAsync().ConfigureAwait(false);
    }

#if NET5_0_OR_GREATER

    /// <summary>
    /// Reads the entire contents of the stream and returns it as a string.
    /// </summary>
    /// <param name="stream">The stream to read from. The stream must be readable.</param>
    /// <param name="encoding">The character encoding to use when decoding the stream. If <see langword="null"/>, <see cref="Encoding.UTF8"/> is used.</param>
    /// <param name="leaveOpen"><see langword="true"/> to leave the stream open after the operation completes; otherwise, <see langword="false"/> to close the stream.</param>
    /// <returns>A string that contains the contents of the stream.</returns>
    /// <exception cref="ArgumentNullException"> Thrown if <paramref name="stream"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the stream does not support reading.</exception>
    public static string ReadAsString(this Stream stream, Encoding? encoding = null, bool leaveOpen = false) {
        encoding ??= Encoding.UTF8;
        using StreamReader reader = new(stream, encoding, detectEncodingFromByteOrderMarks: true, leaveOpen: leaveOpen);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Asynchronously reads the entire contents of the stream and returns it as a string.
    /// </summary>
    /// <param name="stream">The stream to read from. The stream must be readable.</param>
    /// <param name="encoding">The character encoding to use when decoding the stream. If <see langword="null"/>, <see cref="Encoding.UTF8"/> is used.</param>
    /// <param name="leaveOpen"><see langword="true"/> to leave the stream open after the operation completes; otherwise, <see langword="false"/> to close the stream.</param>
    /// <returns>A task that represents the asynchronous read operation. The task result contains the contents of the stream as a string.</returns>
    /// <exception cref="ArgumentNullException"> Thrown if <paramref name="stream"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the stream does not support reading.</exception>
    public static async Task<string> ReadAsStringAsync(this Stream stream, Encoding? encoding = null, bool leaveOpen = false) {
        encoding ??= Encoding.UTF8;
        using StreamReader reader = new(stream, encoding, detectEncodingFromByteOrderMarks: true, leaveOpen: leaveOpen);
        return await reader.ReadToEndAsync().ConfigureAwait(false);
    }

#endif

}
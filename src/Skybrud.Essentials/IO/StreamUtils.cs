using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Skybrud.Essentials.IO;

/// <summary>
/// Static class with various utility methods for working with streams.
/// </summary>
public static class StreamUtils {

    /// <summary>
    /// Creates a new stream based from the specified byte array <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <returns>The created <see cref="Stream"/>.</returns>
    public static Stream ToStream(byte[] value) {
        return new MemoryStream(value);
    }

    /// <summary>
    /// Creates a new stream based from the specified string <paramref name="value"/> using UTF-8 as the encoding.
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <returns>The created <see cref="Stream"/>.</returns>
    public static Stream ToStream(string value) {
        return ToStream(value, Encoding.UTF8);
    }

    /// <summary>
    /// Creates and returns a new stream based on the specified string <paramref name="value"/> and <paramref name="encoding"/>.
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <param name="encoding">The encoding to be used.</param>
    /// <returns>The created <see cref="Stream"/>.</returns>
    public static Stream ToStream(string value, Encoding encoding) {
        byte[] byteArray = encoding.GetBytes(value);
        return new MemoryStream(byteArray);
    }

    /// <summary>
    /// Returns a string value representing the contents of the specified <paramref name="stream"/> using UTF-8 as the encoding.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>An instance of <see cref="string"/> representing the contents of the stream.</returns>
    public static string ToString(Stream stream) {
        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Returns a string value representing the contents of the specified <paramref name="stream"/> and <paramref name="encoding"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="encoding">The encoding to be used.</param>
    /// <returns>An instance of <see cref="string"/> representing the contents of the stream.</returns>
    public static string ToString(Stream stream, Encoding encoding) {
        using StreamReader reader = new(stream, encoding);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Converts the specified <paramref name="stream"/> to a byte array.
    /// </summary>
    /// <param name="stream">The input stream.</param>
    /// <returns>A <see cref="byte"/> array.</returns>
    public static byte[] ToArray(Stream stream) {
        if (stream is MemoryStream ms) return ms.ToArray();
        using MemoryStream memory = stream.CanSeek ? new MemoryStream((int) stream.Length) : new MemoryStream();
        stream.CopyTo(memory);
        return memory.ToArray();
    }

    /// <summary>
    /// Converts the specified <paramref name="stream"/> to a byte array.
    /// </summary>
    /// <param name="stream">The input stream.</param>
    /// <returns>A <see cref="byte"/> array.</returns>
    public static async Task<byte[]> ToArrayAsync(this Stream stream) {
        if (stream is MemoryStream ms) return ms.ToArray();
        using MemoryStream memory = stream.CanSeek ? new MemoryStream((int) stream.Length) : new MemoryStream();
        await stream.CopyToAsync(memory).ConfigureAwait(false);
        return memory.ToArray();
    }

}
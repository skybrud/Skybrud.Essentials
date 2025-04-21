using System;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Exceptions;

internal static class EssentialsException {

#if NET7_0_OR_GREATER

    public static void ThrowIfNull([NotNull] object? argument, [System.Runtime.CompilerServices.CallerArgumentExpression(nameof(argument))] string? paramName = null) {
        ArgumentNullException.ThrowIfNull(argument, paramName);
    }

    public static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, [System.Runtime.CompilerServices.CallerArgumentExpression(nameof(argument))] string? paramName = null) {
        if (string.IsNullOrWhiteSpace(argument)) ThrowNullOrWhiteSpaceException(argument, paramName);
    }

    [DoesNotReturn]
    private static void ThrowNullOrWhiteSpaceException(string? argument, string? paramName) {
        ArgumentNullException.ThrowIfNull(argument, paramName);
        throw new ArgumentException($"The value cannot be an empty string or composed entirely of whitespace. (Parameter '{paramName}')", paramName);
    }

#else

    public static void ThrowIfNull([NotNull] object? argument, string? paramName = null) {
        if (argument is null) throw new ArgumentNullException(paramName);
    }

    public static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, string? paramName = null) {
        if (string.IsNullOrWhiteSpace(argument)) ThrowNullOrWhiteSpaceException(argument, paramName);
    }

    [DoesNotReturn]
    private static void ThrowNullOrWhiteSpaceException(string? argument, string? paramName) {
        if (argument is null) throw new ArgumentNullException(paramName);
        throw new ArgumentException($"The value cannot be an empty string or composed entirely of whitespace. (Parameter '{paramName}')", paramName);
    }

#endif

}
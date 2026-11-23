using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Skybrud.Essentials;

/// <remarks>
/// This is here since we're still targeting .NET Standard in which we can't call something like <c>ArgumentException.ThrowIfNullOrWhiteSpace(input)</c>.
/// </remarks>
internal static class Guard {

    public static void ThrowIfNull([NotNull] object? value, [CallerArgumentExpression(nameof(value))] string? paramName = null) {
        if (value is null) throw new ArgumentNullException(paramName);
    }

    public static void ThrowIfNullOrWhiteSpace([NotNull] string? value, [CallerArgumentExpression(nameof(value))] string? paramName = null) {
        if (value is null) throw new ArgumentNullException(paramName);
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Value cannot be empty or whitespace.", paramName);
    }

}
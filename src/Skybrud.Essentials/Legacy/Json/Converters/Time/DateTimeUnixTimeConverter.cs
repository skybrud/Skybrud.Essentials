using System;

#pragma warning disable IDE0130 // Namespace does not match file name
// ReSharper disable CheckNamespace

namespace Skybrud.Essentials.Json.Converters.Time;

/// <summary>
/// Converts an instance of <see cref="DateTime"/> to and from a Unix timestamp.
/// </summary>
[Obsolete("Use UnixTimeConverter instead.")]
public class DateTimeUnixTimeConverter : UnixTimeConverter { }
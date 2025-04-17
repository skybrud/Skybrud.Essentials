using System;
using Skybrud.Essentials.Time;

#pragma warning disable IDE0130 // Namespace does not match file name
// ReSharper disable CheckNamespace

namespace Skybrud.Essentials.Json.Converters.Time;

/// <summary>
/// Converts an instance of <see cref="EssentialsDateTime"/> to and from a Unix timestamp.
/// </summary>
[Obsolete("Use UnixTimeConverter instead.")]
public class EssentialsDateTimeUnixTimeConverter : UnixTimeConverter { }
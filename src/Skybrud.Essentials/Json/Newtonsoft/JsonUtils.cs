using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections.Enumerables.Extensions;
using Skybrud.Essentials.Common;

namespace Skybrud.Essentials.Json.Newtonsoft;

/// <summary>
/// Utility class with various static helper methods for working with JSON.
/// </summary>
public static partial class JsonUtils {

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance <see cref="JToken"/>.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static JToken ParseJsonToken(string json) {

        // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
        // really read as strings without some localization going on. Since this is kinda annoying, and we don't
        // really need it, we can luckily disable it with the lines below
        return JToken.Load(new JsonTextReader(new StringReader(json)) {
            DateParseHandling = DateParseHandling.None
        });

    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance <typeparamref name="T"/>.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static T ParseJsonToken<T>(string json) {
        return ParseJsonToken(json).ToObject<T>();
    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to be returned.</typeparam>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JToken"/> into
    /// an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static T ParseJsonToken<T>(string json, Func<JToken, T> func) {
        return func(ParseJsonObject(json));
    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance <see cref="JObject"/>.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <returns>An instance of <see cref="JObject"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static JObject ParseJsonObject(string json) {

        // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
        // really read as strings without some localization going on. Since this is kinda annoying, and we don't
        // really need it, we can luckily disable it with the lines below
        return JObject.Load(new JsonTextReader(new StringReader(json)) {
            DateParseHandling = DateParseHandling.None
        });

    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance <typeparamref name="T"/>.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static T ParseJsonObject<T>(string json) {
        return ParseJsonObject(json).ToObject<T>();
    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to be returned.</typeparam>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
    /// an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
        return func(ParseJsonObject(json));
    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance of <paramref name="objectType"/>.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <param name="objectType">The type of the object.</param>
    public static object ParseJsonObject(string json, Type objectType) {
        return ParseJsonObject(json).ToObject(objectType);
    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an instance of <see cref="JArray"/>.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <returns>An instance of <see cref="JArray"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static JArray ParseJsonArray(string json) {

        // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
        // really read as strings without some localization going on. Since this is kinda annoying, and we don't
        // really need it, we can luckily disable it with the lines below
        return JArray.Load(new JsonTextReader(new StringReader(json)) {
            DateParseHandling = DateParseHandling.None
        });

    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
    /// an instance of <typeparamref name="T"/>.</param>
    /// <returns>An array of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
        return [.. from JObject item in ParseJsonArray(json) select func(item)];
    }

    /// <summary>
    /// Parses the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type that each item should be parsed into.</typeparam>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <returns>An array of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
    public static T[] ParseJsonArray<T>(string json) {
        return [..from JObject item in ParseJsonArray(json) select item.ToObject<T>()];
    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <see cref="JToken"/>.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="JToken"/> if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonToken(string? json, [NotNullWhen(true)] out JToken? result) {

        if (json is null) {
            result = null;
            return false;
        }

        try {
            result = ParseJsonToken(json);
            return true;
        } catch (Exception) {
            result = null;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the output object.</typeparam>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="JToken"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonToken<T>(string? json, [NotNullWhen(true)] out T? result) {

        if (json is null) {
            result = default;
            return false;
        }

        try {
            result = ParseJsonToken<T>(json);
            return result is not null;
        } catch (Exception) {
            result = default;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the output object.</typeparam>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="callback">A callback function used for converting a <see cref="JToken"/> into an instance of <typeparamref name="T"/>.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="JToken"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonToken<T>(string? json, Func<JToken, T> callback, [NotNullWhen(true)] out T? result) {

        if (json is null) {
            result = default;
            return false;
        }

        try {

            if (TryParseJsonToken(json, out JToken? temp)) {
                result = callback(temp);
                return result is not null;
            }

            result = default;
            return false;

        } catch (Exception) {

            result = default;
            return false;

        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <see cref="JObject"/>.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="JObject"/> if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonObject(string? json, [NotNullWhen(true)] out JObject? result) {

        if (json is null) {
            result = null;
            return false;
        }

        try {
            result = ParseJsonObject(json);
            return true;
        } catch (Exception) {
            result = null;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the output object.</typeparam>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="JObject"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonObject<T>(string? json, [NotNullWhen(true)] out T? result) {

        if (json is null) {
            result = default;
            return false;
        }

        try {
            result = ParseJsonObject<T>(json);
            return result is not null;
        } catch (Exception) {
            result = default;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the output object.</typeparam>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="callback">A callback function used for converting a <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="JObject"/> if successful; otherwise, the default value of <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonObject<T>(string? json, Func<JObject, T> callback, [NotNullWhen(true)] out T? result) {

        if (json is null) {
            result = default;
            return false;
        }

        try {
            if (TryParseJsonObject(json, out JObject? temp)) {
                result = callback(temp);
                return result is not null;
            }
            result = default;
            return false;
        } catch (Exception) {
            result = default;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <see cref="JArray"/>.
    /// </summary>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="result">When this method returns, holds the parsed <see cref="JArray"/> if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonArray(string? json, [NotNullWhen(true)] out JArray? result) {

        if (json is null) {
            result = null;
            return false;
        }

        try {
            result = ParseJsonArray(json);
            return true;
        } catch (Exception) {
            result = null;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the output Array.</typeparam>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="result">When this method returns, holds the parsed array of <typeparamref name="T"/> if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonArray<T>(string? json, [NotNullWhen(true)] out T[]? result) {

        if (json is null) {
            result = null;
            return false;
        }

        try {
            result = ParseJsonArray<T>(json);
            return true;
        } catch (Exception) {
            result = null;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the output array.</typeparam>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="callback">A callback function used for converting a <see cref="JArray"/> into an instance of <typeparamref name="T"/>.</param>
    /// <param name="result">When this method returns, holds the parsed array of <typeparamref name="T"/> if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonArray<T>(string? json, Func<JArray, T[]> callback, [NotNullWhen(true)] out T[]? result) {

        if (json is null) {
            result = null;
            return false;
        }

        try {
            if (TryParseJsonArray(json, out JArray? temp)) {
                result = callback(temp);
                return true;
            }
            result = null;
            return false;
        } catch (Exception) {
            result = null;
            return false;
        }

    }

    /// <summary>
    /// Attempts to parse the specified <paramref name="json"/> string into an array of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the output array.</typeparam>
    /// <param name="json">The JSON string to parse.</param>
    /// <param name="callback">A callback function used for converting the individual <see cref="JObject"/> of the parsed array into instances of <typeparamref name="T"/>.</param>
    /// <param name="result">When this method returns, holds the parsed array of <typeparamref name="T"/> if successful; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise, <c>false</c>.</returns>
    public static bool TryParseJsonArray<T>(string? json, Func<JObject, T> callback, [NotNullWhen(true)] out T[]? result) {

        if (json is null) {
            result = null;
            return false;
        }

        try {
            if (TryParseJsonArray(json, out JArray? temp)) {
                result = [.. temp.OfType<JObject>().Select(callback)];
                return true;
            }
            result = null;
            return false;
        } catch (Exception) {
            result = null;
            return false;
        }

    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>An instance of <see cref="JToken"/>.</returns>
    public static JToken LoadJsonToken(Stream stream) {
        using StreamReader reader = new(stream);
        using JsonTextReader jsonTextReader = new(reader);
        jsonTextReader.DateParseHandling = DateParseHandling.None;
        return JToken.Load(jsonTextReader);
    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="objectType">The type the JSON token should be converted to.</param>
    /// <returns>An instance of <paramref name="objectType"/>.</returns>
    public static object LoadJsonToken(Stream stream, Type objectType) {
        return LoadJsonToken(stream).ToObject(objectType);
    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to be returned.</typeparam>
    /// <param name="stream">The stream.</param>
    /// <returns>An instance of <typeparamref name="TResult"/>.</returns>
    public static TResult LoadJsonToken<TResult>(Stream stream) {
        return LoadJsonToken(stream).ToObject<TResult>();
    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to which the JSON token should be converted.</typeparam>
    /// <param name="stream">The stream.</param>
    /// <param name="func">A callback function used for converting the JSON token.</param>
    /// <returns>An instance of <typeparamref name="TResult"/>.</returns>
    public static TResult LoadJsonToken<TResult>(Stream stream, Func<JToken, TResult> func) {
        return func(LoadJsonToken(stream));
    }

    /// <summary>
    /// Loads and parses the JSON object from the specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>An instance of <see cref="JObject"/>.</returns>
    public static JObject LoadJsonObject(Stream stream) {
        using StreamReader reader = new(stream);
        using JsonTextReader jsonTextReader = new(reader);
        jsonTextReader.DateParseHandling = DateParseHandling.None;
        return JObject.Load(jsonTextReader);
    }

    /// <summary>
    /// Loads and parses the JSON object from the specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="objectType">The type the JSON object should be converted to.</param>
    /// <returns>An instance of <paramref name="objectType"/>.</returns>
    public static object LoadJsonObject(Stream stream, Type objectType) {
        return LoadJsonObject(stream).ToObject(objectType);
    }

    /// <summary>
    /// Loads and parses the JSON object from the specified <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to be returned.</typeparam>
    /// <param name="stream">The stream.</param>
    /// <returns>An instance of <typeparamref name="TResult"/>.</returns>
    public static TResult LoadJsonObject<TResult>(Stream stream) {
        return LoadJsonObject(stream).ToObject<TResult>();
    }

    /// <summary>
    /// Loads and parses the JSON object from the specified <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TResult">The type to which the JSON object should be converted.</typeparam>
    /// <param name="stream">The stream.</param>
    /// <param name="func">A callback function used for converting the JSON object.</param>
    /// <returns>An instance of <typeparamref name="TResult"/>.</returns>
    public static TResult LoadJsonObject<TResult>(Stream stream, Func<JObject, TResult> func) {
        return func(LoadJsonObject(stream));
    }

    /// <summary>
    /// Loads and parses the JSON array from the specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>An instance of <see cref="JToken"/>.</returns>
    public static JArray LoadJsonArray(Stream stream) {
        using StreamReader reader = new(stream);
        using JsonTextReader jsonTextReader = new(reader);
        jsonTextReader.DateParseHandling = DateParseHandling.None;
        return JArray.Load(jsonTextReader);
    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="objectType">The type of the array.</param>
    /// <returns>An array of <paramref name="objectType"/>.</returns>
    public static object LoadJsonArray(Stream stream, Type objectType) {
        return LoadJsonArray(stream).ToObject(objectType);
    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TItem">The type of the items in the array.</typeparam>
    /// <param name="stream">The stream.</param>
    /// <returns>An array of <typeparamref name="TItem"/>.</returns>
    public static TItem[] LoadJsonArray<TItem>(Stream stream) {
        return LoadJsonArray(stream).ToObject<TItem[]>();
    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TItem">The type of the items in the array.</typeparam>
    /// <param name="stream">The stream.</param>
    /// <param name="func">A callback function for converting each item to an instance of <typeparamref name="TItem"/>.</param>
    /// <returns>An array of <typeparamref name="TItem"/>.</returns>
    public static TItem[] LoadJsonArray<TItem>(Stream stream, Func<JObject, TItem> func) {
        return LoadJsonArray(stream).OfType<JObject>().Select(func).ToArray();
    }

    /// <summary>
    /// Loads and parses the JSON token from the specified <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="TResult">The type returned by the conversion.</typeparam>
    /// <param name="stream">The stream.</param>
    /// <param name="func">A callback function used for converting the JSON array.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> representing the array.</returns>
    public static TResult LoadJsonArray<TResult>(Stream stream, Func<JArray, TResult> func) {
        return func(LoadJsonArray(stream));
    }

#if I_CAN_HAZ_FILE

    /// <summary>
    /// Loads and parses the JSON token in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <see cref="JObject"/>.</returns>
    public static JToken LoadJsonToken(string path) {
        return ParseJsonToken(File.ReadAllText(path, Encoding.UTF8));
    }

    /// <summary>
    /// Loads and parses the JSON token in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="objectType">The type the JSON token should be converted to.</param>
    /// <returns>An instance of <paramref name="objectType"/>.</returns>
    public static object LoadJsonToken(string path, Type objectType) {
        return LoadJsonToken(path).ToObject(objectType);
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T LoadJsonToken<T>(string path) {
        return LoadJsonToken(path).ToObject<T>();
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type to be returned.</typeparam>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JToken"/> into
    /// an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T LoadJsonToken<T>(string path, Func<JToken, T> func) {
        return ParseJsonToken(File.ReadAllText(path, Encoding.UTF8), func);
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <see cref="JObject"/>.</returns>
    public static JObject LoadJsonObject(string path) {
        return ParseJsonObject(File.ReadAllText(path, Encoding.UTF8));
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T LoadJsonObject<T>(string path) {
        return LoadJsonObject(path).ToObject<T>();
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="objectType">The type of the object.</param>
    public static object LoadJsonObject(string path, Type objectType) {
        return LoadJsonObject(path).ToObject(objectType);
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type to be returned.</typeparam>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
    /// an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T LoadJsonObject<T>(string path, Func<JObject, T> func) {
        return ParseJsonObject(File.ReadAllText(path, Encoding.UTF8), func);
    }

    /// <summary>
    /// Loads and parses the JSON array in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An instance of <see cref="JArray"/>.</returns>
    public static JArray LoadJsonArray(string path) {
        return ParseJsonArray(File.ReadAllText(path, Encoding.UTF8));
    }

    /// <summary>
    /// Loads and parses the JSON array at the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="objectType">The type of the items in the array.</param>
    /// <returns>An array of <paramref name="objectType"/>.</returns>
    public static Array LoadJsonArray(string path, Type objectType) {
        return LoadJsonArray(path).Select(x => x.ToObject(objectType)).ToArray(objectType);
    }

    /// <summary>
    /// Loads and parses the JSON array at the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="TItem">The type of the items in the array.</typeparam>
    /// <param name="path">The path to the JSON file.</param>
    /// <returns>An array of <typeparamref name="TItem"/>.</returns>
    public static TItem[] LoadJsonArray<TItem>(string path) {
        return LoadJsonArray(path).ToObject<TItem[]>();
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="T">The type to be returned.</typeparam>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into
    /// an instance of <typeparamref name="T"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    public static T[] LoadJsonArray<T>(string path, Func<JObject, T> func) {
        return ParseJsonArray(File.ReadAllText(path, Encoding.UTF8), func);
    }

    /// <summary>
    /// Loads and parses the JSON object in the file at the specified <paramref name="path"/>.
    /// </summary>
    /// <typeparam name="TResult">The type returned by the conversion.</typeparam>
    /// <param name="path">The path to the JSON file.</param>
    /// <param name="func">A callback function used for converting the JSON array.</param>
    /// <returns>An instance of <typeparamref name="TResult"/> representing the array.</returns>
    public static TResult LoadJsonArray<TResult>(string path, Func<JArray, TResult> func) {
        return func(LoadJsonArray(path));
    }

    /// <summary>
    /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
    public static void SaveJsonObject(string path, JsonObjectBase obj) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        SaveJsonObject(path, obj, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="obj">The instance of <see cref="JsonObjectBase"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonObject(string path, JsonObjectBase obj, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (obj.JObject == null) throw new PropertyNotSetException(nameof(obj.JObject));
        SaveJsonObject(path, obj.JObject, formatting);
    }

    /// <summary>
    /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="obj">The instance of <see cref="JObject"/> to be saved.</param>
    public static void SaveJsonObject(string path, JObject obj) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        SaveJsonObject(path, obj, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="obj"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="obj">The instance of <see cref="JObject"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonObject(string path, JObject obj, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        File.WriteAllText(path, obj.ToString(formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The instance of <see cref="JObject"/> to be saved.</param>
    public static void SaveJsonArray(string path, JArray array) {
        SaveJsonArray(path, array, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <see cref="JArray"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The instance of <see cref="JObject"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray(string path, JArray array, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (array == null) throw new ArgumentNullException(nameof(array));
        File.WriteAllText(path, array.ToString(formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JObject"/> to be saved.</param>
    public static void SaveJsonArray(string path, JObject[] array) {
        SaveJsonArray(path, array, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JObject"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray(string path, JObject[] array, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (array == null) throw new ArgumentNullException(nameof(array));
        File.WriteAllText(path, JsonConvert.SerializeObject(array, formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
    /// doesn't already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="collection">The collection of <see cref="JObject"/> to be saved.</param>
    public static void SaveJsonArray(string path, IEnumerable<JObject> collection) {
        SaveJsonArray(path, collection, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
    /// doesn't already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="collection">The collection of <see cref="JObject"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray(string path, IEnumerable<JObject> collection, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        File.WriteAllText(path, JsonConvert.SerializeObject(collection, formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JToken"/> to be saved.</param>
    public static void SaveJsonArray(string path, JToken[] array) {
        SaveJsonArray(path, array, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JToken"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray(string path, JToken[] array, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (array == null) throw new ArgumentNullException(nameof(array));
        File.WriteAllText(path, JsonConvert.SerializeObject(array, formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
    /// doesn't already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="collection">The collection of <see cref="JToken"/> to be saved.</param>
    public static void SaveJsonArray(string path, IEnumerable<JToken> collection) {
        SaveJsonArray(path, collection, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
    /// doesn't already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="collection">The collection of <see cref="JToken"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray(string path, IEnumerable<JToken> collection, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        File.WriteAllText(path, JsonConvert.SerializeObject(collection, formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
    public static void SaveJsonArray(string path, JsonObjectBase[] array) {
        SaveJsonArray(path, array, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray(string path, JsonObjectBase[] array, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (array == null) throw new ArgumentNullException(nameof(array));
        File.WriteAllText(path, JsonConvert.SerializeObject(from item in array select item?.JObject, formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
    public static void SaveJsonArray<T>(string path, T[] array) where T : JsonObjectBase {
        SaveJsonArray(path, array, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="array"/> to the file at <paramref name="path"/>. If the file doesn't
    /// already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="array">The array of <see cref="JsonObjectBase"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray<T>(string path, T[] array, Formatting formatting) where T : JsonObjectBase {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (array == null) throw new ArgumentNullException(nameof(array));
        File.WriteAllText(path, JsonConvert.SerializeObject(from item in array select item?.JObject, formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
    /// doesn't already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="collection">The collection of <see cref="JsonObjectBase"/> to be saved.</param>
    public static void SaveJsonArray(string path, IEnumerable<JsonObjectBase> collection) {
        SaveJsonArray(path, collection, Formatting.None);
    }

    /// <summary>
    /// Saves the specified <paramref name="collection"/> to the file at <paramref name="path"/>. If the file
    /// doesn't already exist, a new file will be created.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="collection">The collection of <see cref="JsonObjectBase"/> to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the object.</param>
    public static void SaveJsonArray(string path, IEnumerable<JsonObjectBase> collection, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        File.WriteAllText(path, JsonConvert.SerializeObject(from item in collection select item?.JObject, formatting), Encoding.UTF8);
    }

    /// <summary>
    /// Saves <paramref name="token"/> to the specified <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="token">The JSON token to be saved.</param>
    public static void SaveJsonToken(string path, JToken token) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (token == null) throw new ArgumentNullException(nameof(token));
        SaveJsonToken(path, token, Formatting.None);
    }

    /// <summary>
    /// Saves <paramref name="token"/> to the specified <paramref name="path"/> using <paramref name="formatting"/>.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="token">The JSON token to be saved.</param>
    /// <param name="formatting">The formatting to be used when saving the token.</param>
    public static void SaveJsonToken(string path, JToken token, Formatting formatting) {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
        if (token == null) throw new ArgumentNullException(nameof(token));
        File.WriteAllText(path, token.ToString(formatting), Encoding.UTF8);
    }

#endif

}
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Skybrud.Essentials.Json.Newtonsoft.Parsing {

    internal static partial class JsonTokenUtils {

        internal static T[]? ConvertTokenToArray<T>(JToken? token, Func<JToken, T> callback) {

            if (token is not JArray array) return null;
            if (array.Count == 0) return ArrayUtils.Empty<T>();

            List<T> temp = new();

            foreach (JToken item in array) {
                temp.Add(callback(item));
            }

            return temp.ToArray();

        }

        internal static T[]? ConvertTokenToArray<T>(JToken? token, Func<JObject, T> callback) {

            if (token is not JArray array) return null;
            if (array.Count == 0) return ArrayUtils.Empty<T>();

            List<T> temp = new();

            foreach (JToken item in array) {
                if (item is JObject obj) temp.Add(callback(obj));
            }

            return temp.ToArray();

        }

        internal static IReadOnlyList<T> ConvertTokenToReadOnlyList<T>(JToken? token, Func<JObject, T> callback) {

            if (token is not JArray array || array.Count == 0) return ArrayUtils.Empty<T>();

            List<T> temp = new();

            foreach (JToken item in array) {
                if (item is JObject obj) temp.Add(callback(obj));
            }

            return temp;

        }

    }

}
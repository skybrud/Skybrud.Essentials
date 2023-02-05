using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Parsing;

namespace Skybrud.Essentials.Json.Newtonsoft.Extensions {

    public static partial class NewtonsoftJsonObjectExtensions {

        /// <summary>
        /// Returns the enum of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetEnum<T>(this JObject? json, string propertyName) where T : Enum {
            return JsonTokenUtils.GetEnum<T>(json?[propertyName]);
        }

        /// <summary>
        /// Returns the enum of type <typeparamref name="T"/> from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetEnum<T>(this JObject? json, string propertyName, T fallback) where T : Enum {
            return JsonTokenUtils.GetEnum(json?[propertyName], fallback);
        }

        /// <summary>
        /// Returns the enum of type <typeparamref name="TEnum"/> from the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <typeparamref name="TEnum"/> if successful; otherwise, <see langword="null"/>.</returns>
        public static TEnum? GetEnumOrNull<TEnum>(this JObject? json, string propertyName) where TEnum : struct, Enum {
            return JsonTokenUtils.GetEnumOrNull<TEnum>(json?[propertyName]);
        }

        /// <summary>
        /// Returns the enum of type <typeparamref name="T"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetEnumByPath<T>(this JObject? json, string path) where T : Enum {
            return JsonTokenUtils.GetEnum<T>(json?.SelectToken(path));
        }

        /// <summary>
        /// Returns the enum of type <typeparamref name="T"/> value of the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="json">The parent JSON object.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetEnumByPath<T>(this JObject? json, string path, T fallback) where T : Enum {
            return JsonTokenUtils.GetEnum(json?.SelectToken(path), fallback);
        }

    }

}
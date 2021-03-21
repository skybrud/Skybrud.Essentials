using System;
using System.Reflection;

namespace Skybrud.Essentials.Reflection.Extensions {
    
    /// <summary>
    /// Extension methods for working with reflection.
    /// </summary>
    public static class ReflectionExtensions {

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this Enum value) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute<T>(value);
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <c>null</c> if no matches.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this Enum value, out T result) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute(value, out result);
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><c>true</c>c> if one or more attributes are found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttributes<T>(this Enum value, out T[] result) where T : Attribute {
            return ReflectionUtils.HasCustomAttributes(value, out result);
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="value">The enum value to get the attribute for.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.</returns>
        public static T GetCustomAttribute<T>(this Enum value) where T : Attribute {
            return ReflectionUtils.GetCustomAttribute<T>(value);
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="value">The enum value to get attributes for.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(this Enum value) where T : Attribute {
            return ReflectionUtils.GetCustomAttributes<T>(value);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="member">The member info.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this MemberInfo member) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute<T>(member);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="member">The member info.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <c>null</c> if no matches.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this MemberInfo member, out T result) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute(member, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="member">The member info.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><c>true</c>c> if one or more attributes are found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttributes<T>(this MemberInfo member, out T[] result) where T : Attribute {
            return ReflectionUtils.HasCustomAttributes(member, out result);
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="member">The member holding the attribute.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.</returns>
        public static T GetCustomAttribute<T>(this MemberInfo member) where T : Attribute {
            return ReflectionUtils.GetCustomAttribute<T>(member);
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="member">The member holding the attributes.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(this MemberInfo member) where T : Attribute {
            return ReflectionUtils.GetCustomAttributes<T>(member);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="type">The type holding the attribute.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this Type type) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute<T>(type);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="type">The type holding the attribute.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <c>null</c> if no matches.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(this Type type, out T result) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute(type, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="type">The type holding the attributes.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><c>true</c>c> if one or more attributes are found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttributes<T>(this Type type, out T[] result) where T : Attribute {
            return ReflectionUtils.HasCustomAttributes(type, out result);
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="type">The type holding the attribute.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.</returns>
        public static T GetCustomAttribute<T>(this Type type) where T : Attribute {
            return ReflectionUtils.GetCustomAttribute<T>(type);
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="type">The type holding the attributes.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(this Type type) where T : Attribute {
            return ReflectionUtils.GetCustomAttributes<T>(type);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member" /> is marked as obsolete.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(this MemberInfo member) {
            return ReflectionUtils.IsObsolete(member, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member" /> is marked as obsolete.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the member has been marked as obsolete.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(MemberInfo member, out ObsoleteAttribute attribute) {
            return ReflectionUtils.IsObsolete(member, out attribute);
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value" /> is marked as obsolete.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns><c>true</c> if the enum value has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(this Enum value) {
            return ReflectionUtils.IsObsolete(value, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="value" /> is marked as obsolete.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the enum value has been marked as obsolete.</param>
        /// <returns><c>true</c> if the enum value has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(this Enum value, out ObsoleteAttribute attribute) {
            return ReflectionUtils.IsObsolete(value, out attribute);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type" /> is marked as obsolete.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(this Type type) {
            return ReflectionUtils.IsObsolete(type, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type" /> is marked as obsolete.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the type has been marked as obsolete.</param>
        /// <returns><c>true</c> if the type has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(Type type, out ObsoleteAttribute attribute) {
            return ReflectionUtils.IsObsolete(type, out attribute);
        }

    }

}
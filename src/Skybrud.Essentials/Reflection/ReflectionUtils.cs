﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Skybrud.Essentials.Collections;

namespace Skybrud.Essentials.Reflection {

    /// <summary>
    /// Static utility class for working with reflection.
    /// </summary>
    public static class ReflectionUtils {

        /// <summary>
        /// Returns the version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the version of the assembly.</returns>
        public static string GetVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            return assembly.GetName().Version?.ToString()!;
        }

#if I_CAN_HAZ_FILE_VERSION_INFO

        /// <summary>
        /// Returns the version of the assembly of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A string representing the version of the assembly.</returns>
        public static string GetVersion(Type type) {
            return GetVersion(type.Assembly);
        }

        /// <summary>
        /// Returns the version of the assembly of the specified <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A type used for finding the underlying assembly.</typeparam>
        /// <returns>A string representing the version of the assembly.</returns>
        public static string GetVersion<T>() {
            return GetVersion(typeof(T).Assembly);
        }

        /// <summary>
        /// Returns the file version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the file version of the assembly.</returns>
        public static string GetFileVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion!;
        }

        /// <summary>
        /// Returns the file version of the assembly of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A string representing the file version of the assembly.</returns>
        public static string GetFileVersion(Type type) {
            return GetFileVersion(type.Assembly);
        }

        /// <summary>
        /// Returns the file version of the assembly of the specified <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A type used for finding the underlying assembly.</typeparam>
        /// <returns>A string representing the file version of the assembly.</returns>
        public static string GetFileVersion<T>() {
            return GetFileVersion(typeof(T).Assembly);
        }

        /// <summary>
        /// Returns the informational version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the informational version of the assembly.</returns>
        public static string GetInformationalVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion!;
        }

        /// <summary>
        /// Returns the informational version of the assembly of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A string representing the informational version of the assembly.</returns>
        public static string GetInformationalVersion(Type type) {
            return GetInformationalVersion(type.Assembly);
        }

        /// <summary>
        /// Returns the informational version of the assembly of the specified <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A type used for finding the underlying assembly.</typeparam>
        /// <returns>A string representing the informational version of the assembly.</returns>
        public static string GetInformationalVersion<T>() {
            return GetInformationalVersion(typeof(T).Assembly);
        }

        /// <summary>
        /// Returns an instance of <see cref="FileVersionInfo"/> with information about the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>An instance of <see cref="FileVersionInfo"/>.</returns>
        public static FileVersionInfo GetFileVersionInfo(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location);
        }

        /// <summary>
        /// Returns an instance of <see cref="FileVersionInfo"/> with information about the assembly of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>An instance of <see cref="FileVersionInfo"/>.</returns>
        public static FileVersionInfo GetFileVersionInfo(Type type) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return GetFileVersionInfo(type.Assembly);
        }

        /// <summary>
        /// Returns an instance of <see cref="FileVersionInfo"/> with information about the assembly of the specified <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A type used for finding the underlying assembly.</typeparam>
        /// <returns>An instance of <see cref="FileVersionInfo"/>.</returns>
        public static FileVersionInfo GetFileVersionInfo<T>() {
            return GetFileVersionInfo(typeof(T).Assembly);
        }

#endif

        /// <summary>
        /// Returns whether <typeparamref name="T"/> is a class type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <returns><c>true</c> if <typeparamref name="T"/> is a class type; otherwise <c>false</c>.</returns>
        public static bool IsClass<T>() {
            return IsClass(typeof(T));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> is a class type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if <paramref name="type"/> is a class type; otherwise <c>false</c>.</returns>
        public static bool IsClass(Type? type) {
            return type is not null && type.GetTypeInfo().IsClass;
        }

        /// <summary>
        /// Returns whether <typeparamref name="T"/> is an interface type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <returns><c>true</c> if <typeparamref name="T"/> is an interface type; otherwise <c>false</c>.</returns>
        public static bool IsInterface<T>() {
            return IsInterface(typeof(T));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> is an interface type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if <paramref name="type"/> is an interface type; otherwise <c>false</c>.</returns>
        public static bool IsInterface(Type? type) {
            return type is not null && type.GetTypeInfo().IsInterface;
        }

        /// <summary>
        /// Returns whether <typeparamref name="T"/> is an enum.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <returns><c>true</c> if <typeparamref name="T"/> is an enum; otherwise <c>false</c>.</returns>
        public static bool IsEnum<T>() {
            return IsEnum(typeof(T));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> is an enum.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if <paramref name="type"/> is an enum; otherwise <c>false</c>.</returns>
        public static bool IsEnum(Type? type) {
            return type is not null && type.GetTypeInfo().IsEnum;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member" /> is marked as obsolete.
        /// </summary>
        /// <param name="member">The method.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(MemberInfo? member) {
            return IsObsolete(member, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member" /> is marked as obsolete.
        /// </summary>
        /// <param name="member">The method.</param>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the member has been marked as obsolete.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(MemberInfo? member, [NotNullWhen(true)] out ObsoleteAttribute? attribute) {
            attribute = member?.GetCustomAttributes(true).OfType<ObsoleteAttribute>().FirstOrDefault();
            return attribute != null;
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value" /> is marked as obsolete.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns><c>true</c> if the enum value has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(Enum value) {
            return IsObsolete(value, out _);
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value" /> is marked as obsolete.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the member has been marked as obsolete.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(Enum value, [NotNullWhen(true)] out ObsoleteAttribute? attribute) {
            attribute = GetCustomAttribute<ObsoleteAttribute>(value);
            return attribute != null;
        }

        /// <summary>
        /// Returns whether <paramref name="type"/> is marked as obsolete.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(Type? type) {
            return IsObsolete(type, out _);
        }

        /// <summary>
        /// Returns whether <paramref name="type"/> is marked as obsolete.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the type has been marked as obsolete.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(Type? type, [NotNullWhen(true)] out ObsoleteAttribute? attribute) {
            attribute = type?.GetTypeInfo().GetCustomAttributes(true).OfType<ObsoleteAttribute>().FirstOrDefault();
            return attribute != null;
        }

        /// <summary>
        /// Returns whether <typeparamref name="T"/> is marked as obsolete.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete<T>() {
            return IsObsolete<T>(out _);
        }

        /// <summary>
        /// Returns whether <typeparamref name="T"/> is marked as obsolete.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the type has been marked as obsolete.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete<T>([NotNullWhen(true)] out ObsoleteAttribute? attribute) {
            attribute = typeof(T).GetTypeInfo().GetCustomAttributes(true).OfType<ObsoleteAttribute>().FirstOrDefault();
            return attribute != null;
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(Enum value) where T : Attribute {
            return HasCustomAttribute<T>(value, out _);
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <c>null</c> if no matches.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(Enum value, [NotNullWhen(true)] out T? result) where T : Attribute {
            result = GetCustomAttributes<T>(value).FirstOrDefault();
            return result != null;
        }

        /// <summary>
        /// Returns whether the specified enum <paramref name="value"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><c>true</c>c> if one or more attributes are found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttributes<T>(Enum value, [NotNullWhen(true)] out T[]? result) where T : Attribute {
            result = GetCustomAttributes<T>(value);
            return result.Length > 0;
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="value">The enum value to get the attribute for.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.</returns>
        public static T? GetCustomAttribute<T>(Enum value) where T : Attribute {

            // Get the member of the enum value
            MemberInfo? member = value.GetType().GetTypeInfo().GetDeclaredField(value.ToString());

            // Return an array of the found attributes
            return member?
                .GetCustomAttributes<T>(false)
                .FirstOrDefault();

        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="value">The enum value to get attributes for.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(Enum value) where T : Attribute {

            // Get the member of the enum value
            MemberInfo? member = value.GetType().GetTypeInfo().GetDeclaredField(value.ToString());
            if (member == null) return ArrayUtils.Empty<T>();

            // Return an array of the found attributes
            return member
                .GetCustomAttributes<T>(false)
                .ToArray();

        }

        /// <summary>
        /// Returns whether the specified <paramref name="member"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="member">The member.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(MemberInfo? member) where T : Attribute {
            return HasCustomAttribute<T>(member, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="member">The member.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <c>null</c> if no matches.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(MemberInfo? member, [NotNullWhen(true)] out T? result) where T : Attribute {
            result = member?.GetCustomAttributes<T>().FirstOrDefault();
            return result != null;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="member">The member.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><c>true</c>c> if one or more attributes are found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttributes<T>(MemberInfo? member, [NotNullWhen(true)] out T[]? result) where T : Attribute {
            result = member?.GetCustomAttributes<T>().ToArray() ?? ArrayUtils.Empty<T>();
            return result.Length > 0;
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="member">The member holding the attribute.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.</returns>
        public static T? GetCustomAttribute<T>(MemberInfo? member) where T : Attribute {
            return member?
                .GetCustomAttributes<T>(false)
                .FirstOrDefault();
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="member">The member holding the attributes.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(MemberInfo? member) where T : Attribute {
            return member?
                .GetCustomAttributes<T>(false)
                .ToArray() ?? ArrayUtils.Empty<T>();
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(Type? type) where T : Attribute {
            return HasCustomAttribute<T>(type, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="type">The type to check.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <c>null</c> if no matches.</param>
        /// <returns><c>true</c>c> if an attribute is found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute<T>(Type? type, [NotNullWhen(true)] out T? result) where T : Attribute {
            result = type?.GetTypeInfo().GetCustomAttributes<T>(false).FirstOrDefault();
            return result != null;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="type">The type to check.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><c>true</c>c> if one or more attributes are found; otherwise <c>false</c>.</returns>
        public static bool HasCustomAttributes<T>(Type? type, [NotNullWhen(true)] out T[]? result) where T : Attribute {
            result = type?.GetTypeInfo().GetCustomAttributes<T>(false).ToArray() ?? ArrayUtils.Empty<T>();
            return result.Length > 0;
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="type">The type holding the attribute.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <c>null</c> if no matching attributes are found.</returns>
        public static T? GetCustomAttribute<T>(Type? type) where T : Attribute {
            return type?
                .GetTypeInfo()
                .GetCustomAttributes<T>(false)
                .FirstOrDefault();
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="type">The type holding the attributes.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(Type? type) where T : Attribute {
            return type?
                .GetTypeInfo()
                .GetCustomAttributes<T>(false)
                .ToArray() ?? ArrayUtils.Empty<T>();
        }

        /// <summary>
        /// Returns whether the specified <paramref name="assembly"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="assembly">The type to check.</param>
        /// <returns><see langword="true"/> if an attribute is found; otherwise, <see langword="false"/>.</returns>
        public static bool HasCustomAttribute<T>(Assembly? assembly) where T : Attribute {
            return HasCustomAttribute<T>(assembly, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="assembly"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="assembly">The assembly to check.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <see langword="null"/> if no matches.</param>
        /// <returns><see langword="true"/> if an attribute is found; otherwise, <see langword="false"/>.</returns>
        public static bool HasCustomAttribute<T>(Assembly? assembly, [NotNullWhen(true)] out T? result) where T : Attribute {
            result = assembly?.GetCustomAttributes<T>().FirstOrDefault();
            return result != null;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="assembly"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="assembly">The assembly to check.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><see langword="true"/> if an attribute is found; otherwise, <see langword="false"/>.</returns>
        public static bool HasCustomAttributes<T>(Assembly? assembly, [NotNullWhen(true)] out T[]? result) where T : Attribute {
            result = assembly?.GetCustomAttributes<T>().ToArray() ?? ArrayUtils.Empty<T>();
            return result.Length > 0;
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <see langword="null"/> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="assembly">The assembly holding the attribute.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <see langword="null"/> if no matching attributes are found.</returns>
        public static T? GetCustomAttribute<T>(Assembly? assembly) where T : Attribute {
            return assembly?
                .GetCustomAttributes<T>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="assembly">The assembly holding the attributes.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(Assembly? assembly) where T : Attribute {
            return assembly?
                .GetCustomAttributes<T>()
                .ToArray() ?? ArrayUtils.Empty<T>();
        }

#if NET45_OR_GREATER || NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER

        /// <summary>
        /// Returns whether the specified <paramref name="type"/> is an extension class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if <paramref name="type"/> is an extension class; otherwise, <c>false</c>.</returns>
        public static bool IsExtensionClass(Type? type) {
            return type is not null && type.IsDefined(typeof(ExtensionAttribute));
        }

        /// <summary>
        /// Returns whether the specified <typeparamref name="T"/> is an extension class.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns><c>true</c> if <typeparamref name="T"/> is an extension class; otherwise, <c>false</c>.</returns>
        public static bool IsExtensionClass<T>() {
            return typeof(T).IsDefined(typeof(ExtensionAttribute));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="method"/> is an extension method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns><c>true</c> if <paramref name="method"/> is an extension method; otherwise, <c>false</c>.</returns>
        public static bool IsExtensionMethod(MethodInfo? method) {
            return method is not null && method.IsDefined(typeof(ExtensionAttribute));
        }

#endif

        /// <summary>
        /// Returns the <see cref="MethodInfo"/> identified by the specified <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type of the expression.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>An instance of <see cref="MethodInfo"/>.</returns>
        /// <exception cref="ArgumentException">If <paramref name="expression"/> is not a method expression.</exception>
        public static MethodInfo GetMethodInfo<T>(Expression<T> expression) {

            if (expression.Body is not MethodCallExpression methodExpression) {
                throw new ArgumentException($"Expression body is not of type MethodCallExpression: {expression}");
            }

            return methodExpression.Method;

        }

        /// <summary>
        /// Returns the <see cref="PropertyInfo"/> identified by the specified <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="T">The type of the expression.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>An instance of <see cref="PropertyInfo"/>.</returns>
        /// <exception cref="ArgumentException">If <paramref name="expression"/> is not a property expression.</exception>
        public static PropertyInfo GetPropertyInfo<T>(Expression<T> expression) {

            if (expression.Body is not MemberExpression member) {
                throw new ArgumentException($"Expression body is not of type MemberExpression: {expression}");
            }

            if (member.Member is not PropertyInfo propertyInfo) {
                throw new ArgumentException($"Expression member is not a property: {expression}");
            }

            return propertyInfo;

        }

    }

}
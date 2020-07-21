using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
            return assembly.GetName().Version.ToString();
        }

#if I_CAN_HAZ_FILE_VERSION_INFO

        /// <summary>
        /// Returns the file version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the file version of the assembly.</returns>
        public static string GetFileVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

        /// <summary>
        /// Returns the informational version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the informational version of the assembly.</returns>
        public static string GetInformationalVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
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
        public static bool IsClass(Type type) {
            return type.GetTypeInfo().IsClass;
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
        public static bool IsInterface(Type type) {
            return type.GetTypeInfo().IsInterface;
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
        public static bool IsEnum(Type type) {
            return type.GetTypeInfo().IsEnum;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member" /> is marked as obsolete.
        /// </summary>
        /// <param name="member">The method.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(MemberInfo member) {
            return IsObsolete(member, out _);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="member" /> is marked as obsolete.
        /// </summary>
        /// <param name="member">The method.</param>
        /// <param name="attribute">An instance of <see cref="T:System.ObsoleteAttribute" /> if the member has been marked as obsolete.</param>
        /// <returns><c>true</c> if the member has been marked as obsolete; otherwise <c>false</c>.</returns>
        public static bool IsObsolete(MemberInfo member, out ObsoleteAttribute attribute) {
            attribute = member.GetCustomAttributes(true).OfType<ObsoleteAttribute>().FirstOrDefault();
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
        public static bool IsObsolete<T>(out ObsoleteAttribute attribute) {
            attribute = typeof(T).GetTypeInfo().GetCustomAttributes(true).OfType<ObsoleteAttribute>().FirstOrDefault();
            return attribute != null;
        }

    }

}
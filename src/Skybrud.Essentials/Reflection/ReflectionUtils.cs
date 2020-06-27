using System;
using System.Diagnostics;
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
            
#if NET_FRAMEWORK
            return type.IsClass;
#endif
            
#if NET_STANDARD
            return type.GetTypeInfo().IsClass;
#endif

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
            
#if NET_FRAMEWORK
            return type.IsInterface;
#endif
            
#if NET_STANDARD
            return type.GetTypeInfo().IsInterface;
#endif

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
            
#if NET_FRAMEWORK
            return type.IsEnum;
#endif
            
#if NET_STANDARD
            return type.GetTypeInfo().IsEnum;
#endif

        }

    }

}
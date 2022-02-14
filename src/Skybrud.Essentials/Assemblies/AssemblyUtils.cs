using Skybrud.Essentials.Reflection;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Skybrud.Essentials.Assemblies {

    /// <summary>
    /// Static utility class for working with assemblies and the <see cref="Assembly"/> class in particular. Replaced by the <see cref="ReflectionUtils"/> class.
    /// </summary>
    [Obsolete("Use static methods in the ReflectionUtils class instead.")]
    public static class AssemblyUtils {

        /// <summary>
        /// Gets the version of the specified <paramref name="assembly"/>. Alias of <see cref="ReflectionUtils.GetVersion"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the version of the assembly.</returns>
        [Obsolete("Use ReflectionUtils.GetVersion() method instead.")]
        public static string GetVersion(Assembly assembly) {
            return ReflectionUtils.GetVersion(assembly);
        }

#if I_CAN_HAZ_FILE_VERSION_INFO

        /// <summary>
        /// Gets the file version of the specified <paramref name="assembly"/>. Alias of <see cref="ReflectionUtils.GetFileVersion"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the file version of the assembly.</returns>
        [Obsolete("Use ReflectionUtils.GetFileVersion() method instead.")]
        public static string GetFileVersion(Assembly assembly) {
            return ReflectionUtils.GetFileVersion(assembly);
        }

        /// <summary>
        /// Gets the informational version of the specified <paramref name="assembly"/>. Alias of <see cref="ReflectionUtils.GetInformationalVersion"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the informational version of the assembly.</returns>
        [Obsolete("Use ReflectionUtils.GetInformationalVersion() method instead.")]
        public static string GetInformationalVersion(Assembly assembly) {
            return ReflectionUtils.GetInformationalVersion(assembly);
        }

        /// <summary>
        /// Gets an instance of <see cref="FileVersionInfo"/> with information about the specified <paramref name="assembly"/>. Alias of <see cref="ReflectionUtils.GetFileVersionInfo"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>An instance of <see cref="FileVersionInfo"/>.</returns>
        [Obsolete("Use ReflectionUtils.GetFileVersionInfo() method instead.")]
        public static FileVersionInfo GetFileVersionInfo(Assembly assembly) {
            return ReflectionUtils.GetFileVersionInfo(assembly);
        }

#endif

    }

}
using System;
using System.Diagnostics;
using System.Reflection;

namespace Skybrud.Essentials.Assemblies {
    
    /// <summary>
    /// Static utility class for working with assemblies and the <see cref="Assembly"/> class in particular.
    /// </summary>
    public static class AssemblyUtils {

        /// <summary>
        /// Gets the version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the version of the assembly.</returns>
        public static string GetVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException("assembly");
            return assembly.GetName().Version.ToString();
        }

        /// <summary>
        /// Gets the file version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the file version of the assembly.</returns>
        public static string GetFileVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException("assembly");
            return assembly.Location == null ? null : FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

        /// <summary>
        /// Gets the informational version of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>A string representing the informational version of the assembly.</returns>
        public static string GetInformationalVersion(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException("assembly");
            return assembly.Location == null ? null : FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
        }

        /// <summary>
        /// Gets an instance of <see cref="FileVersionInfo"/> with information about the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>An instance of <see cref="FileVersionInfo"/>.</returns>
        public static FileVersionInfo GetFileVersionInfo(Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException("assembly");
            return assembly.Location == null ? null : FileVersionInfo.GetVersionInfo(assembly.Location);
        }

    }

}
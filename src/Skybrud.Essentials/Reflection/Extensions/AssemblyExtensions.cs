using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Skybrud.Essentials.Reflection.Extensions {

    /// <summary>
    /// Static class with extension methods for the <see cref="Assembly"/> class.
    /// </summary>
    public static class AssemblyExtensions {

        /// <summary>
        /// Returns whether the specified <paramref name="assembly"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="assembly">The type to check.</param>
        /// <returns><see langword="true"/> if an attribute is found; otherwise, <see langword="false"/>.</returns>
        public static bool HasCustomAttribute<T>(this Assembly? assembly) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute<T>(assembly);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="assembly"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="assembly">The assembly to check.</param>
        /// <param name="result">The first attribute of <typeparamref name="T"/>, or <see langword="null"/> if no matches.</param>
        /// <returns><see langword="true"/> if an attribute is found; otherwise, <see langword="false"/>.</returns>
        public static bool HasCustomAttribute<T>(this Assembly? assembly, [NotNullWhen(true)] out T? result) where T : Attribute {
            return ReflectionUtils.HasCustomAttribute(assembly, out result);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="assembly"/> has one or more attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes.</typeparam>
        /// <param name="assembly">The assembly to check.</param>
        /// <param name="result">When this method returns, an array containing the matched attributes.</param>
        /// <returns><see langword="true"/> if an attribute is found; otherwise, <see langword="false"/>.</returns>
        public static bool HasCustomAttributes<T>(this Assembly? assembly, [NotNullWhen(true)] out T[]? result) where T : Attribute {
            return ReflectionUtils.HasCustomAttributes(assembly, out result);
        }

        /// <summary>
        /// Returns the first attribute of type <typeparamref name="T"/>, or <see langword="null"/> if no matching attributes are found.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to return.</typeparam>
        /// <param name="assembly">The assembly holding the attribute.</param>
        /// <returns>An instance of <typeparamref name="T"/>, or <see langword="null"/> if no matching attributes are found.</returns>
        public static T? GetCustomAttribute<T>(this Assembly? assembly) where T : Attribute {
            return ReflectionUtils.GetCustomAttribute<T>(assembly);
        }

        /// <summary>
        /// Returns an array of attributes of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the attributes to return.</typeparam>
        /// <param name="assembly">The assembly holding the attributes.</param>
        /// <returns>An array of <typeparamref name="T"/>.</returns>
        public static T[] GetCustomAttributes<T>(this Assembly? assembly) where T : Attribute {
            return ReflectionUtils.GetCustomAttributes<T>(assembly);
        }

        /// <summary>
        /// Returns the copyright information of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Returns a string representing the copyright information, or <see langword="null"/> if not found.</returns>
        public static string? GetCopyright(this Assembly assembly) {
            return assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        }

        /// <summary>
        /// Attempts to get the copyright information of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="result">When this method returns, holds the copyright information if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetCopyright(this Assembly assembly, out string? result) {
            result = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
            return !string.IsNullOrWhiteSpace(result);
        }

        /// <summary>
        /// Returns the title of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Returns the assembly title, or <see langword="null"/> if not found.</returns>
        public static string? GetTitle(this Assembly assembly) {
            return assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
        }

        /// <summary>
        /// Attempts to get the title of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="result">When this method returns, holds the title if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetTitle(this Assembly assembly, out string? result) {
            result = assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
            return !string.IsNullOrWhiteSpace(result);
        }

        /// <summary>
        /// Returns the description of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Returns the assembly description, or <see langword="null"/> if not found.</returns>
        public static string? GetDescription(this Assembly assembly) {
            return assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
        }

        /// <summary>
        /// Attempts to get the description of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="result">When this method returns, holds the description if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetDescription(this Assembly assembly, out string? result) {
            result = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
            return !string.IsNullOrWhiteSpace(result);
        }

        /// <summary>
        /// Returns the build configuration of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Returns the build configuration, or <see langword="null"/> if not found.</returns>
        public static string? GetConfiguration(this Assembly assembly) {
            return assembly.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration;
        }

        /// <summary>
        /// Attempts to get the build configuration of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="result">When this method returns, holds the build configuration if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetConfiguration(this Assembly assembly, out string? result) {
            result = assembly.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration;
            return !string.IsNullOrWhiteSpace(result);
        }

        /// <summary>
        /// Returns the company name of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Returns the company name, or <see langword="null"/> if not found.</returns>
        public static string? GetCompany(this Assembly assembly) {
            return assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
        }

        /// <summary>
        /// Attempts to get the company name of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="result">When this method returns, holds the company name if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetCompany(this Assembly assembly, out string? result) {
            result = assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
            return !string.IsNullOrWhiteSpace(result);
        }

        /// <summary>
        /// Returns the product name of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Returns the product name, or <see langword="null"/> if not found.</returns>
        public static string? GetProduct(this Assembly assembly) {
            return assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
        }

        /// <summary>
        /// Attempts to get the product name of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="result">When this method returns, holds the product name if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetProduct(this Assembly assembly, out string? result) {
            result = assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            return !string.IsNullOrWhiteSpace(result);
        }

        /// <summary>
        /// Returns the repository URL of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Returns the repository URL, or <see langword="null"/> if not found.</returns>
        public static string? GetRepositoryUrl(this Assembly assembly) {
            return assembly.GetMetadata("RepositoryUrl");
        }

        /// <summary>
        /// Attempts to get the repository URL of the specified <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="result">When this method returns, holds the repository URL if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetRepositoryUrl(this Assembly assembly, out string? result) {
            return assembly.TryGetMetadata("RepositoryUrl", out result);
        }

        /// <summary>
        /// Returns the value of the meta data with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="key">The key of the meta data.</param>
        /// <returns>Returns the build configuration, or <see langword="null"/> if not found.</returns>
        public static string? GetMetadata(this Assembly assembly, string key) {
            return assembly.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(x => x.Key == key)?.Value;
        }

        /// <summary>
        /// Attempts to get the value of the meta data with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="key">The key of the meta data.</param>
        /// <param name="result">When this method returns, holds the meta data value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/></returns>
        public static bool TryGetMetadata(this Assembly assembly, string key, out string? result) {
            result = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault(x => x.Key == key)?.Value;
            return !string.IsNullOrWhiteSpace(result);
        }

    }

}
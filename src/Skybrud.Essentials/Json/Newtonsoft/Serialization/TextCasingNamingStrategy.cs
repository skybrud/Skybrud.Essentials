using Newtonsoft.Json.Serialization;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Newtonsoft.Serialization {

    /// <summary>
    /// Custom implementation of <see cref="NamingStrategy"/> for converting property names to <see cref="TextCasing.CamelCase"/>.
    /// </summary>
    public class TextCasingNamingStrategy : NamingStrategy {

        /// <summary>
        /// Gets the casing the be used.
        /// </summary>
        public TextCasing Casing { get; }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="casing"/>.
        /// </summary>
        /// <param name="casing">The casing the be used.</param>
        public TextCasingNamingStrategy(TextCasing casing) {
            Casing = casing;
        }

        /// <summary>
        /// Resolves the specified property name.
        /// </summary>
        /// <param name="name">The property name to resolve.</param>
        /// <returns>The resolved property name.</returns>
        protected override string ResolvePropertyName(string name) {
            return StringUtils.ToCasing(name, Casing);
        }

    }

}
namespace Skybrud.Essentials.Strings {

    /// <summary>
    /// Indicates the casing a given string should be converted to.
    /// </summary>
    public enum TextCasing {

        /// <summary>
        /// Indicates that the string should be converted to lower case (eg. <c>Hello World</c> becomes <c>hello world</c>).
        /// </summary>
        LowerCase,

        /// <summary>
        /// Indicates that the string should be converted to lower case (eg. <c>Hello World</c> becomes <c>HELLO WORLD</c>).
        /// </summary>
        UpperCase,

        /// <summary>
        /// Indicates that the string should be converted to camel case (eg. <c>Hello World</c> becomes <c>helloWorld</c>). Also referred to as lower camel casing.
        /// </summary>
        CamelCase,

        /// <summary>
        /// Indicates that the string should be converted to Pascal case (eg. <c>Hello World</c> becomes <c>helloWorld</c>). Also referred to as upper camel casing.
        /// </summary>
        PascalCase,

        /// <summary>
        /// Indicates that the string should be converted to kebab case, which is lower case words separated by hyphens (eg. <c>Hello World</c> becomes <c>hello-world</c>).
        /// </summary>
        KebabCase,

        /// <summary>
        /// Indicates that the string should be converted to a new lower camel cased string, but with the first character in each word as upper case, and words separator by hyphens (eg. <c>Hello World</c> becomes <c>Hello-World</c>).
        /// </summary>
        HeaderCase,

        /// <summary>
        /// Indicates that the string should be converted to lower case, which is upper case words separated by hyphens (eg. <c>Hello World</c> becomes <c>HELLO-WORLD</c>).
        /// </summary>
        TrainCase,

        /// <summary>
        /// Indicates that the string should be converted to a lower case string with words separated by underscores (eg. <c>Hello World</c> becomes <c>hello_world</c>).
        /// </summary>
        SnakeCase,

        /// <summary>
        /// Indicates that the string should be converted to a upper case string with words separated by underscores (eg. <c>Hello World</c> becomes <c>HELLO_WORLD</c>).
        /// </summary>
        ConstantCase,

        // TODO: Should we support sentence case - eg. "Rød grød med fløde"?

        // TODO: Should we support capital case - eg. "Rød Grød Med Fløde"?

        // TODO: Should we support title case - eg. "The Quick Brown Fox Jumps Over the Lazy Dog"?

        /// <summary>
        /// Alias of <see cref="SnakeCase"/>.
        /// </summary>
        Underscore = SnakeCase,

        /// <summary>
        /// Alias of <see cref="KebabCase"/>.
        /// </summary>
        ParamCase = KebabCase,

        /// <summary>
        /// Alias of <see cref="ConstantCase"/>.
        /// </summary>
        MacroCase = ConstantCase

    }

}
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
        /// Indicates that the string should be converted to lower case, which is upper case words separated by hyphens (eg. <c>Hello World</c> becomes <c>HELLO-WORLD</c>).
        /// </summary>
        TrainCase,

        /// <summary>
        /// Indicates that the string should be converted to a lower case string with words separated by underscores (eg. <c>Hello World</c> becomes <c>hello_world</c>).
        /// </summary>
        Underscore

    }

}
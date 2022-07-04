namespace Skybrud.Essentials.Strings {
    
    /// <summary>
    /// Enum class indicating the format in which a file size should be formatted.
    /// </summary>
    public enum FileSizeFormat {

        /// <summary>
        /// Indicates that the file size should be formatted using kibibytes (based on the power of 2), but using units
        /// like <c>KB</c>, <c>MB</c> etc.
        ///
        /// Teachnically this is wrong as 1 kibibyte (1024 bytes) should use the unit <c>KiB</c>, as <c>KB</c> refers
        /// to kilobytes. But <c>KB</c> is commonly used to represent kibibytes, thereby causing some ambiguity.
        /// </summary>
        Default,

        /// <summary>
        /// Indicates that the file size should be formatted using kibibytes (based on the power of 2) - eg.
        /// <c>KiB</c>, <c>MiB</c> and so forth.
        ///
        /// Using this format, <c>1 KiB</c> equal to <c>1024 bytes</c>.
        /// </summary>
        Kibi,

        /// <summary>
        /// Indicates that the file size should be formatted using kilobytes (based on the power of 10) - eg.
        /// <c>KB</c>, <c>MB</c> and so forth.
        ///
        /// Using this format, <c>1 KB</c> equal to <c>1000 bytes</c>.
        /// </summary>
        Kilo

    }

}
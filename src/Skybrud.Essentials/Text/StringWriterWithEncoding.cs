using System.IO;
using System.Text;

namespace Skybrud.Essentials.Text {
    
    /// <summary>
    /// Custom string writer allowing an optional encoding to be specified via the constructor.
    /// </summary>
    public class StringWriterWithEncoding : StringWriter {

        #region Properties
        
        /// <summary>
        /// Gets the encoding associated with the string writer.
        /// </summary>
        public override Encoding Encoding { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringWriterWithEncoding"/> class that writes to the specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> object to write to.</param>
        public StringWriterWithEncoding(StringBuilder sb) : base(sb) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringWriterWithEncoding"/> class that writes to the specified <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> object to write to.</param>
        /// <param name="encoding">The encoding of the string writer.</param>
        public StringWriterWithEncoding(StringBuilder sb, Encoding encoding) : base(sb) {
            Encoding = encoding;
        }

        #endregion

    }

}
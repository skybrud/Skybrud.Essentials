namespace Skybrud.Essentials.Time {
    
    /// <summary>
    /// Class describing a period defined by a <see cref="Start"/> date and <see cref="End"/> date.
    /// </summary>
    public class EssentialsPeriod {

        #region Properties

        /// <summary>
        /// Gets a reference to the timestamp representing the start of the period.
        /// </summary>
        public EssentialsTime Start { get; protected set; }

        /// <summary>
        /// Gets a reference to the timestamp representing the end of the period.
        /// </summary>
        public EssentialsTime End { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new period with empty start and end dates.
        /// </summary>
        protected EssentialsPeriod() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="start"/> and <paramref name="end"/> dates.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        public EssentialsPeriod(EssentialsTime start, EssentialsTime end) {
            Start = start;
            End = end;
        }

        #endregion

    }

}
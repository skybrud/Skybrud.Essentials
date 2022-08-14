using System.Collections;
using System.Collections.Generic;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a range of one or more <see cref="EssentialsDate"/>.
    /// </summary>
    public class EssentialsDateRange : IEnumerable<EssentialsDate> {

        #region Properties

        /// <summary>
        /// Gets the <see cref="EssentialsDate"/> at the start of the range.
        /// </summary>
        public EssentialsDate Start { get; set; }

        /// <summary>
        /// Gets the <see cref="EssentialsDate"/> at the end of the range.
        /// </summary>
        public EssentialsDate End { get; set; }

        /// <summary>
        /// Gets an array of <see cref="EssentialsDate"/> within the range.
        /// </summary>
        public EssentialsDate[] Days { get; set; }

        /// <summary>
        /// Indicates whether the range is in reverse order (if <see cref="End"/> is before <see cref="Start"/>).
        /// </summary>
        public bool IsReverse { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new range from the specified <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="start">The <see cref="EssentialsDate"/> at the start of the range.</param>
        /// <param name="end">The <see cref="EssentialsDate"/> at the end of the range.</param>
        public EssentialsDateRange(EssentialsDate start, EssentialsDate end) {

            Start = start;
            End = end;

            List<EssentialsDate> temp = new();

            if (end < start) {
                IsReverse = true;
                for (EssentialsDate date = start; date.YearAndDay >= end.YearAndDay; date = date.AddDays(-1)) {
                    temp.Add(date);
                }
            } else {
                for (EssentialsDate date = start; date.YearAndDay <= end.YearAndDay; date = date.AddDays(+1)) {
                    temp.Add(date);
                }
            }

            Days = temp.ToArray();

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EssentialsDate"/> of the range.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="EssentialsDate"/> of the range.</returns>
        public IEnumerator<EssentialsDate> GetEnumerator() {
            return ((IEnumerable<EssentialsDate>) Days).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}
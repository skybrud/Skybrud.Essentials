using System;
using System.Collections;
using System.Collections.Generic;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a range of one or more <see cref="EssentialsWeek"/>.
    /// </summary>
    public class EssentialsWeekRange : IEnumerable<EssentialsWeek> {

        #region Properties

        /// <summary>
        /// Gets the <see cref="EssentialsWeek"/> at the start of the range.
        /// </summary>
        public EssentialsWeek Start { get; set; }

        /// <summary>
        /// Gets the <see cref="EssentialsWeek"/> at the end of the range.
        /// </summary>
        public EssentialsWeek End { get; set; }

        /// <summary>
        /// Gets an array of <see cref="EssentialsWeek"/> within the range.
        /// </summary>
        public EssentialsWeek[] Weeks { get; set; }

        /// <summary>
        /// Indicates whether the range is in reverse order (if <see cref="End"/> is before <see cref="Start"/>).
        /// </summary>
        public bool IsReverse { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new range of all weeks of the specified <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        public EssentialsWeekRange(int year) : this(new EssentialsWeek(year, 1, 1), new EssentialsWeek(year, 12, 31)) { }

        /// <summary>
        /// Initializes a new range from the specified <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="start">The <see cref="EssentialsWeek"/> at the start of the range.</param>
        /// <param name="end">The <see cref="EssentialsWeek"/> at the end of the range.</param>
        public EssentialsWeekRange(EssentialsWeek start, EssentialsWeek end) {

            Start = start;
            End = end;

            List<EssentialsWeek> temp = new List<EssentialsWeek>();

            if (end.Start < start.Start) {
                IsReverse = true;
                for (EssentialsWeek week = start; week.Start >= end.Start; week = week.GetPreviousWeek()) {
                    temp.Add(week);
                }
            } else {
                for (EssentialsWeek week = start; week.Start <= end.Start; week = week.GetNextWeek()) {
                    temp.Add(week);
                }
            }

            Weeks = temp.ToArray();

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EssentialsWeek"/> of the range.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="EssentialsWeek"/> of the range.</returns>
        public IEnumerator<EssentialsWeek> GetEnumerator() {
            return ((IEnumerable<EssentialsWeek>)Weeks).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}
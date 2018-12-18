using System;
using System.Collections;
using System.Collections.Generic;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing the period of a single <strong>ISO 8601</strong> week.
    /// </summary>
    public class EssentialsWeek : IEnumerable<EssentialsDate> {

        #region Properties

        /// <summary>
        /// Gets the year of the week.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Gets the number of the week.
        /// </summary>
        public int Week { get; }

        /// <summary>
        /// Gets a reference to the timestamp representing the start of the week.
        /// </summary>
        public EssentialsDateTimeOffset Start { get; }

        /// <summary>
        /// Gets a reference to the timestamp representing the end of the week.
        /// </summary>
        public EssentialsDateTimeOffset End { get; }

        /// <summary>
        /// Gets a reference to the current week, according to the local time.
        /// </summary>
        public static EssentialsWeek Current => new EssentialsWeek(DateTimeOffset.Now);

        /// <summary>
        /// Gets a reference to the current week, according to Coordinated Universal Time (UTC).
        /// </summary>
        public static EssentialsWeek UtcCurrent => new EssentialsWeek(DateTimeOffset.UtcNow);

        /// <summary>
        /// Gets whether the week is in the past.
        /// </summary>
        public bool IsPast => Year < DateTimeOffset.Now.Year || (Year == DateTimeOffset.Now.Year && Week < Current.Week);

        /// <summary>
        /// Gets whether the week matches the current week.
        /// </summary>
        public bool IsCurrent => Year == DateTimeOffset.Now.Year && Week == Current.Week;

        /// <summary>
        /// Gets whether the week is in the future.
        /// </summary>
        public bool IsFuture => Year > DateTimeOffset.Now.Year || (Year == DateTimeOffset.Now.Year && Week > Current.Week);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/> and <paramref name="week"/>.
        /// </summary>
        /// <param name="year">The year of the week.</param>
        /// <param name="week">The week number of the week.</param>
        public EssentialsWeek(int year, int week) : this(EssentialsDateTimeOffset.FromIso8601Week(year, week, EssentialsDateTimeOffset.Now.Offset)) { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="year"/>, <paramref name="week"/> and <paramref name="offset"/>.
        /// </summary>
        /// <param name="year">The year of the week.</param>
        /// <param name="week">The week number of the week.</param>
        /// <param name="offset">The time's offset from Coordinated Universal Time (UTC).</param> 
        public EssentialsWeek(int year, int week, TimeSpan offset) : this(EssentialsDateTimeOffset.FromIso8601Week(year, week, offset)) { }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="EssentialsDateTimeOffset"/> representing a timestamp in the week.</param>
        public EssentialsWeek(EssentialsDateTimeOffset timestamp) {

            Week = TimeUtils.GetIso8601WeekNumber(timestamp.DateTimeOffset);
            Start = TimeUtils.GetFirstDayOfWeek(timestamp.DateTimeOffset);
            End = TimeUtils.GetLastDayOfWeek(timestamp.DateTimeOffset);

            if (End.Month == 1 && Week == 1) {
                Year = End.Year;
            } else if (Start.Month == 12 && Week >= 50) {
                Year = Start.Year;
            } else {
                Year = timestamp.Year;
            }

        }

        #endregion

        /// <summary>
        /// Gets a reference to the previous week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsWeek"/> representing the previous week.</returns>
        public EssentialsWeek GetPreviousWeek() {
            return new EssentialsWeek(Start.AddDays(-4));
        }

        /// <summary>
        /// Gets a reference to the next week.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsWeek"/> representing the next week.</returns>
        public EssentialsWeek GetNextWeek() {
            return new EssentialsWeek(End.AddDays(+4));
        }

        /// <summary>
        /// Gets an enumerator for iterating over the days of the week.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<EssentialsDate> GetEnumerator() {
            for (EssentialsDateTimeOffset day = Start; day < End; day = day.AddDays(1)) {
                yield return new EssentialsDate(day);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }

}
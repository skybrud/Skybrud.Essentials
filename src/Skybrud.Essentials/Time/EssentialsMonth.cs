using System;
using System.Collections.Generic;
using Skybrud.Essentials.Common;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class describing a month.
    /// </summary>
    public class EssentialsMonth : EssentialsPeriod {

        #region Properties

        /// <summary>
        /// Gets the year of the month.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Gets the ordinal of the month - eg. <c>1</c> for January.
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Gets the month name in English.
        /// </summary>
        public string MonthName => TimeUtils.GetMonthName(Month);

        /// <summary>
        /// Gets the month name according to the current culture.
        /// </summary>
        public string LocalMonthName => TimeUtils.GetLocalMonthName(Month);

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the start of the month.
        /// </summary>
        public new EssentialsTime Start {
            get => base.Start!;
            protected set => base.Start = value;
        }

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the end of the month.
        /// </summary>
        public new EssentialsTime End {
            get => base.End!;
            protected set => base.End = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new month based on the specified <paramref name="year"/> and <paramref name="month"/>.
        ///
        /// Timestamps for start and end will be calculated using <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        public EssentialsMonth(int year, int month) : this(year, month, TimeZoneInfo.Local) { }

        /// <summary>
        /// Initializes a new month based on the specified <paramref name="year"/> and <paramref name="month"/>.
        ///
        /// Timestamps for start and end will be calculated using <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="timeZone"></param>
        public EssentialsMonth(int year, int month, TimeZoneInfo timeZone) {
            Year = year;
            Month = month;
            Start = new EssentialsTime(year, month, 1, timeZone);
            End = Start.GetEndOfMonth(timeZone);
        }

        /// <summary>
        /// Initializes a new instance for the month containing the specified <paramref name="timestamp"/>.
        ///
        /// If <paramref name="timestamp"/> doesn't specify a timestamp (eg. only an offset), the timestamp will be converted to <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the month to be created.</param>
        public EssentialsMonth(EssentialsTime timestamp) {

            if (timestamp is null) throw new ArgumentNullException(nameof(timestamp));
            if (timestamp.TimeZone is null) timestamp = timestamp.ToTimeZone(TimeZoneInfo.Local);

            Year = timestamp.Year;
            Month = timestamp.Month;
            Start = timestamp.GetStartOfMonth();
            End = timestamp.GetEndOfMonth();

        }

        /// <summary>
        /// Initializes a new instance for the month containing the specified <paramref name="timestamp"/>.
        ///
        /// <paramref name="timestamp"/> will be converted to <see cref="TimeZoneInfo.Local"/> prior to calculating the start and end of the month.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the month to be created.</param>
        /// <param name="timeZone"></param>
        public EssentialsMonth(EssentialsTime timestamp, TimeZoneInfo? timeZone) {

            if (timestamp is null) throw new ArgumentNullException(nameof(timestamp));

            timestamp = timestamp.ToTimeZone(timeZone ?? TimeZoneInfo.Local);

            Year = timestamp.Year;
            Month = timestamp.Month;
            Start = timestamp.GetStartOfMonth();
            End = timestamp.GetEndOfMonth();

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new instance representing the previous month, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetPrevious() {
            if (Start is null) throw new PropertyNotSetException(nameof(Start));
            return new EssentialsMonth(Start.GetStartOfMonth(TimeZoneInfo.Local).AddDays(-1));
        }

        /// <summary>
        /// Returns a new instance representing the previous month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used for calculating the start and end dates.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetPrevious(TimeZoneInfo timeZone) {
            if (Start is null) throw new PropertyNotSetException(nameof(Start));
            return new EssentialsMonth(Start.GetStartOfMonth(timeZone).AddDays(-1));
        }

        /// <summary>
        /// Returns a new instance representing the next month, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetNext() {
            if (End is null) throw new PropertyNotSetException(nameof(End));
            return new EssentialsMonth(End.GetEndOfMonth(TimeZoneInfo.Local).AddDays(+1));
        }

        /// <summary>
        /// Returns a new instance representing the next month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone to be used for calculating the start and end dates.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth GetNext(TimeZoneInfo timeZone) {
            if (End is null) throw new PropertyNotSetException(nameof(End));
            return new EssentialsMonth(End.GetEndOfMonth(timeZone).AddDays(+1));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns an array with the months from <paramref name="startYear"/> and <paramref name="startMonth"/>.
        ///
        /// Start and end dates of each month are calculated based on <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="startYear">The year of the starting month.</param>
        /// <param name="startMonth">The starting month.</param>
        /// <param name="months">The amount of month, including the start month.</param>
        /// <returns>An array of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth[] GetMonths(int startYear, int startMonth, int months) {
            return GetMonths(startYear, startMonth, months, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Returns an array with the months from <paramref name="startYear"/> and <paramref name="startMonth"/>.
        ///
        /// Start and end dates of each month are calculated based on <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="startYear">The year of the starting month.</param>
        /// <param name="startMonth">The starting month.</param>
        /// <param name="months">The amount of month, including the start month.</param>
        /// <param name="timeZone">The time zone to be used for calculating the start and end dates.</param>
        /// <returns>An array of <see cref="EssentialsMonth"/>.</returns>
        public static EssentialsMonth[] GetMonths(int startYear, int startMonth, int months, TimeZoneInfo timeZone) {

            List<EssentialsMonth> temp = new();

            int year = startYear;

            for (int i = 0; i < months; i++) {
                int month = (startMonth + i - 1) % 12 + 1;
                if (i > 0 && month == 1) year++;
                temp.Add(new EssentialsMonth(year, month, timeZone));
            }

            return temp.ToArray();

        }

        #endregion

    }

}
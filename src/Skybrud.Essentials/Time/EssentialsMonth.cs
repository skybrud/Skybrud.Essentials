using System;

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
            
            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));

            if (timestamp.TimeZone == null) timestamp = timestamp.ToTimeZone(TimeZoneInfo.Local);

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
        public EssentialsMonth(EssentialsTime timestamp, TimeZoneInfo timeZone)  {
            
            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            if (timeZone == null) throw new ArgumentNullException(nameof(timeZone));

            timestamp = timestamp.ToTimeZone(timeZone);

            Year = timestamp.Year;
            Month = timestamp.Month;
            Start = timestamp.GetStartOfMonth();
            End = timestamp.GetEndOfMonth();

        }

        #endregion

    }

}
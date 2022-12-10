using System;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class describing a year.
    /// </summary>
    public class EssentialsYear : EssentialsPeriod {

        #region Properties

        /// <summary>
        /// Gets the year.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Gets whether the year is a leap year.
        /// </summary>
        public bool IsLeapYear => TimeUtils.IsLeapYear(Year);

        /// <summary>
        /// Gets the amount of days in the yeay - <c>366</c> if <see cref="IsLeapYear"/> is <c>true</c>,
        /// otherwise <c>365</c>.
        /// </summary>
        public int Days => IsLeapYear ? 366 : 365;

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the start of the year.
        /// </summary>
        public new EssentialsTime Start {
            get => base.Start!;
            protected set => base.Start = value;
        }

        /// <summary>
        /// Gets a reference to an <see cref="EssentialsTime"/> instance representing the end of the year.
        /// </summary>
        public new EssentialsTime End {
            get => base.End!;
            protected set => base.End = value;
        }

        #region Calendar dates

        /// <summary>
        /// Gets the date of <strong>Palm Sunday</strong>, which falls on the Sunday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Palm_Sunday#Observance_in_the_liturgy</cref>
        /// </see>
        public DateTime PalmSunday => CalendarUtils.GetPalmSunday(Year);

        /// <summary>
        /// Gets the date of <strong>Moundy Thursday</strong>, which falls on the Thursday before
        /// <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Maundy_Thursday</cref>
        /// </see>
        public DateTime GetMoundyThursday => CalendarUtils.GetMoundyThursday(Year);

        /// <summary>
        /// Gets the date of <strong>Good Friday</strong>, which falls on the Friday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Good_Friday</cref>
        /// </see>
        public DateTime GetGoodFriday => CalendarUtils.GetGoodFriday(Year);

        /// <summary>
        /// Gets the date of <strong>Holy Saturday</strong>, which falls on the Saturday before <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Holy_Saturday</cref>
        /// </see>
        public DateTime GetHolySaturday => CalendarUtils.GetHolySaturday(Year);

        /// <summary>
        /// Gets the date of <strong>Easter Sunday</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://da.wikipedia.org/wiki/Påske#Beregning_af_p.C3.A5skedagens_dato</cref>
        /// </see>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter#Date</cref>
        /// </see>
        public DateTime EasterSunday => CalendarUtils.GetEasterSunday(Year);

        /// <summary>
        /// Gets the date of <strong>Easter Monday</strong>, which falls on the Monday after <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter_Monday</cref>
        /// </see>
        public DateTime EasterMonday => CalendarUtils.GetEasterMonday(Year);

        /// <summary>
        /// Gets the date of <strong>General Prayer Day</strong> (or <strong>Store Bededag</strong> in Danish) - a national
        /// holiday in Denmark. It falls on the 4th Friday after <strong>Easter</strong>.
        /// </summary>
        /// <see>
        ///     <cref>https://da.wikipedia.org/wiki/Store_bededag</cref>
        /// </see>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Store_Bededag</cref>
        /// </see>
        public DateTime StoreBededag => CalendarUtils.Denmark.GetGeneralPrayerDay(Year);

        /// <summary>
        /// Gets the date of <strong>Ascension Day</strong>, which is celebrated on a Thursday, the fortieth day of
        /// <strong>Easter</strong> (the 6th Thursday after <strong>Moundy Thursday</strong>).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Feast_of_the_Ascension</cref>
        /// </see>
        public DateTime AscensionDay => CalendarUtils.GetAscensionDay(Year);

        /// <summary>
        /// Gets the date of <strong>Whit Sunday</strong>, which is celebrated on the 7th Sunday after
        /// <strong>Easter</strong>.
        ///
        /// Depending on the year, Whit Sunday falls within the period from the
        /// <strong>10th of May</strong> to the <strong>13th of June</strong> (both inclusive).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Whitsun</cref>
        /// </see>
        public DateTime WhitSunday => CalendarUtils.GetWhitSunday(Year);

        /// <summary>
        /// Gets the date of <strong>Whit Monday</strong>, which is celebrated the day after
        /// <strong>Whit Sunday</strong>. Whit Sunday is the 7th Sunday after
        /// <strong>Easter</strong>.
        ///
        /// Depending on the year, Whit Monday falls within the period from the <strong>11th of May</strong> to the
        /// <strong>14th of June</strong> (both inclusive).
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Whit_Monday</cref>
        /// </see>
        public DateTime WhitMonday => CalendarUtils.GetWhitMonday(Year);

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new year based on the specified <paramref name="year"/>.
        ///
        /// Timestamps for start and end will be calculated using <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        public EssentialsYear(int year) : this(year, TimeZoneInfo.Local) { }

        /// <summary>
        /// Initializes a new year based on the specified <paramref name="year"/>.
        ///
        /// Timestamps for start and end will be calculated using <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="timeZone">The time zone used for calculating the start and end of the year.</param>
        public EssentialsYear(int year, TimeZoneInfo timeZone) {
            Year = year;
            Start = new EssentialsTime(year, 1, 1, timeZone);
            End = new EssentialsTime(year, 12, 31, timeZone).GetEndOfDay();
        }

        /// <summary>
        /// Initializes a new instance for the year containing the specified <paramref name="timestamp"/>.
        ///
        /// If <paramref name="timestamp"/> doesn't specify a timestamp (eg. only an offset), the timestamp will be converted to <see cref="TimeZoneInfo.Local"/>.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the year to be created.</param>
        public EssentialsYear(EssentialsTime timestamp) {

            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));

            if (timestamp.TimeZone == null) timestamp = timestamp.ToTimeZone(TimeZoneInfo.Local);

            Year = timestamp.Year;
            Start = new EssentialsTime(timestamp.Year, 1, 1, timestamp.TimeZone);
            End = new EssentialsTime(timestamp.Year, 12, 31, timestamp.TimeZone).GetEndOfDay();

        }

        /// <summary>
        /// Initializes a new instance for the year containing the specified <paramref name="timestamp"/>.
        ///
        /// <paramref name="timestamp"/> will be converted to <see cref="TimeZoneInfo.Local"/> prior to calculating the start and end of the year.
        /// </summary>
        /// <param name="timestamp">A timestamp representing the year to be created.</param>
        /// <param name="timeZone">The time zone used for calculating the start and end of the year.</param>
        public EssentialsYear(EssentialsTime timestamp, TimeZoneInfo timeZone) {

            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            if (timeZone == null) throw new ArgumentNullException(nameof(timeZone));

            timestamp = timestamp.ToTimeZone(timeZone);

            Year = timestamp.Year;
            Start = new EssentialsTime(timestamp.Year, 1, 1, timeZone);
            End = new EssentialsTime(timestamp.Year, 12, 31, timeZone).GetEndOfDay();

        }

        #endregion

    }

}
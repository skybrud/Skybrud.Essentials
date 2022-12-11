using System;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class describing a period defined by a <see cref="Start"/> date and <see cref="End"/> date.
    /// </summary>
    public class EssentialsPeriod {

        #region Properties

        /// <summary>
        /// Gets a reference to the timestamp representing the start of the period.
        /// </summary>
        public EssentialsTime? Start { get; protected set; }

        /// <summary>
        /// Gets whether the <see cref="Start"/> property has a value.
        /// </summary>
        [MemberNotNullWhen(true, "Start")]
        public bool HasStart => Start is not null;

        /// <summary>
        /// Gets a reference to the timestamp representing the end of the period.
        /// </summary>
        public EssentialsTime? End { get; protected set; }

        /// <summary>
        /// Gets whether the <see cref="End"/> property has a value.
        /// </summary>
        [MemberNotNullWhen(true, "End")]
        public bool HasEnd => End is not null;

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
        public EssentialsPeriod(EssentialsTime? start, EssentialsTime? end) {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="start"/> and <paramref name="end"/> dates.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        /// <param name="timeZone">The time zone to be used.</param>
        public EssentialsPeriod(EssentialsTime? start, EssentialsTime? end, TimeZoneInfo? timeZone) {
            timeZone ??= TimeZoneInfo.Local;
            Start = start?.ToTimeZone(timeZone);
            End = end?.ToTimeZone(timeZone);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="start"/> and <paramref name="end"/>
        /// dates. Both dates will be adjusted according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        /// <param name="timeZone">The time zone.</param>
        public EssentialsPeriod(DateTimeOffset start, DateTimeOffset end, TimeZoneInfo? timeZone) {
            Start = new EssentialsTime(start, timeZone ?? TimeZoneInfo.Local);
            End = new EssentialsTime(end, timeZone ?? TimeZoneInfo.Local);
        }

        #endregion

        #region Static methods

        private static EssentialsPeriod GetFromDate(DateTimeOffset dto, TimeZoneInfo? timeZone) {

            timeZone ??= TimeZoneInfo.Local;

            DateTimeOffset start = TimeUtils.GetStartOfDay(dto, timeZone);
            DateTimeOffset end = TimeUtils.GetEndOfDay(dto, timeZone);

            return new EssentialsPeriod(start, end, timeZone);

        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the current day from start to end, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Today() {
            return GetFromDate(DateTimeOffset.UtcNow, null);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the current day from start to end, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Today(TimeZoneInfo? timeZone) {
            return GetFromDate(DateTimeOffset.UtcNow, timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the day of <paramref name="timestamp"/> from start to
        /// end, according to <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Today(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {
            return GetFromDate(timestamp, timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the the day before the current day and according to
        /// the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Yesterday() {
            return Yesterday(DateTimeOffset.UtcNow, null);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the the day before the current day and according to
        /// the <paramref name="timeZone"/>.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Yesterday(TimeZoneInfo? timeZone) {
            return Yesterday(DateTimeOffset.UtcNow, timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the the day before the day of
        /// <paramref name="timestamp"/> and according to the <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Yesterday(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {
            return GetFromDate(timestamp.AddDays(-1), timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the the day after the current day and according to
        /// the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Tomorrow() {
            return Tomorrow(DateTimeOffset.UtcNow, null);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the the day after the current day and according to
        /// the <paramref name="timeZone"/>.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Tomorrow(TimeZoneInfo? timeZone) {
            return Tomorrow(DateTimeOffset.UtcNow, timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the the day after the day of
        /// <paramref name="timestamp"/> and according to the <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod Tomorrow(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {
            return GetFromDate(timestamp.AddDays(1), timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the upcoming weekend relative to the current day and
        /// according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod NextWeekend() {
            return NextWeekend(DateTimeOffset.UtcNow, null);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the upcoming weekend relative to the current day and
        /// according to <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod NextWeekend(TimeZoneInfo? timeZone) {
            return NextWeekend(DateTimeOffset.UtcNow, timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the upcoming weekend relative to the specified
        /// <paramref name="timestamp"/> and according to <paramref name="timeZone"/>.
        ///
        /// If <paramref name="timestamp"/> represents a Saturday or a Sunday, the returned period will representing
        /// the weekend of the next week instead.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod NextWeekend(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {

            // Fall back to local time zone if not specified
            timeZone ??= TimeZoneInfo.Local;

            // Convert "timestamp" to same offset as "timeZone"
            timestamp = TimeZoneInfo.ConvertTime(timestamp, timeZone);

            // If "dto" is already within a weekend, we jump to the next week instead
            if (timestamp.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) {

                // Adjust to UTC and add seven days (aka a full week)
                timestamp = timestamp.ToUniversalTime().AddDays(7);

                // Adjust back to the input time zone
                timestamp = TimeZoneInfo.ConvertTime(timestamp, timeZone);

            }

            DateTimeOffset start = TimeUtils.GetStartOfWeek(timestamp, timeZone).AddDays(5);
            DateTimeOffset end = TimeUtils.GetEndOfWeek(timestamp, timeZone);

            // Wrap the result in a new EssentialsPeriod
            return new EssentialsPeriod(start, end, timeZone);

        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the current week, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod ThisWeek() {
            return ThisWeek(DateTimeOffset.UtcNow, null);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the current week, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod ThisWeek(TimeZoneInfo? timeZone) {
            return ThisWeek(DateTimeOffset.UtcNow, timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the week of <paramref name="timestamp"/> and according to <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod ThisWeek(DateTimeOffset timestamp, TimeZoneInfo? timeZone) {

            // Fall back to local time zone if not specified
            timeZone ??= TimeZoneInfo.Local;

            // Wrap the input "timestamp"
            EssentialsTime time = new(timestamp);

            // Calculate start and end
            EssentialsTime start = time.GetStartOfWeek(timeZone);
            EssentialsTime end = time.GetEndOfWeek(timeZone);

            // Wrap the result in a new EssentialsPeriod
            return new EssentialsPeriod(start, end);

        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the current month, according to the local time zone.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod ThisMonth() {
            return ThisMonth(DateTimeOffset.UtcNow, null);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the current month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod ThisMonth(TimeZoneInfo? timeZone) {
            return ThisMonth(DateTimeOffset.UtcNow, timeZone);
        }

        /// <summary>
        /// Returns a <see cref="EssentialsPeriod"/> representing the month of <paramref name="dto"/> and according to <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="dto">The timestamp.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsPeriod"/>.</returns>
        public static EssentialsPeriod ThisMonth(DateTimeOffset dto, TimeZoneInfo? timeZone) {

            // Fall back to local time zone if not specified
            timeZone ??= TimeZoneInfo.Local;

            // Wrap the input "dto"
            EssentialsTime time = new(dto);

            // Calculate start and end
            EssentialsTime start = time.GetStartOfMonth(timeZone);
            EssentialsTime end = time.GetEndOfMonth(timeZone);

            // Wrap the result in a new EssentialsPeriod
            return new EssentialsPeriod(start, end);

        }

        #endregion

    }

}
#pragma warning disable CS1591

using System;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Static class with various utility methods where the return value is <see cref="EssentialsDate"/>.
    /// </summary>
    public static class EssentialsDateUtils {

        #region GetStartOfWeek(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the date identified
        /// by the specified <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(int year, int month, int day) {
            return GetStartOfWeek(new EssentialsDate(year, month, day));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the date identified
        /// by the specified <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(int year, int month, int day, DayOfWeek firstDayOfWeek) {
            return GetStartOfWeek(new EssentialsDate(year, month, day), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date to get the start of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(EssentialsDate date) {
            return GetStartOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date to get the start of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(EssentialsDate date, DayOfWeek firstDayOfWeek) {

            // Get the days since the start of the week
            int diff = date.DayOfWeek - firstDayOfWeek;

            // Adjust if the difference is negative
            if (diff < 0) diff += 7;

            // Get the first day of the week
            return date.AddDays(-diff);

        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The date to get the start of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(DateTime dateTime) {
            return GetStartOfWeek(new EssentialsDate(dateTime));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The date to get the start of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(DateTime dateTime, DayOfWeek firstDayOfWeek) {
            return GetStartOfWeek(new EssentialsDate(dateTime), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">The date to get the start of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(DateTimeOffset dateTimeOffset) {
            return GetStartOfWeek(new EssentialsDate(dateTimeOffset));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">The date to get the start of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(DateTimeOffset dateTimeOffset, DayOfWeek firstDayOfWeek) {
            return GetStartOfWeek(new EssentialsDate(dateTimeOffset), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="EssentialsTime"/> to get the start of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(EssentialsTime time) {
            return GetStartOfWeek(new EssentialsDate(time));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="EssentialsTime"/> to get the start of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(EssentialsTime time, DayOfWeek firstDayOfWeek) {
            return GetStartOfWeek(new EssentialsDate(time), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="week"/>.
        /// </summary>
        /// <param name="week">The <see cref="EssentialsWeek"/> to get the start of of.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetStartOfWeek(EssentialsWeek week) {
            // TODO: Don't convert to "EssentialsTime" as an intermediary
            return new EssentialsDate(week.GetStartOfWeek());
        }

        #endregion

        #region GetEndOfWeek(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the date identified
        /// by the specified <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(int year, int month, int day) {
            return GetEndOfWeek(new EssentialsDate(year, month, day));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the date identified
        /// by the specified <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(int year, int month, int day, DayOfWeek firstDayOfWeek) {
            return GetEndOfWeek(new EssentialsDate(year, month, day), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date to get the end of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(EssentialsDate date) {
            return GetEndOfWeek(date, DayOfWeek.Monday);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date to get the end of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(EssentialsDate date, DayOfWeek firstDayOfWeek) {

            // Get the days since the start of the week
            int diff = date.DayOfWeek - firstDayOfWeek;

            // Adjust if the difference is negative
            if (diff < 0) diff += 7;

            // Get the last day of the week
            return date.AddDays(-diff + 6);

        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The date to get the end of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(DateTime dateTime) {
            return GetEndOfWeek(new EssentialsDate(dateTime));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the week of the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The date to get the start of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the week.</returns>
        public static EssentialsDate GetEndOfWeek(DateTime dateTime, DayOfWeek firstDayOfWeek) {
            return GetEndOfWeek(new EssentialsDate(dateTime), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">The date to get the end of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(DateTimeOffset dateTimeOffset) {
            return GetEndOfWeek(new EssentialsDate(dateTimeOffset));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">The date to get the end of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(DateTimeOffset dateTimeOffset, DayOfWeek firstDayOfWeek) {
            return GetEndOfWeek(new EssentialsDate(dateTimeOffset), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="EssentialsTime"/> to get the end of week for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(EssentialsTime time) {
            return GetEndOfWeek(new EssentialsDate(time));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="EssentialsTime"/> to get the end of week for.</param>
        /// <param name="firstDayOfWeek">The first day of the week.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(EssentialsTime time, DayOfWeek firstDayOfWeek) {
            return GetEndOfWeek(new EssentialsDate(time), firstDayOfWeek);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the week of the specified <paramref name="week"/>.
        /// </summary>
        /// <param name="week">The <see cref="EssentialsWeek"/> to get the end of of.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the week.</returns>
        public static EssentialsDate GetEndOfWeek(EssentialsWeek week) {
            // TODO: Don't convert to "EssentialsTime" as an intermediary
            return new EssentialsDate(week.GetEndOfWeek());
        }

        #endregion

        #region GetStartOfMonth(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the month of the month
        /// identified by the specified <paramref name="year"/> and <paramref name="month"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The year.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the quarter.</returns>
        public static EssentialsDate GetStartOfMonth(int year, int month) {
            return new EssentialsDate(year, month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The <see cref="EssentialsDate"/> to get the start of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the month.</returns>
        public static EssentialsDate GetStartOfMonth(EssentialsDate date) {
            return new EssentialsDate(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the month of the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to get the start of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the month.</returns>
        public static EssentialsDate GetStartOfMonth(DateTime dateTime) {
            return new EssentialsDate(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the month of the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">The <see cref="DateTimeOffset"/> to get the start of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the month.</returns>
        public static EssentialsDate GetStartOfMonth(DateTimeOffset dateTimeOffset) {
            return new EssentialsDate(dateTimeOffset.Year, dateTimeOffset.Month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the month of the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="EssentialsTime"/> to get the start of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the month.</returns>
        public static EssentialsDate GetStartOfMonth(EssentialsTime time) {
            return new EssentialsDate(time.Year, time.Month, 1);
        }

        #endregion

        #region GetEndOfMonth(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the month of the month identified
        /// by the specified <paramref name="year"/> and <paramref name="month"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The year.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the quarter.</returns>
        public static EssentialsDate GetEndOfMonth(int year, int month) {
            return new EssentialsDate(year, month, DateTime.DaysInMonth(year, month));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the month of the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The <see cref="EssentialsDate"/> to get the end of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the month.</returns>
        public static EssentialsDate GetEndOfMonth(EssentialsDate date) {
            return new EssentialsDate(date.Year, date.Month, date.DaysInMonth);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the month of the specified <paramref name="dateTime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to get the end of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the month.</returns>
        public static EssentialsDate GetEndOfMonth(DateTime dateTime) {
            return new EssentialsDate(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the month of the specified <paramref name="dateTimeOffset"/>.
        /// </summary>
        /// <param name="dateTimeOffset">The <see cref="DateTimeOffset"/> to get the end of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the month.</returns>
        public static EssentialsDate GetEndOfMonth(DateTimeOffset dateTimeOffset) {
            return new EssentialsDate(dateTimeOffset.Year, dateTimeOffset.Month, DateTime.DaysInMonth(dateTimeOffset.Year, dateTimeOffset.Month));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the month of the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The <see cref="EssentialsTime"/> to get the end of month for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the month.</returns>
        public static EssentialsDate GetEndOfMonth(EssentialsTime time) {
            return new EssentialsDate(time.Year, time.Month, time.DaysInMonth);
        }

        #endregion

        #region GetStartOfQuarter(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the quarter of the month
        /// identified by the specified <paramref name="month"/> and <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The year.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the quarter.</returns>
        public static EssentialsDate GetStartOfQuarter(int year, int month) {
            month = TimeUtils.GetStartMonthOfQuarter(TimeUtils.GetQuarter(month));
            return new EssentialsDate(year, month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> to get the start of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the quarter.</returns>
        public static EssentialsDate GetStartOfQuarter(DateTime date) {
            int month = TimeUtils.GetStartMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTimeOffset"/> to get the start of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the quarter.</returns>
        public static EssentialsDate GetStartOfQuarter(DateTimeOffset date) {
            int month = TimeUtils.GetStartMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsDate"/> to get the start of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the quarter.</returns>
        public static EssentialsDate GetStartOfQuarter(EssentialsDate date) {
            int month = TimeUtils.GetStartMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsTime"/> to get the start of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the quarter.</returns>
        public static EssentialsDate GetStartOfQuarter(EssentialsTime date) {
            int month = TimeUtils.GetStartMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, 1);
        }

        #endregion

        #region GetEndOfQuarter(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the quarter of the month
        /// identified by the specified <paramref name="month"/> and <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The year.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the quarter.</returns>
        public static EssentialsDate GetEndOfQuarter(int year, int month) {
            month = TimeUtils.GetEndMonthOfQuarter(TimeUtils.GetQuarter(month));
            return new EssentialsDate(year, month, DateTime.DaysInMonth(year, month));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> to get the end of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the quarter.</returns>
        public static EssentialsDate GetEndOfQuarter(DateTime date) {
            int month = TimeUtils.GetEndMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, DateTime.DaysInMonth(date.Year, month));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTimeOffset"/> to get the end of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the quarter.</returns>
        public static EssentialsDate GetEndOfQuarter(DateTimeOffset date) {
            int month = TimeUtils.GetEndMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, DateTime.DaysInMonth(date.Year, month));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsDate"/> to get the end of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the quarter.</returns>
        public static EssentialsDate GetEndOfQuarter(EssentialsDate date) {
            int month = TimeUtils.GetEndMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, DateTime.DaysInMonth(date.Year, month));
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the quarter of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsTime"/> to get the end of quarter for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the quarter.</returns>
        public static EssentialsDate GetEndOfQuarter(EssentialsTime date) {
            int month = TimeUtils.GetEndMonthOfQuarter(date);
            return new EssentialsDate(date.Year, month, DateTime.DaysInMonth(date.Year, month));
        }

        #endregion

        #region GetStartOfYear(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the specified <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the year.</returns>
        public static EssentialsDate GetStartOfYear(int year) {
            return new EssentialsDate(year, 1, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> to get the start of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the year.</returns>
        public static EssentialsDate GetStartOfYear(DateTime date) {
            return new EssentialsDate(date.Year, 1, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTimeOffset"/> to get the start of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the year.</returns>
        public static EssentialsDate GetStartOfYear(DateTimeOffset date) {
            return new EssentialsDate(date.Year, 1, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsDate"/> to get the start of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the year.</returns>
        public static EssentialsDate GetStartOfYear(EssentialsDate date) {
            return new EssentialsDate(date.Year, 1, 1);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the start of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsTime"/> to get the start of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the start of the year.</returns>
        public static EssentialsDate GetStartOfYear(EssentialsTime date) {
            return new EssentialsDate(date.Year, 1, 1);
        }

        #endregion

        #region GetEndOfYear(...)

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the specified <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the year.</returns>
        public static EssentialsDate GetEndOfYear(int year) {
            return new EssentialsDate(year, 12, 31);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> to get the end of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the year.</returns>
        public static EssentialsDate GetEndOfYear(DateTime date) {
            return new EssentialsDate(date.Year, 12, 31);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTimeOffset"/> to get the end of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the year.</returns>
        public static EssentialsDate GetEndOfYear(DateTimeOffset date) {
            return new EssentialsDate(date.Year, 12, 31);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsDate"/> to get the end of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the year.</returns>
        public static EssentialsDate GetEndOfYear(EssentialsDate date) {
            return new EssentialsDate(date.Year, 12, 31);
        }

        /// <summary>
        /// Returns an <see cref="EssentialsDate"/> instance representing the end of the year of specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsTime"/> to get the end of year for.</param>
        /// <returns>An instance of <see cref="EssentialsDate"/> representing the end of the year.</returns>
        public static EssentialsDate GetEndOfYear(EssentialsTime date) {
            return new EssentialsDate(date.Year, 12, 31);
        }

        #endregion

    }

}
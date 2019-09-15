using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a partial date (eg. only year and month).
    /// </summary>
    [JsonConverter(typeof(EssentialsPartialDateConverter))]
    public class EssentialsPartialDate {

        #region Properties

        /// <summary>
        /// Gets the year, or <c>0</c> if not specified.
        /// </summary>
        public int Year { get; }
        
        /// <summary>
        /// Gets the month, or <c>0</c> if not specified.
        /// </summary>
        public int Month { get; }
        
        /// <summary>
        /// Gets the day, or <c>0</c> if not specified.
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing the publication date. This instance will not be
        /// realiable in the way that an instance of <see cref="DateTime"/> can't represent a partial date.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// Gets whether a year has been specified for this date.
        /// </summary>
        public bool HasYear => Year > 0;

        /// <summary>
        /// Gets whether a month has been specified for this date.
        /// </summary>
        public bool HasMonth => Month > 0;

        /// <summary>
        /// Gets whether a day has been specified for this date.
        /// </summary>
        public bool HasDay => Day > 0;

        /// <summary>
        /// Gets whether the date is partial (missing either <see cref="Year"/>, <see cref="Month"/> or
        /// <see cref="Day"/>).
        /// </summary>
        public bool IsPartialDate => !(HasYear && HasMonth && HasDay);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTime"/> representing the full date.</param>
        public EssentialsPartialDate(DateTime date) {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
            DateTime = new DateTime(Year, Month, Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="DateTimeOffset"/> representing the full date.</param>
        public EssentialsPartialDate(DateTimeOffset date) {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
            DateTime = new DateTime(Year, Month, Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">An instance of <see cref="EssentialsDateTime"/> representing the full date.</param>
        public EssentialsPartialDate(EssentialsDateTime date) {
            Year = date == null ? 0 : date.Year;
            Month = date == null ? 0 : date.Month;
            Day = date == null ? 0 : date.Day;
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        public EssentialsPartialDate(int year) {
            Year = Math.Max(0, year);
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="year"/> and <paramref name="month"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        public EssentialsPartialDate(int year, int month) {
            Year = Math.Max(0, year);
            Month = Math.Max(0, month);
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="year"/>, <paramref name="month"/> and
        /// <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year of the date.</param>
        /// <param name="month">The month of the date.</param>
        /// <param name="day">The day of the date.</param>
        public EssentialsPartialDate(int year, int month, int day) {
            Year = Math.Max(0, year);
            Month = Math.Max(0, month);
            Day = Math.Max(0, day);
            DateTime = new DateTime(Year == 0 ? 1 : Year, Month == 0 ? 1 : Month, Day == 0 ? 1 : Day);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a string representation of the partial date in the format of <c>yyyy-MM-dd</c>.
        /// </summary>
        /// <returns>A string that represents the partial date.</returns>
        public override string ToString() {
            return $"{Year:0000}-{Month:00}-{Day:00}";
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">A string that contains the partial date to convert.</param>
        /// <returns>An instance of <see cref="EssentialsPartialDate"/> representing the converted partial date.</returns>
        public static EssentialsPartialDate Parse(string input) {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (TryParse(input, out EssentialsPartialDate date)) return date;
            throw new ArgumentException("Specified string is not a valid date", nameof(input));
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent.
        /// </summary>
        /// <param name="input">A string that contains the partial date to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about
        /// <paramref name="input"/>.</param>
        /// <returns>An instance of <see cref="EssentialsPartialDate"/> representing the converted partial date.</returns>
        public static EssentialsPartialDate Parse(string input, IFormatProvider provider) {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (TryParse(input, provider, out EssentialsPartialDate date)) return date;
            throw new ArgumentException("Specified string is not a valid date", nameof(input));
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsPartialDate"/> value
        /// equivalent to the partial date and time contained in <paramref name="input"/>, if the conversion succeeded,
        /// or <c>null</c> if the conversion failed. The conversion fails if <paramref name="input"/> is
        /// <c>null</c>, is an empty string (""), or does not contain a valid string representation of a partial
        /// date. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise,
        /// <c>false</c>.</returns>
        public static bool TryParse(string input, out EssentialsPartialDate result) {
            return TryParse(input, CultureInfo.InvariantCulture, out result);
        }

        /// <summary>
        /// Converts the specified <paramref name="input"/> string to its <see cref="EssentialsPartialDate"/>
        /// equivalent and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about
        /// <paramref name="input"/>.</param>
        /// <param name="result">When this method returns, contains the <see cref="EssentialsPartialDate"/> value
        /// equivalent to the partial date and time contained in <paramref name="input"/>, if the conversion succeeded,
        /// or <c>null</c> if the conversion failed. The conversion fails if <paramref name="input"/> is
        /// <c>null</c>, is an empty string (""), or does not contain a valid string representation of a partial
        /// date. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if <paramref name="input"/> was converted successfully; otherwise,
        /// <c>false</c>.</returns>
        public static bool TryParse(string input, IFormatProvider provider, out EssentialsPartialDate result) {

            // Initialize "date"
            result = null;

            // Strip all commas to make parsing easier
            input = (input ?? string.Empty).Replace(",", string.Empty);

            // Parse the string into an instance of DateTime for full dates
            if (DateTime.TryParseExact(input, new[] { "yyyy-MM-dd", "d MMMM yyyy", "MMMM d yyyy" }, provider, DateTimeStyles.None, out DateTime dt)) {
                result = new EssentialsPartialDate(dt);
                return true;
            }

            // Match various formats
            Match m1 = Regex.Match(input, "^([0-9]{4})$");
            Match m2 = Regex.Match(input, "^([0-9]{4})-([0-9]{2})$");
            Match m3 = Regex.Match(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})$");
            Match m4 = Regex.Match(input, "^([a-zA-Z]+) ([0-9]{4})$");
            Match m6 = Regex.Match(input, "^([a-zA-Z]+) ([0-9]{1,2})(st|nd|rd|th) ([0-9]{4})$");
            
            if (m1.Success) result = new EssentialsPartialDate(int.Parse(m1.Groups[1].Value));
            if (m2.Success) result = new EssentialsPartialDate(int.Parse(m2.Groups[1].Value), int.Parse(m2.Groups[2].Value));
            if (m3.Success) result = new EssentialsPartialDate(int.Parse(m3.Groups[1].Value), int.Parse(m3.Groups[2].Value), int.Parse(m3.Groups[3].Value));

            if (m4.Success) {
                if (!TimeUtils.TryParseNumberFromMonthName(m4.Groups[1].Value, provider, out int month)) return false;
                int year = int.Parse(m4.Groups[2].Value);
                result = new EssentialsPartialDate(year, month);
                return true;
            }

            if (m6.Success) {
                if (!TimeUtils.TryParseNumberFromMonthName(m6.Groups[1].Value, provider, out int month)) return false;
                int year = int.Parse(m6.Groups[4].Value);
                int day = int.Parse(m6.Groups[2].Value);
                result = new EssentialsPartialDate(year, month, day);
                return true;
            }

            return result != null;

        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsPartialDate"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTime"/>.</param>
        /// <returns>An instance of <see cref="EssentialsPartialDate"/>.</returns>
        public static implicit operator EssentialsPartialDate(DateTime timestamp) {
            return new EssentialsPartialDate(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsPartialDate"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTimeOffset"/>.</param>
        /// <returns>An instance of <see cref="EssentialsPartialDate"/>.</returns>
        public static implicit operator EssentialsPartialDate(DateTimeOffset timestamp) {
            return new EssentialsPartialDate(timestamp);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsPartialDate"/> from the specified
        /// <paramref name="timestamp"/>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>An instance of <see cref="EssentialsPartialDate"/>.</returns>
        public static implicit operator EssentialsPartialDate(EssentialsDateTime timestamp) {
            return new EssentialsPartialDate(timestamp);
        }

        #endregion

    }

}
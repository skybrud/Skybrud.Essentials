using System;
using System.Globalization;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a date without a time.
    /// </summary>
    public class EssentialsDate {

        private readonly DateTime _dateTime;

        #region Properties

        /// <summary>
        /// Gets the year.
        /// </summary>
        public int Year => _dateTime.Year;

        /// <summary>
        /// Gets the month.
        /// </summary>
        public int Month => _dateTime.Month;

        /// <summary>
        /// Gets the day.
        /// </summary>
        public int Day => _dateTime.Day;

        /// <summary>
        /// Returns the day-of-week part of this <see cref="EssentialsDate"/>. The returned value is an integer
        /// between <c>0</c> and <c>6</c>, where <c>0</c> indicates <strong>Sunday</strong>,
        /// <c>1</c> indicates <strong>Monday</strong>, <c>2</c> indicates <strong>Tuesday</strong>,
        /// <c>3</c> indicates <strong>Wednesday</strong>, <c>4</c> indicates <strong>Thursday</strong>,
        /// <c>5</c> indicates <strong>Friday</strong>, and <c>6</c> indicates <strong>Saturday</strong>.
        /// </summary>
        public DayOfWeek DayOfWeek => _dateTime.DayOfWeek;

        /// <summary>
        /// Gets the day-of-year part of this <see cref="EssentialsDate"/>. The returned value is an integer between <c>1</c> and <c>366</c>.
        /// </summary>
        public int DayOfYear => _dateTime.DayOfYear;

        /// <summary>
        /// Gets whether the year of this <see cref="EssentialsDate"/> is a leap year.
        /// </summary>
        public bool IsLeapYear => TimeUtils.IsLeapYear(_dateTime);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDate"/> is within a weekend.
        /// </summary>
        public bool IsWeekend => TimeUtils.IsLeapYear(_dateTime);

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDate"/> is a weekday.
        /// </summary>
        public bool IsWeekday => TimeUtils.IsWeekday(_dateTime);

        /// <summary>
        /// Gets the week number the <strong>ISO 8601</strong> week of this <see cref="EssentialsDate"/>.
        /// </summary>
        public int WeekNumber => TimeUtils.GetIso8601WeekNumber(_dateTime);

        /// <summary>
        /// Gets the amount of days in the month.
        /// </summary>
        public int DaysInMonth => DateTime.DaysInMonth(Year, Month);

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        public string Iso8601 => _dateTime.ToString("yyyy-MM-dd");

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="DateTime"/>.</param>
        public EssentialsDate(DateTime time) {
            _dateTime = time;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="DateTimeOffset"/>.</param>
        public EssentialsDate(DateTimeOffset time) {
            _dateTime = time.DateTime;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="EssentialsDateTime"/>.</param>
        public EssentialsDate(EssentialsDateTime time) {
            _dateTime = time.DateTime;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="time"/>.
        /// </summary>
        /// <param name="time">An instance of <see cref="EssentialsTime"/>.</param>
        public EssentialsDate(EssentialsTime time) {
            _dateTime = time.DateTimeOffset.DateTime;
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="year"/>, <paramref name="month"/> and <paramref name="day"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        public EssentialsDate(int year, int month, int day) {
            _dateTime = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the start of the day, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfDay() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero);
        }

        /// <summary>
        /// Gets the start of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfDay(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone);
        }

        /// <summary>
        /// Gets the end of the day, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfDay() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetEndOfDay();
        }

        /// <summary>
        /// Gets the end of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfDay(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetEndOfDay();
        }

        /// <summary>
        /// Gets the start of the week, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfWeek() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetStartOfWeek();
        }

        /// <summary>
        /// Gets the start of the week, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfWeek(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetStartOfWeek();
        }

        /// <summary>
        /// Gets the end of the week, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfWeek() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetEndOfWeek();
        }

        /// <summary>
        /// Gets the end of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfWeek(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetEndOfWeek();
        }

        /// <summary>
        /// Gets the start of the day, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfMonth() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetStartOfMonth();
        }

        /// <summary>
        /// Gets the start of the day, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetStartOfMonth(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetStartOfMonth();
        }

        /// <summary>
        /// Gets the end of the month, according to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfMonth() {
           return new EssentialsTime(Year, Month, Day, TimeSpan.Zero).GetEndOfMonth();
        }

        /// <summary>
        /// Gets the end of the month, according to the specified <paramref name="timeZone"/>.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime GetEndOfMonth(TimeZoneInfo timeZone) {
            return new EssentialsTime(Year, Month, Day, timeZone).GetEndOfMonth();
        }

        /// <summary>
        /// Returns a string representation of the date.
        /// </summary>
        /// <returns>A string representation of the value of the current <see cref="EssentialsDate"/> object.</returns>
        public override string ToString() {
            return _dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDate"/> to its equivalent string representation using the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDate"/> object as specified by <paramref name="format"/>.</returns>
        public string ToString(string format) {
            return _dateTime.ToString(format);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDate"/> to its equivalent string representation using the specified <paramref name="format"/> and <paramref name="provider"/>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDate"/> object as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
        public string ToString(string format, IFormatProvider provider) {
            return _dateTime.ToString(format, provider);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Converts the string representation of a date to its <see cref="EssentialsDate"/> equivalent by
        /// using the conventions of the current thread culture.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <returns>An object that is equivalent to the date contained in <paramref name="input"/>.</returns>
        public static EssentialsDate Parse(string input) {
            
            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.Parse(input);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        /// <summary>
        /// Converts the string representation of a date to its <see cref="EssentialsDate"/> equivalent by using
        /// culture-specific format information.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <param name="provider">An object that supplies culture-specific format information about <paramref name="input"/>.</param>
        /// <returns>An object that is equivalent to the date contained in <paramref name="input"/> as specified by <paramref name="provider"/>.</returns>
        public static EssentialsDate Parse(string input, IFormatProvider provider) {
            
            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.Parse(input, provider);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        /// <summary>
        /// Converts the string representation of a dat to its <see cref="EssentialsDate"/> equivalent by using
        /// culture-specific format information and a formatting style.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <param name="provider">An object that supplies culture-specific format information about <paramref name="input"/>.</param>
        /// <param name="styles">A bitwise combination of the enumeration values that indicates the style elements that
        /// can be present in <paramref name="input"/> for the parse operation to succeed, and that defines how to
        /// interpret the parsed date in relation to the current time zone or the current date. A typical value to
        /// specify is <see cref="DateTimeStyles.None"/>.</param>
        /// <returns>An object that is equivalent to the date contained in <paramref name="input"/> as specified by <paramref name="provider"/> and <paramref name="styles"/>.</returns>
        public static EssentialsDate Parse(string input, IFormatProvider provider, DateTimeStyles styles) {
            
            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.Parse(input, provider, styles);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="EssentialsDate"/> equivalent using
        /// the specified format and culture-specific format information. The format of the string representation must
        /// match the specified format exactly.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <param name="format">A format specifier that defines the required format of <paramref name="input"/>.</param>
        /// <param name="provider">An object that supplies culture-specific format information about
        /// <paramref name="input"/>.</param>
        /// <returns>An object that is equivalent to the date contained in <paramref name="input"/>, as specified by
        /// <paramref name="format"/> and <paramref name="provider"/>.</returns>
        public static EssentialsDate ParseExact(string input, string format, IFormatProvider provider) {

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.ParseExact(input, format, provider);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="EssentialsDate"/> equivalent
        /// using the specified format, culture-specific format information, and style. The format of the string
        /// representation must match the specified format exactly or an exception is thrown.
        /// </summary>
        /// <param name="input">A string containing a date and time to convert.</param>
        /// <param name="format">A format specifier that defines the required format of s.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="input"/>.</param>
        /// <param name="styles">A bitwise combination of the enumeration values that provides additional information
        /// about <paramref name="input"/>, about style elements that may be present in <paramref name="input"/>, or
        /// about the conversion from <paramref name="input"/> to a <see cref="EssentialsDate"/> value. A typical value
        /// to specify is <see cref="DateTimeStyles.None"/>.</param>
        /// <returns>An object that is equivalent to the date contained in <paramref name="input"/>, as specified by
        /// <paramref name="format"/>, <paramref name="provider"/>, and <paramref name="styles"/>.</returns>
        public static EssentialsDate ParseExact(string input, string format, IFormatProvider provider, DateTimeStyles styles) {

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.ParseExact(input, format, provider, styles);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="EssentialsDate"/> equivalent using
        /// the specified array of formats, culture-specific format information, and style. The format of the string
        /// representation must match at least one of the specified formats exactly or an exception is thrown.
        /// </summary>
        /// <param name="input">A string that contains a date and time to convert.</param>
        /// <param name="formats">An array of allowable formats of <paramref name="input"/>.</param>
        /// <param name="provider">An object that supplies culture-specific format information about <paramref name="input"/>.</param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="input"/>. A typical value to specify is <see cref="DateTimeStyles.None"/>.</param>
        /// <returns>An object that is equivalent to the date contained in <paramref name="input"/>, as specified by
        /// <paramref name="formats"/>, <paramref name="provider"/>, and <paramref name="styles"/>.</returns>
        public static EssentialsDate ParseExact(string input, string[] formats, IFormatProvider provider, DateTimeStyles styles) {

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return null;

            // Attempt to parse the date
            DateTime dt = DateTime.ParseExact(input, formats, provider, styles);

            // Intialize a new instance
            return new EssentialsDate(dt);

        }

        /// <summary>
        /// Tries to convert a specified string representation of a date to its <see cref="EssentialsTime"/>
        /// equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsDate"/> value equivalent to
        /// the date, if the conversion succeeded, or <c>null</c>, if the conversion failed. The conversion fails if
        /// the input parameter is <c>null</c> or does not contain a valid string representation of a date. This
        /// parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the input parameter is successfully converted; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string input, out EssentialsDate result) {

            // Make sure "result" is initialized
            result = null;

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Attempt to parse the date
            if (DateTime.TryParse(input, out DateTime dt)) {
                result = new EssentialsDate(dt);
            }

            return result != null;

        }

        /// <summary>
        /// Tries to convert a specified string representation of a date to its <see cref="EssentialsTime"/>
        /// equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about input.</param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the permitted format of input.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsDate"/> value equivalent to
        /// the date, if the conversion succeeded, or <c>null</c>, if the conversion failed. The conversion fails if
        /// the input parameter is <c>null</c> or does not contain a valid string representation of a date. This
        /// parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the input parameter is successfully converted; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string input, IFormatProvider provider, DateTimeStyles styles, out EssentialsDate result) {

            // Make sure "result" is initialized
            result = null;

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Attempt to parse the date
            if (DateTime.TryParse(input, provider, styles, out DateTime dt)) {
                result = new EssentialsDate(dt);
            }

            return result != null;

        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="EssentialsDate"/> equivalent using
        /// the specified format, culture-specific format information, and style. The format of the string
        /// representation must match the specified format exactly. The method returns a value that indicates whether
        /// the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <param name="format">The format of <paramref name="input"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about input.</param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the permitted format of input.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsDate"/> value equivalent to
        /// the date, if the conversion succeeded, or <c>null</c>, if the conversion failed. The conversion fails if
        /// the input parameter is <c>null</c> or does not contain a valid string representation of a date. This
        /// parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the input parameter is successfully converted; otherwise, <c>false</c>.</returns>
        public static bool TryParseExact(string input, string format, IFormatProvider provider, DateTimeStyles styles, out EssentialsDate result) {

            // Make sure "result" is initialized
            result = null;

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Attempt to parse the date
            if (DateTime.TryParseExact(input, format, provider, styles, out DateTime dt)) {
                result = new EssentialsDate(dt);
            }

            return result != null;

        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="EssentialsDate"/> equivalent using
        /// the specified array of formats, culture-specific format information, and style. The format of the string
        /// representation must match at least one of the specified formats exactly. The method returns a value that
        /// indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains a date to convert.</param>
        /// <param name="formats">An array of allowable formats of <paramref name="input"/>.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about input.</param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the permitted format of input.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsDate"/> value equivalent to
        /// the date, if the conversion succeeded, or <c>null</c>, if the conversion failed. The conversion fails if
        /// the input parameter is <c>null</c> or does not contain a valid string representation of a date. This
        /// parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the input parameter is successfully converted; otherwise, <c>false</c>.</returns>
        public static bool TryParseExact(string input, string[] formats, IFormatProvider provider, DateTimeStyles styles, out EssentialsDate result) {

            // Make sure "result" is initialized
            result = null;

            // Is "input" an empty string?
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Attempt to parse the date
            if (DateTime.TryParseExact(input, formats, provider, styles, out DateTime dt)) {
                result = new EssentialsDate(dt);
            }

            return result != null;

        }

        #endregion

    }

}
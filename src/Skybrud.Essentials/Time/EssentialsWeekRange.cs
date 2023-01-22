using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a range of one or more <see cref="EssentialsWeek"/>.
    /// </summary>
    public class EssentialsWeekRange : IReadOnlyList<EssentialsWeek> {

        private readonly IReadOnlyList<EssentialsWeek> _weeks;

        #region Properties

        /// <summary>
        /// Gets the amount of months in the range.
        /// </summary>
        public int Count => _weeks.Count;

        /// <summary>
        /// Gets the week at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the week to get.</param>
        /// <returns>An instance of <see cref="EssentialsWeek"/>.</returns>
        public EssentialsWeek this[int index] => _weeks[index];

        /// <summary>
        /// Gets the <see cref="EssentialsWeek"/> at the start of the range.
        /// </summary>
        public EssentialsWeek Start => _weeks[0];

        /// <summary>
        /// Gets the <see cref="EssentialsWeek"/> at the end of the range.
        /// </summary>
        public EssentialsWeek End => _weeks[_weeks.Count - 1];

        /// <summary>
        /// Gets an array of <see cref="EssentialsWeek"/> within the range.
        /// </summary>
        [Obsolete("Use 'ToArray' method instead.")]
        public EssentialsWeek[] Weeks => _weeks.ToArray();

        /// <summary>
        /// Indicates whether the range is in reverse order (if <see cref="End"/> is before <see cref="Start"/>).
        /// </summary>
        public bool IsReverse => End < Start;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new range of all weeks of the specified <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year.</param>
        public EssentialsWeekRange([ValueRange(0, 9999)] int year) {
            _weeks = GetWeeks(new EssentialsWeek(year, 1, 1), new EssentialsWeek(year, 12, 31));
        }

        /// <summary>
        /// Initializes a new range of all weeks from <paramref name="start"/> to <paramref name="end"/>.
        /// </summary>
        /// <param name="start">A timestamp within the first week of the range.</param>
        /// <param name="end">A timestamp within the last week of the range.</param>
        public EssentialsWeekRange(EssentialsTime start, EssentialsTime end) {
            _weeks = GetWeeks(new EssentialsWeek(start), new EssentialsWeek(end));
        }

        /// <summary>
        /// Initializes a new range of all weeks from <paramref name="start"/> to <paramref name="end"/>.
        /// </summary>
        /// <param name="start">A timestamp within the first week of the range.</param>
        /// <param name="end">A timestamp within the last week of the range.</param>
        public EssentialsWeekRange(EssentialsDate start, EssentialsDate end) {
            _weeks = GetWeeks(new EssentialsWeek(start), new EssentialsWeek(end));
        }

        /// <summary>
        /// Initializes a new range from the specified <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="start">The <see cref="EssentialsWeek"/> at the start of the range.</param>
        /// <param name="end">The <see cref="EssentialsWeek"/> at the end of the range.</param>
        public EssentialsWeekRange(EssentialsWeek start, EssentialsWeek end) {
            _weeks = GetWeeks(start, end);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="EssentialsWeekRange"/> with the weeks in reverse order. If the current
        /// <see cref="EssentialsWeekRange"/> only contains a single week, that instance will be returned unmodified.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsWeekRange"/>.</returns>
        public EssentialsWeekRange Reverse() {
            return Count == 1 ? this : new EssentialsWeekRange(_weeks[_weeks.Count - 1], _weeks[0]);
        }

        /// <summary>
        /// Returns a string representation of the week range - eg. <c>2022-W49__2023-W01</c>.
        /// </summary>
        /// <returns>An instance of <see cref="string"/> representing the week range.</returns>
        public override string ToString() {
            return $"{_weeks[0]}__{_weeks[_weeks.Count - 1]}";
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EssentialsWeek"/> of the range.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="EssentialsWeek"/> of the range.</returns>
        public IEnumerator<EssentialsWeek> GetEnumerator() {
            return _weeks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        private static List<EssentialsWeek> GetWeeks(EssentialsWeek start, EssentialsWeek end) {

            List<EssentialsWeek> temp = new();

            if (end.Start < start.Start) {
                for (EssentialsWeek week = start; week.Start >= end.Start; week = week.GetPreviousWeek()) {
                    temp.Add(week);
                }
            } else {
                for (EssentialsWeek week = start; week.Start <= end.Start; week = week.GetNextWeek()) {
                    temp.Add(week);
                }
            }

            return temp;

        }

        /// <summary>
        /// Parses the specified <paramref name="input"/> string representation of a week range into a corresponding of
        /// <see cref="EssentialsWeekRange"/>. If <paramref name="input"/> is either <see langword="null"/> or white space,
        /// <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string identifying the week range.</param>
        /// <returns>An instance of <see cref="EssentialsWeekRange"/>.</returns>
        public static EssentialsWeekRange? Parse(string? input) {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (TryParse(input!, out EssentialsWeekRange? result)) return result;
            throw new Exception("Specified input string is not a valid week range.");
        }

        /// <summary>
        /// Tries to convert the specified string representation of a week range to its <see cref="EssentialsWeekRange"/>
        /// equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains the week range to convert.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsWeekRange"/> value
        /// equivalent to the week range, if the conversion succeeded, or <see langword="null"/>, if the conversion
        /// failed. The conversion fails if the input parameter is <see langword="null"/> or does not contain a
        /// valid string representation of a date. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if the input parameter is successfully converted; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string? input, [NotNullWhen(true)] out EssentialsWeekRange? result) {

            if (string.IsNullOrWhiteSpace(input)) {
                result = null;
                return false;
            }

            if (RegexUtils.IsMatch(input, "^([0-9]{4})(-|-W|W)([0-9]{1,2})(_|__)([0-9]{4})(-|-W|W)([0-9]{1,2})$", out Match match)) {
                var startWeek = new EssentialsWeek(match.Groups[1].Value.ToInt32(), match.Groups[3].Value.ToInt32());
                var endWeek = new EssentialsWeek(match.Groups[5].Value.ToInt32(), match.Groups[7].Value.ToInt32());
                result = new EssentialsWeekRange(startWeek, endWeek);
                return true;
            }

            result = null;
            return false;

        }

        #endregion

    }

}
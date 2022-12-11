using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

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

            List<EssentialsWeek> temp = new();

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
        /// Returns a string representation of the week range - eg. <c>2022-W49__2023-W01</c>.
        /// </summary>
        /// <returns>An instance of <see cref="string"/> representing the week range.</returns>
        public override string ToString() {
            return $"{Weeks[0]}__{Weeks[Weeks.Length - 1]}";
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EssentialsWeek"/> of the range.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="EssentialsWeek"/> of the range.</returns>
        public IEnumerator<EssentialsWeek> GetEnumerator() {
            return ((IEnumerable<EssentialsWeek>) Weeks).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

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
            throw new Exception("Specified input string is not a valid week.");
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
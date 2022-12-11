using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

namespace Skybrud.Essentials.Time {

    /// <summary>
    /// Class representing a range of one or more <see cref="EssentialsDate"/>.
    /// </summary>
    public class EssentialsDateRange : IEnumerable<EssentialsDate> {

        #region Properties

        /// <summary>
        /// Gets the <see cref="EssentialsDate"/> at the start of the range.
        /// </summary>
        public EssentialsDate Start { get; set; }

        /// <summary>
        /// Gets the <see cref="EssentialsDate"/> at the end of the range.
        /// </summary>
        public EssentialsDate End { get; set; }

        /// <summary>
        /// Gets an array of <see cref="EssentialsDate"/> within the range.
        /// </summary>
        public EssentialsDate[] Days { get; set; }

        /// <summary>
        /// Indicates whether the range is in reverse order (if <see cref="End"/> is before <see cref="Start"/>).
        /// </summary>
        public bool IsReverse { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new range from the specified <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="start">The <see cref="EssentialsDate"/> at the start of the range.</param>
        /// <param name="end">The <see cref="EssentialsDate"/> at the end of the range.</param>
        public EssentialsDateRange(EssentialsDate start, EssentialsDate end) {

            Start = start;
            End = end;

            List<EssentialsDate> temp = new();

            if (end < start) {
                IsReverse = true;
                for (EssentialsDate date = start; date.YearAndDay >= end.YearAndDay; date = date.AddDays(-1)) {
                    temp.Add(date);
                }
            } else {
                for (EssentialsDate date = start; date.YearAndDay <= end.YearAndDay; date = date.AddDays(+1)) {
                    temp.Add(date);
                }
            }

            Days = temp.ToArray();

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a string representation of the week range - eg. <c>2022-10-01__2022-12-31</c>.
        /// </summary>
        /// <returns>An instance of <see cref="string"/> representing the week range.</returns>
        public override string ToString() {
            return $"{Start}__{End}";
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EssentialsDate"/> of the range.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="EssentialsDate"/> of the range.</returns>
        public IEnumerator<EssentialsDate> GetEnumerator() {
            return ((IEnumerable<EssentialsDate>) Days).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="input"/> string representation of a date range into a corresponding of
        /// <see cref="EssentialsDateRange"/>. If <paramref name="input"/> is either <see langword="null"/> or white space,
        /// <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string identifying the date range.</param>
        /// <returns>An instance of <see cref="EssentialsDateRange"/>.</returns>
        public static EssentialsDateRange? Parse(string? input) {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (TryParse(input!, out EssentialsDateRange? result)) return result;
            throw new Exception("Specified input string is not a valid date range.");
        }

        /// <summary>
        /// Tries to convert the specified string representation of a date range to its <see cref="EssentialsDateRange"/>
        /// equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains the date range to convert.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsDateRange"/> value
        /// equivalent to the date range, if the conversion succeeded, or <see langword="null"/>, if the conversion
        /// failed. The conversion fails if the input parameter is <see langword="null"/> or does not contain a
        /// valid string representation of a date range. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if the input parameter is successfully converted; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string? input, [NotNullWhen(true)] out EssentialsDateRange? result) {

            if (string.IsNullOrWhiteSpace(input)) {
                result = null;
                return false;
            }

            if (RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{2})-([0-9]{2})(_|__)([0-9]{4})-([0-9]{2})-([0-9]{2})$", out Match match)) {
                var startDate = new EssentialsDate(match.Groups[1].Value.ToInt32(), match.Groups[2].Value.ToInt32(), match.Groups[3].Value.ToInt32());
                var endDate = new EssentialsDate(match.Groups[5].Value.ToInt32(), match.Groups[6].Value.ToInt32(), match.Groups[7].Value.ToInt32());
                result = new EssentialsDateRange(startDate, endDate);
                return true;
            }

            result = null;
            return false;

        }

        #endregion

    }

}
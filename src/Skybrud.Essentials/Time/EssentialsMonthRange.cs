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
    /// Class representing a range of one or more <see cref="EssentialsMonth"/>.
    /// </summary>
    public class EssentialsMonthRange : IReadOnlyList<EssentialsMonth> {

        private readonly IReadOnlyList<EssentialsMonth> _months;

        #region Properties

        /// <summary>
        /// Gets the amount of months in the range.
        /// </summary>
        public int Count => _months.Count;

        /// <summary>
        /// Gets the month at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the month to get.</param>
        /// <returns>An instance of <see cref="EssentialsMonth"/>.</returns>
        public EssentialsMonth this[int index] => _months[index];

        /// <summary>
        /// Gets whether the range is in reverse order (most recent month first).
        /// </summary>
        public bool IsReverse => _months[0] > _months[_months.Count - 1];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="firstYear"/>, <paramref name="firstMonth"/>, <paramref name="lastYear"/> and <paramref name="lastMonth"/>.
        /// </summary>
        /// <param name="firstYear">The first year.</param>
        /// <param name="firstMonth">The first month.</param>
        /// <param name="lastYear">The last year.</param>
        /// <param name="lastMonth">The last month.</param>
        public EssentialsMonthRange([ValueRange(0, 9999)] int firstYear, [ValueRange(1, 12)] int firstMonth, [ValueRange(0, 9999)] int lastYear, [ValueRange(1, 12)] int lastMonth) {
            _months = GetMonths(firstYear, firstMonth, lastYear, lastMonth);
        }

        /// <summary>
        /// Initializes a new instance containing the months of <paramref name="firstDate"/>,
        /// <paramref name="lastDate"/> and the months between. If <paramref name="firstDate"/> is greater than
        /// <paramref name="lastDate"/>, the range will be in reverse order.
        /// </summary>
        /// <param name="firstDate">The date representing the first month.</param>
        /// <param name="lastDate">The date representing the last month.</param>
        public EssentialsMonthRange(EssentialsDate firstDate, EssentialsDate lastDate) {
            _months = GetMonths(firstDate.Year, firstDate.Month, lastDate.Year, lastDate.Month);
        }

        /// <summary>
        /// Initializes a new instance containing the specified <paramref name="firstMonth"/>,
        /// <paramref name="lastMonth"/> and the months between. If <paramref name="firstMonth"/> is greater than
        /// <paramref name="lastMonth"/>, the range will be in reverse order.
        /// </summary>
        /// <param name="firstMonth">The first month.</param>
        /// <param name="lastMonth">The last month.</param>
        public EssentialsMonthRange(EssentialsMonth firstMonth, EssentialsMonth lastMonth) {
            _months = GetMonths(firstMonth.Year, firstMonth.Month, lastMonth.Year, lastMonth.Month);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns whether the specified month represented by <paramref name="year"/> and <paramref name="month"/> is within the range.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month</param>
        /// <returns><see langword="true"/> the month is is within the range; otherwise, <see langword="false"/>.</returns>
        public bool Contains(int year, int month) {

            // ReSharper disable RedundantIfElseBlock
            // ReSharper disable ConvertIfStatementToReturnStatement

            EssentialsMonth? first = _months[0];
            EssentialsMonth? last = _months[_months.Count - 1];

            if (IsReverse) {

                if (year < last.Year) return false;
                if (year > first.Year) return false;

                if (year == first.Year && month > first.Month) return false;
                if (year == last.Year && month < last.Month) return false;

                return true;

            } else {

                if (year > last.Year) return false;
                if (year < first.Year) return false;

                if (year == first.Year && month < first.Month) return false;
                if (year == last.Year && month > last.Month) return false;

                return true;

            }

            // ReSharper restore RedundantIfElseBlock
            // ReSharper restore ConvertIfStatementToReturnStatement

        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is within the range.
        /// </summary>
        /// <param name="date">The date</param>
        /// <returns><see langword="true"/> the date is is within the range; otherwise, <see langword="false"/>.</returns>
        public bool Contains(EssentialsDate date) {
            return Contains(date.Year, date.Month);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="month"/> is within the range.
        /// </summary>
        /// <param name="month">The month</param>
        /// <returns><see langword="true"/> the month is is within the range; otherwise, <see langword="false"/>.</returns>
        public bool Contains(EssentialsMonth month) {
            return Contains(month.Year, month.Month);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsMonthRange"/> with the months in reverse order. If the current
        /// <see cref="EssentialsMonthRange"/> only contains a single month, that instance will be returned unmodified.
        /// </summary>
        /// <returns>An instance of <see cref="EssentialsMonthRange"/>.</returns>
        public EssentialsMonthRange Reverse() {
            return Count == 1 ? this : new EssentialsMonthRange(_months.Last(), _months.First());
        }

        /// <inheritdoc />
        public IEnumerator<EssentialsMonth> GetEnumerator() {
            return _months.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        private static List<EssentialsMonth> GetMonths(int firstYear, int firstMonth, int lastYear, int lastMonth) {

            List<EssentialsMonth> months = new();

            if (firstYear < lastYear || firstYear == lastYear && firstMonth <= lastMonth) {
                for (int y = firstYear; y <= lastYear; y++) {
                    for (int m = 1; m <= 12; m++) {
                        if (y > lastYear) break;
                        if (y == firstYear && m < firstMonth) continue;
                        if (y == lastYear && m > lastMonth) break;
                        months.Add(new EssentialsMonth(y, m));
                    }
                }
            } else {
                for (int y = firstYear; y >= lastYear; y--) {
                    for (int m = 12; m >= 1; m--) {
                        if (y < lastYear) break;
                        if (y == firstYear && m > firstMonth) continue;
                        if (y == lastYear && m < lastMonth) break;
                        months.Add(new EssentialsMonth(y, m));
                    }
                }
            }

            return months;

        }


        /// <summary>
        /// Parses the specified <paramref name="input"/> string representation of a month range into a corresponding of
        /// <see cref="EssentialsMonthRange"/>. If <paramref name="input"/> is either <see langword="null"/> or white space,
        /// <see langword="null"/> will be returned instead.
        /// </summary>
        /// <param name="input">The string identifying the week range.</param>
        /// <returns>An instance of <see cref="EssentialsMonthRange"/>.</returns>
        public static EssentialsMonthRange? Parse(string? input) {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (TryParse(input!, out EssentialsMonthRange? result)) return result;
            throw new Exception("Specified input string is not a valid month range.");
        }

        /// <summary>
        /// Tries to convert the specified string representation of a month range to its <see cref="EssentialsMonthRange"/>
        /// equivalent, and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string that contains the month range to convert.</param>
        /// <param name="result">When the method returns, contains the <see cref="EssentialsMonthRange"/> value
        /// equivalent to the month range, if the conversion succeeded, or <see langword="null"/>, if the conversion
        /// failed. The conversion fails if the input parameter is <see langword="null"/> or does not contain a
        /// valid string representation of a date. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if the input parameter is successfully converted; otherwise, <see langword="false"/>.</returns>
        public static bool TryParse(string? input, [NotNullWhen(true)] out EssentialsMonthRange? result) {

            if (string.IsNullOrWhiteSpace(input)) {
                result = null;
                return false;
            }

            if (RegexUtils.IsMatch(input, "^([0-9]{4})-([0-9]{1,2})(_|__)([0-9]{4})-([0-9]{1,2})$", out Match match)) {
                var startMonth = new EssentialsMonth(match.Groups[1].Value.ToInt32(), match.Groups[2].Value.ToInt32());
                var endMonth = new EssentialsMonth(match.Groups[4].Value.ToInt32(), match.Groups[5].Value.ToInt32());
                result = new EssentialsMonthRange(startMonth, endMonth);
                return true;
            }

            result = null;
            return false;

        }

        #endregion

    }

}
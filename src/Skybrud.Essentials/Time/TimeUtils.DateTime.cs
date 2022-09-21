using System;

namespace Skybrud.Essentials.Time {

    public partial class TimeUtils {

        #region Is...

        /// <summary>
        /// Returns whether <paramref name="first"/> and <paramref name="second"/> represents the same day.
        /// </summary>
        /// <param name="first">The first date.</param>
        /// <param name="second">The second date.</param>
        /// <returns><c>true</c> if <paramref name="first"/> and <paramref name="second"/> represents the same day; otherwise, <c>false</c>.</returns>
        public static bool IsSameDay(DateTime first, DateTime second) {
            return first.Year == second.Year && first.Month == second.Month && first.Day == second.Day;
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is today.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is today; otherwise, <c>false</c>.</returns>
        public static bool IsToday(DateTime date) {
            return IsSameDay(date, DateTime.Now);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is tomorrow.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is tomorrow; otherwise, <c>false</c>.</returns>
        public static bool IsTomorrow(DateTime date) {
            return IsSameDay(date, DateTime.Now.AddDays(1));
        }

        /// <summary>
        /// Returns whether the specified <paramref name="date"/> is yesterday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if <paramref name="date"/> is yesterday; otherwise, <c>false</c>.</returns>
        public static bool IsYesterday(DateTime date) {
            return IsSameDay(date, DateTime.Now.AddDays(-1));
        }

        #endregion

    }

}
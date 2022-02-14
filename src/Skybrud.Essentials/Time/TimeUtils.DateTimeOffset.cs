using System;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Essentials.Time {

    public static partial class TimeUtils {

        #region Get ... of day

        public static DateTimeOffset GetStartOfDay(DateTimeOffset time) {
            if (time == null) throw new ArgumentNullException(nameof(time));
            return new DateTimeOffset(time.Year, time.Month, time.Day, 0, 0, 0, time.Offset);
        }

        public static DateTimeOffset GetStartOfDay(DateTimeOffset time, TimeZoneInfo timeZone) {

            if (time == null) throw new ArgumentNullException(nameof(time));

            // Get the end of the day according to the current offset
            DateTimeOffset temp = GetStartOfDay(time);
            if (timeZone == null) return temp;

            // Adjust the time to the specified time zone
            temp = TimeZoneInfo.ConvertTime(temp, timeZone);

            // Adjust the hour (necessary when daylight saving starts or ends)
            if (temp.Hour == 23) temp = temp.AddHours(+1);
            if (temp.Hour == 01) temp = temp.AddHours(-1);

            return temp;

        }

        public static DateTimeOffset GetEndOfDay(DateTimeOffset time) {

            if (time == null) throw new ArgumentNullException(nameof(time));

            // Get the start of the current day
            DateTimeOffset temp = new DateTimeOffset(time.Year, time.Month, time.Day, 0, 0, 0, time.Offset);

            // Add a day, but subtract a single tick
            temp = temp.AddDays(1).AddTicks(-1);

            return temp;

        }

        public static DateTimeOffset GetEndOfDay(DateTimeOffset time, TimeZoneInfo timeZone) {

            if (time == null) throw new ArgumentNullException(nameof(time));

            // Get the end of the day according to the current offset
            DateTimeOffset temp = GetEndOfDay(time);
            if (timeZone == null) return temp;

            // Adjust the time to the specified time zone
            temp = TimeZoneInfo.ConvertTime(temp, timeZone);

            // Adjust the hour (necessary when daylight saving starts or ends)
            if (temp.Hour == 0) temp = temp.AddHours(-1);

            return temp;

        }

        #endregion

        #region Get ... of week

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time) {
            return GetStartOfWeek(time, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time, DayOfWeek startOfWeek) {

            // Get the days since the start of the week
            int diff = time.DayOfWeek - startOfWeek;

            // Adjust if the difference is negative
            if (diff < 0) diff += 7;

            // Get the first day of the week
            time = time.AddDays(-1 * diff);

            // Get the start of the week
            return new DateTimeOffset(time.Year, time.Month, time.Day, 0, 0, 0, time.Offset);

        }

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time, TimeZoneInfo timeZone) {
            return GetStartOfWeek(time, timeZone, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetStartOfWeek(DateTimeOffset time, TimeZoneInfo timeZone, DayOfWeek startOfWeek) {

            // Get the start of the week
            time = GetStartOfWeek(time, startOfWeek);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 23) time = time.AddHours(+1);
            if (time.Hour == 01) time = time.AddHours(-1);

            return time;

        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time) {
            return GetEndOfWeek(time, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time, DayOfWeek startOfWeek) {
            return GetStartOfWeek(time, startOfWeek).AddDays(7).AddTicks(-1);
        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time, TimeZoneInfo timeZone) {
            return GetEndOfWeek(time, timeZone, DayOfWeek.Monday);
        }

        public static DateTimeOffset GetEndOfWeek(DateTimeOffset time, TimeZoneInfo timeZone, DayOfWeek startOfWeek) {

            // Get the end of the week
            time = GetEndOfWeek(time, startOfWeek);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 22) time = time.AddHours(+1);
            if (time.Hour == 00) time = time.AddHours(-1);

            return time;

        }

        #endregion

        #region Get ... of month

        public static DateTimeOffset GetStartOfMonth(DateTimeOffset time) {
            return new DateTimeOffset(time.Year, time.Month, 1, 0, 0, 0, time.Offset);
        }

        public static DateTimeOffset GetStartOfMonth(DateTimeOffset time, TimeZoneInfo timeZone) {

            // Get the start of the month
            time = GetStartOfMonth(time);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 23) time = time.AddHours(+1);
            if (time.Hour == 01) time = time.AddHours(-1);

            return time;

        }

        public static DateTimeOffset GetEndOfMonth(DateTimeOffset time) {

            // Get the amount of days in the month
            int days = DateTime.DaysInMonth(time.Year, time.Month);

            // Get the start of the month, then add the amount of days
            time = GetStartOfMonth(time).AddDays(days).AddTicks(-1);

            return time;

        }

        public static DateTimeOffset GetEndOfMonth(DateTimeOffset time, TimeZoneInfo timeZone) {

            // Get the end of the month
            time = GetEndOfMonth(time);

            // Adjust to the specified time zone
            time = timeZone == null ? time : TimeZoneInfo.ConvertTime(time, timeZone);

            // Adjust for dayligt savings
            if (time.Hour == 22) time = time.AddHours(+1);
            if (time.Hour == 00) time = time.AddHours(-1);

            return time;

        }

        #endregion

    }

}
using System;

namespace Skybrud.Essentials.Time;

/// <summary>
/// Static class with various utility methods for working with dates.
/// </summary>
public class DateUtils {

#if NET8_0_OR_GREATER

    /// <summary>
    /// Returns the number of whole calendar days between the dates represented by
    /// <paramref name="first"/> and <paramref name="second"/>, ignoring the time of day.
    /// </summary>
    /// <param name="first">The first date.</param>
    /// <param name="second">The second date.</param>
    /// <returns>
    /// The number of whole calendar days between the two dates.
    /// </returns>
    public static int GetDaysBetween(DateOnly first, DateOnly second) {
        return second.DayNumber - first.DayNumber;
    }

#endif

    /// <summary>
    /// Returns the number of whole calendar days between the dates represented by
    /// <paramref name="first"/> and <paramref name="second"/>, ignoring the time of day.
    /// </summary>
    /// <param name="first">The first date.</param>
    /// <param name="second">The second date.</param>
    /// <returns>
    /// The number of whole calendar days between the two dates.
    /// </returns>
    public static int GetDaysBetween(DateTime first, DateTime second) {
#if NET8_0_OR_GREATER
        return GetDaysBetween(DateOnly.FromDateTime(first), DateOnly.FromDateTime(second));
#else
        return (second.Date - first.Date).Days;
#endif
    }

    /// <summary>
    /// Returns the number of whole calendar days between the dates represented by
    /// <paramref name="first"/> and <paramref name="second"/>, ignoring the time of day.
    /// </summary>
    /// <param name="first">The first date.</param>
    /// <param name="second">The second date.</param>
    /// <returns>
    /// The number of whole calendar days between the two dates.
    /// </returns>
    public static int GetDaysBetween(DateTimeOffset first, DateTimeOffset second) {
#if NET8_0_OR_GREATER
        return GetDaysBetween(DateOnly.FromDateTime(first.DateTime), DateOnly.FromDateTime(second.DateTime));
#else
        return (second.Date - first.Date).Days;
#endif
    }

    /// <summary>
    /// Returns the number of whole calendar days between the dates represented by
    /// <paramref name="first"/> and <paramref name="second"/>, ignoring the time of day.
    /// </summary>
    /// <param name="first">The first date.</param>
    /// <param name="second">The second date.</param>
    /// <returns>
    /// The number of whole calendar days between the two dates.
    /// </returns>
    public static int GetDaysBetween(EssentialsDate first, EssentialsDate second) {
#if NET8_0_OR_GREATER
        return GetDaysBetween(new DateOnly(first.Year, first.Month, first.Day),new DateOnly(second.Year, second.Month, second.Day));
#else
        DateTime firstDate = new(first.Year, first.Month, first.Day);
        DateTime secondDate = new(second.Year, second.Month, second.Day);
        return (secondDate - firstDate).Days;
#endif
    }

}
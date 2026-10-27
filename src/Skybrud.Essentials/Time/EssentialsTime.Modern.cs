#if NET8_0_OR_GREATER

using System;

namespace Skybrud.Essentials.Time;

public partial class EssentialsTime {

    /// <summary>
    /// Gets the microsecond part of this <see cref="EssentialsTime"/>.
    /// </summary>
    /// <remarks>
    /// If you rely on properties such as <see cref="Now"/> or <see cref="UtcNow"/> to accurately track the number
    /// of elapsed microseconds, the precision of the time's microseconds component depends on the resolution of
    /// the system clock. On Windows NT 3.5 and later, and Windows Vista operating systems, the clock's resolution
    /// is approximately 10000-15000 microseconds.
    /// </remarks>
    /// <see>
    ///     <cref>https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.microsecond?view=net-7.0#system-datetimeoffset-microsecond</cref>
    /// </see>
    public int Microsecond => DateTimeOffset.Microsecond;

    /// <summary>
    /// Gets the nanosecond part of this <see cref="EssentialsTime"/>.
    /// </summary>
    /// <remarks>
    /// If you rely on properties such as <see cref="Now"/> or <see cref="UtcNow"/> to accurately track the number
    /// of elapsed nanosecond, the precision of the time's nanosecond component depends on the resolution of the
    /// system clock. On Windows NT 3.5 and later, and Windows Vista operating systems, the clock's resolution is
    /// approximately 10000000-15000000 nanoseconds.
    /// </remarks>
    /// <see>
    ///     <cref>https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.nanosecond?view=net-7.0#system-datetimeoffset-nanosecond</cref>
    /// </see>
    public int Nanosecond => DateTimeOffset.Nanosecond;

    /// <summary>
    /// Creates a new instance of <see cref="EssentialsTime"/> from the
    /// specified date, time, and UTC offset.
    /// </summary>
    /// <param name="date">The calendar date.</param>
    /// <param name="time">The time of day.</param>
    /// <param name="offset">The UTC offset to associate with the date and time.</param>
    /// <returns>
    /// A new <see cref="EssentialsTime"/> instance representing the
    /// specified date, time, and offset.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// The specified offset is invalid for <see cref="DateTimeOffset"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The resulting date and time cannot be represented by
    /// <see cref="DateTimeOffset"/>.
    /// </exception>
    public static EssentialsTime FromDateOnlyAndTimeOnly(DateOnly date, TimeOnly time, TimeSpan offset) {
        DateTime dateTime = date.ToDateTime(time, DateTimeKind.Unspecified);
        return new EssentialsTime(new DateTimeOffset(dateTime, offset));
    }

    /// <summary>
    /// Creates a new instance of <see cref="EssentialsTime"/> from the
    /// specified date, time, and time zone.
    /// </summary>
    /// <param name="date">The calendar date.</param>
    /// <param name="time">The time of day.</param>
    /// <param name="timeZone">The time zone used to interpret the date and time.</param>
    /// <returns>
    /// A new <see cref="EssentialsTime"/> instance representing the
    /// specified date and time in the specified time zone.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="timeZone"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// The specified local date and time is invalid or ambiguous in the
    /// specified time zone.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The resulting date and time is outside the supported range.
    /// </exception>
    public static EssentialsTime FromDateOnlyAndTimeOnly(DateOnly date, TimeOnly time, TimeZoneInfo timeZone) {

        ArgumentNullException.ThrowIfNull(timeZone);

        DateTime dateTime = date.ToDateTime(time, DateTimeKind.Unspecified);

        if (timeZone.IsInvalidTime(dateTime)) {
            throw new ArgumentException("The specified date and time is invalid in the time zone.", nameof(time));
        }

        if (timeZone.IsAmbiguousTime(dateTime)) {
            throw new ArgumentException("The specified date and time is ambiguous in the time zone.", nameof(time));
        }

        TimeSpan offset = timeZone.GetUtcOffset(dateTime);

        DateTimeOffset dateTimeOffset = new(dateTime, offset);

        return new EssentialsTime(dateTimeOffset, timeZone);

    }

    /// <summary>
    /// Converts the current instance to a <see cref="DateOnly"/> value.
    /// </summary>
    /// <remarks>
    /// The date is extracted from the current instance's represented
    /// calendar date. No conversion to UTC or the local system time zone
    /// is performed.
    /// </remarks>
    /// <returns>
    /// A <see cref="DateOnly"/> value representing the current date.
    /// </returns>
    public DateOnly ToDateOnly() {
        return DateOnly.FromDateTime(DateTimeOffset.DateTime);
    }

    /// <summary>
    /// Converts the current instance to a <see cref="TimeOnly"/> value.
    /// </summary>
    /// <remarks>
    /// Only the time of day is preserved. The date, UTC offset, and
    /// associated time zone are not included in the returned value.
    /// </remarks>
    /// <returns>
    /// A <see cref="TimeOnly"/> value representing the current time of day.
    /// </returns>
    public TimeOnly ToTimeOnly() {
        return TimeOnly.FromDateTime(DateTimeOffset.DateTime);
    }

}

#endif
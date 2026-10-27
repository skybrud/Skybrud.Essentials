#if NET8_0_OR_GREATER

using System;

namespace Skybrud.Essentials.Time;

public partial class EssentialsDate {

    /// <summary>
    /// Initializes a new instance of <see cref="EssentialsDate"/> from the specified <paramref name="date"/>.
    /// </summary>
    /// <param name="date">The date to convert.</param>
    public EssentialsDate(DateOnly date) {
        _dateTime = date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
    }

    /// <summary>
    /// Creates a new instance of <see cref="EssentialsDate"/> from the specified <paramref name="date"/>.
    /// </summary>
    /// <param name="date">The date to convert.</param>
    /// <returns>
    /// A new <see cref="EssentialsDate"/> instance representing the specified date.
    /// </returns>
    public static EssentialsDate FromDateOnly(DateOnly date) {
        return new EssentialsDate(date);
    }

    /// <summary>
    /// Converts the current instance to a <see cref="DateOnly"/> value.
    /// </summary>
    /// <returns>
    /// A <see cref="DateOnly"/> value representing the same year, month, and day.
    /// </returns>
    public DateOnly ToDateOnly() {
        return new DateOnly(Year, Month, Day);
    }

}

#endif
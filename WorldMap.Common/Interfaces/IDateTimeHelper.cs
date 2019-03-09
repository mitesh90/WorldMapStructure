namespace WorldMap.Common
{
    using System;
    public interface IDateTimeHelper
    {
        /// <summary>
        /// Gets the now.
        /// </summary>
        /// <value>
        /// The now.
        /// </value>
        DateTime Now { get; }

        /// <summary>
        /// Gets the previous date.
        /// </summary>
        /// <value>
        /// The previous date.
        /// </value>
        DateTime PreviousDate { get; }

        /// <summary>
        /// Converts to UTC.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        DateTime ConvertToUtc(string timeZone);

        /// <summary>
        /// Converts to UTC.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        DateTime ConvertToUtc(DateTime date, string timeZone);

        /// <summary>
        /// Converts from UTC.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        DateTime ConvertFromUtc(string timeZone);

        /// <summary>
        /// Converts from UTC.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        DateTime ConvertFromUtc(DateTime date, string timeZone);

        /// <summary>
        /// Converts the date to UTC.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        DateTime ConvertDateToUtc(string timeZone);

        /// <summary>
        /// Converts the date to UTC.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        DateTime ConvertDateToUtc(DateTime date, string timeZone);

        /// <summary>
        /// To the end of day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DateTime.</returns>
        DateTime ToEndOfDay(DateTime date);

        DateTime ConvertToTimeZone(string timeZone);

        DateTime ConvertToTimeZone(DateTime date, string timeZone);
    }
}

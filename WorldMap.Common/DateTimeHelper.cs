namespace WorldMap.Common
{
    using System;

    public class DateTimeHelper : IDateTimeHelper
    {
        /// <summary>
        /// Gets or sets the now.
        /// </summary>
        /// <value>
        /// The now.
        /// </value>
        public DateTime Now => DateTime.UtcNow;

        public DateTime PreviousDate => Now.Date.AddDays(AppConstants.PreviousDay);

        /// <summary>
        /// Converts to UTC.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        public DateTime ConvertToUtc(string timeZone)
        {
            return ConvertToUtc(Now, timeZone);
        }

        /// <summary>
        /// Converts to UTC.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        public DateTime ConvertToUtc(DateTime date, string timeZone)
        {
            if (string.IsNullOrEmpty(timeZone))
                return Now;

            // Get TimeZone Info by time zone name
            var desireTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            // Convert utc date from desire time zone
            var desireTimeZoneDate = TimeZoneInfo.ConvertTimeFromUtc(date, desireTimeZone);

            return TimeZoneInfo.ConvertTimeToUtc(desireTimeZoneDate);
        }

        /// <summary>
        /// Converts from UTC.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        public DateTime ConvertFromUtc(string timeZone)
        {
            return ConvertFromUtc(Now, timeZone);
        }

        /// <summary>
        /// Converts from UTC.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        public DateTime ConvertFromUtc(DateTime date, string timeZone)
        {
            if (string.IsNullOrEmpty(timeZone))
                return date;

            // Get TimeZone Info by time zone name
            var desireTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            // Convert utc date from desire time zone
            var desireTimeZoneDate = TimeZoneInfo.ConvertTimeFromUtc(date, desireTimeZone);

            return desireTimeZoneDate;
        }

        /// <summary>
        /// Converts the date to UTC.
        /// </summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        public DateTime ConvertDateToUtc(string timeZone)
        {
            return ConvertDateToUtc(DateTime.Now, timeZone);
        }

        /// <summary>
        /// Converts the date to UTC.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeZone">The time zone.</param>
        /// <returns></returns>
        public DateTime ConvertDateToUtc(DateTime date, string timeZone)
        {
            if (string.IsNullOrEmpty(timeZone))
                return DateTime.UtcNow;

            var desireTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            var desireTimeZoneDate = TimeZoneInfo.ConvertTime(date, desireTimeZone, TimeZoneInfo.Local);

            return TimeZoneInfo.ConvertTimeToUtc(desireTimeZoneDate);
        }

        public DateTime ConvertToTimeZone(string timeZone)
        {
            return ConvertToTimeZone(DateTime.Now, timeZone);
        }

        public DateTime ConvertToTimeZone(DateTime date, string timeZone)
        {
            if (string.IsNullOrEmpty(timeZone))
                return date;

            var desireTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            return TimeZoneInfo.ConvertTime(date, desireTimeZone);
        }

        /// <summary>
        /// This methods used for append end day time to date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.DateTime.</returns>
        public DateTime ToEndOfDay(DateTime date)
        {
            return date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }
    }
}

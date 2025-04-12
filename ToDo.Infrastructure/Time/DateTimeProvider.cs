
using ToDo.Shared;

namespace ToDo.Infrastructure.Time
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => GetTime();

        private static DateTime GetTime()
        {
            DateTime utcNow = DateTime.UtcNow;

            TimeZoneInfo southAfricaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time");
            return  TimeZoneInfo.ConvertTimeFromUtc(utcNow, southAfricaTimeZone);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime CentralTime(this DateTime date)
        {
            var centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            return TimeZoneInfo.ConvertTimeFromUtc(date.ToUniversalTime(), centralTimeZone);
        }
    }
}

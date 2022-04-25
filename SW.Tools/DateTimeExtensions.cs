using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools
{
    internal static class DateTimeExtensions
    {
        internal static DateTime ShortDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        internal static DateTime CentralTime(this DateTime date)
        {
            var centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            return TimeZoneInfo.ConvertTimeFromUtc(date.ToUniversalTime(), centralTimeZone);
        }
        internal static void GetElapsedYears(DateTime dateFrom, DateTime dateTo, ref int elapsedYears)
        {
            if (dateFrom <= dateTo)
            {
                elapsedYears = elapsedYears + 1;
                GetElapsedYears(dateFrom.AddYears(1), dateTo, ref elapsedYears);
            }
        }
        internal static void GetElapsedMonths(DateTime dateFrom, DateTime dateTo, ref int elapsedMonths)
        {
            if (dateFrom <= dateTo)
            {
                elapsedMonths = elapsedMonths + 1;
                GetElapsedMonths(dateFrom.AddMonths(1), dateTo, ref elapsedMonths);
            }
        }
        internal static void GetElapsedDays(DateTime dateFrom, DateTime dateTo, ref int elapsedDays)
        {
            if (dateFrom <= dateTo)
            {
                elapsedDays = elapsedDays + 1;
                GetElapsedDays(dateFrom.AddDays(1), dateTo, ref elapsedDays);
            }
        }

        internal static string DateTimeFixCFDI(string v1, string xml, string v2)
        {
            throw new NotImplementedException();
        }
    }
}

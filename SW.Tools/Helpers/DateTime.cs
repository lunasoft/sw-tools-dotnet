using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SW.Tools.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime CentralTime(this DateTime date)
        {
            var centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            return TimeZoneInfo.ConvertTimeFromUtc(date.ToUniversalTime(), centralTimeZone);
        }
        public static string DateTimeFixCFDI(string attribute, string xmlComprobante, string character)
        {
            Regex exp = new Regex(attribute + @"" + character + @"""(?<captured>[^\?=\&\#]*)""", RegexOptions.Compiled);
            MatchCollection MatchList = exp.Matches(xmlComprobante);
            if (0 < MatchList.Count)
            {
                string oldValue = MatchList[0].ToString();
                DateTime dateTime = DateTime.Parse(MatchList[0].Groups[1].Value);

                string newValue = attribute + @"" + character + @"""" + String.Format("{0:s}", dateTime) + @"""";

                xmlComprobante = xmlComprobante.Replace(oldValue, newValue);
            }

            return xmlComprobante;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SW.Tools
{
    public class Fiscal
    {
        /// <summary>
        /// Remueve caracteres invalidos de un xml para poder parserlo.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoverCaracteresInvalidosXml(string str)
        {
            str = str.Replace("\r\n", "");
            str = str.Replace("\r", "");
            str = str.Replace("\n", "");
            str = str.Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", @"<?xml version=""1.0"" encoding=""utf-8""?>").Trim();
            str = str.Replace("﻿", "");
            str = str.Replace(@"
", "");
            return str;
        }
        /// <summary>
        /// Validacion de Rfc ( Mexico Fisica/Moral )
        /// </summary>
        /// <param name="rfc"></param>
        /// <returns>bool</returns>
        public static bool ValidarRfc(string rfc)
        {
            try
            {
                RegexOptions regexOptions = RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline;

                Regex moralRegex = new Regex("^[A-Za-zñÑ&]{3}\\d{6}[A-Za-z0-9]{3}$", regexOptions);
                Regex fisicaRegex = new Regex("^[A-Za-zñÑ]{4}\\d{6}[A-Za-z0-9]{3}$", regexOptions);

                if (moralRegex.IsMatch(rfc))
                {
                    DateTime fechaResultado;
                    DateTime.TryParseExact(rfc.Substring(3, 6), "yyMMdd", null, System.Globalization.DateTimeStyles.AdjustToUniversal, out fechaResultado);

                    if (fechaResultado != null)
                        return true;
                }
                else if (fisicaRegex.IsMatch(rfc))
                {
                    DateTime fechaResultado;
                    DateTime.TryParseExact(rfc.Substring(4, 6), "yyMMdd", null, System.Globalization.DateTimeStyles.AdjustToUniversal, out fechaResultado);

                    if (fechaResultado != null)
                        return true;
                }

               return false;
            }
            catch (Exception ex)
            {
                throw new Exception("El RFC proporcionado no es correcto, favor de válidar antes de continuar.", ex);
            }


           
        }
        /// <summary>
        /// Calculates Seniority Employee in Weeks (Antiguedad Laboral) P{0}W Ex: P100W P(([1-9][0-9]{0,3})|[0])W
        /// La suma del número de días transcurridos entre la FechaInicioRelLaboral y la FechaFinalPago más uno dividido entre siete.
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public static string AntiguedadSemanas(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var days = (dateTo - dateFrom).TotalDays + 1;
                int result = (int)(days / 7);
                return string.Format("P{0}W", result);
            }
            catch (Exception ex)
            {
                throw new Exception("Los formatos de fecha proporcionados son incorrectos, favor de válidar que las fechas sean correctas. ", ex);
            }
            
        }
        /// <summary>
        /// Calculates Seniority Employee in Y M D (Antiguedad Laboral) P{0}Y{1}M{2}D Ex: P1Y10M5D P(([1-9][0-9]?Y)?([1-9]|1[012])M)?([0]|[1-9]|[12][0-9]|3[01])D
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public static string AntiguedadAnosMesesDias(DateTime dateFrom, DateTime dateTo)
        {
            dateFrom = dateFrom.ShortDate();
            dateTo = dateTo.ShortDate();
            if (dateTo < dateFrom)
                throw new Exception("Date ranges are not valid.");
            YearsMonthsDays result = new YearsMonthsDays();
            //Count by day
            DateTime currentDate = dateFrom;
            int elapsedYears = 0;
            DateTimeExtensions.GetElapsedYears(currentDate.AddYears(1), dateTo, ref elapsedYears);
            result.ElapsedYears = elapsedYears;
            currentDate = currentDate.AddYears(result.ElapsedYears);
            //ElapsedMonths
            int elapsedMonths = 0;
            DateTimeExtensions.GetElapsedMonths(currentDate.AddMonths(1), dateTo, ref elapsedMonths);
            result.ElapsedMonths = elapsedMonths;
            currentDate = currentDate.AddMonths(result.ElapsedMonths);
            //ElapsedDays
            int elapsedDays = 0;
            //Add missing day ( working day )
            DateTimeExtensions.GetElapsedDays(currentDate, dateTo, ref elapsedDays);
            result.ElapsedDays = elapsedDays;
            currentDate = currentDate.AddDays(result.ElapsedDays - 1);
            if (result.ElapsedYears <= 0 && result.ElapsedMonths <= 0)
                return string.Format("P{0}D", result.ElapsedDays);
            else if (result.ElapsedYears > 0 && result.ElapsedMonths == 0)
                return string.Format("P{0}Y{1}D", result.ElapsedYears, result.ElapsedDays);
            else if (result.ElapsedYears <= 0)
                return string.Format("P{0}M{1}D", result.ElapsedMonths, result.ElapsedDays);
            else
                return string.Format("P{0}Y{1}M{2}D", result.ElapsedYears, result.ElapsedMonths, result.ElapsedDays);
        }
    }
}

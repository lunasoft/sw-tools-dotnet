using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Helpers
{
    public static class Coins
    {
        public static decimal TruncateDecimals(this decimal amount, int coinDecimals)
        {
            var pres = (decimal)Math.Pow(10, coinDecimals);
            amount = Math.Truncate(amount * pres);
            return amount / pres;
        }
        public static int GetNumberdecimal(string amount)
        {
            int numbeDecimals = 0;
            try
            {
                if (double.TryParse(amount, out double parsedAmount) && amount.Contains("."))
                {

                    numbeDecimals = amount.Substring(amount.IndexOf(".")).Length - 1;

                }

            }
            catch { numbeDecimals = 0; }

            return numbeDecimals;
        }
        public static decimal RoundEven(this decimal number, int numDecimalPlaces)
        {
            return Math.Round(number, numDecimalPlaces, MidpointRounding.ToEven);
        }
    }
}

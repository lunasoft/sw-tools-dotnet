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
        public static decimal RoundFromZero(this decimal number, int numDecimalPlaces) => Math.Round(number, numDecimalPlaces, MidpointRounding.AwayFromZero);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dal.Extensions
{
    public static class RoundExtensions
    {
        public static decimal Round(this decimal number, int decimals = 2)
        {
            return decimal.Round(number, decimals);
        }
    }
}

using System;

namespace Common.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Round(this decimal value, int precision) => Math.Round(value, precision);
    }
}

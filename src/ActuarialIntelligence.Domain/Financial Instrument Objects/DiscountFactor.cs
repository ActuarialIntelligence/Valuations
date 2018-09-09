using System;

namespace ActuarialIntelligence.Domain.Financial_Instrument_Objects
{
    public static class DiscountFactor
    {
        public static decimal discountFactor(decimal yield, decimal term)
        {
            var d = (1 / (1 + yield));
            var dp = Math.Pow((double)d, (double)term);
            return (decimal)dp;
        }
    }
}

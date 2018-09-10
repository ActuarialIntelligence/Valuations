using ActuarialIntelligence.Domain.Enums;
using System.Collections.Generic;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;
using ActuarialIntelligence.Domain.Reader_Domain_Objects;

namespace ActuarialIntelligence.Domain.ContainerObjects.Expectance
{
    public static class Expectance
    {

        /// <summary>
        /// Use this if CDF values are retrieved externally. The Payout can occor at any given time over teh expected region. 
        /// </summary>
        /// <param name="SurvivalCdf"></param>
        /// <param name="conditionalFundValueAtTime"></param>
        /// <param name="dateIncrementTypes"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public static double ReturnExpectedValue(IDictionary<int, double> SurvivalCdf,
        IList<PolicyData> conditionalFundValueAtTime, 
        DateIncrementTypes dateIncrementTypes, IDictionary<int, double> yield, int expectanceOverPeriod)
        {
            var result = 0d;
            
            foreach (var point in conditionalFundValueAtTime)
            {
                for (int i = 1; i <= expectanceOverPeriod; i++)
                {
                    result += (SurvivalCdf[i]
                        * point.SurrenderValue * (double)DiscountFactor.discountFactor((decimal)yield[i], i));
                }

            }
            return result;
        }

    }
}

using System;
using ActuarialIntelligence.Domain.Enums;
using System.Collections.Generic;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;

namespace ActuarialIntelligence.Domain.ContainerObjects.Expectance
{
    public class Expectance
    {
        ///
        /// 
        /// <summary>
        /// All of this starts at Time zero to term remaining on policy; Set timeIncrement to remaining duration on policy
        /// </summary>
        /// <param name="SurvivalCdf">Probability of surviving for time t in live state</param>
        /// <param name="PDF"></param>
        /// <returns></returns>
        public static double ReturnExpectedValue(Func<int,double> SurvivalCdf, 
            Func<int, double> conditionalFundValueAtTime, DateIncrementTypes dateIncrementTypes, 
            int timeIncrement, int yield)
        {
            var result = 0d;
            for(int i=1;i<timeIncrement;i++)
            {
                result += SurvivalCdf(i) * conditionalFundValueAtTime(i) 
                    * (double)DiscountFactor.discountFactor(yield, timeIncrement);
            }
            return result;
        }
        /// <summary>
        /// Use this if CDF values are retrieved externally.
        /// </summary>
        /// <param name="SurvivalCdf"></param>
        /// <param name="conditionalFundValueAtTime"></param>
        /// <param name="dateIncrementTypes"></param>
        /// <param name="timeIncrement"></param>
        /// <returns></returns>
        public static double ReturnExpectedValue(IList<Point<int, decimal>> SurvivalCdf,
        IList<Point<int, decimal>> conditionalFundValueAtTime, DateIncrementTypes dateIncrementTypes, int timeIncrement,int yield)
        {
            var result = 0d;
            var cnt = 0;
            foreach(var point in conditionalFundValueAtTime)
            {
                result += (double) (SurvivalCdf[cnt].Yval 
                    * point.Yval*DiscountFactor.discountFactor(yield,timeIncrement));
                cnt++;
            }
            return result;
        }

        /// <summary>
        /// Use this if CDF values are retrieved externally.
        /// </summary>
        /// <param name="SurvivalCdf"></param>
        /// <param name="conditionalFundValueAtTime"></param>
        /// <param name="dateIncrementTypes"></param>
        /// <param name="timeIncrement"></param>
        /// <returns></returns>
        public static double ReturnExpectedValue(IDictionary<int, decimal> SurvivalCdf,
        IDictionary<int, decimal> conditionalFundValueAtTime, 
        DateIncrementTypes dateIncrementTypes, int timeIncrement, int yield)
        {
            var result = 0d;
            var cnt = 0;
            foreach (var point in conditionalFundValueAtTime)
            {
                result += (double)(SurvivalCdf[cnt]
                    * point.Value * DiscountFactor.discountFactor(yield, timeIncrement));
                cnt++;
            }
            return result;
        }

    }
}

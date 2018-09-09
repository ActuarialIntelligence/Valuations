using System;
using ActuarialIntelligence.Domain.Enums;
using System.Collections.Generic;


namespace ActuarialIntelligence.Domain.ContainerObjects.Expectance
{
    public class Expectance
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SurvivalCdf">Probability of surviving for time t in live state</param>
        /// <param name="PDF"></param>
        /// <returns></returns>
        public static double ReturnExpectedValue(Func<int,double> SurvivalCdf, 
            Func<int, double> fundValueAtTime, DateIncrementTypes dateIncrementTypes, int timeIncrement)
        {
            var result = 0d;
            for(int i=1;i<timeIncrement;i++)
            {
                result += SurvivalCdf(i) * fundValueAtTime(i);
            }
            return result;
        }

        public static double ReturnExpectedValue(IList<Point<int, decimal>> SurvivalCdf,
        IList<Point<int, decimal>> fundValueAtTime, DateIncrementTypes dateIncrementTypes, int timeIncrement)
        {
            var result = 0d;
            var cnt = 0;
            foreach(var point in fundValueAtTime)
            {
                result += (double) (SurvivalCdf[cnt].Yval * point.Yval);
                cnt++;
            }
            return result;
        }

    }
}

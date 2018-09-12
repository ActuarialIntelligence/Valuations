using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.ContainerObjects.Expectance;
using ActuarialIntelligence.Domain.Expectance;
using ActuarialIntelligence.Domain.Reader_Domain_Objects;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using System.Collections.Generic;

namespace ActuarialIntelligence.Calculators
{
    public class PolicyExpectanceCalculator : ICalculate<PolicyExpectance>
    {
        private readonly IDataReader<Curve> survivalRatesByTermReader;
        private readonly IDataReader<Curve> yieldCurveReader;
        private readonly IDataReader<IList<PolicyData>> policyDataReader;
        public PolicyExpectanceCalculator(IDataReader<Curve> yieldCurveReader, 
            IDataReader<Curve> survivalRatesByTermReader,
            IDataReader<IList<PolicyData>> policyDataReader)
        {
            this.survivalRatesByTermReader = survivalRatesByTermReader;
            this.yieldCurveReader = yieldCurveReader;
            this.policyDataReader = policyDataReader;
        }

        public PolicyExpectance Calculate()
        {
            var policyData = policyDataReader.GetData();
            var yieldCurve = yieldCurveReader.GetData();
            var survivalRatesByTerm = survivalRatesByTermReader.GetData();
            var totalExpectedPayout = 0d;
            foreach(var policy in policyData)
            {
                totalExpectedPayout += Expectance.ReturnExpectedValue(survivalRatesByTerm.keyValuePairs,
                    policyData, Domain.Enums.DateIncrementTypes.Month, yieldCurve.keyValuePairs, (12*50));
            }
            throw new System.NotImplementedException();
        }
    }
}

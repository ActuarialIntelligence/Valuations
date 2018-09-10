using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Expectance;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;

namespace ActuarialIntelligence.Calculators
{
    public class PolicyExpectanceCalculator : ICalculate<PolicyExpectance>
    {
        public readonly IDataReader<YieldCurve> yieldCurveReader;
        public PolicyExpectanceCalculator(IDataReader<YieldCurve> yieldCurveReader)
        {
            this.yieldCurveReader = yieldCurveReader;
        }

        public PolicyExpectance Calculate()
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Collections.Generic;

namespace ActuarialIntelligence.Domain.ContainerObjects
{
    public class Curve
    {
        public IDictionary<int, double> keyValuePairs { get; private set; }
        public Curve(IDictionary<int,double> keyValuePairs)
        {
            this.keyValuePairs = keyValuePairs;
        }

        public double GetYieldAtTerm(int term)
        {
            return keyValuePairs[term];
        }
    }
}

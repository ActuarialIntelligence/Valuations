using ActuarialIntelligence.Domain.Enums;

namespace ActuarialIntelligence.Domain.Reader_Domain_Objects
{
    public class PolicyData
    {
        public PolicyType PolicyType { get; private set; }
        public int Code { get; private set; }
        public int Term { get; private set; }
        public DateIncrementTypes DateIncrementType { get; private set; }
        public double SurrenderValue { get; private set; }
        public PolicyData(int code, PolicyType policyType, int term, 
            DateIncrementTypes dateIncrementType, double surrenderValue)
        {
            PolicyType = policyType;
            Code = code;
            Term = term;
            DateIncrementType = dateIncrementType;
            SurrenderValue = surrenderValue;
        }
    }
}

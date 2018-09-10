using ActuarialIntelligence.Domain.Reader_Domain_Objects;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using System.Collections.Generic;

namespace ActuarialIntelligence.Infrastructure.Readers
{
    public class PolicyDataReader : IDataReader<IList<PolicyData>>
    {
        public void ClearAndDispose()
        {
            throw new System.NotImplementedException();
        }

        public IList<PolicyData> GetData()
        {
            throw new System.NotImplementedException();
        }
    }
}

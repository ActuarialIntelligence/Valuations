using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Infrastructure.Data.Dtos;
using ActuarialIntelligence.Infrastructure.Interfaces.Connection_Interfaces;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using System.Collections.Generic;

namespace ActuarialIntelligence.Infrastructure.Readers
{
    public class YieldCurveReader : IDataReader<YieldCurve>
    {
        private readonly IDataConnection<IList<SimpleArray>> connection;
        public YieldCurveReader(IDataConnection<IList<SimpleArray>> connection)
        {
            this.connection = connection;
        }
        public void ClearAndDispose()
        {
            throw new System.NotImplementedException();
        }

        public YieldCurve GetData()
        {
            var yieldDictionary = new Dictionary<int, double>();
            var rows = connection.LoadData();
            foreach(var row in rows)
            {
                yieldDictionary.Add(int.Parse(row.array[0]), double.Parse(row.array[1]));
            }
            var yieldCurve = new YieldCurve(yieldDictionary);
            return yieldCurve;
        }
    }
}

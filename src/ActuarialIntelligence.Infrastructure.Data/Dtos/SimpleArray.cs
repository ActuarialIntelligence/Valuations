using FileHelpers;

namespace ActuarialIntelligence.Infrastructure.Data.Dtos
{
    [DelimitedRecord(",")]
    public class SimpleArray
    {
        public string[] array; 
    }
}

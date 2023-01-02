using System.Text.Json.Serialization;

namespace TesteTecnicoTarget.Model
{
    public class Faturamento
    {
        [JsonPropertyName("dia")]
        public int Dia { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }
}

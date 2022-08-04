using System.Text.Json.Serialization;

namespace ipmanager.aplication.ProxyDTOs
{
    public class RatesResponse
    {
        [JsonPropertyName("USD")]
        public double USD { get; set; }
    }
}
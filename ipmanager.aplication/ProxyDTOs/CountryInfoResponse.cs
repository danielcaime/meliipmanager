using System.Text.Json.Serialization;

namespace ipmanager.aplication.ProxyDTOs
{
    public class CountryInfoResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("countryCodes")]
        public List<string> CountryCodes { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}
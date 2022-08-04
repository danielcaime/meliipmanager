
using System.Text.Json.Serialization;

namespace ipmanager.aplication.DTOs
{
    public class ManagerResponse
    {
        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("iso_code")]
        public string IsoCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("usd_rate")]
        public double UsdRate { get; set; }

        [JsonPropertyName("euro_rate")]
        public double EuroRate { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }
    }
}

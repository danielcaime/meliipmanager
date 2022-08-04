using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ipmanager.aplication.ProxyDTOs
{
    public class CurrencyRateResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("rates")]
        public RatesResponse Rates { get; set; }
    }
}

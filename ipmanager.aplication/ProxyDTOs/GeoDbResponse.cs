using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ipmanager.aplication.ProxyDTOs
{
    public class GeoDbResponse
    {
        [JsonPropertyName("data")]
        public List<CountryInfoResponse> Data { get; set; }

        [JsonPropertyName("metadata")]
        public MetadataResponse Metadata { get; set; }
    }
}

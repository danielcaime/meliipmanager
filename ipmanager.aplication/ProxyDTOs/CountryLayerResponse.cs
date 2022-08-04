using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ipmanager.aplication.ProxyDTOs
{
    public class CountryLayerResponse : List<CountryLayer>
    {

    }
    public class CountryLayer
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("topLevelDomain")]
        public List<string> TopLevelDomain { get; set; }

        [JsonPropertyName("alpha2Code")]
        public string Alpha2Code { get; set; }

        [JsonPropertyName("alpha3Code")]
        public string Alpha3Code { get; set; }

        [JsonPropertyName("callingCodes")]
        public List<string> CallingCodes { get; set; }

        [JsonPropertyName("capital")]
        public string Capital { get; set; }

        [JsonPropertyName("altSpellings")]
        public List<string> AltSpellings { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}

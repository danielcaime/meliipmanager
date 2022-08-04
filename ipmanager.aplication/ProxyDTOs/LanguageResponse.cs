using System.Text.Json.Serialization;

namespace ipmanager.aplication.ProxyDTOs
{
    public class LanguageResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("native")]
        public string Native { get; set; }
    }
}
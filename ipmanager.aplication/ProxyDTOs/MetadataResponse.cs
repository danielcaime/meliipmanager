using System.Text.Json.Serialization;

namespace ipmanager.aplication.ProxyDTOs
{
    public class MetadataResponse
    {
        [JsonPropertyName("currentOffset")]
        public int CurrentOffset { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
    }
}
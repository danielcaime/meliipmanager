using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ipmanager.aplication.HttpClients
{
    public class HttpClientBase
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public HttpClientBase(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<T> Get<T>(string method)
        {
            using (var response = await _client.GetAsync(method, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<T>(stream, _options);
                return result;
            }
        }
    }
}

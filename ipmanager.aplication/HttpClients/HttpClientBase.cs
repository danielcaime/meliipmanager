using System.Text.Json;
using System.Reflection;
using System.Globalization;

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
        public async Task<T> Get<T>(string method, object queryData)
        {
            var query = GetQueryString(queryData);
            using (var response = await _client.GetAsync($"{method}{query}", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<T>(stream, _options);
                return result;
            }
        }

        private object GetQueryString(object queryData)
        {
            if (queryData == null)
                return string.Empty;

            var properties = from p in queryData.GetType().GetProperties()
                             where p.GetValue(queryData, null) != null
                             select p.Name + "=" + GetPropertyValue(p, queryData);

            return "?" + string.Join("&", properties.ToArray());
        }

        private string GetPropertyValue(PropertyInfo p, object o)
        {
            var propertyValue = p.GetValue(o, null);

            if (propertyValue.GetType() == typeof(DateTime))
            {
                return ((DateTime)propertyValue).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return System.Net.WebUtility.UrlEncode(propertyValue.ToString());
            }
        }
    }
}
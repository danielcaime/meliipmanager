using ipmanager.aplication.HttpClients;
using ipmanager.aplication.Interfaces;
using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Services
{
    public class CountryService : ICountryService
    {
        private readonly GeoDbClient _client;

        public CountryService(GeoDbClient geoDbClient)
        {
            _client = geoDbClient;
        }

        public async Task<CountryInfoResponse> GetCountryInfo(string isoCode)
        {
            var response = await _client.Get<GeoDbResponse>($"/v1/locale/currencies",new { countryId = isoCode, limit = 1 });
            return response.Data.FirstOrDefault();
        }
    }
}

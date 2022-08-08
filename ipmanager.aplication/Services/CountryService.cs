using ipmanager.aplication.HttpClients;
using ipmanager.aplication.Interfaces;
using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Services
{
    public class CountryService : ICountryService
    {
        private readonly GeoDbClient _client;
        private readonly ICacheService _cacheService;

        public CountryService(GeoDbClient geoDbClient, ICacheService cacheService)
        {
            _client = geoDbClient;
            _cacheService = cacheService;
        }

        public async Task<CountryInfoResponse> GetCountryInfo(string isoCode)
        {
            CountryInfoResponse countryInfoResponse;
            countryInfoResponse = await _cacheService.Get<CountryInfoResponse>(isoCode);

            if (countryInfoResponse == null)
            {
                var response = await _client.Get<GeoDbResponse>($"/v1/locale/currencies", new { countryId = isoCode, limit = 1 });
                countryInfoResponse = response.Data.FirstOrDefault();
                await _cacheService.Set<CountryInfoResponse>(isoCode, countryInfoResponse);
            }

            return countryInfoResponse;
        }
    }
}

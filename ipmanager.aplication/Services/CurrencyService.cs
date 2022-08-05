using ipmanager.aplication.HttpClients;
using ipmanager.aplication.Interfaces;
using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly CurrencyClient _currencyClient;
        private readonly ICacheService _cacheService;

        public CurrencyService(CurrencyClient currencyClient, ICacheService cacheService)
        {
            _currencyClient = currencyClient;
            _cacheService = cacheService;
        }

        public async Task<CurrencyRateResponse> GetRates(string currencyBase, string symbols = "USD")
        {
            CurrencyRateResponse currencyRateResponse;
            currencyRateResponse = _cacheService.Get<CurrencyRateResponse>(currencyBase);
            if (currencyRateResponse == null)
            {
                currencyRateResponse = await _currencyClient.Get<CurrencyRateResponse>($"/latest", new { Base = currencyBase, Symbols = symbols });
                _cacheService.Set<CurrencyRateResponse>(currencyBase, currencyRateResponse);
            }
            return currencyRateResponse;
        }
    }
}

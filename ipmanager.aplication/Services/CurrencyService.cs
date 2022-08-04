using ipmanager.aplication.HttpClients;
using ipmanager.aplication.Interfaces;
using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly CurrencyClient _currencyClient;

        public CurrencyService(CurrencyClient currencyClient)
        {
            _currencyClient = currencyClient;
        }

        public async Task<CurrencyRateResponse> GetRates(string currencyBase, string symbols = "USD")
        {
            var response = await _currencyClient.Get<CurrencyRateResponse>($"/latest", new { Base = currencyBase, Symbols = symbols });
            return response;
        }
    }
}

using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyRateResponse> GetRates(string currencyBase, string symbols = "USD");
    }
}

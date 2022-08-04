using ipmanager.aplication.DTOs;
using ipmanager.aplication.Interfaces;

namespace ipmanager.aplication.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ICountryService _countryService;
        private readonly IIpService _ipService;
        private readonly ICurrencyService _currencyService;

        public ManagerService(ICountryService countryService, IIpService ipService, ICurrencyService currencyService)
        {
            _countryService = countryService;
            _ipService = ipService;
            _currencyService = currencyService;
        }

        public async Task<ManagerResponse> GetInfoByIp(string model)
        {
            ManagerResponse managerResponse;

            //step1 get ip country info
            var ipInfo = await _ipService.GetIPInfo(model);
            
            //step2 get country currency info
            var countryInfo = await _countryService.GetCountryInfo(ipInfo.CountryCode);
            //step3 get currency rate info
            var ratesInfo = await _currencyService.GetRates(countryInfo.Code);

            //map
            managerResponse = new ManagerResponse {
                CountryName = ipInfo.CountryName,
                Currency = countryInfo.Code,
                IsoCode = ipInfo.CountryCode,
                USDRate = ratesInfo.Rates.USD
            };
            return managerResponse;
        }
    }
}
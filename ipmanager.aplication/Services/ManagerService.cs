using ipmanager.aplication.DTOs;
using ipmanager.aplication.Interfaces;

namespace ipmanager.aplication.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ICountryService _countryService;
        private readonly IIpService _ipService;
        private readonly ICurrencyService _currencyService;
        private readonly IBanService _banService;

        public ManagerService(ICountryService countryService, IIpService ipService, ICurrencyService currencyService, IBanService banService)
        {
            _countryService = countryService;
            _ipService = ipService;
            _currencyService = currencyService;
            _banService = banService;
        }

        public async Task Ban(string model)
        {
            await _banService.Add(model);
        }

        public async Task BanRemove(string model)
        {
            await _banService.Remove(model);
        }

        public async Task<ManagerResponse> GetInfoByIp(string model)
        {
            if (await _banService.Exist(model))
                throw new Exception("Banned/prohibido");

            ManagerResponse managerResponse;

            //step1 get ip country info
            var ipInfo = await _ipService.GetIPInfo(model);

            //step2 get country currency info
            var countryInfo = await _countryService.GetCountryInfo(ipInfo.CountryCode);
            //step3 get currency rate info
            var ratesInfo = await _currencyService.GetRates(countryInfo.Code);

            //map
            managerResponse = new ManagerResponse
            {
                Model = model,
                CountryName = ipInfo.CountryName,
                Currency = countryInfo.Code,
                IsoCode = ipInfo.CountryCode,
                UsdRate = ratesInfo.Rates.USD
            };
            return managerResponse;
        }
    }
}
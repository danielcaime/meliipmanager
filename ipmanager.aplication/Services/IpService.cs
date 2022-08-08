using ipmanager.aplication.HttpClients;
using ipmanager.aplication.Interfaces;
using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Services
{
    public class IpService : IIpService
    {
        private readonly IpApiClient _ipApiClient;
        private readonly ICacheService _cacheService;
        public IpService(IpApiClient ipApiClient, ICacheService cacheService)
        {
            _ipApiClient = ipApiClient;
            _cacheService = cacheService;
        }

        public async Task<IpApiResponse> GetIPInfo(string ipstr)
        {
            IpApiResponse ipApiResponse;

            ipApiResponse = await _cacheService.Get<IpApiResponse>(ipstr);
            if (ipApiResponse == null)
            {
                ipApiResponse = await _ipApiClient.Get<IpApiResponse>($"/{ipstr}", new { access_key = "af8320b02dbdf6d44fd6f73a3045341a" });
                await _cacheService.Set<IpApiResponse>(ipstr, ipApiResponse);
            }

            return ipApiResponse;
        }
    }
}
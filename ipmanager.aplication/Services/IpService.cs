using ipmanager.aplication.HttpClients;
using ipmanager.aplication.Interfaces;
using ipmanager.aplication.ProxyDTOs;
using Microsoft.Extensions.Caching.Memory;

namespace ipmanager.aplication.Services
{
    public class IpService : IIpService
    {
        private readonly IpApiClient _ipApiClient;
        private readonly IMemoryCache _memoryCache;
        public IpService(IpApiClient ipApiClient, IMemoryCache memoryCache)
        {
            _ipApiClient = ipApiClient;
            _memoryCache = memoryCache;
        }

        public async Task<IpApiResponse> GetIPInfo(string ipstr)
        {
            IpApiResponse ipApiResponse;

            ipApiResponse = GetCached(ipstr);
            if (ipApiResponse == null)
            {
                ipApiResponse = await _ipApiClient.Get<IpApiResponse>($"/{ipstr}", new { access_key = "af8320b02dbdf6d44fd6f73a3045341a" });
                SetCache(ipstr, ipApiResponse);
            }

            return ipApiResponse;
        }

        private void SetCache(string key, IpApiResponse ipApiResponse)
        {
            _memoryCache.Set(key, ipApiResponse, DateTime.Now.AddHours(1));
        }

        private IpApiResponse GetCached(string key)
        {
            return _memoryCache.Get<IpApiResponse>(key);
        }
    }
}
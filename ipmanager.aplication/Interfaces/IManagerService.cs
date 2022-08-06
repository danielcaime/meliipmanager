using ipmanager.aplication.DTOs;
using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerResponse> GetInfoByIp(string model);
        Task Ban(string model);
        Task BanRemove(string ip);
        Task<IpApiResponse> GetIpInfo(string model);
        Task<CountryInfoResponse> GetCountryInfo(string countryCode);
        Task<bool> IsBanned(string model);
    }
}

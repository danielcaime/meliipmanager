
using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Interfaces
{
    public interface IIpService
    {
        Task<IpApiResponse> GetIPInfo(string ipstr);
    }
}

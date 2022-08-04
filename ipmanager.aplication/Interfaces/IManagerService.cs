using ipmanager.aplication.DTOs;

namespace ipmanager.aplication.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerResponse> GetInfoByIp(string model);
        Task Ban(string model);
        Task BanRemove(string ip);
    }
}

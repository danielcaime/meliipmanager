using ipmanager.domain.Models;

namespace ipmanager.domain.Interfaces
{
    public interface IIpModelRepository
    {
        Task<bool> Exists(string model);
        Task Add(IpModel entity);
        Task Delete(string model);
    }
}


namespace ipmanager.aplication.Interfaces
{
    public interface IBanService
    {
        Task Add(string model);
        Task<bool> Exist(string model);
        Task Remove(string model);
    }
}

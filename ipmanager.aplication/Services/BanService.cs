using ipmanager.aplication.Interfaces;
using ipmanager.domain.Interfaces;

namespace ipmanager.aplication.Services
{
    public class BanService : IBanService
    {
        private readonly IIpModelRepository _ipModelRepository;
        public BanService(IIpModelRepository ipModelRepository)
        {
            _ipModelRepository = ipModelRepository;
        }

        public async Task Add(string model)
        {
            await _ipModelRepository.Add(new domain.Models.IpModel { CreatedAt = DateTime.Now, Ip = model });
        }

        public async Task<bool> Exist(string model)
        {
            return await _ipModelRepository.Exists(model);
        }

        public async Task Remove(string model)
        {
            await _ipModelRepository.Delete(model);
        }
    }
}
using ipmanager.aplication.Interfaces;

namespace ipmanager.aplication.Services
{
    public class BanService : IBanService
    {
        private List<string> _bannedIps;

        public BanService()
        {
            _bannedIps = new List<string>();
        }
        public async Task Add(string model)
        {
            await Task.Run(() =>
            {
                _bannedIps.Add(model);
            });
        }

        public async Task<bool> Exist(string model)
        {
            return await Task.Run(() =>
            {
               return  _bannedIps.Exists(m => m.Equals(model));
            });
        }

        public async Task Remove(string model)
        {
            await Task.Run(() =>
            {
                _bannedIps.Remove(model);
            });

        }
    }
}
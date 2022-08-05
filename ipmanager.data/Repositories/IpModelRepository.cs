using ipmanager.data.Contexts;
using ipmanager.domain.Interfaces;
using ipmanager.domain.Models;

namespace ipmanager.data.Repositories
{
    public class IpModelRepository : IIpModelRepository
    {
        private readonly DataContext _context;

        public IpModelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(IpModel entity)
        {
            _context.Set<IpModel>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string model)
        {
            var result = _context.Set<IpModel>().FirstOrDefault(m => m.Ip.Equals(model));
            _context.Set<IpModel>().Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string model)
        {
            return await Task.Run(() =>
            {
                var res = _context.Set<IpModel>().AsQueryable().FirstOrDefault(m => m.Ip.Equals(model));
                return res != null;
            });
        }
    }
}

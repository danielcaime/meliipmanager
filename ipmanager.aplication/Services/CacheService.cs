using ipmanager.aplication.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace ipmanager.aplication.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _cache;

        public CacheService(IMemoryCache memoryCache,IDistributedCache distributedCache)
        {
            _memoryCache = memoryCache;
            _cache = distributedCache;
        }

        public async Task<T> Get<T>(string key) where T : class
        {
            //COMMENT FOR USE IDISTRIBUTEDCACHE
            return _memoryCache.Get<T>(key);
            
            //UNCOMMENT FOR USE IDISTRIBUTEDCACHE
            //var jsonData = await _cache.GetStringAsync(key);
            //if (jsonData == null)
            //{
            //    return default(T);
            //}
            //return JsonSerializer.Deserialize<T>(jsonData);
        }

        public async Task Set<T>(string key,T model) where T : class
        {
            //COMMENT FOR USE IDISTRIBUTEDCACHE
            _memoryCache.Set(key, model, DateTime.Now.AddHours(1));

            //UNCOMMENT FOR USE IDISTRIBUTEDCACHE
            //var options = new DistributedCacheEntryOptions();
            //options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
            //var jsonData = JsonSerializer.Serialize(model);
            //await _cache.SetStringAsync(key, jsonData, options);
        }
    }
}

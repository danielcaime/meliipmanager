using ipmanager.aplication.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipmanager.aplication.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key) where T : class
        {
            return _memoryCache.Get<T>(key);
        }

        public void Set<T>(string key,T model) where T : class
        {
            _memoryCache.Set(key, model, DateTime.Now.AddHours(1));
        }
    }
}

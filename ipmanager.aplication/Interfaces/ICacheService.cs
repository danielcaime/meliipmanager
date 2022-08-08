using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipmanager.aplication.Interfaces
{
    public interface ICacheService
    {
        /// <summary>
        /// Distributed cache
        /// for use DistributedCache uncomment commented lines and comment firts line(in geter and seter)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> Get<T>(string key) where T : class;
        Task Set<T>(string key, T model) where T : class;
    }
}
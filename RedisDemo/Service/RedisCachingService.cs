using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Distributed;
using RedisDemo.Interface;
using System;
using System.Threading.Tasks;

namespace RedisDemo.Service
{
    public class RedisCachingService : IRedisCaching
    {
        private IDistributedCache redisCache;
        public RedisCachingService(IDistributedCache cache)
        {
            redisCache= cache;
        }
        public async Task<string> GetRecordsFromRedis(string key)
        {            
            string url = redisCache.GetString(key);
            return url;
        }

        public void SetRecordsInRedis(string key,string content)
        {
            
            var options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(10));
            redisCache.SetString(key,content,options);
            var a = redisCache.GetString(key);
        }
    }
}

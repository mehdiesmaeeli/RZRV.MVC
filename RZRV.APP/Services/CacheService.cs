using Microsoft.Extensions.Caching.Memory;
using RZRV.APP.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace RZRV.APP.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null)
        {
            if (!_memoryCache.TryGetValue(key, out T cachedItem))
            {
                cachedItem = await factory();

                var cacheEntryOptions = new MemoryCacheEntryOptions();
                if (expiration.HasValue)
                {
                    cacheEntryOptions.SetAbsoluteExpiration(expiration.Value);
                }
                else
                {
                    cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromMinutes(30));
                }

                _memoryCache.Set(key, cachedItem, cacheEntryOptions);
            }

            return cachedItem;
        }

        public Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(string key)
        {
            return Task.FromResult(_memoryCache.TryGetValue(key, out _));
        }
    }
}


namespace Cache.Redis.Cache
{
    public static class CacheStartup
    {
        public static void AddCacheProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            string cacheProvider = configuration.GetSection("CacheProvider").Value;
            if (!string.IsNullOrEmpty(cacheProvider))
            {
                const string providerName = "Default";
                services.AddEFCacheProvider(providerName);

                if (cacheProvider == "redis")
                {
                    services.AddRedisCacheProvider(configuration, providerName);

                }
                else if (cacheProvider == "inmemory")
                {
                    services.AddInMemoryCacheProvider(configuration, providerName);
                }
            }
            else
            {
                services.AddInMemoryEFCacheProvider();
            }
        }

    }
}
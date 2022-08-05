using ipmanager.aplication.Interfaces;
using ipmanager.aplication.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIpService, IpService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IBanService, BanService>();
            services.AddSingleton<ICacheService, CacheService>();
               
            
            return services;
        }
    }
}

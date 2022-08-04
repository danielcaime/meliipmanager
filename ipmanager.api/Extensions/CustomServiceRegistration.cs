using ipmanager.aplication.HttpClients;
using Microsoft.Extensions.Caching.Memory;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomServiceRegistration
    {
        public static IServiceCollection CustomConfigureServices(this IServiceCollection services, WebApplicationBuilder builder)
        {

            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAplicationServices();
            services.AddClients();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            return services;
        }


        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            //services urls
            services.AddHttpClient<IpApiClient>(opt =>
            {
                opt.BaseAddress = new Uri("http://api.ipapi.com");//TODO: move to setting json file
            });

            //services.AddHttpClient<CountrylayerClient>(opt => {
            //    opt.BaseAddress = new Uri("http://api.countrylayer.com");
            //});

            services.AddHttpClient<CurrencyClient>(opt => {
                opt.BaseAddress = new Uri("https://fixer-fixer-currency-v1.p.rapidapi.com");
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Key", "340c5b558fmsh863ba30555a3c8fp1d0cd0jsnf511fbf1d0a1");
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Host", "fixer-fixer-currency-v1.p.rapidapi.com");
            });

            services.AddHttpClient<GeoDbClient>(opt => {
                opt.BaseAddress = new Uri("https://wft-geo-db.p.rapidapi.com");
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Key", "340c5b558fmsh863ba30555a3c8fp1d0cd0jsnf511fbf1d0a1");
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Host", "wft-geo-db.p.rapidapi.com");
            });
            return services;
        }
    }
}
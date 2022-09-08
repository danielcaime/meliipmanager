using FluentValidation;
using FluentValidation.AspNetCore;
using ipmanager.api.Settings;
using ipmanager.api.Validations;
using ipmanager.aplication.HttpClients;
using ipmanager.data.Contexts;
using ipmanager.data.Repositories;
using ipmanager.domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomServiceRegistration
    {
        public static IServiceCollection CustomConfigureServices(this IServiceCollection services, WebApplicationBuilder builder)
        {

            services.AddDbContext<DataContext>();
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ipmanager API",
                    Description = "ipmanager API",
                    Contact = new OpenApiContact
                    {
                        Name = "staff",
                        Email = "caime.daniel@gmail.com",
                    },
                });
            });

            //fluent validations
            services.AddFluentValidationAutoValidation(x =>
            {
                /* more to come here */
            });
            services.AddValidatorsFromAssemblyContaining<ModelValidator>();

            services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            services.AddAplicationServices();
            services.AddClients(builder.Configuration);
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped<IIpModelRepository, IpModelRepository>();
            services.AddStackExchangeRedisCache(opt => {
                opt.Configuration = builder.Configuration.GetConnectionString("RedisUrl");
            });
            return services;
        }

        public static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            //services urls
            services.AddHttpClient<IpApiClient>(opt => {
                opt.BaseAddress = new Uri(appSettings.IpApiUrl);
            });

            services.AddHttpClient<CurrencyClient>(opt => {
                opt.BaseAddress = new Uri(appSettings.CurrencyUrl);
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Key", configuration.GetValue<string>("RapidAPIKey"));
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Host", "fixer-fixer-currency-v1.p.rapidapi.com");
            });

            services.AddHttpClient<GeoDbClient>(opt => {
                opt.BaseAddress = new Uri(appSettings.GeoDbUrl);
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Key", configuration.GetValue<string>("RapidAPIKey"));
                opt.DefaultRequestHeaders.Add("X-RapidAPI-Host", "wft-geo-db.p.rapidapi.com");
            });

            return services;
        }
    }
}
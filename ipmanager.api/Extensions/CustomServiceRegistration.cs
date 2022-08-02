using ipmanager.aplication.HttpClients;

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

            return services;
        }


        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            //services urls
            services.AddHttpClient<IpApiClient>(opt => {
                opt.BaseAddress = new Uri("http://api.ipapi.com");//TODO: move to setting json file
            });

            return services;
        }
    }
}

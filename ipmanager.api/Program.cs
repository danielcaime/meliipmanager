using ipmanager.data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

IWebHostEnvironment _env = builder.Environment;
var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile($"appsettings.{_env.EnvironmentName.ToUpper()}.json", optional: true)
              .AddEnvironmentVariables();

IConfiguration configuration = configurationBuilder.Build();
builder.Configuration.Bind(configuration);

// Add services to the container.
services.CustomConfigureServices(builder);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

app.CustomConfigure();
app.MapControllers();
app.Run();

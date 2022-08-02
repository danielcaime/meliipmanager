var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
services.CustomConfigureServices(builder);

var app = builder.Build();

app.CustomConfigure();
app.MapControllers();
app.Run();

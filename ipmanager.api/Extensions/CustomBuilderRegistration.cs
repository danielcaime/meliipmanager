
namespace Microsoft.AspNetCore.Builder
{
    public static class CustomBuilderRegistration
    {
        public static IApplicationBuilder CustomConfigure(this IApplicationBuilder app)
        {
            
            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            return app;
        }
    }
}

using BookStore.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var services = app.ApplicationServices.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetService<BookStoreDbContext>();

                dbContext.Database.Migrate();
            }
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Book Store API");
                    options.RoutePrefix = string.Empty;
                });
        }
    }
}

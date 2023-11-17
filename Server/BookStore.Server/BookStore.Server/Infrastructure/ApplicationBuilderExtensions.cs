using BookStore.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Infrastructure
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
    }
}

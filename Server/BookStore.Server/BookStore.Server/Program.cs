using BookStore.Server.Data;
using BookStore.Server.Infrastructure;
using BookStore.Server.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BookStoreConnection");
var appSettings = builder.Services.GetAppSettings(builder.Configuration);

builder.Services
    .AddDbContext<BookStoreDbContext>(options =>
        options.UseSqlServer(connectionString))
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting()
    .UseCors(options =>
        {
            options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        })
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
        endpoints.MapControllers())
    .ApplyMigrations();

app.Run();

using BookStore.Server.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Services.GetAppSettings(builder.Configuration);

builder.Services
    .AddDataBase(builder.Configuration)
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddApplicationServices()
    .AddSwagger()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .UseSwaggerUI()
    .UseRouting()
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

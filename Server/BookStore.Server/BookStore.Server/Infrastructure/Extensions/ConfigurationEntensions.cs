namespace BookStore.Server.Infrastructure.Extensions
{
    public static class ConfigurationEntensions
    {
        public static AppSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(appSettingsConfig);

            return appSettingsConfig.Get<AppSettings>();
        }
    }
}

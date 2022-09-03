namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services,IConfiguration configuration)
        {
            return services;
        }
    }
}

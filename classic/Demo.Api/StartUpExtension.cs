using Demo.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Reflection;

namespace System
{
    public static class StartUpExtension
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
            .AddDbContext<EmployeeContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration["ConnectionString"],
                             sqlServerOptionsAction: sqlOptions =>
                             {
                                 sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                             });
            });


            return services;
        }

        public static IServiceCollection EnableCors(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}

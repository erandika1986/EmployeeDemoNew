using Demo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Demo.Application.Common.Interfaces;
using Demo.Domain.Repositories.Base;
using Demo.Infrastructure.Repositories.Base;
using Demo.Domain.Repositories;
using Demo.Infrastructure.Repositories;
using Demo.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("ConnectionString");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IEmployeeContext>(provider => provider.GetRequiredService<EmployeeContext>());

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserReposioty, UserReposioty>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}

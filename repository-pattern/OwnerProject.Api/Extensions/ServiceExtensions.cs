using Microsoft.EntityFrameworkCore;
using OwnerProject.Data;
using OwnerProject.Data.Contract;
using OwnerProject.Data.Repository;
using OwnerProject.Services.Concrete;
using OwnerProject.Services.Contract;

namespace OwnerProject.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["dbconnection:connectionString"];
            services.AddDbContext<OwnerDBContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOwnerService, OwnerService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOwnerRepository, OwnerRepository>();
        }
    }
}
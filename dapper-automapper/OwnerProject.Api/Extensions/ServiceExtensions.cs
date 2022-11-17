using OwnerProject.Domain.Models;
using OwnerProject.Data.Contract;
using OwnerProject.Services.Contract;

namespace OwnerProject.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOwnerService, OwnerService>();

        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Owner>, OwnerRepository>();
        }

        public static void ConfigureDBContext(this IServiceCollection services)
        {
        }

    }

}
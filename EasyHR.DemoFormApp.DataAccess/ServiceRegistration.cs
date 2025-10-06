using EasyHR.DemoFormApp.DataAccess.Abstract;
using EasyHR.DemoFormApp.DataAccess.Concrete;
using EasyHR.DemoFormApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyHR.DemoFormApp.DataAccess
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EasyHR.DemoFormApp.API"))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddDbContext<EasyHRContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}

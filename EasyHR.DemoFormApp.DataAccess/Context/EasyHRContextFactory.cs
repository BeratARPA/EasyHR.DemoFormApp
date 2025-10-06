using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyHR.DemoFormApp.DataAccess.Context
{
    public class EasyHRContextFactory : IDesignTimeDbContextFactory<EasyHRContext>
    {
        public EasyHRContext CreateDbContext(string[] args)
        {
            // API projesinin yolunu belirtin
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EasyHR.DemoFormApp.API"))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EasyHRContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new EasyHRContext(optionsBuilder.Options);
        }
    }
}

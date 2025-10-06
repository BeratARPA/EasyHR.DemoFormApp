using EasyHR.DemoFormApp.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyHR.DemoFormApp.DataAccess.Context
{
    public class EasyHRContext : DbContext
    {
        public EasyHRContext(DbContextOptions<EasyHRContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

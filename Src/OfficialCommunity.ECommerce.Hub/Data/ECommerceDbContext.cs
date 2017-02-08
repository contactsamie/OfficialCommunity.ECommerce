using Microsoft.EntityFrameworkCore;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().ToTable("Operations");
            modelBuilder.Entity<Log>().ToTable("Logs");
        }
    }
}

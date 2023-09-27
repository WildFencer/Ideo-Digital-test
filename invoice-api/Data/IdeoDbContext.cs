using invoice_api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace invoice_api.Data
{
    public class IdeoDbContext: DbContext
    {
        public IdeoDbContext(DbContextOptions<IdeoDbContext> o) : base(o) { }

        public DbSet<InvoiceEntity> Invoices => Set<InvoiceEntity>();
        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
        public DbSet<BillingStatusEntity> BillingStatuses => Set<BillingStatusEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "ideo.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData.Seed(modelBuilder);
        }

    }
}

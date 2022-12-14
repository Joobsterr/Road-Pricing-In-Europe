using BillingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Repository
{
    public class BillDbContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; } = default!;
        public DbSet<Trip> Trips { get; set; } = default!;

        public BillDbContext(DbContextOptions<BillDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=UserDB;User Id=sa; Password=Password1!;";
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();

            base.OnConfiguring(optionsBuilder);
        }
    }
}

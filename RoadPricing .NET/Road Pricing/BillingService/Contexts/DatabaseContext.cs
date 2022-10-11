using BillingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.DatabaseContext
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Bill> Bills { get; set; }
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

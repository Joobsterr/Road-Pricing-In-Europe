using AdministrativeService.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministrativeService.DataBase
{
    public class DatabaseContext: DbContext
    {
        public DbSet<AdministrationPrices>AdministrationPrices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=UserDB;User Id=sa; Password=Password1!;";
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}

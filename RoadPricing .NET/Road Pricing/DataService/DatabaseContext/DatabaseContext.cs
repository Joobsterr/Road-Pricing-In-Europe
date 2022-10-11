using DataService.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataService.DatabaseContext
{
    public class DatabaseContext:DbContext
    {
        public DbSet<DataInputModel> DataInputModel { get; set; }
        public DbSet<DataOutputModel> DataOutputModel { get; set; }
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

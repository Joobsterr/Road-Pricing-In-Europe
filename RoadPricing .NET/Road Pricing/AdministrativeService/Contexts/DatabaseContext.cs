using AdministrativeService.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministrativeService.DataBase
{
    public class DatabaseContext: DbContext
    {
        public DbSet<AdministrationPrices>AdministrationPrices { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}

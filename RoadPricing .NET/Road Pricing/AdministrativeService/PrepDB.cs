using AdministrativeService.DataBase;
using Microsoft.EntityFrameworkCore;

namespace AdministrativeService
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            Console.WriteLine("Prep the database");
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                Console.WriteLine("Seed Data");
                SeedData(servicesScope.ServiceProvider.GetRequiredService<DatabaseContext>());
            }

        }
        public static void SeedData(DatabaseContext context)
        {
            System.Console.WriteLine("Appling Migriations...");
            context.Database.Migrate();
            System.Console.WriteLine("GoData");
        }
    }
}

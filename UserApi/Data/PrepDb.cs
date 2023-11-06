using Microsoft.EntityFrameworkCore;

namespace UserApi.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                MigrateDatabase(context);

                SeedData(context);
            }
        }

        private static void MigrateDatabase(DataContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate(); 
                Console.WriteLine("-->Database migrated to the latest version.");
            }
        }

        private static void SeedData(DataContext context)
        {
            if (!context.users.Any() || !context.comments.Any())
            {
                Console.WriteLine("-->Seeding Data....");
            }
            else
            {
                Console.WriteLine("-->We already have data....");
            }
        }
    }
}

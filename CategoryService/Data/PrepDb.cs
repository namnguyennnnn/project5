namespace CategoryService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }
        private static void SeedData(DataContext context)
        {
            if(!context.categories.Any()|| !context.category_details.Any())
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

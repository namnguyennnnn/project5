using CategoryService.Model;
using Microsoft.EntityFrameworkCore;



namespace CategoryService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<Categories> categories { get; set; }
        public DbSet<CategoryDetail> category_details { get; set; }

    }
}

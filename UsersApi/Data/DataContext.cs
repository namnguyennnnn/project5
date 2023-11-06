using UsersApi.Model;
using Microsoft.EntityFrameworkCore;

namespace UsersApi.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Comment> comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
               .HasOne(c => c.SendingUser) 
               .WithMany(u => u.SentComments) 
               .HasForeignKey(c => c.uid_sending)
               .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ReceivingUser) 
                .WithMany(u => u.ReceivedComments) 
                .HasForeignKey(c => c.uid_receiving)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}

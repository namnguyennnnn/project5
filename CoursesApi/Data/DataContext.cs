using CoursesApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Courses> courses { get; set; }
        public DbSet<CourseDetails> course_details { get; set; }
        public DbSet<Lectures> lectures { get; set; }       
        public DbSet<Ratings> ratings { get; set; }
        public DbSet<Instructors> instructors { get; set; }
        public DbSet<Enrollments> enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lectures>()
               .HasOne(c => c.courseDetail) 
               .WithMany(l => l.lectures) 
               .HasForeignKey(c => c.course_detail_id)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseDetails>()
               .HasOne(c => c.course)
               .WithMany(cd => cd.courseDetails)
               .HasForeignKey(c => c.course_id)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ratings>()
                .HasOne(c => c.course) 
                .WithMany(r => r.ratings) 
                .HasForeignKey(c => c.course_id)
                .OnDelete(DeleteBehavior.Cascade);
           
            modelBuilder.Entity<Courses>()
               .HasOne(i => i.instructor)
               .WithMany(c => c.course)
               .HasForeignKey(c => c.instructor_id);

            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.course)
                .WithOne(c => c.enrollment)
                .HasForeignKey<Enrollments>(e => e.course_id);              
        }
    }
}

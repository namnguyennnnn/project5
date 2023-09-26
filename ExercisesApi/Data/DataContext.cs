using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


namespace ExercisesApi.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Answer> answers { get; set; }
        public DbSet<Exercise> exercises { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Audio> audio { get; set; }       
        public DbSet<Image> images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.question)
                .WithOne(q => q.answer)
                .HasForeignKey<Answer>(a => a.question_id);

            modelBuilder.Entity<Question>()
                .HasOne(a => a.exercise)
                .WithMany(q => q.questions)
                .HasForeignKey(a => a.exercise_id);

            modelBuilder.Entity<Audio>()
               .HasOne(e => e.exercise)
               .WithOne(a => a.audio)
               .HasForeignKey<Audio>(a => a.exercise_id);

            modelBuilder.Entity<Image>()
             .HasOne(q => q.question)
             .WithOne(i => i.image)
             .HasForeignKey<Image>(a => a.question_id);
        }
    }
}

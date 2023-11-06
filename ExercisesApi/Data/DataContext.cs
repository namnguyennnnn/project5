using ExercisesApi.Model;
using Microsoft.EntityFrameworkCore;



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
        public DbSet<Paragraph> paragraphs { get; set; }
        public DbSet<ExamResult> exam_results { get; set; }
        public DbSet<ExamResultDetail> exam_result_details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.question)
                .WithOne(q => q.answer)
                .HasForeignKey<Answer>(a => a.question_id);

            modelBuilder.Entity<Question>()
                .HasOne(e => e.exercise)
                .WithMany(q => q.questions)
                .HasForeignKey(e => e.exercise_id);

            modelBuilder.Entity<Audio>()
               .HasOne(e => e.exercise)
               .WithOne(a => a.audio)
               .HasForeignKey<Audio>(a => a.exercise_id);

            modelBuilder.Entity<Image>()
                 .HasOne(q => q.question)
                 .WithOne(i => i.image)
                 .HasForeignKey<Image>(a => a.question_id);

            modelBuilder.Entity<Paragraph>()
                 .HasOne(q => q.question)
                 .WithOne(i => i.paragraph)
                 .HasForeignKey<Paragraph>(a => a.question_id);

            modelBuilder.Entity<ExamResult>()
                .HasOne(e => e.exercise)
                .WithMany(ex => ex.examResults)
                .HasForeignKey(e => e.exercise_id);

            modelBuilder.Entity<ExamResultDetail>()
               .HasOne(er => er.examResult)
               .WithMany(erd => erd.examResultDetails)
               .HasForeignKey(er => er.exam_result_id);

            modelBuilder.Entity<ExamResultDetail>()
               .HasOne(q => q.question)
               .WithMany(erd => erd.examResultDetail)
               .HasForeignKey(q => q.question_id);
        }
    }
}

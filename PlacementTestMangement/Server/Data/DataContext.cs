using Microsoft.EntityFrameworkCore;
using PlacementTestMangement.Shared.Models;

namespace PlacementTestMangement.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<QuestionType> QuestionTypes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .IsRequired();
            modelBuilder.Entity<QuestionType>().HasData(
                new QuestionType
                {
                    Id = 1,
                    Name = "Grammar",
                    Mark = 100,
                    Minute = 30,
                },
                new QuestionType
                {
                    Id = 2,
                    Name = "Listening",
                    Mark = 100,
                    Minute =30 ,
                },
                new QuestionType
                {
                    Id = 3,
                    Name = "Writing",
                    Mark = 10,
                    Minute = 15,
                });
        }

    }
}


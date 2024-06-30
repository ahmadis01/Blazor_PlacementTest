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
		public DbSet<StudentAnswers> StudentAnswers{ get; set; }

    }
}


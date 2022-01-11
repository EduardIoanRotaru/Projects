using QuizApp.Entities;
using System.Data.Entity;

namespace QuizApp.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() 
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}

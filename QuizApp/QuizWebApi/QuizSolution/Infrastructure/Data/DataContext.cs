using Core.Entities;
using System.Data.Entity;

namespace Infrastructure.Data
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

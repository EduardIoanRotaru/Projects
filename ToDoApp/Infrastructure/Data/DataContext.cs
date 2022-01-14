using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Core.Entities.Task> Tasks {get;set;}
        public DbSet<Comment> Comments{get;set; }

        public DbSet<User> Users {get;set;}
    }
}
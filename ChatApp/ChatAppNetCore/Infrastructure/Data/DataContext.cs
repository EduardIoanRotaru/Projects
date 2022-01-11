using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Image> Images {get;set;}
    }
} 
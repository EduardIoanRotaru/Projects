using Core.Entities;
using Core.Entities.UserProfile;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<AppliedJobs> AppliedJobs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<_UserProfile> UserProfile { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<PersonalSkill> PersonalSkill { get; set; }
        public DbSet<ProfessionalSkill> ProfessionalSkill { get; set; }
    }
}

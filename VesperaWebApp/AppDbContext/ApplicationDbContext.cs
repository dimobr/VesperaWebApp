using Microsoft.EntityFrameworkCore;
using VesperaWebApp.Models;

namespace VesperaWebApp.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<BaseEntity> BaseEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>().HasData(GetSeedDataBaseEntity());
        }

        private static BaseEntity GetSeedDataBaseEntity()
        {
            return new BaseEntity
            {
                Id = 1,
                Name = "Test",
            };
        }
    }
}

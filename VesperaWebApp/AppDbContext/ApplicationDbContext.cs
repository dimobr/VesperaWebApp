using System.Linq;
using Microsoft.EntityFrameworkCore;
using VesperaWebApp.Models;

namespace VesperaWebApp.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<ImageEntityModel> Images { get; set; }
        public DbSet<EmailEntityModel> Emails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageEntityModel>().HasKey(e => e.Id);
            modelBuilder.Entity<EmailEntityModel>().HasKey(e => e.Id);
        }
    }
}

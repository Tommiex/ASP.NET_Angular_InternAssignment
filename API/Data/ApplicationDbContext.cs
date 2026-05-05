using CodePulse.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(u => u.Permissions, p =>
            {
                p.OwnsOne(ps => ps.SuperAdmin);
                p.OwnsOne(ps => ps.Admin);
                p.OwnsOne(ps => ps.Employee);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using TeamTasker.API.Entities;

namespace TeamTasker.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<JobTask> JobTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<JobTask>()
                .HasOne(t => t.User)
                .WithMany(u => u.JobTasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
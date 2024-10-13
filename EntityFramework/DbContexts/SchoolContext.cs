using FluentWay.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentWay.EntityFramework.DbContexts
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}

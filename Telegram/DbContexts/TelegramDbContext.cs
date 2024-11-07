using Microsoft.EntityFrameworkCore;
using Telegram.DbConfigurations;
using Telegram.Models;

namespace Telegram.DbContexts
{
    public class TelegramDbContext : DbContext
    {
        public TelegramDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<PostHistory> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostTypeConfiguration());
        }
    }
}

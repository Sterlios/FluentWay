using Microsoft.EntityFrameworkCore;
using Telegram.DbConfigurations;
using Telegram.Models;

namespace Telegram.DbContexts
{
    internal class TelegramDbContext : DbContext
    {
        public TelegramDbContext(DbContextOptions options) : base(options)
        {
        }

        private DbSet<User> Users { get; set; }
        private DbSet<Role> Roles { get; set; }
        private DbSet<Post> Posts { get; set; }
        private DbSet<TypeOfTime> PostTypes { get; set; }
        private DbSet<Content> Contents { get; set; }
        private DbSet<PostHistory> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new TypeOfTimeConfiguration());
        }
    }
}

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

        private DbSet<UserEntity> Users { get; set; }
        private DbSet<RoleEntity> Roles { get; set; }
        private DbSet<PostEntity> Posts { get; set; }
        private DbSet<PostTypeEntity> PostTypes { get; set; }
        private DbSet<ContentEntity> Contents { get; set; }
        private DbSet<PostHistoryEntity> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostHistoryConfiguration());
        }
    }
}

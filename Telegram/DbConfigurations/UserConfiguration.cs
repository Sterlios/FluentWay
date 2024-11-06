using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.Id);

            builder
                .HasOne(user => user.Role)
                .WithMany(role => role.Users);

            builder
                .HasMany(user => user.Histories)
                .WithOne(history => history.User)
                .HasForeignKey(history => history.UserId);
        }
    }
    internal class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(user => user.Id);

            builder
                .HasMany(role => role.Users)
                .WithOne(user => user.Role);

            builder
                .HasMany(role => role.Posts)
                .WithMany(post => post.Roles);
        }
    }
}

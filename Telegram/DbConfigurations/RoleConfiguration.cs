using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(role => role.Id);

            builder
                .HasMany(role => role.Users)
                .WithOne(user => user.Role);

            builder
                .HasMany(role => role.Posts)
                .WithMany(post => post.Roles);
        }
    }
}

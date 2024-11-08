using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id);

            builder
                .HasMany(role => role.Users)
                .WithOne(user => user.Role);

            builder
                .HasMany(role => role.Posts)
                .WithMany(post => post.Roles);

            builder.HasData(Enum.GetValues(typeof(RoleEnum))
                    .OfType<RoleEnum>()
                    .Select(x => new Role() { Id = x, Name = x.ToString() })
                    .ToArray());
        }
    }
}

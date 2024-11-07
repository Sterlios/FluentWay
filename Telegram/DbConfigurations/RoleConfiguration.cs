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

            builder.HasData(() =>
            {
                var roleTypes = Enum.GetValues(typeof(RoleEnum));
                List<Role> roles = new List<Role>(roleTypes.Length);

                foreach (RoleEnum roleType in roleTypes)
                    roles.Add(new Role()
                    {
                        Id = roleType,
                        Name = roleType.ToString()
                    });

                return roles;
            });
        }
    }
}

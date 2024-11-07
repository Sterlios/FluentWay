using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder
                .HasOne(user => user.Role)
                .WithMany(role => role.Users);

            builder
                .HasMany(user => user.Histories)
                .WithOne(history => history.User);
        }
    }
}

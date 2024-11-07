using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.Id);

            builder
                .HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.Role);

            builder
                .HasMany(user => user.Histories)
                .WithOne(history => history.User);
        }
    }
}

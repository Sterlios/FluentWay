using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class PostHistoryConfiguration : IEntityTypeConfiguration<PostHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<PostHistoryEntity> builder)
        {
            builder.HasKey(postHistory => postHistory.Id);

            builder
                .HasOne(history => history.User)
                .WithMany(user => user.Histories)
                .HasForeignKey(history => history.User);

            builder
                .HasOne(history => history.Post)
                .WithMany(post => post.Histories)
                .HasForeignKey(history => history.Post);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class PostHistoryConfiguration : IEntityTypeConfiguration<PostHistory>
    {
        public void Configure(EntityTypeBuilder<PostHistory> builder)
        {
            builder.HasKey(postHistory => postHistory.Id);

            builder
                .HasOne(history => history.User)
                .WithMany(user => user.Histories);

            builder
                .HasOne(history => history.Post)
                .WithMany(post => post.Histories);
        }
    }
}

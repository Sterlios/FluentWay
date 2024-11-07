using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(post => post.Id);

            builder
                .HasMany(post => post.Roles)
                .WithMany(role => role.Posts);

            builder
                .HasOne(post => post.Content)
                .WithOne(content => content.Post);

            builder
                .HasOne(post => post.Type)
                .WithMany(postType => postType.Posts)
                .HasForeignKey(post => post.Type);

            builder
                .HasMany(post => post.Histories)
                .WithOne(history => history.Post);
        }
    }
}

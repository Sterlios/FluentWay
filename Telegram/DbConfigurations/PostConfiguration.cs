using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(post => post.Id);

            builder
                .HasMany(post => post.Roles)
                .WithMany(role => role.Posts);

            builder
                .HasOne(post => post.Content)
                .WithOne(content => content.Post)
                .HasForeignKey(typeof(Content));

            builder
                .HasOne(post => post.PostType)
                .WithMany(postType => postType.Posts);

            builder
                .HasMany(post => post.Histories)
                .WithOne(history => history.Post);
        }
    }
}

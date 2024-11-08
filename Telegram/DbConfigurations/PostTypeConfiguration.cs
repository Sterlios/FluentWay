using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class PostTypeConfiguration : IEntityTypeConfiguration<PostType>
    {
        public void Configure(EntityTypeBuilder<PostType> builder)
        {
            builder.HasKey(postHistory => postHistory.Id);

            builder
                .HasMany(type => type.Posts)
                .WithOne(post => post.PostType);

            builder.HasData(Enum.GetValues(typeof(PostTypeEnum))
                    .OfType<PostTypeEnum>()
                    .Select(x => new PostType() { Id = x, Name = x.ToString() })
                    .ToArray());
        }
    }
}

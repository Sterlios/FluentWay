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

            builder.HasData(() =>
            {
                var postTypes = Enum.GetValues(typeof(PostTypeEnum));
                List<PostType> posts = new List<PostType>(postTypes.Length);

                foreach (PostTypeEnum postType in postTypes)
                    posts.Add(new PostType()
                    {
                        Id = postType,
                        Name = postType.ToString()
                    });

                return posts.ToArray();
            });
        }
    }
}

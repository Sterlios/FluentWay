using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class PostTypeConfiguration : IEntityTypeConfiguration<PostTypeEntity>
    {
        public void Configure(EntityTypeBuilder<PostTypeEntity> builder)
        {
            builder.HasKey(postHistory => postHistory.Id);

            builder
                .HasMany(type => type.Posts)
                .WithOne(post => post.Type);
        }
    }
}

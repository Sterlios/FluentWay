using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<ContentEntity>
    {
        public void Configure(EntityTypeBuilder<ContentEntity> builder)
        {
            builder.HasKey(content => content.Id);

            builder
                .HasOne(content => content.Post)
                .WithOne(post => post.Content);
        }
    }
}

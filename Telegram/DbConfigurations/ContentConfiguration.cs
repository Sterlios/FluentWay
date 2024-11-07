using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(content => content.Id);

            builder
                .HasOne(content => content.Post)
                .WithOne(post => post.Content);
        }
    }
}

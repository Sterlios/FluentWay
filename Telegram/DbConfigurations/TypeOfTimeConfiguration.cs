using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Telegram.Models;

namespace Telegram.DbConfigurations
{
    public class TypeOfTimeConfiguration : IEntityTypeConfiguration<TypeOfTime>
    {
        public void Configure(EntityTypeBuilder<TypeOfTime> builder)
        {
            builder.HasKey(postHistory => postHistory.Id);

            builder
                .HasMany(type => type.Posts)
                .WithOne(post => post.TypeOfTime);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgresDataAccess.Entities.Map.Topic
{
    public class TopicMap : IEntityTypeConfiguration<Entities.Topic.Topic>
    {
        public void Configure(EntityTypeBuilder<Entities.Topic.Topic> builder)
        {
            builder.ToTable("Topic", "ApiClean");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Name).HasMaxLength(150);
        }

    }
}

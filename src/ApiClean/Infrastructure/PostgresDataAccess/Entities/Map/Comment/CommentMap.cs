using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiClean.Infrastructure.PostgresDataAccess.Entities.Map.Comment
{
    public class CommentMap : IEntityTypeConfiguration<Entities.Comment.Comment>
    {
        public void Configure(EntityTypeBuilder<Entities.Comment.Comment> builder)
        {
            builder.ToTable("Comment", "ApiClean");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.Content).HasMaxLength(1200);
        }
    }
}

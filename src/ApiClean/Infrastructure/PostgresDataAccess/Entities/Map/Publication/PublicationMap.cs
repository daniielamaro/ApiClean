using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.PostgresDataAccess.Entities.Map.Publication
{
    public class PublicationMap : IEntityTypeConfiguration<Entities.Publication.Publication>
    {
        public void Configure(EntityTypeBuilder<Entities.Publication.Publication> builder)
        {
            builder.ToTable("Publication", "ApiClean");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.AutorId).IsRequired();
            builder.Property(u => u.Title).IsRequired();
            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.DateCreated).IsRequired();
            builder.Property(u => u.TopicId).IsRequired();            
            
            builder.HasMany(u => u.Comments);            
        }
    }
}

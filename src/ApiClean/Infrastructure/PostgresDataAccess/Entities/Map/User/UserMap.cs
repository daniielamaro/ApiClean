using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgresDataAccess.Entities.Map.User
{
    public class UserMap : IEntityTypeConfiguration<Entities.User.User>
    {
        public void Configure(EntityTypeBuilder<Entities.User.User> builder)
        {
            builder.ToTable("User", "ApiClean");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(200);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Password).HasMaxLength(100);
        }
    }
}

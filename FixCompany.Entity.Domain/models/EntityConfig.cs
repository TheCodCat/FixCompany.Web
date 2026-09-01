using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixCompany.Entity.Domain.models;

public class EntityConfig : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(x => x.Role).WithMany(x => x.Entitis).HasForeignKey(x => x.RoleId);
    }
}
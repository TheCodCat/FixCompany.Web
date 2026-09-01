using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixCompany.Entity.Domain.models;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.Entitis).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
    }
}
using FixCompany.Entity.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FixCompany.Data.context;

public class FixCompanyContext : DbContext
{
    public DbSet<Entity.Domain.models.Entity> Entities { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FixCompany.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityConfig());
        modelBuilder.ApplyConfiguration(new RoleConfig());

        modelBuilder.Entity<Role>().HasData(new Role[]
        {
            new Role(){Id = 1, Name = "Мастер"},
            new Role(){Id = 2, Name = "Клиент"},
        });
    }
}
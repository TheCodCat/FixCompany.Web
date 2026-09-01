namespace FixCompany.Entity.Domain.models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Entity> Entitis { get; set; }
}
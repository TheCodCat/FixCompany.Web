namespace FixCompany.Entity.Domain.models;

/// <summary>
/// Сущность (клиент и мастер)
/// </summary>
public class Entity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string? LastName { get; set; }
    public string Phone { get; set; }
    public int? RoleId { get; set; }
    public Role? Role { get; set; }
}
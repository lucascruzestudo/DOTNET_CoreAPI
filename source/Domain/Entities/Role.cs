namespace Project.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual IEnumerable<User>? Users { get; set; }

    public Role(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

}
